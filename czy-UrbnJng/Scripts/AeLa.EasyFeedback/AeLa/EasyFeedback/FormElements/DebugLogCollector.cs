using System.Text;
using UnityEngine;

namespace AeLa.EasyFeedback.FormElements
{
	internal class DebugLogCollector : FormElement
	{
		private StringBuilder log;

		public override void Awake()
		{
			base.Awake();
			log = new StringBuilder();
			Application.logMessageReceived += HandleLog;
		}

		protected override void FormClosed()
		{
		}

		protected override void FormOpened()
		{
		}

		protected override void FormSubmitted()
		{
			byte[] bytes = Encoding.ASCII.GetBytes(log.ToString());
			Form.CurrentReport.AttachFile("log.txt", bytes);
		}

		private void HandleLog(string logString, string stackTrace, LogType logType)
		{
			if (logType != LogType.Exception)
			{
				log.AppendFormat("{0}: {1}", logType.ToString(), logString);
			}
			else
			{
				log.AppendLine(logString);
			}
			log.AppendLine(stackTrace);
		}
	}
}
