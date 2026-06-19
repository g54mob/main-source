public class RadicalOptionsMenuOption_ColorRange : RadicalMenuOption
{
	private static string[] options = new string[3] { "24bit", "15bit", "15bitDither" };

	public override void OnParentMenuActivation()
	{
		SetLevel(Manager.prefs.colorRange);
		base.OnParentMenuActivation();
	}

	public override void OnActivated()
	{
		base.OnActivated();
		OnSkimRight();
	}

	public override bool OnSkimRight()
	{
		ChangeLevel(1);
		return true;
	}

	public override bool OnSkimLeft()
	{
		ChangeLevel(-1);
		return true;
	}

	private void ChangeLevel(int amount)
	{
		SetLevel(Manager.prefs.colorRange + amount);
	}

	private void SetLevel(int level)
	{
		Manager.prefs.colorRange = (level + options.Length) % options.Length;
		UpdateText(Manager.prefs.colorRange);
	}

	private void UpdateText(int value)
	{
		valueText.Render(options[value]);
	}
}
