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
	public class ClassProxyWithTargetGenerator : BaseProxyGenerator
	{
		private readonly Type[] additionalInterfacesToProxy;

		public ClassProxyWithTargetGenerator(ModuleScope scope, Type classToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options)
			: base(scope, classToProxy)
		{
			CheckNotGenericTypeDefinition(targetType, "targetType");
			EnsureDoesNotImplementIProxyTargetAccessor(targetType, "targetType");
			CheckNotGenericTypeDefinitions(additionalInterfacesToProxy, "additionalInterfacesToProxy");
			options.Initialize();
			base.ProxyGenerationOptions = options;
			this.additionalInterfacesToProxy = TypeUtil.GetAllInterfaces(additionalInterfacesToProxy);
		}

		public Type GetGeneratedType()
		{
			CacheKey cacheKey = new CacheKey(targetType.GetTypeInfo(), targetType, additionalInterfacesToProxy, base.ProxyGenerationOptions);
			return ObtainProxyType(cacheKey, GenerateType);
		}

		protected virtual IEnumerable<Type> GetTypeImplementerMapping(out IEnumerable<ITypeContributor> contributors, INamingScope namingScope)
		{
			List<MethodInfo> methodsToSkip = new List<MethodInfo>();
			ClassProxyWithTargetInstanceContributor classProxyWithTargetInstanceContributor = new ClassProxyWithTargetInstanceContributor(targetType, methodsToSkip, additionalInterfacesToProxy, ProxyTypeConstants.ClassWithTarget);
			ClassProxyWithTargetTargetContributor classProxyWithTargetTargetContributor = new ClassProxyWithTargetTargetContributor(targetType, methodsToSkip, namingScope)
			{
				Logger = base.Logger
			};
			IDictionary<Type, ITypeContributor> dictionary = new Dictionary<Type, ITypeContributor>();
			Type[] allInterfaces = targetType.GetAllInterfaces();
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
						if (additionalInterfacesToProxy.Contains(mixinInterface) && !dictionary.ContainsKey(mixinInterface))
						{
							AddMappingNoCheck(mixinInterface, classProxyWithTargetTargetContributor, dictionary);
							classProxyWithTargetTargetContributor.AddInterfaceToProxy(mixinInterface);
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
			Type[] array = additionalInterfacesToProxy;
			foreach (Type type in array)
			{
				if (allInterfaces.Contains(type))
				{
					if (!dictionary.ContainsKey(type))
					{
						AddMappingNoCheck(type, classProxyWithTargetTargetContributor, dictionary);
						classProxyWithTargetTargetContributor.AddInterfaceToProxy(type);
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
				AddMappingForISerializable(dictionary, classProxyWithTargetInstanceContributor);
			}
			try
			{
				AddMappingNoCheck(typeof(IProxyTargetAccessor), classProxyWithTargetInstanceContributor, dictionary);
			}
			catch (ArgumentException)
			{
				HandleExplicitlyPassedProxyTargetAccessor(allInterfaces, additionalInterfacesToProxy);
			}
			contributors = new List<ITypeContributor> { classProxyWithTargetTargetContributor, mixinContributor, interfaceProxyWithoutTargetContributor, classProxyWithTargetInstanceContributor };
			return dictionary.Keys;
		}

		private FieldReference CreateTargetField(ClassEmitter emitter)
		{
			FieldReference fieldReference = emitter.CreateField("__target", targetType);
			emitter.DefineCustomAttributeFor<XmlIgnoreAttribute>(fieldReference);
			return fieldReference;
		}

		private void EnsureDoesNotImplementIProxyTargetAccessor(Type type, string name)
		{
			if (!typeof(IProxyTargetAccessor).IsAssignableFrom(type))
			{
				return;
			}
			throw new ArgumentException($"Target type for the proxy implements {typeof(IProxyTargetAccessor)} which is a DynamicProxy infrastructure interface and you should never implement it yourself. Are you trying to proxy an existing proxy?", name);
		}

		private Type GenerateType(string name, INamingScope namingScope)
		{
			IEnumerable<ITypeContributor> contributors;
			IEnumerable<Type> typeImplementerMapping = GetTypeImplementerMapping(out contributors, namingScope);
			MetaType model = new MetaType();
			foreach (ITypeContributor item2 in contributors)
			{
				item2.CollectElementsToProxy(base.ProxyGenerationOptions.Hook, model);
			}
			base.ProxyGenerationOptions.Hook.MethodsInspected();
			ClassEmitter classEmitter = BuildClassEmitter(name, targetType, typeImplementerMapping);
			CreateFields(classEmitter);
			CreateTypeAttributes(classEmitter);
			ConstructorEmitter constructorEmitter = GenerateStaticConstructor(classEmitter);
			FieldReference item = CreateTargetField(classEmitter);
			List<FieldReference> list = new List<FieldReference> { item };
			foreach (ITypeContributor item3 in contributors)
			{
				item3.Generate(classEmitter, base.ProxyGenerationOptions);
				if (item3 is MixinContributor)
				{
					list.AddRange((item3 as MixinContributor).Fields);
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
	}
}
