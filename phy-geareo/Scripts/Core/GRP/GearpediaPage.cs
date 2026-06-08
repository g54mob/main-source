using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP
{
	public class GearpediaPage : Page
	{
		[ViewCrew(typeof(BookView))]
		public BookViewable book;

		public GearpediaPage(Book book)
		{
		}

		[CrewMethod]
		public void Close()
		{
		}
	}
}
