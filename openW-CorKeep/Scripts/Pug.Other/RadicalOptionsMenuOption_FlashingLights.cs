public class RadicalOptionsMenuOption_FlashingLights : RadicalPauseMenuOption
{
	private void Start()
	{
		UpdateText(Manager.prefs.flashingLights);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool flag = !Manager.prefs.flashingLights;
		Manager.prefs.flashingLights = flag;
		UpdateText(flag);
	}

	public override bool OnSkimRight()
	{
		return OnSkimLeft();
	}

	public override bool OnSkimLeft()
	{
		OnActivated();
		return true;
	}

	private void UpdateText(bool flashingEnabled)
	{
		valueText.Render(flashingEnabled ? "on" : "off");
	}

	public override bool IsOn()
	{
		return Manager.prefs.flashingLights;
	}
}
