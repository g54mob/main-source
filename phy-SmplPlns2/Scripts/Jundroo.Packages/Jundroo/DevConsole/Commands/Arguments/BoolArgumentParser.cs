namespace Jundroo.DevConsole.Commands.Arguments
{
	internal class BoolArgumentParser : IArgumentParser<bool>
	{
		public string HelpMessage => null;

		public int Priority => 10;

		public bool TryParse(string value, out bool result)
		{
			return bool.TryParse(value, out result);
		}
	}
}
