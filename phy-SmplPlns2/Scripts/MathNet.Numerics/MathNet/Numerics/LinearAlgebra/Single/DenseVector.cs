using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Providers.LinearAlgebra;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Single
{
	[Serializable]
	[DebuggerDisplay("DenseVector {Count}-Single")]
	public class DenseVector : Vector
	{
		private readonly int _length;

		private readonly float[] _values;

		public float[] Values => _values;

		public DenseVector(DenseVectorStorage<float> storage)
			: base(storage)
		{
			_length = storage.Length;
			_values = storage.Data;
		}

		public DenseVector(int length)
			: this(new DenseVectorStorage<float>(length))
		{
		}

		public DenseVector(float[] storage)
			: this(new DenseVectorStorage<float>(storage.Length, storage))
		{
		}

		public static DenseVector OfVector(Vector<float> vector)
		{
			return new DenseVector(DenseVectorStorage<float>.OfVector(vector.Storage));
		}

		public static DenseVector OfArray(float[] array)
		{
			return new DenseVector(DenseVectorStorage<float>.OfVector(new DenseVectorStorage<float>(array.Length, array)));
		}

		public static DenseVector OfEnumerable(IEnumerable<float> enumerable)
		{
			return new DenseVector(DenseVectorStorage<float>.OfEnumerable(enumerable));
		}

		public static DenseVector OfIndexedEnumerable(int length, IEnumerable<Tuple<int, float>> enumerable)
		{
			return new DenseVector(DenseVectorStorage<float>.OfIndexedEnumerable(length, enumerable));
		}

		public static DenseVector OfIndexedEnumerable(int length, IEnumerable<(int, float)> enumerable)
		{
			return new DenseVector(DenseVectorStorage<float>.OfIndexedEnumerable(length, enumerable));
		}

		public static DenseVector Create(int length, float value)
		{
			if (value == 0f)
			{
				return new DenseVector(length);
			}
			return new DenseVector(DenseVectorStorage<float>.OfValue(length, value));
		}

		public static DenseVector Create(int length, Func<int, float> init)
		{
			return new DenseVector(DenseVectorStorage<float>.OfInit(length, init));
		}

		public static DenseVector CreateRandom(int length, IContinuousDistribution distribution)
		{
			float[] data = Generate.RandomSingle(length, distribution);
			return new DenseVector(new DenseVectorStorage<float>(length, data));
		}

		public static explicit operator float[](DenseVector vector)
		{
			if (vector == null)
			{
				throw new ArgumentNullException("vector");
			}
			return vector.Values;
		}

		public static implicit operator DenseVector(float[] array)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			return new DenseVector(array);
		}

		protected override void DoAdd(float scalar, Vector<float> result)
		{
			if (result is DenseVector denseVector)
			{
				float[] denseValues = denseVector._values;
				CommonParallel.For(0, _values.Length, 4096, delegate(int a, int b)
				{
					for (int i = a; i < b; i++)
					{
						denseValues[i] = _values[i] + scalar;
					}
				});
			}
			else
			{
				base.DoAdd(scalar, result);
			}
		}

		protected override void DoAdd(Vector<float> other, Vector<float> result)
		{
			if (other is DenseVector denseVector && result is DenseVector denseVector2)
			{
				LinearAlgebraControl.Provider.AddArrays(_values, denseVector._values, denseVector2._values);
			}
			else
			{
				base.DoAdd(other, result);
			}
		}

		public static DenseVector operator +(DenseVector leftSide, DenseVector rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (DenseVector)leftSide.Add(rightSide);
		}

		protected override void DoSubtract(float scalar, Vector<float> result)
		{
			if (result is DenseVector denseVector)
			{
				float[] denseValues = denseVector._values;
				CommonParallel.For(0, _values.Length, 4096, delegate(int a, int b)
				{
					for (int i = a; i < b; i++)
					{
						denseValues[i] = _values[i] - scalar;
					}
				});
			}
			else
			{
				base.DoSubtract(scalar, result);
			}
		}

		protected override void DoSubtract(Vector<float> other, Vector<float> result)
		{
			if (other is DenseVector denseVector && result is DenseVector denseVector2)
			{
				LinearAlgebraControl.Provider.SubtractArrays(_values, denseVector._values, denseVector2._values);
			}
			else
			{
				base.DoSubtract(other, result);
			}
		}

		public static DenseVector operator -(DenseVector rightSide)
		{
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			return (DenseVector)rightSide.Negate();
		}

		public static DenseVector operator -(DenseVector leftSide, DenseVector rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (DenseVector)leftSide.Subtract(rightSide);
		}

		protected override void DoNegate(Vector<float> result)
		{
			if (result is DenseVector denseVector)
			{
				LinearAlgebraControl.Provider.ScaleArray(-1f, _values, denseVector.Values);
			}
			else
			{
				base.DoNegate(result);
			}
		}

		protected override void DoMultiply(float scalar, Vector<float> result)
		{
			if (result is DenseVector denseVector)
			{
				LinearAlgebraControl.Provider.ScaleArray(scalar, _values, denseVector.Values);
			}
			else
			{
				base.DoMultiply(scalar, result);
			}
		}

		protected override float DoDotProduct(Vector<float> other)
		{
			if (!(other is DenseVector denseVector))
			{
				return base.DoDotProduct(other);
			}
			return LinearAlgebraControl.Provider.DotProduct(_values, denseVector.Values);
		}

		public static DenseVector operator *(DenseVector leftSide, float rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (DenseVector)leftSide.Multiply(rightSide);
		}

		public static DenseVector operator *(float leftSide, DenseVector rightSide)
		{
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			return (DenseVector)rightSide.Multiply(leftSide);
		}

		public static float operator *(DenseVector leftSide, DenseVector rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return leftSide.DotProduct(rightSide);
		}

		public static DenseVector operator /(DenseVector leftSide, float rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (DenseVector)leftSide.Divide(rightSide);
		}

		protected override void DoModulus(float divisor, Vector<float> result)
		{
			if (result is DenseVector denseVector)
			{
				float[] denseValues = denseVector._values;
				CommonParallel.For(0, _length, 4096, delegate(int a, int b)
				{
					for (int i = a; i < b; i++)
					{
						denseValues[i] = Euclid.Modulus(_values[i], divisor);
					}
				});
			}
			else
			{
				base.DoModulus(divisor, result);
			}
		}

		protected override void DoRemainder(float divisor, Vector<float> result)
		{
			if (result is DenseVector denseVector)
			{
				float[] denseValues = denseVector._values;
				CommonParallel.For(0, _length, 4096, delegate(int a, int b)
				{
					for (int i = a; i < b; i++)
					{
						denseValues[i] = _values[i] % divisor;
					}
				});
			}
			else
			{
				base.DoRemainder(divisor, result);
			}
		}

		public static DenseVector operator %(DenseVector leftSide, float rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (DenseVector)leftSide.Remainder(rightSide);
		}

		public override int AbsoluteMinimumIndex()
		{
			int num = 0;
			float num2 = Math.Abs(_values[num]);
			for (int i = 1; i < _length; i++)
			{
				float num3 = Math.Abs(_values[i]);
				if (num3 < num2)
				{
					num = i;
					num2 = num3;
				}
			}
			return num;
		}

		public override int AbsoluteMaximumIndex()
		{
			int num = 0;
			float num2 = Math.Abs(_values[num]);
			for (int i = 1; i < _length; i++)
			{
				float num3 = Math.Abs(_values[i]);
				if (num3 > num2)
				{
					num = i;
					num2 = num3;
				}
			}
			return num;
		}

		public override int MaximumIndex()
		{
			int result = 0;
			float num = _values[0];
			for (int i = 1; i < _length; i++)
			{
				if (num < _values[i])
				{
					result = i;
					num = _values[i];
				}
			}
			return result;
		}

		public override int MinimumIndex()
		{
			int result = 0;
			float num = _values[0];
			for (int i = 1; i < _length; i++)
			{
				if (num > _values[i])
				{
					result = i;
					num = _values[i];
				}
			}
			return result;
		}

		public override float Sum()
		{
			float num = 0f;
			for (int i = 0; i < _length; i++)
			{
				num += _values[i];
			}
			return num;
		}

		public override double L1Norm()
		{
			double num = 0.0;
			for (int i = 0; i < _length; i++)
			{
				num += (double)Math.Abs(_values[i]);
			}
			return num;
		}

		public override double L2Norm()
		{
			return _values.Aggregate(0f, SpecialFunctions.Hypotenuse);
		}

		public override double InfinityNorm()
		{
			return CommonParallel.Aggregate(_values, (int _, float v) => Math.Abs(v), Math.Max, 0f);
		}

		public override double Norm(double p)
		{
			if (p < 0.0)
			{
				throw new ArgumentOutOfRangeException("p");
			}
			if (p == 1.0)
			{
				return L1Norm();
			}
			if (p == 2.0)
			{
				return L2Norm();
			}
			if (double.IsPositiveInfinity(p))
			{
				return InfinityNorm();
			}
			double num = 0.0;
			for (int i = 0; i < _length; i++)
			{
				num += Math.Pow(Math.Abs(_values[i]), p);
			}
			return Math.Pow(num, 1.0 / p);
		}

		protected override void DoPointwiseMultiply(Vector<float> other, Vector<float> result)
		{
			if (other is DenseVector denseVector && result is DenseVector denseVector2)
			{
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(_values, denseVector._values, denseVector2._values);
			}
			else
			{
				base.DoPointwiseMultiply(other, result);
			}
		}

		protected override void DoPointwiseDivide(Vector<float> divisor, Vector<float> result)
		{
			if (divisor is DenseVector denseVector && result is DenseVector denseVector2)
			{
				LinearAlgebraControl.Provider.PointWiseDivideArrays(_values, denseVector._values, denseVector2._values);
			}
			else
			{
				base.DoPointwiseDivide(divisor, result);
			}
		}

		protected override void DoPointwisePower(Vector<float> exponent, Vector<float> result)
		{
			if (exponent is DenseVector denseVector && result is DenseVector denseVector2)
			{
				LinearAlgebraControl.Provider.PointWisePowerArrays(_values, denseVector._values, denseVector2._values);
			}
			else
			{
				base.DoPointwisePower(exponent, result);
			}
		}

		public static DenseVector Parse(string value, IFormatProvider formatProvider = null)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			value = value.Trim();
			if (value.Length == 0)
			{
				throw new FormatException();
			}
			if (value.StartsWith("(", StringComparison.Ordinal))
			{
				if (!value.EndsWith(")", StringComparison.Ordinal))
				{
					throw new FormatException();
				}
				value = value.Substring(1, value.Length - 2).Trim();
			}
			if (value.StartsWith("[", StringComparison.Ordinal))
			{
				if (!value.EndsWith("]", StringComparison.Ordinal))
				{
					throw new FormatException();
				}
				value = value.Substring(1, value.Length - 2).Trim();
			}
			float[] array = (from t in value.Split(new string[3]
				{
					formatProvider.GetTextInfo().ListSeparator,
					" ",
					"\t"
				}, StringSplitOptions.RemoveEmptyEntries)
				select float.Parse(t, NumberStyles.Any, formatProvider)).ToArray();
			if (array.Length == 0)
			{
				throw new FormatException();
			}
			return new DenseVector(array);
		}

		public static bool TryParse(string value, out DenseVector result)
		{
			return TryParse(value, null, out result);
		}

		public static bool TryParse(string value, IFormatProvider formatProvider, out DenseVector result)
		{
			try
			{
				result = Parse(value, formatProvider);
				return true;
			}
			catch (ArgumentNullException)
			{
				result = null;
				return false;
			}
			catch (FormatException)
			{
				result = null;
				return false;
			}
		}
	}
}
