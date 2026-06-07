using System;

namespace GameCreator.Runtime.Console
{
	public class Output
	{
		private const string ERR_HELP = "Type 'help' to see a list of all available commands.";

		[field: NonSerialized]
		public bool IsError { get; }

		[field: NonSerialized]
		public string Text { get; }

		private Output(bool isError, string text)
		{
			IsError = isError;
			Text = text;
		}

		public static Output Error(string error, bool showHelp = false)
		{
			if (!showHelp)
			{
				return new Output(isError: true, error + ".");
			}
			return new Output(isError: true, error + ". Type 'help' to see a list of all available commands.");
		}

		public static Output Success(string text)
		{
			return new Output(isError: false, text);
		}

		public override string ToString()
		{
			return Text;
		}
	}
}
