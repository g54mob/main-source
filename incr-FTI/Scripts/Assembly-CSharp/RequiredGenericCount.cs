public class RequiredGenericCount : Requirement
{
	public delegate int CountDelegate();

	public EntityId imageItem;

	public readonly string tooltipLocalizationKey;

	public readonly CountDelegate countDelegate;

	public readonly int numRequired;

	public RequiredGenericCount(int targetCount, CountDelegate countDelegate, EntityId targetImageItem, string localizationKey)
	{
		this.countDelegate = countDelegate;
		imageItem = targetImageItem.GetCopy();
		tooltipLocalizationKey = localizationKey;
		numRequired = targetCount;
	}

	public override Requirement GetCopy()
	{
		return new RequiredGenericCount(numRequired, countDelegate, imageItem.GetCopy(), tooltipLocalizationKey);
	}

	public int CurrentCount()
	{
		if (countDelegate != null)
		{
			return countDelegate();
		}
		return 0;
	}

	public override bool IsMet()
	{
		return CurrentCount() >= numRequired;
	}
}
