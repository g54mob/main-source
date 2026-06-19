public class RadicalOptionsMenuOption_Tutorial : RadicalPauseMenuOption
{
	private void Start()
	{
		UpdateText(Manager.prefs.enableTutorial);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool enableTutorial = !Manager.prefs.enableTutorial;
		Manager.prefs.enableTutorial = enableTutorial;
		UpdateText(enableTutorial);
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

	private void UpdateText(bool enableTutorial)
	{
		valueText.Render(enableTutorial ? "on" : "off");
	}

	public override bool IsOn()
	{
		return Manager.prefs.enableTutorial;
	}
}
