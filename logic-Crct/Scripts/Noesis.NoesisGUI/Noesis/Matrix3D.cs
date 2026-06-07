namespace Noesis
{
	public struct Matrix3D
	{
		private float _m11;

		private float _m12;

		private float _m13;

		private float _m21;

		private float _m22;

		private float _m23;

		private float _m31;

		private float _m32;

		private float _m33;

		private float _offsetX;

		private float _offsetY;

		private float _offsetZ;

		private static readonly Matrix3D _identity;

		public float M11
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float M12
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float M13
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float M21
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float M22
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float M23
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float M31
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float M32
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float M33
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float OffsetX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float OffsetY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float OffsetZ
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public static Matrix3D Identity => default(Matrix3D);

		public bool IsIdentity => false;

		public float Determinant => 0f;

		public bool HasInverse => false;

		public Matrix3D(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33, float offsetX, float offsetY, float offsetZ)
		{
			_m11 = 0f;
			_m12 = 0f;
			_m13 = 0f;
			_m21 = 0f;
			_m22 = 0f;
			_m23 = 0f;
			_m31 = 0f;
			_m32 = 0f;
			_m33 = 0f;
			_offsetX = 0f;
			_offsetY = 0f;
			_offsetZ = 0f;
		}

		public void SetIdentity()
		{
		}

		public static Matrix3D operator *(Matrix3D m0, Matrix3D m1)
		{
			return default(Matrix3D);
		}

		public static Matrix3D Multiply(Matrix3D m0, Matrix3D m1)
		{
			return default(Matrix3D);
		}

		public void Append(Matrix3D matrix)
		{
		}

		public void Prepend(Matrix3D matrix)
		{
		}

		public Matrix3D Scale(float scaleX, float scaleY, float scaleZ)
		{
			return default(Matrix3D);
		}

		public Matrix3D Translate(float transX, float transY, float transZ)
		{
			return default(Matrix3D);
		}

		public Matrix3D RotateX(float angle)
		{
			return default(Matrix3D);
		}

		public Matrix3D RotateY(float angle)
		{
			return default(Matrix3D);
		}

		public Matrix3D RotateZ(float angle)
		{
			return default(Matrix3D);
		}

		public Point3D Transform(Point3D point)
		{
			return default(Point3D);
		}

		public Vector3D Transform(Vector3D vector)
		{
			return default(Vector3D);
		}

		public void Invert()
		{
		}

		private void GetSinCos(float angle, out float sn, out float cs)
		{
			sn = default(float);
			cs = default(float);
		}
	}
}
