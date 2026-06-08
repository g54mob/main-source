using System;
using System.ComponentModel;
using System.Reflection;

namespace Castle.DynamicProxy.Internal
{
	public static class InternalsUtil
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete]
		public static bool IsInternal(this MethodBase method)
		{
			return ProxyUtil.IsInternal(method);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete]
		public static bool IsInternalToDynamicProxy(this Assembly asm)
		{
			return ProxyUtil.AreInternalsVisibleToDynamicProxy(asm);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use ProxyUtil.IsAccessible instead, which performs a more accurate accessibility check.")]
		public static bool IsAccessible(this MethodBase method)
		{
			return ProxyUtil.IsAccessibleMethod(method);
		}
	}
}
