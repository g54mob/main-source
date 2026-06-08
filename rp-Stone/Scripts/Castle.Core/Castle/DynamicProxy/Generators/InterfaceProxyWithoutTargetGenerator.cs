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
	public class InterfaceProxyWithoutTargetGenerator : InterfaceProxyWithTargetGenerator
	{
		protected override string GeneratorType => ProxyTypeConstants.InterfaceWithoutTarget;

		public InterfaceProxyWithoutTargetGenerator(ModuleScope scope, Type @interface)
			: base(scope, @interface)
		{
		}

		protected override ITypeContributor AddMappingForTargetType(IDictionary<Type, ITypeContributor> interfaceTypeImplementerMapping, Type proxyTargetType, ICollection<Type> targetInterfaces, ICollection<Type> additionalInterfaces, INamingScope namingScope)
		{
			InterfaceProxyWithoutTargetContributor interfaceProxyWithoutTargetContributor = new InterfaceProxyWithoutTargetContributor(namingScope, (ClassEmitter c, MethodInfo m) => NullExpression.Instance)
			{
				Logger = base.Logger
			};
			Type[] allInterfaces = targetType.GetAllInterfaces();
			foreach (Type type in allInterfaces)
			{
				interfaceProxyWithoutTargetContributor.AddInterfaceToProxy(type);
				AddMappingNoCheck(type, interfaceProxyWithoutTargetContributor, interfaceTypeImplementerMapping);
			}
			return interfaceProxyWithoutTargetContributor;
		}

		protected override Type GenerateType(string typeName, Type proxyTargetType, Type[] interfaces, INamingScope namingScope)
		{
			IEnumerable<ITypeContributor> contributors;
			IEnumerable<Type> typeImplementerMapping = GetTypeImplementerMapping(interfaces, targetType, out contributors, namingScope);
			MetaType model = new MetaType();
			foreach (ITypeContributor item in contributors)
			{
				item.CollectElementsToProxy(base.ProxyGenerationOptions.Hook, model);
			}
			base.ProxyGenerationOptions.Hook.MethodsInspected();
			ClassEmitter emitter;
			FieldReference interceptorsField;
			Type baseType = Init(typeName, out emitter, proxyTargetType, out interceptorsField, typeImplementerMapping);
			ConstructorEmitter constructorEmitter = GenerateStaticConstructor(emitter);
			List<FieldReference> list = new List<FieldReference>();
			foreach (ITypeContributor item2 in contributors)
			{
				item2.Generate(emitter, base.ProxyGenerationOptions);
				if (item2 is MixinContributor)
				{
					list.AddRange((item2 as MixinContributor).Fields);
				}
			}
			List<FieldReference> list2 = new List<FieldReference>(list) { interceptorsField, targetField };
			FieldReference field = emitter.GetField("__selector");
			if (field != null)
			{
				list2.Add(field);
			}
			GenerateConstructors(emitter, baseType, list2.ToArray());
			CompleteInitCacheMethod(constructorEmitter.CodeBuilder);
			Type type = emitter.BuildType();
			InitializeStaticFields(type);
			return type;
		}
	}
}
