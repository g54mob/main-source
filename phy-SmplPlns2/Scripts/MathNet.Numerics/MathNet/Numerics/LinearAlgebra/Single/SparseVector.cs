using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Providers.LinearAlgebra;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Single
{
	[Serializable]
	[DebuggerDisplay("SparseVector {Count}-Single {NonZerosCount}-NonZero")]
	public class SparseVector : Vector
	{
		private readonly SparseVectorStorage<float> _storage;

		public int NonZerosCount => _storage.ValueCount;

		public SparseVector(SparseVectorStorage<float> storage)
			: base(storage)
		{
			_storage = storage;
		}

		public SparseVector(int length)
			: this(new SparseVectorStorage<float>(length))
		{
		}

		public static SparseVector OfVector(Vector<float> vector)
		{
			return new SparseVector(SparseVectorStorage<float>.OfVector(vector.Storage));
		}

		public static SparseVector OfEnumerable(IEnumerable<float> enumerable)
		{
			return new SparseVector(SparseVectorStorage<float>.OfEnumerable(enumerable));
		}

		public static SparseVector OfIndexedEnumerable(int length, IEnumerable<Tuple<int, float>> enumerable)
		{
			return new SparseVector(SparseVectorStorage<float>.OfIndexedEnumerable(length, enumerable));
		}

		public static SparseVector OfIndexedEnumerable(int length, IEnumerable<(int, float)> enumerable)
		{
			return new SparseVector(SparseVectorStorage<float>.OfIndexedEnumerable(length, enumerable));
		}

		public static SparseVector Create(int length, float value)
		{
			return new SparseVector(SparseVectorStorage<float>.OfValue(length, value));
		}

		public static SparseVector Create(int length, Func<int, float> init)
		{
			return new SparseVector(SparseVectorStorage<float>.OfInit(length, init));
		}

		protected override void DoAdd(float scalar, Vector<float> result)
		{
			if (scalar == 0f)
			{
				if (this != result)
				{
					CopyTo(result);
				}
			}
			else if (this == result)
			{
				float[] array = new float[base.Count];
				int[] array2 = new int[base.Count];
				for (int i = 0; i < base.Count; i++)
				{
					array2[i] = i;
					array[i] = scalar;
				}
				int[] indices = _storage.Indices;
				float[] values = _storage.Values;
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

		protected override void DoAdd(Vector<float> other, Vector<float> result)
		{
			if (other is SparseVector sparseVector && result is SparseVector sparseVector2)
			{
				SparseVectorStorage<float> storage = sparseVector._storage;
				int[] indices = storage.Indices;
				float[] values = storage.Values;
				if (this == sparseVector2)
				{
					int num = 0;
					int num2 = 0;
					while (num2 < storage.ValueCount)
					{
						if (num >= _storage.ValueCount || _storage.Indices[num] > indices[num2])
						{
							float num3 = values[num2];
							if (num3 != 0f)
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

		protected override void DoSubtract(float scalar, Vector<float> result)
		{
			DoAdd(0f - scalar, result);
		}

		protected override void DoSubtract(Vector<float> other, Vector<float> result)
		{
			if (this == other)
			{
				result.Clear();
			}
			else if (other is SparseVector sparseVector && result is SparseVector sparseVector2)
			{
				SparseVectorStorage<float> storage = sparseVector._storage;
				int[] indices = storage.Indices;
				float[] values = storage.Values;
				if (this == sparseVector2)
				{
					int num = 0;
					int num2 = 0;
					while (num2 < storage.ValueCount)
					{
						if (num >= _storage.ValueCount || _storage.Indices[num] > indices[num2])
						{
							float num3 = values[num2];
							if (num3 != 0f)
							{
								_storage.InsertAtIndexUnchecked(num++, indices[num2], 0f - num3);
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

		protected override void DoNegate(Vector<float> result)
		{
			if (result is SparseVector sparseVector)
			{
				if (this != result)
				{
					sparseVector._storage.ValueCount = _storage.ValueCount;
					sparseVector._storage.Indices = new int[_storage.ValueCount];
					Buffer.BlockCopy(_storage.Indices, 0, sparseVector._storage.Indices, 0, _storage.ValueCount * 4);
					sparseVector._storage.Values = new float[_storage.ValueCount];
					Array.Copy(_storage.Values, 0, sparseVector._storage.Values, 0, _storage.ValueCount);
				}
				LinearAlgebraControl.Provider.ScaleArray(-1f, sparseVector._storage.Values, sparseVector._storage.Values);
			}
			else
			{
				int[] indices = _storage.Indices;
				float[] values = _storage.Values;
				result.Clear();
				for (int i = 0; i < _storage.ValueCount; i++)
				{
					result.At(indices[i], 0f - values[i]);
				}
			}
		}

		protected override void DoMultiply(float scalar, Vector<float> result)
		{
			if (result is SparseVector sparseVector)
			{
				if (this != result)
				{
					sparseVector._storage.ValueCount = _storage.ValueCount;
					sparseVector._storage.Indices = new int[_storage.ValueCount];
					Buffer.BlockCopy(_storage.Indices, 0, sparseVector._storage.Indices, 0, _storage.ValueCount * 4);
					sparseVector._storage.Values = new float[_storage.ValueCount];
					Array.Copy(_storage.Values, 0, sparseVector._storage.Values, 0, _storage.ValueCount);
				}
				LinearAlgebraControl.Provider.ScaleArray(scalar, sparseVector._storage.Values, sparseVector._storage.Values);
			}
			else
			{
				result.Clear();
				for (int i = 0; i < _storage.ValueCount; i++)
				{
					result.At(_storage.Indices[i], scalar * _storage.Values[i]);
				}
			}
		}

		protected override float DoDotProduct(Vector<float> other)
		{
			int[] indices = _storage.Indices;
			float[] values = _storage.Values;
			float num = 0f;
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

		protected override void DoModulus(float divisor, Vector<float> result)
		{
			int[] indices = _storage.Indices;
			float[] values = _storage.Values;
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

		protected override void DoRemainder(float divisor, Vector<float> result)
		{
			int[] indices = _storage.Indices;
			float[] values = _storage.Values;
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

		public static SparseVector operator *(SparseVector leftSide, float rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (SparseVector)leftSide.Multiply(rightSide);
		}

		public static SparseVector operator *(float leftSide, SparseVector rightSide)
		{
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			return (SparseVector)rightSide.Multiply(leftSide);
		}

		public static float operator *(SparseVector leftSide, SparseVector rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return leftSide.DotProduct(rightSide);
		}

		public static SparseVector operator /(SparseVector leftSide, float rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (SparseVector)leftSide.Divide(rightSide);
		}

		public static SparseVector operator %(SparseVector leftSide, float rightSide)
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
			float[] values = _storage.Values;
			int num = 0;
			float num2 = Math.Abs(values[num]);
			for (int i = 1; i < _storage.ValueCount; i++)
			{
				float num3 = Math.Abs(values[i]);
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
			float[] values = _storage.Values;
			int num = 0;
			float num2 = Math.Abs(values[num]);
			for (int i = 1; i < _storage.ValueCount; i++)
			{
				float num3 = Math.Abs(values[i]);
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
			float[] values = _storage.Values;
			int num = 0;
			float num2 = values[0];
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
			float[] values = _storage.Values;
			int num = 0;
			float num2 = values[0];
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

		public override float Sum()
		{
			float[] values = _storage.Values;
			float num = 0f;
			for (int i = 0; i < _storage.ValueCount; i++)
			{
				num += values[i];
			}
			return num;
		}

		public override double L1Norm()
		{
			float[] values = _storage.Values;
			double num = 0.0;
			for (int i = 0; i < _storage.ValueCount; i++)
			{
				num += (double)Math.Abs(values[i]);
			}
			return num;
		}

		public override double InfinityNorm()
		{
			return CommonParallel.Aggregate(0, _storage.ValueCount, (int i) => Math.Abs(_storage.Values[i]), Math.Max, 0f);
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
			float[] values = _storage.Values;
			double num = 0.0;
			for (int i = 0; i < _storage.ValueCount; i++)
			{
				num += Math.Pow(Math.Abs(values[i]), p);
			}
			return Math.Pow(num, 1.0 / p);
		}

		protected override void DoPointwiseMultiply(Vector<float> other, Vector<float> result)
		{
			if (this == other && this == result)
			{
				float[] values = _storage.Values;
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
			List<float> list = (from t in value.Split(new string[3]
				{
					formatProvider.GetTextInfo().ListSeparator,
					" ",
					"\t"
				}, StringSplitOptions.RemoveEmptyEntries)
				select float.Parse(t, NumberStyles.Any, formatProvider)).ToList();
			if (list.Count == 0)
			{
				throw new FormatException();
			}
			return OfEnumerable(list);
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
			return FormattableString.Invariant($"SparseVector {base.Count}-Single {(double)NonZerosCount / (double)base.Count:P2} Filled");
		}
	}
}
