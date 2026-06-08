using System;
using System.Reflection;
using Castle.DynamicProxy.Generators;

namespace Castle.DynamicProxy.Contributors
{
	internal class InterfaceMembersCollector : MembersCollector
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
			bool flag = AcceptMethod(method, onlyVirtuals: true, hook);
			if (!flag && !method.IsAbstract)
			{
				return null;
			}
			return new MetaMethod(method, method, isStandalone, flag, hasTarget: false);
		}
	}
}
