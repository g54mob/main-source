namespace Rhizomatic.Reactive
{
	public class SingleViewLoader : ViewLoader
	{
		public ViewLoader viewLoader;

		public View view { get; private set; }

		public void CloseView()
		{
		}

		protected override bool DoCanOpen(IViewable viewable)
		{
			return false;
		}

		protected override View DoOpen(IViewable viewable)
		{
			return null;
		}

		protected override void DoClose(View view)
		{
		}
	}
}
