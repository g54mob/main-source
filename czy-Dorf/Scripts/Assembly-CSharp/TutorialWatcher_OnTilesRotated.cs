using UnityEngine;

public class TutorialWatcher_OnTilesRotated : TutorialWatcher
{
	[SerializeField]
	private int targetRotationCount = 5;

	[SerializeField]
	private int currentRotationCount;

	[SerializeField]
	private InputRouter inputRouter;

	public override void StartWatching()
	{
		currentRotationCount = 0;
		inputRouter.OnRotatePreviewTile += RotatePreviewTile;
	}

	private void RotatePreviewTile(int obj)
	{
		currentRotationCount++;
		if (currentRotationCount >= targetRotationCount)
		{
			ConditionFulfilled();
		}
	}
}
