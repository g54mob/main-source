using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DevConsole;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FeedbackWindow : MonoBehaviour
{
	public enum ReportTypes
	{
		Feedback = 0,
		Exception = 1,
		Crash = 2
	}

	public GUIWindow Window;

	public ReportTypes Type;

	public InputField Mail;

	public InputField Message;

	public GUIProgressBar bar;

	public Text FileUploads;

	public GameObject ScreenPanel;

	public RawImage Screenshot;

	public AspectRatioFitter ImageRatio;

	public UnityWebRequest CurrentJob;

	public GameObject MainPanel;

	public GameObject ProgressPanel;

	public GameObject PreviousPanel;

	public Toggle IncludeSave;

	public Toggle IncludeLog;

	public Toggle SpecToggle;

	public Text MessagePlaceholder;

	[NonSerialized]
	public string Exception;

	[NonSerialized]
	private readonly HashSet<string> _files = new HashSet<string>();

	[NonSerialized]
	private Texture2D _screenshot;

	private string _lastMail;

	private string _lastMessage;

	private string _lastType;

	private string _lastVersion;

	private string[] _lastFiles;

	private static float _lastPost = -1f;

	public static FeedbackWindow Instance;

	private bool _isRetry;

	private string _versionOverride;

	private void Awake()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		Window.OnClose = delegate
		{
			if (_screenshot != null)
			{
				UnityEngine.Object.Destroy(_screenshot);
				_screenshot = null;
			}
		};
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void ClearReports()
	{
		if (File.Exists("ReportID.txt"))
		{
			try
			{
				File.Delete("ReportID.txt");
			}
			catch (Exception)
			{
			}
		}
		PreviousPanel.SetActive(false);
	}

	public void Show()
	{
		Show(ReportTypes.Feedback, null, false, false, null);
	}

	public void AddSave(bool doIt)
	{
		if (MainMenuController.Instance != null && MainMenuController.Instance.CurrentSaveGame != null)
		{
			string fullPath = Path.GetFullPath(MainMenuController.Instance.CurrentSaveGame.FileName);
			if (doIt)
			{
				_files.Add(fullPath);
			}
			else
			{
				_files.Remove(fullPath);
			}
		}
		else if (!GameSettings.Instance.IsReferenceNull())
		{
			SaveGame saveGame = GameSettings.Instance.AssociatedSave;
			if (saveGame == null)
			{
				saveGame = GameSettings.Instance.AssociatedAutoSave;
			}
			else if (GameSettings.Instance.AssociatedAutoSave != null)
			{
				saveGame = ((saveGame.RealTime > GameSettings.Instance.AssociatedAutoSave.RealTime) ? saveGame : GameSettings.Instance.AssociatedAutoSave);
			}
			if (saveGame != null)
			{
				string fullPath2 = Path.GetFullPath(saveGame.FileName);
				if (doIt)
				{
					_files.Add(fullPath2);
				}
				else
				{
					_files.Remove(fullPath2);
				}
			}
		}
		UpdateFiles();
	}

	private void UpdateFiles()
	{
		StringBuilder stringBuilder = new StringBuilder();
		string root = Utilities.GetRoot();
		foreach (string file in _files)
		{
			stringBuilder.Append(file.Replace(root, ""));
			try
			{
				if (File.Exists(file))
				{
					FileInfo fileInfo = new FileInfo(file);
					stringBuilder.Append(" (");
					stringBuilder.Append(fileInfo.LastWriteTime.ToString("yy-MM-dd HH:mm"));
					stringBuilder.Append(")");
				}
			}
			catch (Exception)
			{
			}
			stringBuilder.AppendLine();
		}
		FileUploads.text = stringBuilder.ToString().Trim();
	}

	public static string GetLogFile()
	{
		return Application.consoleLogPath;
	}

	public static string GetCrashFolder()
	{
		return Path.Combine(Path.GetFullPath(Path.Combine(Application.persistentDataPath, "../../../")), "Local/Temp/Coredumping/Software Inc/Crashes");
	}

	public void AddLog(bool doIt)
	{
		if (doIt)
		{
			_files.Add(GetLogFile());
		}
		else
		{
			_files.Remove(GetLogFile());
		}
		UpdateFiles();
	}

	public void Show(ReportTypes type, string screenshot, bool save, bool log, string versionOverride = null, params string[] extraFiles)
	{
		MessagePlaceholder.text = ((type == ReportTypes.Feedback) ? "ReportMessagePlaceholder" : "ReportMessagePlaceholderError").Loc();
		_versionOverride = null;
		ScreenPanel.SetActive(false);
		if (screenshot != null)
		{
			try
			{
				if (_screenshot != null)
				{
					UnityEngine.Object.Destroy(_screenshot);
				}
				_screenshot = new Texture2D(4, 4);
				_screenshot.LoadImage(File.ReadAllBytes(screenshot));
				Screenshot.texture = _screenshot;
				ImageRatio.aspectRatio = (float)_screenshot.width / (float)_screenshot.height;
				ScreenPanel.SetActive(true);
			}
			catch (Exception)
			{
			}
		}
		PreviousPanel.SetActive(File.Exists("ReportID.txt"));
		Exception = null;
		_files.Clear();
		_files.AddRange(extraFiles);
		bool flag = File.Exists(GetLogFile());
		IncludeLog.gameObject.SetActive(flag && type == ReportTypes.Feedback);
		IncludeLog.isOn = flag && log;
		if (flag && log)
		{
			AddLog(true);
		}
		SpecToggle.isOn = false;
		switch (type)
		{
		case ReportTypes.Feedback:
			IncludeSave.gameObject.SetActive((type != ReportTypes.Crash && MainMenuController.Instance != null && MainMenuController.Instance.CurrentSaveGame != null) || (!GameSettings.Instance.IsReferenceNull() && (GameSettings.Instance.AssociatedSave != null || GameSettings.Instance.AssociatedAutoSave != null)));
			IncludeSave.isOn = IncludeSave.gameObject.activeSelf && save;
			break;
		case ReportTypes.Crash:
			_versionOverride = versionOverride;
			break;
		}
		Type = type;
		Mail.text = "";
		Message.text = "";
		UpdateFiles();
		Window.Show();
	}

	public void SeePreviousReports()
	{
		if (File.Exists("ReportID.txt"))
		{
			try
			{
				string msg = File.ReadAllText("ReportID.txt").TrimEnd().Replace("\n", ", ");
				WindowManager.Instance.ShowMessageBox(msg, true, DialogWindow.DialogType.Information, Window, new KeyValuePair<string, Action>("OK", delegate
				{
				}), new KeyValuePair<string, Action>("Clear", ClearReports));
			}
			catch (Exception)
			{
			}
		}
	}

	private void Update()
	{
		if (CurrentJob == null)
		{
			return;
		}
		if (CurrentJob.isDone || !string.IsNullOrEmpty(CurrentJob.error))
		{
			if (_isRetry)
			{
				_isRetry = false;
				CurrentJob = null;
				MainPanel.SetActive(true);
				ProgressPanel.SetActive(false);
				Window.Close();
				return;
			}
			string text = null;
			int num = 0;
			if (!string.IsNullOrEmpty(CurrentJob.error))
			{
				text = CurrentJob.error;
			}
			else if (CurrentJob.downloadHandler.text == null || !CurrentJob.downloadHandler.text.StartsWith("Success"))
			{
				text = CurrentJob.downloadHandler.text;
			}
			else
			{
				try
				{
					num = Convert.ToInt32(CurrentJob.downloadHandler.text.Substring(8));
				}
				catch (Exception)
				{
				}
			}
			CurrentJob = null;
			MainPanel.SetActive(true);
			ProgressPanel.SetActive(false);
			if (text == null)
			{
				_lastPost = Time.realtimeSinceStartup;
				WindowManager.SpawnDialog("ReportSuccess2".Loc(num), true, DialogWindow.DialogType.Information);
				PreviousPanel.SetActive(true);
				try
				{
					if (File.Exists("ReportID.txt"))
					{
						File.AppendAllText("ReportID.txt", "\n" + num);
					}
					else
					{
						File.WriteAllText("ReportID.txt", num.ToString());
					}
				}
				catch (Exception)
				{
				}
				Window.Close();
			}
			else
			{
				DialogWindow d = WindowManager.SpawnDialog();
				Window.Close();
				d.Show("ReportFailure".Loc() + "\n" + text, false, DialogWindow.DialogType.Error, new KeyValuePair<string, Action>("Yes", delegate
				{
					SaveLastReport();
					WindowManager.SpawnDialog("TryLaterConfirm".Loc(), true, DialogWindow.DialogType.Question);
					d.Window.Close();
				}), new KeyValuePair<string, Action>("No", delegate
				{
					Window.Show();
					d.Window.Close();
				}));
			}
		}
		else
		{
			bar.Value = CurrentJob.uploadProgress;
		}
	}

	public void StartUpload()
	{
		if (_lastPost > 0f && Time.realtimeSinceStartup - _lastPost < 300f)
		{
			WindowManager.SpawnDialog("ReportDelayError".Loc(), true, DialogWindow.DialogType.Error);
		}
		else if (Mail.text.Trim().Length > 0 && !Regex.IsMatch(Mail.text, "\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", RegexOptions.IgnoreCase))
		{
			WindowManager.SpawnDialog("MailInvalid".Loc(), true, DialogWindow.DialogType.Error);
		}
		else if ((Type == ReportTypes.Feedback || Type == ReportTypes.Exception) && Message.text.Trim().Length < 50)
		{
			WindowManager.SpawnDialog("NoFeedbackError".Loc(), true, DialogWindow.DialogType.Error);
		}
		else if (Type == ReportTypes.Feedback && !IncludeSave.isOn)
		{
			WindowManager.Instance.ShowMessageBox("NoSaveFeedbackWarning".Loc(), true, DialogWindow.DialogType.Question, delegate
			{
				StartCoroutine(Upload());
			});
		}
		else
		{
			StartCoroutine(Upload());
		}
	}

	public IEnumerator UploadSpecial(string mail, string message, string type, string version, string[] files, string deleteDir)
	{
		_isRetry = true;
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("Mail", mail);
		wWWForm.AddField("Message", message);
		wWWForm.AddField("Type", type);
		wWWForm.AddField("Version", version);
		foreach (string text in files)
		{
			if (File.Exists(text) && new FileInfo(text).Length < 15728640)
			{
				using (FileStream input = File.Open(text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					BinaryReader reader = new BinaryReader(input);
					wWWForm.AddBinaryData("Files[]", reader.ReadAllBytes(), Path.GetFileName(text));
				}
			}
		}
		MainPanel.SetActive(false);
		ProgressPanel.SetActive(true);
		CurrentJob = UnityWebRequest.Post("https://www.coredumping.com/BugReporting/Report.php", wWWForm);
		CurrentJob.SetRequestHeader("User-Agent", "Swinc User Agent");
		UnityWebRequest j = CurrentJob;
		yield return CurrentJob.SendWebRequest();
		MainMenuController.IsUploading = false;
		if (string.IsNullOrEmpty(j.error) && "Success".Equals(j.downloadHandler.text))
		{
			try
			{
				Directory.Delete(deleteDir, true);
				yield break;
			}
			catch (Exception ex)
			{
				DevConsole.Console.LogError(ex.ToString());
				yield break;
			}
		}
		string text2 = (string.IsNullOrEmpty(j.error) ? j.downloadHandler.text : j.error);
		DevConsole.Console.LogError("Failed sending report with error:\n" + text2);
	}

	private string GetSpecs()
	{
		return string.Format("OS: {0}\nMemory: {1} MB\nProcessor: {2} - cores: {3}\nGraphics: {4} {5}, {6} MB, v. {7} - {8}", SystemInfo.operatingSystem, SystemInfo.systemMemorySize, SystemInfo.processorType, SystemInfo.processorCount, SystemInfo.graphicsDeviceVendor, SystemInfo.graphicsDeviceName, SystemInfo.graphicsMemorySize, SystemInfo.graphicsDeviceVersion, SystemInfo.graphicsDeviceType.ToString());
	}

	public void ShowSpecs()
	{
		WindowManager.Instance.ShowMessageBox(GetSpecs(), true, DialogWindow.DialogType.Information);
	}

	private void SaveLastReport()
	{
		string text = Path.Combine(Utilities.GetRoot(), "BugReports");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		DateTime now = DateTime.Now;
		string path = string.Format("{0}-{1}-{2}_{3}{4}{5}", now.Year, now.Month.ToString("00"), now.Day.ToString("00"), now.Hour.ToString("00"), now.Minute.ToString("00"), now.Second.ToString("00"));
		string text2 = Path.Combine(text, path);
		Directory.CreateDirectory(text2);
		List<string> list = new List<string>();
		string[] lastFiles = _lastFiles;
		foreach (string text3 in lastFiles)
		{
			try
			{
				File.Copy(text3, Path.Combine(text2, Path.GetFileName(text3)));
				list.Add(Path.GetFileName(text3));
			}
			catch (Exception ex)
			{
				DevConsole.Console.LogError(ex.ToString());
			}
		}
		XMLParser.XMLNode root = new XMLParser.XMLNode("Root", new XMLParser.XMLNode("Mail", _lastMail), new XMLParser.XMLNode("Message", _lastMessage.Replace("<", "&#60;").Replace(">", "&#62;")), new XMLParser.XMLNode("Version", _lastVersion), new XMLParser.XMLNode("Type", _lastType), new XMLParser.XMLNode("Files", list.Select((string x) => new XMLParser.XMLNode("File", x)).ToArray()));
		File.WriteAllText(Path.Combine(text2, "Report.xml"), XMLParser.ExportXML(root));
	}

	public IEnumerator Upload()
	{
		_isRetry = false;
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("Mail", Mail.text);
		string text = Message.text;
		if (Exception != null)
		{
			text = text + "\n\n" + Exception;
		}
		if (SpecToggle.isOn)
		{
			text = text + "\n\n" + GetSpecs();
		}
		_lastMessage = text;
		_lastMail = Mail.text;
		_lastFiles = _files.ToArray();
		_lastType = Type.ToString();
		_lastVersion = _versionOverride ?? Versioning.NetworkVersionString;
		wWWForm.AddField("Message", text);
		wWWForm.AddField("Type", _lastType);
		wWWForm.AddField("Version", _lastVersion);
		wWWForm.AddField("NewReport", "True");
		foreach (string file in _files)
		{
			if (File.Exists(file) && new FileInfo(file).Length < 15728640)
			{
				using (FileStream input = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					BinaryReader reader = new BinaryReader(input);
					wWWForm.AddBinaryData("Files[]", reader.ReadAllBytes(), Path.GetFileName(file));
				}
			}
		}
		MainPanel.SetActive(false);
		ProgressPanel.SetActive(true);
		CurrentJob = UnityWebRequest.Post("https://www.coredumping.com/BugReporting/Report.php", wWWForm);
		CurrentJob.SetRequestHeader("User-Agent", "Swinc User Agent");
		yield return CurrentJob.SendWebRequest();
	}

	private static int CountNewlines(int p, string s, out int column)
	{
		int num = 0;
		column = 0;
		for (int i = 0; i < Mathf.Min(s.Length, p); i++)
		{
			column++;
			if (s[i] == '\n')
			{
				column = 0;
				num++;
			}
		}
		return num;
	}

	private static int FindLineStart(int p, string s)
	{
		if (p <= 0)
		{
			return 0;
		}
		int num = 0;
		int result = 0;
		for (int i = 0; i < s.Length; i++)
		{
			if (s[i] == '\n')
			{
				result = i + 1;
				num++;
				if (num == p)
				{
					return result;
				}
			}
		}
		return result;
	}

	private static int FindColumn(int from, int lookAhead, string s)
	{
		int i = from;
		for (int num = Mathf.Min(from + lookAhead, s.Length); i < num && s[i] != '\n'; i++)
		{
		}
		return i;
	}

	public void ScrollText(BaseEventData data)
	{
		PointerEventData pointerEventData = (PointerEventData)data;
		int column = 0;
		int p = CountNewlines(Message.caretPosition, Message.text, out column) - Mathf.RoundToInt(pointerEventData.scrollDelta.y);
		Message.caretPosition = FindColumn(FindLineStart(p, Message.text), column, Message.text);
		Message.ForceLabelUpdate();
	}
}
