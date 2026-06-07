using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class LoadDebugger : MonoBehaviour
{
	public Text MainText;

	public Text SteamText;

	public static LoadDebugger Instance;

	public bool Errors;

	public List<string> Lines = new List<string>();

	[NonSerialized]
	private bool _first = true;

	private Dictionary<string, KeyValuePair<int, float>> _steamLoad = new Dictionary<string, KeyValuePair<int, float>>();

	private void Awake()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	public static int AddError(string msg)
	{
		if (Instance != null)
		{
			Instance.Errors = true;
			Instance.Lines.Add("<color=#FF0000>" + msg + "</color>");
			Instance.RefreshText();
			return Instance.Lines.Count - 1;
		}
		return -1;
	}

	public static int AddInfo(string msg, string color)
	{
		if (Instance != null)
		{
			Instance.Lines.Add("<color=" + color + ">" + msg + "</color>");
			Instance.RefreshText();
			return Instance.Lines.Count - 1;
		}
		return -1;
	}

	public static int AddInfo(string msg)
	{
		if (Instance != null)
		{
			Instance.Lines.Add(msg);
			Instance.RefreshText();
			return Instance.Lines.Count - 1;
		}
		return -1;
	}

	public static void SetLastLine(string msg)
	{
		if (Instance != null)
		{
			if (Instance.Lines.Count > 0)
			{
				Instance.Lines[Instance.Lines.Count - 1] = msg;
				Instance.RefreshText();
			}
			else
			{
				AddInfo(msg);
			}
		}
	}

	public static void AddToLine(int i, string msg)
	{
		if (Instance != null && i >= 0 && i < Instance.Lines.Count)
		{
			Instance.Lines[i] += msg;
			Instance.RefreshText();
		}
	}

	private void RefreshText()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < Lines.Count; i++)
		{
			stringBuilder.AppendLine(Lines[i]);
		}
		MainText.text = stringBuilder.ToString().TrimEnd();
	}

	public static void AddSteamInfo(string type, float time)
	{
		if (Instance != null)
		{
			KeyValuePair<int, float> value;
			if (Instance._steamLoad.TryGetValue(type, out value))
			{
				Instance._steamLoad[type] = new KeyValuePair<int, float>(value.Key + 1, value.Value + time);
			}
			else
			{
				Instance._steamLoad[type] = new KeyValuePair<int, float>(1, time);
			}
			Instance.RefreshSteamText();
		}
	}

	private void RefreshSteamText()
	{
		if (_steamLoad.Count > 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Steam:".FontSize(24f).FontBold());
			foreach (KeyValuePair<string, KeyValuePair<int, float>> item in _steamLoad)
			{
				stringBuilder.AppendLine(item.Value.Key + " " + item.Key + " loaded in " + item.Value.Value.SecondsToTime());
			}
			SteamText.text = stringBuilder.ToString().TrimEnd();
		}
		else
		{
			SteamText.text = "";
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}
}
