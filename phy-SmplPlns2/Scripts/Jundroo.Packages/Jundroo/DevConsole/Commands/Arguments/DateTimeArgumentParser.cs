using System;

namespace Jundroo.DevConsole.Commands.Arguments
{
	internal class DateTimeArgumentParser : IArgumentParser<DateTime>
	{
		public string HelpMessage => null;

		public int Priority => 10;

		public bool TryParse(string value, out DateTime result)
		{
			return DateTime.TryParse(value, out result);
		}
	}
}
