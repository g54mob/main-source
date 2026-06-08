namespace LINQtoCSV
{
	public interface IDataRow
	{
		int Count { get; }

		DataRowItem this[int index] { get; set; }

		void Clear();

		void Add(DataRowItem item);
	}
}
