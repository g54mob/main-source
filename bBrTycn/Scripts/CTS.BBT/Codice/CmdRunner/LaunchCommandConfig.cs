using System;

namespace Codice.CmdRunner
{
	[Serializable]
	public class LaunchCommandConfig
	{
		public string FullServerCommand;

		public string CmShellComand;

		public string AllServerPrefixCommand;

		public string ClientPath;
	}
}
