using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Rhizomatic.Utility
{
	public class UnityConsole
	{
		private ILogHandler logHandler;

		public event LogFormatArgs onLogFormat
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event LogExceptionArgs onLogException
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public UnityConsole(ILogHandler logHandler)
		{
		}

		public void LogException(Exception exception, UnityEngine.Object context)
		{
		}

		public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
		{
		}
	}
}
