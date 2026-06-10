using NSEipix.Base;

namespace NSMedieval.DevConsole
{
	public class CommandUnlockAchievement : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandUnlockAchievement()
		{
			Command = "unlockAchievement";
			Description = "Unlocks achievement";
			Help = "Use this command with achievement name as string agrument to unlock achievement";
		}

		private void CommandMethod(string achievementName)
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Unlocking achievement " + achievementName);
			MonoSingleton<AchievementManager>.Instance.UnlockAchievement(achievementName);
		}
	}
}
