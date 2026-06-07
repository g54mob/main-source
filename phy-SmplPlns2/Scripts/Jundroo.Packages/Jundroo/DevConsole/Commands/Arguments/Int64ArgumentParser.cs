namespace Jundroo.DevConsole.Commands.Arguments
{
	internal class Int64ArgumentParser : IArgumentParser<long>
	{
		public string HelpMessage => null;

		public int Priority => 10;

		public bool TryParse(string value, out long result)
		{
			return long.TryParse(value, out result);
		}
	}
}
