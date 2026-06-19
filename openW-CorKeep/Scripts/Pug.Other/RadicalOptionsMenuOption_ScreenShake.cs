public class RadicalOptionsMenuOption_ScreenShake : RadicalPauseMenuOption
{
	private void Start()
	{
		UpdateText(Manager.prefs.screenShakes);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool flag = !Manager.prefs.screenShakes;
		Manager.prefs.screenShakes = flag;
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

	private void UpdateText(bool screenShakeEnabled)
	{
		valueText.Render(screenShakeEnabled ? "on" : "off");
	}

	public override bool IsOn()
	{
		return Manager.prefs.screenShakes;
	}
}
