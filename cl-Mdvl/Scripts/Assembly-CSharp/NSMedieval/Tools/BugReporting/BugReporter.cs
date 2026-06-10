using System;
using System.Collections.Generic;
using System.Linq;
using Controller;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Modding;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;

namespace NSMedieval.Tools.BugReporting
{
	[Serializable]
	public class BugReporter : MonoBehaviour, IPauseGame
	{
		[Serializable]
		public enum WindowType
		{
			None = 0,
			MainWindow = 1,
			Sending = 2,
			ErrorOccured = 3,
			Quitting = 4,
			QuittingNoReport = 5,
			ModsDetected = 6
		}

		[Serializable]
		public class WindowTypePair
		{
			[SerializeField]
			private WindowType type;

			[SerializeField]
			private CanvasRenderer renderer;

			public WindowType Type => type;

			public CanvasRenderer Renderer => renderer;

			public WindowTypePair(WindowType type, CanvasRenderer renderer)
			{
				this.type = type;
				this.renderer = renderer;
			}
		}

		private static readonly Dictionary<BugReporterJiraAPI.ReportType, string> ReportCategories = new Dictionary<BugReporterJiraAPI.ReportType, string>
		{
			{
				BugReporterJiraAPI.ReportType.Bug,
				"report_category_bug"
			},
			{
				BugReporterJiraAPI.ReportType.Feedback,
				"report_category_feedback"
			},
			{
				BugReporterJiraAPI.ReportType.Feature,
				"report_category_suggestion"
			}
		};

		private static readonly Dictionary<BugReporterJiraAPI.ReportPriority, string> ReportPriorities = new Dictionary<BugReporterJiraAPI.ReportPriority, string>
		{
			{
				BugReporterJiraAPI.ReportPriority.Low,
				"report_priority_low"
			},
			{
				BugReporterJiraAPI.ReportPriority.Medium,
				"report_priority_medium"
			},
			{
				BugReporterJiraAPI.ReportPriority.High,
				"report_priority_high"
			}
		};

		[SerializeField]
		private Canvas rootCanvas;

		[SerializeField]
		private WindowTypePair[] stateCanvases;

		[SerializeField]
		private TMP_Dropdown category;

		[SerializeField]
		private TMP_Dropdown priority;

		[SerializeField]
		private TMP_InputField subject;

		[SerializeField]
		private TMP_InputField message;

		[SerializeField]
		private SoundButton submitButton;

		[SerializeField]
		private SoundButton closeButton;

		private WindowType currentState;

		private int minimumTitleLenght = 4;

		private int minimumMessageLenght = 10;

		public WindowType CurrentState => currentState;

		private void Start()
		{
			closeButton.onClick.AddListener(Close);
		}

		public void Show(WindowType initialState = WindowType.MainWindow)
		{
			LocalizationController localize = MonoSingleton<LocalizationController>.Instance;
			category.ClearOptions();
			category.AddOptions(ReportCategories.Values.Select((string item) => localize.GetText(item)).ToList());
			priority.ClearOptions();
			priority.AddOptions(ReportPriorities.Values.Select((string item) => localize.GetText(item)).ToList());
			submitButton.onClick.RemoveAllListeners();
			submitButton.onClick.AddListener(OnSubmitButton);
			ScreenCapture.CaptureScreenshot(BugReporterJiraAPI.ScreenShotPath);
			if (initialState == WindowType.MainWindow && MonoSingleton<ModManager>.Instance.EnabledMods.Values.Any())
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					ShowState(WindowType.ModsDetected);
				});
			}
			else
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					ShowState(initialState);
				});
			}
			if (MonoSingleton<InputManager>.IsInstantiated())
			{
				MonoSingleton<InputManager>.Instance.SetInputEnabled(value: false);
			}
			if (MonoSingleton<GlobalKeybindingManager>.IsInstantiated())
			{
				MonoSingleton<GlobalKeybindingManager>.Instance.SubscribeToEscapeKey(Close, base.gameObject);
			}
			if (MonoSingleton<GameplayPauseManager>.IsInstantiated())
			{
				MonoSingleton<GameplayPauseManager>.Instance.Register(this);
			}
		}

		public void Close()
		{
			ShowState(WindowType.None);
			if (MonoSingleton<InputManager>.IsInstantiated())
			{
				MonoSingleton<InputManager>.Instance.SetInputEnabled(value: true);
			}
			if (MonoSingleton<GlobalKeybindingManager>.IsInstantiated())
			{
				MonoSingleton<GlobalKeybindingManager>.Instance.UnsubscribeFromEscapeKey(Close, base.gameObject);
			}
			if (MonoSingleton<GameplayPauseManager>.IsInstantiated())
			{
				MonoSingleton<GameplayPauseManager>.Instance.Unregister(this);
			}
		}

		private void OnSubmitButton()
		{
			string text = subject.text.Trim();
			string text2 = message.text.Trim();
			if (string.IsNullOrEmpty(text) || text.Length < minimumTitleLenght)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("report_title_lenght_warning"));
				return;
			}
			if (string.IsNullOrEmpty(text2) || text2.Length < minimumMessageLenght)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("report_message_lenght_warning"));
				return;
			}
			submitButton.onClick.RemoveAllListeners();
			BugReporterJiraAPI.ReportType reportType = BugReporterJiraAPI.ReportType.Bug;
			BugReporterJiraAPI.ReportPriority reportPriority = ReportPriorities.Keys.ToList()[priority.value];
			MonoSingleton<BugReporterJiraAPI>.Instance.SubmitReport(reportPriority, reportType, text, text2, SubmitReportDoneCallback);
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				ShowState(WindowType.Sending);
			});
		}

		private void SubmitReportDoneCallback(BugReporterJiraAPI.ReportStatus status)
		{
			Log.Info("Submit done. Status: " + status, "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\BugReporting\\BugReporter.cs");
			if (status == BugReporterJiraAPI.ReportStatus.Error)
			{
				Log.Error("Failed to upload report!", "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\BugReporting\\BugReporter.cs");
				Show(WindowType.ErrorOccured);
				return;
			}
			message.text = "";
			subject.text = "";
			category.value = 1;
			priority.value = 0;
			Log.Info("Report uploaded successfully", "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\BugReporting\\BugReporter.cs");
		}

		private void OnStateChanged()
		{
			if (currentState == WindowType.Sending)
			{
				MonoSingleton<TaskController>.Instance.WaitForUnscaled(4f).Then(delegate
				{
					if (currentState == WindowType.Sending)
					{
						Close();
					}
				});
				return;
			}
			if (currentState == WindowType.ModsDetected)
			{
				MonoSingleton<UIController>.Instance.PromptPanel.OpenPanel(new PromptPanelData("mods_in_game_warning_report".ToLocalized(), new List<KeyValuePair<string, Action>> { KeyValuePair.Create<string, Action>("general_ok".ToLocalized(), CloseModsDetected) }), handleInput: false);
				rootCanvas.gameObject.SetActive(value: false);
				return;
			}
			if (currentState == WindowType.ErrorOccured)
			{
				MonoSingleton<TaskController>.Instance.WaitForUnscaled(4f).Then(delegate
				{
					if (currentState == WindowType.ErrorOccured)
					{
						Close();
					}
				});
			}
			_ = currentState;
			_ = 4;
		}

		private void CloseModsDetected()
		{
			rootCanvas.gameObject.SetActive(value: true);
			MonoSingleton<UIController>.Instance.PromptPanel.Hide();
			ShowState(WindowType.MainWindow);
		}

		private void ShowState(WindowType type)
		{
			if (currentState != WindowType.None)
			{
				CanvasRenderer stateCanvas = GetStateCanvas(currentState);
				if (stateCanvas != null)
				{
					currentState = type;
					stateCanvas.gameObject.SetActive(value: false);
				}
				else
				{
					Log.Error("This should never happen", "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\BugReporting\\BugReporter.cs");
				}
			}
			currentState = type;
			if (currentState == WindowType.None)
			{
				rootCanvas.gameObject.SetActive(value: false);
				OnStateChanged();
				return;
			}
			rootCanvas.gameObject.SetActive(value: true);
			CanvasRenderer stateCanvas2 = GetStateCanvas(currentState);
			if (stateCanvas2 == null)
			{
				Log.Error("This should never happen", "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\BugReporting\\BugReporter.cs");
			}
			stateCanvas2.gameObject.SetActive(value: true);
			OnStateChanged();
		}

		private CanvasRenderer GetStateCanvas(WindowType type)
		{
			if (stateCanvases == null || stateCanvases.Length == 0)
			{
				return null;
			}
			return stateCanvases.FirstOrDefault((WindowTypePair item) => item.Type == type)?.Renderer;
		}
	}
}
