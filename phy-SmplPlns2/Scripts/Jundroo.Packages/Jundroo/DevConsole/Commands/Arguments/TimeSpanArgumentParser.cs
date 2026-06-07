using System;

namespace Jundroo.DevConsole.Commands.Arguments
{
	internal class TimeSpanArgumentParser : IArgumentParser<TimeSpan>
	{
		public string HelpMessage => null;

		public int Priority => 10;

		public bool TryParse(string value, out TimeSpan result)
		{
			return TimeSpan.TryParse(value, out result);
		}
	}
}
