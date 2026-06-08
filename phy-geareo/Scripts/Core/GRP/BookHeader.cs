using Rhizomatic;

namespace GRP
{
	public class BookHeader : Thing<BookHeaderConfig>
	{
		public Book book;

		public BookHeader parent;

		public void Setup(Book book)
		{
		}

		public string GetFullText()
		{
			return null;
		}
	}
}
