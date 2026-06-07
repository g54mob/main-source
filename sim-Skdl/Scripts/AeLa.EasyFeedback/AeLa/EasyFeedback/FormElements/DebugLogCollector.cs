using System.Text;
using UnityEngine;

namespace AeLa.EasyFeedback.FormElements
{
	internal class DebugLogCollector : FormElement
	{
		private StringBuilder log;

		public static string[] IgnoreList;

		public override void Awake()
		{
		}

		protected override void FormClosed()
		{
		}

		protected override void FormOpened()
		{
		}

		protected override void FormSubmitted()
		{
		}

		private void HandleLog(string logString, string stackTrace, LogType logType)
		{
		}
	}
}
