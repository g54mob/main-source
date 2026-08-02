using UnityEngine;

public class TSAnimationEvent : MonoBehaviour
{
	public FishingRodController fishingRodController;

	public void SetActiveFishingRod(FishingRodController rod)
	{
		fishingRodController = rod;
	}

	public void ClearActiveFishingRod(FishingRodController rod)
	{
		if (fishingRodController == rod)
		{
			fishingRodController = null;
		}
	}

	public void ThrowFishingRod()
	{
		if (fishingRodController != null)
		{
			fishingRodController.ExecuteThrow();
		}
	}

	public void PickAxeHit()
	{
	}
}
