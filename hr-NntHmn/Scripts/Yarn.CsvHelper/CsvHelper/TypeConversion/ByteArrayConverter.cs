using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class ByteArrayConverter : DefaultTypeConverter
	{
		private readonly ByteArrayConverterOptions options;

		private readonly string HexStringPrefix;

		private readonly byte ByteLength;

		public ByteArrayConverter(ByteArrayConverterOptions options = ByteArrayConverterOptions.Hexadecimal | ByteArrayConverterOptions.HexInclude0x)
		{
		}

		public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
		{
			return null;
		}

		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			return null;
		}

		private string ByteArrayToHexString(byte[] byteArray)
		{
			return null;
		}

		private byte[] HexStringToByteArray(string hex)
		{
			return null;
		}

		private void ValidateOptions()
		{
		}
	}
}
