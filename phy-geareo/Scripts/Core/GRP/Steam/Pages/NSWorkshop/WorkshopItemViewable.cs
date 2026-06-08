using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP.Steam.Pages.NSWorkshop
{
	public class WorkshopItemViewable : Viewable
	{
		[ViewCrew(typeof(ImageUrlView))]
		public ImageUrlViewable image;

		[GameObjectCrew]
		public StateSelector<bool> selected;

		public WorkshopItem item;

		public SteamWorkshopPage page;

		public WorkshopItemViewable(SteamWorkshopPage page, WorkshopItem item)
		{
		}

		[CrewMethod]
		public void Select()
		{
		}
	}
}
