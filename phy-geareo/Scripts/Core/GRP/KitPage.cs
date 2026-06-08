using GRP.Pages.NSKit;
using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP
{
	public class KitPage : Page
	{
		[ViewCrew(typeof(KitView))]
		public KitViewable kit;

		public KitPage(KitViewable kit)
		{
		}

		[CrewMethod]
		public void Back()
		{
		}
	}
}
