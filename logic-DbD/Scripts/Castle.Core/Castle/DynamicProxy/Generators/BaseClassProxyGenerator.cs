using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy.Contributors;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy.Generators
{
	internal abstract class BaseClassProxyGenerator : BaseProxyGenerator
	{
		protected abstract FieldReference TargetField { get; }

		protected BaseClassProxyGenerator(ModuleScope scope, Type targetType, Type[] interfaces, ProxyGenerationOptions options)
			: base(scope, targetType, interfaces, options)
		{
			EnsureDoesNotImplementIProxyTargetAccessor(targetType, "targetType");
		}

		protected abstract CompositeTypeContributor GetProxyTargetContributor(INamingScope namingScope);

		protected abstract ProxyTargetAccessorContributor GetProxyTargetAccessorContributor();

		protected sealed override Type GenerateType(string name, INamingScope namingScope)
		{
			IEnumerable<ITypeContributor> contributors;
			IEnumerable<Type> typeImplementerMapping = GetTypeImplementerMapping(out contributors, namingScope);
			MetaType model = new MetaType();
			foreach (ITypeContributor item in contributors)
			{
				item.CollectElementsToProxy(base.ProxyGenerationOptions.Hook, model);
			}
			base.ProxyGenerationOptions.Hook.MethodsInspected();
			ClassEmitter classEmitter = BuildClassEmitter(name, targetType, typeImplementerMapping);
			CreateFields(classEmitter);
			CreateTypeAttributes(classEmitter);
			ConstructorEmitter constructorEmitter = GenerateStaticConstructor(classEmitter);
			List<FieldReference> list = new List<FieldReference>();
			FieldReference targetField = TargetField;
			if (targetField != null)
			{
				list.Add(targetField);
			}
			foreach (ITypeContributor item2 in contributors)
			{
				item2.Generate(classEmitter);
				if (item2 is MixinContributor mixinContributor)
				{
					list.AddRange(mixinContributor.Fields);
				}
			}
			FieldReference field = classEmitter.GetField("__interceptors");
			list.Add(field);
			FieldReference field2 = classEmitter.GetField("__selector");
			if (field2 != null)
			{
				list.Add(field2);
			}
			GenerateConstructors(classEmitter, targetType, list.ToArray());
			GenerateParameterlessConstructor(classEmitter, targetType, field);
			CompleteInitCacheMethod(constructorEmitter.CodeBuilder);
			new NonInheritableAttributesContributor(targetType).Generate(classEmitter);
			Type type = classEmitter.BuildType();
			InitializeStaticFields(type);
			return type;
		}

		private IEnumerable<Type> GetTypeImplementerMapping(out IEnumerable<ITypeContributor> contributors, INamingScope namingScope)
		{
			List<ITypeContributor> list = new List<ITypeContributor>(5);
			Type[] allInterfaces = targetType.GetAllInterfaces();
			Dictionary<Type, ITypeContributor> dictionary = new Dictionary<Type, ITypeContributor>();
			CompositeTypeContributor proxyTargetContributor = GetProxyTargetContributor(namingScope);
			list.Add(proxyTargetContributor);
			if (base.ProxyGenerationOptions.HasMixins)
			{
				MixinContributor mixinContributor = new MixinContributor(namingScope, canChangeTarget: false)
				{
					Logger = base.Logger
				};
				list.Add(mixinContributor);
				foreach (Type mixinInterface in base.ProxyGenerationOptions.MixinData.MixinInterfaces)
				{
					if (allInterfaces.Contains(mixinInterface))
					{
						if (interfaces.Contains(mixinInterface) && !dictionary.ContainsKey(mixinInterface))
						{
							AddMappingNoCheck(mixinInterface, proxyTargetContributor, dictionary);
							proxyTargetContributor.AddInterfaceToProxy(mixinInterface);
						}
						mixinContributor.AddEmptyInterface(mixinInterface);
					}
					else if (!dictionary.ContainsKey(mixinInterface))
					{
						mixinContributor.AddInterfaceToProxy(mixinInterface);
						AddMappingNoCheck(mixinInterface, mixinContributor, dictionary);
					}
				}
			}
			if (interfaces.Length != 0)
			{
				InterfaceProxyWithoutTargetContributor interfaceProxyWithoutTargetContributor = new InterfaceProxyWithoutTargetContributor(namingScope, (ClassEmitter c, MethodInfo m) => NullExpression.Instance)
				{
					Logger = base.Logger
				};
				list.Add(interfaceProxyWithoutTargetContributor);
				Type[] array = interfaces;
				foreach (Type type in array)
				{
					if (allInterfaces.Contains(type))
					{
						if (!dictionary.ContainsKey(type))
						{
							AddMappingNoCheck(type, proxyTargetContributor, dictionary);
							proxyTargetContributor.AddInterfaceToProxy(type);
						}
					}
					else if (!base.ProxyGenerationOptions.MixinData.ContainsMixin(type))
					{
						interfaceProxyWithoutTargetContributor.AddInterfaceToProxy(type);
						AddMapping(type, interfaceProxyWithoutTargetContributor, dictionary);
					}
				}
			}
			ProxyTargetAccessorContributor proxyTargetAccessorContributor = GetProxyTargetAccessorContributor();
			list.Add(proxyTargetAccessorContributor);
			try
			{
				AddMappingNoCheck(typeof(IProxyTargetAccessor), proxyTargetAccessorContributor, dictionary);
			}
			catch (ArgumentException)
			{
				HandleExplicitlyPassedProxyTargetAccessor(allInterfaces);
			}
			contributors = list;
			return dictionary.Keys;
		}

		private void EnsureDoesNotImplementIProxyTargetAccessor(Type type, string name)
		{
			if (!typeof(IProxyTargetAccessor).IsAssignableFrom(type))
			{
				return;
			}
			throw new ArgumentException($"Target type for the proxy implements {typeof(IProxyTargetAccessor)} which is a DynamicProxy infrastructure interface and you should never implement it yourself. Are you trying to proxy an existing proxy?", name);
		}
	}
}
