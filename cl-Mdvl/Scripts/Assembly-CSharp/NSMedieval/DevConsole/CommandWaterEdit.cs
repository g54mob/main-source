namespace NSMedieval.DevConsole
{
	public class CommandWaterEdit : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandWaterEdit()
		{
			Command = "waterEdiort";
			Description = "Turns on water editor mode.";
			Help = "Use this command to turn on water editor mode which allows you water related debug features.";
		}

		private void CommandMethod()
		{
		}
	}
}
