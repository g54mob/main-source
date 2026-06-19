public class RadicalOptionsMenuOption_Reflections : RadicalMenuOption
{
	private bool _isOn;

	private void Start()
	{
		UpdateText(Manager.prefs.reflections);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		Manager.prefs.reflections = !Manager.prefs.reflections;
		UpdateText(Manager.prefs.reflections);
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

	private void UpdateText(bool isOn)
	{
		_isOn = isOn;
		valueText.Render(isOn ? "on" : "off");
	}

	public override bool IsOn()
	{
		return _isOn;
	}
}
