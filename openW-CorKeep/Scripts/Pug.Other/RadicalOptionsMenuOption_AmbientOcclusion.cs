public class RadicalOptionsMenuOption_AmbientOcclusion : RadicalMenuOption
{
	private static string[] ssaoQualityLevels = new string[3] { "low", "medium", "high" };

	private void Start()
	{
		UpdateText(Manager.prefs.ssaoQuality);
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
		int num = Manager.prefs.ssaoQuality + amount;
		if (num < 0)
		{
			num = ssaoQualityLevels.Length - 1;
		}
		else if (num >= ssaoQualityLevels.Length)
		{
			num = 0;
		}
		Manager.prefs.ssaoQuality = num;
		UpdateText(num);
	}

	private void UpdateText(int quality)
	{
		if (quality >= ssaoQualityLevels.Length)
		{
			valueText.Clear();
		}
		else
		{
			valueText.Render(ssaoQualityLevels[quality]);
		}
	}
}
