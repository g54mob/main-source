using System.Text;
using AeLa.EasyFeedback;
using UnityEngine;

namespace PajamaLlama.External.EasyFeedback
{
	public class EasyFeedbackLogCollector : FormElement
	{
		private StringBuilder _log;

		private string _lastLogString;

		private string _lastStackTrace;

		private LogType _lastLogType;

		private int _lastLogCount;

		public override void Awake()
		{
			base.Awake();
			switch (Application.platform)
			{
			case RuntimePlatform.OSXEditor:
			case RuntimePlatform.OSXPlayer:
			case RuntimePlatform.WindowsPlayer:
			case RuntimePlatform.WindowsEditor:
			case RuntimePlatform.LinuxPlayer:
			case RuntimePlatform.LinuxEditor:
				_log = new StringBuilder();
				Application.logMessageReceived += HandleLog;
				break;
			}
		}

		protected override void FormClosed()
		{
		}

		protected override void FormOpened()
		{
		}

		protected override void FormSubmitted()
		{
			if (_lastLogString != null)
			{
				AppendLog(_lastLogString, _lastStackTrace, _lastLogType, _lastLogCount);
			}
			byte[] bytes = Encoding.ASCII.GetBytes(_log.ToString());
			Form.CurrentReport.AttachFile("log.txt", bytes);
		}

		private void HandleLog(string logString, string stackTrace, LogType logType)
		{
			if (logString != _lastLogString || stackTrace != _lastStackTrace || _lastLogType != logType)
			{
				AppendLog(_lastLogString, _lastStackTrace, _lastLogType, _lastLogCount);
				_lastLogString = logString;
				_lastStackTrace = stackTrace;
				_lastLogType = logType;
				_lastLogCount = 1;
			}
			else
			{
				_lastLogCount++;
			}
		}

		private void AppendLog(string logString, string stackTrace, LogType logType, int count)
		{
			if (logType == LogType.Exception)
			{
				_log.AppendLine($"({count}) {logString}");
			}
			else
			{
				_log.Append($"{logType.ToString()} ({count}): {logString}");
			}
			_log.AppendLine(stackTrace);
		}
	}
}
