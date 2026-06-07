using Coherence.Connection;
using Coherence.Entities;
using Coherence.ProtocolDef;
using Coherence.SimulationFrame;
using UnityEngine;

namespace Coherence
{
	public interface IExtendedDefinition : IDefinition, ISchemaSpecificComponentDeserialize, ISchemaSpecificComponentSerialize, IAuthorityManagement, IBuiltInComponentAccess, IComponentInfo
	{
		string SchemaHash();

		ICoherenceComponentData CreateArchetypeComponent(uint index);

		ICoherenceComponentData CreateConnectedEntityComponent(Entity parent, Vector3 relativePos, Quaternion relativeRot, Vector3 scale);

		ICoherenceComponentData CreateConnectionComponent(ClientID clientID, ConnectionType connectionType);

		ICoherenceComponentData CreateConnectionSceneComponent(uint scene);

		ICoherenceComponentData CreateGlobalQueryComponent();

		ICoherenceComponentData CreatePersistenceComponent();

		ICoherenceComponentData CreatePreserveChildrenComponent();

		ICoherenceComponentData CreateSceneComponent(uint scene);

		ICoherenceComponentData CreateTagComponent(string tag);

		ICoherenceComponentData CreateTagQueryComponent(string tag);

		ICoherenceComponentData CreateUUIDComponent(string UUID);

		ICoherenceComponentData CreateWorldPositionComponent(Vector3 pos, AbsoluteSimulationFrame simFrame);

		ICoherenceComponentData CreateWorldRotationComponent(Quaternion rot, AbsoluteSimulationFrame simFrame);

		ICoherenceComponentData CreateWorldPositionQueryComponent(Vector3 center, float radius);

		bool IsAdoptOrphanCommand(uint compType);

		bool IsAuthorityRequestCommand(uint compType);

		bool IsAuthorityTransferCommand(uint compType);

		bool IsPersistenceReadyCommand(uint compType);

		bool CanRouteCommand(uint compType, MessageTarget target);

		bool IsConnectedEntityComponent(uint compType);

		bool IsConnectionComponent(uint compType);

		bool IsGlobalComponent(uint compType);

		bool IsGlobalQueryComponent(uint compType);

		bool IsPersistenceComponent(uint compType);

		bool IsSceneComponent(uint compType);

		bool IsTagComponent(uint compType);

		bool IsTagQueryComponent(uint compType);

		bool IsUUIDComponent(uint compType);

		bool IsWorldPositionComponent(uint compType);

		bool IsWorldPositionQueryComponent(uint compType);

		IEntityCommand CreateQuerySyncedCommand(Entity entity, bool liveQuerySynced, bool globalQuerySynced);

		AuthorityType GetAuthorityTypeFromAuthorityRequestCommand(IEntityCommand command);

		AuthorityType GetAuthorityTypeFromAuthorityTransferCommand(IEntityCommand command);

		ClientID GetAuthorityRequesterFromCommand(IEntityCommand command);

		ClientID GetNewAuthorityFromAuthorityTransferCommmand(IEntityCommand command);

		bool GetIsAcceptedFromAuthorityTransferCommand(IEntityCommand command);

		ICoherenceComponentData GetArchetypeComponent(ICoherenceComponentData[] comps);

		int GetArchetypeIndexFromComponent(ICoherenceComponentData comp);

		ICoherenceComponentData GetConnectedEntityComponent(ICoherenceComponentData[] comps);

		Entity GetConnectedEntityFromConnectedEntityComponent(ICoherenceComponentData comp);

		Vector3 GetRelativePosFromConnectedEntityComponent(ICoherenceComponentData comp);

		Quaternion GetRelativeRotFromConnectedEntityComponent(ICoherenceComponentData comp);

		ICoherenceComponentData GetConnectionComponent(ICoherenceComponentData[] comps);

		ICoherenceComponentData GetConnectionSceneComponent(ICoherenceComponentData[] comps);

		uint GetConnectionSceneFromComponent(ICoherenceComponentData comp);

		ICoherenceComponentData GetGlobalComponent(ICoherenceComponentData[] comps);

		ICoherenceComponentData GetGlobalQueryComponent(ICoherenceComponentData[] comps);

		ICoherenceComponentData GetPersistenceComponent(ICoherenceComponentData[] comps);

		ICoherenceComponentData GetPreserveChildrenComponent(ICoherenceComponentData[] comps);

		ICoherenceComponentData GetSceneComponent(ICoherenceComponentData[] comps);

		uint GetSceneFromComponent(ICoherenceComponentData comp);

		ICoherenceComponentData GetTagComponent(ICoherenceComponentData[] comps);

		ICoherenceComponentData GetTagQueryComponent(ICoherenceComponentData[] comps);

		string GetTagFromTagComponent(ICoherenceComponentData comp);

		string GetTagFromTagQueryComponent(ICoherenceComponentData comp);

		ICoherenceComponentData GetUUIDComponent(ICoherenceComponentData[] comps);

		string GetUUIDFromComponent(ICoherenceComponentData comp);

		(ICoherenceComponentData, int) GetWorldPositionComponent(ICoherenceComponentData[] comps);

		Vector3 GetWorldPositionFromComponent(ICoherenceComponentData comp);

		void SetWorldPosition(ref ICoherenceComponentData comp, Vector3 newPosition);

		(ICoherenceComponentData, int) GetWorldRotationComponent(ICoherenceComponentData[] comps);

		Quaternion GetWorldRotationFromComponent(ICoherenceComponentData comp);

		void SetWorldRotation(ref ICoherenceComponentData comp, Quaternion newRotation);

		(ICoherenceComponentData, int) GetWorldPositionQueryComponent(ICoherenceComponentData[] comps);

		Vector3 GetWorldPositionQueryCenterFromComponent(ICoherenceComponentData comp);

		float GetWorldPositionQueryRadiusFromComponent(ICoherenceComponentData comp);

		void SetWorldPositionQueryCenter(ref ICoherenceComponentData comp, Vector3 newCenter);

		void RemoveComponentsInvalidatedByConnectedEntity(ref ICoherenceComponentData[] comps);

		bool HasValidConnectedEntityID(ICoherenceComponentData comp);

		bool HasValidConnectionScene(ICoherenceComponentData comp);

		bool HasValidWorldPositionQueryCenter(ICoherenceComponentData comp);

		bool HasValidWorldPositionQueryRadius(ICoherenceComponentData comp);

		bool HasValidWorldPositionPosition(ICoherenceComponentData comp);

		bool HasValidUniqueIDUUID(ICoherenceComponentData comp);

		bool HasValidArchetypeIndex(ICoherenceComponentData comp);

		bool HasValidTagQueryTag(ICoherenceComponentData comp);

		bool HasValidTagTag(ICoherenceComponentData comp);

		uint GetArchetypeIndexByName(string name);

		bool GetEntityArchetype(uint index, out EntityArchetype archetype);
	}
}
