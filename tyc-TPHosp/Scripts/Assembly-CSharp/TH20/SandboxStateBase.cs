namespace TH20
{
	public class SandboxStateBase : MetagameState
	{
		private App _app;

		public SandboxStateBase(App app, MetagameMap map)
			: base(map)
		{
			_app = app;
		}

		public override void Destroy()
		{
			SandboxSaveManager.CurrentSettings = null;
			base.Destroy();
		}

		public override void Update()
		{
			if (MetagameMap.IsReadyToStart)
			{
				PushState(new SandboxStatePlayer(_app, MetagameMap));
			}
		}
	}
}
