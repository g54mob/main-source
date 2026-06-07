namespace Assets.Packages.DevConsole.Commands.Arguments
{
	public class UInt32ArgumentParser : IArgumentParser<uint>
	{
		public string HelpMessage => null;

		public int Priority => 10;

		public bool TryParse(string value, out uint result)
		{
			return uint.TryParse(value, out result);
		}
	}
}
