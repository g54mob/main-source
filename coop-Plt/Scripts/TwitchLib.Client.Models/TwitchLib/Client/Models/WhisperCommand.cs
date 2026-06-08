using System.Collections.Generic;
using System.Linq;

namespace TwitchLib.Client.Models
{
	public class WhisperCommand
	{
		public List<string> ArgumentsAsList { get; }

		public string ArgumentsAsString { get; }

		public char CommandIdentifier { get; }

		public string CommandText { get; }

		public WhisperMessage WhisperMessage { get; }

		public WhisperCommand(WhisperMessage whisperMessage)
		{
			WhisperCommand whisperCommand = this;
			WhisperMessage = whisperMessage;
			string[] array = whisperMessage.Message.Split(' ');
			CommandText = ((array != null) ? array[0].Substring(1, whisperMessage.Message.Split(' ')[0].Length - 1) : null) ?? whisperMessage.Message.Substring(1, whisperMessage.Message.Length - 1);
			string message = whisperMessage.Message;
			string[] array2 = whisperMessage.Message.Split(' ');
			ArgumentsAsString = message.Replace(((array2 != null) ? array2[0] : null) + " ", "");
			ArgumentsAsList = whisperMessage.Message.Split(' ')?.Where((string arg) => arg != whisperMessage.Message[0] + whisperCommand.CommandText).ToList() ?? new List<string>();
			CommandIdentifier = whisperMessage.Message[0];
		}

		public WhisperCommand(WhisperMessage whisperMessage, string commandText, string argumentsAsString, List<string> argumentsAsList, char commandIdentifier)
		{
			WhisperMessage = whisperMessage;
			CommandText = commandText;
			ArgumentsAsString = argumentsAsString;
			ArgumentsAsList = argumentsAsList;
			CommandIdentifier = commandIdentifier;
		}
	}
}
