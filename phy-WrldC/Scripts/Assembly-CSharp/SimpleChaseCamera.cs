using UnityEngine;

public class SimpleChaseCamera : BaseComponentView
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
		cameraFolder = new GameObject("SimpleChaseCamera");
		cameraFolder.transform.SetParent(base.transform);
		cameraFolder.transform.localPosition = new Vector3(10f, 5f, 0f);
		cameraFolder.transform.LookAt(base.transform);
		cameraFolder.SetActive(value: false);
		activeInput = base.BlockBodyView.AddLogicIO(new LogicIO("sc_camera_active", LogicIODirection.Input, digitalSignal: false)
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
		return typeof(SimpleChaseCamera).Name;
	}
}
