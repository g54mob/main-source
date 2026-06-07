using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Providers.LinearAlgebra;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Double
{
	[Serializable]
	[DebuggerDisplay("SparseVector {Count}-Double {NonZerosCount}-NonZero")]
	public class SparseVector : Vector
	{
		private readonly SparseVectorStorage<double> _storage;

		public int NonZerosCount => _storage.ValueCount;

		public SparseVector(SparseVectorStorage<double> storage)
			: base(storage)
		{
			_storage = storage;
		}

		public SparseVector(int length)
			: this(new SparseVectorStorage<double>(length))
		{
		}

		public static SparseVector OfVector(Vector<double> vector)
		{
			return new SparseVector(SparseVectorStorage<double>.OfVector(vector.Storage));
		}

		public static SparseVector OfEnumerable(IEnumerable<double> enumerable)
		{
			return new SparseVector(SparseVectorStorage<double>.OfEnumerable(enumerable));
		}

		public static SparseVector OfIndexedEnumerable(int length, IEnumerable<Tuple<int, double>> enumerable)
		{
			return new SparseVector(SparseVectorStorage<double>.OfIndexedEnumerable(length, enumerable));
		}

		public static SparseVector OfIndexedEnumerable(int length, IEnumerable<(int, double)> enumerable)
		{
			return new SparseVector(SparseVectorStorage<double>.OfIndexedEnumerable(length, enumerable));
		}

		public static SparseVector Create(int length, double value)
		{
			return new SparseVector(SparseVectorStorage<double>.OfValue(length, value));
		}

		public static SparseVector Create(int length, Func<int, double> init)
		{
			return new SparseVector(SparseVectorStorage<double>.OfInit(length, init));
		}

		protected override void DoAdd(double scalar, Vector<double> result)
		{
			if (scalar == 0.0)
			{
				if (this != result)
				{
					CopyTo(result);
				}
			}
			else if (this == result)
			{
				double[] array = new double[base.Count];
				int[] array2 = new int[base.Count];
				for (int i = 0; i < base.Count; i++)
				{
					array2[i] = i;
					array[i] = scalar;
				}
				int[] indices = _storage.Indices;
				double[] values = _storage.Values;
				for (int j = 0; j < _storage.ValueCount; j++)
				{
					array[indices[j]] = values[j] + scalar;
				}
				_storage.Values = array;
				_storage.Indices = array2;
				_storage.ValueCount = base.Count;
			}
			else
			{
				for (int k = 0; k < base.Count; k++)
				{
					result.At(k, At(k) + scalar);
				}
			}
		}

		protected override void DoAdd(Vector<double> other, Vector<double> result)
		{
			if (other is SparseVector sparseVector && result is SparseVector sparseVector2)
			{
				SparseVectorStorage<double> storage = sparseVector._storage;
				int[] indices = storage.Indices;
				double[] values = storage.Values;
				if (this == sparseVector2)
				{
					int num = 0;
					int num2 = 0;
					while (num2 < storage.ValueCount)
					{
						if (num >= _storage.ValueCount || _storage.Indices[num] > indices[num2])
						{
							double num3 = values[num2];
							if (num3 != 0.0)
							{
								_storage.InsertAtIndexUnchecked(num++, indices[num2], num3);
							}
							num2++;
						}
						else if (_storage.Indices[num] == indices[num2])
						{
							_storage.Values[num++] += values[num2++];
						}
						else
						{
							num++;
						}
					}
					return;
				}
				result.Clear();
				int num4 = 0;
				int num5 = 0;
				int num6 = -1;
				while (num4 < _storage.ValueCount || num5 < storage.ValueCount)
				{
					if (num5 >= storage.ValueCount || (num4 < _storage.ValueCount && _storage.Indices[num4] <= indices[num5]))
					{
						int num7 = _storage.Indices[num4];
						if (num7 != num6)
						{
							num6 = num7;
							result.At(num7, _storage.Values[num4] + sparseVector.At(num7));
						}
						num4++;
					}
					else
					{
						int num8 = indices[num5];
						if (num8 != num6)
						{
							num6 = num8;
							result.At(num8, At(num8) + values[num5]);
						}
						num5++;
					}
				}
			}
			else
			{
				base.DoAdd(other, result);
			}
		}

		protected override void DoSubtract(double scalar, Vector<double> result)
		{
			DoAdd(0.0 - scalar, result);
		}

		protected override void DoSubtract(Vector<double> other, Vector<double> result)
		{
			if (this == other)
			{
				result.Clear();
			}
			else if (other is SparseVector sparseVector && result is SparseVector sparseVector2)
			{
				SparseVectorStorage<double> storage = sparseVector._storage;
				int[] indices = storage.Indices;
				double[] values = storage.Values;
				if (this == sparseVector2)
				{
					int num = 0;
					int num2 = 0;
					while (num2 < storage.ValueCount)
					{
						if (num >= _storage.ValueCount || _storage.Indices[num] > indices[num2])
						{
							double num3 = values[num2];
							if (num3 != 0.0)
							{
								_storage.InsertAtIndexUnchecked(num++, indices[num2], 0.0 - num3);
							}
							num2++;
						}
						else if (_storage.Indices[num] == indices[num2])
						{
							_storage.Values[num++] -= values[num2++];
						}
						else
						{
							num++;
						}
					}
					return;
				}
				result.Clear();
				int num4 = 0;
				int num5 = 0;
				int num6 = -1;
				while (num4 < _storage.ValueCount || num5 < storage.ValueCount)
				{
					if (num5 >= storage.ValueCount || (num4 < _storage.ValueCount && _storage.Indices[num4] <= indices[num5]))
					{
						int num7 = _storage.Indices[num4];
						if (num7 != num6)
						{
							num6 = num7;
							result.At(num7, _storage.Values[num4] - sparseVector.At(num7));
						}
						num4++;
					}
					else
					{
						int num8 = indices[num5];
						if (num8 != num6)
						{
							num6 = num8;
							result.At(num8, At(num8) - values[num5]);
						}
						num5++;
					}
				}
			}
			else
			{
				base.DoSubtract(other, result);
			}
		}

		protected override void DoNegate(Vector<double> result)
		{
			if (result is SparseVector sparseVector)
			{
				if (this != result)
				{
					sparseVector._storage.ValueCount = _storage.ValueCount;
					sparseVector._storage.Indices = new int[_storage.ValueCount];
					Buffer.BlockCopy(_storage.Indices, 0, sparseVector._storage.Indices, 0, _storage.ValueCount * 4);
					sparseVector._storage.Values = new double[_storage.ValueCount];
					Array.Copy(_storage.Values, 0, sparseVector._storage.Values, 0, _storage.ValueCount);
				}
				LinearAlgebraControl.Provider.ScaleArray(-1.0, sparseVector._storage.Values, sparseVector._storage.Values);
			}
			else
			{
				int[] indices = _storage.Indices;
				double[] values = _storage.Values;
				result.Clear();
				for (int i = 0; i < _storage.ValueCount; i++)
				{
					result.At(indices[i], 0.0 - values[i]);
				}
			}
		}

		protected override void DoMultiply(double scalar, Vector<double> result)
		{
			if (result is SparseVector sparseVector)
			{
				if (this != result)
				{
					sparseVector._storage.ValueCount = _storage.ValueCount;
					sparseVector._storage.Indices = new int[_storage.ValueCount];
					Buffer.BlockCopy(_storage.Indices, 0, sparseVector._storage.Indices, 0, _storage.ValueCount * 4);
					sparseVector._storage.Values = new double[_storage.ValueCount];
					Array.Copy(_storage.Values, 0, sparseVector._storage.Values, 0, _storage.ValueCount);
				}
				LinearAlgebraControl.Provider.ScaleArray(scalar, sparseVector._storage.Values, sparseVector._storage.Values);
			}
			else
			{
				int[] indices = _storage.Indices;
				double[] values = _storage.Values;
				result.Clear();
				for (int i = 0; i < _storage.ValueCount; i++)
				{
					result.At(indices[i], scalar * values[i]);
				}
			}
		}

		protected override double DoDotProduct(Vector<double> other)
		{
			int[] indices = _storage.Indices;
			double[] values = _storage.Values;
			double num = 0.0;
			if (this == other)
			{
				for (int i = 0; i < _storage.ValueCount; i++)
				{
					num += values[i] * values[i];
				}
			}
			else
			{
				for (int j = 0; j < _storage.ValueCount; j++)
				{
					num += values[j] * other.At(indices[j]);
				}
			}
			return num;
		}

		protected override void DoModulus(double divisor, Vector<double> result)
		{
			int[] indices = _storage.Indices;
			double[] values = _storage.Values;
			if (this == result)
			{
				for (int i = 0; i < _storage.ValueCount; i++)
				{
					values[i] = Euclid.Modulus(values[i], divisor);
				}
				return;
			}
			result.Clear();
			for (int j = 0; j < _storage.ValueCount; j++)
			{
				result.At(indices[j], Euclid.Modulus(values[j], divisor));
			}
		}

		protected override void DoRemainder(double divisor, Vector<double> result)
		{
			int[] indices = _storage.Indices;
			double[] values = _storage.Values;
			if (this == result)
			{
				for (int i = 0; i < _storage.ValueCount; i++)
				{
					values[i] %= divisor;
				}
				return;
			}
			result.Clear();
			for (int j = 0; j < _storage.ValueCount; j++)
			{
				result.At(indices[j], values[j] % divisor);
			}
		}

		public static SparseVector operator +(SparseVector leftSide, SparseVector rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (SparseVector)leftSide.Add(rightSide);
		}

		public static SparseVector operator -(SparseVector rightSide)
		{
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			return (SparseVector)rightSide.Negate();
		}

		public static SparseVector operator -(SparseVector leftSide, SparseVector rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (SparseVector)leftSide.Subtract(rightSide);
		}

		public static SparseVector operator *(SparseVector leftSide, double rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (SparseVector)leftSide.Multiply(rightSide);
		}

		public static SparseVector operator *(double leftSide, SparseVector rightSide)
		{
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			return (SparseVector)rightSide.Multiply(leftSide);
		}

		public static double operator *(SparseVector leftSide, SparseVector rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return leftSide.DotProduct(rightSide);
		}

		public static SparseVector operator /(SparseVector leftSide, double rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (SparseVector)leftSide.Divide(rightSide);
		}

		public static SparseVector operator %(SparseVector leftSide, double rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (SparseVector)leftSide.Remainder(rightSide);
		}

		public override int AbsoluteMinimumIndex()
		{
			if (_storage.ValueCount == 0)
			{
				return 0;
			}
			double[] values = _storage.Values;
			int num = 0;
			double num2 = Math.Abs(values[num]);
			for (int i = 1; i < _storage.ValueCount; i++)
			{
				double num3 = Math.Abs(values[i]);
				if (num3 < num2)
				{
					num = i;
					num2 = num3;
				}
			}
			return _storage.Indices[num];
		}

		public override int AbsoluteMaximumIndex()
		{
			if (_storage.ValueCount == 0)
			{
				return 0;
			}
			double[] values = _storage.Values;
			int num = 0;
			double num2 = Math.Abs(values[num]);
			for (int i = 1; i < _storage.ValueCount; i++)
			{
				double num3 = Math.Abs(values[i]);
				if (num3 > num2)
				{
					num = i;
					num2 = num3;
				}
			}
			return _storage.Indices[num];
		}

		public override int MaximumIndex()
		{
			if (_storage.ValueCount == 0)
			{
				return 0;
			}
			double[] values = _storage.Values;
			int num = 0;
			double num2 = values[0];
			for (int i = 1; i < _storage.ValueCount; i++)
			{
				if (num2 < values[i])
				{
					num = i;
					num2 = values[i];
				}
			}
			return _storage.Indices[num];
		}

		public override int MinimumIndex()
		{
			if (_storage.ValueCount == 0)
			{
				return 0;
			}
			double[] values = _storage.Values;
			int num = 0;
			double num2 = values[0];
			for (int i = 1; i < _storage.ValueCount; i++)
			{
				if (num2 > values[i])
				{
					num = i;
					num2 = values[i];
				}
			}
			return _storage.Indices[num];
		}

		public override double Sum()
		{
			double[] values = _storage.Values;
			double num = 0.0;
			for (int i = 0; i < _storage.ValueCount; i++)
			{
				num += values[i];
			}
			return num;
		}

		public override double L1Norm()
		{
			double[] values = _storage.Values;
			double num = 0.0;
			for (int i = 0; i < _storage.ValueCount; i++)
			{
				num += Math.Abs(values[i]);
			}
			return num;
		}

		public override double InfinityNorm()
		{
			return CommonParallel.Aggregate(0, _storage.ValueCount, (int i) => Math.Abs(_storage.Values[i]), Math.Max, 0.0);
		}

		public override double Norm(double p)
		{
			if (p < 0.0)
			{
				throw new ArgumentOutOfRangeException("p");
			}
			if (_storage.ValueCount == 0)
			{
				return 0.0;
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
			double[] values = _storage.Values;
			double num = 0.0;
			for (int i = 0; i < _storage.ValueCount; i++)
			{
				num += Math.Pow(Math.Abs(values[i]), p);
			}
			return Math.Pow(num, 1.0 / p);
		}

		protected override void DoPointwiseMultiply(Vector<double> other, Vector<double> result)
		{
			if (this == other && this == result)
			{
				double[] values = _storage.Values;
				for (int i = 0; i < _storage.ValueCount; i++)
				{
					values[i] *= values[i];
				}
			}
			else
			{
				base.DoPointwiseMultiply(other, result);
			}
		}

		public static SparseVector Parse(string value, IFormatProvider formatProvider = null)
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
			List<double> list = (from t in value.Split(new string[3]
				{
					formatProvider.GetTextInfo().ListSeparator,
					" ",
					"\t"
				}, StringSplitOptions.RemoveEmptyEntries)
				select double.Parse(t, NumberStyles.Any, formatProvider)).ToList();
			if (list.Count == 0)
			{
				throw new FormatException();
			}
			return new SparseVector(SparseVectorStorage<double>.OfEnumerable(list));
		}

		public static bool TryParse(string value, out SparseVector result)
		{
			return TryParse(value, null, out result);
		}

		public static bool TryParse(string value, IFormatProvider formatProvider, out SparseVector result)
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

		public override string ToTypeString()
		{
			return FormattableString.Invariant($"SparseVector {base.Count}-Double {(double)NonZerosCount / (double)base.Count:P2} Filled");
		}
	}
}
