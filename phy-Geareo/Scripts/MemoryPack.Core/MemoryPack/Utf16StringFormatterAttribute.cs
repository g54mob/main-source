using MemoryPack.Formatters;

namespace MemoryPack
{
	public sealed class Utf16StringFormatterAttribute : MemoryPackCustomFormatterAttribute<Utf16StringFormatter, string>
	{
		public override Utf16StringFormatter GetFormatter()
		{
			return null;
		}
	}
}
