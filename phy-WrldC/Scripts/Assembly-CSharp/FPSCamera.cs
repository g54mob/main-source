using UnityEngine;

public class FPSCamera : BaseComponentView
{
	private GameObject cameraFolder;

	private LogicIO activeInput;

	private void Update()
	{
		if (activeInput.ReadDigitalSignal())
		{
			GameManager.Instance.CameraManager.SetActionCamera(cameraFolder, !cameraFolder.activeSelf);
		}
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		Vector3 localPosition = Util.Vector3Parser(properties.GetProperty("pos"));
		Vector3 forward = Util.Vector3Parser(properties.GetProperty("dir"));
		cameraFolder = new GameObject("FPSCameraFolder");
		cameraFolder.transform.SetParent(base.transform);
		cameraFolder.transform.localPosition = localPosition;
		cameraFolder.transform.localRotation = Quaternion.LookRotation(forward, Vector3.up);
		cameraFolder.SetActive(value: false);
		activeInput = base.BlockBodyView.AddLogicIO(new LogicIO("fps_camera_active", LogicIODirection.Input, digitalSignal: false)
		{
			DefaultKeyType = LogicIODefaultKeyType.UpToDown
		});
	}

	public override void SetBlockDestroyed()
	{
		base.SetBlockDestroyed();
		if (cameraFolder.activeSelf)
		{
			GameManager.Instance.CameraManager.SetActionCamera(cameraFolder, isActive: false);
		}
	}

	public override string GetComponentName()
	{
		return typeof(FPSCamera).Name;
	}
}
