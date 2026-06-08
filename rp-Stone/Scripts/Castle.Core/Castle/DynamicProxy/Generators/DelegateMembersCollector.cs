using System;
using System.Reflection;
using Castle.DynamicProxy.Contributors;

namespace Castle.DynamicProxy.Generators
{
	public class DelegateMembersCollector : MembersCollector
	{
		public DelegateMembersCollector(Type type)
			: base(type)
		{
		}

		protected override MetaMethod GetMethodToGenerate(MethodInfo method, IProxyGenerationHook hook, bool isStandalone)
		{
			if (!AcceptMethod(method, onlyVirtuals: true, hook))
			{
				return null;
			}
			return new MetaMethod(method, method, isStandalone, proxyable: true, !method.IsAbstract);
		}
	}
}
