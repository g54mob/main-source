using MemoryPack.Formatters;

namespace MemoryPack
{
	public sealed class InternStringFormatterAttribute : MemoryPackCustomFormatterAttribute<InternStringFormatter, string>
	{
		public override InternStringFormatter GetFormatter()
		{
			return null;
		}
	}
}
