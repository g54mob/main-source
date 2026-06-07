using Localization;
using UnityEngine;
using UnityEngine.UI;

public class RewiredTextChange : MonoBehaviour
{
	public string BaseTextKey = string.Empty;

	private Text selfText;

	private bool inited;

	private string lastTag = "";

	private void Awake()
	{
		if (BaseTextKey.Length == 0)
		{
			Object.DestroyImmediate(this);
			return;
		}
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
		LocalizedText component2 = base.gameObject.GetComponent<LocalizedText>();
		if (component2 != null)
		{
			Object.DestroyImmediate(component2);
		}
		selfText = GetComponent<Text>();
		if (selfText == null)
		{
			Object.DestroyImmediate(this);
		}
		else if (Logic.GetModel() != null)
		{
			inited = true;
			Logic.GetModel().InputDeviceChanged.AddListener(CheckText);
			CheckText(Logic.GetModel().CurInputDevice);
		}
	}

	private void OnDestroy()
	{
		if (Logic.GetModel() != null && Logic.GetModel().InputDeviceChanged != null)
		{
			Logic.GetModel().InputDeviceChanged.RemoveListener(CheckText);
		}
	}

	private void CheckText(string deviceTag)
	{
		_ = deviceTag == "PC";
		lastTag = deviceTag;
		if (TextResources.IsKeyExists(BaseTextKey + "_" + deviceTag))
		{
			selfText.text = TextResources.GetString(BaseTextKey + "_" + deviceTag);
			return;
		}
		if (deviceTag != "PC")
		{
			deviceTag = "CONTROLLER";
			if (TextResources.IsKeyExists(BaseTextKey + "_" + deviceTag))
			{
				selfText.text = TextResources.GetString(BaseTextKey + "_" + deviceTag);
				return;
			}
		}
		selfText.text = TextResources.GetString(BaseTextKey);
	}

	private void Update()
	{
		if (!inited && Logic.GetModel() != null)
		{
			if (!TextResources.IsReady)
			{
				return;
			}
			inited = true;
			Logic.GetModel().InputDeviceChanged.AddListener(CheckText);
			CheckText(Logic.GetModel().CurInputDevice);
		}
		if (Logic.GetModel() != null && Logic.GetModel().CurInputDevice != lastTag)
		{
			CheckText(Logic.GetModel().CurInputDevice);
		}
	}
}
