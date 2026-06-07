using System;
using System.IO;
using System.Reflection;
using System.Text;
using GUPS.EasyPerformanceMonitor.Persistent;
using UnityEngine;
using UnityEngine.UI;

namespace GUPS.EasyPerformanceMonitor.Window
{
	[Obfuscation(Exclude = true)]
	public class LogMonitorWindow : MonitorWindow
	{
		[Header("Log Window - Settings")]
		[Tooltip("The log text UI element.")]
		public Text LogText;

		[Tooltip("The scrollbar UI element.")]
		public Scrollbar LogScrollbar;

		[Tooltip("The log level from which to display log messages. Info = 2, Warning = 1, Error/Exception = 0. Default is Info (2).")]
		[Range(0f, 2f)]
		public int LogLevel = 2;

		[Tooltip("The maximum number of log lines to display.")]
		[Range(1f, 100f)]
		public int LogMaxLines = 15;

		public const int CMaxLineLength = 500;

		private string[] logLines = new string[15];

		private string logText;

		private bool needRefresh;

		[Tooltip("Save the log to a file in 'Application.persistentDataPath'.")]
		public bool SaveToFile;

		private StringFileWriter logFileWriter;

		private bool isSetup;

		protected override void OnEnable()
		{
			base.OnEnable();
			Application.logMessageReceived -= OnLogMessageReceived;
			Application.logMessageReceived += OnLogMessageReceived;
		}

		protected override void Start()
		{
			base.Start();
			LogText.text = "";
			logLines = new string[LogMaxLines];
			isSetup = true;
		}

		private void OnLogMessageReceived(string _Log, string _Stacktrace, LogType _Type)
		{
			if (!isSetup || _Type == LogType.Warning)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[");
			stringBuilder.Append(DateTime.Now.ToString("HH:mm:ss"));
			stringBuilder.Append("]");
			stringBuilder.Append(" ");
			stringBuilder.Append("[");
			stringBuilder.Append(_Type.ToString());
			stringBuilder.Append("]");
			stringBuilder.Append(" ");
			switch (_Type)
			{
			case LogType.Log:
				if (LogLevel < 2)
				{
					return;
				}
				stringBuilder.Append(_Log);
				break;
			case LogType.Warning:
				if (LogLevel < 1)
				{
					return;
				}
				stringBuilder.Append($"<color=#F1E31A>{_Log}</color>");
				break;
			case LogType.Assert:
				stringBuilder.Append($"<color=#E72D2D>{_Log}: {_Stacktrace.Trim()}</color>");
				break;
			case LogType.Error:
				stringBuilder.Append($"<color=#E72D2D>{_Log}: {_Stacktrace.Trim()}</color>");
				break;
			case LogType.Exception:
				stringBuilder.Append($"<color=#E72D2D>{_Log}: {_Stacktrace.Trim()}</color>");
				break;
			default:
				stringBuilder.Append(_Log);
				break;
			}
			string text = stringBuilder.ToString();
			if (text.Length > 500)
			{
				text = text.Substring(0, 500);
			}
			for (int num = logLines.Length - 1; num >= 0; num--)
			{
				if (num > 0)
				{
					logLines[num] = logLines[num - 1];
				}
				if (num == 0)
				{
					logLines[num] = text;
				}
			}
			StringBuilder stringBuilder2 = new StringBuilder();
			for (int i = 0; i < logLines.Length; i++)
			{
				stringBuilder2.AppendLine(logLines[i]);
			}
			logText = stringBuilder2.ToString();
			needRefresh = true;
			if (SaveToFile)
			{
				if (logFileWriter == null)
				{
					DateTime now = DateTime.Now;
					now.AddSeconds(0f - Time.realtimeSinceStartup);
					string text2 = now.ToString("yyyy.MM.dd_HH.mm.ss");
					string text3 = Path.Combine(Application.persistentDataPath, text2 + "_Log.txt");
					text3 = Path.Combine(Application.persistentDataPath, "DebugLog.txt");
					logFileWriter = new StringFileWriter(text3);
				}
				logFileWriter.Write(text);
			}
		}

		protected override void Update()
		{
			base.Update();
			if (needRefresh)
			{
				needRefresh = false;
				LogText.text = logText;
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			Application.logMessageReceived -= OnLogMessageReceived;
		}
	}
}
