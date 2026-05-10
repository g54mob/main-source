using System;
using System.Collections;
using System.IO;
using System.Threading.Tasks;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Networking;

namespace CTS.Report
{
	public class ReportManager : MonoSingleton<ReportManager>
	{
		[BoxGroup("Base Settings")]
		[Space(10f)]
		public string ProjectID = "Project";

		private string logFilePath;

		private string logContent;

		private string message = "test";

		public static event Action<int> ReceivedAServerAnswer;

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void Start()
		{
			Application.logMessageReceived += HandleLog;
			logFilePath = Path.Combine(Application.persistentDataPath, "unity_logs.txt");
			File.WriteAllText(logFilePath, string.Empty);
		}

		private void OnDestroy()
		{
			Application.logMessageReceived -= HandleLog;
		}

		private async Task<string> ReadLogFileAsync(string path)
		{
			return await Task.Run(() => File.ReadAllText(path));
		}

		private void HandleLog(string logString, string stackTrace, LogType type)
		{
			try
			{
				File.AppendAllText(logFilePath, logString + "\n" + stackTrace + "\n");
			}
			catch (Exception ex)
			{
				Debug.LogError("Failed to write log: " + ex.Message);
			}
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

		[Button("Send Test Report", EButtonEnableMode.Always)]
		public void CaptureAndUpload(string reportContent = null, string debugProfileName = null)
		{
			if (string.IsNullOrEmpty(reportContent))
			{
				reportContent = message;
			}
			StartCoroutine(CaptureAndSendCoroutine(reportContent, debugProfileName));
		}

		private IEnumerator CaptureAndSendCoroutine(string reportContent, string debugProfileName = null)
		{
			if (!File.Exists(logFilePath))
			{
				yield break;
			}
			byte[] contents = File.ReadAllBytes(logFilePath);
			WWWForm wWWForm = new WWWForm();
			string systemSpecs = GetSystemSpecs();
			wWWForm.AddField("systemSpecs", systemSpecs);
			wWWForm.AddField("gameVersion", Application.version);
			wWWForm.AddField("reportContent", reportContent);
			wWWForm.AddField("logFilesFolder", debugProfileName);
			wWWForm.AddBinaryData("logFile", contents, "unity_logs.txt", "text/plain");
			string text = Path.Combine(Application.persistentDataPath, "Saves/" + debugProfileName);
			if (Directory.Exists(text))
			{
				string[] files = Directory.GetFiles(text, "*.sav");
				foreach (string path in files)
				{
					byte[] contents2 = File.ReadAllBytes(path);
					string fileName = Path.GetFileName(path);
					wWWForm.AddBinaryData("saveFile[]", contents2, fileName, "application/octet-stream");
				}
			}
			else
			{
				Debug.LogWarning("Save directory not found: " + text);
			}
			UnityWebRequest www = UnityWebRequest.Post("https://api.clever-trickster.com/" + ProjectID + "/ClientApi/report.php", wWWForm);
			yield return www.SendWebRequest();
			ReportManager.ReceivedAServerAnswer?.Invoke((int)www.responseCode);
		}
	}
}
