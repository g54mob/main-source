public class RadicalOptionsMenuOption_ShowHotbarKeyboardNumbers : RadicalMenuOption
{
	private void Start()
	{
		UpdateText(Manager.prefs.ShowHotbarKeyboardNumbers);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool flag = !Manager.prefs.ShowHotbarKeyboardNumbers;
		Manager.prefs.ShowHotbarKeyboardNumbers = flag;
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
		return Manager.prefs.ShowHotbarKeyboardNumbers;
	}
}
