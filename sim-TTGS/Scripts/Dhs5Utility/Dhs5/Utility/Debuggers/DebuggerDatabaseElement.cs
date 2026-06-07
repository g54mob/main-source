using Dhs5.Utility.Databases;
using UnityEngine;

namespace Dhs5.Utility.Debuggers
{
	public class DebuggerDatabaseElement : BaseEnumDatabaseElement
	{
		[SerializeField]
		private Color m_color;

		[SerializeField]
		private string m_colorString;

		[SerializeField]
		[Range(-1f, 2f)]
		private int m_level;

		[SerializeField]
		private bool m_showLogs = true;

		[SerializeField]
		private bool m_showWarnings = true;

		[SerializeField]
		private bool m_showErrors = true;

		[SerializeField]
		private bool m_showInConsole = true;

		[SerializeField]
		private bool m_showOnScreen = true;

		public Color Color => m_color;

		public string ColorString => m_colorString;

		public bool Active => Level >= 0;

		public int Level => m_level;

		public bool ShowInConsole => m_showInConsole;

		public bool ShowOnScreen => m_showOnScreen;

		public bool CanLog(LogType logType, int logLevel)
		{
			switch (logType)
			{
			case LogType.Log:
				if (Active && m_showLogs)
				{
					return logLevel <= Level;
				}
				return false;
			case LogType.Warning:
				if (Active && m_showWarnings)
				{
					return logLevel <= Level;
				}
				return false;
			case LogType.Error:
			case LogType.Assert:
			case LogType.Exception:
				return m_showErrors;
			default:
				return false;
			}
		}

		public void RefreshColorString()
		{
			m_colorString = ColorUtility.ToHtmlStringRGB(Color);
		}
	}
}
