using NSEipix.Base;
using NSMedieval.Manager;

namespace NSMedieval.DevConsole
{
	public class CommandForceCropHarvestPhase : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandForceCropHarvestPhase()
		{
			Command = "forceCropHarvestPhase";
			Description = "Forces crops to harvest phase after planting.";
			Help = "Use this command to force crops to harvest phase after planting.";
			Argument = ForceHarvestPhase();
		}

		private void CommandMethod()
		{
			MonoSingleton<PlantResourceManager>.Instance.ForceHarvestPhaseToggle();
			Argument = ForceHarvestPhase();
			string result = "Force Harvest Phase " + Argument;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private string ForceHarvestPhase()
		{
			if (!MonoSingleton<PlantResourceManager>.Instance.ForceHarvestPhase)
			{
				return "off";
			}
			return "on";
		}
	}
}
