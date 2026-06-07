using System.Collections.Generic;
using Coherence.Entities;
using Coherence.RSL.EntityManager.Requests;

namespace Coherence.RSL.ReplicationManager.InBuffer
{
	public struct IncomingEntityChange
	{
		private CreateEntityRequest create;

		private UpdateComponentsRequest updateComponents;

		private RemoveComponentsRequest removeComponents;

		private DestroyEntityRequest destroy;

		private ushort priority;

		public Entity GetEntity()
		{
			return default(Entity);
		}

		public ushort GetPriority()
		{
			return 0;
		}

		public bool HasCreate()
		{
			return false;
		}

		public CreateEntityRequest GetCreate()
		{
			return null;
		}

		public bool HasDestroy()
		{
			return false;
		}

		public DestroyEntityRequest GetDestroy()
		{
			return null;
		}

		public void DeletePendingRemoves(uint[] compTypes)
		{
		}

		public void ProcessCreateRequest(CreateEntityRequest req)
		{
		}

		public void ProcessUpdateRequest(UpdateComponentsRequest req)
		{
		}

		public void ProcessRemoveRequest(RemoveComponentsRequest req)
		{
		}

		public void ProcessChange(IRequest req)
		{
		}

		public List<IRequest> GetChanges()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
