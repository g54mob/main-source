using System;
using NGenerics.DataStructures.General;
using NGenerics.Util;

namespace NGenerics.DataStructures.Mathematical
{
	public class VectorN : VectorBase<double>
	{
		private double[] dimensions;

		public override double this[int index]
		{
			get
			{
				return dimensions[index];
			}
			set
			{
				dimensions[index] = value;
			}
		}

		public VectorN(int dimensionCount)
			: base(dimensionCount)
		{
			if (dimensionCount < 1)
			{
				throw new ArgumentOutOfRangeException("dimensionCount");
			}
			dimensions = new double[dimensionCount];
		}

		public override double AbsoluteMaximum()
		{
			int index = AbsoluteMaximumIndex();
			return Math.Abs(this[index]);
		}

		public override int AbsoluteMaximumIndex()
		{
			int result = 0;
			double num = Math.Abs(this[0]);
			for (int i = 1; i < base.DimensionCount; i++)
			{
				double num2 = Math.Abs(this[i]);
				if (num2 > num)
				{
					result = i;
					num = num2;
				}
			}
			return result;
		}

		public override double AbsoluteMinimum()
		{
			int index = AbsoluteMinimumIndex();
			return Math.Abs(this[index]);
		}

		public override int AbsoluteMinimumIndex()
		{
			int result = 0;
			double num = Math.Abs(this[0]);
			for (int i = 1; i < base.DimensionCount; i++)
			{
				double num2 = Math.Abs(this[i]);
				if (num2 < num)
				{
					result = i;
					num = num2;
				}
			}
			return result;
		}

		private static void AddInternal(IVector<double> left, IVector<double> right)
		{
			for (int i = 0; i < left.DimensionCount; i++)
			{
				left[i] += right[i];
			}
		}

		private static void AddInternal(IVector<double> left, double number)
		{
			for (int i = 0; i < left.DimensionCount; i++)
			{
				left[i] += number;
			}
		}

		protected override void AddSafe(IVector<double> vector)
		{
			VectorBase<double>.CheckDimensionsEqual(this, vector);
			AddInternal(this, vector);
		}

		public override void Add(double number)
		{
			AddInternal(this, number);
		}

		protected override IVector<double> CrossProductSafe(IVector<double> vector)
		{
			double num;
			double num2;
			double num3;
			if (base.DimensionCount == 3)
			{
				num = this[0];
				num2 = this[1];
				num3 = this[2];
			}
			else
			{
				num = this[0];
				num2 = this[1];
				num3 = 0.0;
			}
			double num4;
			double num5;
			double num6;
			if (vector.DimensionCount == 3)
			{
				num4 = vector[0];
				num5 = vector[1];
				num6 = vector[2];
			}
			else
			{
				num4 = vector[0];
				num5 = vector[1];
				num6 = 0.0;
			}
			return new Vector3D(num2 * num6 - num3 * num5, num3 * num4 - num * num6, num * num5 - num2 * num4);
		}

		public override void Decrement()
		{
			AddInternal(this, -1.0);
		}

		protected override IVector<double> DeepClone()
		{
			return new VectorN(base.DimensionCount)
			{
				dimensions = (double[])dimensions.Clone()
			};
		}

		protected override void DivideSafe(IVector<double> vector)
		{
			DivideInternal(this, vector);
		}

		public override void Divide(double number)
		{
			MultiplyInternal(this, 1.0 / number);
		}

		private static void DivideInternal(IVector<double> left, IVector<double> right)
		{
			for (int i = 0; i < left.DimensionCount; i++)
			{
				left[i] /= right[i];
			}
		}

		protected override double DotProductSafe(IVector<double> vector)
		{
			double num = 0.0;
			for (int i = 0; i < base.DimensionCount; i++)
			{
				num += this[i] * vector[i];
			}
			return num;
		}

		private static VectorN FromMatrixInternal(ObjectMatrix<double> matrix)
		{
			if (matrix.Columns != 1)
			{
				throw new InvalidCastException("matrix must have only 1 column");
			}
			VectorN vectorN = new VectorN(matrix.Rows);
			for (int i = 0; i < matrix.Rows; i++)
			{
				vectorN[i] = matrix.GetValue(i, 0);
			}
			return vectorN;
		}

		public static VectorN GetUnitVector(int dimensionCount)
		{
			VectorN vectorN = new VectorN(dimensionCount);
			for (int i = 0; i < dimensionCount; i++)
			{
				vectorN[i] = 1.0;
			}
			return vectorN;
		}

		public static VectorN GetZeroVector(int dimensionCount)
		{
			return new VectorN(dimensionCount);
		}

		public override void Increment()
		{
			AddInternal(this, 1.0);
		}

		public override double Magnitude()
		{
			double num = 0.0;
			for (int i = 0; i < base.DimensionCount; i++)
			{
				double num2 = this[i];
				num += num2 * num2;
			}
			return Math.Sqrt(num);
		}

		public override int MaximumIndex()
		{
			int result = 0;
			double num = this[0];
			for (int i = 1; i < base.DimensionCount; i++)
			{
				double num2 = this[i];
				if (num < num2)
				{
					result = i;
					num = num2;
				}
			}
			return result;
		}

		public override int MinimumIndex()
		{
			int result = 0;
			double num = this[0];
			for (int i = 1; i < base.DimensionCount; i++)
			{
				double num2 = this[i];
				if (num > num2)
				{
					result = i;
					num = num2;
				}
			}
			return result;
		}

		protected override IMatrix<double> MultiplySafe(IVector<double> vector)
		{
			return MultiplyInternal(this, vector);
		}

		public override void Multiply(double number)
		{
			MultiplyInternal(this, number);
		}

		private static Matrix MultiplyInternal(IVector<double> left, IVector<double> right)
		{
			Matrix matrix = new Matrix(left.DimensionCount, right.DimensionCount);
			for (int i = 0; i < left.DimensionCount; i++)
			{
				for (int j = 0; j < right.DimensionCount; j++)
				{
					matrix.SetValue(i, j, left[i] * right[j]);
				}
			}
			return matrix;
		}

		private static void MultiplyInternal(IVector<double> left, double right)
		{
			for (int i = 0; i < left.DimensionCount; i++)
			{
				left[i] *= right;
			}
		}

		public override void Negate()
		{
			for (int i = 0; i < base.DimensionCount; i++)
			{
				this[i] *= -1.0;
			}
		}

		public override void Normalize()
		{
			double num = Magnitude();
			for (int i = 0; i < base.DimensionCount; i++)
			{
				this[i] /= num;
			}
		}

		public override double Product()
		{
			double num = 1.0;
			for (int i = 0; i < base.DimensionCount; i++)
			{
				num *= this[i];
			}
			return num;
		}

		public override double Sum()
		{
			double num = 0.0;
			for (int i = 0; i < base.DimensionCount; i++)
			{
				num += this[i];
			}
			return num;
		}

		protected override void SubtractSafe(IVector<double> vector)
		{
			SubtractInternal(this, vector);
		}

		public override void Subtract(double number)
		{
			AddInternal(this, 0.0 - number);
		}

		private static void SubtractInternal(IVector<double> left, IVector<double> right)
		{
			for (int i = 0; i < left.DimensionCount; i++)
			{
				left[i] -= right[i];
			}
		}

		public void Swap(VectorN vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			VectorBase<double>.CheckDimensionsEqual(this, vector);
			double[] array = dimensions;
			dimensions = vector.dimensions;
			vector.dimensions = array;
		}

		public override double[] ToArray()
		{
			return (double[])dimensions.Clone();
		}

		public override IMatrix<double> ToMatrix()
		{
			return ToMatrixInternal(this);
		}

		private static Matrix ToMatrixInternal(IVector<double> vector)
		{
			Matrix matrix = new Matrix(vector.DimensionCount, 1);
			for (int i = 0; i < vector.DimensionCount; i++)
			{
				matrix.SetValue(i, 0, vector[i]);
			}
			return matrix;
		}

		public static implicit operator Matrix(VectorN vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			return ToMatrixInternal(vector);
		}

		public static explicit operator VectorN(ObjectMatrix<double> matrix)
		{
			Guard.ArgumentNotNull(matrix, "matrix");
			return FromMatrixInternal(matrix);
		}

		public static bool operator >(VectorN left, IVector<double> right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			return left.Magnitude() > right.Magnitude();
		}

		public static bool operator <(VectorN left, IVector<double> right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			return left.Magnitude() < right.Magnitude();
		}

		public static bool operator >=(VectorN left, IVector<double> right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			return left.Magnitude() >= right.Magnitude();
		}

		public static bool operator <=(VectorN left, IVector<double> right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			return left.Magnitude() <= right.Magnitude();
		}
	}
}
