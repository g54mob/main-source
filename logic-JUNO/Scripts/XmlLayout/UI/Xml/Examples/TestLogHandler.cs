using System;
using UnityEngine;

namespace UI.Xml.Examples
{
	internal class TestLogHandler : ILogHandler
	{
		private XmlLayout_Example_MessageDialog m_MessageDialog;

		private ILogHandler m_OriginalLogger;

		public TestLogHandler(XmlLayout_Example_MessageDialog messageDialog, ILogHandler originalLogger)
		{
			m_MessageDialog = messageDialog;
			m_OriginalLogger = originalLogger;
		}

		public void LogException(Exception exception, UnityEngine.Object context)
		{
			m_OriginalLogger.LogException(exception, context);
		}

		public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
		{
			if (!m_MessageDialog.gameObject.activeInHierarchy)
			{
				m_MessageDialog.Show(logType.ToString(), string.Format(format, args));
			}
			else
			{
				m_MessageDialog.AppendText(string.Format(format, args));
			}
			m_OriginalLogger.LogFormat(logType, context, format, args);
		}
	}
}
