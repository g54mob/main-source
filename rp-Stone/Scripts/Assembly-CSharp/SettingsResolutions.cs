using System.Collections.Generic;
using UnityEngine;

public class SettingsResolutions : MonoBehaviour
{
	private const string KEY_SAVED = "RESOLUTION_SAVED";

	private const string KEY_WIDTH = "RESOLUTION_WIDTH";

	private const string KEY_HEIGHT = "RESOLUTION_HEIGHT";

	private const string KEY_FULL_SCREEN = "RESOLUTION_FULL_SCREEN";

	private const string KEY_VSYNC = "RESOLUTION_VSYNC";

	private static bool USE_MAX_RESOLUTION_ENTRY;

	private bool isMaxRes;

	private int setResToMaxCountdown = -1;

	public static SettingsResolutions singleton { get; private set; }

	public List<string> GetResolutionStrings()
	{
		List<string> list = new List<string>();
		Resolution[] screenResolutions = Utils.GetScreenResolutions();
		for (int i = 0; i < screenResolutions.Length; i++)
		{
			string item = screenResolutions[i].width + "x" + screenResolutions[i].height;
			list.Add(item);
		}
		if (USE_MAX_RESOLUTION_ENTRY)
		{
			list.Add("MAX");
		}
		return list;
	}

	public int GetCurrentIndex()
	{
		Resolution[] screenResolutions = Utils.GetScreenResolutions();
		if (screenResolutions.Length == 0)
		{
			return -1;
		}
		Resolution resolution = screenResolutions[^1];
		if (Screen.width >= resolution.width && Screen.height >= resolution.height)
		{
			if (USE_MAX_RESOLUTION_ENTRY)
			{
				return screenResolutions.Length;
			}
			return screenResolutions.Length - 1;
		}
		for (int i = 0; i < screenResolutions.Length; i++)
		{
			if (Screen.width == screenResolutions[i].width && Screen.height == screenResolutions[i].height)
			{
				return i;
			}
		}
		return -1;
	}

	public void SetResolutionByIndex(int index)
	{
		Resolution[] screenResolutions = Utils.GetScreenResolutions();
		isMaxRes = false;
		if (index >= screenResolutions.Length)
		{
			SetResolutionToMax();
		}
		else if (index >= 0 && screenResolutions.Length != 0)
		{
			Resolution resolution = screenResolutions[index];
			Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, resolution.refreshRate);
		}
		else
		{
			Utils.LogError("Failed to set resolution to index " + index);
		}
	}

	public string GetCurrentResolutionString()
	{
		return Screen.width + "x" + Screen.height;
	}

	public void SetResolutionToMax()
	{
		Screen.fullScreen = true;
		setResToMaxCountdown = 3;
		isMaxRes = true;
	}

	private void Update()
	{
		if (setResToMaxCountdown > 0 && setResToMaxCountdown-- == 0)
		{
			SetResolutionToMax_Internal();
		}
		if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightShift))
		{
			PlayerPrefs.DeleteKey("RESOLUTION_SAVED");
			PlayerPrefs.DeleteKey("RESOLUTION_WIDTH");
			PlayerPrefs.DeleteKey("RESOLUTION_HEIGHT");
			PlayerPrefs.DeleteKey("RESOLUTION_FULL_SCREEN");
		}
		if (Input.GetKey(KeyCode.V))
		{
			if (Input.GetKeyDown(KeyCode.Alpha0))
			{
				QualitySettings.vSyncCount = 0;
			}
			else if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				QualitySettings.vSyncCount = 1;
			}
		}
	}

	private void SetResolutionToMax_Internal()
	{
		Screen.SetResolution(8000, 4500, fullscreen: true);
	}

	public void Save()
	{
		if (isMaxRes)
		{
			PlayerPrefs.DeleteKey("RESOLUTION_SAVED");
		}
		else
		{
			PlayerPrefs.SetInt("RESOLUTION_SAVED", 1);
			PlayerPrefs.SetInt("RESOLUTION_WIDTH", Screen.width);
			PlayerPrefs.SetInt("RESOLUTION_HEIGHT", Screen.height);
			PlayerPrefs.SetInt("RESOLUTION_FULL_SCREEN", Screen.fullScreen ? 1 : 0);
		}
		PlayerPrefs.SetInt("RESOLUTION_VSYNC", QualitySettings.vSyncCount);
	}

	public void Load()
	{
		if (PlayerPrefs.HasKey("RESOLUTION_SAVED"))
		{
			int num = PlayerPrefs.GetInt("RESOLUTION_WIDTH");
			int num2 = PlayerPrefs.GetInt("RESOLUTION_HEIGHT");
			bool fullscreen = PlayerPrefs.GetInt("RESOLUTION_FULL_SCREEN") == 1;
			Resolution[] screenResolutions = Utils.GetScreenResolutions();
			bool flag = false;
			for (int i = 0; i < screenResolutions.Length; i++)
			{
				Resolution resolution = screenResolutions[i];
				if (num == resolution.width && num2 == resolution.height)
				{
					flag = true;
					Screen.SetResolution(num, num2, fullscreen, resolution.refreshRate);
					break;
				}
			}
			if (!flag)
			{
				Screen.SetResolution(num, num2, fullscreen);
			}
		}
		else
		{
			SetResolutionToMax();
		}
		QualitySettings.vSyncCount = PlayerPrefs.GetInt("RESOLUTION_VSYNC", 1);
	}

	private void Awake()
	{
		singleton = this;
	}
}
