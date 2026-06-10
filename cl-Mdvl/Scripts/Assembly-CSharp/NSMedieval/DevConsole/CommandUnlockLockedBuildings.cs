namespace NSMedieval.DevConsole
{
	public class CommandUnlockLockedBuildings : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandUnlockLockedBuildings()
		{
			Command = "unlockLockedBuildings";
			Description = "Unlocks hardcode locked buildings.";
			Help = "Use this command to unlock hardcoded locked buildings (ONLY IN EDITOR!).";
		}

		private void CommandMethod()
		{
			UnlockLockedBuildings();
		}

		private void UnlockLockedBuildings()
		{
		}
	}
}
