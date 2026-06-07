namespace Noesis
{
	public struct Int32Rect
	{
		private int _x;

		private int _y;

		private uint _width;

		private uint _height;

		private static readonly Int32Rect _empty;

		public static Int32Rect Empty => default(Int32Rect);

		public bool IsEmpty => false;

		public bool HasArea => false;

		public int X
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Y
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Width
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Height
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public Int32Rect(int x, int y, int width, int height)
		{
			_x = 0;
			_y = 0;
			_width = 0u;
			_height = 0u;
		}

		public static bool operator ==(Int32Rect r0, Int32Rect r1)
		{
			return false;
		}

		public static bool operator !=(Int32Rect r0, Int32Rect r1)
		{
			return false;
		}

		public bool Equals(Int32Rect r0, Int32Rect r1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(Int32Rect r)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public static Int32Rect Parse(string str)
		{
			return default(Int32Rect);
		}

		public static bool TryParse(string str, out Int32Rect result)
		{
			result = default(Int32Rect);
			return false;
		}
	}
}
