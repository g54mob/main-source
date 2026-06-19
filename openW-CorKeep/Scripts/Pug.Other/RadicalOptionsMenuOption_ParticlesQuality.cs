public class RadicalOptionsMenuOption_ParticlesQuality : RadicalMenuOption
{
	private static string[] particleQualityLevels = new string[2] { "low", "high" };

	private void Start()
	{
		UpdateText(Manager.prefs.particleQuality);
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
		int num = Manager.prefs.particleQuality + amount;
		if (num < 0)
		{
			num = particleQualityLevels.Length - 1;
		}
		else if (num >= particleQualityLevels.Length)
		{
			num = 0;
		}
		Manager.prefs.particleQuality = num;
		if (Manager.multiMap != null)
		{
			Manager.multiMap.ResetParticles();
		}
		UpdateText(num);
	}

	private void UpdateText(int particleQuality)
	{
		if (particleQuality >= particleQualityLevels.Length)
		{
			valueText.Clear();
		}
		else
		{
			valueText.Render(particleQualityLevels[particleQuality]);
		}
	}
}
