using System;
using System.Globalization;
using Humanizer.Localisation;

namespace Humanizer.Bytes
{
	public class ByteRate
	{
		public ByteSize Size { get; private set; }

		public TimeSpan Interval { get; private set; }

		public ByteRate(ByteSize size, TimeSpan interval)
		{
		}

		public string Humanize(TimeUnit timeUnit = TimeUnit.Second)
		{
			return null;
		}

		public string Humanize(string format, TimeUnit timeUnit = TimeUnit.Second, CultureInfo culture = null)
		{
			return null;
		}
	}
}
