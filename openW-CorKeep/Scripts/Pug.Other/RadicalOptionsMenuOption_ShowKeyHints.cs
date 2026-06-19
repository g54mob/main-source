public class RadicalOptionsMenuOption_ShowKeyHints : RadicalMenuOption
{
	private void Start()
	{
		UpdateText(Manager.prefs.showKeyHints);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool flag = !Manager.prefs.showKeyHints;
		Manager.prefs.showKeyHints = flag;
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
		return Manager.prefs.showKeyHints;
	}
}
