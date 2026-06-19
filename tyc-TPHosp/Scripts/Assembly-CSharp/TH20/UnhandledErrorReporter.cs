#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using Backtrace.Unity;
using Backtrace.Unity.Model;
using TH20.Analytics;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public class UnhandledErrorReporter : MustCallDestroy, ILogHandler
	{
		private readonly UnhandledErrorDialogue _unhandledErrorDialogue;

		private readonly Action<bool> _setSuperPausedAction;

		private readonly Logger _logger;

		private readonly AnalyticsManager _analyticsManager;

		private readonly BacktraceClient _backtraceClient;

		private bool _debugErrorDialogueForceContinuable = true;

		private bool _debugErrorDialogueEnabled = true;

		private bool _errorReportAnalyticsHitRateLimitTrigger;

		private long _frameLastErrorReportSent = -1L;

		private int _numConsecutiveErrorReportMessagesSent;

		private int _numErrorReportMessagesSent;

		public UnhandledErrorReporter(UnhandledErrorDialogue unhandledErrorDialogue, Action<bool> setSuperPausedAction, Logger logger, AnalyticsManager analyticsManager, BacktraceClient backtraceClient)
		{
			_unhandledErrorDialogue = unhandledErrorDialogue;
			_setSuperPausedAction = setSuperPausedAction;
			_logger = logger;
			_analyticsManager = analyticsManager;
			_backtraceClient = backtraceClient;
			Application.logMessageReceived += ApplicationOnLogMessageReceived;
			_logger.AddLogHandler(this);
			ConsoleCommandsDatabase.RegisterCommand("SetErrorDialogueContinuable", "Forces the 'continue' button enabled", "SetErrorDialogueContinuable [false|true]", Debug_SetErrorDialogueContinuable);
			ConsoleCommandsDatabase.RegisterCommand("SetErrorDialogueEnabled", "Completely enables/disables the error reporter dialogue", "SetErrorDialogueEnabled [false|true]", Debug_SetErrorDialogueEnabled);
			ConsoleCommandsDatabase.RegisterCommand("LogTestError", "Logs an error, to test error handling stuff", "LogTestError", Debug_LogTestError);
			ConsoleCommandsDatabase.RegisterCommand("LogTestWarning", "Logs a warning, to test error handling stuff", "LogTestWarning", Debug_LogTestWarning);
		}

		private ConsoleCommandResult Debug_SetErrorDialogueContinuable(params string[] args)
		{
			return ConsoleCommandHelpers.ExtractBool(delegate(bool continuable)
			{
				_debugErrorDialogueForceContinuable = continuable;
				_unhandledErrorDialogue.OverrideContinuable(_debugErrorDialogueForceContinuable);
			}, args);
		}

		private ConsoleCommandResult Debug_SetErrorDialogueEnabled(params string[] args)
		{
			return ConsoleCommandHelpers.ExtractBool(delegate(bool enabled)
			{
				_debugErrorDialogueEnabled = enabled;
				if (!_debugErrorDialogueEnabled && _unhandledErrorDialogue.gameObject.activeSelf)
				{
					_unhandledErrorDialogue.gameObject.SetActive(value: false);
					_setSuperPausedAction(obj: false);
				}
			}, args);
		}

		private ConsoleCommandResult Debug_LogTestError(params string[] args)
		{
			_logger.Error(_unhandledErrorDialogue, LogChannels.Debug, "Example error");
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_LogTestWarning(params string[] args)
		{
			_logger.Warning(_unhandledErrorDialogue, LogChannels.Debug, "Example warning");
			return ConsoleCommandResult.Succeeded();
		}

		public override void Destroy()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("SetErrorDialogueContinuable");
			ConsoleCommandsDatabase.UnRegisterCommand("SetErrorDialogueEnabled");
			_logger.RemoveLogHandler(this);
			Application.logMessageReceived -= ApplicationOnLogMessageReceived;
			base.Destroy();
		}

		private void TryShowDialogueCommon(string message, string stackTrace)
		{
			if (ThreadingUtils.IsOnMainThread() && _debugErrorDialogueEnabled && !_unhandledErrorDialogue.gameObject.activeSelf)
			{
				bool canBeContinuedFrom = Application.isEditor || _debugErrorDialogueForceContinuable;
				_unhandledErrorDialogue.Show(message, stackTrace, canBeContinuedFrom, delegate
				{
					_setSuperPausedAction(obj: false);
				});
				_setSuperPausedAction(obj: true);
				if (DebugVars.BreakOnError.Value)
				{
					UnityEngine.Debug.Break();
				}
			}
		}

		private void TrySendErrorBacktrace(LogEntry logEntry)
		{
			if (!(_backtraceClient == null) && _backtraceClient.Enabled)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("session_id", _analyticsManager.SessionID);
				dictionary.Add("log.channel", logEntry.Channel.Name.ToString());
				dictionary.Add("log.level", logEntry.Level.ToString());
				dictionary.Add("log.frameCount", logEntry.FrameCount.ToString());
				dictionary.Add("log.callstack", LogCallStack.CallStackToString(logEntry.CallStack));
				BacktraceReport report = new BacktraceReport(logEntry.Message, dictionary);
				_backtraceClient.Send(report);
			}
		}

		private void TrySendErrorAnalytics(string condition, string stackTrace, LogChannel channel, long frameCount)
		{
			if (_errorReportAnalyticsHitRateLimitTrigger)
			{
				return;
			}
			if (frameCount - _frameLastErrorReportSent <= 1)
			{
				_numConsecutiveErrorReportMessagesSent++;
				if (_numConsecutiveErrorReportMessagesSent >= 10)
				{
					_errorReportAnalyticsHitRateLimitTrigger = true;
					return;
				}
			}
			else
			{
				_numConsecutiveErrorReportMessagesSent = 0;
			}
			if (_numErrorReportMessagesSent >= 100)
			{
				_errorReportAnalyticsHitRateLimitTrigger = true;
				return;
			}
			_frameLastErrorReportSent = frameCount;
			GameEvent gameEvent = new GameEvent(_analyticsManager.Config.UnhandledErrorInfo).AddParam("callstack", StringUtils.TrimMiddle(stackTrace, 65535)).AddParam("error_message", StringUtils.TrimMiddle(condition, 65535)).AddParam("channel", (channel == null) ? "" : channel.Name)
				.AddParam("frame_number", frameCount)
				.AddParam("type", "Error")
				.AddParam("unformatted", "")
				.AddParam("number", _numErrorReportMessagesSent);
			_numErrorReportMessagesSent++;
			_analyticsManager.RecordEvent(gameEvent);
		}

		private void ApplicationOnLogMessageReceived(string condition, string stackTrace, LogType type)
		{
			if ((type == LogType.Exception || type == LogType.Error || type == LogType.Assert) && !(stackTrace == "") && !condition.Contains("Screen position out of view frustum"))
			{
				TrySendErrorAnalytics(condition, stackTrace, LogChannels.Unity, Time.frameCount);
			}
		}

		void ILogHandler.Log(LogEntry logEntry)
		{
			if (logEntry.Level >= LogLevel.Error && logEntry.Level != LogLevel.AlwaysLog && (logEntry.Channel == null || logEntry.Channel != LogChannels.Unity))
			{
				TrySendErrorAnalytics(logEntry.Message, LogCallStack.CallStackToString(logEntry.CallStack), logEntry.Channel, logEntry.FrameCount);
				TrySendErrorBacktrace(logEntry);
			}
		}

		bool ILogHandler.RequestsCallstackAtLevel(LogLevel logLevel)
		{
			if (logLevel >= LogLevel.Error)
			{
				return logLevel != LogLevel.AlwaysLog;
			}
			return false;
		}
	}
}
