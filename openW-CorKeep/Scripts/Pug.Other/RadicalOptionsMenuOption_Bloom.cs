public class RadicalOptionsMenuOption_Bloom : RadicalMenuOption
{
	private static string[] options = new string[3] { "off", "reduced", "normal" };

	public override void OnParentMenuActivation()
	{
		SetLevel(Manager.prefs.bloom);
		UpdateText(Manager.prefs.bloom);
		base.OnParentMenuActivation();
	}

	public override void OnActivated()
	{
		base.OnActivated();
		OnSkimRight();
	}

	public override bool OnSkimRight()
	{
		ChangeLevel(-1);
		return true;
	}

	public override bool OnSkimLeft()
	{
		ChangeLevel(1);
		return true;
	}

	private void ChangeLevel(int amount)
	{
		SetLevel(Manager.prefs.bloom + amount);
		UpdateText(Manager.prefs.bloom);
	}

	private void SetLevel(int level)
	{
		Manager.prefs.bloom = (level + options.Length) % options.Length;
	}

	private void UpdateText(int value)
	{
		valueText.Render(options[value]);
	}
}
