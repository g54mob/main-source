using FoxyVoxel.Logging;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandQuit : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandQuit()
		{
			Command = "quit";
			Description = "Quits the application";
			Help = "Use this command with no arguments to force Unity to quit";
		}

		private void CommandMethod()
		{
			if (!Application.isEditor)
			{
				Log.Info("Quitting to OS from CommandQuit", "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\Console\\Commands\\CommandQuit.cs");
				Application.Quit();
			}
		}
	}
}
