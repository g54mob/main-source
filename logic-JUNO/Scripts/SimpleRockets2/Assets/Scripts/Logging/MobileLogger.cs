using System;
using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Settings;
using ModApi;
using ModApi.Settings;
using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using UnityEngine;

namespace Assets.Scripts.Logging
{
	public static class MobileLogger
	{
		private static readonly object _lock = new object();

		private static bool _forceRealtimeLogging;

		private static bool _initialized;

		private static string _logFileBackupPath;

		private static string _logFilePath;

		private static GeneralSettings.MobileFileLoggingType _loggingType;

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
			if (Device.IsMobileBuild && !_initialized)
			{
				_initialized = true;
				_pendingLogs = new List<string>();
				_logFilePath = Path.Combine(Game.PersistentDataPath, "player.log.txt");
				_logFileBackupPath = Path.Combine(Game.PersistentDataPath, "player-prev.log.txt");
				_loggingType = GeneralSettings.MobileFileLoggingType.Realtime;
				_forceRealtimeLogging = true;
				InitializeLogFile();
				Application.logMessageReceivedThreaded += OnLogMessageReceived;
				if (Game.IsInitialized)
				{
					EnumSetting<GeneralSettings.MobileFileLoggingType> mobileFileLogging = Game.Instance.Settings.Game.General.MobileFileLogging;
					mobileFileLogging.Changed += OnSettingChanged;
					_loggingType = mobileFileLogging.Value;
				}
				else
				{
					ApplicationSettings.Loaded += OnApplicationSettingsLoaded;
				}
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

		private static void OnApplicationSettingsLoaded(ApplicationSettings settings)
		{
			EnumSetting<GeneralSettings.MobileFileLoggingType> mobileFileLogging = settings.Game.General.MobileFileLogging;
			mobileFileLogging.Changed += OnSettingChanged;
			OnSettingChanged(null, new SettingChangedEventArgs<GeneralSettings.MobileFileLoggingType>(mobileFileLogging));
		}

		private static void OnLogMessageReceived(string log, string stackTrace, LogType type)
		{
			GeneralSettings.MobileFileLoggingType mobileFileLoggingType = (_forceRealtimeLogging ? GeneralSettings.MobileFileLoggingType.Realtime : _loggingType);
			switch (mobileFileLoggingType)
			{
			case GeneralSettings.MobileFileLoggingType.Minimal:
				if (type == LogType.Log)
				{
					return;
				}
				break;
			case GeneralSettings.MobileFileLoggingType.None:
				return;
			}
			log = ((type != LogType.Log) ? (string.IsNullOrEmpty(stackTrace) ? $"[{type}] {log}" : $"[{type}] {log}{Environment.NewLine}{stackTrace}") : (string.IsNullOrEmpty(stackTrace) ? log : (log + Environment.NewLine + stackTrace)));
			lock (_lock)
			{
				_pendingLogs.Add(log);
			}
			if (mobileFileLoggingType == GeneralSettings.MobileFileLoggingType.Realtime)
			{
				FlushPendingLogsToFile();
			}
		}

		private static void OnSettingChanged(object sender, SettingChangedEventArgs<GeneralSettings.MobileFileLoggingType> e)
		{
			Application.logMessageReceivedThreaded -= OnLogMessageReceived;
			_loggingType = e.Setting.Value;
			if (_loggingType != GeneralSettings.MobileFileLoggingType.None)
			{
				Application.logMessageReceivedThreaded += OnLogMessageReceived;
			}
		}
	}
}
