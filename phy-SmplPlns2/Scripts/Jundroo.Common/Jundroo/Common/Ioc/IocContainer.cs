using System;
using System.Collections.Generic;
using UnityEngine;

namespace Jundroo.Common.Ioc
{
	public class IocContainer : IIocContainer
	{
		private Dictionary<object, Dictionary<Type, object>> _contextContainer = new Dictionary<object, Dictionary<Type, object>>();

		private Dictionary<Type, object> _singletonContainer = new Dictionary<Type, object>();

		public void Register<T>(T instance, IContext context)
		{
			Dictionary<Type, object> containerForContext = GetContainerForContext(context);
			Register(instance, containerForContext);
		}

		public void Register<T>(T instance)
		{
			Register(instance, _singletonContainer);
		}

		public void RegisterContext(IContext context)
		{
			if (!_contextContainer.ContainsKey(context))
			{
				_contextContainer.Add(context, new Dictionary<Type, object>());
			}
			else
			{
				Debug.LogError($"Instance already registered as a context: {context}");
			}
		}

		public T Resolve<T>(bool suppressWarnings = false)
		{
			T val = Resolve<T>(_singletonContainer);
			if (!suppressWarnings && val == null)
			{
				Debug.LogError("IOC - No instance registered for type: " + typeof(T).ToString());
			}
			return val;
		}

		public T Resolve<T>(IContext context, bool suppressWarnings = false)
		{
			Dictionary<Type, object> containerForContext = GetContainerForContext(context, suppressWarnings);
			T val = default(T);
			if (containerForContext != null)
			{
				val = Resolve<T>(containerForContext);
				if (val == null && !suppressWarnings)
				{
					Debug.LogError($"IOC - No instance of {typeof(T).ToString()} associated with the given context: {context}");
				}
			}
			return val;
		}

		public void UnRegister<T>()
		{
			UnRegister<T>(_singletonContainer);
		}

		public void UnRegister<T>(IContext context)
		{
			UnRegister<T>(GetContainerForContext(context));
		}

		public void UnregisterContext(IContext context)
		{
			Dictionary<Type, object> containerForContext = GetContainerForContext(context);
			_contextContainer.Remove(containerForContext);
		}

		private Dictionary<Type, object> GetContainerForContext(object context, bool suppressWarnings = false)
		{
			if (_contextContainer.ContainsKey(context))
			{
				return _contextContainer[context];
			}
			if (!suppressWarnings)
			{
				Debug.LogError($"The requested ioc context has either not been registered, or has been unregistered: {context}.");
			}
			return null;
		}

		private void Register<T>(T instance, Dictionary<Type, object> container)
		{
			Type typeFromHandle = typeof(T);
			if (!container.ContainsKey(typeFromHandle))
			{
				container.Add(typeFromHandle, instance);
				return;
			}
			Debug.LogErrorFormat("Ioc - Instance already registered for type: {0}", typeFromHandle.ToString());
		}

		private T Resolve<T>(Dictionary<Type, object> container)
		{
			Type typeFromHandle = typeof(T);
			if (!container.TryGetValue(typeFromHandle, out var value))
			{
				return default(T);
			}
			return (T)value;
		}

		private void UnRegister<T>(Dictionary<Type, object> container)
		{
			container.Remove(typeof(T));
		}
	}
}
