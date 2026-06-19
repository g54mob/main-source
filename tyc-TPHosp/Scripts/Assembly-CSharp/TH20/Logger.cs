using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	public class Logger
	{
		private readonly StringBuilder _stringBuilder;

		private readonly DateFastFormatter _dateFastFormatter;

		private List<LogCallStackFrame> _callStackCache = new List<LogCallStackFrame>();

		private readonly List<ILogHandler> _logHandlers = new List<ILogHandler>();

		private bool _currentlyLogging;

		private bool[] _someHandlerWantsCallStacksAtLevel = new bool[6];

		public LogLevel MinimumLogLevel { get; set; }

		public LogLevel MinimumLogLevelToRequestCallstacks { get; set; }

		public Logger(bool captureUnityLogs = true)
		{
			_stringBuilder = new StringBuilder();
			_dateFastFormatter = new DateFastFormatter();
			MinimumLogLevel = (LogLevel)Math.Max(3, (int)LogLevelHelpers.LowestLogLevelCompiledIn);
			MinimumLogLevelToRequestCallstacks = LogLevel.Information;
			if (captureUnityLogs)
			{
				Application.logMessageReceived += HandleUnityLogMessageReceived;
			}
		}

		private static LogLevel LogLevelFromUnityLogType(LogType logType)
		{
			return logType switch
			{
				LogType.Error => LogLevel.Error, 
				LogType.Assert => LogLevel.Error, 
				LogType.Warning => LogLevel.Warning, 
				LogType.Log => LogLevel.Information, 
				LogType.Exception => LogLevel.Error, 
				_ => throw new ArgumentOutOfRangeException("logType", logType, null), 
			};
		}

		[StackTraceIgnore]
		private void HandleUnityLogMessageReceived(string condition, string stackTrace, LogType type)
		{
			LogLevel logLevel = LogLevelFromUnityLogType(type);
			if (logLevel < MinimumLogLevel)
			{
				return;
			}
			lock (_logHandlers)
			{
				if (_currentlyLogging)
				{
					return;
				}
				_currentlyLogging = true;
				try
				{
					List<LogCallStackFrame> list = null;
					if (_someHandlerWantsCallStacksAtLevel[(int)logLevel] && logLevel >= MinimumLogLevelToRequestCallstacks)
					{
						LogCallStack.GetCallstack(ref _callStackCache);
						list = new List<LogCallStackFrame>(_callStackCache);
						if (list.Count == 0 || list[0].FormattedMethodName.Contains("StartCoroutine_Auto_Internal"))
						{
							list = LogCallStack.GetCallstackFromUnityLog(stackTrace);
						}
						string filename = "";
						int lineNumber = 0;
						if (LogCallStackFrame.ExtractFileAndLineInfoFromUnityMessage(condition, ref filename, ref lineNumber))
						{
							list.Insert(0, new LogCallStackFrame(condition, filename, lineNumber));
						}
					}
					for (int i = 0; i < _logHandlers.Count; i++)
					{
						string message = condition.TrimEnd(null);
						DateTime dateTime = TimeUtils.NowSafe();
						int frameCount = Time.frameCount;
						LogEntry logEntry = new LogEntry(null, LogChannels.Unity, logLevel, list, message, dateTime, _dateFastFormatter.FormatDateTimeString(dateTime), frameCount);
						_logHandlers[i].Log(logEntry);
					}
				}
				finally
				{
					_currentlyLogging = false;
				}
			}
		}

		public void UpdateHandlersThatWantCallStacks()
		{
			lock (_logHandlers)
			{
				for (int i = 0; i < 6; i++)
				{
					for (int j = 0; j < _logHandlers.Count; j++)
					{
						if (_logHandlers[j].RequestsCallstackAtLevel((LogLevel)i))
						{
							_someHandlerWantsCallStacksAtLevel[i] = true;
							return;
						}
					}
					_someHandlerWantsCallStacksAtLevel[i] = false;
				}
			}
		}

		public void AddLogHandler(ILogHandler handler)
		{
			lock (_logHandlers)
			{
				_logHandlers.Add(handler);
				for (int i = 0; i < 6; i++)
				{
					if (handler.RequestsCallstackAtLevel((LogLevel)i))
					{
						_someHandlerWantsCallStacksAtLevel[i] = true;
					}
				}
			}
		}

		public T GetLogHandler<T>() where T : class, ILogHandler
		{
			lock (_logHandlers)
			{
				for (int i = 0; i < _logHandlers.Count; i++)
				{
					if (_logHandlers[i] is T result)
					{
						return result;
					}
				}
				return null;
			}
		}

		public void RemoveLogHandler(ILogHandler handler)
		{
			lock (_logHandlers)
			{
				_logHandlers.Remove(handler);
				UpdateHandlersThatWantCallStacks();
			}
		}

		[StackTraceIgnore]
		private void LogMessage(string message, LogLevel level, LogChannel channel, UnityEngine.Object obj)
		{
			if (level < MinimumLogLevel)
			{
				return;
			}
			lock (_logHandlers)
			{
				if (_currentlyLogging)
				{
					return;
				}
				_currentlyLogging = true;
				try
				{
					LogMessageInner(message, level, channel, obj);
				}
				finally
				{
					_currentlyLogging = false;
				}
			}
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		private void LogMessage(string message, LogLevel level, LogChannel channel, UnityEngine.Object obj, params object[] args)
		{
			if (level < MinimumLogLevel)
			{
				return;
			}
			lock (_logHandlers)
			{
				if (_currentlyLogging)
				{
					return;
				}
				_currentlyLogging = true;
				try
				{
					_stringBuilder.Length = 0;
					if (args.Length != 0)
					{
						_stringBuilder.AppendFormat(message, args);
					}
					else
					{
						_stringBuilder.Append(message);
					}
					string formattedMessage = _stringBuilder.ToString();
					LogMessageInner(formattedMessage, level, channel, obj);
				}
				finally
				{
					_currentlyLogging = false;
				}
			}
		}

		[StackTraceIgnore]
		private void LogMessageInner(string formattedMessage, LogLevel level, LogChannel channel, UnityEngine.Object obj)
		{
			List<LogCallStackFrame> callStack = null;
			if (_someHandlerWantsCallStacksAtLevel[(int)level] && level >= MinimumLogLevelToRequestCallstacks)
			{
				LogCallStack.GetCallstack(ref _callStackCache);
				callStack = new List<LogCallStackFrame>(_callStackCache);
			}
			DateTime dateTime = TimeUtils.NowSafe();
			int num = (ThreadingUtils.IsOnMainThread() ? Time.frameCount : (-1));
			LogEntry logEntry = new LogEntry(obj, channel, level, callStack, formattedMessage, dateTime, _dateFastFormatter.FormatDateTimeString(dateTime), num);
			for (int i = 0; i < _logHandlers.Count; i++)
			{
				_logHandlers[i].Log(logEntry);
			}
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		public void Verbose(string message, params object[] args)
		{
			LogMessage(message, LogLevel.Verbose, null, null, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		public void Verbose(string message)
		{
			LogMessage(message, LogLevel.Verbose, null, null);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		public void Verbose(UnityEngine.Object obj, string message)
		{
			LogMessage(message, LogLevel.Verbose, null, obj);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		public void Verbose(UnityEngine.Object obj, string message, params object[] args)
		{
			LogMessage(message, LogLevel.Verbose, null, obj, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		public void Verbose(LogChannel channel, string message)
		{
			LogMessage(message, LogLevel.Verbose, channel, null);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		public void Verbose(LogChannel channel, string message, params object[] args)
		{
			LogMessage(message, LogLevel.Verbose, channel, null, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		public void Verbose(UnityEngine.Object obj, LogChannel channel, string message)
		{
			LogMessage(message, LogLevel.Verbose, channel, obj);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		public void Verbose(UnityEngine.Object obj, LogChannel channel, string message, params object[] args)
		{
			LogMessage(message, LogLevel.Verbose, channel, obj, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		public void Debug(string message)
		{
			LogMessage(message, LogLevel.Debug, null, null);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		public void Debug(string message, params object[] args)
		{
			LogMessage(message, LogLevel.Debug, null, null, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		public void Debug(UnityEngine.Object obj, string message)
		{
			LogMessage(message, LogLevel.Debug, null, obj);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		public void Debug(UnityEngine.Object obj, string message, params object[] args)
		{
			LogMessage(message, LogLevel.Debug, null, obj, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		public void Debug(LogChannel channel, string message)
		{
			LogMessage(message, LogLevel.Debug, channel, null);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		public void Debug(LogChannel channel, string message, params object[] args)
		{
			LogMessage(message, LogLevel.Debug, channel, null, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		public void Debug(UnityEngine.Object obj, LogChannel channel, string message)
		{
			LogMessage(message, LogLevel.Debug, channel, obj);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		public void Debug(UnityEngine.Object obj, LogChannel channel, string message, params object[] args)
		{
			LogMessage(message, LogLevel.Debug, channel, obj, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		public void Info(string message)
		{
			LogMessage(message, LogLevel.Information, null, null);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		public void Info(string message, params object[] args)
		{
			LogMessage(message, LogLevel.Information, null, null, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		public void Info(UnityEngine.Object obj, string message)
		{
			LogMessage(message, LogLevel.Information, null, obj);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		public void Info(UnityEngine.Object obj, string message, params object[] args)
		{
			LogMessage(message, LogLevel.Information, null, obj, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		public void Info(LogChannel channel, string message)
		{
			LogMessage(message, LogLevel.Information, channel, null);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		public void Info(LogChannel channel, string message, params object[] args)
		{
			LogMessage(message, LogLevel.Information, channel, null, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		public void Info(UnityEngine.Object obj, LogChannel channel, string message)
		{
			LogMessage(message, LogLevel.Information, channel, obj);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		public void Info(UnityEngine.Object obj, LogChannel channel, string message, params object[] args)
		{
			LogMessage(message, LogLevel.Information, channel, obj, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		public void Warning(string message)
		{
			LogMessage(message, LogLevel.Warning, null, null);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		public void Warning(string message, params object[] args)
		{
			LogMessage(message, LogLevel.Warning, null, null, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		public void Warning(UnityEngine.Object obj, string message)
		{
			LogMessage(message, LogLevel.Warning, null, obj);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		public void Warning(UnityEngine.Object obj, string message, params object[] args)
		{
			LogMessage(message, LogLevel.Warning, null, obj, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		public void Warning(LogChannel channel, string message)
		{
			LogMessage(message, LogLevel.Warning, channel, null);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		public void Warning(LogChannel channel, string message, params object[] args)
		{
			LogMessage(message, LogLevel.Warning, channel, null, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		public void Warning(UnityEngine.Object obj, LogChannel channel, string message)
		{
			LogMessage(message, LogLevel.Warning, channel, obj);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		public void Warning(UnityEngine.Object obj, LogChannel channel, string message, params object[] args)
		{
			LogMessage(message, LogLevel.Warning, channel, obj, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		public void Error(string message)
		{
			LogMessage(message, LogLevel.Error, null, null);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		public void Error(string message, params object[] args)
		{
			LogMessage(message, LogLevel.Error, null, null, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		public void Error(UnityEngine.Object obj, string message)
		{
			LogMessage(message, LogLevel.Error, null, obj);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		public void Error(UnityEngine.Object obj, string message, params object[] args)
		{
			LogMessage(message, LogLevel.Error, null, obj, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		public void Error(LogChannel channel, string message)
		{
			LogMessage(message, LogLevel.Error, channel, null);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		public void Error(LogChannel channel, string message, params object[] args)
		{
			LogMessage(message, LogLevel.Error, channel, null, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		public void Error(UnityEngine.Object obj, LogChannel channel, string message)
		{
			LogMessage(message, LogLevel.Error, channel, obj);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		public void Error(UnityEngine.Object obj, LogChannel channel, string message, params object[] args)
		{
			LogMessage(message, LogLevel.Error, channel, obj, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		[Conditional("LOG_LEVEL_ALWAYSLOG")]
		public void AlwaysLog(string message)
		{
			LogMessage(message, LogLevel.AlwaysLog, null, null);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		[Conditional("LOG_LEVEL_ALWAYSLOG")]
		public void AlwaysLog(string message, params object[] args)
		{
			LogMessage(message, LogLevel.AlwaysLog, null, null, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		[Conditional("LOG_LEVEL_ALWAYSLOG")]
		public void AlwaysLog(UnityEngine.Object obj, string message)
		{
			LogMessage(message, LogLevel.AlwaysLog, null, obj);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		[Conditional("LOG_LEVEL_ALWAYSLOG")]
		public void AlwaysLog(UnityEngine.Object obj, string message, params object[] args)
		{
			LogMessage(message, LogLevel.AlwaysLog, null, obj, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		[Conditional("LOG_LEVEL_ALWAYSLOG")]
		public void AlwaysLog(LogChannel channel, string message)
		{
			LogMessage(message, LogLevel.AlwaysLog, channel, null);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		[Conditional("LOG_LEVEL_ALWAYSLOG")]
		public void AlwaysLog(LogChannel channel, string message, params object[] args)
		{
			LogMessage(message, LogLevel.AlwaysLog, channel, null, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		[Conditional("LOG_LEVEL_ALWAYSLOG")]
		public void AlwaysLog(UnityEngine.Object obj, LogChannel channel, string message)
		{
			LogMessage(message, LogLevel.AlwaysLog, channel, obj);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		[Conditional("LOG_LEVEL_ALWAYSLOG")]
		public void AlwaysLog(UnityEngine.Object obj, LogChannel channel, string message, params object[] args)
		{
			LogMessage(message, LogLevel.AlwaysLog, channel, obj, args);
		}
	}
}
