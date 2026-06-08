using System;
using MemoryPack.Formatters;

namespace MemoryPack
{
	public sealed class MemoryPoolFormatterAttribute<T> : MemoryPackCustomFormatterAttribute<MemoryPoolFormatter<T>, Memory<T?>> where T : notnull
	{
		private static readonly MemoryPoolFormatter<T> formatter;

		public override MemoryPoolFormatter<T> GetFormatter()
		{
			return null;
		}
	}
}
