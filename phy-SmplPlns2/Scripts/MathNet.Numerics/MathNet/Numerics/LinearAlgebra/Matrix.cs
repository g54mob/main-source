using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Text;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.LinearAlgebra.Solvers;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra
{
	[Serializable]
	[DebuggerDisplay("Matrix {RowCount}x{ColumnCount}")]
	[DebuggerTypeProxy(typeof(MatrixDebuggingView<>))]
	public abstract class Matrix<T> : IFormattable, IEquatable<Matrix<T>>, ICloneable where T : struct, IEquatable<T>, IFormattable
	{
		public static readonly T One = BuilderInstance<T>.Matrix.One;

		public static readonly T Zero = BuilderInstance<T>.Matrix.Zero;

		public static readonly MatrixBuilder<T> Build = BuilderInstance<T>.Matrix;

		public MatrixStorage<T> Storage { get; private set; }

		public int ColumnCount { get; private set; }

		public int RowCount { get; private set; }

		public T this[int row, int column]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
			get
			{
				return Storage[row, column];
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
			set
			{
				Storage[row, column] = value;
			}
		}

		protected abstract void DoNegate(Matrix<T> result);

		protected abstract void DoConjugate(Matrix<T> result);

		protected abstract void DoAdd(T scalar, Matrix<T> result);

		protected abstract void DoAdd(Matrix<T> other, Matrix<T> result);

		protected abstract void DoSubtract(T scalar, Matrix<T> result);

		protected void DoSubtractFrom(T scalar, Matrix<T> result)
		{
			DoNegate(result);
			result.DoAdd(scalar, result);
		}

		protected abstract void DoSubtract(Matrix<T> other, Matrix<T> result);

		protected abstract void DoMultiply(T scalar, Matrix<T> result);

		protected abstract void DoMultiply(Vector<T> rightSide, Vector<T> result);

		protected abstract void DoMultiply(Matrix<T> other, Matrix<T> result);

		protected abstract void DoTransposeAndMultiply(Matrix<T> other, Matrix<T> result);

		protected abstract void DoConjugateTransposeAndMultiply(Matrix<T> other, Matrix<T> result);

		protected abstract void DoTransposeThisAndMultiply(Vector<T> rightSide, Vector<T> result);

		protected abstract void DoConjugateTransposeThisAndMultiply(Vector<T> rightSide, Vector<T> result);

		protected abstract void DoTransposeThisAndMultiply(Matrix<T> other, Matrix<T> result);

		protected abstract void DoConjugateTransposeThisAndMultiply(Matrix<T> other, Matrix<T> result);

		protected abstract void DoDivide(T divisor, Matrix<T> result);

		protected abstract void DoDivideByThis(T dividend, Matrix<T> result);

		protected abstract void DoModulus(T divisor, Matrix<T> result);

		protected abstract void DoModulusByThis(T dividend, Matrix<T> result);

		protected abstract void DoRemainder(T divisor, Matrix<T> result);

		protected abstract void DoRemainderByThis(T dividend, Matrix<T> result);

		protected abstract void DoPointwiseMultiply(Matrix<T> other, Matrix<T> result);

		protected abstract void DoPointwiseDivide(Matrix<T> divisor, Matrix<T> result);

		protected abstract void DoPointwisePower(T exponent, Matrix<T> result);

		protected abstract void DoPointwisePower(Matrix<T> exponent, Matrix<T> result);

		protected abstract void DoPointwiseModulus(Matrix<T> divisor, Matrix<T> result);

		protected abstract void DoPointwiseRemainder(Matrix<T> divisor, Matrix<T> result);

		protected abstract void DoPointwiseExp(Matrix<T> result);

		protected abstract void DoPointwiseLog(Matrix<T> result);

		protected abstract void DoPointwiseAbs(Matrix<T> result);

		protected abstract void DoPointwiseAcos(Matrix<T> result);

		protected abstract void DoPointwiseAsin(Matrix<T> result);

		protected abstract void DoPointwiseAtan(Matrix<T> result);

		protected abstract void DoPointwiseCeiling(Matrix<T> result);

		protected abstract void DoPointwiseCos(Matrix<T> result);

		protected abstract void DoPointwiseCosh(Matrix<T> result);

		protected abstract void DoPointwiseFloor(Matrix<T> result);

		protected abstract void DoPointwiseLog10(Matrix<T> result);

		protected abstract void DoPointwiseRound(Matrix<T> result);

		protected abstract void DoPointwiseSign(Matrix<T> result);

		protected abstract void DoPointwiseSin(Matrix<T> result);

		protected abstract void DoPointwiseSinh(Matrix<T> result);

		protected abstract void DoPointwiseSqrt(Matrix<T> result);

		protected abstract void DoPointwiseTan(Matrix<T> result);

		protected abstract void DoPointwiseTanh(Matrix<T> result);

		protected abstract void DoPointwiseAtan2(Matrix<T> other, Matrix<T> result);

		protected abstract void DoPointwiseMinimum(T scalar, Matrix<T> result);

		protected abstract void DoPointwiseMinimum(Matrix<T> other, Matrix<T> result);

		protected abstract void DoPointwiseMaximum(T scalar, Matrix<T> result);

		protected abstract void DoPointwiseMaximum(Matrix<T> other, Matrix<T> result);

		protected abstract void DoPointwiseAbsoluteMinimum(T scalar, Matrix<T> result);

		protected abstract void DoPointwiseAbsoluteMinimum(Matrix<T> other, Matrix<T> result);

		protected abstract void DoPointwiseAbsoluteMaximum(T scalar, Matrix<T> result);

		protected abstract void DoPointwiseAbsoluteMaximum(Matrix<T> other, Matrix<T> result);

		public Matrix<T> Add(T scalar)
		{
			if (scalar.Equals(Zero))
			{
				return Clone();
			}
			Matrix<T> result = Build.SameAs(this);
			DoAdd(scalar, result);
			return result;
		}

		public void Add(T scalar, Matrix<T> result)
		{
			if (result.RowCount != RowCount || result.ColumnCount != ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentOutOfRangeException>(this, result, "result");
			}
			if (scalar.Equals(Zero))
			{
				CopyTo(result);
			}
			else
			{
				DoAdd(scalar, result);
			}
		}

		public Matrix<T> Add(Matrix<T> other)
		{
			if (other.RowCount != RowCount || other.ColumnCount != ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentOutOfRangeException>(this, other);
			}
			Matrix<T> result = Build.SameAs(this, other, RowCount, ColumnCount);
			DoAdd(other, result);
			return result;
		}

		public void Add(Matrix<T> other, Matrix<T> result)
		{
			if (other.RowCount != RowCount || other.ColumnCount != ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentOutOfRangeException>(this, other, "other");
			}
			if (result.RowCount != RowCount || result.ColumnCount != ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentOutOfRangeException>(this, result, "result");
			}
			DoAdd(other, result);
		}

		public Matrix<T> Subtract(T scalar)
		{
			if (scalar.Equals(Zero))
			{
				return Clone();
			}
			Matrix<T> result = Build.SameAs(this);
			DoSubtract(scalar, result);
			return result;
		}

		public void Subtract(T scalar, Matrix<T> result)
		{
			if (result.RowCount != RowCount || result.ColumnCount != ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentOutOfRangeException>(this, result, "result");
			}
			if (scalar.Equals(Zero))
			{
				CopyTo(result);
			}
			else
			{
				DoSubtract(scalar, result);
			}
		}

		public Matrix<T> SubtractFrom(T scalar)
		{
			Matrix<T> result = Build.SameAs(this);
			DoSubtractFrom(scalar, result);
			return result;
		}

		public void SubtractFrom(T scalar, Matrix<T> result)
		{
			if (result.RowCount != RowCount || result.ColumnCount != ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentOutOfRangeException>(this, result, "result");
			}
			DoSubtractFrom(scalar, result);
		}

		public Matrix<T> Subtract(Matrix<T> other)
		{
			if (other.RowCount != RowCount || other.ColumnCount != ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentOutOfRangeException>(this, other);
			}
			Matrix<T> result = Build.SameAs(this, other, RowCount, ColumnCount);
			DoSubtract(other, result);
			return result;
		}

		public void Subtract(Matrix<T> other, Matrix<T> result)
		{
			if (other.RowCount != RowCount || other.ColumnCount != ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentOutOfRangeException>(this, other, "other");
			}
			if (result.RowCount != RowCount || result.ColumnCount != ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentOutOfRangeException>(this, result, "result");
			}
			DoSubtract(other, result);
		}

		public Matrix<T> Multiply(T scalar)
		{
			if (scalar.Equals(One))
			{
				return Clone();
			}
			if (scalar.Equals(Zero))
			{
				return Build.SameAs(this);
			}
			Matrix<T> result = Build.SameAs(this);
			DoMultiply(scalar, result);
			return result;
		}

		public void Multiply(T scalar, Matrix<T> result)
		{
			if (result.RowCount != RowCount)
			{
				throw new ArgumentException("Matrix row dimensions must agree.", "result");
			}
			if (result.ColumnCount != ColumnCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.", "result");
			}
			if (scalar.Equals(One))
			{
				CopyTo(result);
			}
			else if (scalar.Equals(Zero))
			{
				result.Clear();
			}
			else
			{
				DoMultiply(scalar, result);
			}
		}

		public Matrix<T> Divide(T scalar)
		{
			if (scalar.Equals(One))
			{
				return Clone();
			}
			if (scalar.Equals(Zero))
			{
				throw new DivideByZeroException();
			}
			Matrix<T> result = Build.SameAs(this);
			DoDivide(scalar, result);
			return result;
		}

		public void Divide(T scalar, Matrix<T> result)
		{
			if (result.RowCount != RowCount)
			{
				throw new ArgumentException("Matrix row dimensions must agree.", "result");
			}
			if (result.ColumnCount != ColumnCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.", "result");
			}
			if (scalar.Equals(One))
			{
				CopyTo(result);
				return;
			}
			if (scalar.Equals(Zero))
			{
				throw new DivideByZeroException();
			}
			DoDivide(scalar, result);
		}

		public Matrix<T> DivideByThis(T scalar)
		{
			Matrix<T> result = Build.SameAs(this);
			DoDivideByThis(scalar, result);
			return result;
		}

		public void DivideByThis(T scalar, Matrix<T> result)
		{
			if (result.RowCount != RowCount)
			{
				throw new ArgumentException("Matrix row dimensions must agree.", "result");
			}
			if (result.ColumnCount != ColumnCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.", "result");
			}
			DoDivideByThis(scalar, result);
		}

		public Vector<T> Multiply(Vector<T> rightSide)
		{
			if (ColumnCount != rightSide.Count)
			{
				throw DimensionsDontMatch<ArgumentException>(this, rightSide, "rightSide");
			}
			Vector<T> result = Vector<T>.Build.SameAs(this, rightSide, RowCount);
			DoMultiply(rightSide, result);
			return result;
		}

		public void Multiply(Vector<T> rightSide, Vector<T> result)
		{
			if (ColumnCount != rightSide.Count)
			{
				throw DimensionsDontMatch<ArgumentException>(this, rightSide, "rightSide");
			}
			if (RowCount != result.Count)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			if (rightSide == result)
			{
				Vector<T> vector = Vector<T>.Build.SameAs(result);
				DoMultiply(rightSide, vector);
				vector.CopyTo(result);
			}
			else
			{
				DoMultiply(rightSide, result);
			}
		}

		public Vector<T> LeftMultiply(Vector<T> leftSide)
		{
			if (RowCount != leftSide.Count)
			{
				throw DimensionsDontMatch<ArgumentException>(this, leftSide, "leftSide");
			}
			Vector<T> result = Vector<T>.Build.SameAs(this, leftSide, ColumnCount);
			DoLeftMultiply(leftSide, result);
			return result;
		}

		public void LeftMultiply(Vector<T> leftSide, Vector<T> result)
		{
			if (RowCount != leftSide.Count)
			{
				throw DimensionsDontMatch<ArgumentException>(this, leftSide, "leftSide");
			}
			if (ColumnCount != result.Count)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			if (leftSide == result)
			{
				Vector<T> vector = Vector<T>.Build.SameAs(result);
				DoLeftMultiply(leftSide, vector);
				vector.CopyTo(result);
			}
			else
			{
				DoLeftMultiply(leftSide, result);
			}
		}

		protected void DoLeftMultiply(Vector<T> leftSide, Vector<T> result)
		{
			DoTransposeThisAndMultiply(leftSide, result);
		}

		public void Multiply(Matrix<T> other, Matrix<T> result)
		{
			if (ColumnCount != other.RowCount || result.RowCount != RowCount || result.ColumnCount != other.ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, other, result);
			}
			if (this == result || other == result)
			{
				Matrix<T> matrix = Build.SameAs(result);
				DoMultiply(other, matrix);
				matrix.CopyTo(result);
			}
			else
			{
				DoMultiply(other, result);
			}
		}

		public Matrix<T> Multiply(Matrix<T> other)
		{
			if (ColumnCount != other.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, other);
			}
			Matrix<T> result = Build.SameAs(this, other, RowCount, other.ColumnCount);
			DoMultiply(other, result);
			return result;
		}

		public void TransposeAndMultiply(Matrix<T> other, Matrix<T> result)
		{
			if (ColumnCount != other.ColumnCount || result.RowCount != RowCount || result.ColumnCount != other.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, other, result);
			}
			if (this == result || other == result)
			{
				Matrix<T> matrix = Build.SameAs(result);
				DoTransposeAndMultiply(other, matrix);
				matrix.CopyTo(result);
			}
			else
			{
				DoTransposeAndMultiply(other, result);
			}
		}

		public Matrix<T> TransposeAndMultiply(Matrix<T> other)
		{
			if (ColumnCount != other.ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, other);
			}
			Matrix<T> result = Build.SameAs(this, other, RowCount, other.RowCount);
			DoTransposeAndMultiply(other, result);
			return result;
		}

		public Vector<T> TransposeThisAndMultiply(Vector<T> rightSide)
		{
			if (RowCount != rightSide.Count)
			{
				throw DimensionsDontMatch<ArgumentException>(this, rightSide, "rightSide");
			}
			Vector<T> result = Vector<T>.Build.SameAs(this, rightSide, ColumnCount);
			DoTransposeThisAndMultiply(rightSide, result);
			return result;
		}

		public void TransposeThisAndMultiply(Vector<T> rightSide, Vector<T> result)
		{
			if (RowCount != rightSide.Count)
			{
				throw DimensionsDontMatch<ArgumentException>(this, rightSide, "rightSide");
			}
			if (ColumnCount != result.Count)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			if (rightSide == result)
			{
				Vector<T> vector = Vector<T>.Build.SameAs(result);
				DoTransposeThisAndMultiply(rightSide, vector);
				vector.CopyTo(result);
			}
			else
			{
				DoTransposeThisAndMultiply(rightSide, result);
			}
		}

		public void TransposeThisAndMultiply(Matrix<T> other, Matrix<T> result)
		{
			if (RowCount != other.RowCount || result.RowCount != ColumnCount || result.ColumnCount != other.ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, other, result);
			}
			if (this == result || other == result)
			{
				Matrix<T> matrix = Build.SameAs(result);
				DoTransposeThisAndMultiply(other, matrix);
				matrix.CopyTo(result);
			}
			else
			{
				DoTransposeThisAndMultiply(other, result);
			}
		}

		public Matrix<T> TransposeThisAndMultiply(Matrix<T> other)
		{
			if (RowCount != other.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, other);
			}
			Matrix<T> result = Build.SameAs(this, other, ColumnCount, other.ColumnCount);
			DoTransposeThisAndMultiply(other, result);
			return result;
		}

		public void ConjugateTransposeAndMultiply(Matrix<T> other, Matrix<T> result)
		{
			if (ColumnCount != other.ColumnCount || result.RowCount != RowCount || result.ColumnCount != other.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, other, result);
			}
			if (this == result || other == result)
			{
				Matrix<T> matrix = Build.SameAs(result);
				DoConjugateTransposeAndMultiply(other, matrix);
				matrix.CopyTo(result);
			}
			else
			{
				DoConjugateTransposeAndMultiply(other, result);
			}
		}

		public Matrix<T> ConjugateTransposeAndMultiply(Matrix<T> other)
		{
			if (ColumnCount != other.ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, other);
			}
			Matrix<T> result = Build.SameAs(this, other, RowCount, other.RowCount);
			DoConjugateTransposeAndMultiply(other, result);
			return result;
		}

		public Vector<T> ConjugateTransposeThisAndMultiply(Vector<T> rightSide)
		{
			if (RowCount != rightSide.Count)
			{
				throw DimensionsDontMatch<ArgumentException>(this, rightSide, "rightSide");
			}
			Vector<T> result = Vector<T>.Build.SameAs(this, rightSide, ColumnCount);
			DoConjugateTransposeThisAndMultiply(rightSide, result);
			return result;
		}

		public void ConjugateTransposeThisAndMultiply(Vector<T> rightSide, Vector<T> result)
		{
			if (RowCount != rightSide.Count)
			{
				throw DimensionsDontMatch<ArgumentException>(this, rightSide, "rightSide");
			}
			if (ColumnCount != result.Count)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			if (rightSide == result)
			{
				Vector<T> vector = Vector<T>.Build.SameAs(result);
				DoConjugateTransposeThisAndMultiply(rightSide, vector);
				vector.CopyTo(result);
			}
			else
			{
				DoConjugateTransposeThisAndMultiply(rightSide, result);
			}
		}

		public void ConjugateTransposeThisAndMultiply(Matrix<T> other, Matrix<T> result)
		{
			if (RowCount != other.RowCount || result.RowCount != ColumnCount || result.ColumnCount != other.ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, other, result);
			}
			if (this == result || other == result)
			{
				Matrix<T> matrix = Build.SameAs(result);
				DoConjugateTransposeThisAndMultiply(other, matrix);
				matrix.CopyTo(result);
			}
			else
			{
				DoConjugateTransposeThisAndMultiply(other, result);
			}
		}

		public Matrix<T> ConjugateTransposeThisAndMultiply(Matrix<T> other)
		{
			if (RowCount != other.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, other);
			}
			Matrix<T> result = Build.SameAs(this, other, ColumnCount, other.ColumnCount);
			DoConjugateTransposeThisAndMultiply(other, result);
			return result;
		}

		private static Matrix<T> IntPower(int exponent, Matrix<T> x, Matrix<T> y, Matrix<T> work)
		{
			switch (exponent)
			{
			case 1:
				if (y == null)
				{
					return x;
				}
				if (work == null)
				{
					work = y.Multiply(x);
				}
				else
				{
					y.Multiply(x, work);
				}
				return work;
			case 2:
				if (work == null)
				{
					work = x.Multiply(x);
				}
				else
				{
					x.Multiply(x, work);
				}
				if (y == null)
				{
					return work;
				}
				y.Multiply(work, x);
				return x;
			default:
				if (exponent.IsEven())
				{
					if (work == null)
					{
						work = x.Multiply(x);
					}
					else
					{
						x.Multiply(x, work);
					}
					return IntPower(exponent / 2, work, y, x);
				}
				if (y == null)
				{
					if (work == null)
					{
						work = x.Multiply(x);
					}
					else
					{
						x.Multiply(x, work);
					}
					return IntPower((exponent - 1) / 2, work, x, null);
				}
				if (work == null)
				{
					work = y.Multiply(x);
				}
				else
				{
					y.Multiply(x, work);
				}
				x.Multiply(x, y);
				return IntPower((exponent - 1) / 2, y, work, x);
			}
		}

		public void Power(int exponent, Matrix<T> result)
		{
			if (RowCount != ColumnCount || result.RowCount != RowCount || result.ColumnCount != ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result);
			}
			if (exponent < 0)
			{
				throw new ArgumentException("Value must not be negative (zero is ok).");
			}
			switch (exponent)
			{
			case 0:
				Build.DiagonalIdentity(RowCount, ColumnCount).CopyTo(result);
				return;
			case 1:
				CopyTo(result);
				return;
			case 2:
				Multiply(this, result);
				return;
			}
			Matrix<T> matrix = IntPower(exponent, Clone(), null, result);
			if (matrix != result)
			{
				matrix.CopyTo(result);
			}
		}

		public Matrix<T> Power(int exponent)
		{
			if (RowCount != ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			if (exponent < 0)
			{
				throw new ArgumentException("Value must not be negative (zero is ok).");
			}
			return exponent switch
			{
				0 => Build.DiagonalIdentity(RowCount, ColumnCount), 
				1 => this, 
				2 => Multiply(this), 
				_ => IntPower(exponent, Clone(), null, null), 
			};
		}

		public Matrix<T> Negate()
		{
			Matrix<T> result = Build.SameAs(this);
			DoNegate(result);
			return result;
		}

		public void Negate(Matrix<T> result)
		{
			if (result.RowCount != RowCount || result.ColumnCount != ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result);
			}
			DoNegate(result);
		}

		public Matrix<T> Conjugate()
		{
			Matrix<T> result = Build.SameAs(this);
			DoConjugate(result);
			return result;
		}

		public void Conjugate(Matrix<T> result)
		{
			if (result.RowCount != RowCount || result.ColumnCount != ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result);
			}
			DoConjugate(result);
		}

		public Matrix<T> Modulus(T divisor)
		{
			Matrix<T> result = Build.SameAs(this);
			DoModulus(divisor, result);
			return result;
		}

		public void Modulus(T divisor, Matrix<T> result)
		{
			if (ColumnCount != result.ColumnCount || RowCount != result.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result);
			}
			DoModulus(divisor, result);
		}

		public Matrix<T> ModulusByThis(T dividend)
		{
			Matrix<T> result = Build.SameAs(this);
			DoModulusByThis(dividend, result);
			return result;
		}

		public void ModulusByThis(T dividend, Matrix<T> result)
		{
			if (ColumnCount != result.ColumnCount || RowCount != result.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result);
			}
			DoModulusByThis(dividend, result);
		}

		public Matrix<T> Remainder(T divisor)
		{
			Matrix<T> result = Build.SameAs(this);
			DoRemainder(divisor, result);
			return result;
		}

		public void Remainder(T divisor, Matrix<T> result)
		{
			if (ColumnCount != result.ColumnCount || RowCount != result.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result);
			}
			DoRemainder(divisor, result);
		}

		public Matrix<T> RemainderByThis(T dividend)
		{
			Matrix<T> result = Build.SameAs(this);
			DoRemainderByThis(dividend, result);
			return result;
		}

		public void RemainderByThis(T dividend, Matrix<T> result)
		{
			if (ColumnCount != result.ColumnCount || RowCount != result.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result);
			}
			DoRemainderByThis(dividend, result);
		}

		public Matrix<T> PointwiseMultiply(Matrix<T> other)
		{
			if (ColumnCount != other.ColumnCount || RowCount != other.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, other, "other");
			}
			Matrix<T> result = Build.SameAs(this, other);
			DoPointwiseMultiply(other, result);
			return result;
		}

		public void PointwiseMultiply(Matrix<T> other, Matrix<T> result)
		{
			if (ColumnCount != result.ColumnCount || RowCount != result.RowCount || ColumnCount != other.ColumnCount || RowCount != other.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, other, result);
			}
			DoPointwiseMultiply(other, result);
		}

		public Matrix<T> PointwiseDivide(Matrix<T> divisor)
		{
			if (ColumnCount != divisor.ColumnCount || RowCount != divisor.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, divisor);
			}
			Matrix<T> result = Build.SameAs(this, divisor);
			DoPointwiseDivide(divisor, result);
			return result;
		}

		public void PointwiseDivide(Matrix<T> divisor, Matrix<T> result)
		{
			if (ColumnCount != result.ColumnCount || RowCount != result.RowCount || ColumnCount != divisor.ColumnCount || RowCount != divisor.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, divisor, result);
			}
			DoPointwiseDivide(divisor, result);
		}

		public Matrix<T> PointwisePower(T exponent)
		{
			Matrix<T> result = Build.SameAs(this);
			DoPointwisePower(exponent, result);
			return result;
		}

		public void PointwisePower(T exponent, Matrix<T> result)
		{
			if (ColumnCount != result.ColumnCount || RowCount != result.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result);
			}
			DoPointwisePower(exponent, result);
		}

		public Matrix<T> PointwisePower(Matrix<T> exponent)
		{
			if (ColumnCount != exponent.ColumnCount || RowCount != exponent.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, exponent);
			}
			Matrix<T> result = Build.SameAs(this);
			DoPointwisePower(exponent, result);
			return result;
		}

		public void PointwisePower(Matrix<T> exponent, Matrix<T> result)
		{
			if (ColumnCount != result.ColumnCount || RowCount != result.RowCount || ColumnCount != exponent.ColumnCount || RowCount != exponent.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, exponent, result);
			}
			DoPointwisePower(exponent, result);
		}

		public Matrix<T> PointwiseModulus(Matrix<T> divisor)
		{
			if (ColumnCount != divisor.ColumnCount || RowCount != divisor.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, divisor);
			}
			Matrix<T> result = Build.SameAs(this, divisor);
			DoPointwiseModulus(divisor, result);
			return result;
		}

		public void PointwiseModulus(Matrix<T> divisor, Matrix<T> result)
		{
			if (ColumnCount != result.ColumnCount || RowCount != result.RowCount || ColumnCount != divisor.ColumnCount || RowCount != divisor.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, divisor, result);
			}
			DoPointwiseModulus(divisor, result);
		}

		public Matrix<T> PointwiseRemainder(Matrix<T> divisor)
		{
			if (ColumnCount != divisor.ColumnCount || RowCount != divisor.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, divisor);
			}
			Matrix<T> result = Build.SameAs(this, divisor);
			DoPointwiseRemainder(divisor, result);
			return result;
		}

		public void PointwiseRemainder(Matrix<T> divisor, Matrix<T> result)
		{
			if (ColumnCount != result.ColumnCount || RowCount != result.RowCount || ColumnCount != divisor.ColumnCount || RowCount != divisor.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, divisor, result);
			}
			DoPointwiseRemainder(divisor, result);
		}

		protected Matrix<T> PointwiseUnary(Action<Matrix<T>> f)
		{
			Matrix<T> matrix = Build.SameAs(this);
			f(matrix);
			return matrix;
		}

		protected void PointwiseUnary(Action<Matrix<T>> f, Matrix<T> result)
		{
			if (ColumnCount != result.ColumnCount || RowCount != result.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result);
			}
			f(result);
		}

		protected Matrix<T> PointwiseBinary(Action<Matrix<T>, Matrix<T>> f, Matrix<T> other)
		{
			if (ColumnCount != other.ColumnCount || RowCount != other.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, other);
			}
			Matrix<T> matrix = Build.SameAs(this, other);
			f(other, matrix);
			return matrix;
		}

		protected void PointwiseBinary(Action<Matrix<T>, Matrix<T>> f, Matrix<T> other, Matrix<T> result)
		{
			if (ColumnCount != result.ColumnCount || RowCount != result.RowCount || ColumnCount != other.ColumnCount || RowCount != other.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, other, result);
			}
			f(other, result);
		}

		public Matrix<T> PointwiseExp()
		{
			return PointwiseUnary(DoPointwiseExp);
		}

		public void PointwiseExp(Matrix<T> result)
		{
			PointwiseUnary(DoPointwiseExp, result);
		}

		public Matrix<T> PointwiseLog()
		{
			return PointwiseUnary(DoPointwiseLog);
		}

		public void PointwiseLog(Matrix<T> result)
		{
			PointwiseUnary(DoPointwiseLog, result);
		}

		public Matrix<T> PointwiseAbs()
		{
			return PointwiseUnary(DoPointwiseAbs);
		}

		public void PointwiseAbs(Matrix<T> result)
		{
			PointwiseUnary(DoPointwiseAbs, result);
		}

		public Matrix<T> PointwiseAcos()
		{
			return PointwiseUnary(DoPointwiseAcos);
		}

		public void PointwiseAcos(Matrix<T> result)
		{
			PointwiseUnary(DoPointwiseAcos, result);
		}

		public Matrix<T> PointwiseAsin()
		{
			return PointwiseUnary(DoPointwiseAsin);
		}

		public void PointwiseAsin(Matrix<T> result)
		{
			PointwiseUnary(DoPointwiseAsin, result);
		}

		public Matrix<T> PointwiseAtan()
		{
			return PointwiseUnary(DoPointwiseAtan);
		}

		public void PointwiseAtan(Matrix<T> result)
		{
			PointwiseUnary(DoPointwiseAtan, result);
		}

		public Matrix<T> PointwiseAtan2(Matrix<T> other)
		{
			return PointwiseBinary(DoPointwiseAtan2, other);
		}

		public void PointwiseAtan2(Matrix<T> other, Matrix<T> result)
		{
			PointwiseBinary(DoPointwiseAtan2, other, result);
		}

		public Matrix<T> PointwiseCeiling()
		{
			return PointwiseUnary(DoPointwiseCeiling);
		}

		public void PointwiseCeiling(Matrix<T> result)
		{
			PointwiseUnary(DoPointwiseCeiling, result);
		}

		public Matrix<T> PointwiseCos()
		{
			return PointwiseUnary(DoPointwiseCos);
		}

		public void PointwiseCos(Matrix<T> result)
		{
			PointwiseUnary(DoPointwiseCos, result);
		}

		public Matrix<T> PointwiseCosh()
		{
			return PointwiseUnary(DoPointwiseCosh);
		}

		public void PointwiseCosh(Matrix<T> result)
		{
			PointwiseUnary(DoPointwiseCosh, result);
		}

		public Matrix<T> PointwiseFloor()
		{
			return PointwiseUnary(DoPointwiseFloor);
		}

		public void PointwiseFloor(Matrix<T> result)
		{
			PointwiseUnary(DoPointwiseFloor, result);
		}

		public Matrix<T> PointwiseLog10()
		{
			return PointwiseUnary(DoPointwiseLog10);
		}

		public void PointwiseLog10(Matrix<T> result)
		{
			PointwiseUnary(DoPointwiseLog10, result);
		}

		public Matrix<T> PointwiseRound()
		{
			return PointwiseUnary(DoPointwiseRound);
		}

		public void PointwiseRound(Matrix<T> result)
		{
			PointwiseUnary(DoPointwiseRound, result);
		}

		public Matrix<T> PointwiseSign()
		{
			return PointwiseUnary(DoPointwiseSign);
		}

		public void PointwiseSign(Matrix<T> result)
		{
			PointwiseUnary(DoPointwiseSign, result);
		}

		public Matrix<T> PointwiseSin()
		{
			return PointwiseUnary(DoPointwiseSin);
		}

		public void PointwiseSin(Matrix<T> result)
		{
			PointwiseUnary(DoPointwiseSin, result);
		}

		public Matrix<T> PointwiseSinh()
		{
			return PointwiseUnary(DoPointwiseSinh);
		}

		public void PointwiseSinh(Matrix<T> result)
		{
			PointwiseUnary(DoPointwiseSinh, result);
		}

		public Matrix<T> PointwiseSqrt()
		{
			return PointwiseUnary(DoPointwiseSqrt);
		}

		public void PointwiseSqrt(Matrix<T> result)
		{
			PointwiseUnary(DoPointwiseSqrt, result);
		}

		public Matrix<T> PointwiseTan()
		{
			return PointwiseUnary(DoPointwiseTan);
		}

		public void PointwiseTan(Matrix<T> result)
		{
			PointwiseUnary(DoPointwiseTan, result);
		}

		public Matrix<T> PointwiseTanh()
		{
			return PointwiseUnary(DoPointwiseTanh);
		}

		public void PointwiseTanh(Matrix<T> result)
		{
			PointwiseUnary(DoPointwiseTanh, result);
		}

		public abstract T Trace();

		public virtual int Rank()
		{
			return Svd(computeVectors: false).Rank;
		}

		public int Nullity()
		{
			return ColumnCount - Rank();
		}

		public virtual T ConditionNumber()
		{
			return Svd(computeVectors: false).ConditionNumber;
		}

		public virtual T Determinant()
		{
			if (RowCount != ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			return LU().Determinant;
		}

		public virtual Vector<T>[] Kernel()
		{
			Svd<T> svd = Svd();
			return svd.VT.EnumerateRows(svd.Rank, ColumnCount - svd.Rank).ToArray();
		}

		public virtual Vector<T>[] Range()
		{
			Svd<T> svd = Svd();
			return svd.U.EnumerateColumns(0, svd.Rank).ToArray();
		}

		public virtual Matrix<T> Inverse()
		{
			if (RowCount != ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			return LU().Inverse();
		}

		public abstract Matrix<T> PseudoInverse();

		public Matrix<T> KroneckerProduct(Matrix<T> other)
		{
			Matrix<T> result = Build.SameAs(this, other, RowCount * other.RowCount, ColumnCount * other.ColumnCount);
			KroneckerProduct(other, result);
			return result;
		}

		public virtual void KroneckerProduct(Matrix<T> other, Matrix<T> result)
		{
			if (result.RowCount != RowCount * other.RowCount || result.ColumnCount != ColumnCount * other.ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentOutOfRangeException>(this, other, result);
			}
			for (int i = 0; i < ColumnCount; i++)
			{
				for (int j = 0; j < RowCount; j++)
				{
					result.SetSubMatrix(j * other.RowCount, other.RowCount, i * other.ColumnCount, other.ColumnCount, At(j, i) * other);
				}
			}
		}

		public Matrix<T> PointwiseMinimum(T scalar)
		{
			Matrix<T> result = Build.SameAs(this);
			DoPointwiseMinimum(scalar, result);
			return result;
		}

		public void PointwiseMinimum(T scalar, Matrix<T> result)
		{
			if (ColumnCount != result.ColumnCount || RowCount != result.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result);
			}
			DoPointwiseMinimum(scalar, result);
		}

		public Matrix<T> PointwiseMaximum(T scalar)
		{
			Matrix<T> result = Build.SameAs(this);
			DoPointwiseMaximum(scalar, result);
			return result;
		}

		public void PointwiseMaximum(T scalar, Matrix<T> result)
		{
			if (ColumnCount != result.ColumnCount || RowCount != result.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result);
			}
			DoPointwiseMaximum(scalar, result);
		}

		public Matrix<T> PointwiseAbsoluteMinimum(T scalar)
		{
			Matrix<T> result = Build.SameAs(this);
			DoPointwiseAbsoluteMinimum(scalar, result);
			return result;
		}

		public void PointwiseAbsoluteMinimum(T scalar, Matrix<T> result)
		{
			if (ColumnCount != result.ColumnCount || RowCount != result.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result);
			}
			DoPointwiseAbsoluteMinimum(scalar, result);
		}

		public Matrix<T> PointwiseAbsoluteMaximum(T scalar)
		{
			Matrix<T> result = Build.SameAs(this);
			DoPointwiseAbsoluteMaximum(scalar, result);
			return result;
		}

		public void PointwiseAbsoluteMaximum(T scalar, Matrix<T> result)
		{
			if (ColumnCount != result.ColumnCount || RowCount != result.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result);
			}
			DoPointwiseAbsoluteMaximum(scalar, result);
		}

		public Matrix<T> PointwiseMinimum(Matrix<T> other)
		{
			Matrix<T> result = Build.SameAs(this);
			DoPointwiseMinimum(other, result);
			return result;
		}

		public void PointwiseMinimum(Matrix<T> other, Matrix<T> result)
		{
			if (ColumnCount != result.ColumnCount || RowCount != result.RowCount || ColumnCount != other.ColumnCount || RowCount != other.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, other, result);
			}
			DoPointwiseMinimum(other, result);
		}

		public Matrix<T> PointwiseMaximum(Matrix<T> other)
		{
			Matrix<T> result = Build.SameAs(this);
			DoPointwiseMaximum(other, result);
			return result;
		}

		public void PointwiseMaximum(Matrix<T> other, Matrix<T> result)
		{
			if (ColumnCount != result.ColumnCount || RowCount != result.RowCount || ColumnCount != other.ColumnCount || RowCount != other.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, other, result);
			}
			DoPointwiseMaximum(other, result);
		}

		public Matrix<T> PointwiseAbsoluteMinimum(Matrix<T> other)
		{
			Matrix<T> result = Build.SameAs(this);
			DoPointwiseAbsoluteMinimum(other, result);
			return result;
		}

		public void PointwiseAbsoluteMinimum(Matrix<T> other, Matrix<T> result)
		{
			if (ColumnCount != result.ColumnCount || RowCount != result.RowCount || ColumnCount != other.ColumnCount || RowCount != other.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, other, result);
			}
			DoPointwiseAbsoluteMinimum(other, result);
		}

		public Matrix<T> PointwiseAbsoluteMaximum(Matrix<T> other)
		{
			Matrix<T> result = Build.SameAs(this);
			DoPointwiseAbsoluteMaximum(other, result);
			return result;
		}

		public void PointwiseAbsoluteMaximum(Matrix<T> other, Matrix<T> result)
		{
			if (ColumnCount != result.ColumnCount || RowCount != result.RowCount || ColumnCount != other.ColumnCount || RowCount != other.RowCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, other, result);
			}
			DoPointwiseAbsoluteMaximum(other, result);
		}

		public abstract double L1Norm();

		public virtual double L2Norm()
		{
			return Svd(computeVectors: false).L2Norm;
		}

		public abstract double InfinityNorm();

		public abstract double FrobeniusNorm();

		public abstract Vector<double> RowNorms(double norm);

		public abstract Vector<double> ColumnNorms(double norm);

		public abstract Matrix<T> NormalizeRows(double norm);

		public abstract Matrix<T> NormalizeColumns(double norm);

		public abstract Vector<T> RowSums();

		public abstract Vector<T> ColumnSums();

		public abstract Vector<T> RowAbsoluteSums();

		public abstract Vector<T> ColumnAbsoluteSums();

		internal static Exception DimensionsDontMatch<TException>(Matrix<T> left, Matrix<T> right, Matrix<T> result, string paramName = null) where TException : Exception
		{
			return CreateException<TException>($"Matrix dimensions must agree: op1 is {left.RowCount}x{left.ColumnCount}, op2 is {right.RowCount}x{right.ColumnCount}, op3 is {result.RowCount}x{result.ColumnCount}.", paramName);
		}

		internal static Exception DimensionsDontMatch<TException>(Matrix<T> left, Matrix<T> right, string paramName = null) where TException : Exception
		{
			return CreateException<TException>($"Matrix dimensions must agree: op1 is {left.RowCount}x{left.ColumnCount}, op2 is {right.RowCount}x{right.ColumnCount}.", paramName);
		}

		internal static Exception DimensionsDontMatch<TException>(Matrix<T> matrix) where TException : Exception
		{
			return CreateException<TException>($"Matrix dimensions must agree: {matrix.RowCount}x{matrix.ColumnCount}.");
		}

		internal static Exception DimensionsDontMatch<TException>(Matrix<T> left, Vector<T> right, Vector<T> result, string paramName = null) where TException : Exception
		{
			return DimensionsDontMatch<TException>(left, right.ToColumnMatrix(), result.ToColumnMatrix(), paramName);
		}

		internal static Exception DimensionsDontMatch<TException>(Matrix<T> left, Vector<T> right, string paramName = null) where TException : Exception
		{
			return DimensionsDontMatch<TException>(left, right.ToColumnMatrix(), paramName);
		}

		internal static Exception DimensionsDontMatch<TException>(Vector<T> left, Matrix<T> right, string paramName = null) where TException : Exception
		{
			return DimensionsDontMatch<TException>(left.ToColumnMatrix(), right, paramName);
		}

		internal static Exception DimensionsDontMatch<TException>(Vector<T> left, Vector<T> right, string paramName = null) where TException : Exception
		{
			return DimensionsDontMatch<TException>(left.ToColumnMatrix(), right.ToColumnMatrix(), paramName);
		}

		private static Exception CreateException<TException>(string message, string paramName = null) where TException : Exception
		{
			if (typeof(TException) == typeof(ArgumentException))
			{
				return new ArgumentException(message, paramName);
			}
			if (typeof(TException) == typeof(ArgumentOutOfRangeException))
			{
				return new ArgumentOutOfRangeException(paramName, message);
			}
			return new Exception(message);
		}

		public bool Equals(Matrix<T> other)
		{
			if (other != null)
			{
				return Storage.Equals(other.Storage);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is Matrix<T> matrix)
			{
				return Storage.Equals(matrix.Storage);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Storage.GetHashCode();
		}

		object ICloneable.Clone()
		{
			return Clone();
		}

		public virtual string ToTypeString()
		{
			return FormattableString.Invariant($"{GetType().Name} {RowCount}x{ColumnCount}-{typeof(T).Name}");
		}

		public string[,] ToMatrixStringArray(int upperRows, int lowerRows, int leftColumns, int rightColumns, string horizontalEllipsis, string verticalEllipsis, string diagonalEllipsis, Func<T, string> formatValue)
		{
			upperRows = Math.Max(upperRows, 1);
			lowerRows = Math.Max(lowerRows, 0);
			leftColumns = Math.Max(leftColumns, 1);
			rightColumns = Math.Max(rightColumns, 0);
			int num = ((RowCount <= upperRows) ? RowCount : upperRows);
			int num2 = ((RowCount > upperRows) ? ((RowCount <= upperRows + lowerRows) ? (RowCount - upperRows) : lowerRows) : 0);
			bool flag = RowCount > num + num2;
			int num3 = (flag ? (num + num2 + 1) : (num + num2));
			int num4 = ((ColumnCount <= leftColumns) ? ColumnCount : leftColumns);
			int num5 = ((ColumnCount > leftColumns) ? ((ColumnCount <= leftColumns + rightColumns) ? (ColumnCount - leftColumns) : rightColumns) : 0);
			bool flag2 = ColumnCount > num4 + num5;
			int num6 = (flag2 ? (num4 + num5 + 1) : (num4 + num5));
			string[,] array = new string[num3, num6];
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num4; j++)
				{
					array[i, j] = formatValue(At(i, j));
				}
				int num7 = num4;
				if (flag2)
				{
					array[i, num4] = horizontalEllipsis;
					num7++;
				}
				for (int k = 0; k < num5; k++)
				{
					array[i, num7 + k] = formatValue(At(i, ColumnCount - num5 + k));
				}
			}
			int num8 = num;
			if (flag)
			{
				for (int l = 0; l < num4; l++)
				{
					array[num, l] = verticalEllipsis;
				}
				int num9 = num4;
				if (flag2)
				{
					array[num, num4] = diagonalEllipsis;
					num9++;
				}
				for (int m = 0; m < num5; m++)
				{
					array[num, num9 + m] = verticalEllipsis;
				}
				num8++;
			}
			for (int n = 0; n < num2; n++)
			{
				for (int num10 = 0; num10 < num4; num10++)
				{
					array[num8 + n, num10] = formatValue(At(RowCount - num2 + n, num10));
				}
				int num11 = num4;
				if (flag2)
				{
					array[num8 + n, num4] = horizontalEllipsis;
					num11++;
				}
				for (int num12 = 0; num12 < num5; num12++)
				{
					array[num8 + n, num11 + num12] = formatValue(At(RowCount - num2 + n, ColumnCount - num5 + num12));
				}
			}
			return array;
		}

		public string[,] ToMatrixStringArray(int upperRows, int lowerRows, int minLeftColumns, int rightColumns, int maxWidth, int padding, string horizontalEllipsis, string verticalEllipsis, string diagonalEllipsis, Func<T, string> formatValue)
		{
			upperRows = Math.Max(upperRows, 1);
			lowerRows = Math.Max(lowerRows, 0);
			minLeftColumns = Math.Max(minLeftColumns, 1);
			maxWidth = Math.Max(maxWidth, 12);
			int num = ((RowCount <= upperRows) ? RowCount : upperRows);
			int num2 = ((RowCount > upperRows) ? ((RowCount <= upperRows + lowerRows) ? (RowCount - upperRows) : lowerRows) : 0);
			bool flag = RowCount > num + num2;
			int num3 = (flag ? (num + num2 + 1) : (num + num2));
			int num4 = ((ColumnCount <= minLeftColumns) ? ColumnCount : minLeftColumns);
			int num5 = ((ColumnCount > minLeftColumns) ? ((ColumnCount <= minLeftColumns + rightColumns) ? (ColumnCount - minLeftColumns) : rightColumns) : 0);
			List<Tuple<int, string[]>> list = new List<Tuple<int, string[]>>();
			for (int i = 0; i < num4; i++)
			{
				list.Add(FormatColumn(i, num3, num, num2, flag, verticalEllipsis, formatValue));
			}
			List<Tuple<int, string[]>> list2 = new List<Tuple<int, string[]>>();
			for (int j = 0; j < num5; j++)
			{
				list2.Add(FormatColumn(ColumnCount - num5 + j, num3, num, num2, flag, verticalEllipsis, formatValue));
			}
			int num6 = list.Sum((Tuple<int, string[]> t) => t.Item1 + padding) + list2.Sum((Tuple<int, string[]> t) => t.Item1 + padding);
			for (int num7 = num4; num7 < ColumnCount - num5; num7++)
			{
				Tuple<int, string[]> tuple = FormatColumn(num7, num3, num, num2, flag, verticalEllipsis, formatValue);
				num6 += tuple.Item1 + padding;
				if (num6 > maxWidth)
				{
					break;
				}
				list.Add(tuple);
			}
			int num8 = list.Count + list2.Count;
			bool flag2 = ColumnCount > num8;
			if (flag2)
			{
				num8++;
			}
			string[,] array = new string[num3, num8];
			int num9 = 0;
			foreach (Tuple<int, string[]> item3 in list)
			{
				string[] item = item3.Item2;
				for (int num10 = 0; num10 < item3.Item2.Length; num10++)
				{
					array[num10, num9] = item[num10];
				}
				num9++;
			}
			if (flag2)
			{
				int num11 = 0;
				for (int num12 = 0; num12 < num; num12++)
				{
					array[num11++, num9] = horizontalEllipsis;
				}
				if (flag)
				{
					array[num11++, num9] = diagonalEllipsis;
				}
				for (int num13 = RowCount - num2; num13 < RowCount; num13++)
				{
					array[num11++, num9] = horizontalEllipsis;
				}
				num9++;
			}
			foreach (Tuple<int, string[]> item4 in list2)
			{
				string[] item2 = item4.Item2;
				for (int num14 = 0; num14 < item4.Item2.Length; num14++)
				{
					array[num14, num9] = item2[num14];
				}
				num9++;
			}
			return array;
		}

		private Tuple<int, string[]> FormatColumn(int column, int height, int upper, int lower, bool withEllipsis, string ellipsis, Func<T, string> formatValue)
		{
			string[] array = new string[height];
			int num = 0;
			for (int i = 0; i < upper; i++)
			{
				array[num++] = formatValue(At(i, column));
			}
			if (withEllipsis)
			{
				array[num++] = "";
			}
			for (int j = RowCount - lower; j < RowCount; j++)
			{
				array[num++] = formatValue(At(j, column));
			}
			int item = ((height != 0) ? array.Max((string x) => x.Length) : 0);
			if (withEllipsis)
			{
				array[upper] = ellipsis;
			}
			return new Tuple<int, string[]>(item, array);
		}

		private static string FormatStringArrayToString(string[,] array, string columnSeparator, string rowSeparator)
		{
			int length = array.GetLength(0);
			int length2 = array.GetLength(1);
			int[] array2 = new int[length2];
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length2; j++)
				{
					array2[j] = Math.Max(array2[j], array[i, j].Length);
				}
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (length > 0)
			{
				for (int k = 0; k < length; k++)
				{
					if (length2 > 0)
					{
						stringBuilder.Append(array[k, 0].PadLeft(array2[0]));
						for (int l = 1; l < length2; l++)
						{
							stringBuilder.Append(columnSeparator);
							stringBuilder.Append(array[k, l].PadLeft(array2[l]));
						}
					}
					else
					{
						stringBuilder.Append("[empty]");
					}
					stringBuilder.Append(rowSeparator);
				}
			}
			else if (length2 > 0)
			{
				for (int m = 0; m < length2; m++)
				{
					stringBuilder.Append("[empty]");
					if (m != length2 - 1)
					{
						stringBuilder.Append(columnSeparator);
					}
				}
			}
			else
			{
				stringBuilder.Append("[empty]");
			}
			return stringBuilder.ToString();
		}

		public string ToMatrixString(int upperRows, int lowerRows, int leftColumns, int rightColumns, string horizontalEllipsis, string verticalEllipsis, string diagonalEllipsis, string columnSeparator, string rowSeparator, Func<T, string> formatValue)
		{
			return FormatStringArrayToString(ToMatrixStringArray(upperRows, lowerRows, leftColumns, rightColumns, horizontalEllipsis, verticalEllipsis, diagonalEllipsis, formatValue), columnSeparator, rowSeparator);
		}

		public string ToMatrixString(int upperRows, int lowerRows, int minLeftColumns, int rightColumns, int maxWidth, string horizontalEllipsis, string verticalEllipsis, string diagonalEllipsis, string columnSeparator, string rowSeparator, Func<T, string> formatValue)
		{
			return FormatStringArrayToString(ToMatrixStringArray(upperRows, lowerRows, minLeftColumns, rightColumns, maxWidth, columnSeparator.Length, horizontalEllipsis, verticalEllipsis, diagonalEllipsis, formatValue), columnSeparator, rowSeparator);
		}

		public string ToMatrixString(int maxRows, int maxColumns, string format = null, IFormatProvider provider = null)
		{
			if (format == null)
			{
				format = "G6";
			}
			int num = ((maxRows > 4) ? 2 : 0);
			int num2 = ((maxColumns > 4) ? 2 : 0);
			return ToMatrixString(maxRows - num, num, maxColumns - num2, num2, "..", "..", "..", "  ", Environment.NewLine, (T x) => x.ToString(format, provider));
		}

		public string ToMatrixString(string format = null, IFormatProvider provider = null)
		{
			if (format == null)
			{
				format = "G6";
			}
			return ToMatrixString(8, 4, 5, 2, 76, "..", "..", "..", "  ", Environment.NewLine, (T x) => x.ToString(format, provider));
		}

		public string ToString(int maxRows, int maxColumns, string format = null, IFormatProvider formatProvider = null)
		{
			return ToTypeString() + Environment.NewLine + ToMatrixString(maxRows, maxColumns, format, formatProvider);
		}

		public sealed override string ToString()
		{
			return ToTypeString() + Environment.NewLine + ToMatrixString();
		}

		public string ToString(string format = null, IFormatProvider formatProvider = null)
		{
			return ToTypeString() + Environment.NewLine + ToMatrixString(format, formatProvider);
		}

		protected Matrix(MatrixStorage<T> storage)
		{
			Storage = storage;
			RowCount = storage.RowCount;
			ColumnCount = storage.ColumnCount;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
		public T At(int row, int column)
		{
			return Storage.At(row, column);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
		public void At(int row, int column, T value)
		{
			Storage.At(row, column, value);
		}

		public void Clear()
		{
			Storage.Clear();
		}

		public void ClearRow(int rowIndex)
		{
			if ((uint)rowIndex >= (uint)RowCount)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			Storage.ClearUnchecked(rowIndex, 1, 0, ColumnCount);
		}

		public void ClearColumn(int columnIndex)
		{
			if ((uint)columnIndex >= (uint)ColumnCount)
			{
				throw new ArgumentOutOfRangeException("columnIndex");
			}
			Storage.ClearUnchecked(0, RowCount, columnIndex, 1);
		}

		public void ClearRows(params int[] rowIndices)
		{
			Storage.ClearRows(rowIndices);
		}

		public void ClearColumns(params int[] columnIndices)
		{
			Storage.ClearColumns(columnIndices);
		}

		public void ClearSubMatrix(int rowIndex, int rowCount, int columnIndex, int columnCount)
		{
			Storage.Clear(rowIndex, rowCount, columnIndex, columnCount);
		}

		public abstract void CoerceZero(double threshold);

		public void CoerceZero(Func<T, bool> zeroPredicate)
		{
			MapInplace((T x) => (!zeroPredicate(x)) ? x : Zero);
		}

		public Matrix<T> Clone()
		{
			Matrix<T> matrix = Build.SameAs(this);
			Storage.CopyToUnchecked(matrix.Storage, ExistingData.AssumeZeros);
			return matrix;
		}

		public void CopyTo(Matrix<T> target)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			Storage.CopyTo(target.Storage);
		}

		public Vector<T> Row(int index)
		{
			if ((uint)index >= (uint)RowCount)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			Vector<T> vector = Vector<T>.Build.SameAs(this, ColumnCount);
			Storage.CopySubRowToUnchecked(vector.Storage, index, 0, 0, ColumnCount, ExistingData.AssumeZeros);
			return vector;
		}

		public void Row(int index, Vector<T> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			Storage.CopyRowTo(result.Storage, index);
		}

		public Vector<T> Row(int rowIndex, int columnIndex, int length)
		{
			Vector<T> vector = Vector<T>.Build.SameAs(this, length);
			Storage.CopySubRowTo(vector.Storage, rowIndex, columnIndex, 0, length);
			return vector;
		}

		public void Row(int rowIndex, int columnIndex, int length, Vector<T> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			Storage.CopySubRowTo(result.Storage, rowIndex, columnIndex, 0, length);
		}

		public Vector<T> Column(int index)
		{
			if ((uint)index >= (uint)ColumnCount)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			Vector<T> vector = Vector<T>.Build.SameAs(this, RowCount);
			Storage.CopySubColumnToUnchecked(vector.Storage, index, 0, 0, RowCount, ExistingData.AssumeZeros);
			return vector;
		}

		public void Column(int index, Vector<T> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			Storage.CopyColumnTo(result.Storage, index);
		}

		public Vector<T> Column(int columnIndex, int rowIndex, int length)
		{
			Vector<T> vector = Vector<T>.Build.SameAs(this, length);
			Storage.CopySubColumnTo(vector.Storage, columnIndex, rowIndex, 0, length);
			return vector;
		}

		public void Column(int columnIndex, int rowIndex, int length, Vector<T> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			Storage.CopySubColumnTo(result.Storage, columnIndex, rowIndex, 0, length);
		}

		public virtual Matrix<T> UpperTriangle()
		{
			Matrix<T> matrix = Build.SameAs(this);
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = i; j < ColumnCount; j++)
				{
					matrix.At(i, j, At(i, j));
				}
			}
			return matrix;
		}

		public virtual Matrix<T> LowerTriangle()
		{
			Matrix<T> matrix = Build.SameAs(this);
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j <= i && j < ColumnCount; j++)
				{
					matrix.At(i, j, At(i, j));
				}
			}
			return matrix;
		}

		public virtual void LowerTriangle(Matrix<T> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (result.RowCount != RowCount || result.ColumnCount != ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					result.At(i, j, (i >= j) ? At(i, j) : Zero);
				}
			}
		}

		public virtual void UpperTriangle(Matrix<T> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (result.RowCount != RowCount || result.ColumnCount != ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					result.At(i, j, (i <= j) ? At(i, j) : Zero);
				}
			}
		}

		public virtual Matrix<T> SubMatrix(int rowIndex, int rowCount, int columnIndex, int columnCount)
		{
			Matrix<T> matrix = Build.SameAs(this, rowCount, columnCount);
			Storage.CopySubMatrixTo(matrix.Storage, rowIndex, 0, rowCount, columnIndex, 0, columnCount, ExistingData.AssumeZeros);
			return matrix;
		}

		public virtual Vector<T> Diagonal()
		{
			int num = Math.Min(RowCount, ColumnCount);
			Vector<T> vector = Vector<T>.Build.SameAs(this, num);
			for (int i = 0; i < num; i++)
			{
				vector.At(i, At(i, i));
			}
			return vector;
		}

		public virtual Matrix<T> StrictlyLowerTriangle()
		{
			Matrix<T> matrix = Build.SameAs(this);
			for (int i = 0; i < RowCount; i++)
			{
				int num = Math.Min(i, ColumnCount);
				for (int j = 0; j < num; j++)
				{
					matrix.At(i, j, At(i, j));
				}
			}
			return matrix;
		}

		public virtual void StrictlyLowerTriangle(Matrix<T> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (result.RowCount != RowCount || result.ColumnCount != ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					result.At(i, j, (i > j) ? At(i, j) : Zero);
				}
			}
		}

		public virtual Matrix<T> StrictlyUpperTriangle()
		{
			Matrix<T> matrix = Build.SameAs(this);
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = i + 1; j < ColumnCount; j++)
				{
					matrix.At(i, j, At(i, j));
				}
			}
			return matrix;
		}

		public virtual void StrictlyUpperTriangle(Matrix<T> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (result.RowCount != RowCount || result.ColumnCount != ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					result.At(i, j, (i < j) ? At(i, j) : Zero);
				}
			}
		}

		public Matrix<T> InsertColumn(int columnIndex, Vector<T> column)
		{
			if (column == null)
			{
				throw new ArgumentNullException("column");
			}
			if ((uint)columnIndex > (uint)ColumnCount)
			{
				throw new ArgumentOutOfRangeException("columnIndex");
			}
			if (column.Count != RowCount)
			{
				throw new ArgumentException("Matrix row dimensions must agree.", "column");
			}
			Matrix<T> matrix = Build.SameAs(this, RowCount, ColumnCount + 1, fullyMutable: true);
			Storage.CopySubMatrixTo(matrix.Storage, 0, 0, RowCount, 0, 0, columnIndex, ExistingData.AssumeZeros);
			matrix.SetColumn(columnIndex, column);
			Storage.CopySubMatrixTo(matrix.Storage, 0, 0, RowCount, columnIndex, columnIndex + 1, ColumnCount - columnIndex, ExistingData.AssumeZeros);
			return matrix;
		}

		public Matrix<T> RemoveColumn(int columnIndex)
		{
			if ((uint)columnIndex >= (uint)ColumnCount)
			{
				throw new ArgumentOutOfRangeException("columnIndex");
			}
			Matrix<T> matrix = Build.SameAs(this, RowCount, ColumnCount - 1, fullyMutable: true);
			Storage.CopySubMatrixTo(matrix.Storage, 0, 0, RowCount, 0, 0, columnIndex, ExistingData.AssumeZeros);
			Storage.CopySubMatrixTo(matrix.Storage, 0, 0, RowCount, columnIndex + 1, columnIndex, ColumnCount - columnIndex - 1, ExistingData.AssumeZeros);
			return matrix;
		}

		public void SetColumn(int columnIndex, Vector<T> column)
		{
			if (column == null)
			{
				throw new ArgumentNullException("column");
			}
			column.Storage.CopyToColumn(Storage, columnIndex);
		}

		public void SetColumn(int columnIndex, int rowIndex, int length, Vector<T> column)
		{
			if (column == null)
			{
				throw new ArgumentNullException("column");
			}
			column.Storage.CopyToSubColumn(Storage, columnIndex, 0, rowIndex, length);
		}

		public void SetColumn(int columnIndex, T[] column)
		{
			if (column == null)
			{
				throw new ArgumentNullException("column");
			}
			new DenseVectorStorage<T>(column.Length, column).CopyToColumn(Storage, columnIndex);
		}

		public Matrix<T> InsertRow(int rowIndex, Vector<T> row)
		{
			if (row == null)
			{
				throw new ArgumentNullException("row");
			}
			if ((uint)rowIndex > (uint)RowCount)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			if (row.Count != ColumnCount)
			{
				throw new ArgumentException("Matrix row dimensions must agree.", "row");
			}
			Matrix<T> matrix = Build.SameAs(this, RowCount + 1, ColumnCount, fullyMutable: true);
			Storage.CopySubMatrixTo(matrix.Storage, 0, 0, rowIndex, 0, 0, ColumnCount, ExistingData.AssumeZeros);
			matrix.SetRow(rowIndex, row);
			Storage.CopySubMatrixTo(matrix.Storage, rowIndex, rowIndex + 1, RowCount - rowIndex, 0, 0, ColumnCount, ExistingData.AssumeZeros);
			return matrix;
		}

		public Matrix<T> RemoveRow(int rowIndex)
		{
			if ((uint)rowIndex >= (uint)RowCount)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			Matrix<T> matrix = Build.SameAs(this, RowCount - 1, ColumnCount, fullyMutable: true);
			Storage.CopySubMatrixTo(matrix.Storage, 0, 0, rowIndex, 0, 0, ColumnCount, ExistingData.AssumeZeros);
			Storage.CopySubMatrixTo(matrix.Storage, rowIndex + 1, rowIndex, RowCount - rowIndex - 1, 0, 0, ColumnCount, ExistingData.AssumeZeros);
			return matrix;
		}

		public void SetRow(int rowIndex, Vector<T> row)
		{
			if (row == null)
			{
				throw new ArgumentNullException("row");
			}
			row.Storage.CopyToRow(Storage, rowIndex);
		}

		public void SetRow(int rowIndex, int columnIndex, int length, Vector<T> row)
		{
			if (row == null)
			{
				throw new ArgumentNullException("row");
			}
			row.Storage.CopyToSubRow(Storage, rowIndex, 0, columnIndex, length);
		}

		public void SetRow(int rowIndex, T[] row)
		{
			if (row == null)
			{
				throw new ArgumentNullException("row");
			}
			new DenseVectorStorage<T>(row.Length, row).CopyToRow(Storage, rowIndex);
		}

		public void SetSubMatrix(int rowIndex, int columnIndex, Matrix<T> subMatrix)
		{
			subMatrix.Storage.CopySubMatrixTo(Storage, 0, rowIndex, subMatrix.RowCount, 0, columnIndex, subMatrix.ColumnCount);
		}

		public void SetSubMatrix(int rowIndex, int rowCount, int columnIndex, int columnCount, Matrix<T> subMatrix)
		{
			subMatrix.Storage.CopySubMatrixTo(Storage, 0, rowIndex, rowCount, 0, columnIndex, columnCount);
		}

		public void SetSubMatrix(int rowIndex, int sorceRowIndex, int rowCount, int columnIndex, int sourceColumnIndex, int columnCount, Matrix<T> subMatrix)
		{
			subMatrix.Storage.CopySubMatrixTo(Storage, sorceRowIndex, rowIndex, rowCount, sourceColumnIndex, columnIndex, columnCount);
		}

		public virtual void SetDiagonal(Vector<T> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			int num = Math.Min(RowCount, ColumnCount);
			if (source.Count != num)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "source");
			}
			for (int i = 0; i < num; i++)
			{
				At(i, i, source.At(i));
			}
		}

		public virtual void SetDiagonal(T[] source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			int num = Math.Min(RowCount, ColumnCount);
			if (source.Length != num)
			{
				throw new ArgumentException("The array arguments must have the same length.", "source");
			}
			for (int i = 0; i < num; i++)
			{
				At(i, i, source[i]);
			}
		}

		public Matrix<T> Resize(int rowCount, int columnCount)
		{
			Matrix<T> matrix = Build.SameAs(this, rowCount, columnCount, fullyMutable: true);
			Storage.CopySubMatrixTo(matrix.Storage, 0, 0, Math.Min(RowCount, rowCount), 0, 0, Math.Min(ColumnCount, columnCount), ExistingData.AssumeZeros);
			return matrix;
		}

		public Matrix<T> Transpose()
		{
			Matrix<T> matrix = Build.SameAs(this, ColumnCount, RowCount);
			Storage.TransposeToUnchecked(matrix.Storage, ExistingData.AssumeZeros);
			return matrix;
		}

		public void Transpose(Matrix<T> result)
		{
			Storage.TransposeTo(result.Storage);
		}

		public abstract Matrix<T> ConjugateTranspose();

		public abstract void ConjugateTranspose(Matrix<T> result);

		public virtual void PermuteRows(Permutation p)
		{
			if (p.Dimension != RowCount)
			{
				throw new ArgumentException("The array arguments must have the same length.", "p");
			}
			int[] array = p.ToInversions();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != i)
				{
					int row = array[i];
					for (int j = 0; j < ColumnCount; j++)
					{
						T value = At(row, j);
						At(row, j, At(i, j));
						At(i, j, value);
					}
				}
			}
		}

		public virtual void PermuteColumns(Permutation p)
		{
			if (p.Dimension != ColumnCount)
			{
				throw new ArgumentException("The array arguments must have the same length.", "p");
			}
			int[] array = p.ToInversions();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != i)
				{
					int column = array[i];
					for (int j = 0; j < RowCount; j++)
					{
						T value = At(j, column);
						At(j, column, At(j, i));
						At(j, i, value);
					}
				}
			}
		}

		public Matrix<T> Append(Matrix<T> right)
		{
			if (right == null)
			{
				throw new ArgumentNullException("right");
			}
			if (right.RowCount != RowCount)
			{
				throw new ArgumentException("Matrix row dimensions must agree.");
			}
			Matrix<T> matrix = Build.SameAs(this, right, RowCount, ColumnCount + right.ColumnCount, fullyMutable: true);
			Storage.CopySubMatrixToUnchecked(matrix.Storage, 0, 0, RowCount, 0, 0, ColumnCount, ExistingData.AssumeZeros);
			right.Storage.CopySubMatrixToUnchecked(matrix.Storage, 0, 0, right.RowCount, 0, ColumnCount, right.ColumnCount, ExistingData.AssumeZeros);
			return matrix;
		}

		public void Append(Matrix<T> right, Matrix<T> result)
		{
			if (right == null)
			{
				throw new ArgumentNullException("right");
			}
			if (right.RowCount != RowCount)
			{
				throw new ArgumentException("Matrix row dimensions must agree.");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (result.ColumnCount != ColumnCount + right.ColumnCount || result.RowCount != RowCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.");
			}
			Storage.CopySubMatrixToUnchecked(result.Storage, 0, 0, RowCount, 0, 0, ColumnCount, ExistingData.Clear);
			right.Storage.CopySubMatrixToUnchecked(result.Storage, 0, 0, right.RowCount, 0, ColumnCount, right.ColumnCount, ExistingData.Clear);
		}

		public Matrix<T> Stack(Matrix<T> lower)
		{
			if (lower == null)
			{
				throw new ArgumentNullException("lower");
			}
			if (lower.ColumnCount != ColumnCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.", "lower");
			}
			Matrix<T> matrix = Build.SameAs(this, lower, RowCount + lower.RowCount, ColumnCount, fullyMutable: true);
			Storage.CopySubMatrixToUnchecked(matrix.Storage, 0, 0, RowCount, 0, 0, ColumnCount, ExistingData.AssumeZeros);
			lower.Storage.CopySubMatrixToUnchecked(matrix.Storage, 0, RowCount, lower.RowCount, 0, 0, lower.ColumnCount, ExistingData.AssumeZeros);
			return matrix;
		}

		public void Stack(Matrix<T> lower, Matrix<T> result)
		{
			if (lower == null)
			{
				throw new ArgumentNullException("lower");
			}
			if (lower.ColumnCount != ColumnCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.", "lower");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (result.RowCount != RowCount + lower.RowCount || result.ColumnCount != ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			Storage.CopySubMatrixToUnchecked(result.Storage, 0, 0, RowCount, 0, 0, ColumnCount, ExistingData.Clear);
			lower.Storage.CopySubMatrixToUnchecked(result.Storage, 0, RowCount, lower.RowCount, 0, 0, lower.ColumnCount, ExistingData.Clear);
		}

		public Matrix<T> DiagonalStack(Matrix<T> lower)
		{
			if (lower == null)
			{
				throw new ArgumentNullException("lower");
			}
			Matrix<T> matrix = Build.SameAs(this, lower, RowCount + lower.RowCount, ColumnCount + lower.ColumnCount, RowCount != ColumnCount);
			Storage.CopySubMatrixToUnchecked(matrix.Storage, 0, 0, RowCount, 0, 0, ColumnCount, ExistingData.AssumeZeros);
			lower.Storage.CopySubMatrixToUnchecked(matrix.Storage, 0, RowCount, lower.RowCount, 0, ColumnCount, lower.ColumnCount, ExistingData.AssumeZeros);
			return matrix;
		}

		public void DiagonalStack(Matrix<T> lower, Matrix<T> result)
		{
			if (lower == null)
			{
				throw new ArgumentNullException("lower");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (result.RowCount != RowCount + lower.RowCount || result.ColumnCount != ColumnCount + lower.ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			Storage.CopySubMatrixToUnchecked(result.Storage, 0, 0, RowCount, 0, 0, ColumnCount, ExistingData.Clear);
			lower.Storage.CopySubMatrixToUnchecked(result.Storage, 0, RowCount, lower.RowCount, 0, ColumnCount, lower.ColumnCount, ExistingData.Clear);
		}

		public virtual bool IsSymmetric()
		{
			if (RowCount != ColumnCount)
			{
				return false;
			}
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = i + 1; j < ColumnCount; j++)
				{
					if (!At(i, j).Equals(At(j, i)))
					{
						return false;
					}
				}
			}
			return true;
		}

		public abstract bool IsHermitian();

		public T[,] ToArray()
		{
			return Storage.ToArray();
		}

		public T[] ToColumnMajorArray()
		{
			return Storage.ToColumnMajorArray();
		}

		public T[] ToRowMajorArray()
		{
			return Storage.ToRowMajorArray();
		}

		public T[][] ToRowArrays()
		{
			return Storage.ToRowArrays();
		}

		public T[][] ToColumnArrays()
		{
			return Storage.ToColumnArrays();
		}

		public T[,] AsArray()
		{
			return Storage.AsArray();
		}

		public T[] AsColumnMajorArray()
		{
			return Storage.AsColumnMajorArray();
		}

		public T[] AsRowMajorArray()
		{
			return Storage.AsRowMajorArray();
		}

		public T[][] AsRowArrays()
		{
			return Storage.AsRowArrays();
		}

		public T[][] AsColumnArrays()
		{
			return Storage.AsColumnArrays();
		}

		public IEnumerable<T> Enumerate()
		{
			return Storage.Enumerate();
		}

		public IEnumerable<T> Enumerate(Zeros zeros)
		{
			if (zeros == Zeros.AllowSkip)
			{
				return Storage.EnumerateNonZero();
			}
			return Storage.Enumerate();
		}

		public IEnumerable<(int, int, T)> EnumerateIndexed()
		{
			return Storage.EnumerateIndexed();
		}

		public IEnumerable<(int, int, T)> EnumerateIndexed(Zeros zeros)
		{
			if (zeros == Zeros.AllowSkip)
			{
				return Storage.EnumerateNonZeroIndexed();
			}
			return Storage.EnumerateIndexed();
		}

		public IEnumerable<Vector<T>> EnumerateColumns()
		{
			for (int i = 0; i < ColumnCount; i++)
			{
				yield return Column(i);
			}
		}

		public IEnumerable<Vector<T>> EnumerateColumns(int index, int length)
		{
			int maxIndex = Math.Min(index + length, ColumnCount);
			for (int i = Math.Max(index, 0); i < maxIndex; i++)
			{
				yield return Column(i);
			}
		}

		public IEnumerable<(int, Vector<T>)> EnumerateColumnsIndexed()
		{
			for (int i = 0; i < ColumnCount; i++)
			{
				yield return (i, Column(i));
			}
		}

		public IEnumerable<(int, Vector<T>)> EnumerateColumnsIndexed(int index, int length)
		{
			int maxIndex = Math.Min(index + length, ColumnCount);
			for (int i = Math.Max(index, 0); i < maxIndex; i++)
			{
				yield return (i, Column(i));
			}
		}

		public IEnumerable<Vector<T>> EnumerateRows()
		{
			for (int i = 0; i < RowCount; i++)
			{
				yield return Row(i);
			}
		}

		public IEnumerable<Vector<T>> EnumerateRows(int index, int length)
		{
			int maxIndex = Math.Min(index + length, RowCount);
			for (int i = Math.Max(index, 0); i < maxIndex; i++)
			{
				yield return Row(i);
			}
		}

		public IEnumerable<(int, Vector<T>)> EnumerateRowsIndexed()
		{
			for (int i = 0; i < RowCount; i++)
			{
				yield return (i, Row(i));
			}
		}

		public IEnumerable<(int, Vector<T>)> EnumerateRowsIndexed(int index, int length)
		{
			int maxIndex = Math.Min(index + length, RowCount);
			for (int i = Math.Max(index, 0); i < maxIndex; i++)
			{
				yield return (i, Row(i));
			}
		}

		public void MapInplace(Func<T, T> f, Zeros zeros = Zeros.AllowSkip)
		{
			Storage.MapInplace(f, zeros);
		}

		public void MapIndexedInplace(Func<int, int, T, T> f, Zeros zeros = Zeros.AllowSkip)
		{
			Storage.MapIndexedInplace(f, zeros);
		}

		public void Map(Func<T, T> f, Matrix<T> result, Zeros zeros = Zeros.AllowSkip)
		{
			if (this == result)
			{
				Storage.MapInplace(f, zeros);
			}
			else
			{
				Storage.MapTo(result.Storage, f, zeros, (zeros == Zeros.Include) ? ExistingData.AssumeZeros : ExistingData.Clear);
			}
		}

		public void MapIndexed(Func<int, int, T, T> f, Matrix<T> result, Zeros zeros = Zeros.AllowSkip)
		{
			if (this == result)
			{
				Storage.MapIndexedInplace(f, zeros);
			}
			else
			{
				Storage.MapIndexedTo(result.Storage, f, zeros, (zeros == Zeros.Include) ? ExistingData.AssumeZeros : ExistingData.Clear);
			}
		}

		public void MapConvert<TU>(Func<T, TU> f, Matrix<TU> result, Zeros zeros = Zeros.AllowSkip) where TU : struct, IEquatable<TU>, IFormattable
		{
			Storage.MapTo(result.Storage, f, zeros, (zeros == Zeros.Include) ? ExistingData.AssumeZeros : ExistingData.Clear);
		}

		public void MapIndexedConvert<TU>(Func<int, int, T, TU> f, Matrix<TU> result, Zeros zeros = Zeros.AllowSkip) where TU : struct, IEquatable<TU>, IFormattable
		{
			Storage.MapIndexedTo(result.Storage, f, zeros, (zeros == Zeros.Include) ? ExistingData.AssumeZeros : ExistingData.Clear);
		}

		public Matrix<TU> Map<TU>(Func<T, TU> f, Zeros zeros = Zeros.AllowSkip) where TU : struct, IEquatable<TU>, IFormattable
		{
			Matrix<TU> matrix = Matrix<TU>.Build.SameAs(this, RowCount, ColumnCount, zeros == Zeros.Include);
			Storage.MapToUnchecked(matrix.Storage, f, zeros, ExistingData.AssumeZeros);
			return matrix;
		}

		public Matrix<TU> MapIndexed<TU>(Func<int, int, T, TU> f, Zeros zeros = Zeros.AllowSkip) where TU : struct, IEquatable<TU>, IFormattable
		{
			Matrix<TU> matrix = Matrix<TU>.Build.SameAs(this, RowCount, ColumnCount, zeros == Zeros.Include);
			Storage.MapIndexedToUnchecked(matrix.Storage, f, zeros, ExistingData.AssumeZeros);
			return matrix;
		}

		public TU[] FoldByRow<TU>(Func<TU, T, TU> f, TU state, Zeros zeros = Zeros.AllowSkip)
		{
			TU[] result = new TU[RowCount];
			if (!EqualityComparer<TU>.Default.Equals(state, default(TU)))
			{
				CommonParallel.For(0, result.Length, 4096, delegate(int a, int b)
				{
					for (int i = a; i < b; i++)
					{
						result[i] = state;
					}
				});
			}
			Storage.FoldByRowUnchecked(result, f, (TU x, int _) => x, result, zeros);
			return result;
		}

		public TU[] FoldByColumn<TU>(Func<TU, T, TU> f, TU state, Zeros zeros = Zeros.AllowSkip)
		{
			TU[] result = new TU[ColumnCount];
			if (!EqualityComparer<TU>.Default.Equals(state, default(TU)))
			{
				CommonParallel.For(0, result.Length, 4096, delegate(int a, int b)
				{
					for (int i = a; i < b; i++)
					{
						result[i] = state;
					}
				});
			}
			Storage.FoldByColumnUnchecked(result, f, (TU x, int _) => x, result, zeros);
			return result;
		}

		public Vector<TU> FoldRows<TU>(Func<Vector<TU>, Vector<T>, Vector<TU>> f, Vector<TU> state) where TU : struct, IEquatable<TU>, IFormattable
		{
			foreach (Vector<T> item in EnumerateRows())
			{
				state = f(state, item);
			}
			return state;
		}

		public Vector<TU> FoldColumns<TU>(Func<Vector<TU>, Vector<T>, Vector<TU>> f, Vector<TU> state) where TU : struct, IEquatable<TU>, IFormattable
		{
			foreach (Vector<T> item in EnumerateColumns())
			{
				state = f(state, item);
			}
			return state;
		}

		public Vector<T> ReduceRows(Func<Vector<T>, Vector<T>, Vector<T>> f)
		{
			return EnumerateRows().Aggregate(f);
		}

		public Vector<T> ReduceColumns(Func<Vector<T>, Vector<T>, Vector<T>> f)
		{
			return EnumerateColumns().Aggregate(f);
		}

		public void Map2(Func<T, T, T> f, Matrix<T> other, Matrix<T> result, Zeros zeros = Zeros.AllowSkip)
		{
			Storage.Map2To(result.Storage, other.Storage, f, zeros, ExistingData.Clear);
		}

		public Matrix<T> Map2(Func<T, T, T> f, Matrix<T> other, Zeros zeros = Zeros.AllowSkip)
		{
			Matrix<T> matrix = Build.SameAs(this);
			Storage.Map2To(matrix.Storage, other.Storage, f, zeros, ExistingData.AssumeZeros);
			return matrix;
		}

		public TState Fold2<TOther, TState>(Func<TState, T, TOther, TState> f, TState state, Matrix<TOther> other, Zeros zeros = Zeros.AllowSkip) where TOther : struct, IEquatable<TOther>, IFormattable
		{
			return Storage.Fold2(other.Storage, f, state, zeros);
		}

		public Tuple<int, int, T> Find(Func<T, bool> predicate, Zeros zeros = Zeros.AllowSkip)
		{
			return Storage.Find(predicate, zeros);
		}

		public Tuple<int, int, T, TOther> Find2<TOther>(Func<T, TOther, bool> predicate, Matrix<TOther> other, Zeros zeros = Zeros.AllowSkip) where TOther : struct, IEquatable<TOther>, IFormattable
		{
			return Storage.Find2(other.Storage, predicate, zeros);
		}

		public bool Exists(Func<T, bool> predicate, Zeros zeros = Zeros.AllowSkip)
		{
			return Storage.Find(predicate, zeros) != null;
		}

		public bool Exists2<TOther>(Func<T, TOther, bool> predicate, Matrix<TOther> other, Zeros zeros = Zeros.AllowSkip) where TOther : struct, IEquatable<TOther>, IFormattable
		{
			return Storage.Find2(other.Storage, predicate, zeros) != null;
		}

		public bool ForAll(Func<T, bool> predicate, Zeros zeros = Zeros.AllowSkip)
		{
			return Storage.Find((T x) => !predicate(x), zeros) == null;
		}

		public bool ForAll2<TOther>(Func<T, TOther, bool> predicate, Matrix<TOther> other, Zeros zeros = Zeros.AllowSkip) where TOther : struct, IEquatable<TOther>, IFormattable
		{
			return Storage.Find2(other.Storage, (T x, TOther y) => !predicate(x, y), zeros) == null;
		}

		public static Matrix<T> operator +(Matrix<T> rightSide)
		{
			return rightSide.Clone();
		}

		public static Matrix<T> operator -(Matrix<T> rightSide)
		{
			return rightSide.Negate();
		}

		public static Matrix<T> operator +(Matrix<T> leftSide, Matrix<T> rightSide)
		{
			return leftSide.Add(rightSide);
		}

		public static Matrix<T> operator +(Matrix<T> leftSide, T rightSide)
		{
			return leftSide.Add(rightSide);
		}

		public static Matrix<T> operator +(T leftSide, Matrix<T> rightSide)
		{
			return rightSide.Add(leftSide);
		}

		public static Matrix<T> operator -(Matrix<T> leftSide, Matrix<T> rightSide)
		{
			return leftSide.Subtract(rightSide);
		}

		public static Matrix<T> operator -(Matrix<T> leftSide, T rightSide)
		{
			return leftSide.Subtract(rightSide);
		}

		public static Matrix<T> operator -(T leftSide, Matrix<T> rightSide)
		{
			return rightSide.SubtractFrom(leftSide);
		}

		public static Matrix<T> operator *(Matrix<T> leftSide, T rightSide)
		{
			return leftSide.Multiply(rightSide);
		}

		public static Matrix<T> operator *(T leftSide, Matrix<T> rightSide)
		{
			return rightSide.Multiply(leftSide);
		}

		public static Matrix<T> operator *(Matrix<T> leftSide, Matrix<T> rightSide)
		{
			return leftSide.Multiply(rightSide);
		}

		public static Vector<T> operator *(Matrix<T> leftSide, Vector<T> rightSide)
		{
			return leftSide.Multiply(rightSide);
		}

		public static Vector<T> operator *(Vector<T> leftSide, Matrix<T> rightSide)
		{
			return rightSide.LeftMultiply(leftSide);
		}

		public static Matrix<T> operator /(T dividend, Matrix<T> divisor)
		{
			return divisor.DivideByThis(dividend);
		}

		public static Matrix<T> operator /(Matrix<T> dividend, T divisor)
		{
			return dividend.Divide(divisor);
		}

		public static Matrix<T> operator %(Matrix<T> dividend, T divisor)
		{
			return dividend.Remainder(divisor);
		}

		public static Matrix<T> operator %(T dividend, Matrix<T> divisor)
		{
			return divisor.RemainderByThis(dividend);
		}

		public static Matrix<T> operator %(Matrix<T> dividend, Matrix<T> divisor)
		{
			return dividend.PointwiseRemainder(divisor);
		}

		[SpecialName]
		public static Matrix<T> op_DotMultiply(Matrix<T> x, Matrix<T> y)
		{
			return x.PointwiseMultiply(y);
		}

		[SpecialName]
		public static Matrix<T> op_DotDivide(Matrix<T> dividend, Matrix<T> divisor)
		{
			return dividend.PointwiseDivide(divisor);
		}

		[SpecialName]
		public static Matrix<T> op_DotPercent(Matrix<T> dividend, Matrix<T> divisor)
		{
			return dividend.PointwiseRemainder(divisor);
		}

		[SpecialName]
		public static Matrix<T> op_DotHat(Matrix<T> matrix, Matrix<T> exponent)
		{
			return matrix.PointwisePower(exponent);
		}

		[SpecialName]
		public static Matrix<T> op_DotHat(Matrix<T> matrix, T exponent)
		{
			return matrix.PointwisePower(exponent);
		}

		public static Matrix<T> Sqrt(Matrix<T> x)
		{
			return x.PointwiseSqrt();
		}

		public static Matrix<T> Exp(Matrix<T> x)
		{
			return x.PointwiseExp();
		}

		public static Matrix<T> Log(Matrix<T> x)
		{
			return x.PointwiseLog();
		}

		public static Matrix<T> Log10(Matrix<T> x)
		{
			return x.PointwiseLog10();
		}

		public static Matrix<T> Sin(Matrix<T> x)
		{
			return x.PointwiseSin();
		}

		public static Matrix<T> Cos(Matrix<T> x)
		{
			return x.PointwiseCos();
		}

		public static Matrix<T> Tan(Matrix<T> x)
		{
			return x.PointwiseTan();
		}

		public static Matrix<T> Asin(Matrix<T> x)
		{
			return x.PointwiseAsin();
		}

		public static Matrix<T> Acos(Matrix<T> x)
		{
			return x.PointwiseAcos();
		}

		public static Matrix<T> Atan(Matrix<T> x)
		{
			return x.PointwiseAtan();
		}

		public static Matrix<T> Sinh(Matrix<T> x)
		{
			return x.PointwiseSinh();
		}

		public static Matrix<T> Cosh(Matrix<T> x)
		{
			return x.PointwiseCosh();
		}

		public static Matrix<T> Tanh(Matrix<T> x)
		{
			return x.PointwiseTanh();
		}

		public static Matrix<T> Abs(Matrix<T> x)
		{
			return x.PointwiseAbs();
		}

		public static Matrix<T> Floor(Matrix<T> x)
		{
			return x.PointwiseFloor();
		}

		public static Matrix<T> Ceiling(Matrix<T> x)
		{
			return x.PointwiseCeiling();
		}

		public static Matrix<T> Round(Matrix<T> x)
		{
			return x.PointwiseRound();
		}

		public abstract Cholesky<T> Cholesky();

		public abstract LU<T> LU();

		public abstract QR<T> QR(QRMethod method = QRMethod.Thin);

		public abstract GramSchmidt<T> GramSchmidt();

		public abstract Svd<T> Svd(bool computeVectors = true);

		public abstract Evd<T> Evd(Symmetricity symmetricity = Symmetricity.Unknown);

		public void Solve(Vector<T> input, Vector<T> result)
		{
			if (ColumnCount == RowCount)
			{
				LU().Solve(input, result);
			}
			else
			{
				QR().Solve(input, result);
			}
		}

		public void Solve(Matrix<T> input, Matrix<T> result)
		{
			if (ColumnCount == RowCount)
			{
				LU().Solve(input, result);
			}
			else
			{
				QR().Solve(input, result);
			}
		}

		public Matrix<T> Solve(Matrix<T> input)
		{
			Matrix<T> result = Build.SameAs(this, ColumnCount, input.ColumnCount, fullyMutable: true);
			Solve(input, result);
			return result;
		}

		public Vector<T> Solve(Vector<T> input)
		{
			Vector<T> result = Vector<T>.Build.SameAs(this, ColumnCount);
			Solve(input, result);
			return result;
		}

		public IterationStatus TrySolveIterative(Vector<T> input, Vector<T> result, IIterativeSolver<T> solver, Iterator<T> iterator = null, IPreconditioner<T> preconditioner = null)
		{
			if (iterator == null)
			{
				iterator = new Iterator<T>(Build.IterativeSolverStopCriteria());
			}
			if (preconditioner == null)
			{
				preconditioner = new UnitPreconditioner<T>();
			}
			solver.Solve(this, input, result, iterator, preconditioner);
			return iterator.Status;
		}

		public IterationStatus TrySolveIterative(Matrix<T> input, Matrix<T> result, IIterativeSolver<T> solver, Iterator<T> iterator = null, IPreconditioner<T> preconditioner = null)
		{
			if (RowCount != input.RowCount || input.RowCount != result.RowCount || input.ColumnCount != result.ColumnCount)
			{
				throw DimensionsDontMatch<ArgumentException>(this, input, result);
			}
			if (iterator == null)
			{
				iterator = new Iterator<T>(Build.IterativeSolverStopCriteria());
			}
			if (preconditioner == null)
			{
				preconditioner = new UnitPreconditioner<T>();
			}
			for (int i = 0; i < input.ColumnCount; i++)
			{
				Vector<T> vector = Vector<T>.Build.Dense(RowCount);
				solver.Solve(this, input.Column(i), vector, iterator, preconditioner);
				foreach (var item in vector.EnumerateIndexed(Zeros.AllowSkip))
				{
					result.At(item.Item1, i, item.Item2);
				}
			}
			return iterator.Status;
		}

		public IterationStatus TrySolveIterative(Vector<T> input, Vector<T> result, IIterativeSolver<T> solver, IPreconditioner<T> preconditioner, params IIterationStopCriterion<T>[] stopCriteria)
		{
			Iterator<T> iterator = new Iterator<T>((stopCriteria.Length == 0) ? Build.IterativeSolverStopCriteria() : stopCriteria);
			return TrySolveIterative(input, result, solver, iterator, preconditioner);
		}

		public IterationStatus TrySolveIterative(Matrix<T> input, Matrix<T> result, IIterativeSolver<T> solver, IPreconditioner<T> preconditioner, params IIterationStopCriterion<T>[] stopCriteria)
		{
			Iterator<T> iterator = new Iterator<T>((stopCriteria.Length == 0) ? Build.IterativeSolverStopCriteria() : stopCriteria);
			return TrySolveIterative(input, result, solver, iterator, preconditioner);
		}

		public IterationStatus TrySolveIterative(Vector<T> input, Vector<T> result, IIterativeSolver<T> solver, params IIterationStopCriterion<T>[] stopCriteria)
		{
			Iterator<T> iterator = new Iterator<T>((stopCriteria.Length == 0) ? Build.IterativeSolverStopCriteria() : stopCriteria);
			return TrySolveIterative(input, result, solver, iterator);
		}

		public IterationStatus TrySolveIterative(Matrix<T> input, Matrix<T> result, IIterativeSolver<T> solver, params IIterationStopCriterion<T>[] stopCriteria)
		{
			Iterator<T> iterator = new Iterator<T>((stopCriteria.Length == 0) ? Build.IterativeSolverStopCriteria() : stopCriteria);
			return TrySolveIterative(input, result, solver, iterator);
		}

		public Vector<T> SolveIterative(Vector<T> input, IIterativeSolver<T> solver, Iterator<T> iterator = null, IPreconditioner<T> preconditioner = null)
		{
			Vector<T> result = Vector<T>.Build.Dense(RowCount);
			TrySolveIterative(input, result, solver, iterator, preconditioner);
			return result;
		}

		public Matrix<T> SolveIterative(Matrix<T> input, IIterativeSolver<T> solver, Iterator<T> iterator = null, IPreconditioner<T> preconditioner = null)
		{
			Matrix<T> result = Build.Dense(input.RowCount, input.ColumnCount);
			TrySolveIterative(input, result, solver, iterator, preconditioner);
			return result;
		}

		public Vector<T> SolveIterative(Vector<T> input, IIterativeSolver<T> solver, IPreconditioner<T> preconditioner, params IIterationStopCriterion<T>[] stopCriteria)
		{
			Vector<T> result = Vector<T>.Build.Dense(RowCount);
			TrySolveIterative(input, result, solver, preconditioner, stopCriteria);
			return result;
		}

		public Matrix<T> SolveIterative(Matrix<T> input, IIterativeSolver<T> solver, IPreconditioner<T> preconditioner, params IIterationStopCriterion<T>[] stopCriteria)
		{
			Matrix<T> result = Build.Dense(input.RowCount, input.ColumnCount);
			TrySolveIterative(input, result, solver, preconditioner, stopCriteria);
			return result;
		}

		public Vector<T> SolveIterative(Vector<T> input, IIterativeSolver<T> solver, params IIterationStopCriterion<T>[] stopCriteria)
		{
			Vector<T> result = Vector<T>.Build.Dense(RowCount);
			TrySolveIterative(input, result, solver, stopCriteria);
			return result;
		}

		public Matrix<T> SolveIterative(Matrix<T> input, IIterativeSolver<T> solver, params IIterationStopCriterion<T>[] stopCriteria)
		{
			Matrix<T> result = Build.Dense(input.RowCount, input.ColumnCount);
			TrySolveIterative(input, result, solver, stopCriteria);
			return result;
		}
	}
}
