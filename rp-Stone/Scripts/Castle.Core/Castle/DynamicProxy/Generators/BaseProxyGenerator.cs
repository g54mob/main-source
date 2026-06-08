using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Castle.Core.Logging;
using Castle.DynamicProxy.Contributors;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.CodeBuilders;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy.Generators
{
	public abstract class BaseProxyGenerator
	{
		protected readonly Type targetType;

		private readonly ModuleScope scope;

		private ILogger logger = NullLogger.Instance;

		private ProxyGenerationOptions proxyGenerationOptions;

		public ILogger Logger
		{
			get
			{
				return logger;
			}
			set
			{
				logger = value;
			}
		}

		protected ProxyGenerationOptions ProxyGenerationOptions
		{
			get
			{
				if (proxyGenerationOptions == null)
				{
					throw new InvalidOperationException("ProxyGenerationOptions must be set before being retrieved.");
				}
				return proxyGenerationOptions;
			}
			set
			{
				if (proxyGenerationOptions != null)
				{
					throw new InvalidOperationException("ProxyGenerationOptions can only be set once.");
				}
				proxyGenerationOptions = value;
			}
		}

		protected ModuleScope Scope => scope;

		protected BaseProxyGenerator(ModuleScope scope, Type targetType)
		{
			this.scope = scope;
			this.targetType = targetType;
		}

		protected void AddMapping(Type @interface, ITypeContributor implementer, IDictionary<Type, ITypeContributor> mapping)
		{
			if (!mapping.ContainsKey(@interface))
			{
				AddMappingNoCheck(@interface, implementer, mapping);
			}
		}

		protected void AddMappingForISerializable(IDictionary<Type, ITypeContributor> typeImplementerMapping, ITypeContributor instance)
		{
			AddMapping(typeof(ISerializable), instance, typeImplementerMapping);
		}

		protected void AddMappingNoCheck(Type @interface, ITypeContributor implementer, IDictionary<Type, ITypeContributor> mapping)
		{
			mapping.Add(@interface, implementer);
		}

		[Obsolete("Exposes a component that is intended for internal use only.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected void AddToCache(CacheKey key, Type type)
		{
			scope.RegisterInCache(key, type);
		}

		protected virtual ClassEmitter BuildClassEmitter(string typeName, Type parentType, IEnumerable<Type> interfaces)
		{
			CheckNotGenericTypeDefinition(parentType, "parentType");
			CheckNotGenericTypeDefinitions(interfaces, "interfaces");
			return new ClassEmitter(Scope, typeName, parentType, interfaces);
		}

		protected void CheckNotGenericTypeDefinition(Type type, string argumentName)
		{
			if (type != null && type.GetTypeInfo().IsGenericTypeDefinition)
			{
				throw new ArgumentException("Type cannot be a generic type definition. Type: " + type.FullName, argumentName);
			}
		}

		protected void CheckNotGenericTypeDefinitions(IEnumerable<Type> types, string argumentName)
		{
			if (types == null)
			{
				return;
			}
			foreach (Type type in types)
			{
				CheckNotGenericTypeDefinition(type, argumentName);
			}
		}

		protected void CompleteInitCacheMethod(ConstructorCodeBuilder constCodeBuilder)
		{
			constCodeBuilder.AddStatement(new ReturnStatement());
		}

		protected virtual void CreateFields(ClassEmitter emitter)
		{
			CreateOptionsField(emitter);
			CreateSelectorField(emitter);
			CreateInterceptorsField(emitter);
		}

		protected void CreateInterceptorsField(ClassEmitter emitter)
		{
			FieldReference field = emitter.CreateField("__interceptors", typeof(IInterceptor[]));
			emitter.DefineCustomAttributeFor<XmlIgnoreAttribute>(field);
		}

		protected FieldReference CreateOptionsField(ClassEmitter emitter)
		{
			return emitter.CreateStaticField("proxyGenerationOptions", typeof(ProxyGenerationOptions));
		}

		protected void CreateSelectorField(ClassEmitter emitter)
		{
			if (ProxyGenerationOptions.Selector != null)
			{
				emitter.CreateField("__selector", typeof(IInterceptorSelector));
			}
		}

		protected virtual void CreateTypeAttributes(ClassEmitter emitter)
		{
			emitter.AddCustomAttributes(ProxyGenerationOptions);
			emitter.DefineCustomAttribute<XmlIncludeAttribute>(new object[1] { targetType });
		}

		protected void EnsureOptionsOverrideEqualsAndGetHashCode(ProxyGenerationOptions options)
		{
			if (Logger.IsWarnEnabled && !OverridesEqualsAndGetHashCode(options.Hook.GetType()))
			{
				Logger.WarnFormat("The IProxyGenerationHook type {0} does not override both Equals and GetHashCode. If these are not correctly overridden caching will fail to work causing performance problems.", options.Hook.GetType().FullName);
			}
		}

		protected void GenerateConstructor(ClassEmitter emitter, ConstructorInfo baseConstructor, params FieldReference[] fields)
		{
			ParameterInfo[] array = null;
			if (baseConstructor != null)
			{
				array = baseConstructor.GetParameters();
			}
			ArgumentReference[] array2;
			if (array != null && array.Length != 0)
			{
				array2 = new ArgumentReference[fields.Length + array.Length];
				int num = fields.Length;
				for (int i = num; i < num + array.Length; i++)
				{
					ParameterInfo parameterInfo = array[i - num];
					array2[i] = new ArgumentReference(parameterInfo.ParameterType);
				}
			}
			else
			{
				array2 = new ArgumentReference[fields.Length];
			}
			for (int j = 0; j < fields.Length; j++)
			{
				array2[j] = new ArgumentReference(fields[j].Reference.FieldType);
			}
			ConstructorEmitter constructorEmitter = emitter.CreateConstructor(array2);
			if (array != null && array.Length != 0)
			{
				int num2 = 1 + fields.Length;
				int k = 0;
				for (int num3 = array.Length; k < num3; k++)
				{
					ParameterBuilder parameterBuilder = constructorEmitter.ConstructorBuilder.DefineParameter(num2 + k, array[k].Attributes, array[k].Name);
					foreach (CustomAttributeInfo nonInheritableAttribute in array[k].GetNonInheritableAttributes())
					{
						parameterBuilder.SetCustomAttribute(nonInheritableAttribute.Builder);
					}
				}
			}
			for (int l = 0; l < fields.Length; l++)
			{
				constructorEmitter.CodeBuilder.AddStatement(new AssignStatement(fields[l], array2[l].ToExpression()));
			}
			if (baseConstructor != null)
			{
				ArgumentReference[] array3 = new ArgumentReference[array.Length];
				Array.Copy(array2, fields.Length, array3, 0, array.Length);
				constructorEmitter.CodeBuilder.InvokeBaseConstructor(baseConstructor, array3);
			}
			else
			{
				constructorEmitter.CodeBuilder.InvokeBaseConstructor();
			}
			constructorEmitter.CodeBuilder.AddStatement(new ReturnStatement());
		}

		protected void GenerateConstructors(ClassEmitter emitter, Type baseType, params FieldReference[] fields)
		{
			ConstructorInfo[] constructors = baseType.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (ConstructorInfo constructorInfo in constructors)
			{
				if (ProxyUtil.IsAccessibleMethod(constructorInfo))
				{
					GenerateConstructor(emitter, constructorInfo, fields);
				}
			}
		}

		protected void GenerateParameterlessConstructor(ClassEmitter emitter, Type baseClass, FieldReference interceptorField)
		{
			ConstructorInfo constructor = baseClass.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, Type.EmptyTypes, null);
			if (constructor == null)
			{
				constructor = baseClass.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
				if (constructor == null || constructor.IsPrivate)
				{
					return;
				}
			}
			ConstructorEmitter constructorEmitter = emitter.CreateConstructor();
			constructorEmitter.CodeBuilder.AddStatement(new AssignStatement(interceptorField, new NewArrayExpression(1, typeof(IInterceptor))));
			constructorEmitter.CodeBuilder.AddStatement(new AssignArrayStatement(interceptorField, 0, new NewInstanceExpression(typeof(StandardInterceptor), new Type[0])));
			constructorEmitter.CodeBuilder.InvokeBaseConstructor(constructor);
			constructorEmitter.CodeBuilder.AddStatement(new ReturnStatement());
		}

		protected ConstructorEmitter GenerateStaticConstructor(ClassEmitter emitter)
		{
			return emitter.CreateTypeConstructor();
		}

		[Obsolete("Exposes a component that is intended for internal use only.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected Type GetFromCache(CacheKey key)
		{
			return scope.GetFromCache(key);
		}

		protected void HandleExplicitlyPassedProxyTargetAccessor(ICollection<Type> targetInterfaces, ICollection<Type> additionalInterfaces)
		{
			string text = typeof(IProxyTargetAccessor).ToString();
			string text2;
			if (targetInterfaces.Contains(typeof(IProxyTargetAccessor)))
			{
				text2 = $"Target type for the proxy implements {text} which is a DynamicProxy infrastructure interface and you should never implement it yourself. Are you trying to proxy an existing proxy?";
			}
			else if (!ProxyGenerationOptions.MixinData.ContainsMixin(typeof(IProxyTargetAccessor)))
			{
				text2 = ((!additionalInterfaces.Contains(typeof(IProxyTargetAccessor))) ? $"It looks like we have a bug with regards to how we handle {text}. Please report it." : $"You passed {text} as one of additional interfaces to proxy which is a DynamicProxy infrastructure interface and is implemented by every proxy anyway. Please remove it from the list of additional interfaces to proxy.");
			}
			else
			{
				Type type = ProxyGenerationOptions.MixinData.GetMixinInstance(typeof(IProxyTargetAccessor)).GetType();
				text2 = $"Mixin type {type.Name} implements {text} which is a DynamicProxy infrastructure interface and you should never implement it yourself. Are you trying to mix in an existing proxy?";
			}
			throw new ProxyGenerationException("This is a DynamicProxy2 error: " + text2);
		}

		protected void InitializeStaticFields(Type builtType)
		{
			builtType.SetStaticField("proxyGenerationOptions", BindingFlags.NonPublic, ProxyGenerationOptions);
		}

		[Obsolete("Exposes a component that is intended for internal use only.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected Type ObtainProxyType(CacheKey cacheKey, Func<string, INamingScope, Type> factory)
		{
			bool notFoundInTypeCache = false;
			Type orAdd = Scope.TypeCache.GetOrAdd(cacheKey, delegate
			{
				notFoundInTypeCache = true;
				Logger.DebugFormat("No cached proxy type was found for target type {0}.", targetType.FullName);
				EnsureOptionsOverrideEqualsAndGetHashCode(ProxyGenerationOptions);
				string uniqueName = Scope.NamingScope.GetUniqueName("Castle.Proxies." + targetType.Name + "Proxy");
				return factory(uniqueName, Scope.NamingScope.SafeSubScope());
			});
			if (!notFoundInTypeCache)
			{
				Logger.DebugFormat("Found cached proxy type {0} for target type {1}.", orAdd.FullName, targetType.FullName);
			}
			return orAdd;
		}

		private bool OverridesEqualsAndGetHashCode(Type type)
		{
			MethodInfo method = type.GetMethod("Equals", BindingFlags.Instance | BindingFlags.Public);
			if (method == null || method.DeclaringType == typeof(object) || method.IsAbstract)
			{
				return false;
			}
			MethodInfo method2 = type.GetMethod("GetHashCode", BindingFlags.Instance | BindingFlags.Public);
			if (method2 == null || method2.DeclaringType == typeof(object) || method2.IsAbstract)
			{
				return false;
			}
			return true;
		}
	}
}
