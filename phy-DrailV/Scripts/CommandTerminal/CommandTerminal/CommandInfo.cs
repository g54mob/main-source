using System;

namespace CommandTerminal
{
	public struct CommandInfo
	{
		public string name;

		public Action<CommandArg[]> proc;

		public int max_arg_count;

		public int min_arg_count;

		public string help;

		public string hint;

		public bool secret;
	}
}
