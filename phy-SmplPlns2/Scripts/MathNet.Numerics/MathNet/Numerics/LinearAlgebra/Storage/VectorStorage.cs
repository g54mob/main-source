using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MathNet.Numerics.LinearAlgebra.Storage
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics/LinearAlgebra")]
	public abstract class VectorStorage<T> : IEquatable<VectorStorage<T>> where T : struct, IEquatable<T>, IFormattable
	{
		protected static readonly T Zero = BuilderInstance<T>.Vector.Zero;

		[DataMember(Order = 1)]
		public readonly int Length;

		public abstract bool IsDense { get; }

		public T this[int index]
		{
			get
			{
				ValidateRange(index);
				return At(index);
			}
			set
			{
				ValidateRange(index);
				At(index, value);
			}
		}

		protected VectorStorage(int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length", "Value must not be negative (zero is ok).");
			}
			Length = length;
		}

		public abstract T At(int index);

		public abstract void At(int index, T value);

		public virtual bool Equals(VectorStorage<T> other)
		{
			if (other == null)
			{
				return false;
			}
			if (Length != other.Length)
			{
				return false;
			}
			if (this == other)
			{
				return true;
			}
			for (int i = 0; i < Length; i++)
			{
				if (!At(i).Equals(other.At(i)))
				{
					return false;
				}
			}
			return true;
		}

		public sealed override bool Equals(object obj)
		{
			return Equals(obj as VectorStorage<T>);
		}

		public override int GetHashCode()
		{
			int num = Math.Min(Length, 25);
			int num2 = 17;
			for (int i = 0; i < num; i++)
			{
				num2 = num2 * 31 + At(i).GetHashCode();
			}
			return num2;
		}

		public virtual void Clear()
		{
			for (int i = 0; i < Length; i++)
			{
				At(i, Zero);
			}
		}

		public virtual void Clear(int index, int count)
		{
			for (int i = index; i < index + count; i++)
			{
				At(i, Zero);
			}
		}

		public void CopyTo(VectorStorage<T> target, ExistingData existingData = ExistingData.Clear)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (this != target)
			{
				if (Length != target.Length)
				{
					throw new ArgumentException("All vectors must have the same dimensionality.", "target");
				}
				CopyToUnchecked(target, existingData);
			}
		}

		internal virtual void CopyToUnchecked(VectorStorage<T> target, ExistingData existingData)
		{
			for (int i = 0; i < Length; i++)
			{
				target.At(i, At(i));
			}
		}

		public void CopyToRow(MatrixStorage<T> target, int rowIndex, ExistingData existingData = ExistingData.Clear)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (Length != target.ColumnCount)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "target");
			}
			ValidateRowRange(target, rowIndex);
			CopyToRowUnchecked(target, rowIndex, existingData);
		}

		internal virtual void CopyToRowUnchecked(MatrixStorage<T> target, int rowIndex, ExistingData existingData)
		{
			for (int i = 0; i < Length; i++)
			{
				target.At(rowIndex, i, At(i));
			}
		}

		public void CopyToColumn(MatrixStorage<T> target, int columnIndex, ExistingData existingData = ExistingData.Clear)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (Length != target.RowCount)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "target");
			}
			ValidateColumnRange(target, columnIndex);
			CopyToColumnUnchecked(target, columnIndex, existingData);
		}

		internal virtual void CopyToColumnUnchecked(MatrixStorage<T> target, int columnIndex, ExistingData existingData)
		{
			for (int i = 0; i < Length; i++)
			{
				target.At(i, columnIndex, At(i));
			}
		}

		public void CopySubVectorTo(VectorStorage<T> target, int sourceIndex, int targetIndex, int count, ExistingData existingData = ExistingData.Clear)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (count != 0)
			{
				ValidateSubVectorRange(target, sourceIndex, targetIndex, count);
				CopySubVectorToUnchecked(target, sourceIndex, targetIndex, count, existingData);
			}
		}

		internal virtual void CopySubVectorToUnchecked(VectorStorage<T> target, int sourceIndex, int targetIndex, int count, ExistingData existingData)
		{
			if (this == target)
			{
				T[] array = new T[count];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = At(i + sourceIndex);
				}
				for (int j = 0; j < array.Length; j++)
				{
					At(j + targetIndex, array[j]);
				}
			}
			else
			{
				int num = sourceIndex;
				int num2 = targetIndex;
				while (num < sourceIndex + count)
				{
					target.At(num2, At(num));
					num++;
					num2++;
				}
			}
		}

		public void CopyToSubRow(MatrixStorage<T> target, int rowIndex, int sourceColumnIndex, int targetColumnIndex, int columnCount, ExistingData existingData = ExistingData.Clear)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (columnCount != 0)
			{
				ValidateSubRowRange(target, rowIndex, sourceColumnIndex, targetColumnIndex, columnCount);
				CopyToSubRowUnchecked(target, rowIndex, sourceColumnIndex, targetColumnIndex, columnCount, existingData);
			}
		}

		internal virtual void CopyToSubRowUnchecked(MatrixStorage<T> target, int rowIndex, int sourceColumnIndex, int targetColumnIndex, int columnCount, ExistingData existingData)
		{
			int num = sourceColumnIndex;
			int num2 = targetColumnIndex;
			while (num < sourceColumnIndex + columnCount)
			{
				target.At(rowIndex, num2, At(num));
				num++;
				num2++;
			}
		}

		public void CopyToSubColumn(MatrixStorage<T> target, int columnIndex, int sourceRowIndex, int targetRowIndex, int rowCount, ExistingData existingData = ExistingData.Clear)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (rowCount != 0)
			{
				ValidateSubColumnRange(target, columnIndex, sourceRowIndex, targetRowIndex, rowCount);
				CopyToSubColumnUnchecked(target, columnIndex, sourceRowIndex, targetRowIndex, rowCount, existingData);
			}
		}

		internal virtual void CopyToSubColumnUnchecked(MatrixStorage<T> target, int columnIndex, int sourceRowIndex, int targetRowIndex, int rowCount, ExistingData existingData)
		{
			int num = sourceRowIndex;
			int num2 = targetRowIndex;
			while (num < sourceRowIndex + rowCount)
			{
				target.At(num2, columnIndex, At(num));
				num++;
				num2++;
			}
		}

		public virtual T[] ToArray()
		{
			T[] array = new T[Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = At(i);
			}
			return array;
		}

		public virtual T[] AsArray()
		{
			return null;
		}

		public virtual IEnumerable<T> Enumerate()
		{
			for (int i = 0; i < Length; i++)
			{
				yield return At(i);
			}
		}

		public virtual IEnumerable<(int, T)> EnumerateIndexed()
		{
			for (int i = 0; i < Length; i++)
			{
				yield return (i, At(i));
			}
		}

		public virtual IEnumerable<T> EnumerateNonZero()
		{
			for (int i = 0; i < Length; i++)
			{
				T val = At(i);
				if (!Zero.Equals(val))
				{
					yield return val;
				}
			}
		}

		public virtual IEnumerable<(int, T)> EnumerateNonZeroIndexed()
		{
			for (int i = 0; i < Length; i++)
			{
				T val = At(i);
				if (!Zero.Equals(val))
				{
					yield return (i, val);
				}
			}
		}

		public virtual Tuple<int, T> Find(Func<T, bool> predicate, Zeros zeros)
		{
			for (int i = 0; i < Length; i++)
			{
				T val = At(i);
				if (predicate(val))
				{
					return new Tuple<int, T>(i, val);
				}
			}
			return null;
		}

		public Tuple<int, T, TOther> Find2<TOther>(VectorStorage<TOther> other, Func<T, TOther, bool> predicate, Zeros zeros) where TOther : struct, IEquatable<TOther>, IFormattable
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (Length != other.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "other");
			}
			return Find2Unchecked(other, predicate, zeros);
		}

		internal virtual Tuple<int, T, TOther> Find2Unchecked<TOther>(VectorStorage<TOther> other, Func<T, TOther, bool> predicate, Zeros zeros) where TOther : struct, IEquatable<TOther>, IFormattable
		{
			for (int i = 0; i < Length; i++)
			{
				T val = At(i);
				TOther val2 = other.At(i);
				if (predicate(val, val2))
				{
					return new Tuple<int, T, TOther>(i, val, val2);
				}
			}
			return null;
		}

		public virtual void MapInplace(Func<T, T> f, Zeros zeros)
		{
			for (int i = 0; i < Length; i++)
			{
				At(i, f(At(i)));
			}
		}

		public virtual void MapIndexedInplace(Func<int, T, T> f, Zeros zeros)
		{
			for (int i = 0; i < Length; i++)
			{
				At(i, f(i, At(i)));
			}
		}

		public void MapTo<TU>(VectorStorage<TU> target, Func<T, TU> f, Zeros zeros, ExistingData existingData) where TU : struct, IEquatable<TU>, IFormattable
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (Length != target.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "target");
			}
			MapToUnchecked(target, f, zeros, existingData);
		}

		internal virtual void MapToUnchecked<TU>(VectorStorage<TU> target, Func<T, TU> f, Zeros zeros, ExistingData existingData) where TU : struct, IEquatable<TU>, IFormattable
		{
			for (int i = 0; i < Length; i++)
			{
				target.At(i, f(At(i)));
			}
		}

		public void MapIndexedTo<TU>(VectorStorage<TU> target, Func<int, T, TU> f, Zeros zeros, ExistingData existingData) where TU : struct, IEquatable<TU>, IFormattable
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (Length != target.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "target");
			}
			MapIndexedToUnchecked(target, f, zeros, existingData);
		}

		internal virtual void MapIndexedToUnchecked<TU>(VectorStorage<TU> target, Func<int, T, TU> f, Zeros zeros, ExistingData existingData) where TU : struct, IEquatable<TU>, IFormattable
		{
			for (int i = 0; i < Length; i++)
			{
				target.At(i, f(i, At(i)));
			}
		}

		public void Map2To(VectorStorage<T> target, VectorStorage<T> other, Func<T, T, T> f, Zeros zeros, ExistingData existingData)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (Length != target.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "target");
			}
			if (Length != other.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "other");
			}
			Map2ToUnchecked(target, other, f, zeros, existingData);
		}

		internal virtual void Map2ToUnchecked(VectorStorage<T> target, VectorStorage<T> other, Func<T, T, T> f, Zeros zeros, ExistingData existingData)
		{
			for (int i = 0; i < Length; i++)
			{
				target.At(i, f(At(i), other.At(i)));
			}
		}

		public TState Fold2<TOther, TState>(VectorStorage<TOther> other, Func<TState, T, TOther, TState> f, TState state, Zeros zeros) where TOther : struct, IEquatable<TOther>, IFormattable
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (Length != other.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "other");
			}
			return Fold2Unchecked(other, f, state, zeros);
		}

		internal virtual TState Fold2Unchecked<TOther, TState>(VectorStorage<TOther> other, Func<TState, T, TOther, TState> f, TState state, Zeros zeros) where TOther : struct, IEquatable<TOther>, IFormattable
		{
			for (int i = 0; i < Length; i++)
			{
				state = f(state, At(i), other.At(i));
			}
			return state;
		}

		private void ValidateRange(int index)
		{
			if ((uint)index >= (uint)Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
		}

		private void ValidateSubVectorRange(VectorStorage<T> target, int sourceIndex, int targetIndex, int count)
		{
			if (count < 1)
			{
				throw new ArgumentOutOfRangeException("count", "Value must be positive.");
			}
			if ((uint)sourceIndex >= (uint)Length)
			{
				throw new ArgumentOutOfRangeException("sourceIndex");
			}
			if (sourceIndex + count > Length)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if ((uint)targetIndex >= (uint)target.Length)
			{
				throw new ArgumentOutOfRangeException("targetIndex");
			}
			if (targetIndex + count > target.Length)
			{
				throw new ArgumentOutOfRangeException("count");
			}
		}

		private void ValidateRowRange(MatrixStorage<T> target, int rowIndex)
		{
			if ((uint)rowIndex >= (uint)target.RowCount)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			if (target.ColumnCount != Length)
			{
				throw new ArgumentException("Matrix row dimensions must agree.", "target");
			}
		}

		private void ValidateColumnRange(MatrixStorage<T> target, int columnIndex)
		{
			if ((uint)columnIndex >= (uint)target.ColumnCount)
			{
				throw new ArgumentOutOfRangeException("columnIndex");
			}
			if (target.RowCount != Length)
			{
				throw new ArgumentException("Matrix column dimensions must agree.", "target");
			}
		}

		private void ValidateSubRowRange(MatrixStorage<T> target, int rowIndex, int sourceColumnIndex, int targetColumnIndex, int columnCount)
		{
			if (columnCount < 1)
			{
				throw new ArgumentOutOfRangeException("columnCount", "Value must be positive.");
			}
			if ((uint)sourceColumnIndex >= (uint)Length)
			{
				throw new ArgumentOutOfRangeException("sourceColumnIndex");
			}
			if (sourceColumnIndex + columnCount > Length)
			{
				throw new ArgumentOutOfRangeException("columnCount");
			}
			if ((uint)rowIndex >= (uint)target.RowCount)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			if ((uint)targetColumnIndex >= (uint)target.ColumnCount)
			{
				throw new ArgumentOutOfRangeException("targetColumnIndex");
			}
			if (targetColumnIndex + columnCount > target.ColumnCount)
			{
				throw new ArgumentOutOfRangeException("columnCount");
			}
		}

		private void ValidateSubColumnRange(MatrixStorage<T> target, int columnIndex, int sourceRowIndex, int targetRowIndex, int rowCount)
		{
			if (rowCount < 1)
			{
				throw new ArgumentOutOfRangeException("rowCount", "Value must be positive.");
			}
			if ((uint)sourceRowIndex >= (uint)Length)
			{
				throw new ArgumentOutOfRangeException("sourceRowIndex");
			}
			if (sourceRowIndex + rowCount > Length)
			{
				throw new ArgumentOutOfRangeException("rowCount");
			}
			if ((uint)columnIndex >= (uint)target.ColumnCount)
			{
				throw new ArgumentOutOfRangeException("columnIndex");
			}
			if ((uint)targetRowIndex >= (uint)target.RowCount)
			{
				throw new ArgumentOutOfRangeException("targetRowIndex");
			}
			if (targetRowIndex + rowCount > target.RowCount)
			{
				throw new ArgumentOutOfRangeException("rowCount");
			}
		}
	}
}
