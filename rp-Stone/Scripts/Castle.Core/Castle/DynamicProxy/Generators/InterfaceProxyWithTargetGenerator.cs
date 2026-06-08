using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Castle.DynamicProxy.Contributors;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Internal;
using Castle.DynamicProxy.Serialization;

namespace Castle.DynamicProxy.Generators
{
	public class InterfaceProxyWithTargetGenerator : BaseProxyGenerator
	{
		protected FieldReference targetField;

		protected virtual bool AllowChangeTarget => false;

		protected virtual string GeneratorType => ProxyTypeConstants.InterfaceWithTarget;

		public InterfaceProxyWithTargetGenerator(ModuleScope scope, Type @interface)
			: base(scope, @interface)
		{
			CheckNotGenericTypeDefinition(@interface, "@interface");
		}

		public Type GenerateCode(Type proxyTargetType, Type[] interfaces, ProxyGenerationOptions options)
		{
			options.Initialize();
			CheckNotGenericTypeDefinition(proxyTargetType, "proxyTargetType");
			CheckNotGenericTypeDefinitions(interfaces, "interfaces");
			EnsureValidBaseType(options.BaseTypeForInterfaceProxy);
			base.ProxyGenerationOptions = options;
			interfaces = TypeUtil.GetAllInterfaces(interfaces);
			CacheKey cacheKey = new CacheKey(proxyTargetType.GetTypeInfo(), targetType, interfaces, options);
			return ObtainProxyType(cacheKey, (string n, INamingScope s) => GenerateType(n, proxyTargetType, interfaces, s));
		}

		protected virtual ITypeContributor AddMappingForTargetType(IDictionary<Type, ITypeContributor> typeImplementerMapping, Type proxyTargetType, ICollection<Type> targetInterfaces, ICollection<Type> additionalInterfaces, INamingScope namingScope)
		{
			InterfaceProxyTargetContributor interfaceProxyTargetContributor = new InterfaceProxyTargetContributor(proxyTargetType, AllowChangeTarget, namingScope)
			{
				Logger = base.Logger
			};
			Type[] allInterfaces = targetType.GetAllInterfaces();
			Type[] array = allInterfaces;
			foreach (Type type in array)
			{
				interfaceProxyTargetContributor.AddInterfaceToProxy(type);
				AddMappingNoCheck(type, interfaceProxyTargetContributor, typeImplementerMapping);
			}
			foreach (Type additionalInterface in additionalInterfaces)
			{
				if (ImplementedByTarget(targetInterfaces, additionalInterface) && !allInterfaces.Contains(additionalInterface))
				{
					interfaceProxyTargetContributor.AddInterfaceToProxy(additionalInterface);
					AddMappingNoCheck(additionalInterface, interfaceProxyTargetContributor, typeImplementerMapping);
				}
			}
			return interfaceProxyTargetContributor;
		}

		protected override void CreateTypeAttributes(ClassEmitter emitter)
		{
			base.CreateTypeAttributes(emitter);
			emitter.DefineCustomAttribute<SerializableAttribute>();
		}

		protected virtual Type GenerateType(string typeName, Type proxyTargetType, Type[] interfaces, INamingScope namingScope)
		{
			IEnumerable<ITypeContributor> contributors;
			IEnumerable<Type> typeImplementerMapping = GetTypeImplementerMapping(interfaces, proxyTargetType, out contributors, namingScope);
			ClassEmitter emitter;
			FieldReference interceptorsField;
			Type baseType = Init(typeName, out emitter, proxyTargetType, out interceptorsField, typeImplementerMapping);
			MetaType model = new MetaType();
			foreach (ITypeContributor item in contributors)
			{
				item.CollectElementsToProxy(base.ProxyGenerationOptions.Hook, model);
			}
			base.ProxyGenerationOptions.Hook.MethodsInspected();
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
			list.Add(interceptorsField);
			list.Add(targetField);
			FieldReference field = emitter.GetField("__selector");
			if (field != null)
			{
				list.Add(field);
			}
			GenerateConstructors(emitter, baseType, list.ToArray());
			CompleteInitCacheMethod(constructorEmitter.CodeBuilder);
			Type type = emitter.BuildType();
			InitializeStaticFields(type);
			return type;
		}

		protected virtual InterfaceProxyWithoutTargetContributor GetContributorForAdditionalInterfaces(INamingScope namingScope)
		{
			return new InterfaceProxyWithoutTargetContributor(namingScope, (ClassEmitter c, MethodInfo m) => NullExpression.Instance)
			{
				Logger = base.Logger
			};
		}

		protected virtual IEnumerable<Type> GetTypeImplementerMapping(Type[] interfaces, Type proxyTargetType, out IEnumerable<ITypeContributor> contributors, INamingScope namingScope)
		{
			IDictionary<Type, ITypeContributor> dictionary = new Dictionary<Type, ITypeContributor>();
			MixinContributor mixinContributor = new MixinContributor(namingScope, AllowChangeTarget)
			{
				Logger = base.Logger
			};
			Type[] allInterfaces = proxyTargetType.GetAllInterfaces();
			Type[] allInterfaces2 = TypeUtil.GetAllInterfaces(interfaces);
			ITypeContributor typeContributor = AddMappingForTargetType(dictionary, proxyTargetType, allInterfaces, allInterfaces2, namingScope);
			if (base.ProxyGenerationOptions.HasMixins)
			{
				foreach (Type mixinInterface in base.ProxyGenerationOptions.MixinData.MixinInterfaces)
				{
					if (allInterfaces.Contains(mixinInterface))
					{
						if (allInterfaces2.Contains(mixinInterface))
						{
							AddMapping(mixinInterface, typeContributor, dictionary);
						}
						mixinContributor.AddEmptyInterface(mixinInterface);
					}
					else if (!dictionary.ContainsKey(mixinInterface))
					{
						mixinContributor.AddInterfaceToProxy(mixinInterface);
						dictionary.Add(mixinInterface, mixinContributor);
					}
				}
			}
			InterfaceProxyWithoutTargetContributor contributorForAdditionalInterfaces = GetContributorForAdditionalInterfaces(namingScope);
			Type[] array = allInterfaces2;
			foreach (Type type in array)
			{
				if (!dictionary.ContainsKey(type) && !base.ProxyGenerationOptions.MixinData.ContainsMixin(type))
				{
					contributorForAdditionalInterfaces.AddInterfaceToProxy(type);
					AddMappingNoCheck(type, contributorForAdditionalInterfaces, dictionary);
				}
			}
			InterfaceProxyInstanceContributor interfaceProxyInstanceContributor = new InterfaceProxyInstanceContributor(targetType, GeneratorType, interfaces);
			AddMappingForISerializable(dictionary, interfaceProxyInstanceContributor);
			try
			{
				AddMappingNoCheck(typeof(IProxyTargetAccessor), interfaceProxyInstanceContributor, dictionary);
			}
			catch (ArgumentException)
			{
				HandleExplicitlyPassedProxyTargetAccessor(allInterfaces, allInterfaces2);
			}
			contributors = new List<ITypeContributor> { typeContributor, contributorForAdditionalInterfaces, mixinContributor, interfaceProxyInstanceContributor };
			return dictionary.Keys;
		}

		protected virtual Type Init(string typeName, out ClassEmitter emitter, Type proxyTargetType, out FieldReference interceptorsField, IEnumerable<Type> interfaces)
		{
			Type baseTypeForInterfaceProxy = base.ProxyGenerationOptions.BaseTypeForInterfaceProxy;
			emitter = BuildClassEmitter(typeName, baseTypeForInterfaceProxy, interfaces);
			CreateFields(emitter, proxyTargetType);
			CreateTypeAttributes(emitter);
			interceptorsField = emitter.GetField("__interceptors");
			return baseTypeForInterfaceProxy;
		}

		private void CreateFields(ClassEmitter emitter, Type proxyTargetType)
		{
			base.CreateFields(emitter);
			targetField = emitter.CreateField("__target", proxyTargetType);
			emitter.DefineCustomAttributeFor<XmlIgnoreAttribute>(targetField);
		}

		private void EnsureValidBaseType(Type type)
		{
			if (type == null)
			{
				throw new ArgumentException("Base type for proxy is null reference. Please set it to System.Object or some other valid type.");
			}
			if (!type.GetTypeInfo().IsClass)
			{
				ThrowInvalidBaseType(type, "it is not a class type");
			}
			if (type.GetTypeInfo().IsSealed)
			{
				ThrowInvalidBaseType(type, "it is sealed");
			}
			ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
			if (constructor == null || constructor.IsPrivate)
			{
				ThrowInvalidBaseType(type, "it does not have accessible parameterless constructor");
			}
		}

		private bool ImplementedByTarget(ICollection<Type> targetInterfaces, Type @interface)
		{
			return targetInterfaces.Contains(@interface);
		}

		private void ThrowInvalidBaseType(Type type, string doesNotHaveAccessibleParameterlessConstructor)
		{
			throw new ArgumentException($"Type {type} is not valid base type for interface proxy, because {doesNotHaveAccessibleParameterlessConstructor}. Only a non-sealed class with non-private default constructor can be used as base type for interface proxy. Please use some other valid type.");
		}
	}
}
