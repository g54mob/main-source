using System;
using System.Globalization;

namespace Humanizer.Bytes
{
	public struct ByteSize : IComparable<ByteSize>, IEquatable<ByteSize>, IComparable, IFormattable
	{
		public static readonly ByteSize MinValue;

		public static readonly ByteSize MaxValue;

		public const long BitsInByte = 8L;

		public const long BytesInKilobyte = 1024L;

		public const long BytesInMegabyte = 1048576L;

		public const long BytesInGigabyte = 1073741824L;

		public const long BytesInTerabyte = 1099511627776L;

		public const string BitSymbol = "b";

		public const string Bit = "bit";

		public const string ByteSymbol = "B";

		public const string Byte = "byte";

		public const string KilobyteSymbol = "KB";

		public const string Kilobyte = "kilobyte";

		public const string MegabyteSymbol = "MB";

		public const string Megabyte = "megabyte";

		public const string GigabyteSymbol = "GB";

		public const string Gigabyte = "gigabyte";

		public const string TerabyteSymbol = "TB";

		public const string Terabyte = "terabyte";

		public long Bits { get; private set; }

		public double Bytes { get; private set; }

		public double Kilobytes { get; private set; }

		public double Megabytes { get; private set; }

		public double Gigabytes { get; private set; }

		public double Terabytes { get; private set; }

		public string LargestWholeNumberSymbol => null;

		public string LargestWholeNumberFullWord => null;

		public double LargestWholeNumberValue => 0.0;

		public string GetLargestWholeNumberSymbol(IFormatProvider provider = null)
		{
			return null;
		}

		public string GetLargestWholeNumberFullWord(IFormatProvider provider = null)
		{
			return null;
		}

		public ByteSize(double byteSize)
		{
			Bits = 0L;
			Bytes = 0.0;
			Kilobytes = 0.0;
			Megabytes = 0.0;
			Gigabytes = 0.0;
			Terabytes = 0.0;
		}

		public static ByteSize FromBits(long value)
		{
			return default(ByteSize);
		}

		public static ByteSize FromBytes(double value)
		{
			return default(ByteSize);
		}

		public static ByteSize FromKilobytes(double value)
		{
			return default(ByteSize);
		}

		public static ByteSize FromMegabytes(double value)
		{
			return default(ByteSize);
		}

		public static ByteSize FromGigabytes(double value)
		{
			return default(ByteSize);
		}

		public static ByteSize FromTerabytes(double value)
		{
			return default(ByteSize);
		}

		public override string ToString()
		{
			return null;
		}

		public string ToString(IFormatProvider provider)
		{
			return null;
		}

		public string ToString(string format)
		{
			return null;
		}

		public string ToString(string format, IFormatProvider provider)
		{
			return null;
		}

		private string ToString(string format, IFormatProvider provider, bool toSymbol)
		{
			return null;
		}

		public string ToFullWords(string format = null, IFormatProvider provider = null)
		{
			return null;
		}

		public override bool Equals(object value)
		{
			return false;
		}

		public bool Equals(ByteSize value)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public int CompareTo(object obj)
		{
			return 0;
		}

		public int CompareTo(ByteSize other)
		{
			return 0;
		}

		public ByteSize Add(ByteSize bs)
		{
			return default(ByteSize);
		}

		public ByteSize AddBits(long value)
		{
			return default(ByteSize);
		}

		public ByteSize AddBytes(double value)
		{
			return default(ByteSize);
		}

		public ByteSize AddKilobytes(double value)
		{
			return default(ByteSize);
		}

		public ByteSize AddMegabytes(double value)
		{
			return default(ByteSize);
		}

		public ByteSize AddGigabytes(double value)
		{
			return default(ByteSize);
		}

		public ByteSize AddTerabytes(double value)
		{
			return default(ByteSize);
		}

		public ByteSize Subtract(ByteSize bs)
		{
			return default(ByteSize);
		}

		public static ByteSize operator +(ByteSize b1, ByteSize b2)
		{
			return default(ByteSize);
		}

		public static ByteSize operator -(ByteSize b1, ByteSize b2)
		{
			return default(ByteSize);
		}

		public static ByteSize operator ++(ByteSize b)
		{
			return default(ByteSize);
		}

		public static ByteSize operator -(ByteSize b)
		{
			return default(ByteSize);
		}

		public static ByteSize operator --(ByteSize b)
		{
			return default(ByteSize);
		}

		public static bool operator ==(ByteSize b1, ByteSize b2)
		{
			return false;
		}

		public static bool operator !=(ByteSize b1, ByteSize b2)
		{
			return false;
		}

		public static bool operator <(ByteSize b1, ByteSize b2)
		{
			return false;
		}

		public static bool operator <=(ByteSize b1, ByteSize b2)
		{
			return false;
		}

		public static bool operator >(ByteSize b1, ByteSize b2)
		{
			return false;
		}

		public static bool operator >=(ByteSize b1, ByteSize b2)
		{
			return false;
		}

		public static bool TryParse(string s, out ByteSize result)
		{
			result = default(ByteSize);
			return false;
		}

		public static bool TryParse(string s, IFormatProvider formatProvider, out ByteSize result)
		{
			result = default(ByteSize);
			return false;
		}

		private static NumberFormatInfo GetNumberFormatInfo(IFormatProvider formatProvider)
		{
			return null;
		}

		public static ByteSize Parse(string s)
		{
			return default(ByteSize);
		}

		public static ByteSize Parse(string s, IFormatProvider formatProvider)
		{
			return default(ByteSize);
		}
	}
}
