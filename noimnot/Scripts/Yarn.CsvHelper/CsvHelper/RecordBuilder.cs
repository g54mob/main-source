namespace CsvHelper
{
	public class RecordBuilder
	{
		private const int DEFAULT_CAPACITY = 16;

		private string[] record;

		private int position;

		private int capacity;

		public int Length => 0;

		public int Capacity => 0;

		public RecordBuilder()
		{
		}

		public RecordBuilder(int capacity)
		{
		}

		public virtual RecordBuilder Add(string field)
		{
			return null;
		}

		public virtual RecordBuilder Clear()
		{
			return null;
		}

		public virtual string[] ToArray()
		{
			return null;
		}
	}
}
