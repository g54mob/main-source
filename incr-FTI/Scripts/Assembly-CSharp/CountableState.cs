public class CountableState
{
	public double currentCount;

	public double maxCount;

	public double minCount;

	public double numAvailable;

	public Town parentTown;

	public bool debugFlag;

	protected static GameManager gm => GameManager.Instance;

	public void TryAdd(float amount)
	{
		currentCount += amount;
		if (currentCount > maxCount)
		{
			currentCount = maxCount;
		}
	}

	public void Fill()
	{
		currentCount = maxCount;
	}

	public void Subtract(double amount)
	{
		currentCount -= amount;
		if (currentCount < minCount)
		{
			currentCount = minCount;
		}
	}

	public double Capacity()
	{
		if (this is BuildingState buildingState)
		{
			return buildingState.currentCount * (double)buildingState.WorkerCapacityPerBuilding();
		}
		return numAvailable;
	}

	public virtual void AssignMaxCapacity()
	{
		maxCount = DefaultCapacity();
	}

	public virtual double DefaultCapacity()
	{
		return 10.0;
	}

	public virtual void Reset()
	{
		currentCount = 0.0;
		AssignMaxCapacity();
	}

	public virtual EntityId AsEntity()
	{
		return EntityId.None;
	}
}
