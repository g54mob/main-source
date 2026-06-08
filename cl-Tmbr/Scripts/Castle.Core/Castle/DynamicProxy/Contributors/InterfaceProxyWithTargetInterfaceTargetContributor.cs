using System;
using Castle.DynamicProxy.Generators;

namespace Castle.DynamicProxy.Contributors
{
	internal class InterfaceProxyWithTargetInterfaceTargetContributor : InterfaceProxyTargetContributor
	{
		public InterfaceProxyWithTargetInterfaceTargetContributor(Type proxyTargetType, bool allowChangeTarget, INamingScope namingScope)
			: base(proxyTargetType, allowChangeTarget, namingScope)
		{
		}

		protected override MembersCollector GetCollectorForInterface(Type @interface)
		{
			return new InterfaceMembersCollector(@interface);
		}
	}
}
