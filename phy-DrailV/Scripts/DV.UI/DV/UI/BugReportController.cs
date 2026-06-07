using System;
using System.Collections.Generic;
using System.IO;
using Cysharp.Threading.Tasks;
using DV.UIFramework;
using TMPro;
using UnityEngine;

namespace DV.UI
{
	public class BugReportController : AUIController
	{
		[Header("Checks")]
		[NullCheck]
		public ToggleDV chkLogFiles;

		[NullCheck]
		public ToggleDV chkScreenshot;

		[NullCheck]
		public ToggleDV chkSaveGames;

		[NullCheck]
		public ToggleDV chkTelemetry;

		[NullCheck]
		public ToggleDV chkGfxBenchmark;

		[NullCheck]
		public ToggleDV chkPhysicsBenchmark;

		[Header("Input")]
		[NullCheck]
		public TextMeshProUGUI txtCharCount;

		[NullCheck]
		public TMP_InputField txtInputDescription;

		[Header("Panel")]
		[NullCheck]
		public CanvasGroup mainGroup;

		[NullCheck]
		public SaveThumbnailViewer screenshotPreview;

		[Header("Button")]
		[NullCheck]
		public ButtonDV btnPack;

		[Header("Dialogs")]
		[NullCheck]
		public Popup messageDialog;

		[NullCheck]
		public Popup spinnerDialog;

		private ABugReportDataProvider provider;

		private ABugReportDataProvider.ReportComponent[] _components;

		private Popup spinnerInstance;

		private PopupManager _popupManager;

		private ABugReportDataProvider.ReportComponent[] Components => _components ?? (_components = InitializeComponents());

		private PopupManager PopupManager => this.FindPopupManager(ref _popupManager);

		protected override void Awake()
		{
			base.Awake();
			txtInputDescription.characterLimit = 300;
			txtCharCount.text = $"{0}/{300}";
		}

		private ABugReportDataProvider.ReportComponent[] InitializeComponents()
		{
			return new ABugReportDataProvider.ReportComponent[5]
			{
				new ABugReportDataProvider.ReportComponent("Basics", null, () => txtInputDescription.text.Length > 0, (List<ABugReportDataProvider.PackingPath> fileList) => provider.PackBasics(fileList, txtInputDescription.text), delegate
				{
					provider.CleanupBasics();
				}),
				new ABugReportDataProvider.ReportComponent("Logs", chkLogFiles, () => File.Exists(Path.Combine(Application.persistentDataPath, "Player.log")) || File.Exists(Path.Combine(Application.persistentDataPath, "Player-prev.log")), (List<ABugReportDataProvider.PackingPath> fileList) => provider.PackCurrentLog(fileList), delegate
				{
				}),
				new ABugReportDataProvider.ReportComponent("Screenshot", chkScreenshot, () => provider.CheckScreenshot(), (List<ABugReportDataProvider.PackingPath> fileList) => provider.PackScreenshot(fileList), delegate
				{
					provider.CleanupScreenshot();
				}),
				new ABugReportDataProvider.ReportComponent("SaveGames", chkSaveGames, () => provider.CheckSaveGames(), (List<ABugReportDataProvider.PackingPath> fileList) => provider.PackSaveGames(fileList), delegate
				{
					provider.CleanupSaveGames();
				}),
				new ABugReportDataProvider.ReportComponent("Telemetry", chkTelemetry, () => provider.CheckTelemetry(), (List<ABugReportDataProvider.PackingPath> fileList) => provider.PackTelemetry(fileList), delegate
				{
					provider.CleanupTelemetry();
				})
			};
		}

		public void SetProvider(ABugReportDataProvider provider)
		{
			this.provider = provider;
			if ((bool)this.provider)
			{
				CheckAvailability();
				CheckReportValidity();
			}
		}

		private void OnTextChanged(string text)
		{
			txtCharCount.text = $"{txtInputDescription.text.Length}/{300}";
		}

		private void OnEnable()
		{
			OnTextChanged(txtInputDescription.text);
			if ((bool)provider)
			{
				CheckAvailability();
				CheckReportValidity();
				if (provider.CheckScreenshot())
				{
					screenshotPreview.Show(provider.GetScreenshotForPreview(), provider.ShouldFlipScreenshotPreview());
				}
				else
				{
					screenshotPreview.Hide();
				}
			}
			else
			{
				screenshotPreview.Hide();
			}
			SetupListeners(on: true);
		}

		private void OnDisable()
		{
			SetupListeners(on: false);
		}

		private void CheckAvailability()
		{
			ABugReportDataProvider.ReportComponent[] components = Components;
			foreach (ABugReportDataProvider.ReportComponent reportComponent in components)
			{
				if ((bool)reportComponent.Checkbox)
				{
					if (reportComponent.IsAvailable)
					{
						reportComponent.Checkbox.ToggleInteractable(newInteractable: true);
						continue;
					}
					reportComponent.Checkbox.ToggleInteractable(newInteractable: false);
					reportComponent.Checkbox.isOn = false;
				}
			}
		}

		private void SetupListeners(bool on)
		{
			ABugReportDataProvider.ReportComponent[] components;
			if (on)
			{
				components = Components;
				foreach (ABugReportDataProvider.ReportComponent reportComponent in components)
				{
					if ((bool)reportComponent.Checkbox)
					{
						reportComponent.Checkbox.onValueChanged.AddListener(OnOptionChanged);
					}
				}
				txtInputDescription.onValueChanged.AddListener(OnTextChanged);
				btnPack.onClick.AddListener(OnPackClicked);
				return;
			}
			components = Components;
			foreach (ABugReportDataProvider.ReportComponent reportComponent2 in components)
			{
				if ((bool)reportComponent2.Checkbox)
				{
					reportComponent2.Checkbox.onValueChanged.RemoveListener(OnOptionChanged);
				}
			}
			txtInputDescription.onValueChanged.RemoveListener(OnTextChanged);
			btnPack.onClick.RemoveListener(OnPackClicked);
		}

		private void CheckReportValidity()
		{
			bool newInteractable = false;
			ABugReportDataProvider.ReportComponent[] components = Components;
			foreach (ABugReportDataProvider.ReportComponent reportComponent in components)
			{
				if ((bool)reportComponent.Checkbox && reportComponent.IsSelected)
				{
					newInteractable = true;
				}
			}
			btnPack.ToggleInteractable(newInteractable);
		}

		private void OnOptionChanged(bool on)
		{
			CheckReportValidity();
		}

		private void OnPackClicked()
		{
			if (!PopupManager.CanShowPopup())
			{
				Debug.LogError("Can't show popup in OnPackClicked? Probably bad setup, check $PopupManager.");
			}
			mainGroup.interactable = false;
			spinnerInstance = PopupManager.ShowPopup(spinnerDialog, new PopupLocalizationKeys
			{
				labelKey = "please_wait"
			});
			provider.PackingCoro(Components, delegate(string packageName)
			{
				spinnerInstance.RequestClose(PopupClosedByAction.Positive, "");
				spinnerInstance = null;
				PopupLocalizationKeys locKeys = new PopupLocalizationKeys
				{
					positiveKey = "ok",
					labelKey = "bugr/packsuccess"
				};
				Dictionary<string, string> locParams = new Dictionary<string, string> { { "FILENAME", packageName } };
				PopupManager.ShowPopup(messageDialog, locKeys, locParams).Closed += OnPopupClosed;
			}, HandleError).Forget();
		}

		private void HandleError(Exception ex)
		{
			if ((bool)spinnerInstance)
			{
				spinnerInstance.RequestClose(PopupClosedByAction.Abortion, "");
				spinnerInstance = null;
			}
			mainGroup.interactable = true;
			if (ex != null)
			{
				PopupLocalizationKeys locKeys = new PopupLocalizationKeys
				{
					positiveKey = "ok",
					labelKey = "bugr/packfail"
				};
				Dictionary<string, string> locParams = new Dictionary<string, string> { { "ERROR", ex.Message } };
				PopupManager.ShowPopup(messageDialog, locKeys, locParams);
				Debug.LogException(ex, this);
			}
		}

		private void OnPopupClosed(PopupResult result)
		{
			mainGroup.interactable = true;
			PauseMenuController componentInParent = GetComponentInParent<PauseMenuController>();
			if (componentInParent != null)
			{
				txtInputDescription.text = "";
				componentInParent.submenuController.SwitchMenu(0);
			}
		}
	}
}
