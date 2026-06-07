namespace Dhs5.Utility.Console
{
	public struct ValidCommand
	{
		public readonly IConsoleCommand command;

		public readonly string rawCommand;

		public readonly object[] parameters;

		public ValidCommand(IConsoleCommand command, string rawCommand, object[] parameters)
		{
			this.command = command;
			this.rawCommand = rawCommand;
			this.parameters = parameters;
		}

		public static ValidCommand Invalid()
		{
			return new ValidCommand(null, null, null);
		}
	}
}
