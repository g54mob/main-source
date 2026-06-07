using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NGenerics.Util;

namespace NGenerics.DataStructures.General
{
	[Serializable]
	public class ObjectMatrix<T> : IMatrix<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		private const string rowsOrColumnsInvalid = "Rows and columns must be nonnegative values.";

		protected int noOfColumns;

		protected int noOfRows;

		protected T[] data;

		public bool IsSquare
		{
			get
			{
				return noOfRows == noOfColumns;
			}
		}

		public T this[int row, int column]
		{
			get
			{
				CheckIndexValid(row, column);
				return data[GetOffset(row, column)];
			}
			set
			{
				CheckIndexValid(row, column);
				data[GetOffset(row, column)] = value;
			}
		}

		int ICollection<T>.Count
		{
			get
			{
				return data.Length;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public int Columns
		{
			get
			{
				return noOfColumns;
			}
		}

		public int Rows
		{
			get
			{
				return noOfRows;
			}
		}

		internal T[] Data
		{
			get
			{
				return data;
			}
		}

		public ObjectMatrix(int rows, int columns)
		{
			if (rows <= 0)
			{
				throw new ArgumentException("Rows and columns must be nonnegative values.", "rows");
			}
			if (columns <= 0)
			{
				throw new ArgumentException("Rows and columns must be nonnegative values.", "columns");
			}
			noOfColumns = columns;
			noOfRows = rows;
			data = new T[noOfRows * noOfColumns];
		}

		internal ObjectMatrix(int rows, int columns, T[] pData)
		{
			noOfColumns = columns;
			noOfRows = rows;
			data = pData;
		}

		internal ObjectMatrix(int rows, int columns, T[,] data)
			: this(rows, columns)
		{
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					this.data[i * columns + j] = data[i, j];
				}
			}
		}

		IMatrix<T> IMatrix<T>.GetSubMatrix(int rowStart, int noOfColumnStart, int rowCount, int columnCount)
		{
			return GetSubMatrix(rowStart, noOfColumnStart, rowCount, columnCount);
		}

		void ICollection<T>.Add(T item)
		{
			throw new NotSupportedException();
		}

		public void Clear()
		{
			data = new T[data.Length];
		}

		public bool Contains(T item)
		{
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i].Equals(item))
				{
					return true;
				}
			}
			return false;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			Guard.ArgumentNotNull(array, "array");
			if (array.Length - arrayIndex < data.Length)
			{
				throw new ArgumentException("Not enough space in the target array.", "array");
			}
			Array.Copy(data, 0, array, arrayIndex, data.Length);
		}

		bool ICollection<T>.Remove(T item)
		{
			throw new NotSupportedException();
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < data.Length; i++)
			{
				yield return data[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void ValidateIsSquare()
		{
			if (!IsSquare)
			{
				throw new InvalidOperationException("The operation is only valid on a square matrix.");
			}
		}

		public T[,] ToArray()
		{
			T[,] array = new T[Rows, Columns];
			for (int i = 0; i < Rows; i++)
			{
				for (int j = 0; j < Columns; j++)
				{
					array[i, j] = GetValue(i, j);
				}
			}
			return array;
		}

		public ObjectMatrix<T> GetSubMatrix(int rowStart, int columnStart, int rowCount, int columnCount)
		{
			if (rowCount <= 0)
			{
				throw new ArgumentOutOfRangeException("rowCount", "Column and row count must be larger than 0.");
			}
			if (columnCount <= 0)
			{
				throw new ArgumentOutOfRangeException("columnCount", "Column and row count must be larger than 0.");
			}
			if (rowStart < 0)
			{
				throw new ArgumentOutOfRangeException("rowStart", "The row index to start from can not be smaller than 0.");
			}
			if (columnStart < 0)
			{
				throw new ArgumentOutOfRangeException("columnCount", "The column index to start from can not be smaller than 0.");
			}
			if (rowStart + rowCount > Rows || columnStart + columnCount > Columns)
			{
				throw new ArgumentOutOfRangeException("rowStart", "More rows or columns have been specified than is present in the matrix.");
			}
			ObjectMatrix<T> objectMatrix = new ObjectMatrix<T>(rowCount, columnCount);
			for (int i = rowStart; i < rowStart + rowCount; i++)
			{
				for (int j = columnStart; j < columnStart + columnCount; j++)
				{
					objectMatrix.SetValue(i - rowStart, j - columnStart, GetValue(i, j));
				}
			}
			return objectMatrix;
		}

		public void InterchangeRows(int firstRow, int secondRow)
		{
			if (firstRow < 0 || firstRow > noOfRows - 1)
			{
				throw new ArgumentOutOfRangeException("firstRow");
			}
			if (secondRow < 0 || secondRow > noOfRows - 1)
			{
				throw new ArgumentOutOfRangeException("secondRow");
			}
			if (firstRow != secondRow)
			{
				for (int i = 0; i < noOfColumns; i++)
				{
					T value = GetValue(firstRow, i);
					SetValue(firstRow, i, GetValue(secondRow, i));
					SetValue(secondRow, i, value);
				}
			}
		}

		public void InterchangeColumns(int firstColumn, int secondColumn)
		{
			if (firstColumn < 0 || firstColumn > noOfColumns - 1)
			{
				throw new ArgumentOutOfRangeException("firstColumn");
			}
			if (secondColumn < 0 || secondColumn > noOfColumns - 1)
			{
				throw new ArgumentOutOfRangeException("secondColumn");
			}
			if (firstColumn != secondColumn)
			{
				for (int i = 0; i < noOfRows; i++)
				{
					T value = GetValue(i, firstColumn);
					SetValue(i, firstColumn, GetValue(i, secondColumn));
					SetValue(i, secondColumn, value);
				}
			}
		}

		public T[] GetRow(int rowIndex)
		{
			if (rowIndex < 0 || rowIndex > noOfRows - 1)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			T[] array = new T[noOfColumns];
			for (int i = 0; i < noOfColumns; i++)
			{
				array[i] = GetValue(rowIndex, i);
			}
			return array;
		}

		public T[] GetColumn(int columnIndex)
		{
			if (columnIndex < 0 || columnIndex > noOfColumns - 1)
			{
				throw new ArgumentOutOfRangeException("columnIndex");
			}
			T[] array = new T[noOfRows];
			for (int i = 0; i < noOfRows; i++)
			{
				array[i] = GetValue(i, columnIndex);
			}
			return array;
		}

		public void AddRows(int rowCount)
		{
			if (rowCount <= 0)
			{
				throw new ArgumentOutOfRangeException("rowCount");
			}
			int num = noOfRows + rowCount;
			T[] newData = new T[num * noOfColumns];
			CopyData(newData, noOfColumns);
			noOfRows = num;
			data = newData;
		}

		public void AddRow()
		{
			AddRows(1);
		}

		public void AddColumn(params T[] values)
		{
			Guard.ArgumentNotNull(values, "values");
			if (values.Length > noOfRows)
			{
				throw new ArgumentException("The number of values can not be greater than the number of rows.", "values");
			}
			AddColumn();
			for (int i = 0; i < values.Length; i++)
			{
				SetValue(i, noOfColumns - 1, values[i]);
			}
		}

		public void AddColumns(int columnCount)
		{
			if (columnCount <= 0)
			{
				throw new ArgumentOutOfRangeException("columnCount");
			}
			int num = noOfColumns + columnCount;
			T[] newData = new T[noOfRows * num];
			CopyData(newData, num);
			noOfColumns = num;
			data = newData;
		}

		public void AddColumn()
		{
			AddColumns(1);
		}

		public void AddRow(params T[] values)
		{
			Guard.ArgumentNotNull(values, "values");
			if (values.Length > noOfColumns)
			{
				throw new ArgumentException("The number of values can not be greater than the number of columns.", "values");
			}
			AddRow();
			for (int i = 0; i < values.Length; i++)
			{
				SetValue(noOfRows - 1, i, values[i]);
			}
		}

		public void Resize(int newNumberOfRows, int newNumberOfColumns)
		{
			if (newNumberOfRows <= 0)
			{
				throw new ArgumentException("Rows and columns must be nonnegative values.", "newNumberOfRows");
			}
			if (newNumberOfColumns <= 0)
			{
				throw new ArgumentException("Rows and columns must be nonnegative values.", "newNumberOfColumns");
			}
			T[] array = new T[newNumberOfRows * newNumberOfColumns];
			int num = Math.Min(noOfRows, newNumberOfRows);
			int num2 = Math.Min(noOfColumns, newNumberOfColumns);
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					array[newNumberOfRows * i + j] = GetValue(i, j);
				}
			}
			data = array;
			noOfRows = newNumberOfRows;
			noOfColumns = newNumberOfColumns;
		}

		public void DeleteRow(int row)
		{
			if (noOfRows == 1)
			{
				throw new InvalidOperationException("The matrix has only one row left, which can not be deleted.");
			}
			int num = noOfRows - 1;
			if (row > num || row < 0)
			{
				throw new ArgumentOutOfRangeException("row");
			}
			T[] destinationArray = new T[num * Columns];
			Array.Copy(data, 0, destinationArray, 0, row * Columns);
			Array.Copy(data, (row + 1) * Columns, destinationArray, row * Columns, Columns * (num - row));
			data = destinationArray;
			noOfRows--;
		}

		public void DeleteColumn(int column)
		{
			if (noOfColumns == 1)
			{
				throw new InvalidOperationException("The matrix has only one column left, which can not be deleted.");
			}
			if (column > noOfColumns - 1 || column < 0)
			{
				throw new ArgumentOutOfRangeException("column");
			}
			T[] array = new T[noOfRows * (noOfColumns - 1)];
			for (int i = 0; i < noOfRows; i++)
			{
				int num = 0;
				for (int j = 0; j < noOfColumns; j++)
				{
					if (j != column)
					{
						array[i * (noOfColumns - 1) + num] = GetValue(i, j);
						num++;
					}
				}
			}
			data = array;
			noOfColumns--;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(noOfRows * noOfColumns * 2);
			for (int i = 0; i < noOfRows; i++)
			{
				for (int j = 0; j < noOfColumns; j++)
				{
					stringBuilder.Append(GetValue(i, j)).Append("\t");
				}
				stringBuilder.AppendLine();
			}
			return stringBuilder.ToString();
		}

		internal T GetValue(int row, int column)
		{
			return data[GetOffset(row, column)];
		}

		internal void SetValue(int row, int column, T value)
		{
			data[GetOffset(row, column)] = value;
		}

		protected int GetOffset(int row, int column)
		{
			return row * noOfColumns + column;
		}

		private void CheckIndexValid(int i, int j)
		{
			if (i < 0 || i > noOfRows - 1)
			{
				throw new ArgumentOutOfRangeException("i");
			}
			if (j < 0 || j > noOfColumns - 1)
			{
				throw new ArgumentOutOfRangeException("j");
			}
		}

		private void CopyData(T[] newData, int newColumnCount)
		{
			int length = ((noOfColumns >= newColumnCount) ? newColumnCount : noOfColumns);
			for (int i = 0; i < noOfRows; i++)
			{
				Array.Copy(data, i * noOfColumns, newData, i * newColumnCount, length);
			}
		}
	}
}
