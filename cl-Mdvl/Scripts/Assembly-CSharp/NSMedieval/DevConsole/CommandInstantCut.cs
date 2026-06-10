using NSEipix.Base;
using NSMedieval.Manager;

namespace NSMedieval.DevConsole
{
	public class CommandInstantCut : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandInstantCut()
		{
			Command = "instantCut";
			Description = "Toggles instant cutting of future marked plants.";
			Help = "Use this command to toggle instant cutting of future marked plants.";
			Argument = InstantCut();
		}

		private void CommandMethod()
		{
			MonoSingleton<PlantResourceManager>.Instance.InstantCutToggle();
			Argument = InstantCut();
			string result = "Instant Cut " + Argument;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private string InstantCut()
		{
			if (!MonoSingleton<PlantResourceManager>.Instance.InstantCut)
			{
				return "off";
			}
			return "on";
		}
	}
}
