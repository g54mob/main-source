using System;
using System.Collections;
using System.Threading;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Almanac;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Tutorial;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.WorldMap;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval
{
	public class LoadingScreenFake : ClosableUIView, IObserver
	{
		private const float ChunkPercentBudget = 0.3f;

		private const float ObjectPercentBudget = 0.5f;

		[Header("Main Group")]
		[SerializeField]
		private float mainGroupFadeOutSpeed = 0.3f;

		[SerializeField]
		private CanvasGroupFader mainGroupFader;

		[Header("Intro Text")]
		[SerializeField]
		private float textFadeInSpeed = 0.4f;

		[SerializeField]
		private CanvasGroupFader introTextGroupFader;

		[SerializeField]
		private TextMeshProUGUI introTitle;

		[SerializeField]
		private TextMeshProUGUI introScenario;

		[SerializeField]
		private TextMeshProUGUI introSignature;

		[Header("Loading elements")]
		[SerializeField]
		private GameObject loadingBar;

		[SerializeField]
		private Slider loadingSlider;

		[SerializeField]
		private TextMeshProUGUI fillBarText;

		[SerializeField]
		private GameObject continueButton;

		[Header("Animation values")]
		[SerializeField]
		private float defaultPercentIncrease = 0.01f;

		private float alpha;

		private bool fadeStarted;

		private float globalLoadPercentage;

		private float totalChunks;

		private float totalObjects;

		private void Awake()
		{
			continueButton.GetComponent<Button>().onClick.AddListener(OnContinueClick);
		}

		private void Start()
		{
			Log.Debug("************LSF: Start()", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\LoadingScreenFake.cs");
			introTextGroupFader.Hide();
			MonoSingleton<LoadingController>.Instance.LoadingPhaseChangedEvent += OnLoadingPhaseChanged;
			OnMainSceneLoaded();
		}

		private void OnEnable()
		{
			Application.runInBackground = false;
		}

		private void OnDisable()
		{
			if (MonoSingleton<GlobalSaveController>.IsInstantiated() && !MonoSingleton<GlobalSaveController>.IsApplicationIsQuitting() && MonoSingleton<GlobalSaveController>.Instance.GlobalSettings != null)
			{
				Application.runInBackground = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.RunInBackground;
				fillBarText.SetText(string.Empty);
			}
		}

		private void OnMainSceneLoaded()
		{
			StartCoroutine(OnSceneLoadedCoroutine());
		}

		private IEnumerator OnSceneLoadedCoroutine()
		{
			fillBarText.SetText("general_creating_world".ToLocalized());
			globalLoadPercentage = 0.1f;
			UpdateSlider();
			WorldMapPlace worldMapPlace = GlobalSaveController.CurrentVillageData.WorldMapPlace;
			if (worldMapPlace == null)
			{
				if (!MonoSingleton<TravelManager>.IsInstantiated() || !MonoSingleton<TravelManager>.Instance.IsGeneratingNewSecondMap)
				{
					throw new Exception("World map place is null, but we are not generating a new second map, this should not happen");
				}
				Log.Info("World map place is allowed to be null because we are generating a new second map", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\LoadingScreenFake.cs");
			}
			string sourceText = worldMapPlace?.EnterMapLoadingScreenTitle.ToLocalized(worldMapPlace) ?? "[dev] Generating map";
			string sourceText2 = worldMapPlace?.EnterMapLoadingScreenDescription.ToLocalized(worldMapPlace) ?? "[dev] Generating new second map...";
			if (TutorialManager.IsTutorialActive)
			{
				sourceText = "tutorial_loading_screen_title".ToLocalized();
				sourceText2 = "tutorial_loading_screen_description".ToLocalized();
			}
			introTitle.SetText(sourceText);
			introScenario.SetText(sourceText2);
			if (GlobalSaveController.CurrentVillageData.IsSecondMap || TutorialManager.IsTutorialActive)
			{
				introSignature.gameObject.SetActive(value: false);
			}
			else
			{
				introSignature.gameObject.SetActive(value: true);
			}
			introTextGroupFader.FadeIn(textFadeInSpeed);
			yield return new WaitForSeconds(textFadeInSpeed + 0.1f);
		}

		private void OnLoadingPhaseChanged(string loadingPhaseTextKey, float percent = -1f, int number = -1)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(32, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\LoadingScreenFake.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Loading phase: ");
				messageBuilder.AppendFormatted(loadingPhaseTextKey);
				messageBuilder.AppendLiteral(" percent:");
				messageBuilder.AppendFormatted(percent);
				messageBuilder.AppendLiteral(" number:");
				messageBuilder.AppendFormatted(number);
			}
			Log.Debug(messageBuilder);
			if (loadingPhaseTextKey.Equals("load_placing_objects") && number < 0)
			{
				return;
			}
			string text = ((loadingPhaseTextKey == "loading_complete") ? MonoSingleton<LocalizationController>.Instance.GetText("load_sequence_complete") : MonoSingleton<LocalizationController>.Instance.GetText(loadingPhaseTextKey));
			float num = defaultPercentIncrease;
			if (loadingPhaseTextKey.Equals("loading_map_chunks"))
			{
				if (number != -1)
				{
					if (totalChunks == 0f)
					{
						totalChunks = number;
					}
					float t = 1f - (float)number / totalChunks;
					num = 0.3f / totalChunks;
					text = string.Format(text, number);
					FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(1, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\LoadingScreenFake.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendFormatted(t, "P1");
						messageBuilder2.AppendLiteral(" ");
						messageBuilder2.AppendFormatted(num, "P1");
					}
					Log.Trace(messageBuilder2);
				}
				else
				{
					num = 0f;
				}
			}
			if (loadingPhaseTextKey.Equals("load_spawning_objects"))
			{
				if (number != -1)
				{
					if (totalObjects == 0f)
					{
						totalObjects = number;
					}
					float num2 = 1f - (float)number / totalObjects;
					num = 0.5f / totalObjects;
					text = $"{text} ({num2:P1})";
					FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(1, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\LoadingScreenFake.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendFormatted(num2, "P1");
						messageBuilder2.AppendLiteral(" ");
						messageBuilder2.AppendFormatted(num, "P1");
					}
					Log.Trace(messageBuilder2);
				}
				else
				{
					num = 0f;
				}
			}
			fillBarText.SetText(text);
			globalLoadPercentage += num;
			if (loadingPhaseTextKey == "loading_complete")
			{
				globalLoadPercentage = 1f;
				OnLoadingFinished();
			}
			UpdateSlider();
		}

		private void UpdateSlider()
		{
			loadingSlider.value = globalLoadPercentage;
		}

		private void OnLoadingFinished()
		{
			MonoSingleton<LoadingController>.Instance.LoadingPhaseChangedEvent -= OnLoadingPhaseChanged;
			MonoSingleton<TaskController>.Instance.WaitUntil(delegate
			{
				Thread.Sleep(20);
				return AlmanacPanelManager.InitDone;
			}).Then(delegate
			{
				MonoSingleton<LoadingController>.Instance.InvokeLoadingCompleteEvent();
				MonoSingleton<TaskController>.Instance.WaitForUnscaled(1f).Then(delegate
				{
					continueButton.SetActive(value: true);
					loadingBar.SetActive(value: false);
				});
			});
		}

		public void OnContinueClick()
		{
			continueButton.SetActive(value: false);
			StartCoroutine(HideCoroutine());
			MonoSingleton<SceneController>.Instance.SetupScene();
			MonoSingleton<UIController>.Instance.StartGame();
			MonoSingleton<GoapController>.Instance.StartGoapTicker();
			MonoSingleton<TravelManager>.Instance.OnGameplayStarted();
		}

		private IEnumerator HideCoroutine()
		{
			mainGroupFader.FadeOut(mainGroupFadeOutSpeed);
			yield return new WaitForSecondsRealtime(mainGroupFadeOutSpeed + 0.1f);
			Hide();
		}
	}
}
