using GRP.Steam.Pages.NSWorkshop;
using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP.Steam
{
	public class SteamWorkshopPage : Page
	{
		[ViewCrew(typeof(WorkshopItemsLoaderView))]
		public WorkshopItemsLoaderViewable itemsLoader;

		[GameObjectCrew]
		public StateSelector<bool> isSelected;

		[GameObjectCrew]
		public StateSelector<bool> notSelected;

		[ViewCrew(typeof(WorkshopItemPanelView))]
		public StateSelector<WorkshopItemPanelViewable> panel;

		public State<WorkshopItemViewable> selectedItem;

		public WorkshopItemsLoader loader;

		public override void OnContext()
		{
		}

		public void ToggleItem(WorkshopItemViewable item)
		{
		}

		[CrewMethod]
		public void Self()
		{
		}

		[CrewMethod]
		public void Explore()
		{
		}

		[CrewMethod]
		public void Close()
		{
		}
	}
}
