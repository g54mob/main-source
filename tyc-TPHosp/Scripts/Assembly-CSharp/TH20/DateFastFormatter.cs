using System;

namespace TH20
{
	public class DateFastFormatter
	{
		public const string EquivalentDateTimeFormatString = "yyyy-MM-dd HH\\:mm\\:ss.fff";

		private readonly char[] _buffer = new char[23];

		private const char DatePartsSeparator = '-';

		private const char DateTimeSeparator = ' ';

		private const char TimePartsSeparator = ':';

		private const char MillisecondSeparator = '.';

		public DateFastFormatter()
		{
			_buffer[4] = (_buffer[7] = '-');
			_buffer[10] = ' ';
			_buffer[13] = (_buffer[16] = ':');
			_buffer[19] = '.';
		}

		public string FormatDateTimeString(DateTime when)
		{
			return new string(FormatDateTime(when));
		}

		public char[] FormatDateTime(DateTime when)
		{
			Write4(when.Year, 0);
			Write2(when.Month, 5);
			Write2(when.Day, 8);
			Write2(when.Hour, 11);
			Write2(when.Minute, 14);
			Write2(when.Second, 17);
			Write3(when.Millisecond, 20);
			return _buffer;
		}

		private void Write2(int value, int offset)
		{
			_buffer[offset++] = (char)(48 + value / 10);
			_buffer[offset] = (char)(48 + value % 10);
		}

		private void Write3(int value, int offset)
		{
			_buffer[offset++] = (char)(48 + value / 100);
			_buffer[offset++] = (char)(48 + value / 10 % 10);
			_buffer[offset] = (char)(48 + value % 10);
		}

		private void Write4(int value, int offset)
		{
			_buffer[offset++] = (char)(48 + value / 1000);
			_buffer[offset++] = (char)(48 + value / 100 % 10);
			_buffer[offset++] = (char)(48 + value / 10 % 10);
			_buffer[offset] = (char)(48 + value % 10);
		}
	}
}
