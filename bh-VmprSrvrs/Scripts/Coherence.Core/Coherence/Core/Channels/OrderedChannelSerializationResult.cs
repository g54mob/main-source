using System.Collections.Generic;
using Coherence.Brook;

namespace Coherence.Core.Channels
{
	internal class OrderedChannelSerializationResult
	{
		public List<MessageID> MessagesSent;

		public void Clear()
		{
		}
	}
}
