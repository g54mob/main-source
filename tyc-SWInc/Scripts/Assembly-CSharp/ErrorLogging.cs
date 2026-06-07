using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ErrorLogging : MonoBehaviour
{
	public static bool First = true;

	public static bool Created = false;

	public static int LoggedErrors = 0;

	public static bool FirstOfScene = true;

	public static bool Modded = false;

	public static bool SceneChanging = false;

	private static int _lastScreenHeight = 0;

	private static int _lastScreenWidth = 0;

	private static readonly List<Exception> Manuals = new List<Exception>();

	private static readonly List<Exception> SaveErrors = new List<Exception>();

	public List<int> Logged = new List<int>();

	private bool unbind;

	private bool unbind2;

	private float _lastResChange = -1f;

	private static uint _logCount;

	public static Regex StackClean = new Regex("\\(at <[a-zA-Z0-9]+>:0\\)");

	private void Awake()
	{
		_lastScreenHeight = Screen.height;
		_lastScreenWidth = Screen.width;
		if (Created)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		unbind = true;
		unbind2 = true;
		Created = true;
		Application.logMessageReceived += HandleLog;
		Application.logMessageReceived += HandleLogCheck;
		SceneManager.activeSceneChanged += SceneChange;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	private void SceneChange(Scene arg0, Scene scene)
	{
		SceneChanging = false;
	}

	private void Start()
	{
		if (First)
		{
			Options.UpdateResolution();
			First = false;
		}
	}

	private void OnDestroy()
	{
		if (unbind)
		{
			Application.logMessageReceived -= HandleLog;
			SceneManager.activeSceneChanged -= SceneChange;
		}
		if (unbind2)
		{
			Application.logMessageReceived -= HandleLogCheck;
		}
	}

	public static void AddException(Exception ex)
	{
		lock (Manuals)
		{
			Manuals.Add(ex);
		}
	}

	public static void AddSaveError(Exception ex)
	{
		lock (Manuals)
		{
			SaveErrors.Add(ex);
		}
	}

	private void Update()
	{
		if (Manuals.Count > 0)
		{
			lock (Manuals)
			{
				for (int i = 0; i < Manuals.Count; i++)
				{
					Debug.LogException(Manuals[i]);
				}
				Manuals.Clear();
				for (int j = 0; j < SaveErrors.Count; j++)
				{
					if (WindowManager.Instance != null)
					{
						WindowManager.SpawnDialog("SaveFailIOError".Loc(SaveErrors[j].Message), true, DialogWindow.DialogType.Error);
					}
					Debug.LogError("Ignore: Save IO Error:\n" + SaveErrors[j]);
				}
				SaveErrors.Clear();
			}
		}
		if (GameData.UserImagesDirty)
		{
			GameData.LoadUserImages(GameData.UserImagePath);
		}
	}

	private void HandleLogCheck(string logString, string stackTrace, LogType type)
	{
		_logCount++;
		if (_logCount % 10 != 0)
		{
			return;
		}
		try
		{
			string logFile = FeedbackWindow.GetLogFile();
			if (File.Exists(logFile))
			{
				long num = new FileInfo(logFile).Length / 1024;
				if (num > 2048)
				{
					Debug.unityLogger.Log("Log is above 2MB, disabling");
					Debug.unityLogger.logEnabled = false;
				}
				else if (num > 1024)
				{
					Debug.Log("Log is above 1MB, only showing errors");
					Debug.unityLogger.filterLogType = LogType.Error;
				}
			}
			else
			{
				Debug.Log("Log file not found, can't stop logging you");
				unbind2 = false;
				Application.logMessageReceived -= HandleLogCheck;
			}
		}
		catch (Exception ex)
		{
			Debug.Log("Error during log file size check:\n" + ex.ToString());
			unbind2 = false;
			Application.logMessageReceived -= HandleLogCheck;
		}
	}

	private void HandleLog(string logString, string stackTrace, LogType type)
	{
		if (LoggedErrors > 50 || !Options.InjectMods)
		{
			Application.logMessageReceived -= HandleLog;
			unbind = false;
		}
		else
		{
			if (type != LogType.Exception && type != LogType.Error)
			{
				return;
			}
			string msg = logString + "\n" + stackTrace;
			if (msg.Contains("ModException"))
			{
				FirstOfScene = false;
			}
			else
			{
				if (Logged.Contains(msg.GetHashCode()) || stackTrace.Contains("UnityEngine.UI.InputField.Delete") || msg.Contains("<RI.Hid>") || logString.Contains("FloatingGamepadTextInput") || msg.Contains("Failed to read input report") || msg.Contains("Failed to create device file") || msg.StartsWith("Internal error. Trying to destroy object that is already released to pool.") || stackTrace.Contains("UnityEngine.RectTransform.set_anchorMin") || logString.Equals("RenderTexture.Create failed: width & height must be larger than 0") || logString.Contains("Error loading texture for material") || logString.Contains("File corrupted, header:") || logString.Contains("Infinity or NaN floating point numbers appear when calculating the transform matrix for a Collider") || (msg.Contains("Failed to get cursor position:") && msg.Contains("Success")))
				{
					return;
				}
				if (!GameSettings.Instance.IsReferenceNull())
				{
					try
					{
						if (GameReader.SaveLock.TryEnterReadLock(-1))
						{
							GameSettings.Instance.Errors.Add(msg);
							GameReader.SaveLock.ExitReadLock();
						}
					}
					catch (Exception)
					{
					}
				}
				if (!logString.Contains("Ignore:") && !msg.Contains("Point on constrained edge not supported yet") && Options.AskReporting && LoggedErrors == 0 && FeedbackWindow.Instance != null)
				{
					if (!GameSettings.Instance.IsReferenceNull())
					{
						GameSettings.GameSpeed = 0f;
					}
					DialogWindow d = WindowManager.SpawnDialog();
					d.Show("ExceptionMessage".Loc(), false, DialogWindow.DialogType.Error, new KeyValuePair<string, Action>("Yes", delegate
					{
						FeedbackWindow.Instance.Show(FeedbackWindow.ReportTypes.Exception, null, false, true, null);
						FeedbackWindow.Instance.Exception = msg;
						d.Window.Close();
					}), new KeyValuePair<string, Action>("See error", delegate
					{
						WindowManager.SpawnDialog(msg, true, DialogWindow.DialogType.Information);
					}), new KeyValuePair<string, Action>("No", delegate
					{
						d.Window.Close();
					}), new KeyValuePair<string, Action>("Never", delegate
					{
						Options.SetAndSave("AskReporting", false);
						d.Window.Close();
					}));
				}
				StartCoroutine(PutLog(msg));
				LoggedErrors++;
			}
		}
	}

	private IEnumerator PutLog(string msg)
	{
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("key", "SwincDebug");
		wWWForm.AddField("msg", StackClean.Replace(msg, ""));
		if (FirstOfScene)
		{
			wWWForm.AddField("first", "1");
			FirstOfScene = false;
		}
		wWWForm.AddField("client", Versioning.NetworkVersionString);
		wWWForm.AddField("version", Versioning.SimpleNetworkVersionString);
		wWWForm.AddField("modded", Modded ? "1" : "0");
		UnityWebRequest www = UnityWebRequest.Post("https://SoftwareInc.Coredumping.com/ErrorLog.php", wWWForm);
		www.SetRequestHeader("User-Agent", "Swinc User Agent");
		int hash = msg.GetHashCode();
		Logged.Add(hash);
		yield return www.SendWebRequest();
		if (!string.IsNullOrEmpty(www.error))
		{
			Logged.Remove(hash);
		}
	}
}
