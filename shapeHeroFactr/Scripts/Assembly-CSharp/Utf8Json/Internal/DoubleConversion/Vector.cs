namespace Utf8Json.Internal.DoubleConversion
{
	internal struct Vector
	{
		public readonly byte[] bytes;

		public readonly int start;

		public readonly int _length;

		public byte this[int i]
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public Vector(byte[] bytes, int start, int length)
		{
			this.bytes = null;
			this.start = 0;
			_length = 0;
		}

		public int length()
		{
			return 0;
		}

		public byte first()
		{
			return 0;
		}

		public byte last()
		{
			return 0;
		}

		public bool is_empty()
		{
			return false;
		}

		public Vector SubVector(int from, int to)
		{
			return default(Vector);
		}
	}
}
