using NSEipix.Base;

namespace NSMedieval.DevConsole
{
	public class CommandAchievementSetStat : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandAchievementSetStat()
		{
			Command = "setAchievementStat";
			Description = "Sets value to achievemnt stat";
			Help = "Use this command to instantly change achievement progress stat. Int only!";
		}

		private void CommandMethod(string statName, int value)
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Changing stat " + statName + " to value " + value);
			MonoSingleton<AchievementManager>.Instance.SetStat(statName, value);
		}
	}
}
