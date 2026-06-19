namespace Rewired.UI.ControlMapper.PugUI.Menu.Options
{
	public class RadicalOptionsMenuOption_ResetUserPrefs : RadicalMenuOption
	{
		protected override void Awake()
		{
			base.Awake();
		}

		public override void OnActivated()
		{
			Manager.prefs.ResetToDefaults();
			base.OnActivated();
		}
	}
}
