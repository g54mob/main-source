using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NGenerics.Util;

namespace NGenerics.DataStructures.Mathematical
{
	public class Vector2D : VectorBase<double>
	{
		public override double this[int index]
		{
			get
			{
				switch (index)
				{
				case 0:
					return X;
				case 1:
					return Y;
				default:
					throw new ArgumentOutOfRangeException("index");
				}
			}
			set
			{
				switch (index)
				{
				case 0:
					X = value;
					break;
				case 1:
					Y = value;
					break;
				default:
					throw new ArgumentOutOfRangeException("index");
				}
			}
		}

		public double X { get; set; }

		public double Y { get; set; }

		public static Vector2D UnitVector
		{
			get
			{
				return new Vector2D(1.0, 1.0);
			}
		}

		public static Vector2D ZeroVector
		{
			get
			{
				return new Vector2D();
			}
		}

		public Vector2D()
			: base(2)
		{
		}

		public Vector2D(double x, double y)
			: base(2)
		{
			X = x;
			Y = y;
		}

		public override double AbsoluteMaximum()
		{
			double val = Math.Abs(X);
			double val2 = Math.Abs(Y);
			return Math.Max(val, val2);
		}

		public override int AbsoluteMaximumIndex()
		{
			double num = Math.Abs(X);
			double num2 = Math.Abs(Y);
			if (!(num > num2))
			{
				return 1;
			}
			return 0;
		}

		public override double AbsoluteMinimum()
		{
			double val = Math.Abs(X);
			double val2 = Math.Abs(Y);
			return Math.Min(val, val2);
		}

		public override int AbsoluteMinimumIndex()
		{
			double num = Math.Abs(X);
			double num2 = Math.Abs(Y);
			if (!(num < num2))
			{
				return 1;
			}
			return 0;
		}

		public override void Add(double number)
		{
			AddInternal(this, number);
		}

		public void Add(Vector2D vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			AddInternal(this, vector);
		}

		private static void AddInternal(Vector2D left, double right)
		{
			left.X += right;
			left.Y += right;
		}

		private static void AddInternal(Vector2D left, Vector2D right)
		{
			left.X += right.X;
			left.Y += right.Y;
		}

		protected override void AddSafe(IVector<double> vector)
		{
			X += vector[0];
			Y += vector[1];
		}

		public override void Clear()
		{
			X = 0.0;
			Y = 0.0;
		}

		internal Vector2D CloneInternal()
		{
			return new Vector2D
			{
				X = X,
				Y = Y
			};
		}

		public Vector3D CrossProduct(Vector3D vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			return new Vector3D(Y * vector.Z, (0.0 - X) * vector.Z, X * vector.Y - Y * vector.X);
		}

		public Vector3D CrossProduct(Vector2D vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			return new Vector3D(0.0, 0.0, X * vector.Y - Y * vector.Y);
		}

		protected override IVector<double> CrossProductSafe(IVector<double> vector)
		{
			if (vector.DimensionCount == 2)
			{
				return new Vector3D(0.0, 0.0, X * vector[1] - Y * vector[1]);
			}
			return new Vector3D(Y * vector[2], (0.0 - X) * vector[2], X * vector[1] - Y * vector[0]);
		}

		protected override IVector<double> DeepClone()
		{
			return CloneInternal();
		}

		public override void Decrement()
		{
			AddInternal(this, -1.0);
		}

		public override void Divide(double number)
		{
			MultiplyInternal(this, 1.0 / number);
		}

		public void Divide(Vector2D vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			DivideInternal(this, vector);
		}

		private static void DivideInternal(Vector2D left, Vector2D right)
		{
			left.X /= right.X;
			left.X /= right.Y;
			left.Y /= right.X;
			left.Y /= right.Y;
		}

		protected override void DivideSafe(IVector<double> vector)
		{
			X /= vector[0];
			X /= vector[1];
			Y /= vector[0];
			Y /= vector[1];
		}

		public double DotProduct(Vector2D vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			return X * vector.X + Y * vector.Y;
		}

		protected override double DotProductSafe(IVector<double> vector)
		{
			return X * vector[0] + Y * vector[1];
		}

		private static Vector2D FromMatrixInternal(IMatrix<double> matrix)
		{
			if (matrix.Columns != 1)
			{
				throw new InvalidCastException("matrix must have only 1 column");
			}
			if (matrix.Rows > 2)
			{
				throw new InvalidCastException("matrix must at most 2 rows");
			}
			if (matrix.Rows != 1)
			{
				return new Vector2D(matrix[0, 0], matrix[1, 0]);
			}
			return new Vector2D(matrix[0, 0], 0.0);
		}

		public override IEnumerator<double> GetEnumerator()
		{
			yield return X;
			yield return Y;
		}

		public override void Increment()
		{
			AddInternal(this, 1.0);
		}

		public override double Magnitude()
		{
			return Math.Sqrt(X * X + Y * Y);
		}

		public override double Maximum()
		{
			return Math.Max(X, Y);
		}

		public override int MaximumIndex()
		{
			if (!(X > Y))
			{
				return 1;
			}
			return 0;
		}

		public override double Minimum()
		{
			return Math.Min(X, Y);
		}

		public override int MinimumIndex()
		{
			if (!(X < Y))
			{
				return 1;
			}
			return 0;
		}

		public override void Multiply(double number)
		{
			MultiplyInternal(this, number);
		}

		public Matrix Multiply(Vector2D vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			return MultiplyInternal(this, vector);
		}

		private static void MultiplyInternal(Vector2D left, double right)
		{
			left.X *= right;
			left.Y *= right;
		}

		private static Matrix MultiplyInternal(Vector2D left, Vector2D right)
		{
			Matrix matrix = new Matrix(2, 2);
			matrix.SetValue(0, 0, left.X * right.X);
			matrix.SetValue(0, 1, left.X * right.Y);
			matrix.SetValue(1, 0, left.Y * right.X);
			matrix.SetValue(1, 1, left.Y * right.Y);
			return matrix;
		}

		protected override IMatrix<double> MultiplySafe(IVector<double> vector)
		{
			Matrix matrix = new Matrix(2, 2);
			matrix.SetValue(0, 0, X * vector[0]);
			matrix.SetValue(0, 1, X * vector[1]);
			matrix.SetValue(1, 0, Y * vector[0]);
			matrix.SetValue(1, 1, Y * vector[1]);
			return matrix;
		}

		public override void Negate()
		{
			X *= -1.0;
			Y *= -1.0;
		}

		public override void Normalize()
		{
			double num = Magnitude();
			X /= num;
			Y /= num;
		}

		protected override void SetValuesSafe(double[] values)
		{
			X = values[0];
			Y = values[1];
		}

		public override double Product()
		{
			return X * Y;
		}

		public override void Subtract(double number)
		{
			AddInternal(this, 0.0 - number);
		}

		public void Subtract(Vector2D vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			SubtractInternal(this, vector);
		}

		protected override void SubtractSafe(IVector<double> vector)
		{
			X -= vector[0];
			Y -= vector[1];
		}

		private static void SubtractInternal(Vector2D left, Vector2D right)
		{
			left.X -= right.X;
			left.Y -= right.Y;
		}

		public override double Sum()
		{
			return X + Y;
		}

		protected override void SwapSafe(IVector<double> other)
		{
			double x = X;
			X = other[0];
			other[0] = x;
			double y = Y;
			Y = other[1];
			other[1] = y;
		}

		public void Swap(Vector2D other)
		{
			Guard.ArgumentNotNull(other, "other");
			double x = X;
			X = other.X;
			other.X = x;
			double y = Y;
			Y = other.Y;
			other.Y = y;
		}

		public override double[] ToArray()
		{
			return new double[2] { X, Y };
		}

		public override IMatrix<double> ToMatrix()
		{
			return ToMatrixInternal(this);
		}

		private static Matrix ToMatrixInternal(Vector2D vector)
		{
			return new Matrix(2, 1, new double[2] { vector.X, vector.Y });
		}

		public static Vector2D operator /(Vector2D left, double right)
		{
			Guard.ArgumentNotNull(left, "left");
			Vector2D vector2D = left.CloneInternal();
			MultiplyInternal(vector2D, 1.0 / right);
			return vector2D;
		}

		public static Vector2D operator /(Vector2D left, Vector2D right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			Vector2D vector2D = left.CloneInternal();
			DivideInternal(vector2D, right);
			return vector2D;
		}

		public static Matrix operator *(Vector2D left, Vector2D right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			return MultiplyInternal(left, right);
		}

		public static Vector2D operator *(Vector2D left, double right)
		{
			Guard.ArgumentNotNull(left, "left");
			Vector2D vector2D = left.CloneInternal();
			MultiplyInternal(vector2D, right);
			return vector2D;
		}

		public static Vector2D operator +(Vector2D left, double right)
		{
			Guard.ArgumentNotNull(left, "left");
			Vector2D vector2D = left.CloneInternal();
			AddInternal(vector2D, right);
			return vector2D;
		}

		public static Vector2D operator +(Vector2D left, Vector2D right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			VectorBase<double>.CheckDimensionsEqual(left, right);
			Vector2D vector2D = left.CloneInternal();
			AddInternal(vector2D, right);
			return vector2D;
		}

		public static Vector2D operator ++(Vector2D right)
		{
			Guard.ArgumentNotNull(right, "right");
			Vector2D vector2D = right.CloneInternal();
			AddInternal(vector2D, 1.0);
			return vector2D;
		}

		public static Vector2D operator -(Vector2D left, Vector2D right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			Vector2D vector2D = left.CloneInternal();
			SubtractInternal(vector2D, right);
			return vector2D;
		}

		public static Vector2D operator -(Vector2D left, double right)
		{
			Guard.ArgumentNotNull(left, "left");
			Vector2D vector2D = left.CloneInternal();
			AddInternal(vector2D, 0.0 - right);
			return vector2D;
		}

		public static Vector2D operator -(Vector2D right)
		{
			Guard.ArgumentNotNull(right, "right");
			Vector2D vector2D = right.CloneInternal();
			vector2D.Negate();
			return vector2D;
		}

		public static Vector2D operator --(Vector2D right)
		{
			Guard.ArgumentNotNull(right, "right");
			Vector2D vector2D = right.CloneInternal();
			AddInternal(vector2D, -1.0);
			return vector2D;
		}

		public static implicit operator Matrix(Vector2D vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			return ToMatrixInternal(vector);
		}

		public static explicit operator Vector2D(ObjectMatrix<double> matrix)
		{
			Guard.ArgumentNotNull(matrix, "matrix");
			return FromMatrixInternal(matrix);
		}

		public static bool operator >(Vector2D left, IVector<double> right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			return left.Magnitude() > right.Magnitude();
		}

		public static bool operator <(Vector2D left, IVector<double> right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			return left.Magnitude() < right.Magnitude();
		}

		public static bool operator >=(Vector2D left, Vector2D right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			return left.Magnitude() >= right.Magnitude();
		}

		public static bool operator <=(Vector2D left, Vector2D right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			return left.Magnitude() <= right.Magnitude();
		}
	}
}
