using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NGenerics.Util;

namespace NGenerics.DataStructures.Mathematical
{
	public class Vector3D : VectorBase<double>
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
				case 2:
					return Z;
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
				case 2:
					Z = value;
					break;
				default:
					throw new ArgumentOutOfRangeException("index");
				}
			}
		}

		public double X { get; set; }

		public double Y { get; set; }

		public double Z { get; set; }

		public static Vector3D ZeroVector
		{
			get
			{
				return new Vector3D();
			}
		}

		public static Vector3D UnitVector
		{
			get
			{
				return new Vector3D(1.0, 1.0, 1.0);
			}
		}

		public Vector3D()
			: base(3)
		{
		}

		public Vector3D(double x, double y, double z)
			: base(3)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public override double AbsoluteMaximum()
		{
			double val = Math.Abs(X);
			double val2 = Math.Abs(Y);
			double val3 = Math.Abs(Z);
			return Math.Max(val, Math.Max(val2, val3));
		}

		public override int AbsoluteMaximumIndex()
		{
			double num = Math.Abs(X);
			double num2 = Math.Abs(Y);
			double num3 = Math.Abs(Z);
			if (num > num2)
			{
				if (num > num3)
				{
					return 0;
				}
				return 2;
			}
			if (num2 > num3)
			{
				return 1;
			}
			return 2;
		}

		public override double AbsoluteMinimum()
		{
			double val = Math.Abs(X);
			double val2 = Math.Abs(Y);
			double val3 = Math.Abs(Z);
			return Math.Min(val, Math.Min(val2, val3));
		}

		public override int AbsoluteMinimumIndex()
		{
			double num = Math.Abs(X);
			double num2 = Math.Abs(Y);
			double num3 = Math.Abs(Z);
			if (num < num2)
			{
				if (num < num3)
				{
					return 0;
				}
				return 2;
			}
			if (num2 < num3)
			{
				return 1;
			}
			return 2;
		}

		public override void Add(double number)
		{
			AddInternal(this, number);
		}

		public void Add(Vector3D vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			AddInternal(this, vector);
		}

		private static void AddInternal(Vector3D left, double right)
		{
			left.X += right;
			left.Y += right;
			left.Z += right;
		}

		private static void AddInternal(Vector3D left, Vector3D right)
		{
			left.X += right.X;
			left.Y += right.Y;
			left.Z += right.Z;
		}

		protected override void AddSafe(IVector<double> vector)
		{
			X += vector[0];
			Y += vector[1];
			Z += vector[2];
		}

		public override void Clear()
		{
			X = 0.0;
			Y = 0.0;
			Z = 0.0;
		}

		internal Vector3D CloneInternal()
		{
			return new Vector3D
			{
				X = X,
				Y = Y,
				Z = Z
			};
		}

		public Vector3D CrossProduct(Vector2D vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			return new Vector3D((0.0 - Z) * vector.Y, Z * vector.X, X * vector.Y - Y * vector.X);
		}

		public Vector3D CrossProduct(Vector3D vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			return new Vector3D(Y * vector.Z - Z * vector.Y, Z * vector.X - X * vector.Z, X * vector.Y - Y * vector.X);
		}

		protected override IVector<double> CrossProductSafe(IVector<double> vector)
		{
			if (vector.DimensionCount == 2)
			{
				return new Vector3D((0.0 - Z) * vector[1], Z * vector[0], X * vector[1] - Y * vector[0]);
			}
			return new Vector3D(Y * vector[2] - Z * vector[1], Z * vector[0] - X * vector[2], X * vector[1] - Y * vector[0]);
		}

		public override void Decrement()
		{
			AddInternal(this, -1.0);
		}

		protected override IVector<double> DeepClone()
		{
			return CloneInternal();
		}

		public override void Divide(double number)
		{
			MultiplyInternal(this, 1.0 / number);
		}

		public void Divide(Vector3D vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			DivideInternal(this, vector);
		}

		private static void DivideInternal(Vector3D left, Vector3D right)
		{
			left.X /= right.X;
			left.X /= right.Y;
			left.X /= right.Z;
			left.Y /= right.X;
			left.Y /= right.Y;
			left.Y /= right.Z;
			left.Z /= right.X;
			left.Z /= right.Y;
			left.Z /= right.Z;
		}

		protected override void DivideSafe(IVector<double> vector)
		{
			X /= vector[0];
			X /= vector[1];
			X /= vector[2];
			Y /= vector[0];
			Y /= vector[1];
			Y /= vector[2];
			Z /= vector[0];
			Z /= vector[1];
			Z /= vector[2];
		}

		public double DotProduct(Vector3D vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			return X * vector.X + Y * vector.Y + Z * vector.Z;
		}

		protected override double DotProductSafe(IVector<double> vector)
		{
			return X * vector[0] + Y * vector[1] + Z * vector[2];
		}

		private static Vector3D FromMatrixInternal(IMatrix<double> matrix)
		{
			if (matrix.Columns != 1)
			{
				throw new InvalidCastException("matrix must have only 1 column");
			}
			if (matrix.Rows > 3)
			{
				throw new InvalidCastException("matrix must at most 3 rows");
			}
			switch (matrix.Rows)
			{
			case 1:
				return new Vector3D(matrix[0, 0], 0.0, 0.0);
			case 2:
				return new Vector3D(matrix[0, 0], matrix[1, 0], 0.0);
			default:
				return new Vector3D(matrix[0, 0], matrix[1, 0], matrix[2, 0]);
			}
		}

		public override IEnumerator<double> GetEnumerator()
		{
			yield return X;
			yield return Y;
			yield return Z;
		}

		public override void Increment()
		{
			AddInternal(this, 1.0);
		}

		public override double Magnitude()
		{
			return Math.Sqrt(X * X + Y * Y + Z * Z);
		}

		public override double Maximum()
		{
			return Math.Max(X, Math.Max(Y, Z));
		}

		public override int MaximumIndex()
		{
			if (X > Y)
			{
				if (!(X > Z))
				{
					return 2;
				}
				return 0;
			}
			if (!(Y > Z))
			{
				return 2;
			}
			return 1;
		}

		public override double Minimum()
		{
			return Math.Min(X, Math.Min(Y, Z));
		}

		public override int MinimumIndex()
		{
			if (X < Y)
			{
				if (!(X < Z))
				{
					return 2;
				}
				return 0;
			}
			if (!(Y < Z))
			{
				return 2;
			}
			return 1;
		}

		public override void Multiply(double number)
		{
			MultiplyInternal(this, number);
		}

		public Matrix Multiply(Vector3D vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			return MultiplyInternal(this, vector);
		}

		private static void MultiplyInternal(Vector3D left, double right)
		{
			left.X *= right;
			left.Y *= right;
			left.Z *= right;
		}

		private static Matrix MultiplyInternal(Vector3D left, Vector3D right)
		{
			Matrix matrix = new Matrix(3, 3);
			matrix.SetValue(0, 0, left.X * right.X);
			matrix.SetValue(0, 1, left.X * right.Y);
			matrix.SetValue(0, 2, left.X * right.Z);
			matrix.SetValue(1, 0, left.Y * right.X);
			matrix.SetValue(1, 1, left.Y * right.Y);
			matrix.SetValue(1, 2, left.Y * right.Z);
			matrix.SetValue(2, 0, left.Z * right.X);
			matrix.SetValue(2, 1, left.Z * right.Y);
			matrix.SetValue(2, 2, left.Z * right.Z);
			return matrix;
		}

		protected override IMatrix<double> MultiplySafe(IVector<double> vector)
		{
			Matrix matrix = new Matrix(3, 3);
			matrix.SetValue(0, 0, X * vector[0]);
			matrix.SetValue(0, 1, X * vector[1]);
			matrix.SetValue(0, 2, X * vector[2]);
			matrix.SetValue(1, 0, Y * vector[0]);
			matrix.SetValue(1, 1, Y * vector[1]);
			matrix.SetValue(1, 2, Y * vector[2]);
			matrix.SetValue(2, 0, Z * vector[0]);
			matrix.SetValue(2, 1, Z * vector[1]);
			matrix.SetValue(2, 2, Z * vector[2]);
			return matrix;
		}

		public override void Negate()
		{
			X *= -1.0;
			Y *= -1.0;
			Z *= -1.0;
		}

		public override void Normalize()
		{
			double num = Magnitude();
			X /= num;
			Y /= num;
			Z /= num;
		}

		public override double Product()
		{
			return X * Y * Z;
		}

		protected override void SubtractSafe(IVector<double> vector)
		{
			X -= vector[0];
			Y -= vector[1];
			Z -= vector[2];
		}

		public override double Sum()
		{
			return X + Y + Z;
		}

		protected override void SetValuesSafe(double[] values)
		{
			X = values[0];
			Y = values[1];
			Z = values[2];
		}

		public override void Subtract(double number)
		{
			AddInternal(this, 0.0 - number);
		}

		public void Subtract(Vector3D vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			SubtractInternal(this, vector);
		}

		private static void SubtractInternal(Vector3D left, Vector3D right)
		{
			left.X -= right.X;
			left.Y -= right.Y;
			left.Z -= right.Z;
		}

		public void Swap(Vector3D other)
		{
			Guard.ArgumentNotNull(other, "other");
			double x = X;
			X = other.X;
			other.X = x;
			double y = Y;
			Y = other.Y;
			other.Y = y;
			double z = Z;
			Z = other.Z;
			other.Z = z;
		}

		protected override void SwapSafe(IVector<double> other)
		{
			double x = X;
			X = other[0];
			other[0] = x;
			double y = Y;
			Y = other[1];
			other[1] = y;
			double z = Z;
			Z = other[2];
			other[2] = z;
		}

		public override double[] ToArray()
		{
			return new double[3] { X, Y, Z };
		}

		public override IMatrix<double> ToMatrix()
		{
			return ToMatrixInternal(this);
		}

		private static Matrix ToMatrixInternal(Vector3D vector)
		{
			return new Matrix(3, 1, new double[3] { vector.X, vector.Y, vector.Z });
		}

		public static Vector3D operator /(Vector3D left, double right)
		{
			Guard.ArgumentNotNull(left, "left");
			Vector3D vector3D = left.CloneInternal();
			MultiplyInternal(vector3D, 1.0 / right);
			return vector3D;
		}

		public static Vector3D operator /(Vector3D left, Vector3D right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			Vector3D vector3D = left.CloneInternal();
			DivideInternal(vector3D, right);
			return vector3D;
		}

		public static Matrix operator *(Vector3D left, Vector3D right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			return MultiplyInternal(left, right);
		}

		public static Vector3D operator *(Vector3D left, double right)
		{
			Guard.ArgumentNotNull(left, "left");
			Vector3D vector3D = left.CloneInternal();
			MultiplyInternal(vector3D, right);
			return vector3D;
		}

		public static Vector3D operator +(Vector3D left, double right)
		{
			Guard.ArgumentNotNull(left, "left");
			Vector3D vector3D = left.CloneInternal();
			AddInternal(vector3D, right);
			return vector3D;
		}

		public static Vector3D operator +(Vector3D left, Vector3D right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			Vector3D vector3D = left.CloneInternal();
			AddInternal(vector3D, right);
			return vector3D;
		}

		public static Vector3D operator ++(Vector3D right)
		{
			Guard.ArgumentNotNull(right, "right");
			Vector3D vector3D = right.CloneInternal();
			AddInternal(vector3D, 1.0);
			return vector3D;
		}

		public static Vector3D operator -(Vector3D left, Vector3D right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			Vector3D vector3D = left.CloneInternal();
			SubtractInternal(vector3D, right);
			return vector3D;
		}

		public static Vector3D operator -(Vector3D left, double right)
		{
			Guard.ArgumentNotNull(left, "left");
			Vector3D vector3D = left.CloneInternal();
			AddInternal(vector3D, 0.0 - right);
			return vector3D;
		}

		public static Vector3D operator -(Vector3D right)
		{
			Guard.ArgumentNotNull(right, "right");
			Vector3D vector3D = right.CloneInternal();
			vector3D.Negate();
			return vector3D;
		}

		public static Vector3D operator --(Vector3D right)
		{
			Guard.ArgumentNotNull(right, "right");
			Vector3D vector3D = right.CloneInternal();
			AddInternal(vector3D, -1.0);
			return vector3D;
		}

		public static implicit operator Matrix(Vector3D vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			return ToMatrixInternal(vector);
		}

		public static explicit operator Vector3D(ObjectMatrix<double> matrix)
		{
			Guard.ArgumentNotNull(matrix, "matrix");
			return FromMatrixInternal(matrix);
		}

		public static bool operator >(Vector3D left, IVector<double> right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			return left.Magnitude() > right.Magnitude();
		}

		public static bool operator <(Vector3D left, IVector<double> right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			return left.Magnitude() < right.Magnitude();
		}

		public static bool operator >=(Vector3D left, IVector<double> right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			return left.Magnitude() >= right.Magnitude();
		}

		public static bool operator <=(Vector3D left, IVector<double> right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			return left.Magnitude() <= right.Magnitude();
		}
	}
}
