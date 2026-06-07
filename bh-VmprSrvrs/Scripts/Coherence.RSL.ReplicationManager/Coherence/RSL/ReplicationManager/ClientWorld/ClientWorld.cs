using System;
using System.Collections.Generic;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.RSL.EntityManager;
using Coherence.RSL.EntityManager.Commands;
using Coherence.RSL.EntityManager.Query;
using Coherence.RSL.EntityManager.Requests;

namespace Coherence.RSL.ReplicationManager.ClientWorld
{
	public class ClientWorld : IClientWorld, IDisposable
	{
		private IClientQueryHandler queryHandler;

		private uint participant;

		private Dictionary<Entity, EntityMeta> metas;

		private FloatingOrigin currentFloatingOrigin;

		private Dictionary<Entity, PositionQuery> positionQueries;

		private Dictionary<Entity, GlobalQuery> globalQueries;

		private Dictionary<Entity, TagQuery> tagQueries;

		private IOutgoingEntityChangeBuffer outgoingEntityChangeBuffer;

		private IExtendedDefinition root;

		private Dictionary<Entity, uint> lodLevel;

		private double minQueryDistance;

		private double minQuerySq;

		private uint scene;

		private ConnectionType connectionType;

		private Dictionary<Entity, HashSet<Entity>> parentToChild;

		private Logger logger;

		public ClientWorld(IClientQueryHandler queryHandler, IOutgoingEntityChangeBuffer outgoingEntityChangeBuffer, uint participant, IExtendedDefinition root, ConnectionType connectionType, double minQueryDistance, Logger logger)
		{
		}

		public void Dispose()
		{
		}

		public FloatingOrigin ProcessResponses(IReadOnlyList<ResponseInfo> responses, ref WorldProcessResult result)
		{
			return default(FloatingOrigin);
		}

		public void UpdateAuthority(AuthorityChangedMessage authorityChange, ref WorldProcessResult result)
		{
		}

		public bool GetEntityMeta(Entity entity, out EntityMeta meta)
		{
			meta = default(EntityMeta);
			return false;
		}

		private EntityChange CreateAuthorityUpdateChange(Entity entity, ICoherenceComponentData[] data, EntityMeta meta, bool isEntityKnown)
		{
			return default(EntityChange);
		}

		private void SendEntityOrphanRequest(Entity orphanEntity, ref WorldProcessResult result)
		{
		}

		private void SendEntityDeleteRequest(Entity entity, DestroyReason reason, ref WorldProcessResult result)
		{
		}

		private bool GetMetaWithAssert(Entity entity, string context, out EntityMeta meta)
		{
			meta = default(EntityMeta);
			return false;
		}

		private void ProcessChildrenOnDelete(Entity entity, EntityMeta meta, bool isInternal, DestroyReason reason, ref WorldProcessResult result)
		{
		}

		private void DestroyEntity(Entity entity, EntityMeta meta, bool isInternal, DestroyReason reason, ChannelID channelID, ref WorldProcessResult result)
		{
		}

		private int UpdateLODLevel(Entity entity, EntityMeta meta, out EntityArchetypeLOD newLOD)
		{
			newLOD = null;
			return 0;
		}

		private bool MovedToMoreDetailedLOD(int change)
		{
			return false;
		}

		private ICoherenceComponentData[] FilteredComponentsWhenIncreasingLevelOfDetail(EntityArchetypeLOD newLOD, EntityMeta meta, ICoherenceComponentData[] data)
		{
			return null;
		}

		private double DistanceToClosestQuery(Vector3d pos)
		{
			return 0.0;
		}

		private EntityMeta GetRootEntityMeta(EntityMeta meta)
		{
			return default(EntityMeta);
		}

		private bool GetLODForDistance(EntityMeta meta, out EntityArchetypeLOD lod)
		{
			lod = null;
			return false;
		}

		private long PrioForComponents(ICoherenceComponentData[] data)
		{
			return 0L;
		}

		private void PrioritizedEntityUpdateChange(Entity entity, ICoherenceComponentData[] data, EntityMeta meta, long priority, bool isInternal, ChannelID channelID, ref WorldProcessResult result)
		{
		}

		private void CreateEntity(Entity entity, ICoherenceComponentData[] data, EntityMeta meta, bool isInternal, ChannelID channelID, ref WorldProcessResult result)
		{
		}

		private void UnsetParentToChildLookup(Entity childEntity, EntityMeta meta)
		{
		}

		private void SetParentToChildLookup(Entity child, ICoherenceComponentData[] data, EntityMeta lastMeta)
		{
		}

		private void ResetWithQuery(ref WorldProcessResult result)
		{
		}

		private void ProcessFloatingOrigin(FloatingOrigin origin)
		{
		}

		private void ApplyFloatingOriginToMeta(ref EntityMeta meta, FloatingOrigin origin)
		{
		}

		private void DestroyDuplicate(Entity duplicateEntity, EntityMeta meta, ChannelID channelID, ref WorldProcessResult result)
		{
		}

		private void ProcessResolveDuplicate(ResponseInfo response, EntityMeta meta, ref WorldProcessResult result)
		{
		}

		private bool HasPositionQueryChanged(PositionQuery orig, PositionQuery final)
		{
			return false;
		}

		private QueryState CreateOrUpdatePositionQuery(Entity entity, ICoherenceComponentData[] comps)
		{
			return default(QueryState);
		}

		private QueryState CreateGlobalEntitiesQuery(Entity entity, ICoherenceComponentData[] comps)
		{
			return default(QueryState);
		}

		private QueryState CreateOrUpdateTagQuery(Entity entity, ICoherenceComponentData[] comps)
		{
			return default(QueryState);
		}

		private void ProcessQueryCreationResult(QueryState positionQueryState, QueryState globalQueryState, List<EntityChange> queryBornChanges, ref WorldProcessResult result)
		{
		}

		private void CheckAndUpdateQuery(Entity entity, ICoherenceComponentData[] comps, EntityMeta meta, ref WorldProcessResult result)
		{
		}

		private void UpdateConnectionScene(ICoherenceComponentData[] comps)
		{
		}

		private bool CanSeeAllScenes()
		{
			return false;
		}

		private QueryResponse RunQuery(List<IFilter> queries)
		{
			return default(QueryResponse);
		}

		private long FilterByQueriedParent(Entity parentEntity)
		{
			return 0L;
		}

		private long FilterRequest(Entity entityToFilter, EntityMeta meta)
		{
			return 0L;
		}

		private void ProcessCreate(CreateEntityRequest req, EntityMeta meta, ref WorldProcessResult result)
		{
		}

		private (ICoherenceComponentData[], EntityMeta) GetSingleEntityData(Entity entity)
		{
			return default((ICoherenceComponentData[], EntityMeta));
		}

		private void UpdateEntity(Entity entity, ICoherenceComponentData[] data, EntityMeta meta, long priority, bool isInternal, ChannelID channelID, ref WorldProcessResult result)
		{
		}

		private void GetCompleteChangesForEntity(Entity entity, bool isInternal, ref WorldProcessResult result)
		{
		}

		private void ProcessUpdate(UpdateComponentsRequest req, EntityMeta meta, ref WorldProcessResult result)
		{
		}

		private void RemoveComponents(Entity entity, IReadOnlyList<uint> compTypes, EntityMeta meta, long priority, bool isInternal, ChannelID channelID, ref WorldProcessResult result)
		{
		}

		private void CheckAndRemoveQuery(Entity entity, IReadOnlyList<uint> compTypes, ref WorldProcessResult result)
		{
		}

		private void ProcessRemoveComponents(RemoveComponentsRequest req, EntityMeta meta, ref WorldProcessResult result)
		{
		}

		private void DestroyOwnEntity(Entity entity, EntityMeta meta, ref WorldProcessResult result)
		{
		}

		private void CheckAndDestroyQuery(Entity entity, ref WorldProcessResult result)
		{
		}

		private void ProcessDestroy(DestroyEntityRequest req, EntityMeta meta, ref WorldProcessResult result)
		{
		}

		private void ProcessClientSwitched(ClientSwitchedSceneRequest req, ref WorldProcessResult result)
		{
		}

		private void HandleResponse(ResponseInfo response, ref WorldProcessResult result)
		{
		}

		public bool EntityExists_Test(Entity entity)
		{
			return false;
		}

		public bool EntityParent_Test(Entity parent, Entity child)
		{
			return false;
		}
	}
}
