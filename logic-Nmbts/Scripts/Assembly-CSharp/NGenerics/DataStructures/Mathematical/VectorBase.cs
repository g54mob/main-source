using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NGenerics.DataStructures.General;
using NGenerics.Util;

namespace NGenerics.DataStructures.Mathematical
{
	public abstract class VectorBase<T> : IVector<T>, IEnumerable<T>, IEnumerable, IEquatable<IVector<T>>, ICloneable
	{
		private readonly int dimensionCount;

		public int DimensionCount
		{
			get
			{
				return dimensionCount;
			}
		}

		public abstract T this[int index] { get; set; }

		protected VectorBase(int dimensionCount)
		{
			this.dimensionCount = dimensionCount;
		}

		public void Add(IVector<T> vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			CheckDimensionsEqual(this, vector);
			AddSafe(vector);
		}

		protected abstract void AddSafe(IVector<T> vector);

		public abstract void Add(T number);

		protected static void CheckDimensionsEqual(IVector<T> left, IVector<T> right)
		{
			if (left.DimensionCount != right.DimensionCount)
			{
				throw new ArgumentException("Vectors must have the same DimensionCount to perform this operation", "right");
			}
		}

		public virtual void Clear()
		{
			for (int i = 0; i < dimensionCount; i++)
			{
				this[i] = default(T);
			}
		}

		protected abstract IVector<T> DeepClone();

		public object Clone()
		{
			return DeepClone();
		}

		public IVector<T> CrossProduct(IVector<T> vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			if (vector.DimensionCount != 2 && vector.DimensionCount != 3)
			{
				throw new ArgumentException("DimensionCount must be 2 or 3 to calculate the cross product.", "vector");
			}
			if (DimensionCount != 2 && DimensionCount != 3)
			{
				throw new InvalidOperationException("DimensionCount must be 2 or 3 to calculate the cross product.");
			}
			return CrossProductSafe(vector);
		}

		protected abstract IVector<T> CrossProductSafe(IVector<T> vector);

		public abstract void Increment();

		public abstract T Magnitude();

		public abstract T Product();

		public abstract T Sum();

		public abstract void Decrement();

		public void Divide(IVector<T> vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			CheckDimensionsEqual(this, vector);
			DivideSafe(vector);
		}

		protected abstract void DivideSafe(IVector<T> vector);

		public abstract void Divide(T number);

		public T DotProduct(IVector<T> vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			CheckDimensionsEqual(this, vector);
			return DotProductSafe(vector);
		}

		protected abstract T DotProductSafe(IVector<T> vector);

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			IVector<T> other = obj as IVector<T>;
			return EqualsInternal(other);
		}

		public bool Equals(IVector<T> other)
		{
			if (other != null)
			{
				return EqualsInternal(other);
			}
			return false;
		}

		private bool EqualsInternal(IVector<T> other)
		{
			if (dimensionCount != other.DimensionCount)
			{
				return false;
			}
			for (int i = 0; i < dimensionCount; i++)
			{
				if (!object.Equals(this[i], other[i]))
				{
					return false;
				}
			}
			return true;
		}

		public override int GetHashCode()
		{
			int num = 0;
			for (int i = 0; i < dimensionCount; i++)
			{
				num ^= this[i].GetHashCode();
			}
			return num;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public abstract T AbsoluteMaximum();

		public abstract int AbsoluteMaximumIndex();

		public abstract T AbsoluteMinimum();

		public abstract int AbsoluteMinimumIndex();

		public virtual T Maximum()
		{
			int index = MaximumIndex();
			return this[index];
		}

		public abstract int MaximumIndex();

		public virtual T Minimum()
		{
			return this[MinimumIndex()];
		}

		public abstract int MinimumIndex();

		public IMatrix<T> Multiply(IVector<T> vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			CheckDimensionsEqual(this, vector);
			return MultiplySafe(vector);
		}

		protected abstract IMatrix<T> MultiplySafe(IVector<T> vector);

		public abstract void Multiply(T number);

		public abstract void Negate();

		public abstract void Normalize();

		public void SetValues(params T[] values)
		{
			Guard.ArgumentNotNull(values, "values");
			if (values.Length != dimensionCount)
			{
				throw new ArgumentOutOfRangeException("values", "length of array must equal dimension count");
			}
			SetValuesSafe(values);
		}

		protected virtual void SetValuesSafe(T[] values)
		{
			for (int i = 0; i < values.Length; i++)
			{
				this[i] = values[i];
			}
		}

		public void Subtract(IVector<T> vector)
		{
			Guard.ArgumentNotNull(vector, "vector");
			CheckDimensionsEqual(this, vector);
			SubtractSafe(vector);
		}

		protected abstract void SubtractSafe(IVector<T> vector);

		public abstract void Subtract(T number);

		public void Swap(IVector<T> other)
		{
			Guard.ArgumentNotNull(other, "other");
			CheckDimensionsEqual(this, other);
			SwapSafe(other);
		}

		protected virtual void SwapSafe(IVector<T> other)
		{
			for (int i = 0; i < dimensionCount; i++)
			{
				T value = this[i];
				this[i] = other[i];
				other[i] = value;
			}
		}

		public abstract T[] ToArray();

		public virtual IEnumerator<T> GetEnumerator()
		{
			for (int index = 0; index < dimensionCount; index++)
			{
				yield return this[index];
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append('{');
			for (int i = 0; i < dimensionCount; i++)
			{
				stringBuilder.Append(this[i]);
				stringBuilder.Append(",");
			}
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			stringBuilder.Append('}');
			return stringBuilder.ToString();
		}

		public abstract IMatrix<T> ToMatrix();

		public static bool operator ==(VectorBase<T> left, IVector<T> right)
		{
			if ((object)left == right)
			{
				return true;
			}
			if ((object)left == null || right == null)
			{
				return false;
			}
			return left.EqualsInternal(right);
		}

		public static bool operator !=(VectorBase<T> left, IVector<T> right)
		{
			return !(left == right);
		}

		public static VectorBase<T> operator /(VectorBase<T> left, IVector<T> right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			CheckDimensionsEqual(left, right);
			VectorBase<T> obj = (VectorBase<T>)left.DeepClone();
			obj.Divide(right);
			return obj;
		}

		public static VectorBase<T> operator /(VectorBase<T> left, T right)
		{
			Guard.ArgumentNotNull(left, "left");
			VectorBase<T> obj = (VectorBase<T>)left.DeepClone();
			obj.Divide(right);
			return obj;
		}

		public static IMatrix<T> operator *(VectorBase<T> left, IVector<T> right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			CheckDimensionsEqual(left, right);
			return left.Multiply(right);
		}

		public static VectorBase<T> operator *(VectorBase<T> left, T right)
		{
			Guard.ArgumentNotNull(left, "left");
			VectorBase<T> obj = (VectorBase<T>)left.DeepClone();
			obj.Multiply(right);
			return obj;
		}

		public static VectorBase<T> operator +(VectorBase<T> left, IVector<T> right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			CheckDimensionsEqual(left, right);
			VectorBase<T> obj = (VectorBase<T>)left.DeepClone();
			obj.Add(right);
			return obj;
		}

		public static VectorBase<T> operator ++(VectorBase<T> right)
		{
			Guard.ArgumentNotNull(right, "right");
			VectorBase<T> obj = (VectorBase<T>)right.DeepClone();
			obj.Increment();
			return obj;
		}

		public static VectorBase<T> operator +(VectorBase<T> left, T right)
		{
			Guard.ArgumentNotNull(left, "left");
			VectorBase<T> obj = (VectorBase<T>)left.DeepClone();
			obj.Add(right);
			return obj;
		}

		public static VectorBase<T> operator -(VectorBase<T> left, IVector<T> right)
		{
			Guard.ArgumentNotNull(left, "left");
			Guard.ArgumentNotNull(right, "right");
			CheckDimensionsEqual(left, right);
			VectorBase<T> obj = (VectorBase<T>)left.DeepClone();
			obj.Subtract(right);
			return obj;
		}

		public static VectorBase<T> operator -(VectorBase<T> left, T right)
		{
			Guard.ArgumentNotNull(left, "left");
			VectorBase<T> obj = (VectorBase<T>)left.DeepClone();
			obj.Subtract(right);
			return obj;
		}

		public static VectorBase<T> operator -(VectorBase<T> right)
		{
			Guard.ArgumentNotNull(right, "right");
			VectorBase<T> obj = (VectorBase<T>)right.DeepClone();
			obj.Negate();
			return obj;
		}

		public static VectorBase<T> operator --(VectorBase<T> right)
		{
			Guard.ArgumentNotNull(right, "right");
			VectorBase<T> obj = (VectorBase<T>)right.DeepClone();
			obj.Decrement();
			return obj;
		}
	}
}
