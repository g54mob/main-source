using System;
using System.IO;
using System.Text;

namespace MiscUtil.IO
{
	public class StringWriterWithEncoding : StringWriter
	{
		private readonly Encoding encoding;

		public override Encoding Encoding => encoding;

		public StringWriterWithEncoding(Encoding encoding)
		{
			if (encoding == null)
			{
				throw new ArgumentNullException("encoding");
			}
			this.encoding = encoding;
		}

		public StringWriterWithEncoding(IFormatProvider formatProvider, Encoding encoding)
			: base(formatProvider)
		{
			if (encoding == null)
			{
				throw new ArgumentNullException("encoding");
			}
			this.encoding = encoding;
		}

		public StringWriterWithEncoding(StringBuilder sb, Encoding encoding)
			: base(sb)
		{
			if (encoding == null)
			{
				throw new ArgumentNullException("encoding");
			}
			this.encoding = encoding;
		}

		public StringWriterWithEncoding(StringBuilder sb, IFormatProvider formatProvider, Encoding encoding)
			: base(sb, formatProvider)
		{
			if (encoding == null)
			{
				throw new ArgumentNullException("encoding");
			}
			this.encoding = encoding;
		}
	}
}
