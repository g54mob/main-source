using System.Collections.Generic;

namespace OUSystems.Cheats.Commands
{
	public class CommandDirectory
	{
		public Dictionary<string, CommandDirectory> Directories;

		public Dictionary<string, DevCommand> Commands;

		private bool ContainsChildCommand(string name)
		{
			return false;
		}

		private bool ContainsChildDirectory(string name)
		{
			return false;
		}

		public DevCommand GetChildCommand(string commandName)
		{
			return null;
		}

		private bool GetChildDirectory(string name, out CommandDirectory directory, bool createIfMissing = false)
		{
			directory = null;
			return false;
		}

		private bool GetPathParts(string path, out string first, out string rest)
		{
			first = null;
			rest = null;
			return false;
		}

		public bool CreateDirectory(string path)
		{
			return false;
		}

		public bool AddCommand(DevCommand command, string path)
		{
			return false;
		}

		public bool NameExists(string name)
		{
			return false;
		}

		public void Execute(string input)
		{
		}

		public bool Execute(string[] splitInput, out string usageText)
		{
			usageText = null;
			return false;
		}
	}
}
