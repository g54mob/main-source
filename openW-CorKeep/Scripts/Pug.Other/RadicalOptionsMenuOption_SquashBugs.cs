public class RadicalOptionsMenuOption_SquashBugs : RadicalPauseMenuOption
{
	private void Start()
	{
		UpdateText(Manager.prefs.squashBugs);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool squashBugs = !Manager.prefs.squashBugs;
		Manager.prefs.squashBugs = squashBugs;
		UpdateText(squashBugs);
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

	private void UpdateText(bool squashBugs)
	{
		valueText.Render(squashBugs ? "on" : "off");
	}

	public override bool IsOn()
	{
		return Manager.prefs.squashBugs;
	}
}
