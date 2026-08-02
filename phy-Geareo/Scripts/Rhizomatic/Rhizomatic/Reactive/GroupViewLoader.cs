namespace Rhizomatic.Reactive
{
	public class GroupViewLoader : ViewLoader
	{
		public ViewLoader[] viewLoaders;

		protected override bool DoCanOpen(IViewable viewable)
		{
			return false;
		}

		protected override void DoClose(View view)
		{
		}

		protected override View DoOpen(IViewable viewable)
		{
			return null;
		}
	}
}
