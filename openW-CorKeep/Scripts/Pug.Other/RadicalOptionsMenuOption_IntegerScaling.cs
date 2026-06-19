public class RadicalOptionsMenuOption_IntegerScaling : RadicalMenuOption
{
	public RadicalOptionsMenuOption_CRTFilter crtFilterOption;

	private void Start()
	{
		UpdateText(Manager.prefs.integerScaling);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool flag = !Manager.prefs.integerScaling;
		Manager.prefs.integerScaling = flag;
		UpdateText(flag);
		crtFilterOption.labelText.ResetEffects();
		crtFilterOption.valueText.ResetEffects();
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
		return Manager.prefs.integerScaling;
	}
}
