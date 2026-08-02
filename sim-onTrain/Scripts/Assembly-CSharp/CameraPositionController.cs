using DG.Tweening;
using HQFPSTemplate;
using UnityEngine;

public class CameraPositionController : MonoBehaviour
{
	public Vector3 defaultPos;

	public Vector3 defaultRot;

	public Vector3 sleepPos;

	public Vector3 sleepRot;

	public Transform playerBodyTarget;

	public Transform deathCamPos;

	public Transform worldCamera;

	public Camera fpsCamera;

	private CameraPhysicsHandler cameraPhysicsHandler;

	public PlayerCamera playerCamera;

	public PlayerDeathCamera freeCamera;

	public Vector3 freeCameraDefaultPos;

	private void Start()
	{
		cameraPhysicsHandler = GetComponentInChildren<CameraPhysicsHandler>();
		if (freeCamera == null)
		{
			freeCamera = GetComponent<PlayerDeathCamera>();
		}
		if (freeCamera != null && playerBodyTarget != null)
		{
			freeCamera.playerBodyTarget = playerBodyTarget;
		}
	}

	public void Sleep()
	{
		if (fpsCamera != null)
		{
			fpsCamera.enabled = false;
		}
		if (playerCamera != null)
		{
			playerCamera.enabled = false;
		}
		if (freeCamera != null)
		{
			if (playerBodyTarget != null)
			{
				freeCamera.playerBodyTarget = playerBodyTarget;
			}
			freeCamera.enabled = true;
		}
		base.transform.DOLocalMove(sleepPos, 0.3f);
		base.transform.DOLocalRotate(sleepRot, 0.3f);
	}

	public void DeatchCamera()
	{
		if (fpsCamera != null)
		{
			fpsCamera.enabled = false;
		}
		if (playerCamera != null)
		{
			playerCamera.enabled = false;
		}
		if (freeCamera != null)
		{
			if (playerBodyTarget != null)
			{
				freeCamera.playerBodyTarget = playerBodyTarget;
			}
			freeCamera.enabled = true;
		}
		cameraPhysicsHandler.enabled = false;
		cameraPhysicsHandler.DisableCameraPhysics();
		base.transform.DOLocalMove(deathCamPos.localPosition, 0.8f);
		base.transform.DOLocalRotate(deathCamPos.localEulerAngles, 0.8f);
	}

	public void ResetCameraPos()
	{
		if (fpsCamera != null)
		{
			fpsCamera.enabled = true;
		}
		if (playerCamera != null)
		{
			playerCamera.enabled = true;
		}
		if (freeCamera != null)
		{
			freeCamera.enabled = false;
		}
		base.transform.localPosition = defaultPos;
		base.transform.localEulerAngles = defaultRot;
		freeCamera.transform.localPosition = freeCameraDefaultPos;
		freeCamera.transform.localEulerAngles = Vector3.zero;
		HQFPSTemplate.Player componentInParent = GetComponentInParent<HQFPSTemplate.Player>();
		if (componentInParent != null)
		{
			componentInParent.Respawn.Send();
		}
		cameraPhysicsHandler.enabled = true;
		DOVirtual.DelayedCall(0.2f, delegate
		{
			cameraPhysicsHandler.EnableCameraPhysics();
		});
	}
}
