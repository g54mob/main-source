using System.Collections.Generic;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.RSL.EntityManager.Requests;

namespace Coherence.RSL.ReplicationManager.InBuffer
{
	public class InBuffer
	{
		private struct Cache
		{
			public List<RefsInfo> RefsToResolve;

			public List<IEntityMessage> HeldMessages;

			public static Cache New()
			{
				return default(Cache);
			}

			public void Flush()
			{
			}
		}

		private struct DeferredChange
		{
			public Entity Entity;

			public List<IRequest> Changes;
		}

		private IEntityMapper mapper;

		private Dictionary<Entity, IncomingEntityChange> changeBuffer;

		private List<IEntityMessage> commands;

		private List<IEntityMessage> inputs;

		private List<InternalDestroy> internalDestroys;

		private Logger logger;

		private Cache cache;

		public InBuffer(IEntityMapper mapper, Logger logger)
		{
		}

		public void AddChange(IRequest req)
		{
		}

		public void AddCommand(IEntityMessage command)
		{
		}

		public void AddInput(IEntityMessage input)
		{
		}

		public bool HasNothingToProcess()
		{
			return false;
		}

		public List<RefsInfo> GetRefsInfos()
		{
			return null;
		}

		public IEntityMapper.Error MapResolvableEntities(List<Entity> resolvableEntities)
		{
			return default(IEntityMapper.Error);
		}

		public List<IRequest> TakeChanges(List<Entity> resolvableEntities)
		{
			return null;
		}

		public List<IEntityMessage> TakeInputs()
		{
			return null;
		}

		public List<IEntityMessage> TakeCommands()
		{
			return null;
		}

		public void TakeInternalDestroys(List<InternalDestroy> destroyBuffer)
		{
		}

		private void MapAndAppend(List<IRequest> changeBuffer, IReadOnlyList<IRequest> changesToMap)
		{
		}

		private bool HandleDestroy(List<IRequest> requests, IncomingEntityChange aggregateChange)
		{
			return false;
		}

		private bool IsPartialUpdate(IncomingEntityChange aggregateChange)
		{
			return false;
		}

		private ChangeList GetSortedChangeList()
		{
			return null;
		}

		private List<IEntityMessage> HandleMessagesReferencingDestroyedEntity(Entity entity, List<IEntityMessage> messages)
		{
			return null;
		}

		private List<IEntityMessage> TakeMessages(List<IEntityMessage> messageBuffer)
		{
			return null;
		}

		private bool HasReferences(IReadOnlyList<IRequest> changes)
		{
			return false;
		}
	}
}
