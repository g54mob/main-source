using System;
using System.Text;
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
			this.options = options;
			ValidateOptions();
			HexStringPrefix = (((options & ByteArrayConverterOptions.HexDashes) == ByteArrayConverterOptions.HexDashes) ? "-" : string.Empty);
			ByteLength = (byte)(((options & ByteArrayConverterOptions.HexDashes) == ByteArrayConverterOptions.HexDashes) ? 3 : 2);
		}

		public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
		{
			if (value is byte[] array)
			{
				if ((options & ByteArrayConverterOptions.Base64) != ByteArrayConverterOptions.Base64)
				{
					return ByteArrayToHexString(array);
				}
				return Convert.ToBase64String(array);
			}
			return base.ConvertToString(value, row, memberMapData);
		}

		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			if (text != null)
			{
				if ((options & ByteArrayConverterOptions.Base64) != ByteArrayConverterOptions.Base64)
				{
					return HexStringToByteArray(text);
				}
				return Convert.FromBase64String(text);
			}
			return base.ConvertFromString(text, row, memberMapData);
		}

		private string ByteArrayToHexString(byte[] byteArray)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if ((options & ByteArrayConverterOptions.HexInclude0x) == ByteArrayConverterOptions.HexInclude0x)
			{
				stringBuilder.Append("0x");
			}
			if (byteArray.Length >= 1)
			{
				stringBuilder.Append(byteArray[0].ToString("X2"));
			}
			for (int i = 1; i < byteArray.Length; i++)
			{
				stringBuilder.Append(HexStringPrefix + byteArray[i].ToString("X2"));
			}
			return stringBuilder.ToString();
		}

		private byte[] HexStringToByteArray(string hex)
		{
			bool num = hex.StartsWith("0x");
			byte[] array = new byte[num ? ((hex.Length - 1) / ByteLength) : (hex.Length + 1 / ByteLength)];
			int num2 = (num ? 1 : 0);
			for (int i = num2 * 2; i < hex.Length; i += ByteLength)
			{
				array[(i - num2) / ByteLength] = Convert.ToByte(hex.Substring(i, 2), 16);
			}
			return array;
		}

		private void ValidateOptions()
		{
			if ((options & ByteArrayConverterOptions.Base64) == ByteArrayConverterOptions.Base64 && (options & (ByteArrayConverterOptions.Hexadecimal | ByteArrayConverterOptions.HexDashes | ByteArrayConverterOptions.HexInclude0x)) != ByteArrayConverterOptions.None)
			{
				throw new ConfigurationException("ByteArrayConverter must be configured exclusively with HexDecimal options, or exclusively with Base64 options.  Was " + options)
				{
					Data = { 
					{
						(object)"options",
						(object)options
					} }
				};
			}
		}
	}
}
