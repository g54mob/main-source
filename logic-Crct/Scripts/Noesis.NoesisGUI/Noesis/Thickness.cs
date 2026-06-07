namespace Noesis
{
	public struct Thickness
	{
		private float _l;

		private float _t;

		private float _r;

		private float _b;

		public float Left
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Top
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Right
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Bottom
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Size Size => default(Size);

		public Thickness(float size)
		{
			_l = 0f;
			_t = 0f;
			_r = 0f;
			_b = 0f;
		}

		public Thickness(float lr, float tb)
		{
			_l = 0f;
			_t = 0f;
			_r = 0f;
			_b = 0f;
		}

		public Thickness(float left, float top, float right, float bottom)
		{
			_l = 0f;
			_t = 0f;
			_r = 0f;
			_b = 0f;
		}

		public static bool operator ==(Thickness t0, Thickness t1)
		{
			return false;
		}

		public static bool operator !=(Thickness t0, Thickness t1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(Thickness t)
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

		public static Thickness Parse(string str)
		{
			return default(Thickness);
		}

		public static bool TryParse(string str, out Thickness result)
		{
			result = default(Thickness);
			return false;
		}
	}
}
