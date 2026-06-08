using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.DynamicProxy.Contributors;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Serialization;

namespace Castle.DynamicProxy.Generators
{
	internal sealed class InterfaceProxyWithoutTargetGenerator : BaseInterfaceProxyGenerator
	{
		protected override bool AllowChangeTarget => false;

		protected override string GeneratorType => ProxyTypeConstants.InterfaceWithoutTarget;

		public InterfaceProxyWithoutTargetGenerator(ModuleScope scope, Type targetType, Type[] interfaces, Type proxyTargetType, ProxyGenerationOptions options)
			: base(scope, targetType, interfaces, proxyTargetType, options)
		{
		}

		protected override CompositeTypeContributor GetProxyTargetContributor(Type proxyTargetType, INamingScope namingScope)
		{
			return new InterfaceProxyWithoutTargetContributor(namingScope, (ClassEmitter c, MethodInfo m) => NullExpression.Instance)
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
		}

		protected override IEnumerable<Type> GetTypeImplementerMapping(Type _, out IEnumerable<ITypeContributor> contributors, INamingScope namingScope)
		{
			return base.GetTypeImplementerMapping(targetType, out contributors, namingScope);
		}
	}
}
