using System;
using System.Collections.Generic;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.UI.Menu.Windows;
using UnityEngine;
using UnityEngine.Localization;

public class Settings : MonoBehaviour
{
	public GameObject enumPrefab;

	public GameObject sliderPrefab;

	public GameObject resolutionPrefab;

	public GameObject controlPrefab;

	public GameObject controlPrefabNew;

	public GameObject controllerDisplayPrefab;

	public GameObject headerPrefab;

	public GameObject languagePrefab;

	public Transform videoContent;

	public Transform gameContent;

	public Transform audioContent;

	public Transform controlContent;

	public Transform visualsContent;

	public Transform otherContent;

	public List<BetterSetting> settings;

	public GameObject resolutionWindow;

	public Window settingsWindow;

	public GameObject btn_resetSettings;

	public GameObject b_resetControls;

	public TabsExplicitNavigation gameContentNav;

	public TabsExplicitNavigation settingsNav;

	public static Action A_ResetRewiredControls;

	public static Settings Instance;

	public LocalizedString localizedSyncAchievementsHeader;

	public LocalizedString localizedSyncAchievementsPrompt;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void Rebuild()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void UpdateSettings()
	{
	}

	private void CreateGenericSettings(Action<string, object, CFSettings> saveAction, Transform contentParent, CFSettings cfSettings)
	{
	}

	private GameObject GetSettingPrefab(SettingType settingType)
	{
		return null;
	}

	public void TryResetSaveFile()
	{
	}

	public void ResetControls()
	{
	}

	private void ResetSaveFile()
	{
	}

	public void RefreshSettings()
	{
	}

	public void SyncSteamAchievements()
	{
	}

	private void SyncAchievements()
	{
	}

	private void OnResButtonClicked()
	{
	}

	private void OnResChanged(int resIndex)
	{
	}
}
