using NSEipix.Base;
using NSMedieval.BuildingComponents;

namespace NSMedieval.DevConsole
{
	public class CommandAutoconstruct : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandAutoconstruct()
		{
			Command = "autoconstruct";
			Description = "Toggles instant construction.";
			Help = "Use this command to toggle instant object construction without resources and workers.";
			Argument = Autoconstruct();
		}

		private void CommandMethod()
		{
			MonoSingleton<BuildingPlacementManager>.Instance.AutoconstructToggle();
			Argument = Autoconstruct();
			string result = "Autoconstruct " + Argument;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private string Autoconstruct()
		{
			if (!MonoSingleton<BuildingPlacementManager>.Instance.Autoconstruct)
			{
				return "off";
			}
			return "on";
		}
	}
}
