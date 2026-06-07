using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jundroo.ModTools;
using Jundroo.ModTools.Core;
using ModApi.Core;
using UnityEngine;

namespace Assets.Scripts.Logging
{
	public class LogHistory
	{
		public delegate void LogHistoryHandler(LogHistory source, LogEntry entry);

		public enum LoggingStatus
		{
			On = 0,
			Off = 1,
			BeginOnError = 2,
			ErrorsOnly = 3
		}

		public class LogEntry
		{
			public string Condition { get; set; }

			public int FrameNumber { get; set; }

			public string StackTrace { get; set; }

			public LogType Type { get; set; }

			public LogEntry(LogEntry entry)
			{
				FrameNumber = entry.FrameNumber;
				Condition = entry.Condition;
				StackTrace = entry.StackTrace;
				Type = entry.Type;
			}

			public LogEntry(int frameNumber, string condition, string stackTrace, LogType type)
			{
				FrameNumber = frameNumber;
				Condition = condition;
				StackTrace = stackTrace;
				Type = type;
			}

			public override string ToString()
			{
				return $"{Type} ({FrameNumber}): {Condition}\n:{StackTrace}";
			}
		}

		public const int DefaultLogCapacity = 100;

		public const int GameInitializationFrames = 10;

		private static LogHistory _instance;

		private Func<string> _deviceCapsProvider;

		private int _lastFrameWithError;

		private int _logCapacity;

		private int _logCount;

		private LinkedList<LogEntry> _logMessages = new LinkedList<LogEntry>();

		private int _rootErrorCapacity;

		private LinkedList<LogEntry> _rootErrors = new LinkedList<LogEntry>();

		private int _rootErrorsLogCount;

		public static LogHistory Instance
		{
			get
			{
				if (_instance == null)
				{
					Debug.LogError("LogHistory.Initialize() must be called before first-use.");
				}
				return _instance;
			}
		}

		public LogEntry FirstError { get; private set; }

		public LogEntry LastRootError => _rootErrors.Last?.Value;

		public int LogCapacity
		{
			get
			{
				return _logCapacity;
			}
			set
			{
				_logCount = Resize(_logMessages, _logCapacity, value);
				_logCapacity = value;
			}
		}

		public int LogCount => _logCount;

		public IReadOnlyCollection<LogEntry> LogMessages => _logMessages;

		public int RootErrorCapacity
		{
			get
			{
				return _rootErrorCapacity;
			}
			set
			{
				_rootErrorsLogCount = Resize(_rootErrors, _rootErrorCapacity, value);
				_rootErrorCapacity = value;
			}
		}

		public IReadOnlyCollection<LogEntry> RootErrors => _rootErrors;

		public LoggingStatus Status { get; set; } = LoggingStatus.ErrorsOnly;

		public event LogHistoryHandler RootErrorOccurred;

		public LogHistory()
		{
			Application.logMessageReceivedThreaded += OnLogMessageRecieved;
		}

		public static void Initialize(int logCapacity, int rootErrorCapacity, Func<string> deviceCapsProvider)
		{
			if (_instance == null)
			{
				_instance = new LogHistory();
				LogHistory instance = _instance;
				instance._deviceCapsProvider = deviceCapsProvider;
				instance.Clear();
				instance.LogCapacity = logCapacity;
				instance.RootErrorCapacity = rootErrorCapacity;
			}
		}

		public void Clear()
		{
			_lastFrameWithError = -1;
			FirstError = null;
			_logCount = 0;
			_logMessages.Clear();
			_rootErrorsLogCount = 0;
			_rootErrors.Clear();
		}

		public string GenerateReport(bool rootErrorsOnly, bool clearAfter)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("===== Device Info =====\n{0}\n", _deviceCapsProvider());
			IModManager modManager = Game.Instance.ModManagerScript.ModManager;
			if (modManager.KnownMods.Count > 0)
			{
				stringBuilder.AppendLine("===== Mods =====");
				foreach (ModInfo mod in modManager.KnownMods)
				{
					ILoadedMod loadedMod = modManager.LoadedMods.FirstOrDefault((ILoadedMod x) => x.ModInfo == mod);
					stringBuilder.AppendLine();
					stringBuilder.AppendLine(((loadedMod == null) ? "   " : string.Empty) + (mod.Name ?? "Unknown Mod"));
					stringBuilder.AppendLine("   Author: " + (mod.Author ?? "Unknown Author"));
					stringBuilder.AppendLine("   Version: " + (mod.Version?.ToString(2) ?? "Unknown Version"));
					stringBuilder.AppendLine("   Date: " + (mod.LastUpdated.ToString("yyyy-MM-dd HH:mm:ss") ?? "Unknown Date"));
					stringBuilder.AppendLine($"   Enabled: {mod.Enabled}");
					stringBuilder.AppendLine($"   Pending Disable: {mod.PendingDisable}");
					stringBuilder.AppendLine("   Loaded: " + ((loadedMod == null) ? "false" : "true"));
					if (loadedMod != null)
					{
						List<ModLoadMessage> list = modManager.ModLoadWarnings.Where((ModLoadMessage x) => x.Mod == mod).ToList();
						if (list.Count > 0)
						{
							stringBuilder.AppendLine($"   Mod Load Warnings: {list.Count}");
						}
						List<ModLoadMessage> list2 = modManager.ModLoadErrors.Where((ModLoadMessage x) => x.Mod == mod).ToList();
						if (list2.Count > 0)
						{
							stringBuilder.AppendLine($"   Mod Load Errors: {list2.Count}");
						}
					}
					stringBuilder.AppendLine();
				}
			}
			stringBuilder.AppendLine("===== Root Errors =====");
			foreach (LogEntry rootError in RootErrors)
			{
				stringBuilder.AppendLine(rootError.ToString());
			}
			if (!rootErrorsOnly)
			{
				stringBuilder.AppendLine("===== Log Entries =====");
				foreach (LogEntry logMessage in LogMessages)
				{
					stringBuilder.AppendLine(logMessage.ToString());
				}
			}
			if (clearAfter)
			{
				Clear();
			}
			return stringBuilder.ToString();
		}

		private static LogEntry AddEntry(LinkedList<LogEntry> list, int logCapacity, ref int logCount, int frameNumber, string condition, string stackTrace, LogType type)
		{
			LogEntry logEntry = null;
			if (logCount == logCapacity)
			{
				LinkedListNode<LogEntry> first = list.First;
				list.RemoveFirst();
				list.AddLast(first);
				logEntry = first.Value;
				logEntry.FrameNumber = frameNumber;
				logEntry.Condition = condition;
				logEntry.StackTrace = stackTrace;
				logEntry.Type = type;
			}
			else
			{
				logEntry = new LogEntry(frameNumber, condition, stackTrace, type);
				list.AddLast(new LinkedListNode<LogEntry>(logEntry));
				logCount++;
			}
			return logEntry;
		}

		private static bool IsError(LogType type)
		{
			if (type != LogType.Assert && type != LogType.Error)
			{
				return type == LogType.Exception;
			}
			return true;
		}

		private static int Resize(LinkedList<LogEntry> list, int oldCapacity, int newCapacity)
		{
			int num = 0;
			if (newCapacity > 0 && oldCapacity > newCapacity)
			{
				num = list.Count - newCapacity;
				while (num-- > 0)
				{
					list.RemoveFirst();
				}
			}
			return list.Count;
		}

		private static bool ShouldLogEntry(LoggingStatus status, bool isError)
		{
			if (status != LoggingStatus.On)
			{
				if (isError)
				{
					return status == LoggingStatus.ErrorsOnly;
				}
				return false;
			}
			return true;
		}

		private static LoggingStatus UpdateStatus(LoggingStatus currentStatus, bool isError)
		{
			LoggingStatus result = currentStatus;
			if (currentStatus == LoggingStatus.BeginOnError && isError)
			{
				result = LoggingStatus.On;
			}
			return result;
		}

		private void OnLogMessageRecieved(string condition, string stackTrace, LogType type)
		{
			lock (this)
			{
				if (Status == LoggingStatus.Off)
				{
					return;
				}
				bool flag = IsError(type);
				Status = UpdateStatus(Status, flag);
				if (!ShouldLogEntry(Status, flag))
				{
					return;
				}
				int num = -1;
				try
				{
					num = Time.frameCount;
				}
				catch
				{
				}
				LogEntry entry = AddEntry(_logMessages, LogCapacity, ref _logCount, num, condition, stackTrace, type);
				if (flag && num != -1)
				{
					if (FirstError == null)
					{
						FirstError = new LogEntry(entry);
					}
					if (num - _lastFrameWithError > 1)
					{
						LogEntry entry2 = AddEntry(_rootErrors, RootErrorCapacity, ref _rootErrorsLogCount, num, condition, stackTrace, type);
						this.RootErrorOccurred?.Invoke(this, entry2);
					}
					_lastFrameWithError = num;
				}
			}
		}
	}
}
