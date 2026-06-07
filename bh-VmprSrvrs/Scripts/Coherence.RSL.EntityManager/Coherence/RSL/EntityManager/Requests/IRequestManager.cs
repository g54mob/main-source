using System.Collections.Generic;
using Coherence.Entities;

namespace Coherence.RSL.EntityManager.Requests
{
	public interface IRequestManager
	{
		CreateEntityRequest NewCreateEntityRequest(Entity entity, uint participant, ICoherenceComponentData[] comps, bool isInternal);

		UpdateComponentsRequest NewUpdateComponentsRequest(Entity entity, uint participant, ICoherenceComponentData[] comps, bool isInternal);

		DestroyEntityRequest NewDestroyEntityRequest(Entity entity, uint participant, DestroyReason reason, bool isInternal);

		ClientSwitchedSceneRequest NewClientSwitchedSceneRequest(Entity entity, uint participant, uint oldScene, uint newScene, bool isInternal);

		RemoveComponentsRequest NewRemoveComponentsRequest(Entity entity, uint participant, IReadOnlyList<uint> comps, bool isInternal);
	}
}
