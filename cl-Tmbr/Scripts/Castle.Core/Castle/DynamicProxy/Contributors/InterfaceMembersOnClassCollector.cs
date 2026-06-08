using System;
using System.Reflection;
using Castle.DynamicProxy.Generators;

namespace Castle.DynamicProxy.Contributors
{
	internal class InterfaceMembersOnClassCollector : MembersCollector
	{
		private readonly InterfaceMapping map;

		private readonly bool onlyProxyVirtual;

		public InterfaceMembersOnClassCollector(Type type, bool onlyProxyVirtual, InterfaceMapping map)
			: base(type)
		{
			this.onlyProxyVirtual = onlyProxyVirtual;
			this.map = map;
		}

		protected override MetaMethod GetMethodToGenerate(MethodInfo method, IProxyGenerationHook hook, bool isStandalone)
		{
			if (!ProxyUtil.IsAccessibleMethod(method))
			{
				return null;
			}
			if (onlyProxyVirtual && IsVirtuallyImplementedInterfaceMethod(method))
			{
				return null;
			}
			MethodInfo methodOnTarget = GetMethodOnTarget(method);
			bool proxyable = AcceptMethod(method, onlyProxyVirtual, hook);
			return new MetaMethod(method, methodOnTarget, isStandalone, proxyable, !methodOnTarget.IsPrivate);
		}

		private MethodInfo GetMethodOnTarget(MethodInfo method)
		{
			int num = Array.IndexOf(map.InterfaceMethods, method);
			if (num == -1)
			{
				return null;
			}
			return map.TargetMethods[num];
		}

		private bool IsVirtuallyImplementedInterfaceMethod(MethodInfo method)
		{
			MethodInfo methodOnTarget = GetMethodOnTarget(method);
			if (methodOnTarget != null)
			{
				return !methodOnTarget.IsFinal;
			}
			return false;
		}
	}
}
