public class RadicalOptionsMenuOption_ShowMinimap : RadicalMenuOption
{
	private void Start()
	{
		UpdateText(Manager.prefs.showMinimap);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool flag = !Manager.prefs.showMinimap;
		Manager.prefs.showMinimap = flag;
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
		return Manager.prefs.showMinimap;
	}
}
