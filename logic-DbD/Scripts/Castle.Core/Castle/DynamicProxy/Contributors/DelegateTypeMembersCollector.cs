using System;
using System.Reflection;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy.Contributors
{
	internal sealed class DelegateTypeMembersCollector : MembersCollector
	{
		public DelegateTypeMembersCollector(Type delegateType)
			: base(delegateType)
		{
		}

		protected override MetaMethod GetMethodToGenerate(MethodInfo method, IProxyGenerationHook hook, bool isStandalone)
		{
			if (method.Name == "Invoke" && method.DeclaringType.IsDelegateType())
			{
				return new MetaMethod(method, method, isStandalone, proxyable: true, hasTarget: false);
			}
			return null;
		}
	}
}
