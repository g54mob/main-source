using System;
using System.Collections;
using System.Diagnostics;
using TMPro;
using UnityConsole;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace TH20
{
	public class UnhandledErrorDialogue : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _messageText;

		[SerializeField]
		private TextMeshProUGUI _stackTraceText;

		[SerializeField]
		private TextMeshProUGUI _instructionText;

		[SerializeField]
		private TextMeshProUGUI _timesShownText;

		[SerializeField]
		private Button _copyToClipboardButton;

		[SerializeField]
		private Button _openLogDirectoryButton;

		[SerializeField]
		private Button _openFogBugzIssueButton;

		[SerializeField]
		private Button _continueButton;

		[SerializeField]
		private Button _quitButton;

		private MonoBehaviour _behaviourToRunCoroutinesOn;

		private Action _onContinueAction;

		private int _timesShown;

		private bool _errorLoggedWhileSettingActive;

		private void Awake()
		{
			_copyToClipboardButton.onClick.AddListener(OnCopyToClipboardButtonClicked);
			_openLogDirectoryButton.onClick.AddListener(OnOpenLogDirectoryButtonClicked);
			_openFogBugzIssueButton.onClick.AddListener(OnOpenFogBugzIssueButtonClicked);
			_continueButton.onClick.AddListener(OnContinueButtonClicked);
			_quitButton.onClick.AddListener(OnQuitButtonClicked);
			string outputDirectory = Logging.Logger.GetLogHandler<FileLogHandler>().OutputDirectory;
			_instructionText.text += outputDirectory;
			ConsoleCommandsDatabase.RegisterCommand("ContinueFromUnhandledError", "Press the continue button on the unhandled error dialogue", "", DebugContinueFromUnhandledError);
		}

		public void Setup(MonoBehaviour behaviourToRunCoroutinesOn)
		{
			_behaviourToRunCoroutinesOn = behaviourToRunCoroutinesOn;
		}

		private void OnDestroy()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("ContinueFromUnhandledError");
		}

		private void OnOpenLogDirectoryButtonClicked()
		{
			Process.Start(Logging.Logger.GetLogHandler<FileLogHandler>().OutputDirectory);
		}

		private void OnCopyToClipboardButtonClicked()
		{
			GUIUtility.systemCopyBuffer = $"Message:\n{_messageText.text}\n\nCallstack:\n{_stackTraceText.text}";
		}

		private void OnOpenFogBugzIssueButtonClicked()
		{
			int num = "https://sqa.sega.co.uk/secure/CreateIssueDetails!init.jspa?pid=10104&issuetype=10202&summary={0}&description={1}".Length - 6;
			string text = ((_messageText.text.Length > 200) ? _messageText.text.Substring(0, 200) : _messageText.text);
			text = text.Replace("\r", " ").Replace("\n", " ");
			string text2 = UnityWebRequest.EscapeURL(text);
			if (num + text2.Length > 2000)
			{
				int length = Math.Max(0, num + text2.Length - 2000);
				text2 = UnityWebRequest.EscapeURL(text.Substring(0, length));
			}
			string text3 = UnityWebRequest.EscapeURL("*Write a description here, choose a nice title, add log files (open the log file folder, there's a button) and screenshots (print screen and paste here), then delete this bit!*\n\n" + _messageText.text + "\n\n\nStack trace:\n\n{{" + _stackTraceText.text + "}}");
			if (num + text2.Length + text3.Length > 2000)
			{
				text3 = UnityWebRequest.EscapeURL("Error message was too big - copied to clipboard - please paste here!");
				OnCopyToClipboardButtonClicked();
			}
			Process.Start($"https://sqa.sega.co.uk/secure/CreateIssueDetails!init.jspa?pid=10104&issuetype=10202&summary={text2}&description={text3}");
		}

		private void OnContinueButtonClicked()
		{
			base.gameObject.SetActive(value: false);
			if (_onContinueAction != null)
			{
				_onContinueAction();
			}
		}

		private void OnQuitButtonClicked()
		{
			QuitGame.Quit();
		}

		public void Show(string message, string stackTrace, bool canBeContinuedFrom, Action onContinueAction)
		{
			try
			{
				Application.logMessageReceived += CheckLogForErrorMessages;
				_errorLoggedWhileSettingActive = false;
				base.gameObject.SetActive(value: true);
				if (_errorLoggedWhileSettingActive)
				{
					_behaviourToRunCoroutinesOn.StartCoroutine(FixGameObjectCoroutine());
				}
				_onContinueAction = onContinueAction;
				_messageText.text = message;
				_stackTraceText.text = stackTrace;
				_continueButton.interactable = canBeContinuedFrom;
				_timesShown++;
				_timesShownText.text = "Error " + _timesShown;
			}
			finally
			{
				Application.logMessageReceived -= CheckLogForErrorMessages;
			}
		}

		private void CheckLogForErrorMessages(string condition, string stackTrace, LogType type)
		{
			if (type == LogType.Error || type == LogType.Assert || type == LogType.Exception)
			{
				_errorLoggedWhileSettingActive = true;
			}
		}

		private IEnumerator FixGameObjectCoroutine()
		{
			yield return null;
			base.gameObject.SetActive(value: false);
			base.gameObject.SetActive(value: true);
		}

		public void OverrideContinuable(bool continuable)
		{
			_continueButton.interactable = continuable;
		}

		private ConsoleCommandResult DebugContinueFromUnhandledError(string[] args)
		{
			OnContinueButtonClicked();
			return ConsoleCommandResult.Succeeded();
		}
	}
}
