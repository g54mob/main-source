public class ProgressValueQuest : ProgressValueCounter
{
	public RequirementType requirementType;

	public ItemType rewardItem;

	public int rewardAmount;

	public override string ToString()
	{
		return $"{requirementType} + {rewardItem} + {rewardAmount} + {progressType} + {base.currentValue} + {maxValue}";
	}
}
