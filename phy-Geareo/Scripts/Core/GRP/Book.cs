using Rhizomatic;

namespace GRP
{
	public class Book : Thing<BookConfig>
	{
		public BookHeader[] headers;

		public BookPaper[] papers;

		public override void OnContext()
		{
		}

		public BookHeader GetHeader(BookHeaderConfig header)
		{
			return null;
		}
	}
}
