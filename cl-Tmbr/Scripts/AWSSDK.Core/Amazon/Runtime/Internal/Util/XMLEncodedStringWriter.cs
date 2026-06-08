using System;
using System.IO;
using System.Text;

namespace Amazon.Runtime.Internal.Util
{
	public class XMLEncodedStringWriter : StringWriter
	{
		public XMLEncodedStringWriter(IFormatProvider formatProvider)
			: base(formatProvider)
		{
		}

		public override void Write(char[] buffer, int index, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (buffer.Length - index < count)
			{
				throw new ArgumentException();
			}
			StringBuilder stringBuilder = GetStringBuilder();
			for (int i = index; i < index + count; i++)
			{
				switch (buffer[i])
				{
				case '\n':
					stringBuilder.Append("&#xA;");
					break;
				case '\u0085':
					stringBuilder.Append("&#x85;");
					break;
				case '\u2028':
					stringBuilder.Append("&#x2028;");
					break;
				default:
					stringBuilder.Append(buffer[i]);
					break;
				}
			}
		}
	}
}
