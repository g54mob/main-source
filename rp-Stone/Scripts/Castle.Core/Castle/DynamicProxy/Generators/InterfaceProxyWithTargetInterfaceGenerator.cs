using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.DynamicProxy.Contributors;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Internal;
using Castle.DynamicProxy.Serialization;

namespace Castle.DynamicProxy.Generators
{
	public class InterfaceProxyWithTargetInterfaceGenerator : InterfaceProxyWithTargetGenerator
	{
		protected override bool AllowChangeTarget => true;

		protected override string GeneratorType => ProxyTypeConstants.InterfaceWithTargetInterface;

		public InterfaceProxyWithTargetInterfaceGenerator(ModuleScope scope, Type @interface)
			: base(scope, @interface)
		{
		}

		protected override ITypeContributor AddMappingForTargetType(IDictionary<Type, ITypeContributor> typeImplementerMapping, Type proxyTargetType, ICollection<Type> targetInterfaces, ICollection<Type> additionalInterfaces, INamingScope namingScope)
		{
			InterfaceProxyWithTargetInterfaceTargetContributor interfaceProxyWithTargetInterfaceTargetContributor = new InterfaceProxyWithTargetInterfaceTargetContributor(proxyTargetType, AllowChangeTarget, namingScope)
			{
				Logger = base.Logger
			};
			Type[] allInterfaces = targetType.GetAllInterfaces();
			foreach (Type type in allInterfaces)
			{
				interfaceProxyWithTargetInterfaceTargetContributor.AddInterfaceToProxy(type);
				AddMappingNoCheck(type, interfaceProxyWithTargetInterfaceTargetContributor, typeImplementerMapping);
			}
			return interfaceProxyWithTargetInterfaceTargetContributor;
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

		private Expression GetTargetExpression(ClassEmitter @class, MethodInfo method)
		{
			return GetTarget(@class, method).ToExpression();
		}
	}
}
