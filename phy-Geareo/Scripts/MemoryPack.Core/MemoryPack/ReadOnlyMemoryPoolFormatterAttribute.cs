using System;
using MemoryPack.Formatters;

namespace MemoryPack
{
	public sealed class ReadOnlyMemoryPoolFormatterAttribute<T> : MemoryPackCustomFormatterAttribute<ReadOnlyMemoryPoolFormatter<T>, ReadOnlyMemory<T?>> where T : notnull
	{
		private static readonly ReadOnlyMemoryPoolFormatter<T> formatter;

		public override ReadOnlyMemoryPoolFormatter<T> GetFormatter()
		{
			return null;
		}
	}
}
