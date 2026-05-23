using UnityEngine;

public class ForceCameraPosOnEnable : MonoBehaviour
{
	[SerializeField]
	private CameraRig cameraRig;

	[SerializeField]
	private Transform forcedPosition;

	[SerializeField]
	private float duration;

	[SerializeField]
	private float forceZoom = 1f;

	private void Update()
	{
		if (duration >= 0f)
		{
			cameraRig.overrideCameraTarget = forcedPosition;
			duration -= Time.deltaTime;
			cameraRig.overrideZoom = forceZoom;
		}
		else
		{
			cameraRig.overrideZoom = -1f;
			cameraRig.overrideCameraTarget = null;
			Object.Destroy(this);
		}
	}
}
