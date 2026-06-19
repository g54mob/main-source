public class RadicalOptionsMenuOption_DynamicWater : RadicalMenuOption
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
		Manager.prefs.dynamicWater = (Manager.prefs.dynamicWater + 1 + options.Length) % options.Length;
		UpdateText();
		return true;
	}

	public override bool OnSkimLeft()
	{
		Manager.prefs.dynamicWater = (Manager.prefs.dynamicWater - 1 + options.Length) % options.Length;
		UpdateText();
		return true;
	}

	private void UpdateText()
	{
		valueText.Render(options[Manager.prefs.dynamicWater]);
	}
}
