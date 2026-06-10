using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using UnityEngine;

namespace NSMedieval
{
	public static class DebugTimer
	{
		private static readonly ConcurrentDictionary<string, DateTime> TimerStart = new ConcurrentDictionary<string, DateTime>();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			TimerStart.Clear();
		}

		public static void StartTimer(string name, bool traceLog = false)
		{
			DateTime now = DateTime.Now;
			TimerStart[name] = now;
			bool isEnabled;
			if (traceLog)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(14, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DebugTimer.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Started timer ");
					messageBuilder.AppendFormatted(name);
				}
				Log.Trace(messageBuilder);
			}
			else
			{
				FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(14, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DebugTimer.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Started timer ");
					messageBuilder2.AppendFormatted(name);
				}
				Log.Info(messageBuilder2);
			}
		}

		[Conditional("UNITY_EDITOR")]
		public static void StartTimerEditorOnly(string name, bool traceLog = false)
		{
			StartTimer(name, traceLog);
		}

		public static void EndTimer(string name, bool traceLog = false)
		{
			DateTime now = DateTime.Now;
			bool isEnabled;
			if (TimerStart.TryGetValue(name, out var value))
			{
				double totalSeconds = (now - value).TotalSeconds;
				if (traceLog)
				{
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(25, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DebugTimer.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Timer ");
						messageBuilder.AppendFormatted(name);
						messageBuilder.AppendLiteral(" ended. Duration: ");
						messageBuilder.AppendFormatted(totalSeconds, "F3");
						messageBuilder.AppendLiteral("s");
					}
					Log.Trace(messageBuilder);
				}
				else
				{
					FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(25, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DebugTimer.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Timer ");
						messageBuilder2.AppendFormatted(name);
						messageBuilder2.AppendLiteral(" ended. Duration: ");
						messageBuilder2.AppendFormatted(totalSeconds, "F3");
						messageBuilder2.AppendLiteral("s");
					}
					Log.Info(messageBuilder2);
				}
				TimerStart.Remove(name);
			}
			else
			{
				FVLogWarningInterpolationHandler messageBuilder3 = new FVLogWarningInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DebugTimer.cs");
				if (isEnabled)
				{
					messageBuilder3.AppendLiteral("Timer ");
					messageBuilder3.AppendFormatted(name);
					messageBuilder3.AppendLiteral(" was not started");
				}
				Log.Warning(messageBuilder3);
			}
		}

		[Conditional("UNITY_EDITOR")]
		public static void EndTimerEditorOnly(string name, bool traceLog = false)
		{
			EndTimer(name, traceLog);
		}

		public static void LogStep(string timerName, string stepName)
		{
			DateTime now = DateTime.Now;
			bool isEnabled;
			if (TimerStart.TryGetValue(timerName, out var value))
			{
				double totalSeconds = (now - value).TotalSeconds;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(37, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DebugTimer.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Timer ");
					messageBuilder.AppendFormatted(timerName);
					messageBuilder.AppendLiteral(" - ");
					messageBuilder.AppendFormatted(stepName);
					messageBuilder.AppendLiteral(". It took ");
					messageBuilder.AppendFormatted(totalSeconds);
					messageBuilder.AppendLiteral("s from timer start");
				}
				Log.Info(messageBuilder);
			}
			else
			{
				FVLogWarningInterpolationHandler messageBuilder2 = new FVLogWarningInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DebugTimer.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Timer ");
					messageBuilder2.AppendFormatted(timerName);
					messageBuilder2.AppendLiteral(" was not started");
				}
				Log.Warning(messageBuilder2);
			}
		}
	}
}
