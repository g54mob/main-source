namespace Dhs5.Utility.Updates
{
	public interface IUpdaterOverrider
	{
		bool OverrideConditionFulfillment(EUpdateCondition condition, out bool fulfilled);
	}
}
