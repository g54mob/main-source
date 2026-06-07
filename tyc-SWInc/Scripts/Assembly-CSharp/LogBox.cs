using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LogBox : MonoBehaviour
{
	public Scrollbar Scrollbar;

	public Text text;

	[NonSerialized]
	public string[] Log = new string[0];

	[NonSerialized]
	private string _realLog = "";

	public int CurrentLine;

	public int JumpSpeed = 4;

	public RectTransform OwnerPanel;

	public bool DisableUpdate;

	public string RealLog
	{
		get
		{
			return _realLog;
		}
		set
		{
			_realLog = value;
			Log = value.Split('\n');
			CurrentLine = 0;
			DisableUpdate = true;
			Scrollbar.size = Mathf.Clamp01(OwnerPanel.rect.height / (float)text.font.lineHeight / (float)Log.Length);
			DisableUpdate = false;
			UpdateScrollDirect();
		}
	}

	public void Scroll(BaseEventData data)
	{
		CurrentLine = Mathf.Clamp(CurrentLine + ((((PointerEventData)data).scrollDelta.y < 0f) ? JumpSpeed : (-JumpSpeed)), 0, Mathf.CeilToInt((float)(Log.Length + 1) - OwnerPanel.rect.height / (float)text.font.lineHeight));
		UpdateScrollDirect();
	}

	public void UpdateScrollDirect()
	{
		DisableUpdate = true;
		Scrollbar.value = (float)CurrentLine / ((float)(Log.Length + 1) - OwnerPanel.rect.height / (float)text.font.lineHeight);
		UpdateText();
		DisableUpdate = false;
	}

	public void UpdateScrollIndirect()
	{
		if (!DisableUpdate)
		{
			CurrentLine = Mathf.CeilToInt(Scrollbar.value * ((float)(Log.Length + 1) - OwnerPanel.rect.height / (float)text.font.lineHeight));
			UpdateText();
		}
	}

	public void UpdateText()
	{
		int num = Mathf.CeilToInt(OwnerPanel.rect.height / (float)text.font.lineHeight);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < num; i++)
		{
			int num2 = i + CurrentLine;
			if (num2 >= 0)
			{
				if (num2 >= Log.Length)
				{
					break;
				}
				stringBuilder.AppendLine(Log[num2]);
			}
		}
		text.text = stringBuilder.ToString();
	}

	public void UpdateLog()
	{
		string logFile = FeedbackWindow.GetLogFile();
		if (File.Exists(logFile))
		{
			try
			{
				using (FileStream stream = File.Open(logFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					using (StreamReader streamReader = new StreamReader(stream))
					{
						RealLog = streamReader.ReadToEnd();
						return;
					}
				}
			}
			catch (Exception ex)
			{
				RealLog = "Error loading log file:\n" + ex.ToString();
				return;
			}
		}
		RealLog = "Log file not found: " + logFile;
	}

	public void CopyClipboard()
	{
		GUIUtility.systemCopyBuffer = _realLog;
	}
}
