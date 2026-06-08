using UnityEngine;

public class TutorialWatcher_OnCameraRotated : TutorialWatcher
{
	[SerializeField]
	private float targetRotationDelta = 90f;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private float currentRotationDelta;

	private CameraRotator cameraRotator;

	public override void StartWatching()
	{
		cameraRotator = OverwritingSingleton<IngameUi>.Instance.cameraContainer.GetComponentInChildren<CameraRotator>();
		currentRotationDelta = 0f;
		cameraRotator.OnCameraRotated += AddRotationDelta;
	}

	private void AddRotationDelta(float rotationDelta)
	{
		if (inputRouter.GameState == GameState.Playing)
		{
			currentRotationDelta += Mathf.Abs(rotationDelta);
			if (currentRotationDelta >= targetRotationDelta)
			{
				cameraRotator.OnCameraRotated -= AddRotationDelta;
				ConditionFulfilled();
			}
		}
	}
}
