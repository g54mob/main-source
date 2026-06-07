namespace Jundroo.DevConsole.Commands.Arguments
{
	internal class UInt16ArgumentParser : IArgumentParser<ushort>
	{
		public string HelpMessage => null;

		public int Priority => 10;

		public bool TryParse(string value, out ushort result)
		{
			return ushort.TryParse(value, out result);
		}
	}
}
