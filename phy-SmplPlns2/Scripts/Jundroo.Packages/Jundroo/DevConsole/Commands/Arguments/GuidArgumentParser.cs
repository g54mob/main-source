using System;

namespace Jundroo.DevConsole.Commands.Arguments
{
	internal class GuidArgumentParser : IArgumentParser<Guid>
	{
		public string HelpMessage => null;

		public int Priority => 10;

		public bool TryParse(string value, out Guid result)
		{
			try
			{
				result = new Guid(value);
				return true;
			}
			catch (Exception)
			{
				result = default(Guid);
				return false;
			}
		}
	}
}
