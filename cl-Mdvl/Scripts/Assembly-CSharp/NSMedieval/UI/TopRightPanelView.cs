using System;
using System.Collections.Generic;
using System.Text;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.GameEventSystem;
using NSMedieval.Manager;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.Tools.BugReporting;
using NSMedieval.Tools.Debug;
using NSMedieval.Types;
using NSMedieval.UI.PhotoMode;
using NSMedieval.UI.Utils;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class TopRightPanelView : UIView, IObserver
	{
		[SerializeField]
		private TMP_Text dateText;

		[SerializeField]
		private TMP_Text timeText;

		[SerializeField]
		private TMP_Text weather;

		[SerializeField]
		private SoundButton almanacButton;

		[SerializeField]
		private SoundButton optionsButton;

		[SerializeField]
		private SoundButton statsButton;

		[SerializeField]
		private SoundButton bugReportButton;

		[SerializeField]
		private SoundButton photoModeButton;

		[SerializeField]
		private Toggle[] gameSpeedButtons;

		private StringBuilder temperatureStringBuilder = new StringBuilder();

		private bool IsFasterSpeedDisabled => GlobalSaveController.CurrentVillageData.Raids.Count > 0;

		private void OnTimeUpdate()
		{
			int hoursSinceDay = GlobalSaveController.CurrentVillageData.DateAndTime.HoursSinceDay;
			timeText.text = ((hoursSinceDay < 10) ? $"0{hoursSinceDay}" : hoursSinceDay.ToString()) + base.Localize.GetText("general_hour_short");
			UpdateBugReportButtonState();
		}

		private void OnDateUpdate()
		{
			dateText.text = string.Format("{0}. {1}\n{2}", GlobalSaveController.CurrentVillageData.DateAndTime.Year, MonoSingleton<LocalizationController>.Instance.GetText("general_" + GlobalSaveController.CurrentVillageData.DateAndTime.Season.Name), UiUtils.GetLocalizedDay());
		}

		private void UpdateWeatherText()
		{
			string text = MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.RunningEventsWeatherTextKey();
			if (text != null)
			{
				weather.text = GetTemperatureLocalized() + "\n" + text;
			}
			else
			{
				weather.text = GetTemperatureLocalized() + "\n" + MonoSingleton<WeatherManager>.Instance.EventNamesLocalized;
			}
		}

		private string GetTemperatureLocalized()
		{
			if (!MonoSingleton<GlobalSaveController>.IsInstantiated() || GlobalSaveController.CurrentVillageData == null)
			{
				return string.Empty;
			}
			VillageMap villageMap = VillageManager.ActiveVillage?.Map;
			if (villageMap?.RoomDetection == null)
			{
				return string.Empty;
			}
			NSMedieval.RoomDetection.RoomDetection roomDetection = villageMap.RoomDetection;
			Vec3Int hoverGridPosition = MonoSingleton<PlayerVoxelInfo>.Instance.HoverGridPosition;
			bool flag = roomDetection.GetRoom(hoverGridPosition) != null;
			int num;
			if (!flag)
			{
				MapNode node = villageMap.GetNode(hoverGridPosition);
				num = ((node != null && node.Coverage == CoverageType.Roofed) ? 1 : 0);
			}
			else
			{
				num = 1;
			}
			bool flag2 = (byte)num != 0;
			string text = MonoSingleton<LocalizationController>.Instance.GetText(flag ? "inside" : (flag2 ? "roofed" : "outside"));
			string localizedTemperature = WorldDate.GetLocalizedTemperature(villageMap.TemperatureManager.GetTemperature(hoverGridPosition));
			temperatureStringBuilder.Clear();
			temperatureStringBuilder.AppendFormat("{0} {1}", localizedTemperature, text);
			return temperatureStringBuilder.ToString();
		}

		private void OnDateTimeInitialize()
		{
			OnTimeUpdate();
			OnDateUpdate();
		}

		private void OnChangeTimeScale(float scale, int speedIndex)
		{
			for (int i = 0; i < gameSpeedButtons.Length; i++)
			{
				gameSpeedButtons[i].interactable = i != speedIndex;
			}
			UpdateFasterButtonState();
		}

		private void UpdateFasterButtonState()
		{
			Toggle toggle = gameSpeedButtons[3];
			if (MonoSingleton<GameSpeedManager>.Instance.IsFasterSpeedDisabled)
			{
				toggle.gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.2f);
			}
			else if (MonoSingleton<GameSpeedManager>.Instance.CurrentSpeedIndex == GameSpeedIndex.Sleeping)
			{
				gameSpeedButtons[3].GetComponent<Image>().color = Color.cyan;
				gameSpeedButtons[3].interactable = false;
			}
			else
			{
				gameSpeedButtons[3].GetComponent<Image>().color = Color.white;
			}
		}

		private void OnRaidStarted(ActiveRaidInfo info, List<HumanoidInstance> enemies)
		{
			UpdateFasterButtonState();
		}

		private void OnRaidEnded(ActiveRaidInfo info)
		{
			UpdateFasterButtonState();
		}

		private void UpdateBugReportButtonState()
		{
			if (BugReporterJiraAPI.IsReportUploading)
			{
				if (bugReportButton.interactable)
				{
					bugReportButton.interactable = false;
				}
			}
			else if (!bugReportButton.interactable)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("report_sent"));
				bugReportButton.interactable = true;
			}
		}

		private void OnVoxelHoverChange(Vec3Int obj)
		{
			UpdateWeatherText();
		}

		private void ShowPhotoMode()
		{
			MonoSingleton<NSMedieval.UI.PhotoMode.PhotoMode>.Instance.Show();
		}

		private void ToggleAlmanac()
		{
			base.SceneUIManager.TogglePanel("AlmanacPanelManager");
		}

		private void ShowBugReporter()
		{
			MonoSingleton<BugReporterManager>.Instance.ShowReporter();
		}

		private void OnStartEvent(GameEventInstance gameEventInstance)
		{
			if (gameEventInstance != null && !(gameEventInstance.Blueprint == null) && gameEventInstance.ReplaceWeatherText != null)
			{
				UpdateWeatherText();
			}
		}

		private void OnGameEventEnded(GameEventInstance gameEventInstance)
		{
			if (gameEventInstance != null && !(gameEventInstance.Blueprint == null) && gameEventInstance.ReplaceWeatherText != null)
			{
				UpdateWeatherText();
			}
		}

		private void Start()
		{
			MonoSingleton<GameEventSystemController>.Instance.GameEventStarted += OnStartEvent;
			MonoSingleton<GameEventSystemController>.Instance.GameEventEnded += OnGameEventEnded;
			MonoSingleton<GameSpeedManager>.Instance.UpdateTimeScaleUIEvent += OnChangeTimeScale;
			MonoSingleton<WorldTimeManager>.Instance.DateTimeInitalizeEvent += OnDateTimeInitialize;
			MonoSingleton<WorldTimeManager>.Instance.TimeUpdateEvent += OnTimeUpdate;
			MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent += OnDateUpdate;
			PlayerVoxelInfo instance = MonoSingleton<PlayerVoxelInfo>.Instance;
			instance.OnHoverChange = (Action<Vec3Int>)Delegate.Combine(instance.OnHoverChange, new Action<Vec3Int>(OnVoxelHoverChange));
			MonoSingleton<RaidController>.Instance.RaidSpawnedEvent += OnRaidStarted;
			MonoSingleton<RaidController>.Instance.RaidEndedEvent += OnRaidEnded;
			MonoSingleton<WorldMapController>.Instance.WorldMapVisibilitySetEvent += OnWorldMapVisibilitySet;
			for (int i = 0; i < gameSpeedButtons.Length; i++)
			{
				int index = i;
				gameSpeedButtons[index].onValueChanged.AddListener(delegate(bool call)
				{
					if (call)
					{
						MonoSingleton<GameSpeedManager>.Instance.OnUIButtonClicked(index);
					}
				});
			}
			almanacButton.onClick.AddListener(ToggleAlmanac);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.ShowHideAlmanac, ToggleAlmanac, activeOnWorldMap: true);
			optionsButton.onClick.AddListener(delegate
			{
				base.SceneUIManager.ShowNewView("InGameMenuView");
			});
			if (GlobalSaveController.CurrentVillageData.IsSecondMap)
			{
				statsButton.gameObject.SetActive(value: false);
			}
			else
			{
				statsButton.onClick.AddListener(delegate
				{
					base.SceneUIManager.TogglePanel("StatisticsPanelManager");
				});
			}
			bugReportButton.onClick.AddListener(ShowBugReporter);
			MonoSingleton<KeybindingManager>.Instance.SubscribeToEvent(KeyInputEvent.Report, delegate
			{
				if (!BugReporterJiraAPI.IsReportUploading)
				{
					ShowBugReporter();
				}
			}, activeOnWorldMap: true);
			photoModeButton.onClick.AddListener(ShowPhotoMode);
		}

		private void OnWorldMapVisibilitySet(bool isEnabled)
		{
			photoModeButton.interactable = !isEnabled;
		}

		protected override void OnDestroy()
		{
			if (!(this == null) && !(base.gameObject == null))
			{
				if (MonoSingleton<GameSpeedManager>.IsInstantiated())
				{
					MonoSingleton<GameSpeedManager>.Instance.UpdateTimeScaleUIEvent -= OnChangeTimeScale;
				}
				if (MonoSingleton<WorldTimeManager>.IsInstantiated())
				{
					MonoSingleton<WorldTimeManager>.Instance.DateTimeInitalizeEvent -= OnDateTimeInitialize;
					MonoSingleton<WorldTimeManager>.Instance.TimeUpdateEvent -= OnTimeUpdate;
					MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent -= OnDateUpdate;
				}
				if (MonoSingleton<PlayerVoxelInfo>.IsInstantiated())
				{
					PlayerVoxelInfo instance = MonoSingleton<PlayerVoxelInfo>.Instance;
					instance.OnHoverChange = (Action<Vec3Int>)Delegate.Remove(instance.OnHoverChange, new Action<Vec3Int>(OnVoxelHoverChange));
				}
				if (MonoSingleton<RaidController>.IsInstantiated())
				{
					MonoSingleton<RaidController>.Instance.RaidSpawnedEvent -= OnRaidStarted;
					MonoSingleton<RaidController>.Instance.RaidEndedEvent -= OnRaidEnded;
				}
				if (MonoSingleton<GameEventSystemController>.IsInstantiated())
				{
					MonoSingleton<GameEventSystemController>.Instance.GameEventStarted -= OnStartEvent;
					MonoSingleton<GameEventSystemController>.Instance.GameEventEnded -= OnGameEventEnded;
				}
				if (MonoSingleton<WorldMapController>.IsInstantiated())
				{
					MonoSingleton<WorldMapController>.Instance.WorldMapVisibilitySetEvent -= OnWorldMapVisibilitySet;
				}
				base.OnDestroy();
			}
		}
	}
}
