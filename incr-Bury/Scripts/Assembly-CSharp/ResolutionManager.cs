using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{
	public static ResolutionManager Singleton;

	private Resolution[] resolutions;

	private List<Resolution> filteredResolutions;

	private float currentRefreshRate;

	private int currentResolutionIndex;

	private bool fullScreen = true;

	public TMP_Dropdown resolutionDropDown;

	public Toggle fullScreenToggle;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			Object.Destroy(this);
			return;
		}
		Singleton = this;
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Start()
	{
		ResetResolutions();
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
		resolutionDropDown.onValueChanged.RemoveAllListeners();
	}

	public void ResetResolutions()
	{
		resolutionDropDown.onValueChanged.RemoveAllListeners();
		resolutions = Screen.resolutions;
		filteredResolutions = new List<Resolution>();
		resolutionDropDown.ClearOptions();
		currentRefreshRate = Screen.currentResolution.refreshRate;
		for (int i = 0; i < resolutions.Length; i++)
		{
			if ((float)resolutions[i].refreshRate == currentRefreshRate)
			{
				filteredResolutions.Add(resolutions[i]);
			}
		}
		List<string> list = new List<string>();
		for (int j = 0; j < filteredResolutions.Count; j++)
		{
			string item = filteredResolutions[j].width + "x" + filteredResolutions[j].height + " " + filteredResolutions[j].refreshRate + " Hz";
			list.Add(item);
			if (filteredResolutions[j].width == Screen.width && filteredResolutions[j].height == Screen.height)
			{
				currentResolutionIndex = j;
			}
		}
		resolutionDropDown.AddOptions(list);
		resolutionDropDown.value = currentResolutionIndex;
		resolutionDropDown.RefreshShownValue();
		fullScreen = Screen.fullScreen;
		fullScreenToggle.isOn = fullScreen;
		resolutionDropDown.onValueChanged.AddListener(delegate
		{
			ResolutionDropDownOptionChanged();
		});
	}

	public void SetResolution()
	{
		Resolution resolution = filteredResolutions[currentResolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, fullScreen);
		Debug.Log("Set resolution to" + filteredResolutions[currentResolutionIndex].width + " width by " + filteredResolutions[currentResolutionIndex].height + " height");
	}

	private void ResolutionDropDownOptionChanged()
	{
		currentResolutionIndex = resolutionDropDown.value;
		Debug.Log("resolution drop down options changed");
		SetResolution();
	}

	public void FullscreenToggleChanged()
	{
		UpdateFullScreen(fullScreenToggle.isOn);
	}

	private void UpdateFullScreen(bool _isOn)
	{
		if (Screen.fullScreen != _isOn)
		{
			Debug.Log("fullscreen toggle doesn't match current fullscreen mode, updating");
			fullScreen = fullScreenToggle.isOn;
			if (fullScreen)
			{
				PlayerPrefs.SetInt("isFullScreen", 1);
			}
			else
			{
				PlayerPrefs.SetInt("isFullScreen", 0);
			}
			SetResolution();
		}
	}
}
