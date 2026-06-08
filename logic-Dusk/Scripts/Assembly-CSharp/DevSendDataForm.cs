using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using UnityEngine;

public class DevSendDataForm : MonoBehaviour
{
	private string screenshotPathText = string.Empty;

	private Rect windowRect = default(Rect);

	private Rect sendingWindowRect = default(Rect);

	private Rect infoLabelRect = default(Rect);

	private Rect commentLabelRect = default(Rect);

	private Rect screenshotLabelRect = default(Rect);

	private Rect screenshotRect = default(Rect);

	private Rect screenshotBackgroundRectOffset = default(Rect);

	private UITextEditor comments;

	private GUIStyle infoStyle;

	private GUIStyle textStyle;

	private GUIStyle inputStyle;

	private GUIStyle sendingStyle;

	private bool isScreenshotSelected;

	private bool isPreparingToArchive;

	private bool isDelayArchive;

	private bool isReadyToArchive;

	private bool isArchive;

	private bool isDoneArchiving;

	private bool isWaitingToTestInput;

	private float timerClearPreviousInput;

	private float timerArchiveSend;

	private string archiveFolder = string.Empty;

	public MenuScreen CallingMenuScreen { get; set; }

	public bool TestForKeyboardRelease { get; set; }

	private void Start()
	{
		infoStyle = new GUIStyle();
		infoStyle.fontSize = 14;
		infoStyle.normal.textColor = Color.white;
		infoStyle.wordWrap = true;
		textStyle = new GUIStyle();
		textStyle.fontSize = 12;
		textStyle.normal.textColor = Color.white;
		inputStyle = new GUIStyle();
		inputStyle.fontSize = 12;
		inputStyle.normal.textColor = Color.white;
		sendingStyle = new GUIStyle();
		sendingStyle.fontSize = 20;
		sendingStyle.normal.textColor = Color.white;
		sendingStyle.alignment = TextAnchor.MiddleCenter;
		windowRect.width = 700f;
		windowRect.height = 400f;
		windowRect.x = (float)(Screen.width / 2) - windowRect.width / 2f;
		windowRect.y = (float)(Screen.height / 2) - windowRect.height / 2f;
		sendingWindowRect.width = 250f;
		sendingWindowRect.height = 50f;
		sendingWindowRect.x = (float)(Screen.width / 2) - sendingWindowRect.width / 2f;
		sendingWindowRect.y = (float)(Screen.height / 2) - sendingWindowRect.height / 2f;
		float num = 20f;
		float num2 = 30f;
		infoLabelRect.x = num;
		infoLabelRect.y = num2;
		infoLabelRect.width = windowRect.width - num * 2f;
		infoLabelRect.height = 20f;
		num2 += 25f;
		screenshotLabelRect.x = num;
		screenshotLabelRect.y = num2;
		screenshotLabelRect.width = windowRect.width - num * 2f;
		screenshotLabelRect.height = 20f;
		num2 += 20f;
		screenshotRect.x = num;
		screenshotRect.y = num2;
		screenshotRect.width = windowRect.width - num * 2f;
		screenshotRect.height = 20f;
		screenshotBackgroundRectOffset = screenshotRect;
		screenshotBackgroundRectOffset.x -= 2f;
		screenshotBackgroundRectOffset.y -= 4f;
		num2 += 25f;
		commentLabelRect.x = num;
		commentLabelRect.y = num2;
		commentLabelRect.width = windowRect.width - num * 2f;
		commentLabelRect.height = 20f;
		num2 += 5f;
		comments = new UITextEditor
		{
			InputArea = new Rect(num, num2, windowRect.width - num * 2f, windowRect.height - num2 - 45f),
			MaxCharacters = 500,
			ExcludedCharacters = new char[2] { '<', '>' },
			TextSize = 12
		};
		num2 += comments.InputArea.height;
	}

	private void Update()
	{
		if (isDelayArchive)
		{
			timerArchiveSend += Time.deltaTime;
			if (timerArchiveSend > 0.5f)
			{
				isDelayArchive = false;
			}
		}
		if (DialogUI.Instance.IsShowing)
		{
			DialogUI.Instance.TestKeyInput();
		}
	}

	private void OnGUI()
	{
		if (DialogUI.Instance.IsShowing)
		{
			return;
		}
		if (!isPreparingToArchive && !isArchive && !isReadyToArchive)
		{
			windowRect = GUI.Window(34, windowRect, DrawWindow, "Archive Data Files");
		}
		else
		{
			if (isDoneArchiving)
			{
				return;
			}
			GUI.Label(sendingWindowRect, "Archiving...", sendingStyle);
			if (!isDelayArchive)
			{
				if (isPreparingToArchive)
				{
					PrepareArchive();
				}
				else if (isReadyToArchive)
				{
					ArchiveFiles();
				}
			}
		}
	}

	private void DrawWindow(int id)
	{
		if (isPreparingToArchive)
		{
			return;
		}
		GUI.Label(infoLabelRect, "Archive any data files and folders for review - provide an optional screenshot and/or comment below...", infoStyle);
		GUI.Label(screenshotLabelRect, "Screenshot Path + File Name (ex: c:\\screenshot\\screen.png) - this will add an additional 'screenshot.EXT' file in the archive", textStyle);
		GUI.DrawTexture(screenshotBackgroundRectOffset, ResourceManager.SemiTransparantBackground50);
		GUI.SetNextControlName("Screenshot");
		string text = GUI.TextArea(screenshotRect, screenshotPathText, textStyle);
		if (isScreenshotSelected)
		{
			text = text.Replace("\n", string.Empty);
			text = text.Replace("<", "*");
			text = text.Replace(">", "*");
			if (isWaitingToTestInput && screenshotPathText != text)
			{
				if (text.ToLower().EndsWith("s"))
				{
					text = text.Remove(text.Length - 1);
				}
				else if (!string.IsNullOrEmpty(text))
				{
					isWaitingToTestInput = false;
				}
			}
			screenshotPathText = text;
		}
		if (GUI.GetNameOfFocusedControl() == "Screenshot")
		{
			if (!isScreenshotSelected)
			{
				TextEditor textEditor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
				isScreenshotSelected = true;
			}
		}
		else
		{
			isScreenshotSelected = false;
		}
		GUI.Label(commentLabelRect, "Provide details (ex: steps to reproduce a bug) - this will add an additional 'comments.txt' file in the archive", textStyle);
		comments.Draw();
		if (isWaitingToTestInput && !string.IsNullOrEmpty(comments.Text))
		{
			isWaitingToTestInput = false;
		}
		string text2 = "Archive";
		string text3 = "Cancel";
		if (!isWaitingToTestInput)
		{
			if (Event.current.alt)
			{
				text2 = "[A]rchive";
				text3 = "[C]ancel";
				if (Event.current.keyCode == KeyCode.A)
				{
					BeginArchiveButtonPressed();
					return;
				}
				if (Event.current.keyCode == KeyCode.C)
				{
					CancelButtonPressed();
					return;
				}
			}
			else if (Event.current.keyCode == KeyCode.Escape)
			{
				CancelButtonPressed();
				return;
			}
		}
		if (GUI.Button(new Rect(5f, windowRect.height - 30f, 100f, 25f), text2))
		{
			BeginArchiveButtonPressed();
		}
		if (GUI.Button(new Rect(windowRect.width - 105f, windowRect.height - 30f, 100f, 25f), text3))
		{
			CancelButtonPressed();
		}
	}

	private void BeginArchiveButtonPressed()
	{
		isPreparingToArchive = true;
		isReadyToArchive = false;
		isDoneArchiving = false;
		isArchive = false;
		isDelayArchive = true;
		timerArchiveSend = 0f;
	}

	private void PrepareArchive()
	{
		isReadyToArchive = true;
		isPreparingToArchive = false;
	}

	private void ArchiveFiles()
	{
		archiveFolder = GameFileHelper.GetArchiveLocation();
		if (!Directory.Exists(archiveFolder))
		{
			Directory.CreateDirectory(archiveFolder);
		}
		string text = DateTime.Now.ToString();
		text = text.Replace("/", string.Empty).Replace("\\", string.Empty).Replace(":", string.Empty);
		archiveFolder = Path.Combine(archiveFolder, text);
		if (!Directory.Exists(archiveFolder))
		{
			Directory.CreateDirectory(archiveFolder);
		}
		string baseGameFileLocation = GameFileHelper.GetBaseGameFileLocation();
		SyncFolderWithArchive(baseGameFileLocation, archiveFolder);
		string[] files = Directory.GetFiles(baseGameFileLocation, "*.*");
		string[] array = files;
		foreach (string text2 in array)
		{
			string destFileName = Path.Combine(archiveFolder, Path.GetFileName(text2));
			File.Copy(text2, destFileName);
		}
		if (comments.Text.Length > 0)
		{
			TextWriter textWriter = null;
			try
			{
				string path = Path.Combine(archiveFolder, "comments.txt");
				textWriter = File.CreateText(path);
				textWriter.Write(comments.Text);
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.LogError(string.Format("Error happened while writing the comments to the comments.txt file.  All other files successfully archived.\r\nException{0}", ex.Message));
			}
			finally
			{
				if (textWriter != null)
				{
					textWriter.Close();
				}
			}
		}
		if (!string.IsNullOrEmpty(screenshotPathText))
		{
			if (File.Exists(screenshotPathText))
			{
				FileInfo fileInfo = new FileInfo(screenshotPathText);
				string destFileName2 = Path.Combine(archiveFolder, string.Format("screenshot{0}", fileInfo.Extension));
				File.Copy(screenshotPathText, destFileName2);
			}
			else
			{
				UnityEngine.Debug.LogWarning(string.Format("Invalid Screenshot Path Provided: {0}\r\nMake sure the full plath + file name is provided", screenshotPathText));
			}
		}
		DialogUI.Instance.ShowDialog("Done", string.Format("Files archived to: {0}\\\r\n\r\nOpen Folder?", archiveFolder), ModalWindowType.YesNo, DoneResult);
		isReadyToArchive = false;
	}

	private void SyncFolderWithArchive(string baseFolder, string currentArchiveFolder)
	{
		string[] directories = Directory.GetDirectories(baseFolder, "*.*", SearchOption.TopDirectoryOnly);
		string[] array = directories;
		foreach (string text in array)
		{
			string fileName = Path.GetFileName(text);
			if (fileName.ToLower() != "archive" && fileName.ToLower() != "gdata" && fileName.ToLower() != "gameboards" && fileName.ToLower() != "screenshots")
			{
				string text2 = Path.Combine(currentArchiveFolder, fileName);
				if (!Directory.Exists(text2))
				{
					Directory.CreateDirectory(text2);
				}
				SyncFolderWithArchive(text, text2);
				string[] files = Directory.GetFiles(Path.Combine(baseFolder, fileName), "*.*");
				string[] array2 = files;
				foreach (string text3 in array2)
				{
					string destFileName = Path.Combine(text2, Path.GetFileName(text3));
					File.Copy(text3, destFileName);
				}
			}
		}
	}

	private void DoneResult(ModalWindowResult result, string input)
	{
		if (result != ModalWindowResult.OK && result != ModalWindowResult.No && result != ModalWindowResult.Cancel)
		{
			Process.Start("explorer.exe", archiveFolder);
		}
		CloseAndReturnToMenu();
		isDoneArchiving = true;
	}

	private void CompressData()
	{
		string currentDataUniverseLocation = GameFileHelper.GetCurrentDataUniverseLocation();
		string[] files = Directory.GetFiles(currentDataUniverseLocation, "*.*", SearchOption.AllDirectories);
		string[] array = files;
		foreach (string text in array)
		{
			FileInfo fileInfo = new FileInfo(text);
			using (FileStream fileStream = fileInfo.OpenRead())
			{
				if (!(((File.GetAttributes(fileInfo.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden) & (fileInfo.Extension != ".gz")))
				{
					continue;
				}
				using (FileStream compressedStream = File.Create(fileInfo.FullName + ".gz"))
				{
					using (GZipStream gZipStream = new GZipStream(compressedStream, CompressionMode.Compress))
					{
						byte[] array2 = new byte[4096];
						int count;
						while ((count = fileStream.Read(array2, 0, array2.Length)) != 0)
						{
							gZipStream.Write(array2, 0, count);
						}
					}
				}
				FileInfo fileInfo2 = new FileInfo(currentDataUniverseLocation + "\\" + fileInfo.Name + ".gz");
				UnityEngine.Debug.Log(string.Format("Compressed {0} from {1} to {2} bytes.", fileInfo.Name, text.Length.ToString(), fileInfo2.Length.ToString()));
			}
		}
	}

	private void CancelButtonPressed()
	{
		CloseAndReturnToMenu();
	}

	private void CloseAndReturnToMenu()
	{
		if (CallingMenuScreen != null)
		{
			CallingMenuScreen.Enable();
			CallingMenuScreen.ReloadMenuItems();
		}
		UnityEngine.Object.Destroy(this);
	}
}
