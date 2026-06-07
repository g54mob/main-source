using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Providers.LinearAlgebra;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Complex
{
	[Serializable]
	[DebuggerDisplay("DenseVector {Count}-Complex")]
	public class DenseVector : Vector
	{
		private readonly int _length;

		private readonly System.Numerics.Complex[] _values;

		public System.Numerics.Complex[] Values => _values;

		public DenseVector(DenseVectorStorage<System.Numerics.Complex> storage)
			: base(storage)
		{
			_length = storage.Length;
			_values = storage.Data;
		}

		public DenseVector(int length)
			: this(new DenseVectorStorage<System.Numerics.Complex>(length))
		{
		}

		public DenseVector(System.Numerics.Complex[] storage)
			: this(new DenseVectorStorage<System.Numerics.Complex>(storage.Length, storage))
		{
		}

		public static DenseVector OfVector(Vector<System.Numerics.Complex> vector)
		{
			return new DenseVector(DenseVectorStorage<System.Numerics.Complex>.OfVector(vector.Storage));
		}

		public static DenseVector OfArray(System.Numerics.Complex[] array)
		{
			return new DenseVector(DenseVectorStorage<System.Numerics.Complex>.OfVector(new DenseVectorStorage<System.Numerics.Complex>(array.Length, array)));
		}

		public static DenseVector OfEnumerable(IEnumerable<System.Numerics.Complex> enumerable)
		{
			return new DenseVector(DenseVectorStorage<System.Numerics.Complex>.OfEnumerable(enumerable));
		}

		public static DenseVector OfIndexedEnumerable(int length, IEnumerable<Tuple<int, System.Numerics.Complex>> enumerable)
		{
			return new DenseVector(DenseVectorStorage<System.Numerics.Complex>.OfIndexedEnumerable(length, enumerable));
		}

		public static DenseVector OfIndexedEnumerable(int length, IEnumerable<(int, System.Numerics.Complex)> enumerable)
		{
			return new DenseVector(DenseVectorStorage<System.Numerics.Complex>.OfIndexedEnumerable(length, enumerable));
		}

		public static DenseVector Create(int length, System.Numerics.Complex value)
		{
			if (value == System.Numerics.Complex.Zero)
			{
				return new DenseVector(length);
			}
			return new DenseVector(DenseVectorStorage<System.Numerics.Complex>.OfValue(length, value));
		}

		public static DenseVector Create(int length, Func<int, System.Numerics.Complex> init)
		{
			return new DenseVector(DenseVectorStorage<System.Numerics.Complex>.OfInit(length, init));
		}

		public static DenseVector CreateRandom(int length, IContinuousDistribution distribution)
		{
			System.Numerics.Complex[] data = Generate.RandomComplex(length, distribution);
			return new DenseVector(new DenseVectorStorage<System.Numerics.Complex>(length, data));
		}

		public static explicit operator System.Numerics.Complex[](DenseVector vector)
		{
			if (vector == null)
			{
				throw new ArgumentNullException("vector");
			}
			return vector.Values;
		}

		public static implicit operator DenseVector(System.Numerics.Complex[] array)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			return new DenseVector(array);
		}

		protected override void DoAdd(System.Numerics.Complex scalar, Vector<System.Numerics.Complex> result)
		{
			if (result is DenseVector denseVector)
			{
				System.Numerics.Complex[] denseValues = denseVector._values;
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

		protected override void DoAdd(Vector<System.Numerics.Complex> other, Vector<System.Numerics.Complex> result)
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

		public static Vector<System.Numerics.Complex> operator +(DenseVector leftSide, DenseVector rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return leftSide.Add(rightSide);
		}

		protected override void DoSubtract(System.Numerics.Complex scalar, Vector<System.Numerics.Complex> result)
		{
			if (result is DenseVector denseVector)
			{
				System.Numerics.Complex[] denseValues = denseVector._values;
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

		protected override void DoSubtract(Vector<System.Numerics.Complex> other, Vector<System.Numerics.Complex> result)
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

		public static Vector<System.Numerics.Complex> operator -(DenseVector rightSide)
		{
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			return rightSide.Negate();
		}

		public static Vector<System.Numerics.Complex> operator -(DenseVector leftSide, DenseVector rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return leftSide.Subtract(rightSide);
		}

		protected override void DoNegate(Vector<System.Numerics.Complex> result)
		{
			if (result is DenseVector denseVector)
			{
				LinearAlgebraControl.Provider.ScaleArray(-System.Numerics.Complex.One, _values, denseVector.Values);
			}
			else
			{
				base.DoNegate(result);
			}
		}

		protected override void DoConjugate(Vector<System.Numerics.Complex> result)
		{
			if (result is DenseVector denseVector)
			{
				LinearAlgebraControl.Provider.ConjugateArray(_values, denseVector._values);
			}
			else
			{
				base.DoConjugate(result);
			}
		}

		protected override void DoMultiply(System.Numerics.Complex scalar, Vector<System.Numerics.Complex> result)
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

		protected override System.Numerics.Complex DoDotProduct(Vector<System.Numerics.Complex> other)
		{
			if (!(other is DenseVector denseVector))
			{
				return base.DoDotProduct(other);
			}
			return LinearAlgebraControl.Provider.DotProduct(_values, denseVector.Values);
		}

		protected override System.Numerics.Complex DoConjugateDotProduct(Vector<System.Numerics.Complex> other)
		{
			if (other is DenseVector { _values: var values })
			{
				System.Numerics.Complex zero = System.Numerics.Complex.Zero;
				for (int i = 0; i < _values.Length; i++)
				{
					zero += _values[i].Conjugate() * values[i];
				}
				return zero;
			}
			return base.DoConjugateDotProduct(other);
		}

		public static DenseVector operator *(DenseVector leftSide, System.Numerics.Complex rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (DenseVector)leftSide.Multiply(rightSide);
		}

		public static DenseVector operator *(System.Numerics.Complex leftSide, DenseVector rightSide)
		{
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			return (DenseVector)rightSide.Multiply(leftSide);
		}

		public static System.Numerics.Complex operator *(DenseVector leftSide, DenseVector rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return leftSide.DotProduct(rightSide);
		}

		public static DenseVector operator /(DenseVector leftSide, System.Numerics.Complex rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (DenseVector)leftSide.Divide(rightSide);
		}

		public override int AbsoluteMinimumIndex()
		{
			int num = 0;
			double num2 = _values[num].Magnitude;
			for (int i = 1; i < _length; i++)
			{
				double magnitude = _values[i].Magnitude;
				if (magnitude < num2)
				{
					num = i;
					num2 = magnitude;
				}
			}
			return num;
		}

		public override int AbsoluteMaximumIndex()
		{
			int num = 0;
			double num2 = _values[num].Magnitude;
			for (int i = 1; i < _length; i++)
			{
				double magnitude = _values[i].Magnitude;
				if (magnitude > num2)
				{
					num = i;
					num2 = magnitude;
				}
			}
			return num;
		}

		public override System.Numerics.Complex Sum()
		{
			System.Numerics.Complex zero = System.Numerics.Complex.Zero;
			for (int i = 0; i < _length; i++)
			{
				zero += _values[i];
			}
			return zero;
		}

		public override double L1Norm()
		{
			double num = 0.0;
			for (int i = 0; i < _length; i++)
			{
				num += _values[i].Magnitude;
			}
			return num;
		}

		public override double L2Norm()
		{
			return _values.Aggregate(System.Numerics.Complex.Zero, SpecialFunctions.Hypotenuse).Magnitude;
		}

		public override double InfinityNorm()
		{
			return CommonParallel.Aggregate(_values, (int _, System.Numerics.Complex v) => v.Magnitude, Math.Max, 0.0);
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
				num += Math.Pow(_values[i].Magnitude, p);
			}
			return Math.Pow(num, 1.0 / p);
		}

		protected override void DoPointwiseMultiply(Vector<System.Numerics.Complex> other, Vector<System.Numerics.Complex> result)
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

		protected override void DoPointwiseDivide(Vector<System.Numerics.Complex> divisor, Vector<System.Numerics.Complex> result)
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

		protected override void DoPointwisePower(Vector<System.Numerics.Complex> exponent, Vector<System.Numerics.Complex> result)
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
			return new DenseVector(list.ToArray());
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
