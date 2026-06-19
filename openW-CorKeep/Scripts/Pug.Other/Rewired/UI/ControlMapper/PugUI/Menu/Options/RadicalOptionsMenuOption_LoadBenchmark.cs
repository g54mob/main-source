namespace Rewired.UI.ControlMapper.PugUI.Menu.Options
{
	public class RadicalOptionsMenuOption_LoadBenchmark : RadicalMenuOption
	{
		protected override void Awake()
		{
			base.Awake();
		}

		public override void OnActivated()
		{
			base.OnActivated();
			Manager.load.LoadBenchmarkScene();
		}
	}
}
