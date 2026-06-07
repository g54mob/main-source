using System;

namespace CsvHelper
{
	[Serializable]
	[Flags]
	public enum Caches
	{
		None = 0,
		NamedIndex = 1,
		ReadRecord = 2,
		WriteRecord = 4,
		TypeConverterOptions = 8,
		RawRecord = 0x10
	}
}
