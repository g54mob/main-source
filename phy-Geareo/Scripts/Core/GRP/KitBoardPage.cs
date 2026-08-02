using GRP.Pages.NSKit;
using Rhizomatic;

namespace GRP
{
	public class KitBoardPage : BoardPage
	{
		[ViewCrew(typeof(KitView))]
		public KitViewable kit;

		public KitBoardPage(KitViewable kit)
		{
		}
	}
}
