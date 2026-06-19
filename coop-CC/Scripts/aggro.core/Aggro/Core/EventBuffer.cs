using System;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Collections;
using Unity.Profiling;
using UnityEngine;

namespace Aggro.Core
{
	internal class EventBuffer<T> : IEventBuffer where T : struct, IEntityEvent
	{
		private struct Item
		{
			public EntityKey key;

			public T ev;
		}

		private class LocalListeners
		{
			public EntityKey key;

			public Entity entity;

			public Listeners listeners = new Listeners();
		}

		private class Listeners
		{
			private List<Delegate> _listeners = new List<Delegate>();

			private Dictionary<Delegate, int> _listenerToIndex = new Dictionary<Delegate, int>();

			public List<Delegate> listeners => _listeners;

			public void Add(Delegate callback)
			{
				_listenerToIndex[callback] = _listeners.Count;
				_listeners.Add(callback);
			}

			public void Remove(Delegate callback)
			{
				int num = _listenerToIndex[callback];
				_listenerToIndex.Remove(callback);
				_listeners.RemoveAtSwapBack(num);
				if (num < _listeners.Count)
				{
					_listenerToIndex[_listeners[num]] = num;
				}
			}

			public bool IsRegistered(Delegate callback)
			{
				return _listenerToIndex.ContainsKey(callback);
			}
		}

		private Listeners _global = new Listeners();

		private Listeners _globalGeneric = new Listeners();

		private List<LocalListeners> _local = new List<LocalListeners>();

		private List<LocalListeners> _localGeneric = new List<LocalListeners>();

		private List<Item> _events = new List<Item>();

		private ProfilerMarker _updateMarker;

		public int typeIndex => EntityTypeManager.GetIndex<T>();

		public EventBuffer()
		{
			_updateMarker = new ProfilerMarker(ProfilerCategory.Scripts, TypeUtil.GetFriendlyName<EventBuffer<T>>() + ".ProcessEvents");
		}

		public void ProcessEvents()
		{
			int count = _events.Count;
			for (int i = 0; i < count; i++)
			{
				Item item = _events[i];
				if (item.key.isValid)
				{
					if (item.key.index < _local.Count)
					{
						LocalListeners localListeners = _local[item.key.index];
						if (localListeners.key == item.key)
						{
							List<Delegate> listeners = localListeners.listeners.listeners;
							int count2 = listeners.Count;
							for (int j = 0; j < count2; j++)
							{
								try
								{
									Delegate obj = listeners[j];
									if (obj is LocalEntityEvent<T> localEntityEvent)
									{
										localEntityEvent(localListeners.entity, item.ev);
									}
									else
									{
										((LocalEntityKeyEvent<T>)obj)(item.key, item.ev);
									}
								}
								catch (Exception exception)
								{
									UnityEngine.Debug.LogException(exception);
								}
							}
						}
					}
					if (item.key.index >= _localGeneric.Count)
					{
						continue;
					}
					LocalListeners localListeners2 = _localGeneric[item.key.index];
					if (!(localListeners2.key == item.key))
					{
						continue;
					}
					List<Delegate> listeners2 = localListeners2.listeners.listeners;
					int count3 = listeners2.Count;
					for (int k = 0; k < count3; k++)
					{
						try
						{
							((LocalGenericEntityEvent)listeners2[k])(localListeners2.entity);
						}
						catch (Exception exception2)
						{
							UnityEngine.Debug.LogException(exception2);
						}
					}
					continue;
				}
				List<Delegate> listeners3 = _global.listeners;
				int count4 = listeners3.Count;
				for (int l = 0; l < count4; l++)
				{
					try
					{
						((GlobalEntityEvent<T>)listeners3[l])(item.ev);
					}
					catch (Exception exception3)
					{
						UnityEngine.Debug.LogException(exception3);
					}
				}
				listeners3 = _globalGeneric.listeners;
				count4 = listeners3.Count;
				for (int m = 0; m < count4; m++)
				{
					try
					{
						((GlobalGenericEntityEvent)listeners3[m])();
					}
					catch (Exception exception4)
					{
						UnityEngine.Debug.LogException(exception4);
					}
				}
			}
			_events.Clear();
		}

		public void AddGlobalRegistrations(List<EntityEventManager.GlobalRegistration> list)
		{
			Type typeFromHandle = typeof(T);
			for (int i = 0; i < _global.listeners.Count; i++)
			{
				list.Add(new EntityEventManager.GlobalRegistration
				{
					eventType = typeFromHandle,
					callback = _global.listeners[i]
				});
			}
		}

		public void QueueEvent(EntityKey key, in T ev)
		{
			Item item = new Item
			{
				key = key,
				ev = ev
			};
			_events.Add(item);
		}

		public void AddGlobalListener(GlobalEntityEvent<T> callback)
		{
			_global.Add(callback);
		}

		public void RemoveGlobalListener(GlobalEntityEvent<T> callback)
		{
			_global.Remove(callback);
		}

		public void AddGlobalGenericListener(GlobalGenericEntityEvent callback)
		{
			_globalGeneric.Add(callback);
		}

		public void RemoveGlobalGenericListener(GlobalGenericEntityEvent callback)
		{
		}

		public void AddLocalListener(EntityKey key, LocalEntityKeyEvent<T> callback)
		{
			while (_local.Count <= key.index)
			{
				_local.Add(null);
			}
			LocalListeners localListeners = _local[key.index];
			if (localListeners == null)
			{
				localListeners = new LocalListeners();
				_local[key.index] = localListeners;
			}
			localListeners.key = key;
			localListeners.entity = Entity.invalid;
			localListeners.listeners.Add(callback);
		}

		public void RemoveLocalListener(EntityKey key, LocalEntityKeyEvent<T> callback)
		{
			_local[key.index].listeners.Remove(callback);
		}

		public void AddLocalListener(Entity entity, LocalEntityEvent<T> callback)
		{
			while (_local.Count <= entity.key.index)
			{
				_local.Add(null);
			}
			LocalListeners localListeners = _local[entity.key.index];
			if (localListeners == null)
			{
				localListeners = new LocalListeners();
				_local[entity.key.index] = localListeners;
			}
			localListeners.key = entity.key;
			localListeners.entity = entity;
			localListeners.listeners.Add(callback);
		}

		public void RemoveLocalListener(Entity entity, LocalEntityEvent<T> callback)
		{
			LocalListeners localListeners = _local[entity.key.index];
			localListeners.listeners.Remove(callback);
			if (localListeners.listeners.listeners.Count == 0)
			{
				localListeners.entity = Entity.invalid;
				localListeners.key = EntityKey.invalid;
			}
		}

		public void AddLocalGenericListener(Entity entity, LocalGenericEntityEvent callback)
		{
			while (_localGeneric.Count <= entity.key.index)
			{
				_localGeneric.Add(null);
			}
			LocalListeners localListeners = _localGeneric[entity.key.index];
			if (localListeners == null)
			{
				localListeners = new LocalListeners();
				_localGeneric[entity.key.index] = localListeners;
			}
			localListeners.key = entity.key;
			localListeners.entity = entity;
			localListeners.listeners.Add(callback);
		}

		public void RemoveLocalGenericListener(Entity entity, LocalGenericEntityEvent callback)
		{
			LocalListeners localListeners = _localGeneric[entity.key.index];
			localListeners.listeners.Remove(callback);
			if (localListeners.listeners.listeners.Count == 0)
			{
				localListeners.entity = Entity.invalid;
				localListeners.key = EntityKey.invalid;
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void VerifyIsGlobalRegistered(Delegate callback)
		{
			if (!_global.IsRegistered(callback))
			{
				throw new InvalidOperationException("Global event callback is not registered! Event: " + TypeUtil.GetFriendlyName<T>() + " Callback: " + callback.Method.Name);
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void VerifyIsNotGlobalRegistered(Delegate callback)
		{
			if (_global.IsRegistered(callback))
			{
				throw new InvalidOperationException("Global event callback is already registered! Event: " + TypeUtil.GetFriendlyName<T>() + " Callback: " + callback.Method.Name);
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void VerifyIsLocalRegistered(EntityKey key, Delegate callback, List<LocalListeners> list)
		{
			if (key.index >= list.Count || list[key.index] == null || (list[key.index].key == key && !list[key.index].listeners.IsRegistered(callback)))
			{
				throw new InvalidOperationException($"Local event callback is not registered! Entity: {key} Event: {TypeUtil.GetFriendlyName<T>()} Callback: {callback.Method.Name}");
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void VerifyIsNotLocalRegistered(EntityKey key, Delegate callback, List<LocalListeners> list)
		{
			if (key.index < list.Count && list[key.index] != null && list[key.index].key == key && list[key.index].listeners.IsRegistered(callback))
			{
				throw new InvalidOperationException($"Local event callback is already registered! Entity: {key} Event: {TypeUtil.GetFriendlyName<T>()} Callback: {callback.Method.Name}");
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void VerifyIsUsableBy(EntityKey key, List<LocalListeners> list)
		{
			if (key.index < list.Count && list[key.index] != null && list[key.index].key.isValid && list[key.index].key != key)
			{
				throw new InvalidOperationException($"Local event listeners owned by another entity! Current: {list[key.index].key} Requester: {key} Event: {TypeUtil.GetFriendlyName<T>()}");
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void VerifyNotNull(Delegate callback)
		{
			if ((object)callback == null)
			{
				throw new ArgumentNullException("Event callback is null! Event: " + TypeUtil.GetFriendlyName<T>());
			}
		}
	}
}
