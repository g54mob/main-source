using System;
using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Storage;
using UnityEngine;

namespace Assets.Scripts.Analytics.Logging
{
	public static class MobileLogger
	{
		private enum MobileFileLoggingType
		{
			None = 0,
			Minimal = 1,
			Full = 2,
			Realtime = 3
		}

		private static readonly object _lock = new object();

		private static bool _forceRealtimeLogging;

		private static bool _initialized;

		private static string _logFileBackupPath;

		private static string _logFilePath;

		private static MobileFileLoggingType _loggingType;

		private static List<string> _pendingLogs;

		public static bool ForceRealtimeLogging
		{
			get
			{
				return _forceRealtimeLogging;
			}
			set
			{
				_forceRealtimeLogging = value;
			}
		}

		public static void FlushPendingLogsToFile()
		{
			List<string> pendingLogs = _pendingLogs;
			if (pendingLogs == null || pendingLogs.Count == 0)
			{
				return;
			}
			try
			{
				lock (_lock)
				{
					using (StreamWriter streamWriter = new StreamWriter(_logFilePath, append: true))
					{
						foreach (string pendingLog in _pendingLogs)
						{
							streamWriter.WriteLine(pendingLog);
						}
					}
					_pendingLogs.Clear();
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		public static void Initialize()
		{
			if (Game.Instance.Device.IsMobileBuild && !Game.Instance.Device.IsAndroidVRBuild && !_initialized)
			{
				_initialized = true;
				_pendingLogs = new List<string>();
				_logFilePath = GameData.GetPath("player.log.txt");
				_logFileBackupPath = GameData.GetPath("player-prev.log.txt");
				_loggingType = MobileFileLoggingType.Full;
				_forceRealtimeLogging = true;
				InitializeLogFile();
				Application.logMessageReceivedThreaded += OnLogMessageReceived;
			}
		}

		private static void InitializeLogFile()
		{
			try
			{
				if (File.Exists(_logFileBackupPath))
				{
					File.Delete(_logFileBackupPath);
				}
				if (File.Exists(_logFilePath))
				{
					File.Copy(_logFilePath, _logFileBackupPath);
				}
				if (File.Exists(_logFilePath))
				{
					File.Delete(_logFilePath);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private static void OnLogMessageReceived(string log, string stackTrace, LogType type)
		{
			MobileFileLoggingType mobileFileLoggingType = (_forceRealtimeLogging ? MobileFileLoggingType.Realtime : _loggingType);
			switch (mobileFileLoggingType)
			{
			case MobileFileLoggingType.Minimal:
				if (type == LogType.Log)
				{
					return;
				}
				break;
			case MobileFileLoggingType.None:
				return;
			}
			log = ((type != LogType.Log) ? (string.IsNullOrEmpty(stackTrace) ? $"[{type}] {log}" : $"[{type}] {log}{System.Environment.NewLine}{stackTrace}") : (string.IsNullOrEmpty(stackTrace) ? log : (log + System.Environment.NewLine + stackTrace)));
			lock (_lock)
			{
				_pendingLogs.Add(log);
			}
			if (mobileFileLoggingType == MobileFileLoggingType.Realtime)
			{
				FlushPendingLogsToFile();
			}
		}
	}
}
