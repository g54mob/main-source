using System.Collections.Generic;
using Coherence.Brook;
using Coherence.ProtocolDef;

namespace Coherence.Core
{
	internal class ReceiveSequenceBuffer : SequenceBuffer<IEntityMessage>
	{
		private MessageID nextID;

		public ReceiveSequenceBuffer(int size)
			: base(0)
		{
		}

		public bool InsertMessage(MessageID id, IEntityMessage message)
		{
			return false;
		}

		public void FlushMessages(List<IEntityMessage> messages)
		{
		}

		public void Clear()
		{
		}

		private bool IsOldMessage(MessageID id)
		{
			return false;
		}

		public bool IsSequenceReady()
		{
			return false;
		}
	}
}
