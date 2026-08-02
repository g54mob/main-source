using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class TypeFormatter : MemoryPackFormatter<Type>
	{
		private static readonly Regex _shortTypeNameRegex;

		private static Regex ShortTypeNameRegex()
		{
			return null;
		}

		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref Type? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref Type? value)
		{
		}
	}
}
