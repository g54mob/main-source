public class RadicalOptionsMenuOption_ShadowQuality : RadicalMenuOption
{
	private static string[] shadowQualityLevels = new string[4] { "low", "medium", "high", "veryHigh" };

	private void Start()
	{
		UpdateText(Manager.prefs.shadowQuality);
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
		int num = Manager.prefs.shadowQuality + amount;
		if (num < 0)
		{
			num = shadowQualityLevels.Length - 1;
		}
		else if (num >= shadowQualityLevels.Length)
		{
			num = 0;
		}
		Manager.prefs.shadowQuality = num;
		UpdateText(num);
	}

	private void UpdateText(int shadowQuality)
	{
		if (shadowQuality >= shadowQualityLevels.Length)
		{
			valueText.Clear();
		}
		else
		{
			valueText.Render(shadowQualityLevels[shadowQuality]);
		}
	}
}
