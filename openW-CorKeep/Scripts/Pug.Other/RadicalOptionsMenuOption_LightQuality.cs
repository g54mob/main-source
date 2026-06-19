public class RadicalOptionsMenuOption_LightQuality : RadicalMenuOption
{
	private static string[] lightQualityLevels = new string[4] { "low", "medium", "high", "veryHigh" };

	private void Start()
	{
		UpdateText(Manager.prefs.lightQuality);
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
		int num = Manager.prefs.lightQuality + amount;
		if (num < 0)
		{
			num = lightQualityLevels.Length - 1;
		}
		else if (num >= lightQualityLevels.Length)
		{
			num = 0;
		}
		Manager.prefs.lightQuality = num;
		UpdateText(num);
	}

	private void UpdateText(int lightQuality)
	{
		if (lightQuality >= lightQualityLevels.Length)
		{
			valueText.Clear();
		}
		else
		{
			valueText.Render(lightQualityLevels[lightQuality]);
		}
	}
}
