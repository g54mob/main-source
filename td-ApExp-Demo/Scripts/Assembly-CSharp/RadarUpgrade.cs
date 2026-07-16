public class RadarUpgrade
{
	public EnhancementRadar upgrade;

	private bool isApplied;

	public bool isBought;

	public bool IsApplied
	{
		get
		{
			return isApplied;
		}
		set
		{
			if (value != isApplied)
			{
				isApplied = value;
				if (isApplied)
				{
					upgrade.OnApplied();
				}
				else
				{
					upgrade.OnRemoved();
				}
			}
		}
	}

	public RadarUpgrade(EnhancementRadar radarUp)
	{
		upgrade = radarUp;
	}
}
