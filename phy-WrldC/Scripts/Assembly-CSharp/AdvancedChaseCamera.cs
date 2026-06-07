using UnityEngine;
using UnityStandardAssets.Cameras;

public class AdvancedChaseCamera : BaseComponentView
{
	private GameObject cameraObject;

	private GameObject cameraFolder;

	private LogicIO activeInput;

	private void Update()
	{
		if (activeInput.ReadDigitalSignal())
		{
			GameManager.Instance.CameraManager.SetActionCamera(cameraFolder, !cameraFolder.activeSelf);
		}
	}

	private void OnDestroy()
	{
		Object.Destroy(cameraObject);
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		GameObject original = Resources.Load<GameObject>("MultipurposeCameraRig");
		cameraObject = Object.Instantiate(original);
		cameraObject.transform.SetParent(base.transform.parent);
		GameObject gameObject = cameraObject.transform.GetChild(0).gameObject;
		gameObject.transform.localPosition = new Vector3(5f, 2f, 0f);
		gameObject.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
		cameraObject.GetComponent<AutoCam>().SetTarget(base.transform);
		cameraFolder = gameObject.transform.GetChild(0).gameObject;
		cameraObject.SetActive(value: true);
		cameraFolder.SetActive(value: false);
		activeInput = base.BlockBodyView.AddLogicIO(new LogicIO("ac_camera_active", LogicIODirection.Input, digitalSignal: false)
		{
			DefaultKeyType = LogicIODefaultKeyType.UpToDown
		});
	}

	public override void SetBlockDestroyed()
	{
		base.SetBlockDestroyed();
		if (cameraObject.activeSelf)
		{
			GameManager.Instance.CameraManager.SetActionCamera(cameraObject, isActive: false);
		}
	}

	public override string GetComponentName()
	{
		return typeof(AdvancedChaseCamera).Name;
	}
}
