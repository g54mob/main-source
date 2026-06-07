using System;
using System.Collections.Generic;
using Dhs5.Utility.GUIs;
using UnityEngine;

namespace Dhs5.Utility.Debuggers
{
	public class OnScreenDebugger : MonoBehaviour
	{
		private struct ScreenLog
		{
			private static int _count;

			public readonly int id;

			public readonly string message;

			public readonly LogType logType;

			public readonly float time;

			public ScreenLog(string message, LogType logType, float time)
			{
				_count++;
				id = _count;
				this.message = message;
				this.logType = logType;
				this.time = time;
			}
		}

		private struct LogDisposalTime : IComparable<LogDisposalTime>
		{
			public readonly int logID;

			public readonly float disposalTime;

			public LogDisposalTime(int id, float disposalTime)
			{
				logID = id;
				this.disposalTime = disposalTime;
			}

			public int CompareTo(LogDisposalTime other)
			{
				return disposalTime.CompareTo(other.disposalTime);
			}
		}

		private GUIStyle m_timeStyle;

		private GUIStyle m_logStyle;

		private List<ScreenLog> m_activeScreenLogs = new List<ScreenLog>();

		private List<LogDisposalTime> m_logsDisposalTime = new List<LogDisposalTime>();

		public bool IsActive => m_activeScreenLogs.IsValid();

		public int LogsCount => m_activeScreenLogs.Count;

		private static OnScreenDebugger Instance { get; set; }

		private void Start()
		{
			InitStyles();
		}

		private void InitStyles()
		{
			m_timeStyle = new GUIStyle
			{
				alignment = TextAnchor.MiddleRight,
				wordWrap = true,
				fontSize = DebuggerSettings.ScreenLogsTimeSize,
				normal = new GUIStyleState
				{
					textColor = Color.white
				}
			};
			m_logStyle = new GUIStyle
			{
				alignment = TextAnchor.MiddleLeft,
				richText = true,
				wordWrap = true,
				fontSize = 20,
				normal = new GUIStyleState
				{
					textColor = Color.white
				}
			};
		}

		private void AddScreenLog(string message, LogType logType, float duration)
		{
			float time = Time.time;
			ScreenLog item = new ScreenLog(message, logType, time);
			m_activeScreenLogs.Add(item);
			LogDisposalTime item2 = new LogDisposalTime(item.id, time + duration);
			m_logsDisposalTime.Add(item2);
			SortDisposalTimes();
		}

		private void RemoveScreenLog(int id)
		{
			int num = m_activeScreenLogs.FindIndex((ScreenLog l) => l.id == id);
			if (num != -1)
			{
				m_activeScreenLogs.RemoveAt(num);
			}
		}

		private void SortDisposalTimes()
		{
			m_logsDisposalTime.Sort((LogDisposalTime l1, LogDisposalTime l2) => l1.CompareTo(l2));
		}

		private void LateUpdate()
		{
			if (!IsActive)
			{
				return;
			}
			float time = Time.time;
			foreach (LogDisposalTime item in m_logsDisposalTime)
			{
				if (time >= item.disposalTime)
				{
					RemoveScreenLog(item.logID);
					continue;
				}
				break;
			}
		}

		private void OnGUI()
		{
			if (IsActive)
			{
				float screenLogHeight = DebuggerSettings.ScreenLogHeight;
				Rect screenLogsRect = DebuggerSettings.ScreenLogsRect;
				Rect rect = new Rect(screenLogsRect.x, screenLogsRect.y, screenLogsRect.width, screenLogHeight);
				int num = LogsCount - 1;
				while (num >= 0 && rect.y + screenLogHeight <= screenLogsRect.y + screenLogsRect.height)
				{
					ScreenLog log = m_activeScreenLogs[num];
					OnScreenLogGUI(rect, num, log, out var necessaryHeight);
					rect.y += necessaryHeight;
					num--;
				}
			}
		}

		private void OnScreenLogGUI(Rect rect, int index, ScreenLog log, out float necessaryHeight)
		{
			float x = rect.x;
			float width = rect.width;
			float num = 75f;
			float num2 = 15f;
			if (DebuggerSettings.ShowScreenLogsTime)
			{
				x = rect.x + num + num2;
				width = rect.width - num - num2;
			}
			GUIContent content = new GUIContent(log.message);
			necessaryHeight = Mathf.Max(rect.height, m_timeStyle.CalcHeight(content, width));
			rect.height = necessaryHeight;
			switch (log.logType)
			{
			case LogType.Warning:
				GUIHelper.DrawRect(rect, new Color(1f, 0.92f, 0.016f, 0.5f));
				break;
			case LogType.Error:
			case LogType.Assert:
			case LogType.Exception:
				GUIHelper.DrawRect(rect, new Color(1f, 0f, 0f, 0.5f));
				break;
			}
			GUIHelper.DrawRect(rect, (index % 2 == 0) ? GUIHelper.transparentBlack05 : GUIHelper.transparentBlack04);
			if (DebuggerSettings.ShowScreenLogsTime)
			{
				GUI.Label(new Rect(rect.x, rect.y, num, rect.height), log.time.ToString("0.00"), m_timeStyle);
			}
			GUI.Label(new Rect(x, rect.y, width, rect.height), content, m_logStyle);
		}

		private static void CreateInstance()
		{
			if (!(Instance != null))
			{
				GameObject obj = new GameObject("OnScreen Debugger");
				UnityEngine.Object.DontDestroyOnLoad(obj);
				Instance = obj.AddComponent<OnScreenDebugger>();
			}
		}

		private static OnScreenDebugger GetInstance()
		{
			if (Instance == null)
			{
				CreateInstance();
			}
			return Instance;
		}

		public static void Log(string message, LogType logType, float duration)
		{
			GetInstance().AddScreenLog(message, logType, duration);
		}
	}
}
