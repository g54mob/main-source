using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

namespace RoslynCSharp
{
	public class ScriptProxy : IDisposable
	{
		private ScriptType scriptType;

		private ScriptFieldProxy fields;

		private ScriptPropertyProxy properies;

		private object instance;

		public ScriptType ScriptType
		{
			get
			{
				CheckDisposed();
				return scriptType;
			}
		}

		public IScriptMemberProxy Fields
		{
			get
			{
				CheckDisposed();
				fields.throwOnError = true;
				return fields;
			}
		}

		public IScriptMemberProxy SafeFields
		{
			get
			{
				CheckDisposed();
				fields.throwOnError = false;
				return fields;
			}
		}

		public IScriptMemberProxy Properties
		{
			get
			{
				CheckDisposed();
				properies.throwOnError = true;
				return properies;
			}
		}

		public IScriptMemberProxy SafeProperties
		{
			get
			{
				CheckDisposed();
				properies.throwOnError = false;
				return properies;
			}
		}

		public object Instance
		{
			get
			{
				CheckDisposed();
				return instance;
			}
		}

		public UnityEngine.Object UnityInstance
		{
			get
			{
				CheckDisposed();
				return instance as UnityEngine.Object;
			}
		}

		public MonoBehaviour BehaviourInstance
		{
			get
			{
				CheckDisposed();
				return instance as MonoBehaviour;
			}
		}

		public ScriptableObject ScriptableInstance
		{
			get
			{
				CheckDisposed();
				return instance as ScriptableObject;
			}
		}

		public bool IsUnityObject
		{
			get
			{
				CheckDisposed();
				return scriptType.IsUnityObject;
			}
		}

		public bool IsMonoBehaviour
		{
			get
			{
				CheckDisposed();
				return scriptType.IsMonoBehaviour;
			}
		}

		public bool IsScriptableObject
		{
			get
			{
				CheckDisposed();
				return scriptType.IsScriptableObject;
			}
		}

		public bool IsDisposed => instance == null;

		internal ScriptProxy(ScriptType scriptType, object instance)
		{
			this.scriptType = scriptType;
			this.instance = instance;
			fields = new ScriptFieldProxy(isStatic: false, scriptType, this);
			properies = new ScriptPropertyProxy(isStatic: false, scriptType, this);
		}

		public object Call(string methodName)
		{
			return Call(methodName, ProxyCallConvention.Any);
		}

		public object Call(string methodName, ProxyCallConvention callConvention)
		{
			CheckDisposed();
			MethodInfo methodInfo = scriptType.FindCachedMethod(methodName, isStatic: false);
			if (methodInfo == null)
			{
				throw new TargetException($"Type '{ScriptType}' does not define a method called '{methodName}'");
			}
			object obj = methodInfo.Invoke(instance, null);
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
			MethodInfo methodInfo = scriptType.FindCachedMethod(methodName, isStatic: false);
			if (methodInfo == null)
			{
				throw new TargetException($"Type '{ScriptType}' does not define a method called '{methodName}'");
			}
			object obj = methodInfo.Invoke(instance, arguments);
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
				return Call(method, callConvention);
			}
			catch
			{
				return null;
			}
		}

		public Type GetInstanceType()
		{
			CheckDisposed();
			return instance.GetType();
		}

		public T GetInstanceAs<T>(bool throwOnError, T errorValue = default(T))
		{
			if (throwOnError)
			{
				return (T)instance;
			}
			try
			{
				return (T)instance;
			}
			catch
			{
				return errorValue;
			}
		}

		public virtual void Dispose()
		{
			CheckDisposed();
			if (IsUnityObject)
			{
				UnityEngine.Object.Destroy(UnityInstance);
			}
			if (instance is IDisposable)
			{
				(instance as IDisposable).Dispose();
			}
			scriptType = null;
			instance = null;
		}

		public void MakePersistent()
		{
			if (IsUnityObject)
			{
				UnityEngine.Object.DontDestroyOnLoad(UnityInstance);
			}
		}

		private void CheckDisposed()
		{
			if (instance == null)
			{
				throw new ObjectDisposedException("The script has already been disposed. Unity types can be disposed automatically when the wrapped type is destroyed");
			}
		}
	}
}
