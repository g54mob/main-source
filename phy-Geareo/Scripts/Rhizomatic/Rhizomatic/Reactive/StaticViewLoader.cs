namespace Rhizomatic.Reactive
{
	public class StaticViewLoader : ViewLoader
	{
		public bool _fetch;

		public View[] views;

		private bool hasSetup;

		private void Awake()
		{
		}

		private void Setup()
		{
		}

		private View GetView(IViewable viewable)
		{
			return null;
		}

		protected override View DoOpen(IViewable viewable)
		{
			return null;
		}

		protected override void DoClose(View view)
		{
		}

		protected override bool DoCanOpen(IViewable viewable)
		{
			return false;
		}

		private void OnValidate()
		{
		}
	}
}
