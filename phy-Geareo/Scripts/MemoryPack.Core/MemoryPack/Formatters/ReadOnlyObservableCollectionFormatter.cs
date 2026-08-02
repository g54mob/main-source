using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class ReadOnlyObservableCollectionFormatter<T> : MemoryPackFormatter<ReadOnlyObservableCollection<T?>>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref ReadOnlyObservableCollection<T?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref ReadOnlyObservableCollection<T?>? value)
		{
		}
	}
}
