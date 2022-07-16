//------------------------------------------------------------------------------
//  此代码版权（除特别声明或在TouchSocket.Core.XREF命名空间的代码）归作者本人若汝棋茗所有
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

/* 项目“TouchSocketPro (net5)”的未合并的更改
在此之前:
using TouchSocket.Core.Dependency;
using TouchSocket.Core.Log;
using System;
在此之后:
using System;
using TouchSocket.Core.Dependency;
using TouchSocket.Core.Log;
*/

/* 项目“TouchSocketPro (netcoreapp3.1)”的未合并的更改
在此之前:
using TouchSocket.Core.Dependency;
using TouchSocket.Core.Log;
using System;
在此之后:
using System;
using TouchSocket.Core.Dependency;
using TouchSocket.Core.Log;
*/

/* 项目“TouchSocketPro (netstandard2.0)”的未合并的更改
在此之前:
using TouchSocket.Core.Dependency;
using TouchSocket.Core.Log;
using System;
在此之后:
using System;
using TouchSocket.Core.Dependency;
using TouchSocket.Core.Log;
*/

using System;

namespace TouchSocket.Core.Plugins
{
    /// <summary>
    /// 插件接口
    /// </summary>
    public interface IPlugin : IDisposable
    {
        /// <summary>
        /// 插件执行顺序
        /// <para>该属性值越大，越靠前执行。值相等时，按添加先后顺序</para>
        /// <para>该属性效果，仅在<see cref="IPluginsManager.Add(IPlugin)"/>之前设置有效。</para>
        /// </summary>
        int Order { get; set; }
    }
}