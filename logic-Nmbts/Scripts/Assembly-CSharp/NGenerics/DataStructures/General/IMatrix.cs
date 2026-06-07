namespace NGenerics.DataStructures.General
{
	public interface IMatrix<T>
	{
		int Columns { get; }

		int Rows { get; }

		bool IsSquare { get; }

		T this[int row, int column] { get; set; }

		IMatrix<T> GetSubMatrix(int rowStart, int columnStart, int rowCount, int columnCount);

		void InterchangeRows(int firstRow, int secondRow);

		void InterchangeColumns(int firstColumn, int secondColumn);

		T[] GetRow(int rowIndex);

		T[] GetColumn(int columnIndex);

		void AddRows(int rowCount);

		void AddRow();

		void AddRow(params T[] values);

		void AddColumns(int columnCount);

		void AddColumn();

		void AddColumn(params T[] values);

		void DeleteRow(int row);

		void DeleteColumn(int column);

		void Resize(int newNumberOfRows, int newNumberOfColumns);
	}
}
