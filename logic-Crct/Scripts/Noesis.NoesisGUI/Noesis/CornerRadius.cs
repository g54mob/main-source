namespace Noesis
{
	public struct CornerRadius
	{
		private float _tl;

		private float _tr;

		private float _br;

		private float _bl;

		public float TopLeft
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float TopRight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float BottomRight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float BottomLeft
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public CornerRadius(float radius)
		{
			_tl = 0f;
			_tr = 0f;
			_br = 0f;
			_bl = 0f;
		}

		public CornerRadius(float topLeft, float topRight, float bottomRight, float bottomLeft)
		{
			_tl = 0f;
			_tr = 0f;
			_br = 0f;
			_bl = 0f;
		}

		public static bool operator ==(CornerRadius c0, CornerRadius c1)
		{
			return false;
		}

		public static bool operator !=(CornerRadius c0, CornerRadius c1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(CornerRadius t)
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

		public static CornerRadius Parse(string str)
		{
			return default(CornerRadius);
		}

		public static bool TryParse(string str, out CornerRadius result)
		{
			result = default(CornerRadius);
			return false;
		}
	}
}
