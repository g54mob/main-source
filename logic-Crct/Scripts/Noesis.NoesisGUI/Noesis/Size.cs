namespace Noesis
{
	public struct Size
	{
		private float _width;

		private float _height;

		private static readonly Size _empty;

		public float Width
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Height
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public static Size Empty => default(Size);

		public bool IsEmpty => false;

		public Size(float width, float height)
		{
			_width = 0f;
			_height = 0f;
		}

		public static explicit operator Vector(Size size)
		{
			return default(Vector);
		}

		public static explicit operator Point(Size size)
		{
			return default(Point);
		}

		public static bool operator ==(Size s0, Size s1)
		{
			return false;
		}

		public static bool operator !=(Size s0, Size s1)
		{
			return false;
		}

		public static bool Equals(Size s0, Size s1)
		{
			return false;
		}

		public override bool Equals(object o)
		{
			return false;
		}

		public bool Equals(Size value)
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

		public static Size Parse(string str)
		{
			return default(Size);
		}

		private static Size CreateEmptySize()
		{
			return default(Size);
		}

		public static bool TryParse(string str, out Size result)
		{
			result = default(Size);
			return false;
		}
	}
}
