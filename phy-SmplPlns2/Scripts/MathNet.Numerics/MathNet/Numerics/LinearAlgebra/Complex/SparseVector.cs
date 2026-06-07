using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Providers.LinearAlgebra;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Complex
{
	[Serializable]
	[DebuggerDisplay("SparseVector {Count}-Complex {NonZerosCount}-NonZero")]
	public class SparseVector : Vector
	{
		private readonly SparseVectorStorage<System.Numerics.Complex> _storage;

		public int NonZerosCount => _storage.ValueCount;

		public SparseVector(SparseVectorStorage<System.Numerics.Complex> storage)
			: base(storage)
		{
			_storage = storage;
		}

		public SparseVector(int length)
			: this(new SparseVectorStorage<System.Numerics.Complex>(length))
		{
		}

		public static SparseVector OfVector(Vector<System.Numerics.Complex> vector)
		{
			return new SparseVector(SparseVectorStorage<System.Numerics.Complex>.OfVector(vector.Storage));
		}

		public static SparseVector OfEnumerable(IEnumerable<System.Numerics.Complex> enumerable)
		{
			return new SparseVector(SparseVectorStorage<System.Numerics.Complex>.OfEnumerable(enumerable));
		}

		public static SparseVector OfIndexedEnumerable(int length, IEnumerable<Tuple<int, System.Numerics.Complex>> enumerable)
		{
			return new SparseVector(SparseVectorStorage<System.Numerics.Complex>.OfIndexedEnumerable(length, enumerable));
		}

		public static SparseVector OfIndexedEnumerable(int length, IEnumerable<(int, System.Numerics.Complex)> enumerable)
		{
			return new SparseVector(SparseVectorStorage<System.Numerics.Complex>.OfIndexedEnumerable(length, enumerable));
		}

		public static SparseVector Create(int length, System.Numerics.Complex value)
		{
			return new SparseVector(SparseVectorStorage<System.Numerics.Complex>.OfValue(length, value));
		}

		public static SparseVector Create(int length, Func<int, System.Numerics.Complex> init)
		{
			return new SparseVector(SparseVectorStorage<System.Numerics.Complex>.OfInit(length, init));
		}

		protected override void DoAdd(System.Numerics.Complex scalar, Vector<System.Numerics.Complex> result)
		{
			if (scalar == System.Numerics.Complex.Zero)
			{
				if (this != result)
				{
					CopyTo(result);
				}
			}
			else if (this == result)
			{
				System.Numerics.Complex[] array = new System.Numerics.Complex[base.Count];
				int[] array2 = new int[base.Count];
				for (int i = 0; i < base.Count; i++)
				{
					array2[i] = i;
					array[i] = scalar;
				}
				int[] indices = _storage.Indices;
				System.Numerics.Complex[] values = _storage.Values;
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

		protected override void DoAdd(Vector<System.Numerics.Complex> other, Vector<System.Numerics.Complex> result)
		{
			if (other is SparseVector sparseVector && result is SparseVector sparseVector2)
			{
				SparseVectorStorage<System.Numerics.Complex> storage = sparseVector._storage;
				int[] indices = storage.Indices;
				System.Numerics.Complex[] values = storage.Values;
				if (this == sparseVector2)
				{
					int num = 0;
					int num2 = 0;
					while (num2 < storage.ValueCount)
					{
						if (num >= _storage.ValueCount || _storage.Indices[num] > indices[num2])
						{
							System.Numerics.Complex value = values[num2];
							if (!System.Numerics.Complex.Zero.Equals(value))
							{
								_storage.InsertAtIndexUnchecked(num++, indices[num2], value);
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
				int num3 = 0;
				int num4 = 0;
				int num5 = -1;
				while (num3 < _storage.ValueCount || num4 < storage.ValueCount)
				{
					if (num4 >= storage.ValueCount || (num3 < _storage.ValueCount && _storage.Indices[num3] <= indices[num4]))
					{
						int num6 = _storage.Indices[num3];
						if (num6 != num5)
						{
							num5 = num6;
							result.At(num6, _storage.Values[num3] + sparseVector.At(num6));
						}
						num3++;
					}
					else
					{
						int num7 = indices[num4];
						if (num7 != num5)
						{
							num5 = num7;
							result.At(num7, At(num7) + values[num4]);
						}
						num4++;
					}
				}
			}
			else
			{
				base.DoAdd(other, result);
			}
		}

		protected override void DoSubtract(System.Numerics.Complex scalar, Vector<System.Numerics.Complex> result)
		{
			DoAdd(-scalar, result);
		}

		protected override void DoSubtract(Vector<System.Numerics.Complex> other, Vector<System.Numerics.Complex> result)
		{
			if (this == other)
			{
				result.Clear();
			}
			else if (other is SparseVector sparseVector && result is SparseVector sparseVector2)
			{
				SparseVectorStorage<System.Numerics.Complex> storage = sparseVector._storage;
				int[] indices = storage.Indices;
				System.Numerics.Complex[] values = storage.Values;
				if (this == sparseVector2)
				{
					int num = 0;
					int num2 = 0;
					while (num2 < storage.ValueCount)
					{
						if (num >= _storage.ValueCount || _storage.Indices[num] > indices[num2])
						{
							System.Numerics.Complex complex = values[num2];
							if (!System.Numerics.Complex.Zero.Equals(complex))
							{
								_storage.InsertAtIndexUnchecked(num++, indices[num2], -complex);
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
				int num3 = 0;
				int num4 = 0;
				int num5 = -1;
				while (num3 < _storage.ValueCount || num4 < storage.ValueCount)
				{
					if (num4 >= storage.ValueCount || (num3 < _storage.ValueCount && _storage.Indices[num3] <= indices[num4]))
					{
						int num6 = _storage.Indices[num3];
						if (num6 != num5)
						{
							num5 = num6;
							result.At(num6, _storage.Values[num3] - sparseVector.At(num6));
						}
						num3++;
					}
					else
					{
						int num7 = indices[num4];
						if (num7 != num5)
						{
							num5 = num7;
							result.At(num7, At(num7) - values[num4]);
						}
						num4++;
					}
				}
			}
			else
			{
				base.DoSubtract(other, result);
			}
		}

		protected override void DoNegate(Vector<System.Numerics.Complex> result)
		{
			if (result is SparseVector sparseVector)
			{
				if (this != result)
				{
					sparseVector._storage.ValueCount = _storage.ValueCount;
					sparseVector._storage.Indices = new int[_storage.ValueCount];
					Buffer.BlockCopy(_storage.Indices, 0, sparseVector._storage.Indices, 0, _storage.ValueCount * 4);
					sparseVector._storage.Values = new System.Numerics.Complex[_storage.ValueCount];
					Array.Copy(_storage.Values, 0, sparseVector._storage.Values, 0, _storage.ValueCount);
				}
				LinearAlgebraControl.Provider.ScaleArray(-System.Numerics.Complex.One, sparseVector._storage.Values, sparseVector._storage.Values);
			}
			else
			{
				int[] indices = _storage.Indices;
				System.Numerics.Complex[] values = _storage.Values;
				result.Clear();
				for (int i = 0; i < _storage.ValueCount; i++)
				{
					result.At(indices[i], -values[i]);
				}
			}
		}

		protected override void DoConjugate(Vector<System.Numerics.Complex> result)
		{
			if (result is SparseVector sparseVector)
			{
				if (this != result)
				{
					sparseVector._storage.ValueCount = _storage.ValueCount;
					sparseVector._storage.Indices = new int[_storage.ValueCount];
					Buffer.BlockCopy(_storage.Indices, 0, sparseVector._storage.Indices, 0, _storage.ValueCount * 4);
					sparseVector._storage.Values = new System.Numerics.Complex[_storage.ValueCount];
					Array.Copy(_storage.Values, 0, sparseVector._storage.Values, 0, _storage.ValueCount);
				}
				LinearAlgebraControl.Provider.ConjugateArray(sparseVector._storage.Values, sparseVector._storage.Values);
			}
			else
			{
				int[] indices = _storage.Indices;
				System.Numerics.Complex[] values = _storage.Values;
				result.Clear();
				for (int i = 0; i < _storage.ValueCount; i++)
				{
					result.At(indices[i], values[i].Conjugate());
				}
			}
		}

		protected override void DoMultiply(System.Numerics.Complex scalar, Vector<System.Numerics.Complex> result)
		{
			if (result is SparseVector sparseVector)
			{
				if (this != result)
				{
					sparseVector._storage.ValueCount = _storage.ValueCount;
					sparseVector._storage.Indices = new int[_storage.ValueCount];
					Buffer.BlockCopy(_storage.Indices, 0, sparseVector._storage.Indices, 0, _storage.ValueCount * 4);
					sparseVector._storage.Values = new System.Numerics.Complex[_storage.ValueCount];
					Array.Copy(_storage.Values, 0, sparseVector._storage.Values, 0, _storage.ValueCount);
				}
				LinearAlgebraControl.Provider.ScaleArray(scalar, sparseVector._storage.Values, sparseVector._storage.Values);
			}
			else
			{
				int[] indices = _storage.Indices;
				System.Numerics.Complex[] values = _storage.Values;
				result.Clear();
				for (int i = 0; i < _storage.ValueCount; i++)
				{
					result.At(indices[i], scalar * values[i]);
				}
			}
		}

		protected override System.Numerics.Complex DoDotProduct(Vector<System.Numerics.Complex> other)
		{
			int[] indices = _storage.Indices;
			System.Numerics.Complex[] values = _storage.Values;
			System.Numerics.Complex zero = System.Numerics.Complex.Zero;
			if (this == other)
			{
				for (int i = 0; i < _storage.ValueCount; i++)
				{
					zero += values[i] * values[i];
				}
			}
			else
			{
				for (int j = 0; j < _storage.ValueCount; j++)
				{
					zero += values[j] * other.At(indices[j]);
				}
			}
			return zero;
		}

		protected override System.Numerics.Complex DoConjugateDotProduct(Vector<System.Numerics.Complex> other)
		{
			int[] indices = _storage.Indices;
			System.Numerics.Complex[] values = _storage.Values;
			System.Numerics.Complex zero = System.Numerics.Complex.Zero;
			if (this == other)
			{
				for (int i = 0; i < _storage.ValueCount; i++)
				{
					zero += values[i].Conjugate() * values[i];
				}
			}
			else
			{
				for (int j = 0; j < _storage.ValueCount; j++)
				{
					zero += values[j].Conjugate() * other.At(indices[j]);
				}
			}
			return zero;
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

		public static SparseVector operator *(SparseVector leftSide, System.Numerics.Complex rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (SparseVector)leftSide.Multiply(rightSide);
		}

		public static SparseVector operator *(System.Numerics.Complex leftSide, SparseVector rightSide)
		{
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			return (SparseVector)rightSide.Multiply(leftSide);
		}

		public static System.Numerics.Complex operator *(SparseVector leftSide, SparseVector rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return leftSide.DotProduct(rightSide);
		}

		public static SparseVector operator /(SparseVector leftSide, System.Numerics.Complex rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (SparseVector)leftSide.Divide(rightSide);
		}

		public static SparseVector operator %(SparseVector leftSide, System.Numerics.Complex rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (SparseVector)leftSide.Modulus(rightSide);
		}

		public override int AbsoluteMinimumIndex()
		{
			if (_storage.ValueCount == 0)
			{
				return 0;
			}
			System.Numerics.Complex[] values = _storage.Values;
			int num = 0;
			double num2 = values[num].Magnitude;
			for (int i = 1; i < _storage.ValueCount; i++)
			{
				double magnitude = values[i].Magnitude;
				if (magnitude < num2)
				{
					num = i;
					num2 = magnitude;
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
			System.Numerics.Complex[] values = _storage.Values;
			int num = 0;
			double num2 = values[num].Magnitude;
			for (int i = 1; i < _storage.ValueCount; i++)
			{
				double magnitude = values[i].Magnitude;
				if (magnitude > num2)
				{
					num = i;
					num2 = magnitude;
				}
			}
			return _storage.Indices[num];
		}

		public override System.Numerics.Complex Sum()
		{
			System.Numerics.Complex[] values = _storage.Values;
			System.Numerics.Complex zero = System.Numerics.Complex.Zero;
			for (int i = 0; i < _storage.ValueCount; i++)
			{
				zero += values[i];
			}
			return zero;
		}

		public override double L1Norm()
		{
			System.Numerics.Complex[] values = _storage.Values;
			double num = 0.0;
			for (int i = 0; i < _storage.ValueCount; i++)
			{
				num += values[i].Magnitude;
			}
			return num;
		}

		public override double InfinityNorm()
		{
			return CommonParallel.Aggregate(0, _storage.ValueCount, (int i) => _storage.Values[i].Magnitude, Math.Max, 0.0);
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
			System.Numerics.Complex[] values = _storage.Values;
			double num = 0.0;
			for (int i = 0; i < _storage.ValueCount; i++)
			{
				num += Math.Pow(values[i].Magnitude, p);
			}
			return Math.Pow(num, 1.0 / p);
		}

		protected override void DoPointwiseMultiply(Vector<System.Numerics.Complex> other, Vector<System.Numerics.Complex> result)
		{
			if (this == other && this == result)
			{
				System.Numerics.Complex[] values = _storage.Values;
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
			string[] array = value.Split(new string[1] { formatProvider.GetTextInfo().ListSeparator }, StringSplitOptions.RemoveEmptyEntries);
			List<System.Numerics.Complex> list = new List<System.Numerics.Complex>();
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string[] array3 = array2[i].Split(new string[2] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
				string text = string.Empty;
				for (int j = 0; j < array3.Length; j++)
				{
					text += array3[j];
					if (!text.EndsWith("+") && !text.EndsWith("-") && (!text.StartsWith("(") || text.EndsWith(")")))
					{
						string text2 = ((j < array3.Length - 1) ? array3[j + 1] : string.Empty);
						if (!text2.StartsWith("+") && !text2.StartsWith("-"))
						{
							list.Add(text.ToComplex(formatProvider));
							text = string.Empty;
						}
					}
				}
				if (text != string.Empty)
				{
					throw new FormatException();
				}
			}
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
			return FormattableString.Invariant($"SparseVector {base.Count}-Complex {(double)NonZerosCount / (double)base.Count:P2} Filled");
		}
	}
}
