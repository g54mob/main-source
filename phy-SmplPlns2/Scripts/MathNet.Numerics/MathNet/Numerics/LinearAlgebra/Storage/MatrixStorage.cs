using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MathNet.Numerics.LinearAlgebra.Storage
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics/LinearAlgebra")]
	public abstract class MatrixStorage<T> : IEquatable<MatrixStorage<T>> where T : struct, IEquatable<T>, IFormattable
	{
		protected static readonly T Zero = BuilderInstance<T>.Matrix.Zero;

		[DataMember(Order = 1)]
		public readonly int RowCount;

		[DataMember(Order = 2)]
		public readonly int ColumnCount;

		public abstract bool IsDense { get; }

		public abstract bool IsFullyMutable { get; }

		public T this[int row, int column]
		{
			get
			{
				ValidateRange(row, column);
				return At(row, column);
			}
			set
			{
				ValidateRange(row, column);
				At(row, column, value);
			}
		}

		protected MatrixStorage(int rowCount, int columnCount)
		{
			if (rowCount < 0)
			{
				throw new ArgumentOutOfRangeException("rowCount", "The number of rows of a matrix must be non-negative.");
			}
			if (columnCount < 0)
			{
				throw new ArgumentOutOfRangeException("columnCount", "The number of columns of a matrix must be non-negative.");
			}
			RowCount = rowCount;
			ColumnCount = columnCount;
		}

		public abstract bool IsMutableAt(int row, int column);

		public abstract T At(int row, int column);

		public abstract void At(int row, int column, T value);

		public bool Equals(MatrixStorage<T> other)
		{
			if (other == null)
			{
				return false;
			}
			if (ColumnCount != other.ColumnCount || RowCount != other.RowCount)
			{
				return false;
			}
			if (this == other)
			{
				return true;
			}
			return Find2Unchecked(other, (T a, T b) => !a.Equals(b), Zeros.AllowSkip) == null;
		}

		public sealed override bool Equals(object obj)
		{
			return Equals(obj as MatrixStorage<T>);
		}

		public override int GetHashCode()
		{
			int num = Math.Min(RowCount * ColumnCount, 25);
			int num2 = 17;
			for (int i = 0; i < num; i++)
			{
				int result;
				int row = Math.DivRem(i, ColumnCount, out result);
				num2 = num2 * 31 + At(row, result).GetHashCode();
			}
			return num2;
		}

		public virtual void Clear()
		{
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					At(i, j, Zero);
				}
			}
		}

		public void Clear(int rowIndex, int rowCount, int columnIndex, int columnCount)
		{
			if (rowCount >= 1 && columnCount >= 1)
			{
				if (rowIndex + rowCount > RowCount || rowIndex < 0)
				{
					throw new ArgumentOutOfRangeException("rowIndex");
				}
				if (columnIndex + columnCount > ColumnCount || columnIndex < 0)
				{
					throw new ArgumentOutOfRangeException("columnIndex");
				}
				ClearUnchecked(rowIndex, rowCount, columnIndex, columnCount);
			}
		}

		internal virtual void ClearUnchecked(int rowIndex, int rowCount, int columnIndex, int columnCount)
		{
			for (int i = rowIndex; i < rowIndex + rowCount; i++)
			{
				for (int j = columnIndex; j < columnIndex + columnCount; j++)
				{
					At(i, j, Zero);
				}
			}
		}

		public void ClearRows(int[] rowIndices)
		{
			if (rowIndices.Length == 0)
			{
				return;
			}
			for (int i = 0; i < rowIndices.Length; i++)
			{
				if (rowIndices[i] < 0 || rowIndices[i] >= RowCount)
				{
					throw new ArgumentOutOfRangeException("rowIndices");
				}
			}
			ClearRowsUnchecked(rowIndices);
		}

		public void ClearColumns(int[] columnIndices)
		{
			if (columnIndices.Length == 0)
			{
				return;
			}
			for (int i = 0; i < columnIndices.Length; i++)
			{
				if ((uint)columnIndices[i] >= (uint)ColumnCount)
				{
					throw new ArgumentOutOfRangeException("columnIndices");
				}
			}
			ClearColumnsUnchecked(columnIndices);
		}

		internal virtual void ClearRowsUnchecked(int[] rowIndices)
		{
			foreach (int row in rowIndices)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					At(row, j, Zero);
				}
			}
		}

		internal virtual void ClearColumnsUnchecked(int[] columnIndices)
		{
			foreach (int column in columnIndices)
			{
				for (int j = 0; j < RowCount; j++)
				{
					At(j, column, Zero);
				}
			}
		}

		public void CopyTo(MatrixStorage<T> target, ExistingData existingData = ExistingData.Clear)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (this != target)
			{
				if (RowCount != target.RowCount || ColumnCount != target.ColumnCount)
				{
					throw new ArgumentException($"Matrix dimensions must agree: op1 is {RowCount}x{ColumnCount}, op2 is {target.RowCount}x{target.ColumnCount}.", "target");
				}
				CopyToUnchecked(target, existingData);
			}
		}

		internal virtual void CopyToUnchecked(MatrixStorage<T> target, ExistingData existingData)
		{
			for (int i = 0; i < ColumnCount; i++)
			{
				for (int j = 0; j < RowCount; j++)
				{
					target.At(j, i, At(j, i));
				}
			}
		}

		public void CopySubMatrixTo(MatrixStorage<T> target, int sourceRowIndex, int targetRowIndex, int rowCount, int sourceColumnIndex, int targetColumnIndex, int columnCount, ExistingData existingData = ExistingData.Clear)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (rowCount == 0 || columnCount == 0)
			{
				return;
			}
			if (sourceRowIndex == 0 && targetRowIndex == 0 && rowCount == RowCount && rowCount == target.RowCount && sourceColumnIndex == 0 && targetColumnIndex == 0 && columnCount == ColumnCount && columnCount == target.ColumnCount)
			{
				CopyTo(target);
				return;
			}
			if (this == target)
			{
				throw new NotSupportedException();
			}
			ValidateSubMatrixRange(target, sourceRowIndex, targetRowIndex, rowCount, sourceColumnIndex, targetColumnIndex, columnCount);
			CopySubMatrixToUnchecked(target, sourceRowIndex, targetRowIndex, rowCount, sourceColumnIndex, targetColumnIndex, columnCount, existingData);
		}

		internal virtual void CopySubMatrixToUnchecked(MatrixStorage<T> target, int sourceRowIndex, int targetRowIndex, int rowCount, int sourceColumnIndex, int targetColumnIndex, int columnCount, ExistingData existingData)
		{
			int num = sourceColumnIndex;
			int num2 = targetColumnIndex;
			while (num < sourceColumnIndex + columnCount)
			{
				int num3 = sourceRowIndex;
				int num4 = targetRowIndex;
				while (num3 < sourceRowIndex + rowCount)
				{
					target.At(num4, num2, At(num3, num));
					num3++;
					num4++;
				}
				num++;
				num2++;
			}
		}

		public void CopyRowTo(VectorStorage<T> target, int rowIndex, ExistingData existingData = ExistingData.Clear)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			ValidateRowRange(target, rowIndex);
			CopySubRowToUnchecked(target, rowIndex, 0, 0, ColumnCount, existingData);
		}

		public void CopySubRowTo(VectorStorage<T> target, int rowIndex, int sourceColumnIndex, int targetColumnIndex, int columnCount, ExistingData existingData = ExistingData.Clear)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (columnCount != 0)
			{
				ValidateSubRowRange(target, rowIndex, sourceColumnIndex, targetColumnIndex, columnCount);
				CopySubRowToUnchecked(target, rowIndex, sourceColumnIndex, targetColumnIndex, columnCount, existingData);
			}
		}

		internal virtual void CopySubRowToUnchecked(VectorStorage<T> target, int rowIndex, int sourceColumnIndex, int targetColumnIndex, int columnCount, ExistingData existingData)
		{
			int num = sourceColumnIndex;
			int num2 = targetColumnIndex;
			while (num < sourceColumnIndex + columnCount)
			{
				target.At(num2, At(rowIndex, num));
				num++;
				num2++;
			}
		}

		public void CopyColumnTo(VectorStorage<T> target, int columnIndex, ExistingData existingData = ExistingData.Clear)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			ValidateColumnRange(target, columnIndex);
			CopySubColumnToUnchecked(target, columnIndex, 0, 0, RowCount, existingData);
		}

		public void CopySubColumnTo(VectorStorage<T> target, int columnIndex, int sourceRowIndex, int targetRowIndex, int rowCount, ExistingData existingData = ExistingData.Clear)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (rowCount != 0)
			{
				ValidateSubColumnRange(target, columnIndex, sourceRowIndex, targetRowIndex, rowCount);
				CopySubColumnToUnchecked(target, columnIndex, sourceRowIndex, targetRowIndex, rowCount, existingData);
			}
		}

		internal virtual void CopySubColumnToUnchecked(VectorStorage<T> target, int columnIndex, int sourceRowIndex, int targetRowIndex, int rowCount, ExistingData existingData)
		{
			int num = sourceRowIndex;
			int num2 = targetRowIndex;
			while (num < sourceRowIndex + rowCount)
			{
				target.At(num2, At(num, columnIndex));
				num++;
				num2++;
			}
		}

		public void TransposeTo(MatrixStorage<T> target, ExistingData existingData = ExistingData.Clear)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (RowCount != target.ColumnCount || ColumnCount != target.RowCount)
			{
				throw new ArgumentException($"Matrix dimensions must agree: op1 is {RowCount}x{ColumnCount}, op2 is {target.RowCount}x{target.ColumnCount}.", "target");
			}
			if (this == target)
			{
				TransposeSquareInplaceUnchecked();
			}
			else
			{
				TransposeToUnchecked(target, existingData);
			}
		}

		internal virtual void TransposeToUnchecked(MatrixStorage<T> target, ExistingData existingData)
		{
			for (int i = 0; i < ColumnCount; i++)
			{
				for (int j = 0; j < RowCount; j++)
				{
					target.At(i, j, At(j, i));
				}
			}
		}

		internal virtual void TransposeSquareInplaceUnchecked()
		{
			for (int i = 0; i < ColumnCount; i++)
			{
				for (int j = 0; j < i; j++)
				{
					T value = At(j, i);
					At(j, i, At(i, j));
					At(i, j, value);
				}
			}
		}

		public virtual T[] ToRowMajorArray()
		{
			T[] array = new T[RowCount * ColumnCount];
			for (int i = 0; i < RowCount; i++)
			{
				int num = i * ColumnCount;
				for (int j = 0; j < ColumnCount; j++)
				{
					array[num + j] = At(i, j);
				}
			}
			return array;
		}

		public virtual T[] ToColumnMajorArray()
		{
			T[] array = new T[RowCount * ColumnCount];
			for (int i = 0; i < ColumnCount; i++)
			{
				int num = i * RowCount;
				for (int j = 0; j < RowCount; j++)
				{
					array[num + j] = At(j, i);
				}
			}
			return array;
		}

		public virtual T[][] ToRowArrays()
		{
			T[][] array = new T[RowCount][];
			for (int i = 0; i < RowCount; i++)
			{
				T[] array2 = new T[ColumnCount];
				for (int j = 0; j < ColumnCount; j++)
				{
					array2[j] = At(i, j);
				}
				array[i] = array2;
			}
			return array;
		}

		public virtual T[][] ToColumnArrays()
		{
			T[][] array = new T[ColumnCount][];
			for (int i = 0; i < ColumnCount; i++)
			{
				T[] array2 = new T[RowCount];
				for (int j = 0; j < RowCount; j++)
				{
					array2[j] = At(j, i);
				}
				array[i] = array2;
			}
			return array;
		}

		public virtual T[,] ToArray()
		{
			T[,] array = new T[RowCount, ColumnCount];
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					array[i, j] = At(i, j);
				}
			}
			return array;
		}

		public virtual T[] AsRowMajorArray()
		{
			return null;
		}

		public virtual T[] AsColumnMajorArray()
		{
			return null;
		}

		public virtual T[][] AsRowArrays()
		{
			return null;
		}

		public virtual T[][] AsColumnArrays()
		{
			return null;
		}

		public virtual T[,] AsArray()
		{
			return null;
		}

		public virtual IEnumerable<T> Enumerate()
		{
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					yield return At(i, j);
				}
			}
		}

		public virtual IEnumerable<(int, int, T)> EnumerateIndexed()
		{
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					yield return (i, j, At(i, j));
				}
			}
		}

		public virtual IEnumerable<T> EnumerateNonZero()
		{
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					T val = At(i, j);
					if (!Zero.Equals(val))
					{
						yield return val;
					}
				}
			}
		}

		public virtual IEnumerable<(int, int, T)> EnumerateNonZeroIndexed()
		{
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					T val = At(i, j);
					if (!Zero.Equals(val))
					{
						yield return (i, j, val);
					}
				}
			}
		}

		public virtual Tuple<int, int, T> Find(Func<T, bool> predicate, Zeros zeros)
		{
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					T val = At(i, j);
					if (predicate(val))
					{
						return new Tuple<int, int, T>(i, j, val);
					}
				}
			}
			return null;
		}

		public Tuple<int, int, T, TOther> Find2<TOther>(MatrixStorage<TOther> other, Func<T, TOther, bool> predicate, Zeros zeros) where TOther : struct, IEquatable<TOther>, IFormattable
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (RowCount != other.RowCount || ColumnCount != other.ColumnCount)
			{
				throw new ArgumentException($"Matrix dimensions must agree: op1 is {RowCount}x{ColumnCount}, op2 is {other.RowCount}x{other.ColumnCount}.", "other");
			}
			return Find2Unchecked(other, predicate, zeros);
		}

		internal virtual Tuple<int, int, T, TOther> Find2Unchecked<TOther>(MatrixStorage<TOther> other, Func<T, TOther, bool> predicate, Zeros zeros) where TOther : struct, IEquatable<TOther>, IFormattable
		{
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					T val = At(i, j);
					TOther val2 = other.At(i, j);
					if (predicate(val, val2))
					{
						return new Tuple<int, int, T, TOther>(i, j, val, val2);
					}
				}
			}
			return null;
		}

		public virtual void MapInplace(Func<T, T> f, Zeros zeros)
		{
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					At(i, j, f(At(i, j)));
				}
			}
		}

		public virtual void MapIndexedInplace(Func<int, int, T, T> f, Zeros zeros)
		{
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					At(i, j, f(i, j, At(i, j)));
				}
			}
		}

		public void MapTo<TU>(MatrixStorage<TU> target, Func<T, TU> f, Zeros zeros, ExistingData existingData) where TU : struct, IEquatable<TU>, IFormattable
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (RowCount != target.RowCount || ColumnCount != target.ColumnCount)
			{
				throw new ArgumentException($"Matrix dimensions must agree: op1 is {RowCount}x{ColumnCount}, op2 is {target.RowCount}x{target.ColumnCount}.", "target");
			}
			MapToUnchecked(target, f, zeros, existingData);
		}

		internal virtual void MapToUnchecked<TU>(MatrixStorage<TU> target, Func<T, TU> f, Zeros zeros, ExistingData existingData) where TU : struct, IEquatable<TU>, IFormattable
		{
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					target.At(i, j, f(At(i, j)));
				}
			}
		}

		public void MapIndexedTo<TU>(MatrixStorage<TU> target, Func<int, int, T, TU> f, Zeros zeros, ExistingData existingData) where TU : struct, IEquatable<TU>, IFormattable
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (RowCount != target.RowCount || ColumnCount != target.ColumnCount)
			{
				throw new ArgumentException($"Matrix dimensions must agree: op1 is {RowCount}x{ColumnCount}, op2 is {target.RowCount}x{target.ColumnCount}.", "target");
			}
			MapIndexedToUnchecked(target, f, zeros, existingData);
		}

		internal virtual void MapIndexedToUnchecked<TU>(MatrixStorage<TU> target, Func<int, int, T, TU> f, Zeros zeros, ExistingData existingData) where TU : struct, IEquatable<TU>, IFormattable
		{
			for (int i = 0; i < ColumnCount; i++)
			{
				for (int j = 0; j < RowCount; j++)
				{
					target.At(j, i, f(j, i, At(j, i)));
				}
			}
		}

		public void MapSubMatrixIndexedTo<TU>(MatrixStorage<TU> target, Func<int, int, T, TU> f, int sourceRowIndex, int targetRowIndex, int rowCount, int sourceColumnIndex, int targetColumnIndex, int columnCount, Zeros zeros, ExistingData existingData) where TU : struct, IEquatable<TU>, IFormattable
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (rowCount != 0 && columnCount != 0)
			{
				if ((object)this == target)
				{
					throw new NotSupportedException();
				}
				ValidateSubMatrixRange(target, sourceRowIndex, targetRowIndex, rowCount, sourceColumnIndex, targetColumnIndex, columnCount);
				MapSubMatrixIndexedToUnchecked(target, f, sourceRowIndex, targetRowIndex, rowCount, sourceColumnIndex, targetColumnIndex, columnCount, zeros, existingData);
			}
		}

		internal virtual void MapSubMatrixIndexedToUnchecked<TU>(MatrixStorage<TU> target, Func<int, int, T, TU> f, int sourceRowIndex, int targetRowIndex, int rowCount, int sourceColumnIndex, int targetColumnIndex, int columnCount, Zeros zeros, ExistingData existingData) where TU : struct, IEquatable<TU>, IFormattable
		{
			int num = sourceColumnIndex;
			int num2 = targetColumnIndex;
			while (num < sourceColumnIndex + columnCount)
			{
				int num3 = sourceRowIndex;
				int num4 = targetRowIndex;
				while (num3 < sourceRowIndex + rowCount)
				{
					target.At(num4, num2, f(num4, num2, At(num3, num)));
					num3++;
					num4++;
				}
				num++;
				num2++;
			}
		}

		public void Map2To(MatrixStorage<T> target, MatrixStorage<T> other, Func<T, T, T> f, Zeros zeros, ExistingData existingData)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (RowCount != target.RowCount || ColumnCount != target.ColumnCount)
			{
				throw new ArgumentException($"Matrix dimensions must agree: op1 is {RowCount}x{ColumnCount}, op2 is {target.RowCount}x{target.ColumnCount}.", "target");
			}
			if (RowCount != other.RowCount || ColumnCount != other.ColumnCount)
			{
				throw new ArgumentException($"Matrix dimensions must agree: op1 is {RowCount}x{ColumnCount}, op2 is {other.RowCount}x{other.ColumnCount}.", "other");
			}
			Map2ToUnchecked(target, other, f, zeros, existingData);
		}

		internal virtual void Map2ToUnchecked(MatrixStorage<T> target, MatrixStorage<T> other, Func<T, T, T> f, Zeros zeros, ExistingData existingData)
		{
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					target.At(i, j, f(At(i, j), other.At(i, j)));
				}
			}
		}

		public void FoldByRow<TU>(TU[] target, Func<TU, T, TU> f, Func<TU, int, TU> finalize, TU[] state, Zeros zeros)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (target.Length != RowCount)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "target");
			}
			if (state == null)
			{
				throw new ArgumentNullException("state");
			}
			if (state.Length != RowCount)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "state");
			}
			FoldByRowUnchecked(target, f, finalize, state, zeros);
		}

		internal virtual void FoldByRowUnchecked<TU>(TU[] target, Func<TU, T, TU> f, Func<TU, int, TU> finalize, TU[] state, Zeros zeros)
		{
			for (int i = 0; i < RowCount; i++)
			{
				TU arg = state[i];
				for (int j = 0; j < ColumnCount; j++)
				{
					arg = f(arg, At(i, j));
				}
				target[i] = finalize(arg, ColumnCount);
			}
		}

		public void FoldByColumn<TU>(TU[] target, Func<TU, T, TU> f, Func<TU, int, TU> finalize, TU[] state, Zeros zeros)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (target.Length != ColumnCount)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "target");
			}
			if (state == null)
			{
				throw new ArgumentNullException("state");
			}
			if (state.Length != ColumnCount)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "state");
			}
			FoldByColumnUnchecked(target, f, finalize, state, zeros);
		}

		internal virtual void FoldByColumnUnchecked<TU>(TU[] target, Func<TU, T, TU> f, Func<TU, int, TU> finalize, TU[] state, Zeros zeros)
		{
			for (int i = 0; i < ColumnCount; i++)
			{
				TU arg = state[i];
				for (int j = 0; j < RowCount; j++)
				{
					arg = f(arg, At(j, i));
				}
				target[i] = finalize(arg, RowCount);
			}
		}

		public TState Fold2<TOther, TState>(MatrixStorage<TOther> other, Func<TState, T, TOther, TState> f, TState state, Zeros zeros) where TOther : struct, IEquatable<TOther>, IFormattable
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (RowCount != other.RowCount || ColumnCount != other.ColumnCount)
			{
				throw new ArgumentException($"Matrix dimensions must agree: op1 is {RowCount}x{ColumnCount}, op2 is {other.RowCount}x{other.ColumnCount}.", "other");
			}
			return Fold2Unchecked(other, f, state, zeros);
		}

		internal virtual TState Fold2Unchecked<TOther, TState>(MatrixStorage<TOther> other, Func<TState, T, TOther, TState> f, TState state, Zeros zeros) where TOther : struct, IEquatable<TOther>, IFormattable
		{
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					state = f(state, At(i, j), other.At(i, j));
				}
			}
			return state;
		}

		private void ValidateRange(int row, int column)
		{
			if ((uint)row >= (uint)RowCount)
			{
				throw new ArgumentOutOfRangeException("row");
			}
			if ((uint)column >= (uint)ColumnCount)
			{
				throw new ArgumentOutOfRangeException("column");
			}
		}

		private void ValidateSubMatrixRange<TU>(MatrixStorage<TU> target, int sourceRowIndex, int targetRowIndex, int rowCount, int sourceColumnIndex, int targetColumnIndex, int columnCount) where TU : struct, IEquatable<TU>, IFormattable
		{
			if (rowCount < 1)
			{
				throw new ArgumentOutOfRangeException("rowCount", "Value must be positive.");
			}
			if (columnCount < 1)
			{
				throw new ArgumentOutOfRangeException("columnCount", "Value must be positive.");
			}
			if ((uint)sourceRowIndex >= (uint)RowCount)
			{
				throw new ArgumentOutOfRangeException("sourceRowIndex");
			}
			if ((uint)sourceColumnIndex >= (uint)ColumnCount)
			{
				throw new ArgumentOutOfRangeException("sourceColumnIndex");
			}
			int num = sourceRowIndex + rowCount;
			int num2 = sourceColumnIndex + columnCount;
			if (num > RowCount)
			{
				throw new ArgumentOutOfRangeException("rowCount");
			}
			if (num2 > ColumnCount)
			{
				throw new ArgumentOutOfRangeException("columnCount");
			}
			if ((uint)targetRowIndex >= (uint)target.RowCount)
			{
				throw new ArgumentOutOfRangeException("targetRowIndex");
			}
			if ((uint)targetColumnIndex >= (uint)target.ColumnCount)
			{
				throw new ArgumentOutOfRangeException("targetColumnIndex");
			}
			int num3 = targetRowIndex + rowCount;
			int num4 = targetColumnIndex + columnCount;
			if (num3 > target.RowCount)
			{
				throw new ArgumentOutOfRangeException("rowCount");
			}
			if (num4 > target.ColumnCount)
			{
				throw new ArgumentOutOfRangeException("columnCount");
			}
		}

		private void ValidateRowRange<TU>(VectorStorage<TU> target, int rowIndex) where TU : struct, IEquatable<TU>, IFormattable
		{
			if ((uint)rowIndex >= (uint)RowCount)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			if (ColumnCount != target.Length)
			{
				throw new ArgumentException("Matrix row dimensions must agree.", "target");
			}
		}

		private void ValidateColumnRange<TU>(VectorStorage<TU> target, int columnIndex) where TU : struct, IEquatable<TU>, IFormattable
		{
			if ((uint)columnIndex >= (uint)ColumnCount)
			{
				throw new ArgumentOutOfRangeException("columnIndex");
			}
			if (RowCount != target.Length)
			{
				throw new ArgumentException("Matrix column dimensions must agree.", "target");
			}
		}

		private void ValidateSubRowRange<TU>(VectorStorage<TU> target, int rowIndex, int sourceColumnIndex, int targetColumnIndex, int columnCount) where TU : struct, IEquatable<TU>, IFormattable
		{
			if (columnCount < 1)
			{
				throw new ArgumentOutOfRangeException("columnCount", "Value must be positive.");
			}
			if ((uint)rowIndex >= (uint)RowCount)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			if ((uint)sourceColumnIndex >= (uint)ColumnCount)
			{
				throw new ArgumentOutOfRangeException("sourceColumnIndex");
			}
			if (sourceColumnIndex + columnCount > ColumnCount)
			{
				throw new ArgumentOutOfRangeException("columnCount");
			}
			if ((uint)targetColumnIndex >= (uint)target.Length)
			{
				throw new ArgumentOutOfRangeException("targetColumnIndex");
			}
			if (targetColumnIndex + columnCount > target.Length)
			{
				throw new ArgumentOutOfRangeException("columnCount");
			}
		}

		private void ValidateSubColumnRange<TU>(VectorStorage<TU> target, int columnIndex, int sourceRowIndex, int targetRowIndex, int rowCount) where TU : struct, IEquatable<TU>, IFormattable
		{
			if (rowCount < 1)
			{
				throw new ArgumentOutOfRangeException("rowCount", "Value must be positive.");
			}
			if ((uint)columnIndex >= (uint)ColumnCount)
			{
				throw new ArgumentOutOfRangeException("columnIndex");
			}
			if ((uint)sourceRowIndex >= (uint)RowCount)
			{
				throw new ArgumentOutOfRangeException("sourceRowIndex");
			}
			if (sourceRowIndex + rowCount > RowCount)
			{
				throw new ArgumentOutOfRangeException("rowCount");
			}
			if ((uint)targetRowIndex >= (uint)target.Length)
			{
				throw new ArgumentOutOfRangeException("targetRowIndex");
			}
			if (targetRowIndex + rowCount > target.Length)
			{
				throw new ArgumentOutOfRangeException("rowCount");
			}
		}
	}
}
