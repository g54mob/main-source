using System.Globalization;

namespace Amazon.S3.Model
{
	public class ByteRange
	{
		private string _formattedByteRange;

		public long Start { get; set; }

		public long End { get; set; }

		public string FormattedByteRange
		{
			get
			{
				if (!string.IsNullOrEmpty(_formattedByteRange))
				{
					return _formattedByteRange;
				}
				return string.Format(CultureInfo.InvariantCulture, "bytes={0}-{1}", Start, End);
			}
			set
			{
				_formattedByteRange = value;
			}
		}

		public ByteRange(long start, long end)
		{
			Start = start;
			End = end;
		}

		public ByteRange(string byteRangeValue)
		{
			_formattedByteRange = byteRangeValue;
		}
	}
}
