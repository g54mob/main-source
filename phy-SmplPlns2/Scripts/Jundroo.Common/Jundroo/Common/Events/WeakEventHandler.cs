using System;
using System.Reflection;
using UnityEngine;

namespace Jundroo.Common.Events
{
	public static class WeakEventHandler
	{
		public delegate void WeakEventUnregisterCallback<T>(EventHandler<T> eventHandler) where T : EventArgs;

		private interface IWeakEventHandler<T> where T : EventArgs
		{
			EventHandler<T> Handler { get; }

			MethodInfo Method { get; }

			WeakReference Target { get; }
		}

		private class WeakEventHandlerWrapper<THandler, TArgs> : IWeakEventHandler<TArgs> where THandler : class where TArgs : EventArgs
		{
			private delegate void OpenEventHandler(THandler target, object sender, TArgs e);

			private EventHandler<TArgs> _handler;

			private OpenEventHandler _openHandler;

			private WeakReference _target;

			private WeakEventUnregisterCallback<TArgs> _unregisterCallback;

			public EventHandler<TArgs> Handler => _handler;

			public MethodInfo Method => _openHandler.Method;

			public WeakReference Target => _target;

			public WeakEventHandlerWrapper(EventHandler<TArgs> eventHandler, WeakEventUnregisterCallback<TArgs> unregister)
			{
				_target = new WeakReference(eventHandler.Target);
				_openHandler = (OpenEventHandler)Delegate.CreateDelegate(typeof(OpenEventHandler), null, eventHandler.Method);
				_handler = Invoke;
				_unregisterCallback = unregister;
			}

			public static implicit operator EventHandler<TArgs>(WeakEventHandlerWrapper<THandler, TArgs> weakEventHandler)
			{
				return weakEventHandler._handler;
			}

			public void Invoke(object sender, TArgs e)
			{
				THandler val = (THandler)_target.Target;
				UnityEngine.Object obj = val as UnityEngine.Object;
				bool flag = (object)obj != null;
				if (val != null && (!flag || !(obj == null)))
				{
					_openHandler(val, sender, e);
				}
				else if (_unregisterCallback != null)
				{
					_unregisterCallback(_handler);
					_unregisterCallback = null;
				}
			}
		}

		public static EventHandler<T> Create<T>(EventHandler<T> eventHandler, WeakEventUnregisterCallback<T> unregisterCallback) where T : EventArgs
		{
			if (eventHandler == null)
			{
				throw new ArgumentNullException("eventHandler");
			}
			if (eventHandler.Method.IsStatic || eventHandler.Target == null)
			{
				return eventHandler;
			}
			return ((IWeakEventHandler<T>)typeof(WeakEventHandlerWrapper<, >).MakeGenericType(eventHandler.Method.DeclaringType, typeof(T)).GetConstructor(new Type[2]
			{
				typeof(EventHandler<T>),
				typeof(WeakEventUnregisterCallback<T>)
			}).Invoke(new object[2] { eventHandler, unregisterCallback })).Handler;
		}

		public static EventHandler<T> FindUnregisterHandler<T>(EventHandler<T> source, EventHandler<T> value) where T : EventArgs
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (source != null)
			{
				Delegate[] invocationList = source.GetInvocationList();
				foreach (Delegate obj in invocationList)
				{
					if ((object)obj != null && obj.Target is IWeakEventHandler<T> weakEventHandler && weakEventHandler.Target.Target == value.Target && weakEventHandler.Method == value.Method)
					{
						value = weakEventHandler.Handler;
						break;
					}
				}
			}
			return value;
		}
	}
}
