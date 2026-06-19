public class RadicalOptionsMenuOption_StreamerMode : RadicalMenuOption
{
	private void Start()
	{
		UpdateText(Manager.prefs.streamerMode);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool flag = !Manager.prefs.streamerMode;
		Manager.prefs.streamerMode = flag;
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
		valueText.Render(value ? "on" : "off");
	}

	public override bool IsOn()
	{
		return Manager.prefs.streamerMode;
	}
}
