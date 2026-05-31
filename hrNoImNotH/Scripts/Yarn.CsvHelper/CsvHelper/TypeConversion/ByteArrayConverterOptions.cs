using System;

namespace CsvHelper.TypeConversion
{
	[Flags]
	public enum ByteArrayConverterOptions
	{
		None = 0,
		Hexadecimal = 1,
		Base64 = 2,
		HexDashes = 4,
		HexInclude0x = 8
	}
}
