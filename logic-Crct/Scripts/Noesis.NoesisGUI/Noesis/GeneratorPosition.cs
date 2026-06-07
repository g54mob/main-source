namespace Noesis
{
	public struct GeneratorPosition
	{
		private int _index;

		private int _offset;

		public int Index
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Offset
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public GeneratorPosition(int index, int offset)
		{
			_index = 0;
			_offset = 0;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public static bool operator ==(GeneratorPosition p1, GeneratorPosition p2)
		{
			return false;
		}

		public static bool operator !=(GeneratorPosition p1, GeneratorPosition p2)
		{
			return false;
		}
	}
}
