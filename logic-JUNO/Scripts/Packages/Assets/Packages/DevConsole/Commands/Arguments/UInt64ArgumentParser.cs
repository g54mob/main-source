namespace Assets.Packages.DevConsole.Commands.Arguments
{
	public class UInt64ArgumentParser : IArgumentParser<ulong>
	{
		public string HelpMessage => null;

		public int Priority => 10;

		public bool TryParse(string value, out ulong result)
		{
			return ulong.TryParse(value, out result);
		}
	}
}
