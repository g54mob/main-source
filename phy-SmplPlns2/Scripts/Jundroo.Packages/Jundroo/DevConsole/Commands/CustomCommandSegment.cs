namespace Jundroo.DevConsole.Commands
{
	internal class CustomCommandSegment : ConsoleCommandSegment
	{
		public RegisteredCommandInfo? CommandInfo { get; set; }

		public override ConsoleCommandSegment Clone(bool needsReevaluated)
		{
			return new CustomCommandSegment
			{
				CommandInfo = CommandInfo,
				CommandText = base.CommandText,
				CommandType = base.CommandType,
				Evaluated = (!needsReevaluated && base.Evaluated)
			};
		}
	}
}
