public class RadicalOptionsMenuOption_16Colors : RadicalMenuOption
{
	private void Start()
	{
		UpdateText(Manager.prefs.limitColors);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool flag = !Manager.prefs.limitColors;
		Manager.prefs.limitColors = flag;
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

	private void UpdateText(bool vsyncEnabled)
	{
		valueText.Render(vsyncEnabled ? "on" : "off");
	}

	public override bool IsOn()
	{
		return Manager.prefs.limitColors;
	}
}
