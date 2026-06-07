namespace Jundroo.DevConsole.Commands.Arguments
{
	internal class ByteArgumentParser : IArgumentParser<byte>
	{
		public string HelpMessage => null;

		public int Priority => 10;

		public bool TryParse(string value, out byte result)
		{
			return byte.TryParse(value, out result);
		}
	}
}
