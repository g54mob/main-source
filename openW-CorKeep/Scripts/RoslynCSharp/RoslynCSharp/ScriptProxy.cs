using System;
using System.Collections;
using System.Reflection;
using RoslynCSharp.Implementation;
using UnityEngine;

namespace RoslynCSharp
{
	public abstract class ScriptProxy : IDisposable
	{
		private IScriptDataProxy fields;

		private IScriptDataProxy safeFields;

		private IScriptDataProxy properties;

		private IScriptDataProxy safeProperties;

		private IScriptEventProxy events;

		private IScriptEventProxy safeEvents;

		public abstract ScriptAssembly Assembly { get; }

		public abstract ScriptType ScriptType { get; }

		public virtual IScriptDataProxy Fields
		{
			get
			{
				CheckDisposed();
				if (fields == null)
				{
					fields = new ScriptFieldDataProxy(ScriptType, this, isStatic: false, throwOnError: true);
				}
				return fields;
			}
		}

		public virtual IScriptDataProxy SafeFields
		{
			get
			{
				CheckDisposed();
				if (safeFields == null)
				{
					safeFields = new ScriptFieldDataProxy(ScriptType, this, isStatic: false, throwOnError: false);
				}
				return safeFields;
			}
		}

		public virtual IScriptDataProxy Properties
		{
			get
			{
				CheckDisposed();
				if (properties == null)
				{
					properties = new ScriptPropertyDataProxy(ScriptType, this, isStatic: false, throwOnError: true);
				}
				return properties;
			}
		}

		public virtual IScriptDataProxy SafeProperties
		{
			get
			{
				CheckDisposed();
				if (safeProperties == null)
				{
					safeProperties = new ScriptPropertyDataProxy(ScriptType, this, isStatic: false, throwOnError: false);
				}
				return safeProperties;
			}
		}

		public virtual IScriptEventProxy Events
		{
			get
			{
				CheckDisposed();
				if (events == null)
				{
					events = new ScriptEventHandlerProxy(ScriptType, this, isStatic: false, throwOnError: true);
				}
				return events;
			}
		}

		public virtual IScriptEventProxy SafeEvents
		{
			get
			{
				CheckDisposed();
				if (safeEvents == null)
				{
					safeEvents = new ScriptEventHandlerProxy(ScriptType, this, isStatic: false, throwOnError: true);
				}
				return safeEvents;
			}
		}

		public abstract object Instance { get; }

		public virtual UnityEngine.Object UnityInstance
		{
			get
			{
				CheckDisposed();
				return GetInstanceAs<UnityEngine.Object>(throwOnError: false);
			}
		}

		public virtual MonoBehaviour MonoBehaviourInstance
		{
			get
			{
				CheckDisposed();
				return GetInstanceAs<MonoBehaviour>(throwOnError: false);
			}
		}

		public virtual ScriptableObject ScriptableObjectInstance
		{
			get
			{
				CheckDisposed();
				return GetInstanceAs<ScriptableObject>(throwOnError: false);
			}
		}

		public virtual bool IsUnityObject => ScriptType.IsUnityObject;

		public virtual bool IsMonoBehaviour => ScriptType.IsMonoBehaviour;

		public virtual bool IsScriptableObject => ScriptType.IsScriptableObject;

		public abstract bool IsDisposed { get; }

		protected abstract void ConstructInstance(ScriptType type, object instance);

		public object Call(string methodName)
		{
			return Call(methodName, ProxyCallConvention.Any);
		}

		public object Call(string methodName, ProxyCallConvention callConvention)
		{
			CheckDisposed();
			MethodInfo methodInfo = ScriptType.FindCachedMethod(methodName, isStatic: false);
			if (methodInfo == null)
			{
				throw new TargetException($"Type '{ScriptType}' does not define a method called '{methodName}'");
			}
			object obj = methodInfo.Invoke(Instance, null);
			if (obj is IEnumerator && (callConvention == ProxyCallConvention.Any || callConvention == ProxyCallConvention.UnityCoroutine))
			{
				IEnumerator routine = obj as IEnumerator;
				if (IsMonoBehaviour)
				{
					GetInstanceAs<MonoBehaviour>(throwOnError: false).StartCoroutine(routine);
				}
			}
			return obj;
		}

		public object Call(string methodName, params object[] arguments)
		{
			return Call(methodName, ProxyCallConvention.Any, arguments);
		}

		public object Call(string methodName, ProxyCallConvention callConvention, params object[] arguments)
		{
			CheckDisposed();
			MethodInfo methodInfo = ScriptType.FindCachedMethod(methodName, isStatic: false);
			if (methodInfo == null)
			{
				throw new TargetException($"Type '{ScriptType}' does not define a method called '{methodName}'");
			}
			object obj = methodInfo.Invoke(Instance, arguments);
			if (obj is IEnumerator && (callConvention == ProxyCallConvention.Any || callConvention == ProxyCallConvention.UnityCoroutine))
			{
				IEnumerator routine = obj as IEnumerator;
				if (IsMonoBehaviour)
				{
					GetInstanceAs<MonoBehaviour>(throwOnError: false).StartCoroutine(routine);
				}
			}
			return obj;
		}

		public object SafeCall(string method)
		{
			return SafeCall(method, ProxyCallConvention.Any);
		}

		public object SafeCall(string method, ProxyCallConvention callConvention)
		{
			try
			{
				CheckDisposed();
				return Call(method, callConvention);
			}
			catch
			{
				return null;
			}
		}

		public object SafeCall(string method, params object[] arguments)
		{
			return SafeCall(method, ProxyCallConvention.Any, arguments);
		}

		public object SafeCall(string method, ProxyCallConvention callConvention, params object[] arguments)
		{
			try
			{
				CheckDisposed();
				return Call(method, callConvention, arguments);
			}
			catch
			{
				return null;
			}
		}

		public Type GetInstanceType()
		{
			return Instance.GetType();
		}

		public virtual T GetInstanceAs<T>(bool throwOnError, T errorValue = default(T))
		{
			if (throwOnError)
			{
				return (T)Instance;
			}
			try
			{
				return (T)Instance;
			}
			catch
			{
				return errorValue;
			}
		}

		public abstract void Dispose();

		public virtual void MakePersistent()
		{
			if (IsUnityObject)
			{
				UnityEngine.Object.DontDestroyOnLoad(UnityInstance);
			}
		}

		protected virtual void CheckDisposed()
		{
			if (IsDisposed)
			{
				throw new ObjectDisposedException("The script has already been disposed. Unity types can be disposed automatically when the wrapped type is destroyed");
			}
		}

		public static ScriptProxy CreateScriptProxy(ScriptType type, object instance)
		{
			return CreateScriptProxy<ScriptProxyImpl>(type, instance);
		}

		public static T CreateScriptProxy<T>(ScriptType type, object instance) where T : ScriptProxy, new()
		{
			T val = new T();
			val.ConstructInstance(type, instance);
			return val;
		}
	}
}
