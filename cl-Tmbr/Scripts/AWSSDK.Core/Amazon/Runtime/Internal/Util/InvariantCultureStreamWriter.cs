using System;
using System.Globalization;
using System.IO;

namespace Amazon.Runtime.Internal.Util
{
	public class InvariantCultureStreamWriter : StreamWriter
	{
		public override IFormatProvider FormatProvider => CultureInfo.InvariantCulture;

		public InvariantCultureStreamWriter(Stream stream)
			: base(stream)
		{
		}
	}
}
