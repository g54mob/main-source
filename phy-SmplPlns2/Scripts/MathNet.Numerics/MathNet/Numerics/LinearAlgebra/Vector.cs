using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Text;
using MathNet.Numerics.LinearAlgebra.Storage;

namespace MathNet.Numerics.LinearAlgebra
{
	[Serializable]
	[DebuggerDisplay("Vector {Count}")]
	[DebuggerTypeProxy(typeof(VectorDebuggingView<>))]
	public abstract class Vector<T> : IFormattable, IEquatable<Vector<T>>, IList, ICollection, IEnumerable, IList<T>, ICollection<T>, IEnumerable<T>, ICloneable where T : struct, IEquatable<T>, IFormattable
	{
		public static readonly T Zero = BuilderInstance<T>.Vector.Zero;

		public static readonly T One = BuilderInstance<T>.Vector.One;

		public static readonly VectorBuilder<T> Build = BuilderInstance<T>.Vector;

		bool ICollection<T>.IsReadOnly => false;

		bool IList.IsReadOnly => false;

		bool IList.IsFixedSize => true;

		object IList.this[int index]
		{
			get
			{
				return Storage[index];
			}
			set
			{
				Storage[index] = (T)value;
			}
		}

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => Storage;

		public VectorStorage<T> Storage { get; private set; }

		public int Count { get; private set; }

		public T this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
			get
			{
				return Storage[index];
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
			set
			{
				Storage[index] = value;
			}
		}

		protected abstract void DoNegate(Vector<T> result);

		protected abstract void DoConjugate(Vector<T> result);

		protected abstract void DoAdd(T scalar, Vector<T> result);

		protected abstract void DoAdd(Vector<T> other, Vector<T> result);

		protected abstract void DoSubtract(T scalar, Vector<T> result);

		protected void DoSubtractFrom(T scalar, Vector<T> result)
		{
			DoNegate(result);
			result.DoAdd(scalar, result);
		}

		protected abstract void DoSubtract(Vector<T> other, Vector<T> result);

		protected abstract void DoMultiply(T scalar, Vector<T> result);

		protected abstract T DoDotProduct(Vector<T> other);

		protected abstract T DoConjugateDotProduct(Vector<T> other);

		protected void DoOuterProduct(Vector<T> other, Matrix<T> result)
		{
			Vector<T> vector = Build.Dense(Count);
			for (int i = 0; i < other.Count; i++)
			{
				DoMultiply(other.At(i), vector);
				result.SetColumn(i, vector);
			}
		}

		protected abstract void DoDivide(T divisor, Vector<T> result);

		protected abstract void DoDivideByThis(T dividend, Vector<T> result);

		protected abstract void DoModulus(T divisor, Vector<T> result);

		protected abstract void DoModulusByThis(T dividend, Vector<T> result);

		protected abstract void DoRemainder(T divisor, Vector<T> result);

		protected abstract void DoRemainderByThis(T dividend, Vector<T> result);

		protected abstract void DoPointwiseMultiply(Vector<T> other, Vector<T> result);

		protected abstract void DoPointwiseDivide(Vector<T> divisor, Vector<T> result);

		protected abstract void DoPointwisePower(T exponent, Vector<T> result);

		protected abstract void DoPointwisePower(Vector<T> exponent, Vector<T> result);

		protected abstract void DoPointwiseModulus(Vector<T> divisor, Vector<T> result);

		protected abstract void DoPointwiseRemainder(Vector<T> divisor, Vector<T> result);

		protected abstract void DoPointwiseExp(Vector<T> result);

		protected abstract void DoPointwiseLog(Vector<T> result);

		protected abstract void DoPointwiseAbs(Vector<T> result);

		protected abstract void DoPointwiseAcos(Vector<T> result);

		protected abstract void DoPointwiseAsin(Vector<T> result);

		protected abstract void DoPointwiseAtan(Vector<T> result);

		protected abstract void DoPointwiseCeiling(Vector<T> result);

		protected abstract void DoPointwiseCos(Vector<T> result);

		protected abstract void DoPointwiseCosh(Vector<T> result);

		protected abstract void DoPointwiseFloor(Vector<T> result);

		protected abstract void DoPointwiseLog10(Vector<T> result);

		protected abstract void DoPointwiseRound(Vector<T> result);

		protected abstract void DoPointwiseSign(Vector<T> result);

		protected abstract void DoPointwiseSin(Vector<T> result);

		protected abstract void DoPointwiseSinh(Vector<T> result);

		protected abstract void DoPointwiseSqrt(Vector<T> result);

		protected abstract void DoPointwiseTan(Vector<T> result);

		protected abstract void DoPointwiseTanh(Vector<T> result);

		protected abstract void DoPointwiseAtan2(Vector<T> other, Vector<T> result);

		protected abstract void DoPointwiseAtan2(T scalar, Vector<T> result);

		protected abstract void DoPointwiseMinimum(T scalar, Vector<T> result);

		protected abstract void DoPointwiseMinimum(Vector<T> other, Vector<T> result);

		protected abstract void DoPointwiseMaximum(T scalar, Vector<T> result);

		protected abstract void DoPointwiseMaximum(Vector<T> other, Vector<T> result);

		protected abstract void DoPointwiseAbsoluteMinimum(T scalar, Vector<T> result);

		protected abstract void DoPointwiseAbsoluteMinimum(Vector<T> other, Vector<T> result);

		protected abstract void DoPointwiseAbsoluteMaximum(T scalar, Vector<T> result);

		protected abstract void DoPointwiseAbsoluteMaximum(Vector<T> other, Vector<T> result);

		public Vector<T> Add(T scalar)
		{
			if (scalar.Equals(Zero))
			{
				return Clone();
			}
			Vector<T> result = Build.SameAs(this);
			DoAdd(scalar, result);
			return result;
		}

		public void Add(T scalar, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
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

		public Vector<T> Add(Vector<T> other)
		{
			if (Count != other.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "other");
			}
			Vector<T> result = Build.SameAs(this, other);
			DoAdd(other, result);
			return result;
		}

		public void Add(Vector<T> other, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoAdd(other, result);
		}

		public Vector<T> Subtract(T scalar)
		{
			if (scalar.Equals(Zero))
			{
				return Clone();
			}
			Vector<T> result = Build.SameAs(this);
			DoSubtract(scalar, result);
			return result;
		}

		public void Subtract(T scalar, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
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

		public Vector<T> SubtractFrom(T scalar)
		{
			Vector<T> result = Build.SameAs(this);
			DoSubtractFrom(scalar, result);
			return result;
		}

		public void SubtractFrom(T scalar, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoSubtractFrom(scalar, result);
		}

		public Vector<T> Negate()
		{
			Vector<T> result = Build.SameAs(this);
			DoNegate(result);
			return result;
		}

		public void Negate(Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoNegate(result);
		}

		public Vector<T> Subtract(Vector<T> other)
		{
			if (Count != other.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "other");
			}
			Vector<T> result = Build.SameAs(this, other);
			DoSubtract(other, result);
			return result;
		}

		public void Subtract(Vector<T> other, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoSubtract(other, result);
		}

		public Vector<T> Conjugate()
		{
			Vector<T> result = Build.SameAs(this);
			DoConjugate(result);
			return result;
		}

		public void Conjugate(Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoConjugate(result);
		}

		public Vector<T> Multiply(T scalar)
		{
			if (scalar.Equals(One))
			{
				return Clone();
			}
			if (scalar.Equals(Zero))
			{
				return Build.SameAs(this);
			}
			Vector<T> result = Build.SameAs(this);
			DoMultiply(scalar, result);
			return result;
		}

		public void Multiply(T scalar, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
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

		public T DotProduct(Vector<T> other)
		{
			if (Count != other.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "other");
			}
			return DoDotProduct(other);
		}

		public T ConjugateDotProduct(Vector<T> other)
		{
			if (Count != other.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "other");
			}
			return DoConjugateDotProduct(other);
		}

		public Vector<T> Divide(T scalar)
		{
			if (scalar.Equals(One))
			{
				return Clone();
			}
			Vector<T> result = Build.SameAs(this);
			DoDivide(scalar, result);
			return result;
		}

		public void Divide(T scalar, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			if (scalar.Equals(One))
			{
				CopyTo(result);
			}
			else
			{
				DoDivide(scalar, result);
			}
		}

		public Vector<T> DivideByThis(T scalar)
		{
			Vector<T> result = Build.SameAs(this);
			DoDivideByThis(scalar, result);
			return result;
		}

		public void DivideByThis(T scalar, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoDivideByThis(scalar, result);
		}

		public Vector<T> Modulus(T divisor)
		{
			Vector<T> result = Build.SameAs(this);
			DoModulus(divisor, result);
			return result;
		}

		public void Modulus(T divisor, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoModulus(divisor, result);
		}

		public Vector<T> ModulusByThis(T dividend)
		{
			Vector<T> result = Build.SameAs(this);
			DoModulusByThis(dividend, result);
			return result;
		}

		public void ModulusByThis(T dividend, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoModulusByThis(dividend, result);
		}

		public Vector<T> Remainder(T divisor)
		{
			Vector<T> result = Build.SameAs(this);
			DoRemainder(divisor, result);
			return result;
		}

		public void Remainder(T divisor, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoRemainder(divisor, result);
		}

		public Vector<T> RemainderByThis(T dividend)
		{
			Vector<T> result = Build.SameAs(this);
			DoRemainderByThis(dividend, result);
			return result;
		}

		public void RemainderByThis(T dividend, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoRemainderByThis(dividend, result);
		}

		public Vector<T> PointwiseMultiply(Vector<T> other)
		{
			if (Count != other.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "other");
			}
			Vector<T> result = Build.SameAs(this, other);
			DoPointwiseMultiply(other, result);
			return result;
		}

		public void PointwiseMultiply(Vector<T> other, Vector<T> result)
		{
			if (Count != other.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "other");
			}
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoPointwiseMultiply(other, result);
		}

		public Vector<T> PointwiseDivide(Vector<T> divisor)
		{
			if (Count != divisor.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "divisor");
			}
			Vector<T> result = Build.SameAs(this, divisor);
			DoPointwiseDivide(divisor, result);
			return result;
		}

		public void PointwiseDivide(Vector<T> divisor, Vector<T> result)
		{
			if (Count != divisor.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "divisor");
			}
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoPointwiseDivide(divisor, result);
		}

		public Vector<T> PointwisePower(T exponent)
		{
			Vector<T> result = Build.SameAs(this);
			DoPointwisePower(exponent, result);
			return result;
		}

		public void PointwisePower(T exponent, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoPointwisePower(exponent, result);
		}

		public Vector<T> PointwisePower(Vector<T> exponent)
		{
			if (Count != exponent.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "exponent");
			}
			Vector<T> result = Build.SameAs(this);
			DoPointwisePower(exponent, result);
			return result;
		}

		public void PointwisePower(Vector<T> exponent, Vector<T> result)
		{
			if (Count != exponent.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "exponent");
			}
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoPointwisePower(exponent, result);
		}

		public Vector<T> PointwiseModulus(Vector<T> divisor)
		{
			if (Count != divisor.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "divisor");
			}
			Vector<T> result = Build.SameAs(this, divisor);
			DoPointwiseModulus(divisor, result);
			return result;
		}

		public void PointwiseModulus(Vector<T> divisor, Vector<T> result)
		{
			if (Count != divisor.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "divisor");
			}
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoPointwiseModulus(divisor, result);
		}

		public Vector<T> PointwiseRemainder(Vector<T> divisor)
		{
			if (Count != divisor.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "divisor");
			}
			Vector<T> result = Build.SameAs(this, divisor);
			DoPointwiseRemainder(divisor, result);
			return result;
		}

		public void PointwiseRemainder(Vector<T> divisor, Vector<T> result)
		{
			if (Count != divisor.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "divisor");
			}
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoPointwiseRemainder(divisor, result);
		}

		protected Vector<T> PointwiseUnary(Action<Vector<T>> f)
		{
			Vector<T> vector = Build.SameAs(this);
			f(vector);
			return vector;
		}

		protected void PointwiseUnary(Action<Vector<T>> f, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			f(result);
		}

		protected Vector<T> PointwiseBinary(Action<T, Vector<T>> f, T other)
		{
			Vector<T> vector = Build.SameAs(this);
			f(other, vector);
			return vector;
		}

		protected void PointwiseBinary(Action<T, Vector<T>> f, T x, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			f(x, result);
		}

		protected Vector<T> PointwiseBinary(Action<Vector<T>, Vector<T>> f, Vector<T> other)
		{
			if (Count != other.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "other");
			}
			Vector<T> vector = Build.SameAs(this, other);
			f(other, vector);
			return vector;
		}

		protected void PointwiseBinary(Action<Vector<T>, Vector<T>> f, Vector<T> other, Vector<T> result)
		{
			if (Count != other.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "other");
			}
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			f(other, result);
		}

		public Vector<T> PointwiseExp()
		{
			return PointwiseUnary(DoPointwiseExp);
		}

		public void PointwiseExp(Vector<T> result)
		{
			PointwiseUnary(DoPointwiseExp, result);
		}

		public Vector<T> PointwiseLog()
		{
			return PointwiseUnary(DoPointwiseLog);
		}

		public void PointwiseLog(Vector<T> result)
		{
			PointwiseUnary(DoPointwiseLog, result);
		}

		public Vector<T> PointwiseAbs()
		{
			return PointwiseUnary(DoPointwiseAbs);
		}

		public void PointwiseAbs(Vector<T> result)
		{
			PointwiseUnary(DoPointwiseAbs, result);
		}

		public Vector<T> PointwiseAcos()
		{
			return PointwiseUnary(DoPointwiseAcos);
		}

		public void PointwiseAcos(Vector<T> result)
		{
			PointwiseUnary(DoPointwiseAcos, result);
		}

		public Vector<T> PointwiseAsin()
		{
			return PointwiseUnary(DoPointwiseAsin);
		}

		public void PointwiseAsin(Vector<T> result)
		{
			PointwiseUnary(DoPointwiseAsin, result);
		}

		public Vector<T> PointwiseAtan()
		{
			return PointwiseUnary(DoPointwiseAtan);
		}

		public void PointwiseAtan(Vector<T> result)
		{
			PointwiseUnary(DoPointwiseAtan, result);
		}

		public Vector<T> PointwiseAtan2(Vector<T> other)
		{
			return PointwiseBinary(DoPointwiseAtan2, other);
		}

		public void PointwiseAtan2(Vector<T> other, Vector<T> result)
		{
			PointwiseBinary(DoPointwiseAtan2, other, result);
		}

		public Vector<T> PointwiseCeiling()
		{
			return PointwiseUnary(DoPointwiseCeiling);
		}

		public void PointwiseCeiling(Vector<T> result)
		{
			PointwiseUnary(DoPointwiseCeiling, result);
		}

		public Vector<T> PointwiseCos()
		{
			return PointwiseUnary(DoPointwiseCos);
		}

		public void PointwiseCos(Vector<T> result)
		{
			PointwiseUnary(DoPointwiseCos, result);
		}

		public Vector<T> PointwiseCosh()
		{
			return PointwiseUnary(DoPointwiseCosh);
		}

		public void PointwiseCosh(Vector<T> result)
		{
			PointwiseUnary(DoPointwiseCosh, result);
		}

		public Vector<T> PointwiseFloor()
		{
			return PointwiseUnary(DoPointwiseFloor);
		}

		public void PointwiseFloor(Vector<T> result)
		{
			PointwiseUnary(DoPointwiseFloor, result);
		}

		public Vector<T> PointwiseLog10()
		{
			return PointwiseUnary(DoPointwiseLog10);
		}

		public void PointwiseLog10(Vector<T> result)
		{
			PointwiseUnary(DoPointwiseLog10, result);
		}

		public Vector<T> PointwiseRound()
		{
			return PointwiseUnary(DoPointwiseRound);
		}

		public void PointwiseRound(Vector<T> result)
		{
			PointwiseUnary(DoPointwiseRound, result);
		}

		public Vector<T> PointwiseSign()
		{
			return PointwiseUnary(DoPointwiseSign);
		}

		public void PointwiseSign(Vector<T> result)
		{
			PointwiseUnary(DoPointwiseSign, result);
		}

		public Vector<T> PointwiseSin()
		{
			return PointwiseUnary(DoPointwiseSin);
		}

		public void PointwiseSin(Vector<T> result)
		{
			PointwiseUnary(DoPointwiseSin, result);
		}

		public Vector<T> PointwiseSinh()
		{
			return PointwiseUnary(DoPointwiseSinh);
		}

		public void PointwiseSinh(Vector<T> result)
		{
			PointwiseUnary(DoPointwiseSinh, result);
		}

		public Vector<T> PointwiseSqrt()
		{
			return PointwiseUnary(DoPointwiseSqrt);
		}

		public void PointwiseSqrt(Vector<T> result)
		{
			PointwiseUnary(DoPointwiseSqrt, result);
		}

		public Vector<T> PointwiseTan()
		{
			return PointwiseUnary(DoPointwiseTan);
		}

		public void PointwiseTan(Vector<T> result)
		{
			PointwiseUnary(DoPointwiseTan, result);
		}

		public Vector<T> PointwiseTanh()
		{
			return PointwiseUnary(DoPointwiseTanh);
		}

		public void PointwiseTanh(Vector<T> result)
		{
			PointwiseUnary(DoPointwiseTanh, result);
		}

		public Matrix<T> OuterProduct(Vector<T> other)
		{
			Matrix<T> result = Matrix<T>.Build.SameAs(this, Count, other.Count);
			DoOuterProduct(other, result);
			return result;
		}

		public void OuterProduct(Vector<T> other, Matrix<T> result)
		{
			if (Count != result.RowCount || other.Count != result.ColumnCount)
			{
				throw new ArgumentException("Matrix dimensions must agree.", "result");
			}
			DoOuterProduct(other, result);
		}

		public static Matrix<T> OuterProduct(Vector<T> u, Vector<T> v)
		{
			return u.OuterProduct(v);
		}

		public Vector<T> PointwiseMinimum(T scalar)
		{
			Vector<T> result = Build.SameAs(this);
			DoPointwiseMinimum(scalar, result);
			return result;
		}

		public void PointwiseMinimum(T scalar, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoPointwiseMinimum(scalar, result);
		}

		public Vector<T> PointwiseMaximum(T scalar)
		{
			Vector<T> result = Build.SameAs(this);
			DoPointwiseMaximum(scalar, result);
			return result;
		}

		public void PointwiseMaximum(T scalar, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoPointwiseMaximum(scalar, result);
		}

		public Vector<T> PointwiseAbsoluteMinimum(T scalar)
		{
			Vector<T> result = Build.SameAs(this);
			DoPointwiseAbsoluteMinimum(scalar, result);
			return result;
		}

		public void PointwiseAbsoluteMinimum(T scalar, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoPointwiseAbsoluteMinimum(scalar, result);
		}

		public Vector<T> PointwiseAbsoluteMaximum(T scalar)
		{
			Vector<T> result = Build.SameAs(this);
			DoPointwiseAbsoluteMaximum(scalar, result);
			return result;
		}

		public void PointwiseAbsoluteMaximum(T scalar, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoPointwiseAbsoluteMaximum(scalar, result);
		}

		public Vector<T> PointwiseMinimum(Vector<T> other)
		{
			Vector<T> result = Build.SameAs(this);
			DoPointwiseMinimum(other, result);
			return result;
		}

		public void PointwiseMinimum(Vector<T> other, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoPointwiseMinimum(other, result);
		}

		public Vector<T> PointwiseMaximum(Vector<T> other)
		{
			Vector<T> result = Build.SameAs(this);
			DoPointwiseMaximum(other, result);
			return result;
		}

		public void PointwiseMaximum(Vector<T> other, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoPointwiseMaximum(other, result);
		}

		public Vector<T> PointwiseAbsoluteMinimum(Vector<T> other)
		{
			Vector<T> result = Build.SameAs(this);
			DoPointwiseAbsoluteMinimum(other, result);
			return result;
		}

		public void PointwiseAbsoluteMinimum(Vector<T> other, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoPointwiseAbsoluteMinimum(other, result);
		}

		public Vector<T> PointwiseAbsoluteMaximum(Vector<T> other)
		{
			Vector<T> result = Build.SameAs(this);
			DoPointwiseAbsoluteMaximum(other, result);
			return result;
		}

		public void PointwiseAbsoluteMaximum(Vector<T> other, Vector<T> result)
		{
			if (Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "result");
			}
			DoPointwiseAbsoluteMaximum(other, result);
		}

		public abstract double L1Norm();

		public abstract double L2Norm();

		public abstract double InfinityNorm();

		public abstract double Norm(double p);

		public abstract Vector<T> Normalize(double p);

		public abstract T AbsoluteMinimum();

		public abstract int AbsoluteMinimumIndex();

		public abstract T AbsoluteMaximum();

		public abstract int AbsoluteMaximumIndex();

		public T Maximum()
		{
			return At(MaximumIndex());
		}

		public abstract int MaximumIndex();

		public T Minimum()
		{
			return At(MinimumIndex());
		}

		public abstract int MinimumIndex();

		public abstract T Sum();

		public double SumMagnitudes()
		{
			return L1Norm();
		}

		public bool Equals(Vector<T> other)
		{
			if (other != null)
			{
				return Storage.Equals(other.Storage);
			}
			return false;
		}

		public sealed override bool Equals(object obj)
		{
			if (obj is Vector<T> vector)
			{
				return Storage.Equals(vector.Storage);
			}
			return false;
		}

		public sealed override int GetHashCode()
		{
			return Storage.GetHashCode();
		}

		object ICloneable.Clone()
		{
			return Clone();
		}

		int IList<T>.IndexOf(T item)
		{
			for (int i = 0; i < Count; i++)
			{
				if (At(i).Equals(item))
				{
					return i;
				}
			}
			return -1;
		}

		void IList<T>.Insert(int index, T item)
		{
			throw new NotSupportedException();
		}

		void IList<T>.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		void ICollection<T>.Add(T item)
		{
			throw new NotSupportedException();
		}

		bool ICollection<T>.Remove(T item)
		{
			throw new NotSupportedException();
		}

		bool ICollection<T>.Contains(T item)
		{
			foreach (T item2 in (IEnumerable<T>)this)
			{
				if (item2.Equals(item))
				{
					return true;
				}
			}
			return false;
		}

		void ICollection<T>.CopyTo(T[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			Storage.CopySubVectorTo(new DenseVectorStorage<T>(array.Length, array), 0, arrayIndex, Count);
		}

		int IList.IndexOf(object value)
		{
			if (!(value is T))
			{
				return -1;
			}
			return ((IList<T>)this).IndexOf((T)value);
		}

		bool IList.Contains(object value)
		{
			if (!(value is T))
			{
				return false;
			}
			return ((ICollection<T>)this).Contains((T)value);
		}

		void IList.Insert(int index, object value)
		{
			throw new NotSupportedException();
		}

		int IList.Add(object value)
		{
			throw new NotSupportedException();
		}

		void IList.Remove(object value)
		{
			throw new NotSupportedException();
		}

		void IList.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (array.Rank != 1)
			{
				throw new ArgumentException("Array must have exactly one dimension (and not be null).", "array");
			}
			Storage.CopySubVectorTo(new DenseVectorStorage<T>(array.Length, (T[])array), 0, index, Count);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return Enumerate().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return Enumerate().GetEnumerator();
		}

		public virtual string ToTypeString()
		{
			return FormattableString.Invariant($"{GetType().Name} {Count}-{typeof(T).Name}");
		}

		public string[,] ToVectorStringArray(int maxPerColumn, int maxCharactersWidth, int padding, string ellipsis, Func<T, string> formatValue)
		{
			maxPerColumn = Math.Max(maxPerColumn, 3);
			maxCharactersWidth = Math.Max(maxCharactersWidth, 16);
			List<Tuple<int, string[]>> list = new List<Tuple<int, string[]>>();
			int num = 0;
			int i;
			int num2;
			for (i = 0; i < Count; i += num2)
			{
				num2 = Math.Min(maxPerColumn, Count - i);
				Tuple<int, string[]> tuple = FormatCompleteColumn(i, num2, formatValue);
				num += tuple.Item1 + padding;
				if (num > maxCharactersWidth && i > 0)
				{
					break;
				}
				list.Add(tuple);
			}
			if (i < Count)
			{
				string[] item = list[list.Count - 1].Item2;
				item[^2] = ellipsis;
				item[^1] = formatValue(At(Count - 1));
			}
			int num3 = list[0].Item2.Length;
			int count = list.Count;
			string[,] array = new string[num3, count];
			int num4 = 0;
			foreach (Tuple<int, string[]> item3 in list)
			{
				string[] item2 = item3.Item2;
				for (int j = 0; j < item3.Item2.Length; j++)
				{
					array[j, num4] = item2[j];
				}
				for (int k = item3.Item2.Length; k < num3; k++)
				{
					array[k, num4] = "";
				}
				num4++;
			}
			return array;
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
			for (int k = 0; k < length; k++)
			{
				stringBuilder.Append(array[k, 0].PadLeft(array2[0]));
				for (int l = 1; l < length2; l++)
				{
					stringBuilder.Append(columnSeparator);
					stringBuilder.Append(array[k, l].PadLeft(array2[l]));
				}
				stringBuilder.Append(rowSeparator);
			}
			return stringBuilder.ToString();
		}

		private Tuple<int, string[]> FormatCompleteColumn(int offset, int height, Func<T, string> formatValue)
		{
			string[] array = new string[height];
			int num = 0;
			for (int i = 0; i < height; i++)
			{
				array[num++] = formatValue(At(offset + i));
			}
			return new Tuple<int, string[]>(array.Max((string x) => x.Length), array);
		}

		public string ToVectorString(int maxPerColumn, int maxCharactersWidth, string ellipsis, string columnSeparator, string rowSeparator, Func<T, string> formatValue)
		{
			return FormatStringArrayToString(ToVectorStringArray(maxPerColumn, maxCharactersWidth, columnSeparator.Length, ellipsis, formatValue), columnSeparator, rowSeparator);
		}

		public string ToVectorString(int maxPerColumn, int maxCharactersWidth, string format = null, IFormatProvider provider = null)
		{
			if (format == null)
			{
				format = "G6";
			}
			return ToVectorString(maxPerColumn, maxCharactersWidth, "..", "  ", Environment.NewLine, (T x) => x.ToString(format, provider));
		}

		public string ToVectorString(string format = null, IFormatProvider provider = null)
		{
			if (format == null)
			{
				format = "G6";
			}
			return ToVectorString(12, 80, "..", "  ", Environment.NewLine, (T x) => x.ToString(format, provider));
		}

		public string ToString(int maxPerColumn, int maxCharactersWidth, string format = null, IFormatProvider provider = null)
		{
			return ToTypeString() + Environment.NewLine + ToVectorString(maxPerColumn, maxCharactersWidth, format, provider);
		}

		public sealed override string ToString()
		{
			return ToTypeString() + Environment.NewLine + ToVectorString();
		}

		public string ToString(string format = null, IFormatProvider formatProvider = null)
		{
			return ToTypeString() + Environment.NewLine + ToVectorString(format, formatProvider);
		}

		protected Vector(VectorStorage<T> storage)
		{
			Storage = storage;
			Count = storage.Length;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
		public T At(int index)
		{
			return Storage.At(index);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
		public void At(int index, T value)
		{
			Storage.At(index, value);
		}

		public void Clear()
		{
			Storage.Clear();
		}

		public void ClearSubVector(int index, int count)
		{
			if (count < 1)
			{
				throw new ArgumentOutOfRangeException("count", "Value must be positive.");
			}
			if (index + count > Count || index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			Storage.Clear(index, count);
		}

		public abstract void CoerceZero(double threshold);

		public void CoerceZero(Func<T, bool> zeroPredicate)
		{
			MapInplace((T x) => (!zeroPredicate(x)) ? x : Zero);
		}

		public Vector<T> Clone()
		{
			Vector<T> vector = Build.SameAs(this);
			Storage.CopyToUnchecked(vector.Storage, ExistingData.AssumeZeros);
			return vector;
		}

		public void SetValues(T[] values)
		{
			new DenseVectorStorage<T>(Count, values).CopyTo(Storage);
		}

		public void CopyTo(Vector<T> target)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			Storage.CopyTo(target.Storage);
		}

		public Vector<T> SubVector(int index, int count)
		{
			Vector<T> vector = Build.SameAs(this, count);
			Storage.CopySubVectorTo(vector.Storage, index, 0, count, ExistingData.AssumeZeros);
			return vector;
		}

		public void SetSubVector(int index, int count, Vector<T> subVector)
		{
			if (subVector == null)
			{
				throw new ArgumentNullException("subVector");
			}
			subVector.Storage.CopySubVectorTo(Storage, 0, index, count);
		}

		public void CopySubVectorTo(Vector<T> destination, int sourceIndex, int targetIndex, int count)
		{
			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}
			Storage.CopySubVectorTo(destination.Storage, sourceIndex, targetIndex, count);
		}

		public T[] ToArray()
		{
			return Storage.ToArray();
		}

		public T[] AsArray()
		{
			return Storage.AsArray();
		}

		public Matrix<T> ToColumnMatrix()
		{
			Matrix<T> matrix = Matrix<T>.Build.SameAs(this, Count, 1);
			Storage.CopyToColumnUnchecked(matrix.Storage, 0, ExistingData.AssumeZeros);
			return matrix;
		}

		public Matrix<T> ToRowMatrix()
		{
			Matrix<T> matrix = Matrix<T>.Build.SameAs(this, 1, Count);
			Storage.CopyToRowUnchecked(matrix.Storage, 0, ExistingData.AssumeZeros);
			return matrix;
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

		public IEnumerable<(int, T)> EnumerateIndexed()
		{
			return Storage.EnumerateIndexed();
		}

		public IEnumerable<(int, T)> EnumerateIndexed(Zeros zeros)
		{
			if (zeros == Zeros.AllowSkip)
			{
				return Storage.EnumerateNonZeroIndexed();
			}
			return Storage.EnumerateIndexed();
		}

		public void MapInplace(Func<T, T> f, Zeros zeros = Zeros.AllowSkip)
		{
			Storage.MapInplace(f, zeros);
		}

		public void MapIndexedInplace(Func<int, T, T> f, Zeros zeros = Zeros.AllowSkip)
		{
			Storage.MapIndexedInplace(f, zeros);
		}

		public void Map(Func<T, T> f, Vector<T> result, Zeros zeros = Zeros.AllowSkip)
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

		public void MapIndexed(Func<int, T, T> f, Vector<T> result, Zeros zeros = Zeros.AllowSkip)
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

		public void MapConvert<TU>(Func<T, TU> f, Vector<TU> result, Zeros zeros = Zeros.AllowSkip) where TU : struct, IEquatable<TU>, IFormattable
		{
			Storage.MapTo(result.Storage, f, zeros, (zeros == Zeros.Include) ? ExistingData.AssumeZeros : ExistingData.Clear);
		}

		public void MapIndexedConvert<TU>(Func<int, T, TU> f, Vector<TU> result, Zeros zeros = Zeros.AllowSkip) where TU : struct, IEquatable<TU>, IFormattable
		{
			Storage.MapIndexedTo(result.Storage, f, zeros, (zeros == Zeros.Include) ? ExistingData.AssumeZeros : ExistingData.Clear);
		}

		public Vector<TU> Map<TU>(Func<T, TU> f, Zeros zeros = Zeros.AllowSkip) where TU : struct, IEquatable<TU>, IFormattable
		{
			Vector<TU> vector = Vector<TU>.Build.SameAs(this);
			Storage.MapToUnchecked(vector.Storage, f, zeros, ExistingData.AssumeZeros);
			return vector;
		}

		public Vector<TU> MapIndexed<TU>(Func<int, T, TU> f, Zeros zeros = Zeros.AllowSkip) where TU : struct, IEquatable<TU>, IFormattable
		{
			Vector<TU> vector = Vector<TU>.Build.SameAs(this);
			Storage.MapIndexedToUnchecked(vector.Storage, f, zeros, ExistingData.AssumeZeros);
			return vector;
		}

		public void Map2(Func<T, T, T> f, Vector<T> other, Vector<T> result, Zeros zeros = Zeros.AllowSkip)
		{
			Storage.Map2To(result.Storage, other.Storage, f, zeros, ExistingData.Clear);
		}

		public Vector<T> Map2(Func<T, T, T> f, Vector<T> other, Zeros zeros = Zeros.AllowSkip)
		{
			Vector<T> vector = Build.SameAs(this);
			Storage.Map2To(vector.Storage, other.Storage, f, zeros, ExistingData.AssumeZeros);
			return vector;
		}

		public TState Fold2<TOther, TState>(Func<TState, T, TOther, TState> f, TState state, Vector<TOther> other, Zeros zeros = Zeros.AllowSkip) where TOther : struct, IEquatable<TOther>, IFormattable
		{
			return Storage.Fold2(other.Storage, f, state, zeros);
		}

		public Tuple<int, T> Find(Func<T, bool> predicate, Zeros zeros = Zeros.AllowSkip)
		{
			return Storage.Find(predicate, zeros);
		}

		public Tuple<int, T, TOther> Find2<TOther>(Func<T, TOther, bool> predicate, Vector<TOther> other, Zeros zeros = Zeros.AllowSkip) where TOther : struct, IEquatable<TOther>, IFormattable
		{
			return Storage.Find2(other.Storage, predicate, zeros);
		}

		public bool Exists(Func<T, bool> predicate, Zeros zeros = Zeros.AllowSkip)
		{
			return Storage.Find(predicate, zeros) != null;
		}

		public bool Exists2<TOther>(Func<T, TOther, bool> predicate, Vector<TOther> other, Zeros zeros = Zeros.AllowSkip) where TOther : struct, IEquatable<TOther>, IFormattable
		{
			return Storage.Find2(other.Storage, predicate, zeros) != null;
		}

		public bool ForAll(Func<T, bool> predicate, Zeros zeros = Zeros.AllowSkip)
		{
			return Storage.Find((T x) => !predicate(x), zeros) == null;
		}

		public bool ForAll2<TOther>(Func<T, TOther, bool> predicate, Vector<TOther> other, Zeros zeros = Zeros.AllowSkip) where TOther : struct, IEquatable<TOther>, IFormattable
		{
			return Storage.Find2(other.Storage, (T x, TOther y) => !predicate(x, y), zeros) == null;
		}

		public static Vector<T> operator +(Vector<T> rightSide)
		{
			return rightSide.Clone();
		}

		public static Vector<T> operator -(Vector<T> rightSide)
		{
			return rightSide.Negate();
		}

		public static Vector<T> operator +(Vector<T> leftSide, Vector<T> rightSide)
		{
			return leftSide.Add(rightSide);
		}

		public static Vector<T> operator +(Vector<T> leftSide, T rightSide)
		{
			return leftSide.Add(rightSide);
		}

		public static Vector<T> operator +(T leftSide, Vector<T> rightSide)
		{
			return rightSide.Add(leftSide);
		}

		public static Vector<T> operator -(Vector<T> leftSide, Vector<T> rightSide)
		{
			return leftSide.Subtract(rightSide);
		}

		public static Vector<T> operator -(Vector<T> leftSide, T rightSide)
		{
			return leftSide.Subtract(rightSide);
		}

		public static Vector<T> operator -(T leftSide, Vector<T> rightSide)
		{
			return rightSide.SubtractFrom(leftSide);
		}

		public static Vector<T> operator *(Vector<T> leftSide, T rightSide)
		{
			return leftSide.Multiply(rightSide);
		}

		public static Vector<T> operator *(T leftSide, Vector<T> rightSide)
		{
			return rightSide.Multiply(leftSide);
		}

		public static T operator *(Vector<T> leftSide, Vector<T> rightSide)
		{
			return leftSide.DotProduct(rightSide);
		}

		public static Vector<T> operator /(T dividend, Vector<T> divisor)
		{
			return divisor.DivideByThis(dividend);
		}

		public static Vector<T> operator /(Vector<T> dividend, T divisor)
		{
			return dividend.Divide(divisor);
		}

		public static Vector<T> operator /(Vector<T> dividend, Vector<T> divisor)
		{
			return dividend.PointwiseDivide(divisor);
		}

		public static Vector<T> operator %(Vector<T> dividend, T divisor)
		{
			return dividend.Remainder(divisor);
		}

		public static Vector<T> operator %(T dividend, Vector<T> divisor)
		{
			return divisor.RemainderByThis(dividend);
		}

		public static Vector<T> operator %(Vector<T> dividend, Vector<T> divisor)
		{
			return dividend.PointwiseRemainder(divisor);
		}

		[SpecialName]
		public static Vector<T> op_DotMultiply(Vector<T> x, Vector<T> y)
		{
			return x.PointwiseMultiply(y);
		}

		[SpecialName]
		public static Vector<T> op_DotDivide(Vector<T> dividend, Vector<T> divisor)
		{
			return dividend.PointwiseDivide(divisor);
		}

		[SpecialName]
		public static Vector<T> op_DotPercent(Vector<T> dividend, Vector<T> divisor)
		{
			return dividend.PointwiseRemainder(divisor);
		}

		[SpecialName]
		public static Vector<T> op_DotHat(Vector<T> vector, Vector<T> exponent)
		{
			return vector.PointwisePower(exponent);
		}

		[SpecialName]
		public static Vector<T> op_DotHat(Vector<T> vector, T exponent)
		{
			return vector.PointwisePower(exponent);
		}

		public static Vector<T> Sqrt(Vector<T> x)
		{
			return x.PointwiseSqrt();
		}

		public static Vector<T> Exp(Vector<T> x)
		{
			return x.PointwiseUnary(x.DoPointwiseExp);
		}

		public static Vector<T> Log(Vector<T> x)
		{
			return x.PointwiseUnary(x.PointwiseLog);
		}

		public static Vector<T> Log10(Vector<T> x)
		{
			return x.PointwiseLog10();
		}

		public static Vector<T> Sin(Vector<T> x)
		{
			return x.PointwiseSin();
		}

		public static Vector<T> Cos(Vector<T> x)
		{
			return x.PointwiseCos();
		}

		public static Vector<T> Tan(Vector<T> x)
		{
			return x.PointwiseTan();
		}

		public static Vector<T> Asin(Vector<T> x)
		{
			return x.PointwiseAsin();
		}

		public static Vector<T> Acos(Vector<T> x)
		{
			return x.PointwiseAcos();
		}

		public static Vector<T> Atan(Vector<T> x)
		{
			return x.PointwiseAtan();
		}

		public static Vector<T> Sinh(Vector<T> x)
		{
			return x.PointwiseSinh();
		}

		public static Vector<T> Cosh(Vector<T> x)
		{
			return x.PointwiseCosh();
		}

		public static Vector<T> Tanh(Vector<T> x)
		{
			return x.PointwiseTanh();
		}

		public static Vector<T> Abs(Vector<T> x)
		{
			return x.PointwiseAbs();
		}

		public static Vector<T> Floor(Vector<T> x)
		{
			return x.PointwiseFloor();
		}

		public static Vector<T> Ceiling(Vector<T> x)
		{
			return x.PointwiseCeiling();
		}

		public static Vector<T> Round(Vector<T> x)
		{
			return x.PointwiseRound();
		}
	}
}
