public class RadicalOptionsMenuOption_ObjectShadows : RadicalMenuOption
{
	private static string[] options = new string[3] { "off", "low", "high" };

	private void Start()
	{
		UpdateText();
	}

	public override void OnActivated()
	{
		base.OnActivated();
		OnSkimRight();
	}

	public override bool OnSkimRight()
	{
		Manager.prefs.objectShadows = (Manager.prefs.objectShadows + 1 + options.Length) % options.Length;
		UpdateText();
		return true;
	}

	public override bool OnSkimLeft()
	{
		Manager.prefs.objectShadows = (Manager.prefs.objectShadows - 1 + options.Length) % options.Length;
		UpdateText();
		return true;
	}

	private void UpdateText()
	{
		valueText.Render(options[Manager.prefs.objectShadows]);
	}
}
