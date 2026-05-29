using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using CTS.BBT;
using CTS.Core;
using CTS.Report;
using CTS.UI;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace CTS
{
	public class ReportInterface : CTSSingleton<ReportInterface>
	{
		[BoxGroup("Base Settings")]
		[Space(10f)]
		public ErrorResponseDataSO _errorResponseDataSO;

		[BoxGroup("Base Settings")]
		[Space(10f)]
		public StringKey _optionUIStringKey;

		[BoxGroup("Base Settings")]
		[Space(10f)]
		public PaletteData _paletteColorGreen;

		[BoxGroup("Base Settings")]
		public PaletteData _paletteColorRed;

		[SerializeField]
		[BoxGroup("Link GameObject")]
		[Space(10f)]
		private CanvasGroupController _canvasGroupController;

		[SerializeField]
		[BoxGroup("Link GameObject")]
		private GameObject _noInternetContent;

		[SerializeField]
		[BoxGroup("Link GameObject")]
		private GameObject _complianceContent;

		[SerializeField]
		[BoxGroup("Link GameObject")]
		private GameObject _internetContent;

		[SerializeField]
		[BoxGroup("Link GameObject")]
		private GameObject _loadingContent;

		[SerializeField]
		[BoxGroup("Link GameObject")]
		private GameObject _PostRequestContent;

		[SerializeField]
		[BoxGroup("Link Component")]
		[Space(10f)]
		private Toggle _complianceCheckBox;

		[SerializeField]
		[BoxGroup("Link Component")]
		private TMP_InputField _reportContentText;

		[SerializeField]
		[BoxGroup("Link Component")]
		private TMP_Text _resultMessageText;

		[SerializeField]
		[BoxGroup("Link Component")]
		private Image _borderColorMessage;

		private Dictionary<int, ErrorResponseDataSO.ErrorData> _errorHandlers = new Dictionary<int, ErrorResponseDataSO.ErrorData>();

		private SaveManager[] _saveManagers;

		private LockToggle _timeScaleToggler;

		private GameObject _currentContent;

		private bool _complianceAccepted;

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		protected override void OnEnabled()
		{
			_timeScaleToggler = new LockToggle(MonoSingleton<TimeController>.Instance);
			ErrorResponseDataSO.ErrorData[] errorDataArray = _errorResponseDataSO.errorDataArray;
			foreach (ErrorResponseDataSO.ErrorData errorData in errorDataArray)
			{
				if (!_errorHandlers.ContainsKey(errorData.errorCode))
				{
					_errorHandlers.Add(errorData.errorCode, errorData);
				}
			}
			ReportManager.ReceivedAServerAnswer += PostRequestResult;
		}

		protected override void OnDisabled()
		{
			ReportManager.ReceivedAServerAnswer -= PostRequestResult;
		}

		private void PostRequestResult(int errorCode)
		{
			SwitchContent(EReportContent.PostRequest);
			if (_errorHandlers.TryGetValue(errorCode, out var value))
			{
				_borderColorMessage.color = value.borderColor.GetColor();
				_resultMessageText.text = value.messageKey.GetLocalizedString();
			}
			else
			{
				HandleUnknownError(errorCode);
			}
		}

		private bool IsConnectedToInternet()
		{
			try
			{
				using WebClient webClient = new WebClient();
				using (webClient.OpenRead("http://www.google.com"))
				{
					return true;
				}
			}
			catch (SocketException ex)
			{
				Debug.LogError("[IsConnectedToInternet] SocketException occurred: " + ex.Message);
				return false;
			}
			catch (Exception ex2)
			{
				Debug.LogError("[IsConnectedToInternet] General Exception occurred: " + ex2.Message);
				return false;
			}
		}

		private void HandleUnknownError(int errorCode)
		{
			_borderColorMessage.color = _paletteColorRed;
			string text = $"[Report Exception] SocketException occurred: {errorCode}";
			_resultMessageText.text = text;
			Debug.LogError(text ?? "");
		}

		private void SwitchContent(EReportContent content)
		{
			if ((bool)_currentContent)
			{
				_currentContent.SetActive(value: false);
			}
			switch (content)
			{
			case EReportContent.NoInternet:
				_currentContent = _noInternetContent;
				break;
			case EReportContent.Compliance:
				_currentContent = _complianceContent;
				break;
			case EReportContent.Internet:
				_currentContent = _internetContent;
				break;
			case EReportContent.Loading:
				_currentContent = _loadingContent;
				break;
			case EReportContent.PostRequest:
				_currentContent = _PostRequestContent;
				break;
			}
			_currentContent.SetActive(value: true);
		}

		private string CreateDebugSave()
		{
			if (CTSSingleton<ProfileManager>.Instance.CurrentProfile == null)
			{
				return null;
			}
			_saveManagers = CTSSingleton<ProfileManager>.Instance.GetComponentsInChildren<SaveManager>(includeInactive: true);
			string text = CTSSingleton<ProfileManager>.Instance.CurrentProfile.GetName();
			string text2 = "BugReport/" + text;
			SaveManager[] saveManagers = _saveManagers;
			foreach (SaveManager saveManager in saveManagers)
			{
				saveManager.Save(saveManager.name switch
				{
					"DialogueSave" => text2 + "/dialogueData", 
					"ProfileSave" => text2 + "/profile", 
					"SceneSave" => text2 + "/" + CTSSingleton<GameMode>.Instance.LevelInfo.name, 
					_ => text2 + "/" + saveManager.name, 
				});
			}
			return text2;
		}

		public void Open()
		{
			_timeScaleToggler.Lock();
			_canvasGroupController.QuickShow();
			if (MonoSingleton<CanvasGroupManager>.Instance.TryGet(_optionUIStringKey, out var controller))
			{
				controller.QuickHide();
			}
			if (!IsConnectedToInternet())
			{
				SwitchContent(EReportContent.NoInternet);
			}
			else if (_complianceAccepted)
			{
				_reportContentText.text = "";
				SwitchContent(EReportContent.Internet);
			}
			else
			{
				SwitchContent(EReportContent.Compliance);
			}
		}

		public void Close()
		{
			_canvasGroupController.QuickHide();
			if (MonoSingleton<CanvasGroupManager>.Instance.TryGet(_optionUIStringKey, out var controller))
			{
				controller.QuickShow();
			}
			_timeScaleToggler.Unlock();
		}

		public void AcceptCompliance()
		{
			if (_complianceCheckBox.isOn)
			{
				_complianceAccepted = true;
				SwitchContent(EReportContent.Internet);
			}
		}

		public void TryToSendAReport()
		{
			string text = _reportContentText.text;
			if (!string.IsNullOrEmpty(text))
			{
				SwitchContent(EReportContent.Loading);
				base.gameObject.scene.StartCoroutine(CaptureAndSendCoroutine(text));
			}
		}

		private IEnumerator CaptureAndSendCoroutine(string reportContent)
		{
			string persistentDataPath = Application.persistentDataPath;
			string text = persistentDataPath + "/ReportTemp/";
			string text2 = "ReportData.zip";
			string text3 = text + text2;
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			if (File.Exists(text3))
			{
				File.Delete(text3);
			}
			List<string> list = new List<string>();
			if (CTSSingleton<GameMode>.InstanceExists())
			{
				SaveManager[] componentsInChildren = CTSSingleton<ProfileManager>.Instance.GetComponentsInChildren<SaveManager>(includeInactive: true);
				if (componentsInChildren.Length == 0)
				{
					throw new NullReferenceException("Couldn't find any manager to save");
				}
				SaveManager[] array = componentsInChildren;
				foreach (SaveManager saveManager in array)
				{
					string text4 = saveManager.name;
					string text5 = ((!text4.Contains("Scene")) ? ((!text4.Contains("Dialogue")) ? ((!text4.Contains("Profile")) ? ("Snap_" + saveManager.name) : "profile") : "dialogueData") : CTSSingleton<GameMode>.Instance.LevelInfo.name);
					saveManager.Save(text5);
					list.Add(text5 + ".sav");
				}
			}
			ES3Settings globalFolderSettings = SaveSettings.GetGlobalFolderSettings();
			globalFolderSettings.path = "Saves/";
			if (!ES3.DirectoryExists(globalFolderSettings))
			{
				Debug.LogException(new NullReferenceException("Nothing was saved?"));
			}
			using (ZipArchive destination = ZipFile.Open(text3, ZipArchiveMode.Create))
			{
				string path = persistentDataPath + "/Player.log";
				string text6 = persistentDataPath + "/ReportLog.log";
				if (File.Exists(path))
				{
					using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
					{
						using FileStream destination2 = File.OpenWrite(text6);
						fileStream.CopyTo(destination2);
					}
					destination.CreateEntryFromFile(text6, "Player.log");
				}
				path = persistentDataPath + "/Player-prev.log";
				if (File.Exists(path))
				{
					destination.CreateEntryFromFile(path, "Player-prev.log");
				}
				string text7 = CTSSingleton<ProfileManager>.Instance.CurrentProfile.GetName();
				foreach (string item in list)
				{
					globalFolderSettings.path = "Saves/" + item;
					if (ES3.FileExists(globalFolderSettings))
					{
						destination.CreateEntryFromFile(globalFolderSettings.FullPath, text7 + "_Snapshot/" + item);
						ES3.DeleteFile(globalFolderSettings);
					}
				}
				globalFolderSettings.path = "Saves/" + text7 + "/";
				if (ES3.DirectoryExists(globalFolderSettings))
				{
					string fullPath = globalFolderSettings.FullPath;
					string[] files = ES3.GetFiles(globalFolderSettings);
					foreach (string text8 in files)
					{
						if (text8.EndsWith(".sav"))
						{
							destination.CreateEntryFromFile(fullPath + text8, text7 + "/" + text8);
						}
					}
				}
			}
			WWWForm wWWForm = new WWWForm();
			string systemSpecs = GetSystemSpecs();
			wWWForm.AddField("systemSpecs", systemSpecs);
			wWWForm.AddField("gameVersion", Application.version);
			wWWForm.AddField("reportContent", reportContent);
			wWWForm.AddField("logFilesFolder", "");
			byte[] contents = File.ReadAllBytes(persistentDataPath + "/unity_logs.txt");
			wWWForm.AddBinaryData("logFile", contents, "unity_logs.txt", "text/plain");
			byte[] contents2 = File.ReadAllBytes(text3);
			string fileName = "ReportData.zip";
			wWWForm.AddBinaryData("saveFile[]", contents2, fileName, "application/octet-stream");
			UnityWebRequest www = UnityWebRequest.Post("https://api.clever-trickster.com/BloodBarTycoon/ClientApi/report.php", wWWForm);
			yield return www.SendWebRequest();
			PostRequestResult((int)www.responseCode);
		}

		private string GetSystemSpecs()
		{
			string processorType = SystemInfo.processorType;
			string text = SystemInfo.systemMemorySize + " MB";
			string graphicsDeviceName = SystemInfo.graphicsDeviceName;
			string operatingSystem = SystemInfo.operatingSystem;
			string text2 = Screen.width + "x" + Screen.height;
			return "CPU: " + processorType + "<br />RAM: " + text + "<br />GPU: " + graphicsDeviceName + "<br />OS: " + operatingSystem + "<br />Resolution: " + text2;
		}
	}
}
