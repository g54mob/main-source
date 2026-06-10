using NSEipix.Base;

namespace NSMedieval.DevConsole
{
	public class CommandResetAchievement : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandResetAchievement()
		{
			Command = "resetAchievements";
			Description = "Resets all achievement progress";
			Help = "Use this command to reset all achievements progress";
		}

		private void CommandMethod()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Reseting achievements");
			MonoSingleton<AchievementManager>.Instance.ResetAll();
		}
	}
}
