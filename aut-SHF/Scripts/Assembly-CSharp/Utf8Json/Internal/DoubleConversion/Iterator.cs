namespace Utf8Json.Internal.DoubleConversion
{
	internal struct Iterator
	{
		private byte[] buffer;

		private int offset;

		public byte Value => 0;

		public Iterator(byte[] buffer, int offset)
		{
			this.buffer = null;
			this.offset = 0;
		}

		public static Iterator operator ++(Iterator self)
		{
			return default(Iterator);
		}

		public static Iterator operator +(Iterator self, int length)
		{
			return default(Iterator);
		}

		public static int operator -(Iterator lhs, Iterator rhs)
		{
			return 0;
		}

		public static bool operator ==(Iterator lhs, Iterator rhs)
		{
			return false;
		}

		public static bool operator !=(Iterator lhs, Iterator rhs)
		{
			return false;
		}

		public static bool operator ==(Iterator lhs, char rhs)
		{
			return false;
		}

		public static bool operator !=(Iterator lhs, char rhs)
		{
			return false;
		}

		public static bool operator ==(Iterator lhs, byte rhs)
		{
			return false;
		}

		public static bool operator !=(Iterator lhs, byte rhs)
		{
			return false;
		}

		public static bool operator >=(Iterator lhs, char rhs)
		{
			return false;
		}

		public static bool operator <=(Iterator lhs, char rhs)
		{
			return false;
		}

		public static bool operator >(Iterator lhs, char rhs)
		{
			return false;
		}

		public static bool operator <(Iterator lhs, char rhs)
		{
			return false;
		}
	}
}
