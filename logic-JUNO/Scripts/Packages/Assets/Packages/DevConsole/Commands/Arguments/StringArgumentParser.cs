namespace Assets.Packages.DevConsole.Commands.Arguments
{
	public class StringArgumentParser : IArgumentParser<string>
	{
		public string HelpMessage => null;

		public int Priority => 10;

		public bool TryParse(string value, out string result)
		{
			result = value;
			return true;
		}
	}
}
