using System.Collections.Generic;

public class BaseGlobalInfo
{
	public int TotalExecutionCount;

	public int TotalGarbageOut;

	public int StabilityLevel;

	public int EvilExplosionCount;

	public int TotalEvilCount;

	public bool HasSpawnBook;

	public const int INITIAL_STABILITY = 150;

	public const int STABILITY_DELTA = 500;

	public virtual bool CanBuild()
	{
		return false;
	}

	public virtual int MaxBuilding()
	{
		return 0;
	}

	public int GetMaxStability()
	{
		if (StabilityLevel == 0)
		{
			return 150;
		}
		return StabilityLevel * 500;
	}

	public virtual List<BaseSavableAttribute> GetStaticAttributes()
	{
		return new List<BaseSavableAttribute>();
	}

	public void Reset()
	{
		TotalExecutionCount = 0;
		TotalGarbageOut = 0;
		StabilityLevel = 0;
		foreach (BaseSavableAttribute staticAttribute in GetStaticAttributes())
		{
			staticAttribute.Reset();
		}
	}

	public virtual bool CanLowerCost()
	{
		return false;
	}

	public bool CanHighlightDevice()
	{
		if (!Installation.IsDemo() && (HasSpawnBook || TotalEvilCount > 0))
		{
			return true;
		}
		return false;
	}
}
