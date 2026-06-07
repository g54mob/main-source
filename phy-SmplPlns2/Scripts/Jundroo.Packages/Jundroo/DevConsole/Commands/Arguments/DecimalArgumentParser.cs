namespace Jundroo.DevConsole.Commands.Arguments
{
	internal class DecimalArgumentParser : IArgumentParser<decimal>
	{
		public string HelpMessage => null;

		public int Priority => 10;

		public bool TryParse(string value, out decimal result)
		{
			return decimal.TryParse(value, out result);
		}
	}
}
