using Rhizomatic;

namespace GRP
{
	public class BookPaper : Thing<BookPaperConfig>
	{
		public Book book;

		public BookHeader header;

		public int index;

		public void Setup(Book book, int index)
		{
		}

		public string GetHeaderText()
		{
			return null;
		}
	}
}
