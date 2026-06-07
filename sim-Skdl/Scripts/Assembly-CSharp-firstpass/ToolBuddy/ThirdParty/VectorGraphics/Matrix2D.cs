using UnityEngine;

namespace ToolBuddy.ThirdParty.VectorGraphics
{
	public struct Matrix2D
	{
		public float m00;

		public float m10;

		public float m01;

		public float m11;

		public float m02;

		public float m12;

		private static readonly Matrix2D zeroMatrix;

		private static readonly Matrix2D identityMatrix;

		public float this[int row, int column]
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float this[int index]
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public static Matrix2D zero => default(Matrix2D);

		public static Matrix2D identity => default(Matrix2D);

		public Matrix2D(Vector2 column0, Vector2 column1, Vector2 column2)
		{
			m00 = 0f;
			m10 = 0f;
			m01 = 0f;
			m11 = 0f;
			m02 = 0f;
			m12 = 0f;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public static Matrix2D operator *(Matrix2D lhs, Matrix2D rhs)
		{
			return default(Matrix2D);
		}

		public static Vector2 operator *(Matrix2D lhs, Vector2 vector)
		{
			return default(Vector2);
		}

		public static bool operator ==(Matrix2D lhs, Matrix2D rhs)
		{
			return false;
		}

		public static bool operator !=(Matrix2D lhs, Matrix2D rhs)
		{
			return false;
		}

		public Vector2 GetColumn(int index)
		{
			return default(Vector2);
		}

		public Vector3 GetRow(int index)
		{
			return default(Vector3);
		}

		public void SetColumn(int index, Vector2 column)
		{
		}

		public void SetRow(int index, Vector3 row)
		{
		}

		public Vector2 MultiplyPoint(Vector2 point)
		{
			return default(Vector2);
		}

		public Vector2 MultiplyVector(Vector2 vector)
		{
			return default(Vector2);
		}

		public Matrix2D Inverse()
		{
			return default(Matrix2D);
		}

		public static Matrix2D Scale(Vector2 vector)
		{
			return default(Matrix2D);
		}

		public static Matrix2D Translate(Vector2 vector)
		{
			return default(Matrix2D);
		}

		public static Matrix2D RotateRH(float angleRadians)
		{
			return default(Matrix2D);
		}

		public static Matrix2D RotateLH(float angleRadians)
		{
			return default(Matrix2D);
		}

		public static Matrix2D SkewX(float angleRadians)
		{
			return default(Matrix2D);
		}

		public static Matrix2D SkewY(float angleRadians)
		{
			return default(Matrix2D);
		}

		public override string ToString()
		{
			return null;
		}

		public string ToString(string format)
		{
			return null;
		}
	}
}
