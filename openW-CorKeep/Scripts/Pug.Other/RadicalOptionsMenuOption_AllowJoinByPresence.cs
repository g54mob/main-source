public class RadicalOptionsMenuOption_AllowJoinByPresence : RadicalMenuOption
{
	private void Start()
	{
		UpdateText(Manager.prefs.allowJoinByPresence);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool flag = !Manager.prefs.allowJoinByPresence;
		Manager.prefs.allowJoinByPresence = flag;
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
		return Manager.prefs.allowJoinByPresence;
	}
}
