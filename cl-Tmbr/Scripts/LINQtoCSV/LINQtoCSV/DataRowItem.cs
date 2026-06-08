namespace LINQtoCSV
{
	public class DataRowItem
	{
		private string m_value;

		private int m_lineNbr;

		public int LineNbr => m_lineNbr;

		public string Value => m_value;

		public DataRowItem(string value, int lineNbr)
		{
			m_value = value;
			m_lineNbr = lineNbr;
		}
	}
}
