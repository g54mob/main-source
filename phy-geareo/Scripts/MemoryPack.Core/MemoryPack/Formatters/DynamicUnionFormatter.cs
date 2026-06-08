using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MemoryPack.Formatters
{
	public sealed class DynamicUnionFormatter<T> : MemoryPackFormatter<T> where T : class
	{
		private readonly Dictionary<Type, ushort> typeToTag;

		private readonly Dictionary<ushort, Type> tagToType;

		public DynamicUnionFormatter(params (ushort Tag, Type Type)[] memoryPackUnions)
		{
		}

		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref T? value)
		{
		}

		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref T? value)
		{
		}
	}
}
