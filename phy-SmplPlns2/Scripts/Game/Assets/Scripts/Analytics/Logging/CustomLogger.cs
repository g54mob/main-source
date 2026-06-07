using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Analytics.Logging
{
	[AddComponentMenu("Logging/Custom Log Handler")]
	public class CustomLogger : MonoBehaviour, ILogHandler
	{
		private readonly struct LogIdentifier : IEquatable<LogIdentifier>
		{
			public readonly string ContentKey;

			public readonly LogType Type;

			private readonly int _cachedHashCode;

			public LogIdentifier(LogType type, string contentKey)
			{
				Type = type;
				ContentKey = contentKey ?? string.Empty;
				int num = 17;
				num = num * 23 + Type.GetHashCode();
				num = num * 23 + ContentKey.GetHashCode();
				_cachedHashCode = num;
			}

			public bool Equals(LogIdentifier other)
			{
				if (Type == other.Type)
				{
					return ContentKey == other.ContentKey;
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is LogIdentifier other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return _cachedHashCode;
			}
		}

		private class LogTrackingInfo
		{
			public float LastAttemptTime { get; set; }

			public float LastLoggedTime { get; set; }

			public int SuppressedSinceLastLogCount { get; set; }

			public LogTrackingInfo(float currentTime)
			{
				LastLoggedTime = currentTime;
				LastAttemptTime = currentTime;
				SuppressedSinceLastLogCount = 0;
			}
		}

		[ThreadStatic]
		private static bool _isHandlingLogOnThisThread;

		private readonly object _lockObject = new object();

		private readonly Dictionary<LogIdentifier, LogTrackingInfo> _logTracking = new Dictionary<LogIdentifier, LogTrackingInfo>();

		[Tooltip("How often (seconds) to clean up old message tracking data.")]
		[SerializeField]
		private float _cleanupInterval = 300f;

		[Tooltip("Minimum number of suppressed messages required to log a summary during cleanup.")]
		[SerializeField]
		private int _cleanupLogThreshold = 5;

		private float _currentTime;

		[Tooltip("If a message is suppressed, but this much time (seconds) has passed since it was last displayed, display it anyway along with the suppressed count.")]
		[SerializeField]
		private float _displaySuppressedTimeout = 15f;

		[Header("Manual Filtering")]
		[Tooltip("Enable manual filtering for specific known noisy messages (applied before spam detection).")]
		[SerializeField]
		private bool _enableManualFiltering = true;

		[Header("Spam Detection & Rate Limiting")]
		[Tooltip("Enable automatic spam detection and rate limiting for Logs and Exceptions.")]
		[SerializeField]
		private bool _enableSpamDetection = true;

		private float _lastCleanupTime;

		private ILogHandler _originalHandler;

		[Tooltip("Minimum time (seconds) between identical log messages or exceptions attempts (logged or suppressed).")]
		[SerializeField]
		private float _suppressionCooldown = 60f;

		public bool EnableSpamDetection
		{
			get
			{
				return _enableSpamDetection;
			}
			set
			{
				_enableSpamDetection = value;
			}
		}

		[HideInCallstack]
		public void LogException(Exception exception, UnityEngine.Object context)
		{
			ILogHandler originalHandler = _originalHandler;
			if (originalHandler == null || _isHandlingLogOnThisThread)
			{
				return;
			}
			_isHandlingLogOnThisThread = true;
			try
			{
				LogIdentifier identifier = CreateIdentifierForException(exception);
				int suppressedCount = 0;
				bool flag = true;
				if (_enableSpamDetection)
				{
					flag = ShouldLog(identifier, out suppressedCount);
				}
				if (flag)
				{
					if (suppressedCount > 0)
					{
						originalHandler.LogFormat(LogType.Log, context, "{0}", $"[Suppressed {suppressedCount} Exceptions]: {identifier.ContentKey}");
					}
					originalHandler.LogException(exception, context);
				}
			}
			catch (Exception exception2)
			{
				try
				{
					originalHandler.LogException(exception2, null);
				}
				catch
				{
				}
			}
			finally
			{
				_isHandlingLogOnThisThread = false;
			}
		}

		[HideInCallstack]
		public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
		{
			ILogHandler originalHandler = _originalHandler;
			if (originalHandler == null || _isHandlingLogOnThisThread)
			{
				return;
			}
			_isHandlingLogOnThisThread = true;
			try
			{
				if (!_enableManualFiltering || !ShouldManuallyFilter(logType, format, args))
				{
					string text;
					try
					{
						text = string.Format(format ?? string.Empty, args);
					}
					catch (FormatException ex)
					{
						text = "[CustomLogHandler Formatting Error: " + ex.Message + "] Original format: '" + format + "'";
						originalHandler.LogFormat(LogType.Error, context, "{0}", text);
						return;
					}
					bool flag = true;
					int suppressedCount = 0;
					if (_enableSpamDetection)
					{
						LogIdentifier identifier = new LogIdentifier(logType, text);
						flag = ShouldLog(identifier, out suppressedCount);
					}
					if (flag)
					{
						string text2 = ((suppressedCount > 0) ? $"[Suppressed {suppressedCount} {logType}s]: {text}" : text);
						originalHandler.LogFormat(logType, context, "{0}", text2);
					}
				}
			}
			catch (Exception exception)
			{
				try
				{
					originalHandler.LogException(exception, null);
				}
				catch
				{
				}
			}
			finally
			{
				_isHandlingLogOnThisThread = false;
			}
		}

		protected virtual void OnDisable()
		{
			List<KeyValuePair<LogIdentifier, LogTrackingInfo>> list = null;
			lock (_lockObject)
			{
				if (_logTracking.Count > 0)
				{
					list = _logTracking.ToList();
					_logTracking.Clear();
				}
			}
			ILogHandler originalHandler = _originalHandler;
			if (list != null && list.Count > 0 && originalHandler != null)
			{
				foreach (KeyValuePair<LogIdentifier, LogTrackingInfo> item in list)
				{
					if (item.Value.SuppressedSinceLastLogCount > 0)
					{
						originalHandler.LogFormat(LogType.Log, null, "{0}", $"[Log Cleanup] Suppressed {item.Key.Type} {item.Value.SuppressedSinceLastLogCount} times since last logged: {item.Key.ContentKey}");
					}
				}
			}
			if (Debug.unityLogger.logHandler == this)
			{
				Debug.unityLogger.logHandler = originalHandler;
			}
			_originalHandler = null;
		}

		protected virtual void OnEnable()
		{
			if (Debug.unityLogger.logHandler != this)
			{
				_originalHandler = Debug.unityLogger.logHandler;
				Debug.unityLogger.logHandler = this;
				_lastCleanupTime = Time.realtimeSinceStartup;
				_currentTime = Time.realtimeSinceStartup;
			}
			else
			{
				_originalHandler?.LogFormat(LogType.Warning, null, "{0}", "[CustomLogHandler] OnEnable called but this instance is already the log handler.");
			}
		}

		protected virtual bool ShouldManuallyFilter(LogType logType, string format, params object[] args)
		{
			return false;
		}

		protected virtual void Update()
		{
			_currentTime = Time.realtimeSinceStartup;
			if (_enableSpamDetection && _currentTime > _lastCleanupTime + _cleanupInterval)
			{
				CleanupOldEntries();
				_lastCleanupTime = _currentTime;
			}
		}

		private void CleanupOldEntries()
		{
			if (!_enableSpamDetection)
			{
				return;
			}
			List<KeyValuePair<LogIdentifier, int>> list = null;
			lock (_lockObject)
			{
				if (_logTracking.Count == 0)
				{
					return;
				}
				float num = _currentTime - _cleanupInterval * 2f;
				List<LogIdentifier> list2 = new List<LogIdentifier>();
				foreach (KeyValuePair<LogIdentifier, LogTrackingInfo> item in _logTracking)
				{
					if (!(item.Value.LastAttemptTime < num))
					{
						continue;
					}
					list2.Add(item.Key);
					if (item.Value.SuppressedSinceLastLogCount >= _cleanupLogThreshold)
					{
						if (list == null)
						{
							list = new List<KeyValuePair<LogIdentifier, int>>();
						}
						list.Add(new KeyValuePair<LogIdentifier, int>(item.Key, item.Value.SuppressedSinceLastLogCount));
					}
				}
				foreach (LogIdentifier item2 in list2)
				{
					_logTracking.Remove(item2);
				}
			}
			ILogHandler originalHandler = _originalHandler;
			if (list == null || list.Count <= 0 || originalHandler == null)
			{
				return;
			}
			foreach (KeyValuePair<LogIdentifier, int> item3 in list)
			{
				originalHandler.LogFormat(LogType.Log, null, "{0}", $"[Log Cleanup] Suppressed {item3.Key.Type} {item3.Value} times since last logged: {item3.Key.ContentKey} \n(entry removed).");
			}
		}

		private LogIdentifier CreateIdentifierForException(Exception exception)
		{
			if (exception == null)
			{
				return new LogIdentifier(LogType.Exception, "[Null Exception]");
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(exception.GetType().FullName);
			stringBuilder.Append(": ");
			string message = exception.Message;
			if (!string.IsNullOrEmpty(message))
			{
				int num = message.IndexOfAny(new char[2] { '\r', '\n' });
				if (num >= 0)
				{
					stringBuilder.Append(message.AsSpan(0, num));
				}
				else
				{
					stringBuilder.Append(message);
				}
			}
			string stackTrace = exception.StackTrace;
			if (!string.IsNullOrEmpty(stackTrace))
			{
				stringBuilder.AppendLine();
				int num2 = stackTrace.IndexOfAny(new char[2] { '\r', '\n' });
				if (num2 >= 0)
				{
					stringBuilder.Append(stackTrace.AsSpan(0, num2));
				}
				else
				{
					stringBuilder.Append(stackTrace);
				}
			}
			return new LogIdentifier(LogType.Exception, stringBuilder.ToString());
		}

		private bool ShouldLog(LogIdentifier identifier, out int suppressedCount)
		{
			lock (_lockObject)
			{
				float currentTime = _currentTime;
				suppressedCount = 0;
				if (_logTracking.TryGetValue(identifier, out var value))
				{
					suppressedCount = value.SuppressedSinceLastLogCount;
					float num = currentTime - value.LastAttemptTime;
					float num2 = currentTime - value.LastLoggedTime;
					bool num3 = num >= _suppressionCooldown;
					bool flag = num2 >= _displaySuppressedTimeout;
					if (num3 || flag)
					{
						value.LastLoggedTime = currentTime;
						value.SuppressedSinceLastLogCount = 0;
						value.LastAttemptTime = currentTime;
						return true;
					}
					value.SuppressedSinceLastLogCount++;
					value.LastAttemptTime = currentTime;
					return false;
				}
				value = new LogTrackingInfo(currentTime);
				_logTracking.Add(identifier, value);
				suppressedCount = 0;
				return true;
			}
		}
	}
}
