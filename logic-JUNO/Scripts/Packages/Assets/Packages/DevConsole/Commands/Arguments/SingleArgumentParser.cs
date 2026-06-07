namespace Assets.Packages.DevConsole.Commands.Arguments
{
	public class SingleArgumentParser : IArgumentParser<float>
	{
		public string HelpMessage => null;

		public int Priority => 10;

		public bool TryParse(string value, out float result)
		{
			return float.TryParse(value, out result);
		}
	}
}
