using System.Collections.Generic;
using Coherence.Entities;
using Coherence.Log;

namespace Coherence.RSL.EntityManager.Requests
{
	public class RequestManager : IRequestManager
	{
		private Logger logger;

		public RequestManager(Logger logger)
		{
		}

		public CreateEntityRequest NewCreateEntityRequest(Entity entity, uint participant, ICoherenceComponentData[] comps, bool isInternal)
		{
			return null;
		}

		public UpdateComponentsRequest NewUpdateComponentsRequest(Entity entity, uint participant, ICoherenceComponentData[] comps, bool isInternal)
		{
			return null;
		}

		public DestroyEntityRequest NewDestroyEntityRequest(Entity entity, uint participant, DestroyReason reason, bool isInternal)
		{
			return null;
		}

		public ClientSwitchedSceneRequest NewClientSwitchedSceneRequest(Entity entity, uint participant, uint oldScene, uint newScene, bool isInternal)
		{
			return null;
		}

		public RemoveComponentsRequest NewRemoveComponentsRequest(Entity entity, uint participant, IReadOnlyList<uint> compTypes, bool isInternal)
		{
			return null;
		}
	}
}
