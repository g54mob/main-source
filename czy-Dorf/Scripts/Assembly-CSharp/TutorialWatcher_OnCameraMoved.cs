using UnityEngine;

public class TutorialWatcher_OnCameraMoved : TutorialWatcher
{
	[SerializeField]
	private float targetMovementDelta;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private float movementDelta;

	private CameraMovement cameraMovement;

	public override void StartWatching()
	{
		cameraMovement = OverwritingSingleton<IngameUi>.Instance.cameraContainer.GetComponentInChildren<CameraMovement>();
		movementDelta = 0f;
		cameraMovement.OnCameraMoved += AddMovementDelta;
	}

	private void AddMovementDelta(Vector2 worldMovementDelta, bool movedByPlayer)
	{
		if (inputRouter.GameState == GameState.Playing)
		{
			movementDelta += worldMovementDelta.magnitude;
			if (movementDelta >= targetMovementDelta)
			{
				cameraMovement.OnCameraMoved -= AddMovementDelta;
				ConditionFulfilled();
			}
		}
	}
}
