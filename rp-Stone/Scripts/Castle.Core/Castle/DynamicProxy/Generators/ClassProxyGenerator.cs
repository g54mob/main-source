using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy.Contributors;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Internal;
using Castle.DynamicProxy.Serialization;

namespace Castle.DynamicProxy.Generators
{
	public class ClassProxyGenerator : BaseProxyGenerator
	{
		public ClassProxyGenerator(ModuleScope scope, Type targetType)
			: base(scope, targetType)
		{
			CheckNotGenericTypeDefinition(targetType, "targetType");
			EnsureDoesNotImplementIProxyTargetAccessor(targetType, "targetType");
		}

		public Type GenerateCode(Type[] interfaces, ProxyGenerationOptions options)
		{
			options.Initialize();
			interfaces = TypeUtil.GetAllInterfaces(interfaces);
			CheckNotGenericTypeDefinitions(interfaces, "interfaces");
			base.ProxyGenerationOptions = options;
			CacheKey cacheKey = new CacheKey(targetType, interfaces, options);
			return ObtainProxyType(cacheKey, (string n, INamingScope s) => GenerateType(n, interfaces, s));
		}

		protected virtual Type GenerateType(string name, Type[] interfaces, INamingScope namingScope)
		{
			IEnumerable<ITypeContributor> contributors;
			IEnumerable<Type> typeImplementerMapping = GetTypeImplementerMapping(interfaces, out contributors, namingScope);
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
			foreach (ITypeContributor item2 in contributors)
			{
				item2.Generate(classEmitter, base.ProxyGenerationOptions);
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
			Type type = classEmitter.BuildType();
			InitializeStaticFields(type);
			return type;
		}

		protected virtual IEnumerable<Type> GetTypeImplementerMapping(Type[] interfaces, out IEnumerable<ITypeContributor> contributors, INamingScope namingScope)
		{
			List<MethodInfo> methodsToSkip = new List<MethodInfo>();
			ClassProxyInstanceContributor classProxyInstanceContributor = new ClassProxyInstanceContributor(targetType, methodsToSkip, interfaces, ProxyTypeConstants.Class);
			ClassProxyTargetContributor classProxyTargetContributor = new ClassProxyTargetContributor(targetType, methodsToSkip, namingScope)
			{
				Logger = base.Logger
			};
			IDictionary<Type, ITypeContributor> dictionary = new Dictionary<Type, ITypeContributor>();
			Type[] allInterfaces = targetType.GetAllInterfaces();
			Type[] allInterfaces2 = TypeUtil.GetAllInterfaces(interfaces);
			MixinContributor mixinContributor = new MixinContributor(namingScope, canChangeTarget: false)
			{
				Logger = base.Logger
			};
			if (base.ProxyGenerationOptions.HasMixins)
			{
				foreach (Type mixinInterface in base.ProxyGenerationOptions.MixinData.MixinInterfaces)
				{
					if (allInterfaces.Contains(mixinInterface))
					{
						if (allInterfaces2.Contains(mixinInterface) && !dictionary.ContainsKey(mixinInterface))
						{
							AddMappingNoCheck(mixinInterface, classProxyTargetContributor, dictionary);
							classProxyTargetContributor.AddInterfaceToProxy(mixinInterface);
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
			InterfaceProxyWithoutTargetContributor interfaceProxyWithoutTargetContributor = new InterfaceProxyWithoutTargetContributor(namingScope, (ClassEmitter c, MethodInfo m) => NullExpression.Instance)
			{
				Logger = base.Logger
			};
			Type[] array = allInterfaces2;
			foreach (Type type in array)
			{
				if (allInterfaces.Contains(type))
				{
					if (!dictionary.ContainsKey(type))
					{
						AddMappingNoCheck(type, classProxyTargetContributor, dictionary);
						classProxyTargetContributor.AddInterfaceToProxy(type);
					}
				}
				else if (!base.ProxyGenerationOptions.MixinData.ContainsMixin(type))
				{
					interfaceProxyWithoutTargetContributor.AddInterfaceToProxy(type);
					AddMapping(type, interfaceProxyWithoutTargetContributor, dictionary);
				}
			}
			if (targetType.IsSerializable)
			{
				AddMappingForISerializable(dictionary, classProxyInstanceContributor);
			}
			try
			{
				AddMappingNoCheck(typeof(IProxyTargetAccessor), classProxyInstanceContributor, dictionary);
			}
			catch (ArgumentException)
			{
				HandleExplicitlyPassedProxyTargetAccessor(allInterfaces, allInterfaces2);
			}
			contributors = new List<ITypeContributor> { classProxyTargetContributor, mixinContributor, interfaceProxyWithoutTargetContributor, classProxyInstanceContributor };
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
