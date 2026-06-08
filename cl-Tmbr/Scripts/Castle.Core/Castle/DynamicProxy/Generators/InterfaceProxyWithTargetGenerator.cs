using System;
using System.Collections.Generic;
using System.Linq;
using Castle.DynamicProxy.Contributors;
using Castle.DynamicProxy.Serialization;

namespace Castle.DynamicProxy.Generators
{
	internal sealed class InterfaceProxyWithTargetGenerator : BaseInterfaceProxyGenerator
	{
		protected override bool AllowChangeTarget => false;

		protected override string GeneratorType => ProxyTypeConstants.InterfaceWithTarget;

		public InterfaceProxyWithTargetGenerator(ModuleScope scope, Type targetType, Type[] interfaces, Type proxyTargetType, ProxyGenerationOptions options)
			: base(scope, targetType, interfaces, proxyTargetType, options)
		{
		}

		protected override CompositeTypeContributor GetProxyTargetContributor(Type proxyTargetType, INamingScope namingScope)
		{
			return new InterfaceProxyTargetContributor(proxyTargetType, AllowChangeTarget, namingScope)
			{
				Logger = base.Logger
			};
		}

		protected override ProxyTargetAccessorContributor GetProxyTargetAccessorContributor()
		{
			return new ProxyTargetAccessorContributor(() => targetField, proxyTargetType);
		}

		protected override void AddMappingForAdditionalInterfaces(CompositeTypeContributor contributor, Type[] proxiedInterfaces, IDictionary<Type, ITypeContributor> typeImplementerMapping, ICollection<Type> targetInterfaces)
		{
			Type[] array = interfaces;
			foreach (Type type in array)
			{
				if (ImplementedByTarget(targetInterfaces, type) && !proxiedInterfaces.Contains(type))
				{
					contributor.AddInterfaceToProxy(type);
					AddMappingNoCheck(type, contributor, typeImplementerMapping);
				}
			}
		}

		private bool ImplementedByTarget(ICollection<Type> targetInterfaces, Type @interface)
		{
			return targetInterfaces.Contains(@interface);
		}
	}
}
