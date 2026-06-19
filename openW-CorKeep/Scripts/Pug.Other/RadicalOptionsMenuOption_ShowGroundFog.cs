public class RadicalOptionsMenuOption_ShowGroundFog : RadicalMenuOption
{
	private void Start()
	{
		UpdateText(Manager.prefs.ShowGroundFog);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool flag = !Manager.prefs.ShowGroundFog;
		Manager.prefs.ShowGroundFog = flag;
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
		return Manager.prefs.ShowGroundFog;
	}
}
