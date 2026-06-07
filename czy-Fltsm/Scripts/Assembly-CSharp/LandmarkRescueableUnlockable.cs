public class LandmarkRescueableUnlockable : LandmarkUnlockable
{
	public void Initialize(LandmarkActionRescue.Rescueable rescueable)
	{
		if (rescueable.Unlocked)
		{
			InitializeUnlocked();
		}
		else
		{
			InitializeLocked();
		}
	}
}
