namespace Rhizomatic.Reactive
{
	public class InstantiateViewLoader : ViewLoader
	{
		public PrefabContainer container;

		private bool started;

		private void Awake()
		{
		}

		private void OnDisable()
		{
		}

		private void SetupPrefabs()
		{
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
	}
}
