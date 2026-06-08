using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;

namespace GRP.Steam.Pages.NSWorkshop
{
	public class WorkshopSelfItemViewable : Viewable
	{
		[TextCrew]
		public string title;

		[ViewCrew(typeof(ImageUrlView))]
		public ImageUrlViewable image;

		public WorkshopItem item;

		public Context context;

		public WorkshopSelfItemViewable(Context context, WorkshopItem item)
		{
		}

		[CrewMethod]
		public void Edit()
		{
		}
	}
}
