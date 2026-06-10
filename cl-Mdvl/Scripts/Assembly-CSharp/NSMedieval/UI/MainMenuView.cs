using System;
using System.Collections.Generic;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Managers;
using NSMedieval.Modding;
using NSMedieval.State;
using NSMedieval.Tutorial;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering.PostProcessing;

namespace NSMedieval.UI
{
	public class MainMenuView : ClosableUIView
	{
		[SerializeField]
		private SoundButton resumeButton;

		[SerializeField]
		private GameObject resumeOldSaveWarning;

		[SerializeField]
		private SoundButton newGameButton;

		[SerializeField]
		private SoundButton loadButton;

		[SerializeField]
		private SoundButton tutorialButton;

		[SerializeField]
		private SoundButton optionsButton;

		[SerializeField]
		private SoundButton languageButton;

		[SerializeField]
		private SoundButton roadmapButton;

		[SerializeField]
		private SoundButton autoplayButton;

		[SerializeField]
		private SoundButton modBrowserButton;

		[SerializeField]
		private SoundButton quitButon;

		[SerializeField]
		private HomeNotificationPopup notificationPopup;

		[SerializeField]
		private GameObject languageDivider;

		[SerializeField]
		private SoundButton twitterLink;

		[SerializeField]
		private SoundButton patchNotesLink;

		[SerializeField]
		private SoundButton newsletterLink;

		[SerializeField]
		private SoundButton buyFullLink;

		[SerializeField]
		private SoundButton discordLink;

		[SerializeField]
		private SoundButton youtubeLink;

		[SerializeField]
		private SoundButton tiktokLink;

		[SerializeField]
		private SoundButton redditLink;

		[SerializeField]
		private SoundButton steamLink;

		[SerializeField]
		private Camera mainCamera;

		[SerializeField]
		private GameObject homeSceneArt;

		[SerializeField]
		private GameObject backgroundPlane;

		[SerializeField]
		private AssetReferenceT<RenderTexture> backgroundRenderTextureRef;

		[SerializeField]
		private GameObject earlyAccessGO;

		[SerializeField]
		private GameObject demoGO;

		[SerializeField]
		private GameObject mainMenuPanel;

		private RenderTexture backgroundRenderTexture;

		private bool showingLowRes;

		public static void ShowCorruptedSaveMessage(VillageSaveMeta meta)
		{
			List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>("general_ok", null)
			};
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData("load_failed", buttonActions));
		}

		public static void ShowMissingModMessage(VillageSaveMeta meta)
		{
			List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>("general_back", null),
				new KeyValuePair<string, Action>("menu_load", delegate
				{
					MonoSingleton<AddressableSceneLoadingManager>.Instance.LoadMainScene();
				})
			};
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("load_failed_missing_mod".ToLocalized());
			int num = 0;
			int num2 = 5;
			if (meta != null)
			{
				List<string> mods = meta.Mods;
				if (mods != null && mods.Count > 0)
				{
					stringBuilder.AppendLine();
					stringBuilder.AppendLine("mods_from_save".ToLocalized() + ":");
					foreach (string mod in meta.Mods)
					{
						string text = "DefaultGreen";
						if (!MonoSingleton<ModManager>.Instance.IsModEnabled(mod))
						{
							text = "DefaultRed";
						}
						stringBuilder.AppendLine("<style=" + text + ">" + mod + "</style>");
						num++;
						if (num >= num2)
						{
							stringBuilder.AppendLine("and_more".ToLocalized());
							break;
						}
					}
				}
			}
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("load_failed_missing_objects".ToLocalized() + ":");
			num = 0;
			foreach (string corruptedBlueprintId in MonoSingleton<GlobalSaveController>.Instance.CorruptedBlueprintIds)
			{
				string text2 = "DefaultGreen";
				if (!MonoSingleton<GlobalSaveController>.Instance.ReplacedBlueprintIds.Contains(corruptedBlueprintId))
				{
					text2 = "DefaultRed";
				}
				stringBuilder.AppendLine("<style=" + text2 + ">" + corruptedBlueprintId + "</style>");
				num++;
				if (num >= num2)
				{
					stringBuilder.AppendLine("and_more".ToLocalized());
					break;
				}
			}
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData(stringBuilder.ToString(), buttonActions));
		}

		public static void ShowObsoleteSaveMessage(string modifiedVersion, string validVersion)
		{
			List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>("general_ok", null)
			};
			if (string.IsNullOrEmpty(modifiedVersion))
			{
				modifiedVersion = "?.?.?";
			}
			if (!ApplicationVersionUtils.IsValidSaveVersion(modifiedVersion))
			{
				string promptText = MonoSingleton<LocalizationController>.Instance.GetText("save_load_fail").Replace("<save_modified_version>", modifiedVersion).Replace("<valid_save_version>", validVersion);
				MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData(promptText, buttonActions));
			}
			else if (!ApplicationVersionUtils.IsNewSaveVersion(modifiedVersion))
			{
				string text = MonoSingleton<LocalizationController>.Instance.GetText("save_migration_error");
				MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData(text, buttonActions), handleInput: false);
			}
		}

		public override void Show()
		{
			tutorialButton.interactable = true;
			resumeOldSaveWarning.SetActive(SecureSaveLoadingManager.HasSaves && SecureSaveLoadingManager.LatestSave.IsObsolete);
			resumeButton.gameObject.SetActive(SecureSaveLoadingManager.HasSaves);
			SetInteractable(resumeButton, SecureSaveLoadingManager.HasSaves);
			SetInteractable(loadButton, SecureSaveLoadingManager.HasSaves);
			MonoSingleton<UIClosableController>.Instance.CloseAll();
			base.Show();
			SwitchBackground(showLowRes: false);
			autoplayButton.gameObject.SetActive(value: false);
		}

		private void OnEnable()
		{
			if (MonoSingleton<EulaManager>.Instance.EulaAccepted)
			{
				modBrowserButton.AddCleanListener(delegate
				{
					base.SceneUIManager.ShowNewView("ModLoaderView");
				});
			}
			else
			{
				MonoSingleton<EulaManager>.Instance.EulaStatusChangeEvent += OnEulaStatusChanged;
				modBrowserButton.AddCleanListener(MonoSingleton<EulaManager>.Instance.ShowPrompt);
			}
		}

		private void OnDisable()
		{
			if (MonoSingleton<EulaManager>.IsInstantiated())
			{
				MonoSingleton<EulaManager>.Instance.EulaStatusChangeEvent -= OnEulaStatusChanged;
			}
		}

		private void QuitGame()
		{
			Log.Info("Quitting to OS from MainMenuView", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\MainMenuView.cs");
			SwitchBackground(showLowRes: false);
			if (MonoSingleton<TaskController>.IsInstantiated())
			{
				MonoSingleton<TaskController>.Instance.StopAllCoroutines();
			}
			Application.Quit();
		}

		private void SwitchBackground(bool showLowRes)
		{
			if (showingLowRes != showLowRes)
			{
				showingLowRes = showLowRes;
				if (showLowRes)
				{
					backgroundPlane.SetActive(value: false);
					homeSceneArt.SetActive(value: true);
					float aspect = mainCamera.aspect;
					mainCamera.targetTexture = backgroundRenderTextureRef.Asset as RenderTexture;
					mainCamera.aspect = aspect;
					mainCamera.Render();
					mainCamera.targetTexture = null;
					backgroundPlane.SetActive(value: true);
					homeSceneArt.SetActive(value: false);
					mainCamera.ResetAspect();
				}
				else
				{
					mainCamera.GetComponent<PostProcessLayer>().ResetHistory();
					mainCamera.targetTexture = null;
					mainCamera.ResetAspect();
					backgroundPlane.SetActive(value: false);
					homeSceneArt.SetActive(value: true);
				}
			}
		}

		private void Start()
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(14, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\MainMenuView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Game version: ");
				messageBuilder.AppendFormatted(Application.version);
			}
			Log.Info(messageBuilder);
			base.SceneUIManager.OnViewShownEvent += OnUIViewShown;
			MonoSingleton<GlobalSaveController>.Instance.SynchronizeWithFiles();
			base.SceneUIManager.RegisterCurrentView(this);
			resumeButton.onClick.AddListener(OnResumeButtonClick);
			loadButton.onClick.AddListener(delegate
			{
				base.SceneUIManager.ShowNewView("LoadGameView");
			});
			tutorialButton.onClick.AddListener(OnTutorialButtonClick);
			newGameButton.onClick.AddListener(OnNewGameButtonClick);
			optionsButton.onClick.AddListener(delegate
			{
				base.SceneUIManager.ShowNewView("OptionsView");
			});
			languageButton.onClick.AddListener(delegate
			{
				base.SceneUIManager.ShowNewView("LanguageSelectView");
			});
			roadmapButton.onClick.AddListener(delegate
			{
				base.SceneUIManager.ShowNewView("RoadmapView");
			});
			autoplayButton.onClick.AddListener(delegate
			{
				base.SceneUIManager.ShowNewView("AutoplayView");
			});
			quitButon.onClick.AddListener(delegate
			{
				SwitchBackground(showLowRes: true);
				List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
				{
					new KeyValuePair<string, Action>("general_yes", QuitGame),
					new KeyValuePair<string, Action>("general_no", delegate
					{
						SwitchBackground(showLowRes: false);
					})
				};
				MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData("quit_game_prompt_info", buttonActions), handleInput: false);
			});
			quitButon.ButtonClickSound = "UI_ButtonClose";
			twitterLink.onClick.AddListener(delegate
			{
				Application.OpenURL("https://twitter.com/going_medieval");
			});
			discordLink.onClick.AddListener(delegate
			{
				Application.OpenURL("https://discord.gg/4bEnGhe");
			});
			steamLink.onClick.AddListener(delegate
			{
				Application.OpenURL("https://store.steampowered.com/app/1029780/Going_Medieval/");
			});
			youtubeLink.onClick.AddListener(delegate
			{
				Application.OpenURL("https://www.youtube.com/@FoxyVoxel");
			});
			tiktokLink.onClick.AddListener(delegate
			{
				Application.OpenURL("https://www.tiktok.com/@going.medieval");
			});
			redditLink.onClick.AddListener(delegate
			{
				Application.OpenURL("https://www.reddit.com/r/goingmedieval/");
			});
			patchNotesLink.onClick.AddListener(delegate
			{
				Application.OpenURL("https://foxyvoxel.io/category/going-medieval/");
			});
			newsletterLink.onClick.AddListener(delegate
			{
				Application.OpenURL("https://foxyvoxel.io/#newsletter");
			});
			buyFullLink.onClick.AddListener(delegate
			{
				Application.OpenURL("steam://store/1029780");
			});
			MonoSingleton<AddressableLoadingManager>.Instance.LoadAsync<RenderTexture>(backgroundRenderTextureRef, base.AddReferenceCallback);
			Show();
			Invoke("ShowNotificationPopup", 0.5f);
		}

		private void OnTutorialButtonClick()
		{
			if (SecureSaveLoadingManager.HasSaves)
			{
				string text = MonoSingleton<LocalizationController>.Instance.GetText("tutorial_start_warning_description");
				List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
				{
					new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_yes"), MonoSingleton<TutorialManager>.Instance.LoadTutorial),
					new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_no"), delegate
					{
					})
				};
				MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData(text, buttonActions));
			}
			else
			{
				MonoSingleton<TutorialManager>.Instance.LoadTutorial();
			}
		}

		private void OnNewGameButtonClick()
		{
			if (!MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TutorialComplete && !MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TutorialWarningShown && !SecureSaveLoadingManager.HasSaves)
			{
				MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.SetTutorialWarningShown();
				MonoSingleton<GlobalSaveController>.Instance.Serialize();
				string text = MonoSingleton<LocalizationController>.Instance.GetText("tutorial_warning_description");
				List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
				{
					new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("tutorial_warning_answer_tutorial"), OnTutorialButtonClick),
					new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("tutorial_warning_answer_new_game"), OnNewGameButtonClick)
				};
				MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData(text, buttonActions));
			}
			else
			{
				base.SceneUIManager.ShowNewView("ScenarioView");
			}
		}

		private void OnEulaStatusChanged(bool accepted)
		{
			if (accepted)
			{
				MonoSingleton<EulaManager>.Instance.EulaStatusChangeEvent -= OnEulaStatusChanged;
				modBrowserButton.AddCleanListener(delegate
				{
					base.SceneUIManager.ShowNewView("ModLoaderView");
				});
				base.SceneUIManager.ShowNewView("ModLoaderView");
			}
		}

		protected override void OnDestroy()
		{
			if (base.SceneUIManager != null)
			{
				base.SceneUIManager.OnViewShownEvent -= OnUIViewShown;
			}
			base.OnDestroy();
		}

		private void OnUIViewShown(string viewName)
		{
			bool showLowRes = !viewName.Equals("MainMenuView");
			SwitchBackground(showLowRes);
		}

		private void ShowNotificationPopup()
		{
			notificationPopup.Show();
		}

		private void OnResumeButtonClick()
		{
			SetInteractable(resumeButton, interactable: false);
			MonoSingleton<SecureSaveLoadingManager>.Instance.LoadLatestVillageSaveData();
		}

		private void SetInteractable(SoundButton button, bool interactable)
		{
			button.interactable = interactable;
			float a = 1f;
			if (!interactable)
			{
				a = 0.1f;
			}
			button.gameObject.GetComponentInChildren<TMP_Text>().color = new Color(1f, 1f, 1f, a);
		}

		private void Update()
		{
			if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.N))
			{
				Debug.Log(MemoryStats.LogMemoryUsage());
			}
		}
	}
}
