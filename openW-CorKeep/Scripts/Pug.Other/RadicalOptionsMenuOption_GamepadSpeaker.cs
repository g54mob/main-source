public class RadicalOptionsMenuOption_GamepadSpeaker : RadicalPauseMenuOption
{
	private void Start()
	{
		UpdateText(Manager.prefs.gamepadSpeaker);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool flag = !Manager.prefs.gamepadSpeaker;
		Manager.prefs.gamepadSpeaker = flag;
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

	private void UpdateText(bool gamepadSpeakerEnabled)
	{
		valueText.Render(gamepadSpeakerEnabled ? "on" : "off");
	}

	public override bool IsOn()
	{
		return Manager.prefs.gamepadSpeaker;
	}
}
