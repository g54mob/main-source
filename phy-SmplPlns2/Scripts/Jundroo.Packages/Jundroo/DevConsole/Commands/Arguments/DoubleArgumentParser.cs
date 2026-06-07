namespace Jundroo.DevConsole.Commands.Arguments
{
	internal class DoubleArgumentParser : IArgumentParser<double>
	{
		public string HelpMessage => null;

		public int Priority => 10;

		public bool TryParse(string value, out double result)
		{
			return double.TryParse(value, out result);
		}
	}
}
