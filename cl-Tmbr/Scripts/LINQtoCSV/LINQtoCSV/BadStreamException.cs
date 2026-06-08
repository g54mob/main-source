namespace LINQtoCSV
{
	public class BadStreamException : LINQtoCSVException
	{
		public BadStreamException()
			: base("Stream provided to Read is either null, or does not support Seek.")
		{
		}
	}
}
