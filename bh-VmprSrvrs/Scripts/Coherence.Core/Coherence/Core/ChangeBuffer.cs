using System.Collections.Generic;
using Coherence.Brook;
using Coherence.Entities;
using Coherence.Log;
using Coherence.Serializer;

namespace Coherence.Core
{
	internal class ChangeBuffer
	{
		public readonly Dictionary<Entity, OutgoingEntityUpdate> Buffer;

		public readonly Queue<SerializedEntityMessage> commandBuffer;

		public readonly Queue<SerializedEntityMessage> inputBuffer;

		public readonly SequenceId sequenceID;

		protected Logger logger;

		public ChangeBuffer(Dictionary<Entity, OutgoingEntityUpdate> buffer, Queue<SerializedEntityMessage> commands, Queue<SerializedEntityMessage> inputs, SequenceId id, Logger logger)
		{
		}

		public bool HasMessages()
		{
			return false;
		}

		public void ReprioritizeChanges(int priority)
		{
		}

		public void ClearAllChangesForEntity(Entity id)
		{
		}

		public bool HasChangesForEntity(Entity id)
		{
			return false;
		}

		public void ClearComponentChangesForEntity(Entity id, uint componentID)
		{
		}

		public bool HasComponentChangesForEntity(Entity id, uint componentID)
		{
			return false;
		}

		public void MergeIfOrderedComponents(Entity entity, ref DeltaComponents components, IComponentInfo componentInfo)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
