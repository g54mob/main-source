using System.Collections.Generic;
using Coherence.Brook;

namespace Coherence.Serializer
{
	public static class MessageQueueSerializer
	{
		private const uint MessageTypeBitCount = 8u;

		private const uint MessageCountBitCount = 8u;

		private const uint MessageHeaderBitCount = 16u;

		private const int MaxMessageCount = 255;

		public static (int, uint) GetCountFromBudget(Queue<SerializedEntityMessage> messages, uint maxBudget, bool useDebugStreams)
		{
			return default((int, uint));
		}

		public static void SerializeQueue(List<SerializedEntityMessage> serializedMessagesBuffer, MessageType messageType, SerializerContext<IOutBitStream> ctx, Queue<SerializedEntityMessage> messages, uint bitBudget)
		{
		}
	}
}
