using NSEipix.Base;
using NSMedieval.Manager;

namespace NSMedieval.DevConsole
{
	public class CommandKillAllPiles : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandKillAllPiles()
		{
			Command = "killPiles";
			Description = "Kills all piles on the map";
			Help = "Use this to kill all piles on the map";
		}

		private void CommandMethod()
		{
			MonoSingleton<ResourcePileManager>.Instance.KillAllPilesGameplay();
		}
	}
}
