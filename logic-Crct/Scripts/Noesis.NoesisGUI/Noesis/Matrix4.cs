namespace Noesis
{
	public struct Matrix4
	{
		private Vector4 _r0;

		private Vector4 _r1;

		private Vector4 _r2;

		private Vector4 _r3;

		public Vector4 this[uint i]
		{
			get
			{
				return default(Vector4);
			}
			set
			{
			}
		}

		public static Matrix4 Identity => default(Matrix4);

		public Matrix4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23, float m30, float m31, float m32, float m33)
		{
			_r0 = default(Vector4);
			_r1 = default(Vector4);
			_r2 = default(Vector4);
			_r3 = default(Vector4);
		}

		public Matrix4(Vector4 v0, Vector4 v1, Vector4 v2, Vector4 v3)
		{
			_r0 = default(Vector4);
			_r1 = default(Vector4);
			_r2 = default(Vector4);
			_r3 = default(Vector4);
		}

		public static Matrix4 operator *(Matrix4 m, float f)
		{
			return default(Matrix4);
		}

		public static Matrix4 operator *(float f, Matrix4 m)
		{
			return default(Matrix4);
		}

		public static Matrix4 operator /(Matrix4 m, float f)
		{
			return default(Matrix4);
		}

		public static Vector4 operator *(Vector4 v, Matrix4 m)
		{
			return default(Vector4);
		}

		public static Matrix4 operator *(Matrix4 m0, Matrix4 m1)
		{
			return default(Matrix4);
		}

		public static bool operator ==(Matrix4 m0, Matrix4 m1)
		{
			return false;
		}

		public static bool operator !=(Matrix4 m0, Matrix4 m1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(Matrix4 m)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static Matrix4 Scale(float scaleX, float scaleY, float scaleZ)
		{
			return default(Matrix4);
		}

		public static Matrix4 RotX(float radians)
		{
			return default(Matrix4);
		}

		public static Matrix4 RotY(float radians)
		{
			return default(Matrix4);
		}

		public static Matrix4 RotZ(float radians)
		{
			return default(Matrix4);
		}

		public static Matrix4 Ortho(float width, float height, float zNear, float zFar)
		{
			return default(Matrix4);
		}

		public static Matrix4 Ortho(float left, float right, float bottom, float top, float zNear, float zFar)
		{
			return default(Matrix4);
		}

		public static Matrix4 Perspective(float width, float height, float zNear, float zFar)
		{
			return default(Matrix4);
		}

		public static Matrix4 Perspective(float left, float right, float bottom, float top, float zNear, float zFar)
		{
			return default(Matrix4);
		}

		public static Matrix4 PerspectiveFov(float fovY, float aspect, float zNear, float zFar)
		{
			return default(Matrix4);
		}

		public static Matrix4 Viewport(float width, float height)
		{
			return default(Matrix4);
		}

		public static Matrix4 Transpose(Matrix4 m)
		{
			return default(Matrix4);
		}

		public static bool IsAffine(Matrix4 m)
		{
			return false;
		}

		public static float Determinant(Matrix4 m)
		{
			return 0f;
		}

		public static Matrix4 Inverse(Matrix4 m)
		{
			return default(Matrix4);
		}

		public static Matrix4 Inverse(Matrix4 m, float determinant)
		{
			return default(Matrix4);
		}

		public Rect TransformBounds(Rect bounds)
		{
			return default(Rect);
		}
	}
}
