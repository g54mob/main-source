using System.Collections.Generic;
using Coherence.Brook;
using Coherence.Serializer;

namespace Coherence.Core
{
	internal class SendSequenceBuffer : SequenceBuffer<SendSequenceBufferEntry>
	{
		private MessageID currentID;

		private MessageID nextAckID;

		public SendSequenceBuffer(int size)
			: base(0)
		{
		}

		public bool AppendMessage(SerializedEntityMessage message)
		{
			return false;
		}

		public void OnMessagesDelivered(IReadOnlyList<MessageID> messageIDs, bool wasDelivered)
		{
		}

		public void OnMessagesSent(List<MessageID> messageIDs)
		{
		}

		public void GetMessagesToSend(List<(MessageID ID, SerializedEntityMessage Message)> messages)
		{
		}

		public bool IsFull()
		{
			return false;
		}

		public bool IsEmpty()
		{
			return false;
		}

		public void Clear()
		{
		}
	}
}
