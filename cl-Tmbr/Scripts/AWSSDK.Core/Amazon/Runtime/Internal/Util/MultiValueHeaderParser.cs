using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Amazon.Util;

namespace Amazon.Runtime.Internal.Util
{
	public static class MultiValueHeaderParser
	{
		private static char Delimiter = ',';

		public static List<string> ToStringList(string header)
		{
			List<string> list = new List<string>();
			int num = 0;
			byte[] bytes = Encoding.UTF8.GetBytes(header);
			while (num < bytes.Length)
			{
				Tuple<string, int> tuple = ReadValue(bytes, num);
				list.Add(tuple.Item1);
				num = tuple.Item2;
			}
			return list;
		}

		public static List<DateTime> ToDateTimeList(string header, string format)
		{
			string text = header?.Trim();
			if (string.IsNullOrEmpty(text))
			{
				return new List<DateTime>();
			}
			switch (format)
			{
			case "ISO8601":
				return (from item in text.Split(new char[1] { Delimiter })
					select DateTime.Parse(item.Trim(), CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal)).ToList();
			case "RFC822":
			{
				List<string> list = new List<string>();
				int num = 0;
				while (num < text.Length)
				{
					int num2 = text.IndexOf(Delimiter, num);
					if (num2 == -1 || num2 + 1 == text.Length)
					{
						throw new ArgumentException($"Invalid RFC822 format {text} at starting index {num}.");
					}
					num2 = text.IndexOf(Delimiter, num2 + 1);
					if (num2 == -1)
					{
						num2 = text.Length;
					}
					list.Add(text.Substring(num, num2 - num));
					num = num2 + 1;
				}
				return list.Select((string item) => DateTime.Parse(item.Trim(), CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal)).ToList();
			}
			case "UnixTimestamp":
				return (from item in text.Split(new char[1] { Delimiter })
					select AWSSDKUtils.ConvertFromUnixEpochSeconds(int.Parse(item.Trim(), CultureInfo.InvariantCulture))).ToList();
			default:
				throw new ArgumentException("Unknown format type: " + format + ". Supported formats are: ISO8601, RFC822, UnixTimestamp");
			}
		}

		public static List<T> ToValueTypeList<T>(string header) where T : struct
		{
			string text = header?.Trim();
			if (string.IsNullOrEmpty(text))
			{
				return new List<T>();
			}
			return text.Split(new char[1] { Delimiter }).ToList().ConvertAll((string item) => (T)Convert.ChangeType(item.Trim(), typeof(T)))
				.ToList();
		}

		private static Tuple<string, int> ReadValue(byte[] input, int startAtIndex)
		{
			for (int i = startAtIndex; i < input.Length; i++)
			{
				switch (input[i])
				{
				case 34:
					return ReadQuotedValue(input, i + 1);
				default:
					return ReadUnquotedValue(input, i);
				case 9:
				case 32:
					break;
				}
			}
			return new Tuple<string, int>(string.Empty, input.Length);
		}

		private static Tuple<string, int> ReadUnquotedValue(byte[] input, int startIndex)
		{
			int num = Array.IndexOf(input, (byte)Delimiter, startIndex);
			int num2 = ((num != -1) ? (num - startIndex) : (input.Length - startIndex));
			string item = Encoding.UTF8.GetString(input, startIndex, num2).Trim();
			int item2 = AdvanceIndexIfComma(input, startIndex + num2);
			return new Tuple<string, int>(item, item2);
		}

		private static Tuple<string, int> ReadQuotedValue(byte[] input, int startIndex)
		{
			for (int i = startIndex; i < input.Length; i++)
			{
				if (input[i] == 34 && (i == startIndex || input[i - 1] != 92))
				{
					string item = Encoding.UTF8.GetString(input, startIndex, i - startIndex).Replace("\\\"", "\"").Replace("\\\\", "\\");
					int item2 = AdvanceIndexIfComma(input, i + 1);
					return new Tuple<string, int>(item, item2);
				}
			}
			throw new ArgumentException($"Input started with a quote but did not end with a quote at index {startIndex}.");
		}

		private static int AdvanceIndexIfComma(byte[] input, int index)
		{
			if (index >= input.Length)
			{
				return index;
			}
			if (input[index] == (byte)Delimiter)
			{
				return index + 1;
			}
			throw new ArgumentException($"Expected delimiter `{Delimiter}` in input data at index {index}.");
		}
	}
}
