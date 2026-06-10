using NSEipix.Base;
using NSMedieval.Crops;

namespace NSMedieval.DevConsole
{
	public class CommandForcePlantCrops : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandForcePlantCrops()
		{
			Command = "forcePlantCrops";
			Description = "Toggles spawning crops with planted seeds.";
			Help = "Use this command to toggle placing and expanding crops being already seeded.";
			Argument = ForcePlantCrops();
		}

		private void CommandMethod()
		{
			MonoSingleton<CropsManager>.Instance.ForcePlantCropsToggle();
			Argument = ForcePlantCrops();
			string result = "Force Plant Crops " + Argument;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private string ForcePlantCrops()
		{
			if (!MonoSingleton<CropsManager>.Instance.ForcePlantCrops)
			{
				return "off";
			}
			return "on";
		}
	}
}
