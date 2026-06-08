using System;
using System.Reflection;
using Castle.DynamicProxy.Generators;

namespace Castle.DynamicProxy.Contributors
{
	public class InterfaceMembersCollector : MembersCollector
	{
		public InterfaceMembersCollector(Type @interface)
			: base(@interface)
		{
		}

		protected override MetaMethod GetMethodToGenerate(MethodInfo method, IProxyGenerationHook hook, bool isStandalone)
		{
			if (!ProxyUtil.IsAccessibleMethod(method))
			{
				return null;
			}
			bool proxyable = AcceptMethod(method, onlyVirtuals: false, hook);
			return new MetaMethod(method, method, isStandalone, proxyable, hasTarget: false);
		}
	}
}
