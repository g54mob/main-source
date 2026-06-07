using System.Collections.Generic;
using Coherence.Common.Pooling;
using Coherence.Serializer;

namespace Coherence.RSL.ReplicationManager.OutBuffer
{
	public class MessageBuffer
	{
		private readonly Queue<SerializedEntityMessage> messages;

		private readonly Queue<List<SerializedEntityMessage>> sent;

		private readonly ListPool<SerializedEntityMessage> sentPool;

		public Queue<SerializedEntityMessage> Messages => null;

		public int Count()
		{
			return 0;
		}

		public void AddMessage(SerializedEntityMessage message)
		{
		}

		public void MarkAsSent(IReadOnlyList<SerializedEntityMessage> sentList)
		{
		}

		public void MarkAsLost()
		{
		}

		public void MarkAsReceived()
		{
		}
	}
}
