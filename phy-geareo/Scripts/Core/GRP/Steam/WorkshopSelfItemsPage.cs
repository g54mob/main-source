using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP.Steam
{
	public class WorkshopSelfItemsPage : Page
	{
		[ViewCrew(typeof(WorkshopItemsLoaderView))]
		public WorkshopItemsLoaderViewable itemsLoader;

		public WorkshopItemsLoader loader;

		public override void OnContext()
		{
		}

		[CrewMethod]
		public void CreateNew()
		{
		}

		[CrewMethod]
		public void Close()
		{
		}
	}
}
