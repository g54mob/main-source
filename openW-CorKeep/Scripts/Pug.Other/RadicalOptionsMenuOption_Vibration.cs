public class RadicalOptionsMenuOption_Vibration : RadicalOptionsMenuOption_TextToggle
{
	public override bool IsOn
	{
		get
		{
			return Manager.prefs.vibration;
		}
		protected set
		{
			Manager.prefs.vibration = value;
		}
	}

	public override void OnActivated()
	{
		base.OnActivated();
		Manager.input.singleplayerInputModule.RumbleNow();
	}
}
