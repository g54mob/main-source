public class RadicalOptionsMenuOption_ShowInGameUI : RadicalMenuOption
{
	private void Start()
	{
		UpdateText(Manager.prefs.hideInGameUI);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool flag = !Manager.prefs.hideInGameUI;
		Manager.prefs.hideInGameUI = flag;
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

	private void UpdateText(bool value)
	{
		valueText.Render((!value) ? "on" : "off");
	}

	public override bool IsOn()
	{
		return !Manager.prefs.hideInGameUI;
	}
}
