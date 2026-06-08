using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Serialization;
using Castle.DynamicProxy.Contributors;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Serialization;

namespace Castle.DynamicProxy.Generators
{
	public class DelegateProxyGenerator : BaseProxyGenerator
	{
		public DelegateProxyGenerator(ModuleScope scope, Type delegateType)
			: base(scope, delegateType)
		{
			base.ProxyGenerationOptions = new ProxyGenerationOptions(new DelegateProxyGenerationHook());
			base.ProxyGenerationOptions.Initialize();
		}

		public Type GetProxyType()
		{
			CacheKey cacheKey = new CacheKey(targetType, null, null);
			return ObtainProxyType(cacheKey, GenerateType);
		}

		protected virtual IEnumerable<Type> GetTypeImplementerMapping(out IEnumerable<ITypeContributor> contributors, INamingScope namingScope)
		{
			List<MethodInfo> methodsToSkip = new List<MethodInfo>();
			ClassProxyInstanceContributor classProxyInstanceContributor = new ClassProxyInstanceContributor(targetType, methodsToSkip, Type.EmptyTypes, ProxyTypeConstants.ClassWithTarget);
			DelegateProxyTargetContributor item = new DelegateProxyTargetContributor(targetType, namingScope)
			{
				Logger = base.Logger
			};
			IDictionary<Type, ITypeContributor> dictionary = new Dictionary<Type, ITypeContributor>();
			if (targetType.IsSerializable)
			{
				AddMappingForISerializable(dictionary, classProxyInstanceContributor);
			}
			AddMappingNoCheck(typeof(IProxyTargetAccessor), classProxyInstanceContributor, dictionary);
			contributors = new List<ITypeContributor> { item, classProxyInstanceContributor };
			return dictionary.Keys;
		}

		private FieldReference CreateTargetField(ClassEmitter emitter)
		{
			FieldReference fieldReference = emitter.CreateField("__target", targetType);
			emitter.DefineCustomAttributeFor<XmlIgnoreAttribute>(fieldReference);
			return fieldReference;
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
			ClassEmitter classEmitter = BuildClassEmitter(name, typeof(object), typeImplementerMapping);
			CreateFields(classEmitter);
			CreateTypeAttributes(classEmitter);
			ConstructorEmitter constructorEmitter = GenerateStaticConstructor(classEmitter);
			FieldReference item = CreateTargetField(classEmitter);
			List<FieldReference> list = new List<FieldReference> { item };
			foreach (ITypeContributor item3 in contributors)
			{
				item3.Generate(classEmitter, base.ProxyGenerationOptions);
			}
			FieldReference field = classEmitter.GetField("__interceptors");
			list.Add(field);
			FieldReference field2 = classEmitter.GetField("__selector");
			if (field2 != null)
			{
				list.Add(field2);
			}
			GenerateConstructor(classEmitter, null, list.ToArray());
			GenerateParameterlessConstructor(classEmitter, targetType, field);
			CompleteInitCacheMethod(constructorEmitter.CodeBuilder);
			Type type = classEmitter.BuildType();
			InitializeStaticFields(type);
			return type;
		}
	}
}
