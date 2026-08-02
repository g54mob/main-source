using System.Runtime.CompilerServices;
using System.Text;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class StringBuilderFormatter : MemoryPackFormatter<StringBuilder>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref StringBuilder? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref StringBuilder? value)
		{
		}
	}
}
