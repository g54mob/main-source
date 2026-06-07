using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence.Connection;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Coherence.Toolkit
{
	public class EntitiesManager : IEntitiesManager
	{
		[CompilerGenerated]
		private sealed class _003CAddClientConnection_003Ed__68 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public EntitiesManager _003C_003E4__this;

			public CoherenceClientConnection clientConnection;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CAddClientConnection_003Ed__68(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private HashSet<Entity> internalEntities;

		private IClient client;

		private readonly ICoherenceBridge bridge;

		private readonly IClientConnectionManager clientConnectionsManager;

		private readonly CoherenceInputManager inputManager;

		private readonly UniquenessManager uniquenessManager;

		private readonly IDefinition definition;

		private readonly Coherence.Log.Logger logger;

		internal readonly Dictionary<Entity, NetworkEntityState> networkEntities;

		internal readonly Dictionary<string, Queue<UnsyncedNetworkEntity>> unsyncedNetworkEntities;

		internal readonly Dictionary<string, UnsyncedNetworkEntity> unsyncedNetworkEntitiesByUniqueId;

		private readonly Dictionary<Entity, List<IncomingEntityUpdate>> delayedUpdatesDependingOnParents;

		private readonly Stack<Entity> delayedEntitiesToInstantiate;

		private readonly Dictionary<Entity, List<IncomingEntityUpdate>> delayedEntityUpdates;

		private readonly Dictionary<Entity, List<(IEntityCommand command, MessageTarget target)>> delayedEntityCommands;

		private readonly CoherenceLoopLookup coherenceLoopLookup;

		private Entity connectionEntityID;

		public IEnumerable<NetworkEntityState> NetworkEntities => null;

		public int EntityCount => 0;

		public Entity ConnectionEntityID => default(Entity);

		internal EntitiesManager()
		{
		}

		internal EntitiesManager(ICoherenceBridge bridge, IClientConnectionManager clientConnectionsManager, CoherenceInputManager inputManager, UniquenessManager uniquenessManager, IDefinition definition, Coherence.Log.Logger logger)
		{
		}

		public ICoherenceSync GetCoherenceSyncForEntity(Entity id)
		{
			return null;
		}

		public NetworkEntityState GetNetworkEntityStateForEntity(Entity id)
		{
			return null;
		}

		internal void InterpolateBindings(CoherenceSync.InterpolationLoop interpolationLoop)
		{
		}

		internal void InvokeCallbacks(CoherenceSync.InterpolationLoop interpolationLoop)
		{
		}

		internal void SampleBindings(CoherenceSync.InterpolationLoop interpolationLoop)
		{
		}

		internal void SyncAndSend()
		{
		}

		public static Entity UnityObjectToEntityId(GameObject from)
		{
			return default(Entity);
		}

		public static Entity UnityObjectToEntityId(Component from)
		{
			return default(Entity);
		}

		public Entity UnityObjectToEntityId(Transform from)
		{
			return default(Entity);
		}

		public static Entity UnityObjectToEntityId(ICoherenceSync from)
		{
			return default(Entity);
		}

		public GameObject EntityIdToGameObject(Entity from)
		{
			return null;
		}

		public Transform EntityIdToTransform(Entity from)
		{
			return null;
		}

		public RectTransform EntityIdToRectTransform(Entity from)
		{
			return null;
		}

		public ICoherenceSync EntityIdToCoherenceSync(Entity from)
		{
			return null;
		}

		public Scene? SetActiveScene()
		{
			return null;
		}

		internal bool TryGetNetworkEntityState(Entity id, out NetworkEntityState networkEntityState)
		{
			networkEntityState = null;
			return false;
		}

		public Dictionary<Entity, NetworkEntityState>.Enumerator GetEnumerator()
		{
			return default(Dictionary<Entity, NetworkEntityState>.Enumerator);
		}

		internal virtual (NetworkEntityState, ComponentUpdates?, uint?, bool) SyncNetworkEntityState(ICoherenceSync sync)
		{
			return default((NetworkEntityState, ComponentUpdates?, uint?, bool));
		}

		internal void ApplyDelayedUpdates(Entity id)
		{
		}

		internal bool AddDelayedCommand(IEntityCommand command, MessageTarget target, Entity id)
		{
			return false;
		}

		internal void ApplyDelayedCommands(Entity id)
		{
		}

		private bool DisableServerObjectIfClient(ICoherenceSync sync)
		{
			return false;
		}

		internal void DestroyAuthorityNetworkEntityState(NetworkEntityState state)
		{
		}

		internal void UpdateInterpolationLoopConfig(ICoherenceSync sync, CoherenceSync.InterpolationLoop newLocation)
		{
		}

		internal bool ContainsEntity(Entity id)
		{
			return false;
		}

		internal void Update()
		{
		}

		private void SetClient(IClient client)
		{
		}

		private (bool, UnsyncedNetworkEntity) ClaimUnsyncedNetworkEntity(string assetId, string uniqueId)
		{
			return default((bool, UnsyncedNetworkEntity));
		}

		private static bool FoundUnsyncedNetworkEntity((bool, UnsyncedNetworkEntity) result)
		{
			return false;
		}

		private NetworkEntityState CreateEntity(ICoherenceSync sync, string uuid)
		{
			return null;
		}

		private void HandleDisconnected(ConnectionCloseReason obj)
		{
		}

		private void CreateNetworkedEntity(Entity entityID, IncomingEntityUpdate entityUpdate, out bool shouldSpawn)
		{
			shouldSpawn = default(bool);
		}

		private void UpdateNetworkedEntity(Entity id, IncomingEntityUpdate entityUpdate)
		{
		}

		private void DestroyNetworkedEntity(Entity entityID, DestroyReason destroyReason)
		{
		}

		private void DestroyLocalObject(NetworkEntityState state, DestroyReason destroyReason)
		{
		}

		private void AddNetworkEntityStateToMapper(NetworkEntityState state, ICoherenceSync sync)
		{
		}

		private void RemoveEntityFromMapper(NetworkEntityState state)
		{
		}

		private void InstantiateNetworkedEntity(ICoherenceSync syncPrefab, SpawnInfo info, Entity entityID, IncomingEntityUpdate entityUpdate)
		{
		}

		private bool DelayInstantiationDependingOnParent(Entity parentEntity, IncomingEntityUpdate entityUpdate)
		{
			return false;
		}

		private void InstantiateCoherenceSync(ICoherenceSync syncPrefab, SpawnInfo info, NetworkEntityState state)
		{
		}

		private NetworkEntityState CreateUnsynchronizedNetworkEntity(SpawnInfo info, Entity entityID, IncomingEntityUpdate entityUpdate, CoherenceSync.UnsyncedNetworkEntityPriority unsyncedNetworkEntityPriority)
		{
			return null;
		}

		private void PostNetworkEntityCreationActions(NetworkEntityState state)
		{
		}

		private void InstantiateDelayedEntitiesDependingOnThisParent(Entity parentEntity)
		{
		}

		[IteratorStateMachine(typeof(_003CAddClientConnection_003Ed__68))]
		private IEnumerator AddClientConnection(CoherenceClientConnection clientConnection)
		{
			return null;
		}

		private static void RemoveUnhandledComponents(ComponentUpdates componentUpdates)
		{
		}
	}
}
