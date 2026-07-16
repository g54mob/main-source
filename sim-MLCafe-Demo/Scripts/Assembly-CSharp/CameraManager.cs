using UnityEngine;

public class CameraManager : MonoBehaviour
{
	public enum ActiveCameraState
	{
		PlayerCamera = 0,
		DarkRoomCamera = 1
	}

	[SerializeField]
	private CameraController cameraController;

	public Camera activeCamera;

	public CameraController activeCameraController;

	public ActiveCameraState activeCameraState;

	private static CameraManager instance;

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		GlobalReferences.OnRefreshReferences.AddListener(InitCamera);
		InitCamera();
	}

	public void InitCamera()
	{
		SwitchActiveCameraController(ActiveCameraState.PlayerCamera);
	}

	public static Camera GetActiveCamera()
	{
		return instance.activeCamera;
	}

	public static CameraController GetActiveCameraController()
	{
		return instance.activeCameraController;
	}

	[ContextMenu("SwitchToPlayer")]
	private void SwitchToPlayerCam()
	{
		SwitchActiveCameraController(ActiveCameraState.PlayerCamera);
	}

	[ContextMenu("SwitchToDarkRoom")]
	private void SwitchToDarkRoomCam()
	{
		SwitchActiveCameraController(ActiveCameraState.DarkRoomCamera);
	}

	public static void SwitchActiveCameraController(ActiveCameraState state)
	{
		DisableActiveCamera();
		instance.activeCameraState = state;
		switch (state)
		{
		case ActiveCameraState.PlayerCamera:
			SetPlayerCameraActive();
			break;
		case ActiveCameraState.DarkRoomCamera:
			SetDarkRoomCameraActive();
			break;
		}
		instance.activeCameraController.Activate();
	}

	public static void SetPlayerCameraActive()
	{
		if (GlobalReferences.IsValidated())
		{
			if (GlobalReferences.GetCameraController() != null)
			{
				GlobalReferences.GetCameraController().gameObject.SetActive(value: true);
				instance.activeCameraController = GlobalReferences.GetCameraController();
				instance.activeCamera = instance.activeCameraController.GetCamera();
			}
			if (GlobalReferences.GetCharacterController() != null)
			{
				GlobalReferences.GetCharacterController().gameObject.SetActive(value: true);
				GlobalReferences.GetCharacterController().ActivateCharacterInteraction();
			}
			if (RayCaster.IsValidated())
			{
				RayCaster.Activate();
			}
			if (MouseCursorInteraction.IsValidated())
			{
				MouseCursorInteraction.SetAllInfo(hideAll: false);
			}
			if (!(GlobalReferences.GetHUDManager() == null))
			{
				GlobalReferences.GetHUDManager().ShowHUD();
			}
		}
	}

	public static void DisableActiveCamera()
	{
		if (GlobalReferences.IsValidated())
		{
			if (GlobalReferences.GetCameraController() != null)
			{
				GlobalReferences.GetCameraController().gameObject.SetActive(value: false);
			}
			if (GlobalReferences.GetCharacterController() != null)
			{
				GlobalReferences.GetCharacterController().DeactivateCharacterInteraction();
				GlobalReferences.GetCharacterController().gameObject.SetActive(value: false);
			}
			if (GlobalReferences.GetCameraController() != null)
			{
				GlobalReferences.GetDarkRoomCameraController().gameObject.SetActive(value: false);
			}
			if (instance.activeCameraController != null)
			{
				instance.activeCameraController.Deactivate();
			}
		}
	}

	public static void SetDarkRoomCameraActive()
	{
		GlobalReferences.GetDarkRoomCameraController().gameObject.SetActive(value: true);
		instance.activeCameraController = GlobalReferences.GetDarkRoomCameraController();
		instance.activeCamera = instance.activeCameraController.GetCamera();
		if (RayCaster.IsValidated())
		{
			RayCaster.Deactivate();
		}
		if (MouseCursorInteraction.IsValidated())
		{
			MouseCursorInteraction.SetAllInfo(hideAll: true);
		}
		if (!(GlobalReferences.GetHUDManager() == null))
		{
			GlobalReferences.GetHUDManager().HideHUD();
		}
	}

	public static void SetTitleScreenCameraActive()
	{
		instance.cameraController.gameObject.SetActive(value: false);
		instance.cameraController.Activate();
		Shader.SetGlobalVector("_PlayerPosition", new Vector3(-250f, -250f, -250f));
	}
}
