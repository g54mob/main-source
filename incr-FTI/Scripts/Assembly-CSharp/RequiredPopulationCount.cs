public class RequiredPopulationCount : Requirement
{
	public float targetCount;

	private Town cachedTown;

	public RequiredPopulationCount(float count)
	{
		targetCount = count;
		cachedTown = GameManager.TownBeingLoaded;
	}

	public override Requirement GetCopy()
	{
		return new RequiredPopulationCount(targetCount);
	}

	public override bool IsMet()
	{
		return CurrentLevel() >= (double)targetCount;
	}

	public double CurrentLevel()
	{
		if (cachedTown != null)
		{
			return cachedTown.population;
		}
		return GameUtility.RoundToFloat(GameManager.Instance.activeTown.population);
	}
}
