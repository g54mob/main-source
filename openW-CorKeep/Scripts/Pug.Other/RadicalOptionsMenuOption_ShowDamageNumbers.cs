public class RadicalOptionsMenuOption_ShowDamageNumbers : RadicalMenuOption
{
	private void Start()
	{
		UpdateText(Manager.prefs.showDamageNumbers);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool flag = !Manager.prefs.showDamageNumbers;
		Manager.prefs.showDamageNumbers = flag;
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
		return Manager.prefs.showDamageNumbers;
	}
}
