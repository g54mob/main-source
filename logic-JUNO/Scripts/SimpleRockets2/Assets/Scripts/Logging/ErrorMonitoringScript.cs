using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Assets.Scripts.Sharing;
using Assets.Scripts.Sharing.Handlers.BugReport;
using Assets.Scripts.Sharing.Handlers.Sandbox;
using ModApi;
using ModApi.Common.Textures;
using ModApi.Input;
using ModApi.Ui;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Logging
{
	public class ErrorMonitoringScript : MonoBehaviour
	{
		public const string ErrorReportsFolder = "BugReports";

		private const string ImageFilePrefix = "BugReportImage_";

		private const string InputStateFileName = "InputState.txt";

		private const string LogFileName = "Log.txt";

		private const string SandboxXmlFileName = "Sandbox.xml";

		private int _reportCount;

		public string FullyQualifiedErrorReportsFolder => Utilities.CombinePaths(Application.persistentDataPath, "BugReports");

		public void Awake()
		{
			LogHistory.Instance.RootErrorOccurred += OnRootErrorOccurred;
			SceneManager.sceneLoaded += OnSceneLoaded;
		}

		private static byte[] FormatScreenshot(Texture2D screenshot)
		{
			return SandboxFormData.PictureFormat switch
			{
				SandboxFormData.PictureFormatType.JPG => screenshot.EncodeToJPG(), 
				SandboxFormData.PictureFormatType.PNG => screenshot.EncodeToPNG(), 
				_ => throw new InvalidOperationException(string.Format("Unsupported picture format:", SandboxFormData.PictureFormat)), 
			};
		}

		private static string GetInputState()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("===== Configured Inputs =====");
			foreach (IGameInput allInput in Game.Instance.InputManager.Inputs.AllInputs)
			{
				stringBuilder.AppendFormat("{0} - isDown: {1}, downThisFrame: {2}, upThisFrame: {3}, axis: {4}\n", allInput.DescriptiveName.PadRight(50, ' '), allInput.GetButton(), allInput.GetButtonDown(), allInput.GetButtonUp(), allInput.GetAxis());
			}
			stringBuilder.AppendLine("\n===== Raw Inputs =====");
			foreach (KeyCode value in Enum.GetValues(typeof(KeyCode)))
			{
				if (UnityEngine.Input.GetKeyDown(value))
				{
					stringBuilder.AppendFormat("{0} downThisFrame", value.ToString().PadRight(20, ' '));
				}
			}
			foreach (KeyCode value2 in Enum.GetValues(typeof(KeyCode)))
			{
				if (UnityEngine.Input.GetKeyDown(value2))
				{
					stringBuilder.AppendFormat("{0} upThisFrame", value2.ToString().PadRight(20, ' '));
				}
			}
			foreach (KeyCode value3 in Enum.GetValues(typeof(KeyCode)))
			{
				if (UnityEngine.Input.GetKey(value3))
				{
					stringBuilder.AppendFormat("{0} isDown\n", value3.ToString().PadRight(20, ' '));
				}
			}
			return stringBuilder.ToString();
		}

		private static void SaveScreenshot(Texture2D screenshot, string reportFolder)
		{
			byte[] bytes = FormatScreenshot(screenshot);
			File.WriteAllBytes(Utilities.CombinePaths(reportFolder, string.Format("{0}0.{1}", "BugReportImage_", SandboxFormData.PictureExtension)), bytes);
		}

		private void CreateErrorReport()
		{
			GetBugReportScreenshots(delegate(Texture2D screenshot)
			{
				string text = Utilities.CombinePaths(FullyQualifiedErrorReportsFolder, Guid.NewGuid().ToString());
				Directory.CreateDirectory(text);
				if (Game.InFlightScene)
				{
					SandboxFormData.CreateFromCurrentSandbox("AutoReport", GetDescription(), isPublic: false, validPhotoChecksums: true, new List<Texture2D> { screenshot }).SaveXml(text, "Sandbox.xml");
				}
				else
				{
					SaveScreenshot(screenshot, text);
					if (Game.InDesignerScene)
					{
						Debug.LogWarning("Reminder: Add designer-related reporting data to error report.");
					}
				}
				File.WriteAllText(Utilities.CombinePaths(text, "Log.txt"), LogHistory.Instance.GenerateReport(rootErrorsOnly: false, clearAfter: false));
				string inputState = GetInputState();
				File.WriteAllText(Utilities.CombinePaths(text, "InputState.txt"), inputState.ToString());
			});
		}

		private void DeleteUnsentBugReports()
		{
			try
			{
				Utilities.DeleteDirectoryFromPersistentData(FullyQualifiedErrorReportsFolder, recursive: true);
			}
			catch (Exception ex)
			{
				Debug.LogWarningFormat("Couldn't remove bug report folder: {0}", ex.Message);
			}
		}

		private void GetBugReportScreenshots(Action<Texture2D> onComplete)
		{
			Screenshots.TakeScreenShot(new Vector2i(1280, 720), onComplete);
		}

		private string GetDescription()
		{
			return $"Auto-generated report from error logged in \"{SceneManager.GetActiveScene().name}\"";
		}

		private bool HasUnreportedErrors()
		{
			bool result = false;
			if (Directory.Exists(FullyQualifiedErrorReportsFolder))
			{
				DirectoryInfo[] array = new DirectoryInfo(FullyQualifiedErrorReportsFolder)?.GetDirectories();
				result = array != null && array.Count() > 0;
			}
			return result;
		}

		private void OnBugReportSendCompleted(WebsiteRequest request)
		{
			_reportCount--;
			if (!request.Success)
			{
				Debug.LogWarningFormat("Auto-generated bug report could not be sent: {0}", request.Error);
			}
			if (_reportCount == 0)
			{
				DeleteUnsentBugReports();
				Debug.Log("All bug reports processed, removing bug reports folder.");
			}
		}

		private void OnRootErrorOccurred(LogHistory source, LogHistory.LogEntry entry)
		{
			if (!entry.StackTrace.Contains("ErrorMonitoringScript"))
			{
				CreateErrorReport();
			}
		}

		private void OnSceneLoaded(Scene newScene, LoadSceneMode mode)
		{
			if (HasUnreportedErrors())
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				messageDialogScript.MessageText = "It looks like a problem occurred earlier. Would you help improve the game? Click Okay to send us a bug report.";
				messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
				{
					ProcessBugReports();
					d.Close();
				};
				messageDialogScript.CancelClicked += delegate(MessageDialogScript d)
				{
					DeleteUnsentBugReports();
					d.Close();
				};
			}
		}

		private void ProcessBugReports()
		{
			try
			{
				DirectoryInfo[] directories = new DirectoryInfo(FullyQualifiedErrorReportsFolder).GetDirectories();
				foreach (DirectoryInfo directoryInfo in directories)
				{
					FileInfo fileInfo = directoryInfo.GetFiles("Log.txt").FirstOrDefault();
					if (fileInfo != null)
					{
						try
						{
							_reportCount++;
							FileInfo fileInfo2 = directoryInfo.GetFiles("Sandbox.xml").FirstOrDefault();
							XDocument sandboxData = ((fileInfo2 != null) ? XDocument.Load(fileInfo2.FullName) : null);
							FileInfo fileInfo3 = directoryInfo.GetFiles("InputState.txt").FirstOrDefault();
							string inputState = ((fileInfo3 != null) ? File.ReadAllText(fileInfo3.FullName) : null);
							Dictionary<string, byte[]> dictionary = new Dictionary<string, byte[]>();
							FileInfo[] files = directoryInfo.GetFiles(string.Format("*{0}*", "BugReportImage_"));
							foreach (FileInfo fileInfo4 in files)
							{
								dictionary.Add(Path.GetFileNameWithoutExtension(fileInfo4.FullName), File.ReadAllBytes(fileInfo4.FullName));
							}
							SendBugReport(sandboxData, File.ReadAllText(fileInfo.FullName), inputState, dictionary);
						}
						catch (Exception ex)
						{
							_reportCount--;
							Debug.LogWarningFormat("An exception was thrown while processing a bug report: {0}", ex.Message);
						}
					}
					else
					{
						Debug.LogWarning("Couldn't find log file for bug report.");
					}
				}
			}
			catch (Exception ex2)
			{
				Debug.LogWarningFormat("An exception was thrown while processing bug reports: {0}", ex2.Message);
			}
			if (_reportCount <= 0)
			{
				DeleteUnsentBugReports();
			}
		}

		private void SendBugReport(XDocument sandboxData, string logFileContents, string inputState, Dictionary<string, byte[]> screenshots)
		{
			BugReportUpload handler = new BugReportUpload(sandboxData, logFileContents, inputState, screenshots);
			WebsiteRequest websiteRequest = new WebsiteRequest(Game.SimpleRocketsWebsiteUrl, handler);
			websiteRequest.Completed += OnBugReportSendCompleted;
			websiteRequest.SendRequest();
		}
	}
}
