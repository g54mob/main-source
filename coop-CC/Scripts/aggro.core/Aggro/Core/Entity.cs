using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Mirror;
using UnityEngine;

namespace Aggro.Core
{
	public readonly struct Entity : IEquatable<Entity>
	{
		public readonly EntityKey key;

		public readonly EntityManager entityManager;

		public readonly EntityWorld world;

		public readonly EntityEventManager eventManager;

		public static readonly Entity invalid = new Entity(EntityKey.invalid, null);

		public Animator animator => GetObject<Animator>();

		public Rigidbody rigidbody => GetObject<Rigidbody>();

		public EntityTag tags => GetObject<EntityTag>();

		public GameObject gameObject => GetObject<GameObject>();

		public Transform transform => GetObject<Transform>();

		public EntityBehaviour behaviour => GetObject<EntityBehaviour>();

		public NetworkIdentity netIdentity => GetObject<NetworkIdentity>();

		public NetworkTransformBase netTransform => GetObject<NetworkTransformBase>();

		public PredictedRigidbody predictedRigidbody => GetObject<PredictedRigidbody>();

		public PredictedRigidbodyGroup predictedRigidbodyGroup => GetObject<PredictedRigidbodyGroup>();

		public NetworkAnimator networkAnimator => GetObject<NetworkAnimator>();

		public bool isServer => netIdentity.isServer;

		public bool isClient => netIdentity.isClient;

		public bool isLocalPlayer => netIdentity.isLocalPlayer;

		public bool isServerOnly => netIdentity.isServerOnly;

		public bool isClientOnly => netIdentity.isClientOnly;

		public bool isOwned => netIdentity.isOwned;

		public string name
		{
			get
			{
				if (Exists())
				{
					return entityManager.GetName(key);
				}
				return "<INVALID>";
			}
		}

		public string devCmdName
		{
			get
			{
				if (Exists())
				{
					return string.Format("{0}-{1}", entityManager.GetName(key).Replace(" ", ""), key.index);
				}
				return "";
			}
		}

		public Entity(int index, uint version, EntityWorld world)
			: this(new EntityKey(index, version), world)
		{
		}

		public Entity(EntityKey key, EntityWorld world)
		{
			if (world == null)
			{
				this.key = EntityKey.invalid;
				this.world = null;
				entityManager = null;
				eventManager = null;
			}
			else
			{
				this.key = key;
				this.world = world;
				entityManager = world.entityManager;
				eventManager = world.eventManager;
			}
		}

		public bool Exists(bool allowIsDying = false)
		{
			if (!key.isValid)
			{
				return false;
			}
			if (entityManager == null || !entityManager.isValid || !entityManager.Exists(key))
			{
				return false;
			}
			if (!allowIsDying)
			{
				return !entityManager.IsDying(key);
			}
			return true;
		}

		public bool IsDying()
		{
			if (!key.isValid)
			{
				return false;
			}
			if (entityManager == null || !entityManager.isValid || !entityManager.Exists(key))
			{
				return false;
			}
			return entityManager.IsDying(key);
		}

		public EntityCoroutineId StartSimulationCoroutine(IEnumerator coroutine)
		{
			return world.simulationCoroutineManager.StartCoroutine(key, coroutine);
		}

		public EntityCoroutineId StartPresentationCoroutine(IEnumerator coroutine)
		{
			return world.presentationCoroutineManager.StartCoroutine(key, coroutine);
		}

		public void StopEntityCoroutine(EntityCoroutineId id)
		{
			if (world.simulationCoroutineManager.managerId == id.managerId)
			{
				world.simulationCoroutineManager.StopCoroutine(id);
			}
			else if (world.presentationCoroutineManager.managerId == id.managerId)
			{
				world.presentationCoroutineManager.StopCoroutine(id);
			}
			else
			{
				UnityEngine.Debug.LogError($"Trying to stop a coroutine with an unknown manager! ({id})", behaviour);
			}
		}

		public bool IsRunningEntityCoroutine(EntityCoroutineId id)
		{
			if (world.simulationCoroutineManager.managerId == id.managerId)
			{
				return world.simulationCoroutineManager.IsRunningCoroutine(id);
			}
			if (world.presentationCoroutineManager.managerId == id.managerId)
			{
				return world.presentationCoroutineManager.IsRunningCoroutine(id);
			}
			return false;
		}

		public void AddObject<T>(T obj) where T : class
		{
			entityManager.AddObject(key, obj);
		}

		public void AddObject(object obj, int typeIndex)
		{
			entityManager.AddObject(key, obj, typeIndex);
		}

		public void AddStruct<T>() where T : struct, IEntityStruct
		{
			entityManager.AddComponentData(key, default(T));
		}

		public void AddStruct<T>(T comp) where T : struct, IEntityStruct
		{
			entityManager.AddComponentData(key, comp);
		}

		public void SetOrAddStruct<T>(T comp) where T : struct, IEntityStruct
		{
			entityManager.SetOrAddComponentData(key, comp);
		}

		public void AddJobStruct<T>() where T : unmanaged, IEntityJobComponent
		{
			entityManager.AddJobComponentData(key, default(T));
		}

		public void AddJobStruct<T>(T comp) where T : unmanaged, IEntityJobComponent
		{
			entityManager.AddJobComponentData(key, comp);
		}

		public T GetObject<T>() where T : class
		{
			return entityManager.GetObject<T>(key);
		}

		public object GetObject(Type type)
		{
			return entityManager.GetObject(key, type);
		}

		public object GetObject(int typeIndex)
		{
			return entityManager.GetObject(key, typeIndex);
		}

		public void GetObjects<T>(List<T> objs, ObjectQueryFlags flags = ObjectQueryFlags.AllObjects) where T : class
		{
			entityManager.GetObjects(key, objs, flags);
		}

		public void GetObjects(List<object> objs, Type type, ObjectQueryFlags flags = ObjectQueryFlags.AllObjects)
		{
			entityManager.GetObjects(key, objs, type, flags);
		}

		public void GetObjects(List<object> objs, int typeIndex, ObjectQueryFlags flags = ObjectQueryFlags.AllObjects)
		{
			entityManager.GetObjects(key, objs, typeIndex, flags);
		}

		public T GetStruct<T>() where T : struct, IEntityStruct
		{
			return entityManager.GetComponentData<T>(key);
		}

		public T GetJobStruct<T>() where T : unmanaged, IEntityJobComponent
		{
			return entityManager.GetJobComponentData<T>(key);
		}

		public void SetStruct<T>(T comp) where T : struct, IEntityStruct
		{
			entityManager.SetComponentData(key, comp);
		}

		public void SetJobStruct<T>(T comp) where T : unmanaged, IEntityJobComponent
		{
			entityManager.SetJobComponentData(key, comp);
		}

		public bool HasObject<T>() where T : class
		{
			if (!Exists(allowIsDying: true))
			{
				return false;
			}
			return entityManager.HasObject<T>(key);
		}

		public bool HasObject(Type type)
		{
			if (!Exists(allowIsDying: true))
			{
				return false;
			}
			return entityManager.HasObject(key, type);
		}

		public bool HasObject(int typeIndex)
		{
			if (!Exists(allowIsDying: true))
			{
				return false;
			}
			return entityManager.HasObject(key, typeIndex);
		}

		public bool HasStruct<T>() where T : struct, IEntityStruct
		{
			if (!Exists(allowIsDying: true))
			{
				return false;
			}
			return entityManager.HasComponentData<T>(key);
		}

		public bool HasJobStruct<T>() where T : unmanaged, IEntityJobComponent
		{
			if (!Exists(allowIsDying: true))
			{
				return false;
			}
			return entityManager.HasJobComponentData<T>(key);
		}

		public bool TryGetObject<T>(out T obj) where T : class
		{
			if (!Exists(allowIsDying: true))
			{
				obj = null;
				return false;
			}
			return entityManager.TryGetObject<T>(key, out obj);
		}

		public bool TryGetObject<T>(int typeIndex, out T obj) where T : class
		{
			if (!Exists(allowIsDying: true))
			{
				obj = null;
				return false;
			}
			return entityManager.TryGetObject(key, typeIndex, out obj);
		}

		public bool TryGetObject(Type type, out object obj)
		{
			if (!Exists(allowIsDying: true))
			{
				obj = null;
				return false;
			}
			return entityManager.TryGetObject(key, type, out obj);
		}

		public bool TryGetObject(int typeIndex, out object obj)
		{
			if (!Exists(allowIsDying: true))
			{
				obj = null;
				return false;
			}
			return entityManager.TryGetObject(key, typeIndex, out obj);
		}

		public bool TryGetStruct<T>(out T comp) where T : struct, IEntityStruct
		{
			if (!Exists(allowIsDying: true))
			{
				comp = default(T);
				return false;
			}
			return entityManager.TryGetComponentData<T>(key, out comp);
		}

		public bool TryGetJobStruct<T>(out T comp) where T : unmanaged, IEntityJobComponent
		{
			if (!Exists(allowIsDying: true))
			{
				comp = default(T);
				return false;
			}
			return entityManager.TryGetJobComponentData<T>(key, out comp);
		}

		public void RemoveObject<T>(T obj) where T : class
		{
			entityManager.RemoveObject(key, obj);
		}

		public void RemoveObject(object obj, Type type)
		{
			entityManager.RemoveObject(key, obj, type);
		}

		public void RemoveObject(object obj, int typeIndex)
		{
			entityManager.RemoveObject(key, obj, typeIndex);
		}

		public void RemoveObjects<T>() where T : class
		{
			entityManager.RemoveObjects<T>(key);
		}

		public void RemoveObjects(Type type)
		{
			entityManager.RemoveObjects(key, type);
		}

		public void RemoveObjects(int typeIndex)
		{
			entityManager.RemoveObjects(key, typeIndex);
		}

		public void RemoveStruct<T>() where T : struct, IEntityStruct
		{
			entityManager.RemoveComponentData<T>(key);
		}

		public void RemoveJobStruct<T>() where T : unmanaged, IEntityJobComponent
		{
			entityManager.RemoveJobComponentData<T>(key);
		}

		public void QueueEvent<T>(T ev) where T : struct, IEntityEvent
		{
			eventManager.QueueLocalEvent(key, ev);
		}

		public void QueueEvent<T>(T ev, int typeIndex) where T : struct, IEntityEvent
		{
			eventManager.QueueLocalEvent(key, ev, typeIndex);
		}

		public void AddEventListener<T>(LocalEntityEvent<T> callback) where T : struct, IEntityEvent
		{
			eventManager.AddLocalListener(this, callback);
		}

		public void AddEventListener<T>(LocalEntityEvent<T> callback, int typeIndex) where T : struct, IEntityEvent
		{
			eventManager.AddLocalListener(this, callback, typeIndex);
		}

		public void RemoveEventListener<T>(LocalEntityEvent<T> callback) where T : struct, IEntityEvent
		{
			eventManager.RemoveLocalListener(this, callback);
		}

		public void RemoveEventListener<T>(LocalEntityEvent<T> callback, int typeIndex) where T : struct, IEntityEvent
		{
			eventManager.RemoveLocalListener(this, callback, typeIndex);
		}

		public void AddGenericEventListener(LocalGenericEntityEvent callback, Type type)
		{
			eventManager.AddLocalGenericListener(this, callback, type);
		}

		public void AddGenericEventListener(LocalGenericEntityEvent callback, int typeIndex)
		{
			eventManager.AddLocalGenericListener(this, callback, typeIndex);
		}

		public void RemoveGenericEventListener(LocalGenericEntityEvent callback, Type type)
		{
			eventManager.RemoveLocalGenericListener(this, callback, type);
		}

		public void RemoveGenericEventListener(LocalGenericEntityEvent callback, int typeIndex)
		{
			eventManager.RemoveLocalGenericListener(this, callback, typeIndex);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetSeed(int seed = 0)
		{
			return entityManager.GetSeed(key, seed);
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckValidCoroutineId(EntityCoroutineId id)
		{
			if (!id.isValid)
			{
				UnityEngine.Debug.LogError($"Invalid coroutine id! ({id})", behaviour);
				throw new InvalidOperationException();
			}
		}

		public bool Equals(Entity other)
		{
			return key.Equals(other.key);
		}

		public override bool Equals(object obj)
		{
			if (obj is Entity other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return key.GetHashCode();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Entity a, Entity b)
		{
			return a.key == b.key;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Entity a, Entity b)
		{
			return !(a == b);
		}

		public override string ToString()
		{
			return $"({key.index}, {key.version}) {name}";
		}
	}
}
