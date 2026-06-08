using System;
using System.Reflection;

namespace Castle.Core
{
	public static class ProxyServices
	{
		public static bool IsDynamicProxy(Type type)
		{
			string fullName = type.GetTypeInfo().Assembly.FullName;
			if (!fullName.StartsWith("DynamicAssemblyProxyGen", StringComparison.Ordinal))
			{
				return fullName.StartsWith("DynamicProxyGenAssembly2", StringComparison.Ordinal);
			}
			return true;
		}
	}
}
