using System;
using System.Collections.Generic;
using Coherence.Common;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Core
{
	internal class ReceiveChangeBuffer
	{
		public static readonly TimeSpan MessageTTL;

		private readonly Dictionary<Entity, IncomingEntityUpdate> entityDataByID;

		private readonly List<ExpirableMessage> commands;

		private readonly List<ExpirableMessage> inputs;

		private readonly List<Entity> entitiesTaken;

		private readonly List<RefsInfo> refsToResolve;

		private readonly IEntityRegistry entityRegistry;

		private readonly IDateTimeProvider dateTimeProvider;

		private readonly Logger logger;

		public ReceiveChangeBuffer(IEntityRegistry entityRegistry, Logger logger, IDateTimeProvider dateTimeProvider = null)
		{
		}

		public void Clear()
		{
		}

		public void AddChange(in IncomingEntityUpdate change)
		{
		}

		public void AddCommand(IEntityMessage command)
		{
		}

		public void AddInput(IEntityMessage input)
		{
		}

		public List<RefsInfo> GetRefsInfos()
		{
			return null;
		}

		public void TakeUpdates(List<IncomingEntityUpdate> buffer, IReadOnlyCollection<Entity> resolvableEntities)
		{
		}

		private static void SortChanges(List<IncomingEntityUpdate> buff)
		{
		}

		private static int GetOperationPriority(EntityOperation operation)
		{
			return 0;
		}

		private static int GetNumberOfRefs(IncomingEntityUpdate update)
		{
			return 0;
		}

		public void TakeCommands(List<IEntityMessage> buffer, IReadOnlyCollection<Entity> resolvableEntities)
		{
		}

		public void TakeInputs(List<IEntityMessage> buffer, IReadOnlyCollection<Entity> resolvableEntities)
		{
		}

		private void TakeMessages(List<IEntityMessage> buffer, List<ExpirableMessage> source, IReadOnlyCollection<Entity> resolvableEntities)
		{
		}

		private bool IsMessageResolvable(IEntityMessage message, IReadOnlyCollection<Entity> resolvableEntities)
		{
			return false;
		}

		private bool IsPartialUpdate(in IncomingEntityUpdate update)
		{
			return false;
		}

		private bool HandleDestroy(in IncomingEntityUpdate data, List<IncomingEntityUpdate> changes)
		{
			return false;
		}

		private void HandleMessagesReferencingDestroyedEntity(in Entity entity, List<ExpirableMessage> messages)
		{
		}
	}
}
