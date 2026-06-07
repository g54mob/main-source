using System;
using UnityEngine;

namespace Gh.Tk
{
	public class GreenheartLogHandler : ILogHandler
	{
		private readonly ILogHandler _defaultLogHandler;

		private string[] _ignoreErrorFragments;

		private string[] _ignoreWarningFragments;

		public GreenheartLogHandler(ILogHandler defaultLogHandler)
		{
		}

		public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
		{
		}

		public void LogException(Exception exception, UnityEngine.Object context)
		{
		}
	}
}
