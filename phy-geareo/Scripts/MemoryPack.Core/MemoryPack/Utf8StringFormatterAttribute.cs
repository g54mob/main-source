using MemoryPack.Formatters;

namespace MemoryPack
{
	public sealed class Utf8StringFormatterAttribute : MemoryPackCustomFormatterAttribute<Utf8StringFormatter, string>
	{
		public override Utf8StringFormatter GetFormatter()
		{
			return null;
		}
	}
}
