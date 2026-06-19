public class RadicalOptionsMenuOption_FishingMiniGameOption : RadicalPauseMenuOption
{
	private void Start()
	{
		UpdateText(Manager.prefs.fishingMiniGameEnabled);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool fishingMiniGameEnabled = !Manager.prefs.fishingMiniGameEnabled;
		Manager.prefs.fishingMiniGameEnabled = fishingMiniGameEnabled;
		UpdateText(fishingMiniGameEnabled);
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

	private void UpdateText(bool fishingMiniGameEnabled)
	{
		valueText.Render(fishingMiniGameEnabled ? "on" : "off");
	}

	public override bool IsOn()
	{
		return Manager.prefs.fishingMiniGameEnabled;
	}
}
