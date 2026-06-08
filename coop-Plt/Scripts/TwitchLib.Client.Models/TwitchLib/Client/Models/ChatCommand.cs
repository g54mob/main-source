using System.Collections.Generic;
using System.Linq;
using TwitchLib.Client.Models.Common;

namespace TwitchLib.Client.Models
{
	public class ChatCommand
	{
		public List<string> ArgumentsAsList { get; }

		public string ArgumentsAsString { get; }

		public ChatMessage ChatMessage { get; }

		public char CommandIdentifier { get; }

		public string CommandText { get; }

		public ChatCommand(ChatMessage chatMessage)
		{
			ChatCommand chatCommand = this;
			ChatMessage = chatMessage;
			string[] array = chatMessage.Message.Split(' ');
			CommandText = ((array != null) ? array[0].Substring(1, chatMessage.Message.Split(' ')[0].Length - 1) : null) ?? chatMessage.Message.Substring(1, chatMessage.Message.Length - 1);
			object obj;
			if (!chatMessage.Message.Contains(" "))
			{
				obj = "";
			}
			else
			{
				string message = chatMessage.Message;
				string[] array2 = chatMessage.Message.Split(' ');
				obj = message.Replace(((array2 != null) ? array2[0] : null) + " ", "");
			}
			ArgumentsAsString = (string)obj;
			if (!chatMessage.Message.Contains("\"") || chatMessage.Message.Count((char x) => x == '"') % 2 == 1)
			{
				ArgumentsAsList = chatMessage.Message.Split(' ')?.Where((string arg) => arg != chatMessage.Message[0] + chatCommand.CommandText).ToList() ?? new List<string>();
			}
			else
			{
				ArgumentsAsList = Helpers.ParseQuotesAndNonQuotes(ArgumentsAsString);
			}
			CommandIdentifier = chatMessage.Message[0];
		}

		public ChatCommand(ChatMessage chatMessage, string commandText, string argumentsAsString, List<string> argumentsAsList, char commandIdentifier)
		{
			ChatMessage = chatMessage;
			CommandText = commandText;
			ArgumentsAsString = argumentsAsString;
			ArgumentsAsList = argumentsAsList;
			CommandIdentifier = commandIdentifier;
		}
	}
}
