namespace NSMedieval.DevConsole
{
	public class CommandConstructionSpeedMax : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandConstructionSpeedMax()
		{
			Command = "constructionSpeedMax";
			Description = "Max outs humanoid construction speed.";
			Help = "Use this command to max out humanoid construction speed.";
		}

		private void CommandMethod()
		{
		}
	}
}
