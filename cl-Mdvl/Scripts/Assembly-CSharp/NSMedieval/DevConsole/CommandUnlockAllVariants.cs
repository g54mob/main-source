using NSEipix.Base;
using NSMedieval.BuildingComponents;

namespace NSMedieval.DevConsole
{
	public class CommandUnlockAllVariants : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandUnlockAllVariants()
		{
			Command = "unlockAllVariants";
			Description = "Toggles whether all building variants are unlocked or not.";
			Help = "Use this command to toggle wether building variants are instantly unlocked or if you need to have that resource on the map.";
			Argument = VariantsUnlocked();
		}

		private void CommandMethod()
		{
			MonoSingleton<BuildingPlacementManager>.Instance.VariantsUnlockedToggle();
			Argument = VariantsUnlocked();
			string result = "Unlock All Variants " + Argument;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private string VariantsUnlocked()
		{
			if (!MonoSingleton<BuildingPlacementManager>.Instance.VariantsUnlocked)
			{
				return "off";
			}
			return "on";
		}
	}
}
