//------------------------------------------------------------------------------
//  此代码版权（除特别声明或在RRQMCore.XREF命名空间的代码）归作者本人若汝棋茗所有
//  源代码使用协议遵循本仓库的开源协议及附加协议，若本仓库没有设置，则按MIT开源协议授权
//  CSDN博客：https://blog.csdn.net/qq_40374647
//  哔哩哔哩视频：https://space.bilibili.com/94253567
//  Gitee源代码仓库：https://gitee.com/RRQM_Home
//  Github源代码仓库：https://github.com/RRQM
//  API首页：https://www.yuque.com/eo2w71/rrqm
//  交流QQ群：234762506
//  感谢您的下载和使用
//------------------------------------------------------------------------------
//------------------------------------------------------------------------------

using RRQMCore.Dependency;

namespace RRQMSocket.RPC.XmlRpc
{
    /// <summary>
    /// XmlRpcParser配置
    /// </summary>
    public class XmlRpcParserConfig : TcpServiceConfig
    {
        /// <summary>
        /// 代理令箭，当获取代理文件时需验证令箭
        /// </summary>
        public string ProxyToken
        {
            get { return (string)this.GetValue(ProxyTokenProperty); }
            set { this.SetValue(ProxyTokenProperty, value); }
        }

        /// <summary>
        /// 代理令箭，当获取代理文件时需验证令箭, 所需类型<see cref="string"/>
        /// </summary>
        public static readonly DependencyProperty ProxyTokenProperty =
            DependencyProperty.Register("ProxyToken", typeof(string), typeof(XmlRpcParserConfig), null);

        /// <summary>
        /// 最大数据包长度
        /// </summary>
        public int MaxPackageSize
        {
            get { return (int)this.GetValue(MaxPackageSizeProperty); }
            set { this.SetValue(MaxPackageSizeProperty, value); }
        }

        /// <summary>
        /// 最大数据包长度，所需类型<see cref="int"/>
        /// </summary>
        public static readonly DependencyProperty MaxPackageSizeProperty =
            DependencyProperty.Register("MaxPackageSize", typeof(int), typeof(XmlRpcParserConfig), 1024);
    }
}