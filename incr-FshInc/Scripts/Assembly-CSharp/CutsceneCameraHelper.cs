using UnityEngine;

public class CutsceneCameraHelper : MonoBehaviour
{
	[Header("Targets")]
	[Tooltip("The primary object you want the camera to look at (e.g. the Boat)")]
	public Transform targetObject;

	[Tooltip("An optional secondary target for complex scenes (e.g. the Kraken)")]
	public Transform secondaryTargetObject;

	[Tooltip("The orthographic size to zoom to during tracking cutscenes (default: 3)")]
	public float targetZoom = 3f;

	public void ZoomToTarget()
	{
		ZoomToSpecificTarget(targetObject);
	}

	public void TrackAndZoomTarget()
	{
		TrackAndZoomSpecificTarget(targetObject);
	}

	public void PanToTarget()
	{
		PanToSpecificTarget(targetObject);
	}

	public void ZoomToSecondaryTarget()
	{
		ZoomToSpecificTarget(secondaryTargetObject);
	}

	public void TrackAndZoomSecondaryTarget()
	{
		TrackAndZoomSpecificTarget(secondaryTargetObject);
	}

	public void PanToSecondaryTarget()
	{
		PanToSpecificTarget(secondaryTargetObject);
	}

	public void ZoomToSpecificTarget(Transform specificTarget)
	{
		if (CameraController.Instance != null && specificTarget != null)
		{
			CameraController.Instance.ZoomToTarget(specificTarget.position);
			Debug.Log("[CutsceneCameraHelper] Zooming camera to " + specificTarget.name);
		}
	}

	public void TrackAndZoomSpecificTarget(Transform specificTarget)
	{
		if (CameraController.Instance != null && specificTarget != null)
		{
			CameraController.Instance.StartTrackingAndZoom(specificTarget, targetZoom);
			Debug.Log($"[CutsceneCameraHelper] Tracking and zooming camera on {specificTarget.name} to size {targetZoom}");
		}
	}

	public void PanToSpecificTarget(Transform specificTarget)
	{
		if (CameraController.Instance != null && specificTarget != null)
		{
			CameraController.Instance.PanTowards(specificTarget.position);
			Debug.Log("[CutsceneCameraHelper] Panning camera to " + specificTarget.name);
		}
	}

	public void ResetCamera()
	{
		if (CameraController.Instance != null)
		{
			CameraController.Instance.ResetZoom();
			Debug.Log("[CutsceneCameraHelper] Resetting camera zoom/pan.");
		}
	}

	[Tooltip("Shows cinematic black bars at top and bottom of screen. (Slides in)")]
	public void ShowCinematicBars()
	{
		if (CutsceneManager.Instance != null)
		{
			CutsceneManager.Instance.ShowCinematicBars();
		}
	}

	[Tooltip("Hides cinematic black bars. (Slides out)")]
	public void HideCinematicBars()
	{
		if (CutsceneManager.Instance != null)
		{
			CutsceneManager.Instance.HideCinematicBars();
		}
	}
}
