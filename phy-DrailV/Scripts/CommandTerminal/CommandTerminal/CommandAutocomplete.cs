using System.Collections.Generic;

namespace CommandTerminal
{
	public class CommandAutocomplete
	{
		private Dictionary<string, CommandInfo> known_words = new Dictionary<string, CommandInfo>();

		private List<string> buffer = new List<string>();

		public string lastInput;

		private string[] lastResults;

		private int lastIndex;

		public void Register(CommandInfo command)
		{
			known_words.Add(command.name.ToLower(), command);
		}

		public (string[] all, int index) Complete(string inputText, bool backwards = false)
		{
			inputText = inputText.ToLower();
			if (inputText != lastInput)
			{
				lastIndex = 0;
				lastInput = inputText;
				foreach (KeyValuePair<string, CommandInfo> known_word in known_words)
				{
					if (known_word.Key.Contains(inputText))
					{
						buffer.Add(known_word.Value.name);
					}
				}
				buffer.Sort(Comparator);
				lastResults = buffer.ToArray();
				buffer.Clear();
			}
			else
			{
				lastIndex += ((!backwards) ? 1 : (-1));
				if (lastIndex < 0)
				{
					lastIndex = lastResults.Length - 1;
				}
				else if (lastIndex >= lastResults.Length)
				{
					lastIndex = 0;
				}
			}
			return (all: lastResults, index: lastIndex);
		}

		private int Comparator(string x, string y)
		{
			return x.ToLower().IndexOf(lastInput) - y.ToLower().IndexOf(lastInput);
		}
	}
}
