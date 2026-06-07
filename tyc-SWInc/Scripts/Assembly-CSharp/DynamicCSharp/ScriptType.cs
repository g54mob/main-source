using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using UnityEngine;

namespace DynamicCSharp
{
	public sealed class ScriptType
	{
		private Dictionary<string, FieldInfo> fieldCache = new Dictionary<string, FieldInfo>();

		private Dictionary<string, PropertyInfo> propertyCache = new Dictionary<string, PropertyInfo>();

		private Dictionary<string, MethodInfo> methodCache = new Dictionary<string, MethodInfo>();

		private Type rawType;

		private ScriptAssembly assembly;

		public Type RawType
		{
			get
			{
				return rawType;
			}
		}

		public ScriptAssembly Assembly
		{
			get
			{
				return assembly;
			}
		}

		public bool IsUnityObject
		{
			get
			{
				return IsSubtypeOf<UnityEngine.Object>();
			}
		}

		public bool IsMonoBehaviour
		{
			get
			{
				return IsSubtypeOf<MonoBehaviour>();
			}
		}

		public bool IsScriptableObject
		{
			get
			{
				return IsSubtypeOf<ScriptableObject>();
			}
		}

		public ScriptType(Type type)
		{
			assembly = null;
			rawType = type;
		}

		internal ScriptType(ScriptAssembly assembly, Type type)
		{
			this.assembly = assembly;
			rawType = type;
		}

		public ScriptProxy CreateInstance(GameObject parent = null)
		{
			if (IsMonoBehaviour)
			{
				return CreateBehaviourInstance(parent);
			}
			if (IsScriptableObject)
			{
				return CreateScriptableInstance();
			}
			return CreateCSharpInstance();
		}

		public ScriptProxy CreateInstance(GameObject parent = null, params object[] parameters)
		{
			if (IsMonoBehaviour)
			{
				return CreateBehaviourInstance(parent);
			}
			if (IsScriptableObject)
			{
				return CreateScriptableInstance();
			}
			return CreateCSharpInstance(parameters);
		}

		public object CreateRawInstance(GameObject parent = null)
		{
			ScriptProxy scriptProxy = CreateInstance(parent);
			if (scriptProxy == null)
			{
				return null;
			}
			return scriptProxy.Instance;
		}

		public object CreateRawInstance(GameObject parent = null, params object[] parameters)
		{
			ScriptProxy scriptProxy = CreateInstance(parent, parameters);
			if (scriptProxy == null)
			{
				return null;
			}
			return scriptProxy.Instance;
		}

		public T CreateRawInstance<T>(GameObject parent = null) where T : class
		{
			ScriptProxy scriptProxy = CreateInstance(parent);
			if (scriptProxy == null)
			{
				return null;
			}
			return scriptProxy.GetInstanceAs<T>(false);
		}

		public T CreateRawInstance<T>(GameObject parent = null, params object[] parameters) where T : class
		{
			ScriptProxy scriptProxy = CreateInstance(parent);
			if (scriptProxy == null)
			{
				return null;
			}
			return scriptProxy.GetInstanceAs<T>(false);
		}

		private ScriptProxy CreateBehaviourInstance(GameObject parent)
		{
			if (parent == null)
			{
				throw new ArgumentNullException("parent");
			}
			MonoBehaviour monoBehaviour = parent.AddComponent(rawType) as MonoBehaviour;
			if (monoBehaviour != null)
			{
				return new ScriptProxy(this, monoBehaviour);
			}
			return null;
		}

		private ScriptProxy CreateScriptableInstance()
		{
			ScriptableObject scriptableObject = ScriptableObject.CreateInstance(rawType);
			if (scriptableObject != null)
			{
				return new ScriptProxy(this, scriptableObject);
			}
			return null;
		}

		private ScriptProxy CreateCSharpInstance(params object[] args)
		{
			object obj = null;
			try
			{
				obj = Activator.CreateInstance(rawType, DynamicCSharp.Settings.GetMemberBindings(), null, args, null);
			}
			catch (MissingMethodException)
			{
				if (args.Length != 0)
				{
					return null;
				}
				obj = FormatterServices.GetUninitializedObject(rawType);
			}
			if (obj != null)
			{
				return new ScriptProxy(this, obj);
			}
			return null;
		}

		public bool IsSubtypeOf(Type baseClass)
		{
			return baseClass.IsAssignableFrom(rawType);
		}

		public bool IsSubtypeOf<T>()
		{
			return IsSubtypeOf(typeof(T));
		}

		public FieldInfo FindCachedField(string name)
		{
			if (fieldCache.ContainsKey(name))
			{
				return fieldCache[name];
			}
			FieldInfo field = rawType.GetField(name, DynamicCSharp.Settings.GetMemberBindings());
			if (field == null)
			{
				return null;
			}
			fieldCache.Add(name, field);
			return field;
		}

		public PropertyInfo FindCachedProperty(string name)
		{
			if (propertyCache.ContainsKey(name))
			{
				return propertyCache[name];
			}
			PropertyInfo property = rawType.GetProperty(name, DynamicCSharp.Settings.GetMemberBindings());
			if (property == null)
			{
				return null;
			}
			propertyCache.Add(name, property);
			return property;
		}

		public MethodInfo FindCachedMethod(string name)
		{
			if (methodCache.ContainsKey(name))
			{
				return methodCache[name];
			}
			MethodInfo method = rawType.GetMethod(name, DynamicCSharp.Settings.GetMemberBindings());
			if (method == null)
			{
				return null;
			}
			methodCache.Add(name, method);
			return method;
		}

		public object CallStatic(string methodName)
		{
			MethodInfo methodInfo = FindCachedMethod(methodName);
			if (methodInfo == null)
			{
				throw new TargetException(string.Format("Type '{0}' does not define a static method called '{1}'", this, methodName));
			}
			if (!methodInfo.IsStatic)
			{
				throw new TargetException(string.Format("The target method '{0}' is not marked as static and must be called on an object", methodName));
			}
			return methodInfo.Invoke(null, null);
		}

		public object CallStatic(string methodName, params object[] arguments)
		{
			MethodInfo methodInfo = FindCachedMethod(methodName);
			if (methodInfo == null)
			{
				throw new TargetException(string.Format("Type '{0}' does not define a static method called '{1}'", this, methodName));
			}
			if (!methodInfo.IsStatic)
			{
				throw new TargetException(string.Format("The target method '{0}' is not marked as static and must be called on an object", methodName));
			}
			return methodInfo.Invoke(null, arguments);
		}

		public object SafeCallStatic(string method)
		{
			try
			{
				return CallStatic(method);
			}
			catch
			{
				return null;
			}
		}

		public object SafeCallStatic(string method, params object[] arguments)
		{
			try
			{
				return CallStatic(method, arguments);
			}
			catch
			{
				return null;
			}
		}

		public override string ToString()
		{
			return string.Format("ScriptType({0})", rawType.Name);
		}
	}
}
