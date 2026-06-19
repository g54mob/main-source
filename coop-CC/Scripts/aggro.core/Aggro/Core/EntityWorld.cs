using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Unity.Collections;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Aggro.Core
{
	public class EntityWorld : IDisposable
	{
		private ProfilerMarker _updateMarker;

		private Dictionary<Type, EntitySystemBase> _typeToSystems = new Dictionary<Type, EntitySystemBase>();

		private List<EntitySystemBase> _systems = new List<EntitySystemBase>();

		private List<object> _buffers = new List<object>();

		private List<IExternalData> _datas = new List<IExternalData>();

		private static List<EntityWorld> _worlds = new List<EntityWorld>();

		private static List<EntityWorld> _gameObjectWorlds = new List<EntityWorld>();

		private EntitySystemBase _mainSystem;

		public readonly string name;

		private readonly EntityWorldFlags _flags;

		public int seed;

		public bool stopEntityBehaviourCreation;

		private static HashSet<Type> _loopDetection = new HashSet<Type>();

		public bool isValid { get; private set; }

		public uint version { get; private set; }

		public EntityManager entityManager { get; private set; }

		public EntityEventManager eventManager { get; private set; }

		public EntityCoroutineManager simulationCoroutineManager { get; private set; }

		public EntityCoroutineManager presentationCoroutineManager { get; private set; }

		public int systemCount => _systems.Count;

		public static EntityWorld gameObjectWorld
		{
			get
			{
				if (_gameObjectWorlds.Count <= 0)
				{
					return null;
				}
				return _gameObjectWorlds[0];
			}
		}

		public EntityWorld(string name, Allocator allocator)
			: this(name, EntityWorldFlags.CreateBasicUpdater | EntityWorldFlags.GameObjectWorld, 0, allocator)
		{
		}

		public EntityWorld(string name, EntityWorldFlags flags, Allocator allocator)
			: this(name, flags, 0, allocator)
		{
		}

		public EntityWorld(string name, EntityWorldFlags flags, int entityCapacity, Allocator allocator)
		{
			this.name = name;
			_flags = flags;
			entityManager = new EntityManager(this, entityCapacity, allocator);
			eventManager = new EntityEventManager();
			simulationCoroutineManager = new EntityCoroutineManager(entityManager);
			presentationCoroutineManager = new EntityCoroutineManager(entityManager);
			_updateMarker = new ProfilerMarker(ProfilerCategory.Scripts, "World.Update (" + name + ")");
			_worlds.Add(this);
			isValid = true;
			if ((flags & EntityWorldFlags.CreateBasicUpdater) != 0)
			{
				SetMainUpdateSystem<BasicWorldUpdateSystem>();
			}
			if ((flags & EntityWorldFlags.GameObjectWorld) != 0)
			{
				_gameObjectWorlds.Add(this);
			}
		}

		public void ProcessExistingEntities(bool runStartRunning)
		{
			List<GameObject> list = new List<GameObject>();
			List<Transform> list2 = new List<Transform>();
			int sceneCount = SceneManager.sceneCount;
			for (int i = 0; i < sceneCount; i++)
			{
				Scene sceneAt = SceneManager.GetSceneAt(i);
				list.Clear();
				sceneAt.GetRootGameObjects(list);
				int count = list.Count;
				for (int j = 0; j < count; j++)
				{
					GameObject gameObject = list[j];
					if (gameObject.activeInHierarchy)
					{
						list2.Add(gameObject.transform);
					}
				}
			}
			EntityWorldUtil.CreateEntities(this, list2, runStartRunning);
		}

		public void RunStartRunningMessages()
		{
			ObjectQuery<EntityBehaviour> objectQuery = entityManager.CreateObjectQuery<EntityBehaviour>();
			objectQuery.Run();
			for (int i = 0; i < objectQuery.count; i++)
			{
				objectQuery.GetObject(i).CreateCallStartRunning();
			}
		}

		public void Dispose()
		{
			entityManager.dependency.Complete();
			for (int i = 0; i < _systems.Count; i++)
			{
				_systems[i].Destroyed();
			}
			_systems.Clear();
			entityManager.Dispose();
			_worlds.Remove(this);
			if ((_flags & EntityWorldFlags.GameObjectWorld) != 0)
			{
				_gameObjectWorlds.Remove(this);
			}
			isValid = false;
		}

		public void SetMainUpdateSystem<T>() where T : EntitySystemBase
		{
			_mainSystem = GetOrCreateSystem<T>();
		}

		public void Update()
		{
			version++;
			if (_mainSystem != null)
			{
				_mainSystem.Update();
			}
		}

		public T GetOrCreateSystem<T>() where T : EntitySystemBase
		{
			if (!HasSystem<T>())
			{
				CreateSystem<T>();
			}
			return GetSystem<T>();
		}

		public EntitySystemBase GetOrCreateSystem(Type type)
		{
			if (!HasSystem(type))
			{
				CreateSystem(type);
			}
			return GetSystem(type);
		}

		public bool HasSystem<T>() where T : EntitySystemBase
		{
			return HasSystem(typeof(T));
		}

		public bool HasSystem(Type type)
		{
			return _typeToSystems.ContainsKey(type);
		}

		public T GetSystem<T>() where T : EntitySystemBase
		{
			return (T)GetSystem(typeof(T));
		}

		public EntitySystemBase GetSystem(Type systemType)
		{
			if (!_typeToSystems.TryGetValue(systemType, out var value))
			{
				throw new InvalidOperationException("System does not exist in world! World: " + name + " Type: " + systemType.FullName);
			}
			return value;
		}

		public EntitySystemBase CreateSystem<T>() where T : EntitySystemBase
		{
			return CreateSystem(typeof(T));
		}

		public EntitySystemBase CreateSystem<T>(Type groupType, int priority) where T : EntitySystemBase
		{
			return CreateSystem(typeof(T), groupType, priority);
		}

		public EntitySystemBase CreateSystem(Type systemType)
		{
			EntityWorldUtil.GetGroupAndPriority(systemType, out var group, out var priority);
			return CreateSystem(systemType, group, priority);
		}

		public EntitySystemBase CreateSystem(Type systemType, Type groupType, int priority)
		{
			_loopDetection.Clear();
			return CreateSystemInternal(systemType, groupType, priority);
		}

		private EntitySystemBase CreateSystemInternal(Type systemType, Type groupType, int priority)
		{
			if (_loopDetection.Contains(systemType))
			{
				throw new InvalidOperationException("Infinite loop detected with system creation! World: " + name + " Type: " + systemType.FullName);
			}
			_loopDetection.Add(systemType);
			EntitySystemBase entitySystemBase;
			if (groupType == null)
			{
				if (priority != 0)
				{
					UnityEngine.Debug.LogWarning("System has no group but has defined a priority, this will be ignored! World: " + name + " Type: " + systemType.FullName);
				}
				entitySystemBase = (EntitySystemBase)Activator.CreateInstance(systemType);
			}
			else
			{
				if (!typeof(EntitySystemGroupBase).IsAssignableFrom(groupType))
				{
					throw new InvalidOperationException($"Group type isn't a system group! World: {name} Type: {systemType} Group: {groupType}");
				}
				if (!HasSystem(groupType))
				{
					EntityWorldUtil.GetGroupAndPriority(groupType, out var group, out var priority2);
					CreateSystemInternal(groupType, group, priority2);
				}
				EntitySystemGroupBase obj = (EntitySystemGroupBase)GetSystem(groupType);
				entitySystemBase = (EntitySystemBase)Activator.CreateInstance(systemType);
				obj.AddSystem(entitySystemBase, priority);
			}
			entitySystemBase.systemId = _systems.Count;
			entitySystemBase.entityManager = entityManager;
			entitySystemBase.eventManager = eventManager;
			entitySystemBase.world = this;
			_typeToSystems[systemType] = entitySystemBase;
			_systems.Add(entitySystemBase);
			entitySystemBase.Created();
			return entitySystemBase;
		}

		internal void CreateBehaviourSystem(Type systemType, MethodInfo methodInfo, Type rootGroup, Type defaultGroup)
		{
			EntityWorldUtil.GetGroupAndPriority(methodInfo, out var group, out var priority);
			if (group == null)
			{
				group = defaultGroup;
			}
			CreateBehaviourSystem(systemType, methodInfo.DeclaringType, group, priority);
		}

		internal void CreateBehaviourSystem(Type systemType, Type behaviourType, Type groupType, int priority)
		{
			_loopDetection.Clear();
			CreateBehaviourSystemInternal(systemType, behaviourType, groupType, priority);
		}

		private void CreateBehaviourSystemInternal(Type systemType, Type behaviourType, Type groupType, int priority)
		{
			if (_loopDetection.Contains(systemType))
			{
				throw new InvalidOperationException("Infinite loop detect with system creation! World: " + name + " Type: " + systemType.FullName);
			}
			_loopDetection.Add(systemType);
			EntityBehaviourSystemBase entityBehaviourSystemBase;
			if (groupType == null)
			{
				if (priority != 0)
				{
					UnityEngine.Debug.LogWarning("System has no group but has defined a priority, this will be ignored! World: " + name + " Type: " + systemType.FullName);
				}
				entityBehaviourSystemBase = (EntityBehaviourSystemBase)Activator.CreateInstance(systemType);
			}
			else
			{
				if (!typeof(EntitySystemGroupBase).IsAssignableFrom(groupType))
				{
					throw new InvalidOperationException($"Group type isn't a system group! World: {name} Type: {systemType} Group: {groupType}");
				}
				if (!HasSystem(groupType))
				{
					EntityWorldUtil.GetGroupAndPriority(groupType, out var group, out var priority2);
					CreateSystemInternal(groupType, group, priority2);
				}
				EntitySystemGroupBase obj = (EntitySystemGroupBase)GetSystem(groupType);
				entityBehaviourSystemBase = (EntityBehaviourSystemBase)Activator.CreateInstance(systemType);
				obj.AddSystem(entityBehaviourSystemBase, priority);
			}
			entityBehaviourSystemBase.systemId = _systems.Count;
			entityBehaviourSystemBase.entityManager = entityManager;
			entityBehaviourSystemBase.eventManager = eventManager;
			entityBehaviourSystemBase.world = this;
			_systems.Add(entityBehaviourSystemBase);
			entityBehaviourSystemBase.Initialize(behaviourType);
			entityBehaviourSystemBase.Created();
		}

		public bool HasBuffer<T>() where T : struct, IBufferItem
		{
			return HasBuffer(EntityTypeManager.GetIndex<T>());
		}

		public bool HasBuffer(Type type)
		{
			return HasBuffer(EntityTypeManager.GetIndex(type));
		}

		public bool HasBuffer(int typeIndex)
		{
			if (typeIndex < _buffers.Count)
			{
				return _buffers[typeIndex] != null;
			}
			return false;
		}

		public EntityBuffer<T> GetBuffer<T>() where T : struct, IBufferItem
		{
			return GetBuffer<T>(EntityTypeManager.GetIndex<T>());
		}

		public EntityBuffer<T> GetBuffer<T>(int typeIndex) where T : struct, IBufferItem
		{
			if (!HasBuffer(typeIndex))
			{
				throw new InvalidOperationException("Entity Buffer not part of world! World: " + name + " Type: " + typeof(T).FullName);
			}
			return new EntityBuffer<T>
			{
				Items = (List<T>)_buffers[typeIndex]
			};
		}

		public void CreateBuffer<T>() where T : struct, IBufferItem
		{
			if (HasBuffer<T>())
			{
				throw new InvalidOperationException("Entity Buffer already exists in world! World: " + name + " Type: " + typeof(T).FullName);
			}
			int index = EntityTypeManager.GetIndex<T>();
			while (_buffers.Count <= index)
			{
				_buffers.Add(null);
			}
			_buffers[index] = new List<T>();
		}

		public void CreateBuffer(Type type)
		{
			if (HasBuffer(type))
			{
				throw new InvalidOperationException("Entity Buffer already exists in world! World: " + name + " Type: " + type.FullName);
			}
			int index = EntityTypeManager.GetIndex(type);
			while (_buffers.Count <= index)
			{
				_buffers.Add(null);
			}
			Type type2 = typeof(List<>).MakeGenericType(type);
			_buffers[index] = Activator.CreateInstance(type2);
		}

		public bool HasExternalData<T>() where T : class, IExternalData
		{
			return HasExternalData(EntityTypeManager.GetIndex<T>());
		}

		public bool HasExternalData(Type type)
		{
			return HasExternalData(EntityTypeManager.GetIndex(type));
		}

		public bool HasExternalData(int typeIndex)
		{
			if (typeIndex < _datas.Count)
			{
				return _datas[typeIndex] != null;
			}
			return false;
		}

		public T GetExternalData<T>() where T : class, IExternalData
		{
			return GetExternalData<T>(EntityTypeManager.GetIndex<T>());
		}

		public T GetExternalData<T>(int typeIndex) where T : class, IExternalData
		{
			if (!HasExternalData(typeIndex))
			{
				throw new InvalidOperationException("External Data not part of world! World: " + name + " Type: " + typeof(T).FullName);
			}
			return (T)_datas[typeIndex];
		}

		public void CreateExternalData<T>() where T : class, IExternalData
		{
			CreateExternalData(typeof(T));
		}

		public void CreateExternalData(Type type)
		{
			if (HasExternalData(type))
			{
				throw new InvalidOperationException("External Data already exists in world! World: " + name + " Type: " + type.FullName);
			}
			int index = EntityTypeManager.GetIndex(type);
			while (_datas.Count <= index)
			{
				_datas.Add(null);
			}
			_datas[index] = (IExternalData)Activator.CreateInstance(type);
		}

		public EntitySystemBase[] GetSystems()
		{
			return _systems.ToArray();
		}

		public void GetSystems(List<EntitySystemBase> systems)
		{
			systems.Clear();
			systems.AddRangeNoGarbage(_systems);
		}

		public static void GetWorlds(List<EntityWorld> worlds)
		{
			worlds.Clear();
			worlds.AddRangeNoGarbage(_worlds);
		}

		[Conditional("UNITY_EDITOR")]
		[Conditional("DEVELOPMENT_BUILD")]
		private void VerifyIsSystemType(Type type)
		{
			if (type == null)
			{
				throw new NullReferenceException("System type is null!");
			}
			if (!typeof(EntitySystemBase).IsAssignableFrom(type))
			{
				throw new InvalidOperationException("System type doesn't implement EntitySystemBase! (" + type.FullName + ")");
			}
		}

		[Conditional("UNITY_EDITOR")]
		[Conditional("DEVELOPMENT_BUILD")]
		private void VerifyIsEntityBufferType(Type type)
		{
			if (type == null)
			{
				throw new NullReferenceException("Entity Buffer type is null!");
			}
			if (!type.IsValueType)
			{
				throw new InvalidOperationException("Entity Buffer type is not a struct! (" + type.FullName + ")");
			}
			if (!typeof(IBufferItem).IsAssignableFrom(type))
			{
				throw new InvalidOperationException("Entity Buffer type does not implement IBufferItem! (" + type.FullName + ")");
			}
		}

		[Conditional("UNITY_EDITOR")]
		[Conditional("DEVELOPMENT_BUILD")]
		private void VerifyIsExternalDataType(Type type)
		{
			if (type == null)
			{
				throw new NullReferenceException("External Data type is null!");
			}
			if (!type.IsClass)
			{
				throw new InvalidOperationException("External Data type is not a class! (" + type.FullName + ")");
			}
			if (!typeof(IExternalData).IsAssignableFrom(type))
			{
				throw new InvalidOperationException("External Data type does not implement IExternalData! (" + type.FullName + ")");
			}
		}
	}
}
