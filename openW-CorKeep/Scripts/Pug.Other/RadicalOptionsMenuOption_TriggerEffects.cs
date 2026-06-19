public class RadicalOptionsMenuOption_TriggerEffects : RadicalPauseMenuOption
{
	private void Start()
	{
		UpdateText(Manager.prefs.triggerEffects);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool flag = !Manager.prefs.triggerEffects;
		Manager.prefs.triggerEffects = flag;
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

	private void UpdateText(bool settingEnabled)
	{
		valueText.Render(settingEnabled ? "on" : "off");
	}

	public override bool IsOn()
	{
		return Manager.prefs.triggerEffects;
	}
}
