public class RadicalOptionsMenuOption_ShowCharacterNames : RadicalMenuOption
{
	private void Start()
	{
		UpdateText(Manager.prefs.showCharacterNames);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool flag = !Manager.prefs.showCharacterNames;
		Manager.prefs.showCharacterNames = flag;
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
		return Manager.prefs.showCharacterNames;
	}
}
