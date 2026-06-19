namespace SickDev.CommandSystem
{
	public class CommandOverloadNotFoundException : CommandSystemException
	{
		private ParsedCommand parsedCommand;

		public override string Message => "No overload found for command " + parsedCommand.raw;

		public CommandOverloadNotFoundException(ParsedCommand parsedCommand)
		{
			this.parsedCommand = parsedCommand;
		}
	}
}
