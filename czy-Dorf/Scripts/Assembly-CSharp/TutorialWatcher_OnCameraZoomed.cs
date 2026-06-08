using UnityEngine;

public class TutorialWatcher_OnCameraZoomed : TutorialWatcher
{
	[SerializeField]
	private float targetZoomDelta = 3f;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private float currentZoomDelta;

	private CameraZoom cameraZoom;

	public override void StartWatching()
	{
		cameraZoom = OverwritingSingleton<IngameUi>.Instance.cameraContainer.GetComponentInChildren<CameraZoom>();
		currentZoomDelta = 0f;
		cameraZoom.OnCameraZoomed += AddZoomDelta;
	}

	private void AddZoomDelta(float zoomDelta)
	{
		if (inputRouter.GameState == GameState.Playing)
		{
			currentZoomDelta += Mathf.Abs(zoomDelta);
			if (currentZoomDelta >= targetZoomDelta)
			{
				cameraZoom.OnCameraZoomed -= AddZoomDelta;
				ConditionFulfilled();
			}
		}
	}
}
