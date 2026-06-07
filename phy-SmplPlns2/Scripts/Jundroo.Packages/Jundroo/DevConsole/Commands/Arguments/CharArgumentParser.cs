namespace Jundroo.DevConsole.Commands.Arguments
{
	internal class CharArgumentParser : IArgumentParser<char>
	{
		public string HelpMessage => null;

		public int Priority => 10;

		public bool TryParse(string value, out char result)
		{
			return char.TryParse(value, out result);
		}
	}
}
