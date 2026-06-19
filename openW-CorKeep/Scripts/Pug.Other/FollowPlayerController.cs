using UnityEngine;

public class FollowPlayerController : MonoBehaviour
{
	public bool followCameraIfManualCameraControl;

	private void LateUpdate()
	{
		if (followCameraIfManualCameraControl && Manager.camera.currentCameraStyle == CameraManager.CameraControlStyle.ManualControl)
		{
			base.transform.position = Manager.camera.gameCamera.transform.position + new Vector3(0f, -20f, 20f);
			return;
		}
		PlayerController player = Manager.main.player;
		if (player != null && player.gameObject.activeInHierarchy)
		{
			base.transform.position = player.transform.position;
		}
		else
		{
			base.transform.localPosition = Vector3.zero;
		}
	}
}
