using System;
using System.Collections.Generic;
using Coherence.Common;
using Coherence.Common.Pooling;
using Coherence.Connection;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.RSL.EntityManager.Commands;
using Coherence.RSL.EntityManager.Query;
using Coherence.RSL.EntityManager.Requests;
using Coherence.SimulationFrame;
using UnityEngine;

namespace Coherence.RSL.EntityManager
{
	public class EntityManager : IEntityManager, IClientQueryHandler, IDisposable
	{
		private enum StandardError
		{
			None = 0,
			Error = 1
		}

		private enum CreateRequestError
		{
			None = 0,
			OrderedComponent = 1,
			Invalid = 2,
			AlreadyCreated = 3,
			UnauthorizedCreate = 4
		}

		private enum ModifyEntityError
		{
			None = 0,
			EntityNotFound = 1,
			EntityNotOwned = 2,
			EntityWasDestroyed = 3
		}

		private enum RemoveComponentError
		{
			None = 0,
			EntityNotFound = 1,
			MissingComponent = 2,
			OrderedComponent = 3,
			InvalidComponent = 4
		}

		public static readonly float WorldPositionMaxRange;

		private IExtendedDefinition root;

		private EntityIDGenerator entityIDGenerator;

		private IRequestManager requestManager;

		private OrphanRefs orphanRefs;

		private Dictionary<Entity, EntityMeta> metas;

		private Dictionary<Entity, ComponentData> componentData;

		private Dictionary<string, Entity> uniqueEntities;

		private Dictionary<Entity, DestroyInfo> destroyedEntities;

		private readonly CacheList<KeyValuePair<Entity, DestroyInfo>> destroyedEntitiesToRemove;

		private readonly ListPool<IRequest> requestBufferPool;

		private readonly CacheList<IRequest> commandRequestsCache;

		private readonly CacheList<Entity> entitiesToCheck;

		private readonly CacheList<Entity> childrenToDestroy;

		private Dictionary<Entity, HashSet<Entity>> parentToChild;

		private Dictionary<uint, ParticipantInfo> participants;

		private Dictionary<ClientID, ParticipantInfo> participantsByClientID;

		private TagIndex tagIndex;

		private SpatialIndex spatialIndex;

		private readonly TimeSpan DestroyCacheTTL;

		private Coherence.Log.Logger logger;

		private readonly List<UpdateComponentsRequest> orphanUpdatesBuffer;

		private readonly Stack<Entity> populateWithChildrenStack;

		private readonly HostAuthority hostAuthFeatures;

		public EntityIDGenerator EntityIDGenerator => null;

		public IRequestManager RequestManager()
		{
			return null;
		}

		public EntityManager(IExtendedDefinition root, HostAuthority hostAuthority, Coherence.Log.Logger logger, ushort maxEntities = 65534)
		{
		}

		public void Dispose()
		{
		}

		public void OnParticipantJoin(ParticipantInfo info, List<ResponseInfo> responses, List<IClientMessage> generatedMessages)
		{
		}

		public void OnParticipantLeave(uint participant, List<ResponseInfo> responses, List<IClientMessage> generatedMessages)
		{
		}

		public void HandleEntityRequests(List<IBaseRequest> requests, List<ResponseInfo> responses, List<CommandResponse> commandResponses, List<IClientMessage> generatedMessages)
		{
		}

		public QueryResponse HandleClientQuery(ClientQuery clientQuery)
		{
			return default(QueryResponse);
		}

		private void UpdateDestroyCache()
		{
		}

		private void HandleGlobalQuery(HashSet<Entity> entities)
		{
		}

		private void HandlePositionQuery(PositionQuery query, HashSet<Entity> entities)
		{
		}

		private void HandleParentChainQuery(ParentChainQuery query, HashSet<Entity> entities)
		{
		}

		private void HandleTagQuery(TagQuery query, HashSet<Entity> entities)
		{
		}

		private void PopulateWithChildren(Entity parent, HashSet<Entity> entities)
		{
		}

		private void HandleInput(IEntityMessage input, List<CommandResponse> responses)
		{
		}

		private void ProcessFailedAuthorityTransfer(uint sender, Entity entity, AuthorityType authType, EntityMeta meta, string reason, CommandStatus status, List<CommandResponse> responses, LogLevel logLevel = LogLevel.Warning)
		{
		}

		private void ProcessAuthorityRequest(IEntityMessage command, List<CommandResponse> commandResponses, List<IClientMessage> generatedMessages)
		{
		}

		private void ProcessAuthorityTransfer(IEntityMessage command, List<CommandResponse> commandResponses, List<IClientMessage> generatedMessages, List<IRequest> generatedRequests)
		{
		}

		private void HandleTransferToDisconnectedClient(Entity entity, EntityMeta meta, uint participant, List<IRequest> generatedRequests)
		{
		}

		private bool InSameScene(EntityMeta meta, uint participant)
		{
			return false;
		}

		private void ProcessAdoptingOrphan(IEntityMessage command, List<CommandResponse> commandResponses, List<IClientMessage> generatedMessages, List<IRequest> generatedRequests)
		{
		}

		private bool HandleInternalCommand(IEntityMessage command, List<CommandResponse> commandResponses, List<IClientMessage> generatedMessages, List<IRequest> generatedRequests)
		{
			return false;
		}

		private void HandleUserCommand(IEntityMessage command, List<CommandResponse> responses)
		{
		}

		private void HandleCommand(IEntityMessage command, List<CommandResponse> commandResponses, List<IClientMessage> generatedMessages, List<ResponseInfo> responses)
		{
		}

		private void HandleRequest(IRequest request, List<ResponseInfo> responses, List<IClientMessage> generatedMessages)
		{
		}

		private ModifyEntityError CanModifyEntity(Entity entity, uint participant, RequestMode requestMode)
		{
			return default(ModifyEntityError);
		}

		private StandardError HandleUpdateCantModifyError(ModifyEntityError error, IRequest request, DateTime now)
		{
			return default(StandardError);
		}

		private bool IsCyclic(Entity parent, Entity child)
		{
			return false;
		}

		private bool DetectCyclicHierarchy(Entity entity, ICoherenceComponentData[] comps)
		{
			return false;
		}

		private RemoveComponentError ValidateRemoveRequest(RemoveComponentsRequest request)
		{
			return default(RemoveComponentError);
		}

		private void RemoveComponents(Entity entity, ref EntityMeta meta, IReadOnlyList<uint> compTypes)
		{
		}

		private StandardError ProcessComponentRemove(RemoveComponentsRequest request, DateTime now, List<ResponseInfo> responses)
		{
			return default(StandardError);
		}

		private StandardError ProcessComponentUpdate(UpdateComponentsRequest request, DateTime now, List<ResponseInfo> responses, List<IRequest> generatedRequests, List<IClientMessage> generatedMessages)
		{
			return default(StandardError);
		}

		private ModifyEntityError CanDestroyEntity(uint participant, Entity entity, bool isInternal)
		{
			return default(ModifyEntityError);
		}

		private StandardError ProcessDestroy(DestroyEntityRequest request, DateTime now, List<ResponseInfo> responses)
		{
			return default(StandardError);
		}

		private void DestroyEntitiesForParticipant(uint participant, List<Entity> entities, List<ResponseInfo> responses, List<IRequest> generatedRequests)
		{
		}

		private void ApplyEntityOrphaning(Entity entity, List<IRequest> generatedRequests)
		{
		}

		private void SendAuthorityChangeMessages(Entity entity, AuthorityType authorityType, EntityMeta meta, uint origin, uint sender, List<IClientMessage> generatedMessages)
		{
		}

		private void TransferEntityAuthority(Entity entity, uint origin, uint sender, uint newAuthority, AuthorityType authorityType, EntityMeta meta, List<IClientMessage> generatedMessages, List<IRequest> generatedRequests)
		{
		}

		private void DestroyAllEntitiesForParticipant(uint participant, List<ResponseInfo> responses, List<IClientMessage> generatedMessages, List<IRequest> generatedRequests)
		{
		}

		private CreateRequestError ValidateCreateRequest(CreateEntityRequest request)
		{
			return default(CreateRequestError);
		}

		private bool IsClientConnectionEntity(Entity entity, ICoherenceComponentData[] comps)
		{
			return false;
		}

		private StandardError UpdateConnectionScene(Entity entity, ICoherenceComponentData[] comps, uint participant, List<ResponseInfo> responses, List<IRequest> generatedRequests, List<IClientMessage> generatedMessages)
		{
			return default(StandardError);
		}

		private bool IsUnauthorizedConnectionUpdate(bool isInternalRequest, ICoherenceComponentData[] comps)
		{
			return false;
		}

		private bool IsUnauthorizedConnectionUpdate(bool isInternalRequest, bool hasConnectionComponent)
		{
			return false;
		}

		private void ApplyFloatingOriginToWorldPositionQueryComponent(ref ICoherenceComponentData[] comps, FloatingOrigin origin)
		{
		}

		private void ApplyFloatingOriginToWorldPositionComponent(Entity entity, ref ICoherenceComponentData[] comps, FloatingOrigin origin)
		{
		}

		private bool IsEntityAChild(Entity entity, ICoherenceComponentData[] comps)
		{
			return false;
		}

		private void ApplyFloatingOriginToComponents(Entity entity, ref ICoherenceComponentData[] comps, FloatingOrigin origin)
		{
		}

		private bool IsDuplicate(ICoherenceComponentData[] comps, out Entity owner, out string UUID)
		{
			owner = default(Entity);
			UUID = null;
			return false;
		}

		private StandardError ResolveDuplicate(CreateEntityRequest request, Entity owner, string UUID, List<ResponseInfo> responses)
		{
			return default(StandardError);
		}

		private void DestroyUniqueComp(ICoherenceComponentData[] comps)
		{
		}

		private Vector3d GetWorldPosition(Entity entity)
		{
			return default(Vector3d);
		}

		private Quaternion GetWorldRotation(Entity entity)
		{
			return default(Quaternion);
		}

		private void UpdateChildrenOfDeletedParent(Entity parent, uint participant, AbsoluteSimulationFrame simFrame, List<ResponseInfo> responses)
		{
		}

		private void DeleteChildrenRecursively(Entity entity, uint participant, DestroyReason reason, List<ResponseInfo> responses)
		{
		}

		private void PerformDestroyChildren(Entity entity, EntityMeta meta, uint participant, DestroyReason reason, AbsoluteSimulationFrame simFrame, List<ResponseInfo> responses)
		{
		}

		private void PerformDestroy(Entity entity, uint participant, DestroyReason reason, List<ResponseInfo> responses)
		{
		}

		private void UpdateConnectedEntity(Entity entity, ref EntityMeta meta, ref ICoherenceComponentData[] comps)
		{
		}

		private void RemoveConnectedEntity(Entity entity, ref EntityMeta meta)
		{
		}

		private void UpdateWorldPosition(Entity entity, ref EntityMeta meta, ref ICoherenceComponentData[] comps)
		{
		}

		private void RemoveWorldPosition(Entity entity, ref EntityMeta meta)
		{
		}

		private void UpdateUniqueID(Entity entity, ref EntityMeta meta, ref ICoherenceComponentData[] comps)
		{
		}

		private void RemoveUniqueID(Entity entity, ref EntityMeta meta)
		{
		}

		private void UpdatePersistence(ref EntityMeta meta, ref ICoherenceComponentData[] comps)
		{
		}

		private void RemovePersistence(Entity entity, ref EntityMeta meta)
		{
		}

		private void UpdateArchetype(ref EntityMeta meta, ref ICoherenceComponentData[] comps)
		{
		}

		private void UpdateGlobal(ref EntityMeta meta, ICoherenceComponentData[] comps)
		{
		}

		private void RemoveGlobal(Entity entity, ref EntityMeta meta)
		{
		}

		private void UpdateTag(Entity entity, ref EntityMeta meta, ref ICoherenceComponentData[] comps)
		{
		}

		private void RemoveTag(Entity entity, ref EntityMeta meta)
		{
		}

		private void UpdatePreserveChildren(ref EntityMeta meta, ref ICoherenceComponentData[] comps)
		{
		}

		private void UpdateComponents(Entity entity, ref EntityMeta meta, ref ICoherenceComponentData[] comps)
		{
		}

		private void UpdateSpatialIndex(Entity entity, EntityMeta meta, bool wasIndexed, Vector3d oldPosition)
		{
		}

		private void SetScene(Entity entity, ref EntityMeta meta, uint scene, uint participant, List<IRequest> generatedRequests)
		{
		}

		private StandardError SetSceneForCreatedEntity(uint participant, Entity createdEntity, ref EntityMeta meta, ICoherenceComponentData[] comps, List<IRequest> generatedRequests)
		{
			return default(StandardError);
		}

		private StandardError ProcessCreateRequest(CreateEntityRequest request, List<ResponseInfo> responses, List<IRequest> generatedRequests, List<IClientMessage> generatedMessages)
		{
			return default(StandardError);
		}

		public bool EntityExists_Test(Entity entity)
		{
			return false;
		}

		public EntityMeta GetEntityMeta_Test(Entity entity)
		{
			return default(EntityMeta);
		}

		public ComponentData GetEntityComponentData_Test(Entity entity)
		{
			return null;
		}
	}
}
