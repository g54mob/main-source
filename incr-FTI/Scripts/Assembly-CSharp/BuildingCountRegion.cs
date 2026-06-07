public class BuildingCountRegion : MenuButton
{
	public BuildingState loadedState;

	private int lastDisplayedCountHash;

	public bool CalcDisplayHashChange()
	{
		int num;
		if (loadedState == null)
		{
			num = 0;
		}
		else
		{
			num = 17;
			int num2 = GameUtility.AsTruncatedInt(loadedState.currentCount);
			num = 37 * num + num2;
			num = 37 * num + loadedState.pendingConstructions;
		}
		if (num != lastDisplayedCountHash)
		{
			lastDisplayedCountHash = num;
			return true;
		}
		return false;
	}
}
