using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LogWindowUI : MonoBehaviour
{
	private class ButtonItem
	{
		public GameObject buttonObject { get; set; }

		public Image buttonImage { get; set; }

		public Image buttonBorder { get; set; }

		public Text text { get; set; }

		public string groupKey { get; set; }
	}

	public static LogWindowUI Instance;

	private Transform panelLogs;

	private Transform panelLogReader;

	private bool initalized;

	private ButtonItem[] logButtonArray;

	private Dictionary<string, string> logTextDict;

	private string currentLogKey;

	private int currentLogIdx = -1;

	private int logCount = -1;

	private bool isShowingLogViewer;

	private void Awake()
	{
		Instance = this;
		if (!initalized)
		{
			Initalized();
		}
	}

	private void Initalized()
	{
		panelLogs = base.transform;
		if (panelLogs != null)
		{
			Transform transform = panelLogs.FindChild("PanelEntries");
			panelLogReader = panelLogs.FindChild("PanelLogReader");
			if (transform != null)
			{
				Transform[] componentsInChildren = transform.gameObject.GetComponentsInChildren<Transform>();
				if (componentsInChildren != null && componentsInChildren.Length > 0)
				{
					int num = componentsInChildren.Length;
					logButtonArray = new ButtonItem[num / 3];
					int num2 = 0;
					for (int i = 1; i < num; i += 3)
					{
						logButtonArray[num2] = new ButtonItem();
						Transform transform2 = componentsInChildren[i];
						Transform transform3 = componentsInChildren[i + 1];
						Transform transform4 = componentsInChildren[i + 2];
						logButtonArray[num2].buttonObject = componentsInChildren[i].gameObject;
						logButtonArray[num2].buttonImage = transform2.gameObject.GetComponent<Image>();
						logButtonArray[num2].buttonBorder = transform3.gameObject.GetComponent<Image>();
						logButtonArray[num2].text = transform4.gameObject.GetComponent<Text>();
						logButtonArray[num2].buttonObject.SetActive(false);
						num2++;
					}
				}
			}
			panelLogs.gameObject.SetActive(false);
		}
		initalized = true;
	}

	public void SetLogMode(bool isViewingLog)
	{
		isShowingLogViewer = isViewingLog;
		if (isViewingLog)
		{
			panelLogs.gameObject.SetActive(true);
			if (LogManager.LogDataFile == null)
			{
				LogManager.InitManager();
			}
			if (logTextDict == null)
			{
				logTextDict = new Dictionary<string, string>();
			}
			List<string> groupsByName = LogManager.LogDataFile.GetGroupsByName("LOG_");
			int num = 0;
			bool flag = false;
			currentLogIdx = -1;
			logCount = 0;
			foreach (string item in groupsByName)
			{
				LogManager.LogTypeEnum setting = (LogManager.LogTypeEnum)LogManager.LogDataFile.GetSetting(item, "TYPE", 0);
				string arg = "Log";
				if (setting == LogManager.LogTypeEnum.Objective)
				{
					arg = "Notice";
				}
				string empty = string.Empty;
				empty = (GlobalSettings.cheatMode ? string.Format("{0}.txt", LogManager.LogDataFile.GetSetting(item, "FILE", string.Empty)) : LogManager.LogDataFile.GetSetting(item, "LOGID", string.Empty));
				logButtonArray[num].text.text = string.Format("{0} {1}", arg, empty);
				logButtonArray[num].buttonObject.SetActive(true);
				logButtonArray[num].groupKey = item;
				if (currentLogKey == item)
				{
					flag = true;
					currentLogIdx = num;
				}
				logCount++;
				num++;
				if (num >= logButtonArray.Length)
				{
					break;
				}
			}
			if (!flag)
			{
				currentLogIdx = 0;
			}
			currentLogKey = groupsByName[currentLogIdx];
			logButtonArray[currentLogIdx].buttonImage.color = SystemOverlayUI.Instance.SelectedItemColor;
			ShowLogEntry(logButtonArray[currentLogIdx].groupKey);
		}
		else
		{
			panelLogs.gameObject.SetActive(false);
			if (logTextDict != null && logTextDict.Count > 1 && !string.IsNullOrEmpty(currentLogKey))
			{
				string value = logTextDict[currentLogKey];
				logTextDict.Clear();
				logTextDict.Add(currentLogKey, value);
			}
		}
	}

	private void Update()
	{
		if (!isShowingLogViewer)
		{
			return;
		}
		if (Input.GetButtonDown("Up"))
		{
			logButtonArray[currentLogIdx].buttonImage.color = Color.black;
			currentLogIdx--;
			if (currentLogIdx < 0)
			{
				currentLogIdx = logCount - 1;
			}
			logButtonArray[currentLogIdx].buttonImage.color = SystemOverlayUI.Instance.SelectedItemColor;
			currentLogKey = logButtonArray[currentLogIdx].groupKey;
			ShowLogEntry(currentLogKey);
		}
		else if (Input.GetButtonDown("Down"))
		{
			logButtonArray[currentLogIdx].buttonImage.color = Color.black;
			currentLogIdx++;
			if (currentLogIdx >= logCount)
			{
				currentLogIdx = 0;
			}
			logButtonArray[currentLogIdx].buttonImage.color = SystemOverlayUI.Instance.SelectedItemColor;
			currentLogKey = logButtonArray[currentLogIdx].groupKey;
			ShowLogEntry(currentLogKey);
		}
	}

	private void ShowLogEntry(string key)
	{
		if (!logTextDict.ContainsKey(key))
		{
			string empty = string.Empty;
			string text = Path.Combine(GameFileHelper.GetDataUniverseLogLocation(), LogManager.LogDataFile.GetSetting(key, "FILE", string.Empty));
			text = text.Replace("Color/", string.Empty);
			text += ".bkd";
			empty = LogManager.GetLogFromFile(text);
			logTextDict.Add(key, empty);
		}
		Transform transform = panelLogReader.FindChild("LogText");
		transform.gameObject.GetComponent<Text>().text = logTextDict[key];
	}
}
