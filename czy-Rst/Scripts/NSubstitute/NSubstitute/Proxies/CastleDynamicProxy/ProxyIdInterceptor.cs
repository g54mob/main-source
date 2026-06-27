using System;
using System.Globalization;
using System.Reflection;
using Castle.DynamicProxy;
using NSubstitute.Core;

namespace NSubstitute.Proxies.CastleDynamicProxy
{
	public class ProxyIdInterceptor : IInterceptor
	{
		private string? _cachedProxyId;

		public ProxyIdInterceptor(Type primaryProxyType)
		{
			_003CprimaryProxyType_003EP = primaryProxyType;
			base._002Ector();
		}

		public void Intercept(IInvocation invocation)
		{
			if (IsDefaultToStringMethod(invocation.Method))
			{
				invocation.ReturnValue = _cachedProxyId ?? (_cachedProxyId = GenerateId(invocation));
			}
			else
			{
				invocation.Proceed();
			}
		}

		private string GenerateId(IInvocation invocation)
		{
			object invocationTarget = invocation.InvocationTarget;
			string nonMangledTypeName = _003CprimaryProxyType_003EP.GetNonMangledTypeName();
			int hashCode = invocationTarget.GetHashCode();
			return string.Format(CultureInfo.InvariantCulture, "Substitute.{0}|{1:x8}", nonMangledTypeName, hashCode);
		}

		public static bool IsDefaultToStringMethod(MethodInfo methodInfo)
		{
			if (methodInfo.DeclaringType == typeof(object) && string.Equals(methodInfo.Name, "ToString", StringComparison.Ordinal))
			{
				return methodInfo.GetParameters().Length == 0;
			}
			return false;
		}
	}
}
