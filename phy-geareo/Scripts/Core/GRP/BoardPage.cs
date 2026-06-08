using Rhizomatic;

namespace GRP
{
	public abstract class BoardPage : Page
	{
		[ViewCrew(typeof(BoardView))]
		public BoardViewable board;

		public override void OnContext()
		{
		}
	}
}
