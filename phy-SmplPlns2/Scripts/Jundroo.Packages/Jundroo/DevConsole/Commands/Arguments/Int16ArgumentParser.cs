namespace Jundroo.DevConsole.Commands.Arguments
{
	internal class Int16ArgumentParser : IArgumentParser<short>
	{
		public string HelpMessage => null;

		public int Priority => 10;

		public bool TryParse(string value, out short result)
		{
			return short.TryParse(value, out result);
		}
	}
}
