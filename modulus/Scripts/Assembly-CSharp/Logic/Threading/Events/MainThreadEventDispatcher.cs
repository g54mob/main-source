#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.Collections.Generic;
using Events;
using UnityEngine;
using Utils;

namespace Logic.Threading.Events
{
	public class MainThreadEventDispatcher : MonoBehaviour
	{
		[SerializeField]
		private BaseEvent _levelClearedEvent;

		private static MainThreadEventDispatcher _instance;

		private static bool _exists;

		private readonly Dictionary<Type, IMainThreadQueue> _queues = new Dictionary<Type, IMainThreadQueue>();

		private readonly Queue<Type> _executionQueue = new Queue<Type>();

		public static bool Exists => _exists;

		public static MainThreadEventDispatcher Instance => _instance;

		private void Awake()
		{
			if (_instance != null)
			{
				this.DevException("Duplicate MainThreadEventDispatcher exists, destroying self", "Awake", 38);
				UnityEngine.Object.Destroy(this);
			}
			else
			{
				_instance = this;
				_exists = true;
				_levelClearedEvent.Register(Reset);
			}
		}

		private void OnDestroy()
		{
			_instance = null;
			_exists = false;
			_levelClearedEvent.UnRegister(Reset);
		}

		private void Reset()
		{
			lock (this)
			{
				_executionQueue.Clear();
				_queues.Clear();
			}
		}

		public void Update()
		{
			lock (this)
			{
				while (_executionQueue.Count > 0)
				{
					Type type = _executionQueue.Dequeue();
					if (!_queues.TryGetValue(type, out var value))
					{
						this.DevException("Queue is missing of type \"" + type.FullName + "\"", "Update", 74);
						break;
					}
					value.DequeueAndFire();
				}
			}
		}

		public void Enqueue<T, Y>(Y context) where T : MainThreadQueue<Y>, new() where Y : IMainThreadEventContext
		{
			lock (this)
			{
				Type typeFromHandle = typeof(T);
				T val;
				if (!_queues.TryGetValue(typeFromHandle, out var value))
				{
					val = new T();
					_queues.Add(typeFromHandle, val);
				}
				else
				{
					val = value as T;
				}
				val.Enqueue(context);
				_executionQueue.Enqueue(typeFromHandle);
			}
		}
	}
}
