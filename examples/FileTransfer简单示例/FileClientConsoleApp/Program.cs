﻿using System;
using TouchSocket.Core;
using TouchSocket.Core.Config;
using TouchSocket.Core.Log;
using TouchSocket.Core.Plugins;
using TouchSocket.Core.Run;
using TouchSocket.Rpc.TouchRpc;
using TouchSocket.Rpc.TouchRpc.Plugins;
using TouchSocket.Sockets;

namespace FileClientConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TcpTouchRpcClient client = new TouchSocketConfig()
                .SetRemoteIPHost("127.0.0.1:7789")
                .SetVerifyToken("File")
                .UsePlugin()
                .ConfigurePlugins(a =>
                {
                    a.Add<TouchRpcActionPlugin<TcpTouchRpcClient>>()//此处的逻辑可用插件替代完成。
                    .SetFileTransfering((client, e) =>
                    {
                        //有可能是上传，也有可能是下载
                        client.Logger.Info($"服务器请求传输文件，ID={client.ID}，请求类型={e.TransferType}，文件名={e.FileInfo.FileName}");
                    })
                    .SetFileTransfered((client, e) =>
                    {
                        //传输结束，但是不一定成功，需要从e.Result判断状态。
                        client.Logger.Info($"服务器传输文件结束，ID={client.ID}，请求类型={e.TransferType}，文件名={e.FileInfo.FileName}，请求状态={e.Result}");
                    });
                })
                .BuildWithTcpTouchRpcClient();

            client.Logger.Info("连接成功");

            //第一个参数是请求路径，第二个是保存路径。
            FileRequest fileRequest = new FileRequest(@"D:\System\Windows.iso", $@"Windows.iso");

            fileRequest.Flags = TransferFlags.BreakpointResume;//尝试断点续传，使用断点续传时，会验证MD5值

            FileOperator fileOperator = new FileOperator();//实例化本次传输的控制器，用于获取传输进度、速度、状态等。

            fileOperator.Timeout = 60 * 1000;//当传输大文件，且启用断点续传时，服务器可能会先计算MD5，而延时响应，所以需要设置超时时间。

            //此处的作用相当于Timer，定时每秒输出当前的传输进度和速度。
            LoopAction loopAction = LoopAction.CreateLoopAction(-1, 1000, (loop) =>
            {
                if (fileOperator.Result.ResultCode != ResultCode.Default)
                {
                    loop.Dispose();
                }

                client.Logger.Info($"进度：{fileOperator.Progress}，速度：{fileOperator.Speed()}");
            });

            loopAction.RunAsync();

            Metadata metadata = new Metadata();//传递到服务器的元数据
            metadata.Add("1", "1");
            metadata.Add("2", "2");

            //此方法会阻塞，直到传输结束，也可以使用PullFileAsync
            IResult result = client.PullFile(fileRequest, fileOperator, metadata);

            client.Logger.Info(result.ToString());
            Console.ReadKey();
        }
    }
}