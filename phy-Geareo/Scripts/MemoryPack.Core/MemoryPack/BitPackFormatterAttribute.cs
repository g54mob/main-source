using MemoryPack.Compression;

namespace MemoryPack
{
	public sealed class BitPackFormatterAttribute : MemoryPackCustomFormatterAttribute<BitPackFormatter, bool[]>
	{
		public override BitPackFormatter GetFormatter()
		{
			return null;
		}
	}
}
