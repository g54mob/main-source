public class RadicalOptionsMenuOption_FaceMouseDirection : RadicalPauseMenuOption
{
	private void Start()
	{
		UpdateText(Manager.prefs.faceMouseDirection);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		bool faceMouseDirection = !Manager.prefs.faceMouseDirection;
		Manager.prefs.faceMouseDirection = faceMouseDirection;
		UpdateText(faceMouseDirection);
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

	private void UpdateText(bool faceMouseDirection)
	{
		valueText.Render(faceMouseDirection ? "on" : "off");
	}

	public override bool IsOn()
	{
		return Manager.prefs.faceMouseDirection;
	}
}
