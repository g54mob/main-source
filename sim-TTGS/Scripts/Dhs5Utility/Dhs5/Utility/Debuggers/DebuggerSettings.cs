using Dhs5.Utility.Settings;
using UnityEngine;

namespace Dhs5.Utility.Debuggers
{
	[Settings("Editor/Debugger", Scope.User)]
	public class DebuggerSettings : CustomSettings<DebuggerSettings>
	{
		[Header("Console Debugger")]
		[SerializeField]
		[Range(8f, 18f)]
		private int m_consoleLog0Size = 14;

		[SerializeField]
		[Range(8f, 18f)]
		private int m_consoleLog1Size = 12;

		[SerializeField]
		[Range(8f, 18f)]
		private int m_consoleLog2Size = 11;

		[Header("Screen Debugger")]
		[SerializeField]
		[Min(1f)]
		private float m_defaultScreenLogDuration = 5f;

		[SerializeField]
		private bool m_showScreenLogsTime = true;

		[Header("Screen Debugger GUI")]
		[SerializeField]
		private Rect m_screenLogsRect = new Rect(10f, 10f, 700f, 500f);

		[SerializeField]
		[Range(10f, 40f)]
		private float m_screenLogHeight = 20f;

		[Space(10f)]
		[SerializeField]
		[Range(10f, 30f)]
		private int m_screenLog0Size = 20;

		[SerializeField]
		[Range(10f, 30f)]
		private int m_screenLog1Size = 18;

		[SerializeField]
		[Range(10f, 30f)]
		private int m_screenLog2Size = 16;

		[Space(10f)]
		[SerializeField]
		[Range(10f, 30f)]
		private int m_screenLogsTimeSize = 18;

		public static float DefaultScreenLogDuration
		{
			get
			{
				if (!(CustomSettings<DebuggerSettings>.I != null))
				{
					return 5f;
				}
				return CustomSettings<DebuggerSettings>.I.m_defaultScreenLogDuration;
			}
		}

		public static bool ShowScreenLogsTime
		{
			get
			{
				if (!(CustomSettings<DebuggerSettings>.I != null))
				{
					return true;
				}
				return CustomSettings<DebuggerSettings>.I.m_showScreenLogsTime;
			}
		}

		public static Rect ScreenLogsRect
		{
			get
			{
				if (!(CustomSettings<DebuggerSettings>.I != null))
				{
					return new Rect(10f, 10f, 700f, 500f);
				}
				return CustomSettings<DebuggerSettings>.I.m_screenLogsRect;
			}
		}

		public static float ScreenLogHeight
		{
			get
			{
				if (!(CustomSettings<DebuggerSettings>.I != null))
				{
					return 20f;
				}
				return CustomSettings<DebuggerSettings>.I.m_screenLogHeight;
			}
		}

		public static int MaxLogsOnScreen
		{
			get
			{
				if (!(CustomSettings<DebuggerSettings>.I != null))
				{
					return 25;
				}
				return Mathf.FloorToInt(CustomSettings<DebuggerSettings>.I.m_screenLogsRect.height / CustomSettings<DebuggerSettings>.I.m_screenLogHeight);
			}
		}

		public static int ScreenLogsTimeSize
		{
			get
			{
				if (!(CustomSettings<DebuggerSettings>.I != null))
				{
					return 18;
				}
				return CustomSettings<DebuggerSettings>.I.m_screenLogsTimeSize;
			}
		}

		public static int GetConsoleLogSize(int level)
		{
			if (CustomSettings<DebuggerSettings>.I != null)
			{
				switch (level)
				{
				case 0:
					return CustomSettings<DebuggerSettings>.I.m_consoleLog0Size;
				case 1:
					return CustomSettings<DebuggerSettings>.I.m_consoleLog1Size;
				case 2:
					return CustomSettings<DebuggerSettings>.I.m_consoleLog2Size;
				}
			}
			return 12;
		}

		public static int GetScreenLogSize(int level)
		{
			if (CustomSettings<DebuggerSettings>.I != null)
			{
				switch (level)
				{
				case 0:
					return CustomSettings<DebuggerSettings>.I.m_screenLog0Size;
				case 1:
					return CustomSettings<DebuggerSettings>.I.m_screenLog1Size;
				case 2:
					return CustomSettings<DebuggerSettings>.I.m_screenLog2Size;
				}
			}
			return 18;
		}
	}
}
