using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DebugLogViewer
{
	private enum LogSourceEnum
	{
		Game = 0,
		DataStore = 1
	}

	private LogWindow logWindow = new LogWindow();

	private Rect windowRect;

	private string logFolder = string.Empty;

	private List<string> logFileList = new List<string>();

	private LogSourceEnum currentLogSource = LogSourceEnum.DataStore;

	public bool IsShowing { get; private set; }

	public DebugLogViewer()
	{
		windowRect = new Rect(Screen.width / 2 - 150, Screen.height / 2 - 200, 300f, 400f);
		if (currentLogSource == LogSourceEnum.Game)
		{
			SetLogToGameSource();
		}
		else if (currentLogSource == LogSourceEnum.DataStore)
		{
			SetLogToDataStoreSource();
		}
	}

	public void Show()
	{
		logFileList.Clear();
		if (Directory.Exists(logFolder))
		{
			string[] files = Directory.GetFiles(logFolder, "~log*.txt");
			string[] array = files;
			foreach (string path in array)
			{
				logFileList.Add(Path.GetFileName(path));
			}
		}
		if (logFileList.Count > 0)
		{
			IsShowing = true;
		}
		else
		{
			IsShowing = false;
		}
	}

	public void Hide()
	{
		IsShowing = false;
	}

	public void Update()
	{
		if (logWindow.WindowIsShown)
		{
			logWindow.Update();
		}
	}

	public void DrawWindow()
	{
		if (!logWindow.WindowIsShown)
		{
			GUI.Window(35, windowRect, DrawActualWindow, "Objective Log Files");
		}
		else
		{
			logWindow.DrawWindow();
		}
	}

	private void DrawActualWindow(int id)
	{
		float height = ((currentLogSource != LogSourceEnum.Game) ? 20 : 30);
		float height2 = ((currentLogSource != LogSourceEnum.DataStore) ? 20 : 30);
		if (GUI.Button(new Rect(5f, 20f, windowRect.width / 2f - 5f, height), "Game"))
		{
			SetLogToGameSource();
			Show();
		}
		if (GUI.Button(new Rect(windowRect.width / 2f + 1f, 20f, windowRect.width / 2f - 5f, height2), "DataStore"))
		{
			SetLogToDataStoreSource();
			Show();
		}
		Rect position = new Rect(5f, 55f, windowRect.width - 10f, 25f);
		foreach (string logFile in logFileList)
		{
			if (GUI.Button(position, logFile))
			{
				ShowLog(logFile);
			}
			position.y += 25f;
		}
		GUI.DragWindow();
	}

	private void ShowLog(string fileName)
	{
		logWindow.ShowLog(LogManager.GetLogFromFile(Path.Combine(logFolder, fileName)));
	}

	private void SetLogToGameSource()
	{
		logFolder = GameFileHelper.GetCurrentDataUniverseLocation();
		logFolder = Path.Combine(logFolder, "Logs");
		currentLogSource = LogSourceEnum.Game;
	}

	private void SetLogToDataStoreSource()
	{
		logFolder = Path.Combine(Application.dataPath, "DataStore");
		logFolder = Path.Combine(logFolder, "Objectives");
		currentLogSource = LogSourceEnum.DataStore;
	}
}
