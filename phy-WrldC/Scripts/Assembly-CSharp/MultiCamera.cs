using UnityEngine;
using UnityStandardAssets.Cameras;

public class MultiCamera : BaseComponentView
{
	private GameObject fpsCameraFolder;

	private GameObject simpleChaseCameraFolder;

	private GameObject advancedChaseCameraFolder;

	private GameObject advancedChaseCameraObject;

	private GameObject currentCameraFolder;

	private LogicIO activeInput;

	private int cameraType;

	private bool isAutoActive;

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		cameraType = base.BlockBodyView.OverridableProperties.GetPropertyAsInt("multi_camera_type");
		switch (cameraType)
		{
		case 0:
			currentCameraFolder = fpsCameraFolder;
			break;
		case 1:
			currentCameraFolder = simpleChaseCameraFolder;
			break;
		case 2:
			currentCameraFolder = advancedChaseCameraFolder;
			break;
		default:
			currentCameraFolder = fpsCameraFolder;
			break;
		}
		isAutoActive = base.BlockBodyView.OverridableProperties.GetPropertyAsBool("multi_camera_auto_active");
		if (!base.BlockBodyView.ParentBlockView.ParentCreationView.IsPlayable)
		{
			isAutoActive = false;
		}
	}

	private void Update()
	{
		if (activeInput.ReadDigitalSignal() || isAutoActive)
		{
			GameManager.Instance.CameraManager.SetActionCamera(currentCameraFolder, !currentCameraFolder.activeSelf);
			isAutoActive = false;
		}
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		base.gameObject.AddComponent<MultiCameraReplay>();
	}

	protected override void SetInitializeConfiguration(Properties properties)
	{
		base.SetInitializeConfiguration(properties);
		SetUpFPSCamera(properties);
		SetUpSimpleChaseCamera(properties);
		SetUpAdvancedChaseCamera(properties);
		activeInput = base.BlockBodyView.AddLogicIO(new LogicIO("multi_camera_active", LogicIODirection.Input, digitalSignal: false)
		{
			DefaultKeyType = LogicIODefaultKeyType.UpToDown
		});
	}

	protected override void InternalResetComponent()
	{
		base.InternalResetComponent();
		if (fpsCameraFolder != null)
		{
			Object.Destroy(fpsCameraFolder);
		}
		if (simpleChaseCameraFolder != null)
		{
			Object.Destroy(simpleChaseCameraFolder);
		}
		if (advancedChaseCameraObject != null)
		{
			Object.Destroy(advancedChaseCameraObject);
		}
	}

	private void OnDestroy()
	{
		Object.Destroy(advancedChaseCameraObject);
	}

	public override void SetBlockDestroyed()
	{
		base.SetBlockDestroyed();
		if (currentCameraFolder.activeSelf)
		{
			GameManager.Instance.CameraManager.SetActionCamera(currentCameraFolder, isActive: false);
			GameManager.Instance.CameraManager.OrbitCamera.SetTarget(base.transform, isMoveImmediately: true);
		}
	}

	protected override void InternalInitializeGizmos<MultiCameraModel>(MultiCameraModel componentModel)
	{
		base.InternalInitializeGizmos(componentModel);
		GameObject obj = InstantiateGizmoObject("CameraGizmo");
		Vector3 propertyAsVector = componentModel.Properties.GetPropertyAsVector3("fpsPosition");
		Vector3 propertyAsVector2 = componentModel.Properties.GetPropertyAsVector3("fpsDirection");
		obj.transform.localPosition = propertyAsVector;
		obj.transform.localRotation = Quaternion.LookRotation(propertyAsVector2, Vector3.up);
	}

	public override string GetComponentName()
	{
		return typeof(MultiCamera).Name;
	}

	public void SetCameraOff()
	{
		if (currentCameraFolder.activeSelf)
		{
			GameManager.Instance.CameraManager.SetActionCamera(currentCameraFolder, isActive: false);
		}
	}

	private void SetUpFPSCamera(Properties properties)
	{
		Vector3 propertyAsVector = properties.GetPropertyAsVector3("fpsPosition");
		Vector3 propertyAsVector2 = properties.GetPropertyAsVector3("fpsDirection");
		fpsCameraFolder = new GameObject("FPSCameraFolder");
		fpsCameraFolder.transform.SetParent(base.transform);
		fpsCameraFolder.transform.localPosition = propertyAsVector;
		fpsCameraFolder.transform.localRotation = Quaternion.LookRotation(propertyAsVector2, Vector3.up);
		fpsCameraFolder.SetActive(value: false);
	}

	private void SetUpSimpleChaseCamera(Properties properties)
	{
		float propertyAsFloat = properties.GetPropertyAsFloat("thirdPersonDistance");
		float propertyAsFloat2 = properties.GetPropertyAsFloat("thirdPersonHeight");
		simpleChaseCameraFolder = new GameObject("SimpleChaseCamera");
		simpleChaseCameraFolder.transform.SetParent(base.transform);
		simpleChaseCameraFolder.transform.localPosition = new Vector3(0f - propertyAsFloat, propertyAsFloat2, 0f);
		simpleChaseCameraFolder.transform.LookAt(base.transform);
		simpleChaseCameraFolder.SetActive(value: false);
	}

	private void SetUpAdvancedChaseCamera(Properties properties)
	{
		float propertyAsFloat = properties.GetPropertyAsFloat("thirdPersonDistance");
		float propertyAsFloat2 = properties.GetPropertyAsFloat("thirdPersonHeight");
		GameObject original = Resources.Load<GameObject>("MultipurposeCameraRig");
		advancedChaseCameraObject = Object.Instantiate(original);
		advancedChaseCameraObject.transform.SetParent(base.transform.parent);
		GameObject gameObject = advancedChaseCameraObject.transform.GetChild(0).gameObject;
		gameObject.transform.localPosition = new Vector3(0f - propertyAsFloat, propertyAsFloat2, 0f);
		gameObject.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
		advancedChaseCameraObject.GetComponent<AutoCam>().SetTarget(base.transform);
		advancedChaseCameraFolder = gameObject.transform.GetChild(0).gameObject;
		advancedChaseCameraObject.SetActive(value: true);
		advancedChaseCameraFolder.SetActive(value: false);
	}
}
