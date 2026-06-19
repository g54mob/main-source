using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Aggro.Core
{
	public class EntityEventManager
	{
		public struct GlobalRegistration
		{
			public Type eventType;

			public Delegate callback;
		}

		private struct LocalRegistration : IEquatable<LocalRegistration>
		{
			public Entity entity;

			public LocalGenericEntityEvent callback;

			public bool Equals(LocalRegistration other)
			{
				if (entity.Equals(other.entity))
				{
					return object.Equals(callback, other.callback);
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is LocalRegistration other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return HashCode.Combine(entity, callback);
			}
		}

		private List<IEventBuffer> _indexToBuffer = new List<IEventBuffer>();

		private List<IEventBuffer> _eventBuffers = new List<IEventBuffer>();

		private List<HashSet<GlobalGenericEntityEvent>> _queuedGlobalGenericRegistrations = new List<HashSet<GlobalGenericEntityEvent>>();

		private List<HashSet<LocalRegistration>> _queuedLocalGenericRegistrations = new List<HashSet<LocalRegistration>>();

		internal EntityEventManager()
		{
		}

		public void ProcessEvents()
		{
			int count = _eventBuffers.Count;
			for (int i = 0; i < count; i++)
			{
				_eventBuffers[i].ProcessEvents();
			}
		}

		public GlobalRegistration[] GetGlobalRegistrations()
		{
			List<GlobalRegistration> list = new List<GlobalRegistration>();
			for (int i = 0; i < _eventBuffers.Count; i++)
			{
				_eventBuffers[i].AddGlobalRegistrations(list);
			}
			return list.ToArray();
		}

		public void QueueGlobalEvent<T>(T ev) where T : struct, IEntityEvent
		{
			QueueGlobalEvent(ev, EntityTypeManager.GetIndex<T>());
		}

		public void QueueGlobalEvent<T>(T ev, int typeIndex) where T : struct, IEntityEvent
		{
			EventBuffer<T> addBuffer = GetAddBuffer<T>(typeIndex);
			addBuffer.QueueEvent(EntityKey.invalid, in ev);
			if (_queuedGlobalGenericRegistrations.Count < typeIndex)
			{
				return;
			}
			HashSet<GlobalGenericEntityEvent> hashSet = _queuedGlobalGenericRegistrations[typeIndex];
			if (hashSet == null || hashSet.Count <= 0)
			{
				return;
			}
			foreach (GlobalGenericEntityEvent item in hashSet)
			{
				addBuffer.AddGlobalGenericListener(item);
			}
			_queuedGlobalGenericRegistrations[typeIndex] = null;
		}

		public void QueueLocalEvent<T>(EntityKey key, T ev) where T : struct, IEntityEvent
		{
			QueueLocalEvent(key, ev, EntityTypeManager.GetIndex<T>());
		}

		public void QueueLocalEvent<T>(EntityKey key, T ev, int typeIndex) where T : struct, IEntityEvent
		{
			EventBuffer<T> addBuffer = GetAddBuffer<T>(typeIndex);
			addBuffer.QueueEvent(key, in ev);
			if (_queuedLocalGenericRegistrations.Count < typeIndex)
			{
				return;
			}
			HashSet<LocalRegistration> hashSet = _queuedLocalGenericRegistrations[typeIndex];
			if (hashSet == null || hashSet.Count <= 0)
			{
				return;
			}
			foreach (LocalRegistration item in hashSet)
			{
				addBuffer.AddLocalGenericListener(item.entity, item.callback);
			}
			_queuedLocalGenericRegistrations[typeIndex] = null;
		}

		public void AddGlobalListener<T>(GlobalEntityEvent<T> callback) where T : struct, IEntityEvent
		{
			AddGlobalListener(callback, EntityTypeManager.GetIndex<T>());
		}

		public void AddGlobalListener<T>(GlobalEntityEvent<T> callback, int typeIndex) where T : struct, IEntityEvent
		{
			GetAddBuffer<T>(typeIndex).AddGlobalListener(callback);
		}

		public void RemoveGlobalListener<T>(GlobalEntityEvent<T> callback) where T : struct, IEntityEvent
		{
			RemoveGlobalListener(callback, EntityTypeManager.GetIndex<T>());
		}

		public void RemoveGlobalListener<T>(GlobalEntityEvent<T> callback, int typeIndex) where T : struct, IEntityEvent
		{
			((EventBuffer<T>)_indexToBuffer[typeIndex]).RemoveGlobalListener(callback);
		}

		public void AddGlobalGenericListener(GlobalGenericEntityEvent callback, Type type)
		{
			AddGlobalGenericListener(callback, EntityTypeManager.GetIndex(type));
		}

		public void AddGlobalGenericListener(GlobalGenericEntityEvent callback, int typeIndex)
		{
			if (TryGetGenericBuffer(typeIndex, out var buffer))
			{
				buffer.AddGlobalGenericListener(callback);
				return;
			}
			while (_queuedGlobalGenericRegistrations.Count <= typeIndex)
			{
				_queuedGlobalGenericRegistrations.Add(null);
			}
			HashSet<GlobalGenericEntityEvent> hashSet = _queuedGlobalGenericRegistrations[typeIndex];
			if (hashSet == null)
			{
				hashSet = new HashSet<GlobalGenericEntityEvent>();
				_queuedGlobalGenericRegistrations[typeIndex] = hashSet;
			}
			hashSet.Add(callback);
		}

		public void RemoveGlobalGenericListener(GlobalGenericEntityEvent callback, Type type)
		{
			RemoveGlobalGenericListener(callback, EntityTypeManager.GetIndex(type));
		}

		public void RemoveGlobalGenericListener(GlobalGenericEntityEvent callback, int typeIndex)
		{
			if (TryGetGenericBuffer(typeIndex, out var buffer))
			{
				buffer.RemoveGlobalGenericListener(callback);
			}
			else
			{
				_queuedGlobalGenericRegistrations[typeIndex].Remove(callback);
			}
		}

		public void AddLocalListener<T>(EntityKey key, LocalEntityKeyEvent<T> callback) where T : struct, IEntityEvent
		{
			AddLocalListener(key, callback, EntityTypeManager.GetIndex<T>());
		}

		public void AddLocalListener<T>(EntityKey key, LocalEntityKeyEvent<T> callback, int typeIndex) where T : struct, IEntityEvent
		{
			GetAddBuffer<T>(typeIndex).AddLocalListener(key, callback);
		}

		public void RemoveLocalListener<T>(EntityKey key, LocalEntityKeyEvent<T> callback) where T : struct, IEntityEvent
		{
			RemoveLocalListener(key, callback, EntityTypeManager.GetIndex<T>());
		}

		public void RemoveLocalListener<T>(EntityKey key, LocalEntityKeyEvent<T> callback, int typeIndex) where T : struct, IEntityEvent
		{
			((EventBuffer<T>)_indexToBuffer[typeIndex]).RemoveLocalListener(key, callback);
		}

		internal void AddLocalListener<T>(Entity entity, LocalEntityEvent<T> callback) where T : struct, IEntityEvent
		{
			AddLocalListener(entity, callback, EntityTypeManager.GetIndex<T>());
		}

		internal void AddLocalListener<T>(Entity entity, LocalEntityEvent<T> callback, int typeIndex) where T : struct, IEntityEvent
		{
			GetAddBuffer<T>(typeIndex).AddLocalListener(entity, callback);
		}

		internal void RemoveLocalListener<T>(Entity entity, LocalEntityEvent<T> callback) where T : struct, IEntityEvent
		{
			RemoveLocalListener(entity, callback, EntityTypeManager.GetIndex<T>());
		}

		internal void RemoveLocalListener<T>(Entity entity, LocalEntityEvent<T> callback, int typeIndex) where T : struct, IEntityEvent
		{
			((EventBuffer<T>)_indexToBuffer[typeIndex]).RemoveLocalListener(entity, callback);
		}

		internal void AddLocalGenericListener(Entity entity, LocalGenericEntityEvent callback, Type type)
		{
			AddLocalGenericListener(entity, callback, EntityTypeManager.GetIndex(type));
		}

		internal void AddLocalGenericListener(Entity entity, LocalGenericEntityEvent callback, int typeIndex)
		{
			if (TryGetGenericBuffer(typeIndex, out var buffer))
			{
				buffer.AddLocalGenericListener(entity, callback);
				return;
			}
			while (_queuedLocalGenericRegistrations.Count <= typeIndex)
			{
				_queuedLocalGenericRegistrations.Add(null);
			}
			HashSet<LocalRegistration> hashSet = _queuedLocalGenericRegistrations[typeIndex];
			if (hashSet == null)
			{
				hashSet = new HashSet<LocalRegistration>();
				_queuedLocalGenericRegistrations[typeIndex] = hashSet;
			}
			hashSet.Add(new LocalRegistration
			{
				entity = entity,
				callback = callback
			});
		}

		internal void RemoveLocalGenericListener(Entity entity, LocalGenericEntityEvent callback, Type type)
		{
			RemoveLocalGenericListener(entity, callback, EntityTypeManager.GetIndex(type));
		}

		internal void RemoveLocalGenericListener(Entity entity, LocalGenericEntityEvent callback, int typeIndex)
		{
			if (TryGetGenericBuffer(typeIndex, out var buffer))
			{
				buffer.RemoveLocalGenericListener(entity, callback);
				return;
			}
			LocalRegistration item = new LocalRegistration
			{
				entity = entity,
				callback = callback
			};
			_queuedLocalGenericRegistrations[typeIndex].Remove(item);
		}

		private EventBuffer<T> GetAddBuffer<T>(int typeIndex) where T : struct, IEntityEvent
		{
			while (_indexToBuffer.Count <= typeIndex)
			{
				_indexToBuffer.Add(null);
			}
			EventBuffer<T> eventBuffer = _indexToBuffer[typeIndex] as EventBuffer<T>;
			if (eventBuffer == null)
			{
				eventBuffer = new EventBuffer<T>();
				_indexToBuffer[typeIndex] = eventBuffer;
				_eventBuffers.Add(eventBuffer);
			}
			return eventBuffer;
		}

		private bool TryGetGenericBuffer(int typeIndex, out IEventBuffer buffer)
		{
			if (typeIndex >= _indexToBuffer.Count)
			{
				buffer = null;
				return false;
			}
			buffer = _indexToBuffer[typeIndex];
			return buffer != null;
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void VerifyNotNull<T>(GlobalEntityEvent<T> callback) where T : struct, IEntityEvent
		{
			if (callback == null)
			{
				throw new ArgumentNullException("Global event callback is null! Event: " + TypeUtil.GetFriendlyName<T>());
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void VerifyNotNull<T>(EntityKey key, Delegate callback) where T : struct, IEntityEvent
		{
			if ((object)callback == null)
			{
				throw new ArgumentNullException($"Local event callback is null! Event: {TypeUtil.GetFriendlyName<T>()} Entity: {key}");
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void VerifyEventType(int typeIndex)
		{
			Type type = EntityTypeManager.GetType(typeIndex);
			if (!type.IsValueType)
			{
				throw new ArgumentException("Event type is not a struct! Event: " + TypeUtil.GetFriendlyName(type));
			}
			if (!typeof(IEntityEvent).IsAssignableFrom(type))
			{
				throw new ArgumentException("Event type does not implement IEntityEvent! Event: " + TypeUtil.GetFriendlyName(type));
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void VerifyNotNull(GlobalGenericEntityEvent callback, int typeIndex)
		{
			if (callback == null)
			{
				throw new ArgumentNullException("Global generic event callback is null! Event: " + TypeUtil.GetFriendlyName(EntityTypeManager.GetType(typeIndex)));
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void VerifyNotNull(LocalGenericEntityEvent callback, int typeIndex)
		{
			if (callback == null)
			{
				throw new ArgumentNullException("Local generic event callback is null! Event: " + TypeUtil.GetFriendlyName(EntityTypeManager.GetType(typeIndex)));
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void VerifyValid(Entity entity)
		{
			if (!entity.Exists())
			{
				throw new ArgumentNullException("Entity for local events is not valid!");
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void VerifyNotNull<T>(Entity entity, Delegate callback) where T : struct, IEntityEvent
		{
			if ((object)callback == null)
			{
				throw new ArgumentNullException("Local event callback is null! Event: " + TypeUtil.GetFriendlyName<T>());
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void VerifyBufferExists<T>() where T : struct, IEntityEvent
		{
			int index = EntityTypeManager.GetIndex<T>();
			if (index >= _indexToBuffer.Count || _indexToBuffer[index] == null)
			{
				throw new InvalidOperationException("Entity buffer does not exist! Event: " + TypeUtil.GetFriendlyName<T>());
			}
		}
	}
}
