using System;
using System.Collections;
using System.Collections.Generic;
using LeanTween.Framework;
using SettingScripts;
using SteamIntegrations;
using TMPro;
using UIScripts;
using UIScripts.SettingHandles;
using UIScripts.UIReferences;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.CrashReportHandler;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ManagementScripts
{
	public class MenuInitializer : MonoBehaviour
	{
		[Header("References")]
		public LoadingPanel LoadingPanel;

		public CanvasGroup TitleScreen;

		public CanvasGroup MainUI;

		public MenuManager menuManager;

		public ScenariosEditor GSH;

		public GameObject continueButton;

		public GameObject loadButton;

		public GameObject achievementButton;

		public GameObject steamUserSection;

		public Image steamUserIcon;

		public TextMeshProUGUI steamUsername;

		public GameObject welcomePopup;

		public WorkshopItemsPanel workshopItemsPanel;

		public List<GameObject> hideWithSteam = new List<GameObject>();

		public List<GameObject> showWithSteam = new List<GameObject>();

		private float progress;

		public static bool firstLoad = true;

		private const float SettingsFraction = 0.55f;

		private const float ResourcesFraction = 0.45f;

		[FormerlySerializedAs("OnLoadingDone")]
		public UnityEvent OnSettingsLoaded = new UnityEvent();

		public UnityEvent OnProceduralSpriteLoaded = new UnityEvent();

		public void Start()
		{
			Time.timeScale = 1f;
			TitleScreen.gameObject.SetActive(value: false);
			bool active = SaveController.AnySave();
			continueButton.SetActive(active);
			loadButton.SetActive(active);
			bool steam = SteamManager.Initialized || SteamManager.isDemo;
			hideWithSteam.ForEach(delegate(GameObject o)
			{
				o.SetActive(!steam);
			});
			showWithSteam.ForEach(delegate(GameObject o)
			{
				o.SetActive(steam);
			});
			achievementButton.SetActive(!SteamManager.isDemo);
			steamUserSection.SetActive(SteamManager.Initialized);
			if (SteamManager.Initialized)
			{
				steamUsername.text = SteamManager.username;
				steamUserIcon.sprite = SteamManager.avatarSprite;
				workshopItemsPanel.Initialize();
			}
			StartCoroutine(WaitMenuInitialization());
			progress = 0f;
		}

		private IEnumerator WaitMenuInitialization()
		{
			LoadingPanel.SetActive(active: true);
			LoadingPanel.UpdateProgress(0f);
			menuManager.SetActiveAllPanels();
			WaitForSeconds delay = new WaitForSeconds(0.1f);
			yield return null;
			ProceduralSpriteManager.Instance.StartLoadingSprites();
			GSH.gameObject.SetActive(value: true);
			GSH.StartLoadingSettingsHandles();
			yield return null;
			while (!GSH.doneLoading || !ProceduralSpriteManager.Instance.done)
			{
				LoadingPanel.UpdateProgress(0.45f * ProceduralSpriteManager.Instance.loadProgress + 0.495f * GSH.progress);
				yield return null;
			}
			progress = 0.945f;
			LoadingPanel.UpdateProgress(progress);
			yield return null;
			GSH.UpdateControls();
			progress += 0.027500002f;
			LoadingPanel.UpdateProgress(progress);
			OnSettingsLoaded.Invoke();
			yield return null;
			menuManager.SetActiveAllPanels(active: false);
			progress += 0.027500002f;
			LoadingPanel.UpdateProgress(progress);
			yield return delay;
			LoadingPanel.UpdateProgress(1f);
			OnProceduralSpriteLoaded.Invoke();
			LoadingPanel.SetActive(active: false, 1f);
			welcomePopup.SetActive(firstLoad && AppInitializer.firstTimeEver);
			if (firstLoad)
			{
				firstLoad = false;
				TitleScreen.gameObject.SetActive(value: true);
				MainUI.gameObject.SetActive(value: false);
				LeanTween.Framework.LeanTween.delayedCall(3f, (Action)delegate
				{
					TitleScreen.LeanAlpha(0f, 1f);
					LeanTween.Framework.LeanTween.delayedCall(1f, (Action)delegate
					{
						MainUI.gameObject.SetActive(value: true);
						MainUI.alpha = 0f;
						MainUI.LeanAlpha(1f, 0.5f);
					});
				});
			}
			else
			{
				MainUI.gameObject.SetActive(value: true);
				MainUI.alpha = 1f;
			}
			yield return delay;
			yield return delay;
			yield return delay;
			yield return delay;
			yield return delay;
			if (AppInitializer.display060Warning)
			{
				PopupManager.DisplayError("WARNING!", "Welcome back to The Bibites and our brand new 0.6 Update!\nA lot has changed in terms of dynamics and simulation complexity since the version your were used to, and not all can be updated.\n\nBibites and scenarios from your previous versions are NOT supported. I did my best to create an updater that would try to update bibites and scenarios from older versions, and while I did a pretty good job, it's very probable that they'll either die very quickly, or even cause bugs.\n\nI'm magnanimous, so I left you the option to try, but do so at your own risks. \n\n\nP.S.: sorry for telling you a problem occured when it wasn't the case, but I just really wanted grab your attention #sorrynotsorry");
				AppInitializer.display060Warning = false;
			}
			CheckCloudDiagnosticConsent();
		}

		private void CheckCloudDiagnosticConsent()
		{
			if (!UserSettings.AskedForCloudDiagnosticConsent.val)
			{
				PopupManager.DisplayChoiceDialog("Consent Inquiry for Cloud Diagnostic", UserSettings.CloudDiagnosticConsent.HelperText + "\n\nYou will be able to change your choice later", "Refuse", "Allow", AnsweredCloudDiagnostic, AllowCloudDiagnostic);
			}
			if (!UserSettings.AskedForAnalyticsConsent.val)
			{
				PopupManager.DisplayChoiceDialog("Analytics: Help with Science!", "Science is at the core of The Bibites, and while it's a powerful tool to do some hands-on study about evolution on a user-level, there's also a lot of potential for large-scale research.\nIf you consent to this, we'll collect some data about what's going on in your sims, what scenarios you launch, and so on, to be able to analyse the trends of the simulation, and what parameters lead to better results and more interesting dynamics.\nThis might eventually allow us to do some more thorough science and maybe even publish papers! Although in the short term it will mainly help-us better balance the existing scenarios or create new ones.\n\nOf course, this means that we send some data from your computer to our servers on the internet, so we totally understand if you prefer not to.\nYou can also change this at any other time in the user settings panel.", "Refuse", "Allow", AnsweredAnalytics, AllowAnalytics);
			}
			ConfigurePermissions();
		}

		private void AllowCloudDiagnostic()
		{
			UserSettings.CloudDiagnosticConsent.val = true;
			AnsweredCloudDiagnostic();
		}

		private void AnsweredCloudDiagnostic()
		{
			UserSettings.AskedForCloudDiagnosticConsent.val = true;
		}

		private void AllowAnalytics()
		{
			UserSettings.AnalyticsConsent.val = true;
			AnsweredAnalytics();
		}

		private void AnsweredAnalytics()
		{
			UserSettings.AskedForAnalyticsConsent.val = true;
		}

		private async void ConfigurePermissions()
		{
			CrashReportHandler.enableCaptureExceptions = UserSettings.CloudDiagnosticConsent.val;
			await UnityServices.InitializeAsync();
			if (UserSettings.AnalyticsConsent.val)
			{
				AnalyticsService.Instance.StartDataCollection();
			}
		}
	}
}
