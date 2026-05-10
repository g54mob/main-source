using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core
{
	public class CTSEvent
	{
		private readonly List<Action> _callbacks = new List<Action>();

		public int Count => _callbacks.Count;

		public static CTSEvent operator +(CTSEvent @event, Action action)
		{
			@event.AddListener(action);
			return @event;
		}

		public static CTSEvent operator -(CTSEvent @event, Action action)
		{
			@event.RemoveListener(action);
			return @event;
		}

		public void AddListener(Action action)
		{
			_callbacks.Add(action);
		}

		public void RemoveListener(Action action)
		{
			_callbacks.Remove(action);
		}

		public void RemoveAllListeners()
		{
			_callbacks.Clear();
		}

		public void Invoke()
		{
			for (int i = 0; i < _callbacks.Count; i++)
			{
				try
				{
					_callbacks[i]();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}
	}
	public class CTSEvent<TArg>
	{
		private readonly List<Action<TArg>> _callbacks = new List<Action<TArg>>();

		public int Count => _callbacks.Count;

		public static CTSEvent<TArg> operator +(CTSEvent<TArg> @event, Action<TArg> action)
		{
			@event.AddListener(action);
			return @event;
		}

		public static CTSEvent<TArg> operator -(CTSEvent<TArg> @event, Action<TArg> action)
		{
			@event.RemoveListener(action);
			return @event;
		}

		public void AddListener(Action<TArg> action)
		{
			_callbacks.Add(action);
		}

		public void RemoveListener(Action<TArg> action)
		{
			_callbacks.Remove(action);
		}

		public void RemoveAllListeners()
		{
			_callbacks.Clear();
		}

		public void Invoke(TArg arg)
		{
			for (int i = 0; i < _callbacks.Count; i++)
			{
				try
				{
					_callbacks[i](arg);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}
	}
}
