using UnityEngine;

public class RewiredDependentHideShow : MonoBehaviour
{
	public bool anyControllerCheck = true;

	public string InputDeviceType = "CONTROLLER";

	private bool inited;

	private string lastTag = "";

	private void Awake()
	{
		if (Logic.IsSteamDeckRunning())
		{
			Object.DestroyImmediate(this);
			return;
		}
		PlatformDependendSelfDestroy component = base.gameObject.GetComponent<PlatformDependendSelfDestroy>();
		if (component != null)
		{
			Object.DestroyImmediate(component);
		}
		if (Logic.GetModel() != null)
		{
			inited = true;
			Logic.GetModel().InputDeviceChanged.AddListener(CheckHide);
			CheckHide(Logic.GetModel().CurInputDevice);
		}
	}

	private void CheckHide(string deviceTag)
	{
		bool flag = deviceTag == "PC";
		lastTag = deviceTag;
		if (anyControllerCheck)
		{
			base.gameObject.SetActive(flag == (InputDeviceType == "PC"));
		}
		else
		{
			base.gameObject.SetActive(deviceTag == InputDeviceType);
		}
	}

	private void OnDestroy()
	{
		if (Logic.GetModel() != null && Logic.GetModel().InputDeviceChanged != null)
		{
			Logic.GetModel().InputDeviceChanged.RemoveListener(CheckHide);
		}
	}

	private void Update()
	{
		if (!inited && Logic.GetModel() != null)
		{
			inited = true;
			Logic.GetModel().InputDeviceChanged.AddListener(CheckHide);
			CheckHide(Logic.GetModel().CurInputDevice);
		}
		if (Logic.GetModel() != null && Logic.GetModel().CurInputDevice != lastTag)
		{
			CheckHide(Logic.GetModel().CurInputDevice);
		}
	}
}
