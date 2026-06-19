public class RadicalOptionsMenuOption_Vsync : RadicalMenuOption
{
	public RadicalOptionsMenuOption_TargetFrameRate targetFrameRateOption;

	private void Start()
	{
		UpdateText(Manager.prefs.vsync);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool flag = !Manager.prefs.vsync;
		Manager.prefs.vsync = flag;
		UpdateText(flag);
		targetFrameRateOption.labelText.ResetEffects();
		targetFrameRateOption.valueText.ResetEffects();
		targetFrameRateOption.UpdateText(Manager.prefs.targetFrameRate);
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

	private void UpdateText(bool vsyncEnabled)
	{
		valueText.Render(vsyncEnabled ? "on" : "off");
	}

	public override bool IsOn()
	{
		return Manager.prefs.vsync;
	}
}
