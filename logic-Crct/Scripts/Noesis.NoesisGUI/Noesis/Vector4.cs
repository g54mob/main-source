namespace Noesis
{
	public struct Vector4
	{
		private float _x;

		private float _y;

		private float _z;

		private float _w;

		public float this[uint i]
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float X
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Y
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Z
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float W
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Vector XY => default(Vector);

		public Vector XZ => default(Vector);

		public Vector XW => default(Vector);

		public Vector YZ => default(Vector);

		public Vector YW => default(Vector);

		public static Vector4 Zero => default(Vector4);

		public static Vector4 XAxis => default(Vector4);

		public static Vector4 YAxis => default(Vector4);

		public static Vector4 ZAxis => default(Vector4);

		public static Vector4 WAxis => default(Vector4);

		public Vector4(float x, float y, float z, float w)
		{
			_x = 0f;
			_y = 0f;
			_z = 0f;
			_w = 0f;
		}

		public Vector4(Vector v, float z, float w)
		{
			_x = 0f;
			_y = 0f;
			_z = 0f;
			_w = 0f;
		}

		public static Vector4 operator +(Vector4 v)
		{
			return default(Vector4);
		}

		public static Vector4 operator -(Vector4 v)
		{
			return default(Vector4);
		}

		public static Vector4 operator +(Vector4 v0, Vector4 v1)
		{
			return default(Vector4);
		}

		public static Vector4 operator -(Vector4 v0, Vector4 v1)
		{
			return default(Vector4);
		}

		public static Vector4 operator *(Vector4 v, float f)
		{
			return default(Vector4);
		}

		public static Vector4 operator *(float f, Vector4 v)
		{
			return default(Vector4);
		}

		public static Vector4 operator /(Vector4 v, float f)
		{
			return default(Vector4);
		}

		public static bool operator ==(Vector4 v0, Vector4 v1)
		{
			return false;
		}

		public static bool operator !=(Vector4 v0, Vector4 v1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(Vector4 v)
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

		public static float LengthSquared(Vector4 v)
		{
			return 0f;
		}

		public static float Length(Vector4 v)
		{
			return 0f;
		}

		public static Vector4 Normalize(Vector4 v)
		{
			return default(Vector4);
		}

		public static Vector Project(Vector4 v)
		{
			return default(Vector);
		}

		public static float Dot(Vector4 v0, Vector4 v1)
		{
			return 0f;
		}
	}
}
