using NSEipix.Base;
using NSMedieval.Managers;

namespace NSMedieval.DevConsole
{
	public class CommandKillAllFish : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandKillAllFish()
		{
			Command = "killAllFish";
			Description = "Kills all fish on the map";
			Help = "Use this to kill all fish on the map";
		}

		private void CommandMethod()
		{
			MonoSingleton<FishResourceManager>.Instance.KillAllFish();
		}
	}
}
