namespace Jundroo.DevConsole.Commands.Arguments
{
	internal class Int32ArgumentParser : IArgumentParser<int>
	{
		public string HelpMessage => null;

		public int Priority => 10;

		public bool TryParse(string value, out int result)
		{
			return int.TryParse(value, out result);
		}
	}
}
