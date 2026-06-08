using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.DynamicProxy.Contributors;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Serialization;

namespace Castle.DynamicProxy.Generators
{
	internal sealed class InterfaceProxyWithTargetInterfaceGenerator : BaseInterfaceProxyGenerator
	{
		protected override bool AllowChangeTarget => true;

		protected override string GeneratorType => ProxyTypeConstants.InterfaceWithTargetInterface;

		public InterfaceProxyWithTargetInterfaceGenerator(ModuleScope scope, Type targetType, Type[] interfaces, Type proxyTargetType, ProxyGenerationOptions options)
			: base(scope, targetType, interfaces, proxyTargetType, options)
		{
		}

		protected override CompositeTypeContributor GetProxyTargetContributor(Type proxyTargetType, INamingScope namingScope)
		{
			return new InterfaceProxyWithTargetInterfaceTargetContributor(proxyTargetType, AllowChangeTarget, namingScope)
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

		protected override InterfaceProxyWithoutTargetContributor GetContributorForAdditionalInterfaces(INamingScope namingScope)
		{
			return new InterfaceProxyWithOptionalTargetContributor(namingScope, GetTargetExpression, GetTarget)
			{
				Logger = base.Logger
			};
		}

		private Reference GetTarget(ClassEmitter @class, MethodInfo method)
		{
			return new AsTypeReference(@class.GetField("__target"), method.DeclaringType);
		}

		private IExpression GetTargetExpression(ClassEmitter @class, MethodInfo method)
		{
			return GetTarget(@class, method);
		}
	}
}
