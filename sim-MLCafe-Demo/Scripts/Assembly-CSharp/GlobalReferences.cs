using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GlobalReferences : MonoBehaviour
{
	[SerializeField]
	private CharacterControllerComponent characterController;

	[SerializeField]
	private CameraController cameraController;

	[SerializeField]
	private CameraController darkRoomCameraController;

	[SerializeField]
	private DispatchControllerComponent dispatchController;

	[SerializeField]
	private Canvas canvasHUD;

	[SerializeField]
	private HUDManager hudManager;

	[SerializeField]
	private GameObject resetPositionArea;

	private static GlobalReferences instance;

	public static UnityEvent OnRefreshReferences = new UnityEvent();

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		RefreshReferences();
		SceneManager.activeSceneChanged += delegate
		{
			RefreshReferences();
		};
	}

	public static bool IsValidated()
	{
		return instance != null;
	}

	public static CharacterControllerComponent GetCharacterController()
	{
		return instance.characterController;
	}

	public static CameraController GetActiveCameraController()
	{
		if (GameStateManager.GetCurrentGameState() == GameStateManager.GameState.TitleScreen)
		{
			return instance.cameraController;
		}
		return CameraManager.GetActiveCameraController();
	}

	public static CameraController GetCameraController()
	{
		return instance.cameraController;
	}

	public static CameraController GetDarkRoomCameraController()
	{
		return instance.darkRoomCameraController;
	}

	public static DispatchControllerComponent GetDispatchController()
	{
		return instance.dispatchController;
	}

	public static HUDManager GetHUDManager()
	{
		return instance.hudManager;
	}

	public static GameObject GetResetPositionArea()
	{
		return instance.resetPositionArea;
	}

	public static Vector3 GetHalfwayCharacterCameraPoint(float alpha = 0.5f)
	{
		Vector3 vector = Vector3.Lerp(instance.characterController.transform.position, instance.cameraController.GetCamera().transform.position, alpha);
		return new Vector3(vector.x, 0f, vector.z);
	}

	public static Canvas GetCanvasHUD()
	{
		return instance.canvasHUD;
	}

	public static void RefreshReferences()
	{
		if (GameStateManager.IsValidated() && GameStateManager.GetCurrentGameState() == GameStateManager.GameState.TitleScreen)
		{
			instance.characterController = Object.FindFirstObjectByType<CharacterControllerComponent>();
			instance.cameraController = Object.FindFirstObjectByType<CameraController>();
		}
		else
		{
			instance.characterController = Object.FindFirstObjectByType<CharacterControllerComponent>();
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			if (gameObject != null)
			{
				instance.cameraController = gameObject.GetComponent<CameraController>();
			}
			GameObject gameObject2 = GameObject.FindGameObjectWithTag("DarkRoomCamera");
			if (gameObject2 != null)
			{
				instance.darkRoomCameraController = gameObject2.GetComponent<CameraController>();
				instance.darkRoomCameraController.Deactivate();
			}
			instance.dispatchController = Object.FindFirstObjectByType<DispatchControllerComponent>();
			GameObject gameObject3 = GameObject.FindGameObjectWithTag("Respawn");
			if (gameObject3 != null)
			{
				instance.resetPositionArea = gameObject3;
			}
			instance.hudManager = Object.FindFirstObjectByType<HUDManager>();
		}
		OnRefreshReferences.Invoke();
	}
}
