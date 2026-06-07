using UnityEngine;

public class LandmarkActionSalvageableUnlockable : LandmarkUnlockable
{
	[SerializeField]
	private LandmarkSalvageableCategory _category;

	public bool Initialize(LandmarkActionSalvage.Category category)
	{
		if (category.CategoryAsset != _category)
		{
			return false;
		}
		if (category.Unlocked)
		{
			InitializeUnlocked();
		}
		else
		{
			InitializeLocked();
		}
		return true;
	}
}
