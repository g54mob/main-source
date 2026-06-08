using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy.Serialization
{
	[Serializable]
	public class ProxyObjectReference : IObjectReference, ISerializable, IDeserializationCallback
	{
		private static ModuleScope scope = new ModuleScope();

		private readonly SerializationInfo info;

		private readonly StreamingContext context;

		private readonly Type baseType;

		private readonly Type[] interfaces;

		private readonly object proxy;

		private readonly ProxyGenerationOptions proxyGenerationOptions;

		private bool isInterfaceProxy;

		private bool delegateToBase;

		public static ModuleScope ModuleScope => scope;

		public static void ResetScope()
		{
			SetScope(new ModuleScope());
		}

		public static void SetScope(ModuleScope scope)
		{
			if (scope == null)
			{
				throw new ArgumentNullException("scope");
			}
			ProxyObjectReference.scope = scope;
		}

		[SecurityCritical]
		protected ProxyObjectReference(SerializationInfo info, StreamingContext context)
		{
			this.info = info;
			this.context = context;
			baseType = DeserializeTypeFromString("__baseType");
			string[] array = (string[])info.GetValue("__interfaces", typeof(string[]));
			interfaces = new Type[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				interfaces[i] = Type.GetType(array[i]);
			}
			proxyGenerationOptions = (ProxyGenerationOptions)info.GetValue("__proxyGenerationOptions", typeof(ProxyGenerationOptions));
			proxy = RecreateProxy();
			DeserializeProxyState();
		}

		private Type DeserializeTypeFromString(string key)
		{
			return Type.GetType(info.GetString(key), throwOnError: true, ignoreCase: false);
		}

		[SecurityCritical]
		protected virtual object RecreateProxy()
		{
			string value = GetValue<string>("__proxyTypeId");
			if (value.Equals(ProxyTypeConstants.Class))
			{
				isInterfaceProxy = false;
				return RecreateClassProxy();
			}
			if (value.Equals(ProxyTypeConstants.ClassWithTarget))
			{
				isInterfaceProxy = false;
				return RecreateClassProxyWithTarget();
			}
			isInterfaceProxy = true;
			return RecreateInterfaceProxy(value);
		}

		[SecurityCritical]
		private object RecreateClassProxyWithTarget()
		{
			Type generatedType = new ClassProxyWithTargetGenerator(scope, baseType, interfaces, proxyGenerationOptions).GetGeneratedType();
			return InstantiateClassProxy(generatedType);
		}

		[SecurityCritical]
		public object RecreateInterfaceProxy(string generatorType)
		{
			Type type = DeserializeTypeFromString("__theInterface");
			Type proxyTargetType = DeserializeTypeFromString("__targetFieldType");
			InterfaceProxyWithTargetGenerator interfaceProxyWithTargetGenerator;
			if (generatorType == ProxyTypeConstants.InterfaceWithTarget)
			{
				interfaceProxyWithTargetGenerator = new InterfaceProxyWithTargetGenerator(scope, type);
			}
			else if (generatorType == ProxyTypeConstants.InterfaceWithoutTarget)
			{
				interfaceProxyWithTargetGenerator = new InterfaceProxyWithoutTargetGenerator(scope, type);
			}
			else
			{
				if (!(generatorType == ProxyTypeConstants.InterfaceWithTargetInterface))
				{
					throw new InvalidOperationException($"Got value {generatorType} for the interface generator type, which is not known for the purpose of serialization.");
				}
				interfaceProxyWithTargetGenerator = new InterfaceProxyWithTargetInterfaceGenerator(scope, type);
			}
			return FormatterServices.GetSafeUninitializedObject(interfaceProxyWithTargetGenerator.GenerateCode(proxyTargetType, interfaces, proxyGenerationOptions));
		}

		[SecurityCritical]
		public object RecreateClassProxy()
		{
			Type proxy_type = new ClassProxyGenerator(scope, baseType).GenerateCode(interfaces, proxyGenerationOptions);
			return InstantiateClassProxy(proxy_type);
		}

		[SecurityCritical]
		private object InstantiateClassProxy(Type proxy_type)
		{
			delegateToBase = GetValue<bool>("__delegateToBase");
			if (delegateToBase)
			{
				return Activator.CreateInstance(proxy_type, info, context);
			}
			return FormatterServices.GetSafeUninitializedObject(proxy_type);
		}

		protected void InvokeCallback(object target)
		{
			if (target is IDeserializationCallback)
			{
				(target as IDeserializationCallback).OnDeserialization(this);
			}
		}

		[SecurityCritical]
		public object GetRealObject(StreamingContext context)
		{
			return proxy;
		}

		[SecurityCritical]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		[SecuritySafeCritical]
		public void OnDeserialization(object sender)
		{
			IInterceptor[] value = GetValue<IInterceptor[]>("__interceptors");
			SetInterceptors(value);
			DeserializeProxyMembers();
			DeserializeProxyState();
			InvokeCallback(proxy);
		}

		[SecurityCritical]
		private void DeserializeProxyMembers()
		{
			Type type = proxy.GetType();
			MemberInfo[] serializableMembers = FormatterServices.GetSerializableMembers(type);
			List<MemberInfo> list = new List<MemberInfo>();
			List<object> list2 = new List<object>();
			for (int i = 0; i < serializableMembers.Length; i++)
			{
				FieldInfo fieldInfo = serializableMembers[i] as FieldInfo;
				if (!(fieldInfo.DeclaringType != type))
				{
					object value = info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
					list.Add(fieldInfo);
					list2.Add(value);
				}
			}
			FormatterServices.PopulateObjectMembers(proxy, list.ToArray(), list2.ToArray());
		}

		[SecurityCritical]
		private void DeserializeProxyState()
		{
			if (isInterfaceProxy)
			{
				object value = GetValue<object>("__target");
				SetTarget(value);
			}
			else if (!delegateToBase)
			{
				object[] value2 = GetValue<object[]>("__data");
				MemberInfo[] serializableMembers = FormatterServices.GetSerializableMembers(baseType);
				serializableMembers = TypeUtil.Sort(serializableMembers);
				FormatterServices.PopulateObjectMembers(proxy, serializableMembers, value2);
			}
		}

		private void SetTarget(object target)
		{
			FieldInfo field = proxy.GetType().GetField("__target", BindingFlags.Instance | BindingFlags.NonPublic);
			if (field == null)
			{
				throw new SerializationException("The SerializationInfo specifies an invalid interface proxy type, which has no __target field.");
			}
			field.SetValue(proxy, target);
		}

		private void SetInterceptors(IInterceptor[] interceptors)
		{
			FieldInfo field = proxy.GetType().GetField("__interceptors", BindingFlags.Instance | BindingFlags.NonPublic);
			if (field == null)
			{
				throw new SerializationException("The SerializationInfo specifies an invalid proxy type, which has no __interceptors field.");
			}
			field.SetValue(proxy, interceptors);
		}

		private T GetValue<T>(string name)
		{
			return (T)info.GetValue(name, typeof(T));
		}
	}
}
