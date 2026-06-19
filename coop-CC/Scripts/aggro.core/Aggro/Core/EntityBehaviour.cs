using System.Collections.Generic;
using Aggro.Core.Networking;
using Mirror;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

namespace Aggro.Core
{
	[SelectionBase]
	[DisallowMultipleComponent]
	public sealed class EntityBehaviour : MonoBehaviour, IEntityTyped
	{
		private List<IEntityBehaviourBase> _behaviours = new List<IEntityBehaviourBase>();

		private bool _sentInitializeMsg;

		private bool _sentInitializeMsgLate;

		private bool _sentStartedRunningMsg;

		private bool _hasInitialized;

		private Rigidbody _rigidbody;

		private NavMeshAgent _agent;

		private Animator _animator;

		private PlayableDirector _director;

		private NetworkIdentity _networkIdentity;

		private NetworkTransformBase _networkTransform;

		private PredictedRigidbody _networkRigidbody;

		private NetworkAnimator _networkAnimator;

		private Dictionary<uint, NetworkEntityBehaviourBase> _idToBehaviour = new Dictionary<uint, NetworkEntityBehaviourBase>();

		private static List<NetworkEntityBehaviourBase> _networkBehaviours = new List<NetworkEntityBehaviourBase>();

		private List<Collider> _colliders = new List<Collider>();

		private static bool _skipOnDestroy;

		public EntityKey key { get; internal set; }

		public Entity entity => new Entity(key, world);

		public EntityManager entityManager { get; private set; }

		public EntityEventManager eventManager { get; private set; }

		public EntityWorld world { get; private set; }

		public bool isBeingUnityDestroyed { get; private set; }

		[RuntimeInitializeOnLoadMethod]
		private static void InitializeRunTime()
		{
			_skipOnDestroy = false;
		}

		private void OnEnable()
		{
			if (NetworkServer.active && EntityWorld.gameObjectWorld != null && !EntityWorld.gameObjectWorld.stopEntityBehaviourCreation && (object)GetComponent<NetworkIdentity>() != null)
			{
				NetworkServer.Spawn(base.gameObject);
			}
			if (entity.Exists(allowIsDying: true))
			{
				entityManager.SetEnabled(key, enabled: true);
				if (!_sentStartedRunningMsg)
				{
					_sentStartedRunningMsg = true;
					int count = _behaviours.Count;
					for (int i = 0; i < count; i++)
					{
						_behaviours[i].StartedRunning();
					}
				}
			}
			else
			{
				if (EntityWorld.gameObjectWorld == null || EntityWorld.gameObjectWorld.stopEntityBehaviourCreation)
				{
					return;
				}
				if (base.transform.parent != null)
				{
					EntityBehaviour componentInParent = base.transform.parent.GetComponentInParent<EntityBehaviour>();
					if ((object)componentInParent == null || !componentInParent.enabled || componentInParent.entity.Exists(allowIsDying: true))
					{
						EntityWorldUtil.CreateEntities(EntityWorld.gameObjectWorld, base.transform, runStartRunning: true);
					}
				}
				else
				{
					EntityWorldUtil.CreateEntities(EntityWorld.gameObjectWorld, base.transform, runStartRunning: true);
				}
			}
		}

		private void CheckInitialize()
		{
			if (_hasInitialized)
			{
				return;
			}
			_hasInitialized = true;
			EntityGetComponentsInChildren(_colliders, includeInactive: true);
			int count = _colliders.Count;
			for (int i = 0; i < count; i++)
			{
				Collider collider = _colliders[i];
				if ((object)collider.GetComponent<EntityCollider>() == null)
				{
					collider.gameObject.AddComponent<EntityCollider>();
				}
			}
			EntityGetComponentsInChildren(_behaviours, includeInactive: true);
			count = _behaviours.Count;
			for (int j = 0; j < count; j++)
			{
				IEntityBehaviourBase entityBehaviourBase = _behaviours[j];
				entityBehaviourBase.typeIndex = EntityTypeManager.GetIndex(entityBehaviourBase.GetType());
			}
			_behaviours.Sort((IEntityBehaviourBase x, IEntityBehaviourBase y) => x.typeIndex.CompareTo(y.typeIndex));
			for (int num = 0; num < count; num++)
			{
				_behaviours[num].behaviourIndex = num;
			}
			_rigidbody = EntityGetComponentInChildren<Rigidbody>(includeInactive: true);
			_agent = EntityGetComponentInChildren<NavMeshAgent>(includeInactive: true);
			_animator = EntityGetComponentInChildren<Animator>(includeInactive: true);
			_director = EntityGetComponentInChildren<PlayableDirector>(includeInactive: true);
			_networkIdentity = EntityGetComponentInChildren<NetworkIdentity>(includeInactive: true);
			_networkTransform = EntityGetComponentInChildren<NetworkTransformBase>(includeInactive: true);
			_networkRigidbody = EntityGetComponentInChildren<PredictedRigidbody>(includeInactive: true);
			_networkAnimator = EntityGetComponentInChildren<NetworkAnimator>(includeInactive: true);
			_networkBehaviours.Clear();
			EntityGetComponentsInChildren(_networkBehaviours, includeInactive: true);
			for (int num2 = 0; num2 < _networkBehaviours.Count; num2++)
			{
				NetworkEntityBehaviourBase networkEntityBehaviourBase = _networkBehaviours[num2];
				uint rawNetworkBehaviourId = networkEntityBehaviourBase.rawNetworkBehaviourId;
				NetworkEntityBehaviourBase value;
				if (rawNetworkBehaviourId == 0)
				{
					Debug.LogError("[NETWORK] NetworkEntityBehaviour has no id! " + networkEntityBehaviourBase.name, networkEntityBehaviourBase);
				}
				else if (_idToBehaviour.TryGetValue(rawNetworkBehaviourId, out value))
				{
					Debug.LogError($"[NETWORK] NetworkEntityBehaviour has conflicting id! Id: {rawNetworkBehaviourId} {networkEntityBehaviourBase.name} {value.name}", networkEntityBehaviourBase);
				}
				else
				{
					_idToBehaviour[rawNetworkBehaviourId] = networkEntityBehaviourBase;
				}
			}
		}

		[Server]
		public void ServerClientConnected(NetworkConnectionToClient conn)
		{
			if (!NetworkServer.active)
			{
				Debug.LogWarning("[Server] function 'System.Void Aggro.Core.EntityBehaviour::ServerClientConnected(Mirror.NetworkConnectionToClient)' called when server was not active");
				return;
			}
			for (int i = 0; i < _behaviours.Count; i++)
			{
				if (_behaviours[i] is NetworkEntityBehaviourBase networkEntityBehaviourBase)
				{
					networkEntityBehaviourBase.ServerClientConnected(conn);
				}
			}
		}

		[Server]
		public void ServerOwnerDisconnecting()
		{
			if (!NetworkServer.active)
			{
				Debug.LogWarning("[Server] function 'System.Void Aggro.Core.EntityBehaviour::ServerOwnerDisconnecting()' called when server was not active");
				return;
			}
			for (int i = 0; i < _behaviours.Count; i++)
			{
				if (_behaviours[i] is NetworkEntityBehaviourBase networkEntityBehaviourBase)
				{
					networkEntityBehaviourBase.ServerOwnerDisconnecting();
				}
			}
		}

		public bool TryGetNetworkBehaviour<T>(uint id, out T behaviour) where T : NetworkEntityBehaviourBase
		{
			if (id != 0 && _idToBehaviour.TryGetValue(id, out var value))
			{
				behaviour = value as T;
				return (object)behaviour != null;
			}
			behaviour = null;
			return false;
		}

		private void EntityGetComponentsInChildren<T>(List<T> children, bool includeInactive)
		{
			Transform transform = base.transform;
			children.AddRangeNoGarbage(transform.GetComponents<T>());
			for (int i = 0; i < transform.childCount; i++)
			{
				EntityGetComponentsInChildren(transform.GetChild(i), children, includeInactive);
			}
		}

		private void EntityGetComponentsInChildren<T>(Transform child, List<T> children, bool includeInactive)
		{
			if ((child.gameObject.activeSelf || includeInactive) && !(child.GetComponent<EntityBehaviour>() != null) && !(child.GetComponent<EntityIgnore>() != null))
			{
				children.AddRangeNoGarbage(child.GetComponents<T>());
				for (int i = 0; i < child.childCount; i++)
				{
					EntityGetComponentsInChildren(child.GetChild(i), children, includeInactive);
				}
			}
		}

		private T EntityGetComponentInChildren<T>(bool includeInactive) where T : class
		{
			if (TryGetComponent<T>(out var component))
			{
				return component;
			}
			Transform transform = base.transform;
			for (int i = 0; i < transform.childCount; i++)
			{
				component = EntityGetComponentInChildren<T>(transform.GetChild(i), includeInactive);
				if (component != null)
				{
					return component;
				}
			}
			return null;
		}

		private T EntityGetComponentInChildren<T>(Transform child, bool includeInactive) where T : class
		{
			if (!child.gameObject.activeSelf && !includeInactive)
			{
				return null;
			}
			if (child.GetComponent<EntityBehaviour>() != null || child.GetComponent<EntityIgnore>() != null)
			{
				return null;
			}
			if (child.TryGetComponent<T>(out var component))
			{
				return component;
			}
			for (int i = 0; i < child.childCount; i++)
			{
				component = EntityGetComponentInChildren<T>(child.GetChild(i), includeInactive);
				if (component != null)
				{
					return component;
				}
			}
			return null;
		}

		internal void CreateEntity(EntityWorld world)
		{
			CheckInitialize();
			this.world = world;
			entityManager = this.world.entityManager;
			eventManager = this.world.eventManager;
			key = entityManager.CreateEntity(EntityContext.defaultContext, base.isActiveAndEnabled, dying: false);
			entityManager.SetName(key, base.name);
			entityManager.AddObject(key, this);
			entityManager.AddObject(key, base.gameObject);
			entityManager.AddObject(key, base.transform);
			CheckAddComponent(_rigidbody);
			CheckAddComponent(_agent);
			CheckAddComponent(_animator);
			CheckAddComponent(_director);
			CheckAddComponent(_networkIdentity);
			CheckAddComponent(_networkTransform);
			CheckAddComponent(_networkRigidbody);
			CheckAddComponent(_networkAnimator);
			int count = _behaviours.Count;
			for (int i = 0; i < count; i++)
			{
				IEntityBehaviourBase entityBehaviourBase = _behaviours[i];
				entityBehaviourBase.entity = new Entity(key, world);
				entityManager.AddObject(key, entityBehaviourBase, entityBehaviourBase.typeIndex);
			}
			for (int j = 0; j < _colliders.Count; j++)
			{
				entityManager.AddObject(key, _colliders[j]);
			}
		}

		private void CheckAddComponent<T>(T field) where T : Component
		{
			if ((object)field != null)
			{
				entityManager.AddObject(key, field);
			}
		}

		internal void CreateCallInitialize()
		{
			if (!_sentInitializeMsg)
			{
				_sentInitializeMsg = true;
				int count = _behaviours.Count;
				for (int i = 0; i < count; i++)
				{
					_behaviours[i].Initialize();
				}
			}
		}

		internal void CreateCallInitializeLate()
		{
			if (!_sentInitializeMsgLate)
			{
				_sentInitializeMsgLate = true;
				int count = _behaviours.Count;
				for (int i = 0; i < count; i++)
				{
					_behaviours[i].InitializeLate();
				}
			}
		}

		internal void CreateCallCreate()
		{
			int count = _behaviours.Count;
			for (int i = 0; i < count; i++)
			{
				_behaviours[i].Created();
			}
		}

		internal void CreateCallStartRunning()
		{
			if (base.isActiveAndEnabled && !_sentStartedRunningMsg)
			{
				_sentStartedRunningMsg = true;
				int count = _behaviours.Count;
				for (int i = 0; i < count; i++)
				{
					_behaviours[i].StartedRunning();
				}
			}
		}

		internal void DestroyingEntity()
		{
			int count = _behaviours.Count;
			for (int i = 0; i < count; i++)
			{
				IEntityBehaviourBase entityBehaviourBase = _behaviours[i];
				if (entityBehaviourBase != null)
				{
					entityBehaviourBase.Destroyed();
					entityBehaviourBase.entity = Entity.invalid;
				}
			}
			world = null;
			entityManager = null;
			eventManager = null;
			key = EntityKey.invalid;
			_sentStartedRunningMsg = false;
		}

		private void OnDisable()
		{
			if (entityManager != null && entityManager.isValid && entityManager.Exists(key))
			{
				entityManager.SetEnabled(key, enabled: false);
			}
		}

		private void OnDestroy()
		{
			if (!_skipOnDestroy)
			{
				isBeingUnityDestroyed = true;
				if (entityManager != null && entityManager.Exists(key))
				{
					entityManager.DestroyEntity(key);
				}
			}
		}
	}
}
