using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class CameraManager
{
	private bool isMainCameraActive;

	private GameObject orbitCameraFolder;

	private GameObject currentCameraFolder;

	private GameObject camerasObject;

	private BlurOptimized blurOptimized;

	private string creationId;

	private BlockBodyModel bodyModelFocused;

	private Vector3 cameraTargetPosition;

	private float savedAngleX;

	private float savedAngleY;

	private float savedZoomDistance;

	public OrbitCamera OrbitCamera { get; }

	public OrbitCamera BlockViewOrbitCamera { get; }

	public Camera FrontCamera { get; }

	public Transform CamerasTransform => camerasObject.transform;

	public AudioListener CameraAudioListener { get; }

	public bool IsMainCameraLocked { get; private set; }

	public CameraManager(GameObject orbitCameraObject, GameObject blockViewCameraObject)
	{
		orbitCameraFolder = orbitCameraObject.transform.GetChild(0).gameObject;
		camerasObject = orbitCameraObject.transform.GetChild(0).GetChild(0).gameObject;
		CameraAudioListener = orbitCameraObject.GetComponentInChildren<AudioListener>();
		blurOptimized = orbitCameraObject.GetComponentInChildren<BlurOptimized>(includeInactive: true);
		OrbitCamera = orbitCameraObject.GetComponent<OrbitCamera>();
		BlockViewOrbitCamera = blockViewCameraObject.GetComponent<OrbitCamera>();
		FrontCamera = orbitCameraObject.transform.FindChildRecursively("Front Camera").GetComponent<Camera>();
		isMainCameraActive = true;
		IsMainCameraLocked = false;
	}

	public void SetCamerasSensitivity(float sensitivity)
	{
		sensitivity = Mathf.Clamp(sensitivity, 0.25f, 10f);
		float xYRotationSpeed = 7f * sensitivity;
		OrbitCamera.SetXYRotationSpeed(xYRotationSpeed);
		BlockViewOrbitCamera.SetXYRotationSpeed(xYRotationSpeed);
	}

	public void SetLockMainCamera(bool isLocked)
	{
		OrbitCamera.SetMovementsActive(!isLocked);
		IsMainCameraLocked = isLocked;
	}

	public void SetMainCameraBlur(bool shouldBlur)
	{
		blurOptimized.enabled = shouldBlur;
	}

	public void RestoresMainCamera()
	{
		OrbitCamera.SetMovementsActive(value: true);
		camerasObject.transform.SetParent(orbitCameraFolder.transform, worldPositionStays: false);
		if (currentCameraFolder != null)
		{
			currentCameraFolder.SetActive(value: false);
		}
		currentCameraFolder = null;
		isMainCameraActive = true;
	}

	public void SetActionCamera(GameObject newCameraFolder, bool isActive)
	{
		if (isActive)
		{
			if (isMainCameraActive)
			{
				isMainCameraActive = false;
			}
			newCameraFolder.SetActive(value: true);
			OrbitCamera.SetMovementsActive(value: false);
			camerasObject.transform.SetParent(newCameraFolder.transform, worldPositionStays: false);
			if (currentCameraFolder != null)
			{
				currentCameraFolder.SetActive(value: false);
			}
			currentCameraFolder = newCameraFolder;
		}
		else
		{
			RestoresMainCamera();
		}
		Debug.Log("New Camera Activated: " + newCameraFolder.name);
	}

	public void SaveMainCameraStatus(CreationModel currentCreationModel)
	{
		if (!UpdateFocusedBlock(currentCreationModel))
		{
			bodyModelFocused = null;
			creationId = string.Empty;
			cameraTargetPosition = OrbitCamera.GetTargetPosition();
		}
	}

	public bool UpdateFocusedBlock(CreationModel currentCreationModel)
	{
		Transform target = OrbitCamera.GetTarget();
		if (target != null)
		{
			BlockBodyView component = target.GetComponent<BlockBodyView>();
			if (component != null)
			{
				int id = component.ParentBlockView.Id;
				int index = component.Index;
				bodyModelFocused = currentCreationModel.GetBlockModel(id).GetBlockBodyModel(index);
				creationId = currentCreationModel.Id;
				Transform transform = LevelManager.Instance.SelectedZone.transform;
				Vector3 localPoint = currentCreationModel.Position.TransformPoint(currentCreationModel.Rotation, bodyModelFocused.ParentBlockModel.Position);
				localPoint = transform.position.TransformPoint(transform.rotation, localPoint);
				cameraTargetPosition = localPoint;
				(float, float) angles = OrbitCamera.GetAngles();
				savedAngleX = angles.Item1;
				savedAngleY = angles.Item2;
				savedZoomDistance = OrbitCamera.GetZoomDistance();
				return true;
			}
		}
		return false;
	}

	public bool RestoresMainCameraStatus(CreationView currentCreationView, bool shouldRestoreLastPosition = true)
	{
		if (bodyModelFocused != null && currentCreationView.Id == creationId)
		{
			int id = bodyModelFocused.ParentBlockModel.Id;
			int index = bodyModelFocused.Index;
			Transform transform = currentCreationView.GetBlockView(id).GetBlockBodyView(index).transform;
			OrbitCamera.SetTarget(transform);
			OrbitCamera.SetAngles(savedAngleX, savedAngleY);
			OrbitCamera.SetZoomDistance(savedZoomDistance);
			return true;
		}
		if (shouldRestoreLastPosition)
		{
			OrbitCamera.SetTargetPosition(cameraTargetPosition);
		}
		return false;
	}

	public void RestoresLastMainCameraPosition()
	{
		_ = cameraTargetPosition;
		OrbitCamera.SetTargetPosition(cameraTargetPosition);
	}

	public void FocusMainCameraOnBrainBlock(CreationController creationController, bool shouldReplaceLastFocus = true)
	{
		if (shouldReplaceLastFocus || !(OrbitCamera.GetTarget() != null))
		{
			RestoresMainCamera();
			BlockModel brainBlockModel = creationController.model.BrainBlockModel;
			BlockBodyView blockBodyView = creationController.view.GetBlockBodyView(brainBlockModel.GetBlockBodyModel(0));
			OrbitCamera.SetTarget(blockBodyView.transform);
		}
	}
}
