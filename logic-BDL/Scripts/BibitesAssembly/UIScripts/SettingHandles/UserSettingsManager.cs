using System.Collections.Generic;
using ManagementScripts;
using SettingScripts;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.CrashReportHandler;

namespace UIScripts.SettingHandles
{
	public class UserSettingsManager : UIPanel
	{
		public List<GameObject> Tabs = new List<GameObject>();

		public GameObject graphicsHolder;

		public GameObject gameHolder;

		public GameObject hotkeysHolder;

		private List<ISettingsListHandle> SettingsList;

		private SettingsGroupHandle graphicsOptions = new SettingsGroupHandle
		{
			GroupTitle = "Graphics Settings",
			Settings = new List<ISettingHandle>
			{
				new SettingToggle(UserSettings.Fullscreen),
				new SettingToggle(UserSettings.AutomaticallyDetectScreenResolution),
				new FloatSettingDropdown(UserSettings.ScreenResolutionFactor)
				{
					addDetailsToTooltip = false
				},
				new FloatSettingDropdown(UserSettings.UIScale)
				{
					addDetailsToTooltip = false
				},
				new FloatSettingSlider(UserSettings.pheromonesStrength),
				new ChoiceSettingDropdown<ChoiceUserSetting<UserSettings.ProceduralSizeChoice>, UserSettings.ProceduralSizeChoice>(UserSettings.ProceduralSize),
				new SettingsGroupHandle
				{
					GroupTitle = "UI Preferences",
					Settings = new List<ISettingHandle>
					{
						new SettingsColorPicker(UserSettings.FertilityColor),
						new SettingsGroupHandle
						{
							GroupTitle = "Background",
							Settings = new List<ISettingHandle>
							{
								new SettingsColorPicker(UserSettings.BackgroundColor),
								new SubSettingsGroupHandle(UserSettings.ShowGrid)
								{
									GroupTitle = "Grid Options",
									Settings = new List<ISettingHandle>
									{
										new SettingsColorPicker(UserSettings.GridColor1),
										new LogIntSettingSlider(UserSettings.GridStep1, 10f, wholeNumbers: true),
										new FloatSettingSlider(UserSettings.GridLineWidth1),
										new SettingsColorPicker(UserSettings.GridColor2),
										new LogIntSettingSlider(UserSettings.GridStep2, 10f, wholeNumbers: true),
										new IntSettingSlider(UserSettings.GridLineWidth2)
									}
								},
								new SubSettingsGroupHandle(UserSettings.ShowTexture)
								{
									GroupTitle = "Texture Options",
									Settings = new List<ISettingHandle>
									{
										new SettingsColorPicker(UserSettings.TextureColor)
									}
								}
							}
						},
						new SettingToggle(UserSettings.ShowNodeNames)
					}
				}
			}
		};

		private SettingsGroupHandle autosaveOptions = new SettingsGroupHandle
		{
			GroupTitle = "Save Settings",
			Settings = new List<ISettingHandle>
			{
				new SettingToggle(UserSettings.AutoSave),
				new ChoiceSettingDropdown<ChoiceUserSetting<UserSettings.AutoSavePeriods>, UserSettings.AutoSavePeriods>(UserSettings.AutoSavePeriod),
				new SettingToggle(UserSettings.AutoSaveRealTime),
				new SettingToggle(UserSettings.ReloadAfterAutosaves),
				new SettingToggle(UserSettings.PauseAfterLoad),
				new IntSettingSlider(UserSettings.AutoSaveMaxFiles)
			}
		};

		private SettingsGroupHandle gameOptions = new SettingsGroupHandle
		{
			GroupTitle = "Gameplay Options",
			Settings = new List<ISettingHandle>
			{
				new SubSettingsGroupHandle
				{
					GroupTitle = "Easter Eggs Settings",
					MasterToggle = new SubSettingsToggleMaster(UserSettings.AllowEasterEggs),
					Settings = new List<ISettingHandle>
					{
						new LogIntSettingSlider(UserSettings.EasterEggsProbability, 10f)
					}
				}
			}
		};

		private SettingsGroupHandle controlOptions = new SettingsGroupHandle
		{
			GroupTitle = "Control Options",
			Settings = new List<ISettingHandle>
			{
				new IntSettingSlider(UserSettings.minimumFPS),
				new SettingToggle(UserSettings.ignoreMinOnUnfocus),
				new SettingToggle(UserSettings.allowArrowKeyCameraControl),
				new SettingToggle(UserSettings.OpenZoneEditorOnSelect)
			}
		};

		private SettingsGroupHandle reportingOptions = new SettingsGroupHandle
		{
			GroupTitle = "Reporting Settings",
			Settings = new List<ISettingHandle>
			{
				new SettingToggle(UserSettings.CloudDiagnosticConsent),
				new SettingToggle(UserSettings.AnalyticsConsent)
			}
		};

		private static readonly int FertilityColor = Shader.PropertyToID("_fertilityColor");

		public override void InitPanel()
		{
			UserSettings.Fullscreen.SubscribeTo<BoolUserSetting, bool>(UpdateFullscreen, invokeNow: true);
			UserSettings.CloudDiagnosticConsent.SubscribeTo<BoolUserSetting, bool>(ToggleCloudReporting, invokeNow: true);
			UserSettings.AnalyticsConsent.Subscribe(ToggleAnalyticsConsent);
			UserSettings.FertilityColor.SubscribeTo<ColorUserSetting, Color>(UpdateFertilityColor, invokeNow: true);
			SettingsList = new List<ISettingsListHandle>
			{
				graphicsOptions.AssignHolder(graphicsHolder),
				autosaveOptions.AssignHolder(gameHolder),
				gameOptions.AssignHolder(gameHolder),
				controlOptions.AssignHolder(gameHolder),
				reportingOptions.AssignHolder(gameHolder)
			};
		}

		private void Start()
		{
			SettingsList.ForEach(delegate(ISettingsListHandle L)
			{
				L.CreateUIElements();
			});
			OpenTab(0);
		}

		public override void OpenPanel()
		{
			base.OpenPanel();
			TimeController.Instance?.TogglePauseGame("SettingsPanel");
			UserControl.AllowControl = false;
		}

		public override void ClosePanel()
		{
			base.ClosePanel();
			ReleaseRestrictions();
		}

		private void ReleaseRestrictions()
		{
			TimeController.Instance?.TogglePauseGame("SettingsPanel", isUnpause: true);
			UserControl.AllowControl = true;
		}

		public void OpenTab(int i)
		{
			Tabs.ForEach(delegate(GameObject p)
			{
				p.SetActive(value: false);
			});
			Tabs[i].SetActive(value: true);
		}

		public void ResetAllWarnings()
		{
			ActionWarnings.allInfoShown.ForEach(delegate(ActionWarning i)
			{
				i.ResetValue();
			});
		}

		private void OnDestroy()
		{
			SettingsList.ForEach(delegate(ISettingsListHandle L)
			{
				L.ReleaseDependencies();
			});
			UserSettings.Fullscreen.UnSubscribeTo<BoolUserSetting, bool>(UpdateFullscreen);
			UserSettings.CloudDiagnosticConsent.UnSubscribeTo<BoolUserSetting, bool>(ToggleCloudReporting);
			UserSettings.AnalyticsConsent.UnSubscribe(ToggleAnalyticsConsent);
			UserSettings.FertilityColor.UnSubscribeTo<ColorUserSetting, Color>(UpdateFertilityColor);
		}

		private static void UpdateFertilityColor(Color val)
		{
			Shader.SetGlobalColor(FertilityColor, val);
		}

		private void UpdateFullscreen(bool val)
		{
			Screen.fullScreen = val;
			if (val)
			{
				Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, fullscreen: true);
			}
		}

		private void ToggleCloudReporting(bool value)
		{
			CrashReportHandler.enableCaptureExceptions = value;
		}

		private void ToggleAnalyticsConsent(bool value)
		{
			if (value)
			{
				AnalyticsService.Instance.StartDataCollection();
			}
			else
			{
				AnalyticsService.Instance.StopDataCollection();
			}
		}
	}
}
