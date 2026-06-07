using System;
using System.Collections;
using System.Collections.Generic;
using Enviro;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
	public static SettingManager S;

	[HideInInspector]
	public Resolution[] filteredResolutions;

	[HideInInspector]
	public List<string> resOptionsStrings = new List<string>();

	private string savePath = "ES3_Setting.es3";

	public event Action OnSetResolution;

	private void Awake()
	{
		if (S == null)
		{
			S = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			InitializeResolutions();
			LoadAndApplyAllSettings();
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void InitializeResolutions()
	{
		Resolution[] resolutions = Screen.resolutions;
		Dictionary<string, Resolution> dictionary = new Dictionary<string, Resolution>();
		for (int i = 0; i < resolutions.Length; i++)
		{
			string key = resolutions[i].width + "x" + resolutions[i].height;
			if (!dictionary.ContainsKey(key))
			{
				dictionary.Add(key, resolutions[i]);
			}
			else if (resolutions[i].refreshRateRatio.value > dictionary[key].refreshRateRatio.value)
			{
				dictionary[key] = resolutions[i];
			}
		}
		List<Resolution> list = new List<Resolution>(dictionary.Values);
		list.Sort((Resolution a, Resolution b) => (a.width * a.height).CompareTo(b.width * b.height));
		filteredResolutions = list.ToArray();
		resOptionsStrings.Clear();
		Resolution[] array = filteredResolutions;
		for (int num = 0; num < array.Length; num++)
		{
			Resolution resolution = array[num];
			double num2 = Math.Round(resolution.refreshRateRatio.value);
			resOptionsStrings.Add($"{resolution.width} x {resolution.height} ({num2}Hz)");
		}
	}

	public void SetFrameRate(int fps)
	{
		Application.targetFrameRate = fps;
	}

	public void SetVSync(bool isOn)
	{
		QualitySettings.vSyncCount = (isOn ? 1 : 0);
	}

	public void SetResolution(int index, bool isFull)
	{
		Resolution resolution = filteredResolutions[index];
		FullScreenMode mode = (isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed);
		StartCoroutine(ChangeResolutionRoutine(resolution.width, resolution.height, mode));
	}

	private IEnumerator ChangeResolutionRoutine(int w, int h, FullScreenMode mode)
	{
		Screen.SetResolution(w, h, mode);
		yield return new WaitForEndOfFrame();
		this.OnSetResolution?.Invoke();
	}

	public void SetQuality(int index)
	{
		int vSyncCount = QualitySettings.vSyncCount;
		QualitySettings.SetQualityLevel(index, applyExpensiveChanges: true);
		QualitySettings.vSyncCount = vSyncCount;
		if (EnviroManager.instance != null && EnviroManager.instance.Quality != null)
		{
			EnviroQualities settings = EnviroManager.instance.Quality.Settings;
			if (index >= 0 && index < settings.Qualities.Count)
			{
				settings.defaultQuality = settings.Qualities[index];
			}
			else
			{
				Debug.LogWarning("Enviro 3 퀄리티 리스트 인덱스를 벗어났습니다. 인스펙터 세팅을 확인해주세요.");
			}
		}
	}

	public void SetVolume(string parameterName, float value)
	{
		float value2 = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
		if (AudioManager.S != null)
		{
			AudioManager.S.mixer.SetFloat(parameterName, value2);
		}
	}

	public void SetSensitivity(float value)
	{
		if (FirstPersonController.S != null)
		{
			FirstPersonController.S.mouseSensitivity = value;
		}
	}

	public void LoadSensitivity()
	{
		ES3Settings settings = new ES3Settings(savePath);
		SetSensitivity(ES3.Load("MouseSensitivity", 0.05f, settings));
	}

	public void SaveAllSettings(float master, float music, float sfx, float sens, bool isFull, bool isVSync, int targetFPS)
	{
		ES3Settings settings = new ES3Settings(savePath);
		ES3.Save("ResWidth", Screen.width, settings);
		ES3.Save("ResHeight", Screen.height, settings);
		ES3.Save("FullScreen", isFull, settings);
		ES3.Save("Quality", QualitySettings.GetQualityLevel(), settings);
		ES3.Save("MasterVolume", master, settings);
		ES3.Save("MusicVolume", music, settings);
		ES3.Save("SFXVolume", sfx, settings);
		ES3.Save("MouseSensitivity", sens, settings);
		ES3.Save("VSync", isVSync, settings);
		ES3.Save("TargetFPS", targetFPS, settings);
	}

	public void LoadAndApplyAllSettings()
	{
		ES3Settings settings = new ES3Settings(savePath);
		SetVolume("MasterVolume", ES3.Load("MasterVolume", 1f, settings));
		SetVolume("MusicVolume", ES3.Load("MusicVolume", 0.4f, settings));
		SetVolume("SFXVolume", ES3.Load("SFXVolume", 1f, settings));
		int quality = ES3.Load("Quality", QualitySettings.GetQualityLevel(), settings);
		SetQuality(quality);
		bool num = ES3.Load("FullScreen", defaultValue: true, settings);
		int w = ES3.Load("ResWidth", Screen.currentResolution.width, settings);
		int h = ES3.Load("ResHeight", Screen.currentResolution.height, settings);
		FullScreenMode mode = (num ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed);
		StartCoroutine(ChangeResolutionRoutine(w, h, mode));
		QualitySettings.vSyncCount = (ES3.Load("VSync", defaultValue: false, settings) ? 1 : 0);
		Application.targetFrameRate = ES3.Load("TargetFPS", 60, settings);
		SetSensitivity(ES3.Load("MouseSensitivity", 0.05f, settings));
	}
}
