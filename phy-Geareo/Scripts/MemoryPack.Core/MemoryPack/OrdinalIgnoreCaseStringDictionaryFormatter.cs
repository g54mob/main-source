using System.Collections.Generic;
using MemoryPack.Formatters;

namespace MemoryPack
{
	public sealed class OrdinalIgnoreCaseStringDictionaryFormatter<TValue> : MemoryPackCustomFormatterAttribute<DictionaryFormatter<string, TValue?>, Dictionary<string, TValue?>>
	{
		private static readonly DictionaryFormatter<string, TValue?> formatter;

		public override DictionaryFormatter<string?, TValue?>? GetFormatter()
		{
			return null;
		}
	}
}
