using System;
using System.Text.RegularExpressions;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Rewired;

public sealed class InputManager : InputManager_Base
{
	private bool ignoreRecompile;

	protected override void OnInitialized()
	{
		UnsubscribeEvents();
		UnityAction<Scene, LoadSceneMode> value = (UnityAction<Scene, LoadSceneMode>)(object)new UnityAction<Scene, System.Int32Enum>(OnSceneLoaded);
		SceneManager.sceneLoaded += value;
	}

	protected override void OnDeinitialized()
	{
		UnsubscribeEvents();
	}

	protected override void DetectPlatform()
	{
		scriptingBackend = ScriptingBackend.Mono;
		editorPlatform = EditorPlatform.None;
		webplayerPlatform = WebplayerPlatform.None;
		isEditor = false;
		string deviceName = SystemInfo.deviceName;
		string deviceModel = SystemInfo.deviceModel;
		platform = Platform.Windows;
		scriptingBackend = ScriptingBackend.IL2CPP;
		scriptingAPILevel = ScriptingAPILevel.NetStandard20;
	}

	protected override void CheckRecompile()
	{
	}

	protected override IExternalTools GetExternalTools()
	{
		return new ExternalTools();
	}

	private bool CheckDeviceName(string searchPattern, string deviceName, string deviceModel)
	{
		if (Regex.IsMatch(deviceName, searchPattern, RegexOptions.IgnoreCase))
		{
			return true;
		}
		return Regex.IsMatch(deviceModel, searchPattern, RegexOptions.IgnoreCase);
	}

	private void SubscribeEvents()
	{
		UnsubscribeEvents();
		UnityAction<Scene, LoadSceneMode> value = (UnityAction<Scene, LoadSceneMode>)(object)new UnityAction<Scene, System.Int32Enum>(OnSceneLoaded);
		SceneManager.sceneLoaded += value;
	}

	private void UnsubscribeEvents()
	{
		UnityAction<Scene, LoadSceneMode> value = (UnityAction<Scene, LoadSceneMode>)(object)new UnityAction<Scene, System.Int32Enum>(OnSceneLoaded);
		SceneManager.sceneLoaded -= value;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		OnSceneLoaded();
	}
}
