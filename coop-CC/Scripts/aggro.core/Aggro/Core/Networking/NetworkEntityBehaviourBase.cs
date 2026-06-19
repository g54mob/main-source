using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Mirror;
using Unity.Mathematics;
using UnityEngine;

namespace Aggro.Core.Networking
{
	public abstract class NetworkEntityBehaviourBase : NetworkBehaviour, IEntityBehaviourBase, IEntityTyped
	{
		[HideInInspector]
		[SerializeField]
		private uint _networkBehaviourId;

		private int _behaviourIndex;

		private int _typeIndex;

		private Entity _entity;

		public Entity entity => _entity;

		public EntityKey key => _entity.key;

		public EntityManager entityManager => _entity.entityManager;

		public EntityEventManager eventManager => _entity.eventManager;

		public EntityWorld world => _entity.world;

		public uint behaviourVersion { get; private set; }

		public int typeIndex => _typeIndex;

		public uint rawNetworkBehaviourId => _networkBehaviourId;

		public NetBehaviourId networkBehaviourId => new NetBehaviourId(entity.netIdentity, _networkBehaviourId);

		int IEntityBehaviourBase.behaviourIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _behaviourIndex;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				_behaviourIndex = value;
			}
		}

		Entity IEntityBehaviourBase.entity
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _entity;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				_entity = value;
			}
		}

		int IEntityBehaviourBase.typeIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _typeIndex;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				_typeIndex = value;
			}
		}

		public bool Exists()
		{
			return entity.Exists();
		}

		void IEntityBehaviourBase.UpdateSimulation()
		{
			behaviourVersion++;
			OnUpdateSimulation();
		}

		void IEntityBehaviourBase.UpdateSimulationEarly()
		{
			behaviourVersion++;
			OnUpdateSimulationEarly();
		}

		void IEntityBehaviourBase.UpdateSimulationLate()
		{
			behaviourVersion++;
			OnUpdateSimulationLate();
		}

		void IEntityBehaviourBase.UpdatePresentation()
		{
			behaviourVersion++;
			OnUpdatePresentation();
		}

		void IEntityBehaviourBase.UpdatePresentationEarly()
		{
			behaviourVersion++;
			OnUpdatePresentationEarly();
		}

		void IEntityBehaviourBase.UpdatePresentationLate()
		{
			behaviourVersion++;
			OnUpdatePresentationLate();
		}

		public EntityCoroutineId StartSimulationCoroutine(IEnumerator coroutine)
		{
			return world.simulationCoroutineManager.StartCoroutine(this, key, _typeIndex, coroutine);
		}

		public EntityCoroutineId StartPresentationCoroutine(IEnumerator coroutine)
		{
			return world.presentationCoroutineManager.StartCoroutine(this, key, _typeIndex, coroutine);
		}

		public void StopEntityCoroutine(EntityCoroutineId id)
		{
			entity.StopEntityCoroutine(id);
		}

		public bool IsRunningEntityCoroutine(EntityCoroutineId id)
		{
			return entity.IsRunningEntityCoroutine(id);
		}

		void IEntityBehaviourBase.Initialize()
		{
			try
			{
				OnInitializeBehaviour();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		void IEntityBehaviourBase.InitializeLate()
		{
			try
			{
				OnInitializeLateBehaviour();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		void IEntityBehaviourBase.Created()
		{
			try
			{
				OnEntityCreated();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		void IEntityBehaviourBase.StartedRunning()
		{
			try
			{
				OnEntityStart();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		void IEntityBehaviourBase.Destroyed()
		{
			try
			{
				OnEntityDestroyed();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		protected virtual void OnInitializeBehaviour()
		{
		}

		protected virtual void OnInitializeLateBehaviour()
		{
		}

		protected virtual void OnEntityCreated()
		{
		}

		protected virtual void OnEntityDestroyed()
		{
		}

		protected virtual void OnEntityStart()
		{
		}

		protected virtual void OnUpdateSimulationEarly()
		{
		}

		protected virtual void OnUpdateSimulation()
		{
		}

		protected virtual void OnUpdateSimulationLate()
		{
		}

		protected virtual void OnUpdatePresentationEarly()
		{
		}

		protected virtual void OnUpdatePresentation()
		{
		}

		protected virtual void OnUpdatePresentationLate()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetSeed(int seed = 0)
		{
			return Hash.Calculate(Hash.Calculate(_typeIndex, _behaviourIndex), Hash.Calculate(key.index, (int)key.version), Hash.Calculate(world.seed, Time.renderedFrameCount), seed);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Unity.Mathematics.Random GetRandom(int seed = 0)
		{
			return MathUtil.GetRandom(GetSeed(seed));
		}

		[Server]
		public void ServerClientConnected(NetworkConnectionToClient conn)
		{
			if (!NetworkServer.active)
			{
				Debug.LogWarning("[Server] function 'System.Void Aggro.Core.Networking.NetworkEntityBehaviourBase::ServerClientConnected(Mirror.NetworkConnectionToClient)' called when server was not active");
				return;
			}
			try
			{
				OnServerClientConnected(conn);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		[Server]
		public void ServerOwnerDisconnecting()
		{
			if (!NetworkServer.active)
			{
				Debug.LogWarning("[Server] function 'System.Void Aggro.Core.Networking.NetworkEntityBehaviourBase::ServerOwnerDisconnecting()' called when server was not active");
				return;
			}
			try
			{
				OnServerOwnerDisconnecting();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		protected virtual void OnServerClientConnected(NetworkConnectionToClient conn)
		{
		}

		protected virtual void OnServerOwnerDisconnecting()
		{
		}

		public override bool Weaved()
		{
			return true;
		}
	}
}
