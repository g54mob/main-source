namespace Noesis
{
	public struct Matrix
	{
		private float _m11;

		private float _m12;

		private float _m21;

		private float _m22;

		private float _offsetX;

		private float _offsetY;

		private static readonly Matrix _identity;

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

		public static Matrix Identity => default(Matrix);

		public bool IsIdentity => false;

		public float Determinant => 0f;

		public bool HasInverse => false;

		public Matrix(float m11, float m12, float m21, float m22, float offsetX, float offsetY)
		{
			_m11 = 0f;
			_m12 = 0f;
			_m21 = 0f;
			_m22 = 0f;
			_offsetX = 0f;
			_offsetY = 0f;
		}

		public void SetIdentity()
		{
		}

		public static Matrix operator *(Matrix m0, Matrix m1)
		{
			return default(Matrix);
		}

		public static Matrix Multiply(Matrix m0, Matrix m1)
		{
			return default(Matrix);
		}

		public void Append(Matrix matrix)
		{
		}

		public void Prepend(Matrix matrix)
		{
		}

		public void Rotate(float angle)
		{
		}

		public void RotatePrepend(float angle)
		{
		}

		public void RotateAt(float angle, float centerX, float centerY)
		{
		}

		public void RotateAtPrepend(float angle, float centerX, float centerY)
		{
		}

		public void Scale(float scaleX, float scaleY)
		{
		}

		public void ScalePrepend(float scaleX, float scaleY)
		{
		}

		public void ScaleAt(float scaleX, float scaleY, float centerX, float centerY)
		{
		}

		public void ScaleAtPrepend(float scaleX, float scaleY, float centerX, float centerY)
		{
		}

		public void Skew(float skewX, float skewY)
		{
		}

		public void SkewPrepend(float skewX, float skewY)
		{
		}

		public void Translate(float offsetX, float offsetY)
		{
		}

		public void TranslatePrepend(float offsetX, float offsetY)
		{
		}

		public Point Transform(Point point)
		{
			return default(Point);
		}

		public void Transform(Point[] points)
		{
		}

		public Vector Transform(Vector vector)
		{
			return default(Vector);
		}

		public void Transform(Vector[] vectors)
		{
		}

		public void Invert()
		{
		}

		public static bool operator ==(Matrix matrix1, Matrix matrix2)
		{
			return false;
		}

		public static bool operator !=(Matrix matrix1, Matrix matrix2)
		{
			return false;
		}

		public static bool Equals(Matrix matrix1, Matrix matrix2)
		{
			return false;
		}

		public override bool Equals(object o)
		{
			return false;
		}

		public bool Equals(Matrix value)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		private static Matrix CreateRotationRadians(float angle)
		{
			return default(Matrix);
		}

		private static Matrix CreateRotationRadians(float angle, float centerX, float centerY)
		{
			return default(Matrix);
		}

		private static Matrix CreateScaling(float scaleX, float scaleY)
		{
			return default(Matrix);
		}

		private static Matrix CreateScaling(float scaleX, float scaleY, float centerX, float centerY)
		{
			return default(Matrix);
		}

		private static Matrix CreateSkewRadians(float skewX, float skewY)
		{
			return default(Matrix);
		}

		private static Matrix CreateTranslation(float offsetX, float offsetY)
		{
			return default(Matrix);
		}

		private void MultiplyPoint(ref float x, ref float y)
		{
		}

		private void MultiplyVector(ref float x, ref float y)
		{
		}
	}
}
