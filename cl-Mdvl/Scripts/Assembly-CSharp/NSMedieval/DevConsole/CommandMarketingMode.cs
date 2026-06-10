namespace NSMedieval.DevConsole
{
	public class CommandMarketingMode : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandMarketingMode()
		{
			Command = "marketingMode";
			Description = "Turns on marketing mode.";
			Help = "Use this command to turn on marketing mode which allows fast gameplay.";
		}

		private void CommandMethod()
		{
		}
	}
}
