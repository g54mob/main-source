using System.Collections.Generic;

namespace NSMedieval
{
	public class MessagesHolder
	{
		private List<string> messages;

		private bool allowDuplicates;

		public MessagesHolder(bool allowDuplicates)
		{
			messages = new List<string>();
			this.allowDuplicates = allowDuplicates;
		}

		public void PushMessage(string message)
		{
			if (allowDuplicates || !messages.Contains(message))
			{
				messages.Add(message);
			}
		}

		public List<string> GetMessages()
		{
			return messages;
		}

		public void Clear()
		{
			messages.Clear();
		}
	}
}
