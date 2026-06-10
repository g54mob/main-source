using System;

namespace ModIO.Implementation.Wss.Messages
{
	[Serializable]
	internal struct WssMessages
	{
		public WssMessage[] messages;

		public WssMessages(params WssMessage[] messages)
		{
			this.messages = null;
		}
	}
}
