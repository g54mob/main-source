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
	internal abstract class BaseInterfaceProxyGenerator : BaseProxyGenerator
	{
		protected readonly Type proxyTargetType;

		protected FieldReference targetField;

		protected abstract bool AllowChangeTarget { get; }

		protected abstract string GeneratorType { get; }

		protected BaseInterfaceProxyGenerator(ModuleScope scope, Type targetType, Type[] interfaces, Type proxyTargetType, ProxyGenerationOptions options)
			: base(scope, targetType, interfaces, options)
		{
			CheckNotGenericTypeDefinition(proxyTargetType, "proxyTargetType");
			EnsureValidBaseType(base.ProxyGenerationOptions.BaseTypeForInterfaceProxy);
			this.proxyTargetType = proxyTargetType;
		}

		protected abstract CompositeTypeContributor GetProxyTargetContributor(Type proxyTargetType, INamingScope namingScope);

		protected abstract ProxyTargetAccessorContributor GetProxyTargetAccessorContributor();

		protected abstract void AddMappingForAdditionalInterfaces(CompositeTypeContributor contributor, Type[] proxiedInterfaces, IDictionary<Type, ITypeContributor> typeImplementerMapping, ICollection<Type> targetInterfaces);

		protected virtual ITypeContributor AddMappingForTargetType(IDictionary<Type, ITypeContributor> typeImplementerMapping, Type proxyTargetType, ICollection<Type> targetInterfaces, INamingScope namingScope)
		{
			CompositeTypeContributor proxyTargetContributor = GetProxyTargetContributor(proxyTargetType, namingScope);
			Type[] allInterfaces = targetType.GetAllInterfaces();
			Type[] array = allInterfaces;
			foreach (Type type in array)
			{
				proxyTargetContributor.AddInterfaceToProxy(type);
				AddMappingNoCheck(type, proxyTargetContributor, typeImplementerMapping);
			}
			AddMappingForAdditionalInterfaces(proxyTargetContributor, allInterfaces, typeImplementerMapping, targetInterfaces);
			return proxyTargetContributor;
		}

		protected override CacheKey GetCacheKey()
		{
			return new CacheKey(proxyTargetType, targetType, interfaces, base.ProxyGenerationOptions);
		}

		protected override Type GenerateType(string typeName, INamingScope namingScope)
		{
			IEnumerable<ITypeContributor> contributors;
			IEnumerable<Type> typeImplementerMapping = GetTypeImplementerMapping(proxyTargetType, out contributors, namingScope);
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
				item2.Generate(emitter);
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
			new NonInheritableAttributesContributor(targetType).Generate(emitter);
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

		protected virtual IEnumerable<Type> GetTypeImplementerMapping(Type proxyTargetType, out IEnumerable<ITypeContributor> contributors, INamingScope namingScope)
		{
			List<ITypeContributor> list = new List<ITypeContributor>(5);
			Type[] allInterfaces = proxyTargetType.GetAllInterfaces();
			Dictionary<Type, ITypeContributor> dictionary = new Dictionary<Type, ITypeContributor>();
			ITypeContributor typeContributor = AddMappingForTargetType(dictionary, proxyTargetType, allInterfaces, namingScope);
			list.Add(typeContributor);
			if (base.ProxyGenerationOptions.HasMixins)
			{
				MixinContributor mixinContributor = new MixinContributor(namingScope, AllowChangeTarget)
				{
					Logger = base.Logger
				};
				list.Add(mixinContributor);
				foreach (Type mixinInterface in base.ProxyGenerationOptions.MixinData.MixinInterfaces)
				{
					if (allInterfaces.Contains(mixinInterface))
					{
						if (interfaces.Contains(mixinInterface))
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
			if (interfaces.Length != 0)
			{
				InterfaceProxyWithoutTargetContributor contributorForAdditionalInterfaces = GetContributorForAdditionalInterfaces(namingScope);
				list.Add(contributorForAdditionalInterfaces);
				Type[] array = interfaces;
				foreach (Type type in array)
				{
					if (!dictionary.ContainsKey(type) && !base.ProxyGenerationOptions.MixinData.ContainsMixin(type))
					{
						contributorForAdditionalInterfaces.AddInterfaceToProxy(type);
						AddMappingNoCheck(type, contributorForAdditionalInterfaces, dictionary);
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

		protected virtual Type Init(string typeName, out ClassEmitter emitter, Type proxyTargetType, out FieldReference interceptorsField, IEnumerable<Type> allInterfaces)
		{
			Type baseTypeForInterfaceProxy = base.ProxyGenerationOptions.BaseTypeForInterfaceProxy;
			emitter = BuildClassEmitter(typeName, baseTypeForInterfaceProxy, allInterfaces);
			CreateFields(emitter, proxyTargetType);
			CreateTypeAttributes(emitter);
			interceptorsField = emitter.GetField("__interceptors");
			return baseTypeForInterfaceProxy;
		}

		private void CreateFields(ClassEmitter emitter, Type proxyTargetType)
		{
			base.CreateFields(emitter);
			targetField = emitter.CreateField("__target", proxyTargetType);
		}

		private void EnsureValidBaseType(Type type)
		{
			if (type == null)
			{
				throw new ArgumentException("Base type for proxy is null reference. Please set it to System.Object or some other valid type.");
			}
			if (!type.IsClass)
			{
				ThrowInvalidBaseType(type, "it is not a class type");
			}
			if (type.IsSealed)
			{
				ThrowInvalidBaseType(type, "it is sealed");
			}
			ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
			if (constructor == null || constructor.IsPrivate)
			{
				ThrowInvalidBaseType(type, "it does not have accessible parameterless constructor");
			}
		}

		private void ThrowInvalidBaseType(Type type, string doesNotHaveAccessibleParameterlessConstructor)
		{
			throw new ArgumentException($"Type {type} is not valid base type for interface proxy, because {doesNotHaveAccessibleParameterlessConstructor}. Only a non-sealed class with non-private default constructor can be used as base type for interface proxy. Please use some other valid type.");
		}
	}
}
