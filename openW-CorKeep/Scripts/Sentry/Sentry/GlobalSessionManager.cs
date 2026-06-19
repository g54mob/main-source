using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using Sentry.Extensibility;
using Sentry.Infrastructure;
using Sentry.Internal;

namespace Sentry
{
	internal class GlobalSessionManager : ISessionManager
	{
		private const string PersistedSessionFileName = ".session";

		private readonly ISystemClock _clock;

		private readonly Func<string, PersistedSessionUpdate> _persistedSessionProvider;

		private readonly SentryOptions _options;

		private readonly string? _persistenceDirectoryPath;

		private SentrySession? _currentSession;

		private DateTimeOffset? _lastPauseTimestamp;

		internal SentrySession? CurrentSession => _currentSession;

		public bool IsSessionActive => _currentSession != null;

		public GlobalSessionManager(SentryOptions options, ISystemClock? clock = null, Func<string, PersistedSessionUpdate>? persistedSessionProvider = null)
		{
			_options = options;
			_clock = clock ?? SystemClock.Clock;
			_persistedSessionProvider = persistedSessionProvider ?? ((Func<string, PersistedSessionUpdate>)((string filePath) => Json.Load(_options.FileSystem, filePath, PersistedSessionUpdate.FromJson)));
			_persistenceDirectoryPath = options.TryGetDsnSpecificCacheDirectoryPath();
		}

		private void PersistSession(SessionUpdate update, DateTimeOffset? pauseTimestamp = null)
		{
			_options.LogDebug("Persisting session (SID: '{0}') to a file.", update.Id);
			if (string.IsNullOrWhiteSpace(_persistenceDirectoryPath))
			{
				_options.LogDebug("Persistence directory is not set, returning.");
				return;
			}
			if (_options.DisableFileWrite)
			{
				_options.LogInfo("File write has been disabled via the options. Skipping persisting session.");
				return;
			}
			try
			{
				_options.LogDebug("Creating persistence directory for session file at '{0}'.", _persistenceDirectoryPath);
				if (!_options.FileSystem.CreateDirectory(_persistenceDirectoryPath))
				{
					_options.LogError("Failed to create persistent directory for session file.");
					return;
				}
				string text = Path.Combine(_persistenceDirectoryPath, ".session");
				PersistedSessionUpdate persistedSessionUpdate = new PersistedSessionUpdate(update, pauseTimestamp);
				if (!_options.FileSystem.CreateFileForWriting(text, out Stream fileStream))
				{
					_options.LogError("Failed to persist session file.");
					return;
				}
				try
				{
					using Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(fileStream);
					persistedSessionUpdate.WriteTo(utf8JsonWriter, _options.DiagnosticLogger);
					utf8JsonWriter.Flush();
				}
				finally
				{
					fileStream.Dispose();
				}
				_options.LogDebug("Persisted session to a file '{0}'.", text);
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "Failed to persist session on the file system.");
			}
		}

		private void DeletePersistedSession()
		{
			if (string.IsNullOrWhiteSpace(_persistenceDirectoryPath))
			{
				_options.LogDebug("Persistence directory is not set, not deleting any persisted session file.");
				return;
			}
			if (_options.DisableFileWrite)
			{
				_options.LogInfo("File write has been disabled via the options. Skipping deletion of persisted session files.");
				return;
			}
			string text = Path.Combine(_persistenceDirectoryPath, ".session");
			try
			{
				IDiagnosticLogger? diagnosticLogger = _options.DiagnosticLogger;
				if (diagnosticLogger != null && diagnosticLogger.IsEnabled(SentryLevel.Debug))
				{
					try
					{
						string arg = _options.FileSystem.ReadAllTextFromFile(text);
						_options.LogDebug("Deleting persisted session file with contents: {0}", arg);
					}
					catch (Exception exception)
					{
						_options.LogError(exception, "Failed to read the contents of persisted session file '{0}'.", text);
					}
				}
				if (!_options.FileSystem.DeleteFile(text))
				{
					_options.LogError("Failed to delete persisted session file.");
				}
				else
				{
					_options.LogInfo("Deleted persisted session file '{0}'.", text);
				}
			}
			catch (Exception exception2)
			{
				_options.LogError(exception2, "Failed to delete persisted session from the file system: '{0}'", text);
			}
		}

		public SessionUpdate? TryRecoverPersistedSession()
		{
			_options.LogDebug("Attempting to recover persisted session from file.");
			if (string.IsNullOrWhiteSpace(_persistenceDirectoryPath))
			{
				_options.LogDebug("Persistence directory is not set, returning.");
				return null;
			}
			string text = Path.Combine(_persistenceDirectoryPath, ".session");
			try
			{
				PersistedSessionUpdate persistedSessionUpdate = _persistedSessionProvider(text);
				SessionEndStatus? endStatus = null;
				try
				{
					SessionEndStatus value = ((_options.CrashedLastRun?.Invoke() ?? false) ? SessionEndStatus.Crashed : ((!persistedSessionUpdate.PauseTimestamp.HasValue) ? SessionEndStatus.Abnormal : SessionEndStatus.Exited));
					endStatus = value;
				}
				catch (Exception exception)
				{
					_options.LogError(exception, "Invoking CrashedLastRun failed.");
				}
				SessionUpdate sessionUpdate = new SessionUpdate(persistedSessionUpdate.Update, isInitial: false, persistedSessionUpdate.PauseTimestamp ?? _clock.GetUtcNow(), persistedSessionUpdate.Update.SequenceNumber + 1, endStatus);
				_options.LogInfo("Recovered session: EndStatus: {0}. PauseTimestamp: {1}", sessionUpdate.EndStatus, persistedSessionUpdate.PauseTimestamp);
				return sessionUpdate;
			}
			catch (Exception ex) when (((ex is FileNotFoundException || ex is DirectoryNotFoundException) ? 1 : 0) != 0)
			{
				_options.LogDebug("A persisted session does not exist ({0}) at {1}.", ex.GetType().Name, text);
				return null;
			}
			catch (Exception exception2)
			{
				_options.LogError(exception2, "Failed to recover persisted session from the file system '{0}'.", text);
				return null;
			}
		}

		public SessionUpdate? StartSession()
		{
			string release = _options.SettingLocator.GetRelease();
			if (string.IsNullOrWhiteSpace(release))
			{
				_options.LogError("Failed to start a session because there is no release information.");
				return null;
			}
			string environment = _options.SettingLocator.GetEnvironment();
			SentrySession sentrySession = new SentrySession(_options.InstallationId, release, environment);
			SentrySession sentrySession2 = Interlocked.Exchange(ref _currentSession, sentrySession);
			if (sentrySession2 != null)
			{
				_options.LogWarning("Starting a new session while an existing one is still active.");
				EndSession(sentrySession2, _clock.GetUtcNow(), SessionEndStatus.Exited);
			}
			_options.LogInfo("Started new session (SID: {0}; DID: {1}).", sentrySession.Id, sentrySession.DistinctId);
			SessionUpdate sessionUpdate = sentrySession.CreateUpdate(isInitial: true, _clock.GetUtcNow());
			PersistSession(sessionUpdate);
			return sessionUpdate;
		}

		private SessionUpdate EndSession(SentrySession session, DateTimeOffset timestamp, SessionEndStatus status)
		{
			if (status == SessionEndStatus.Crashed)
			{
				session.ReportError();
			}
			_options.LogInfo("Ended session (SID: {0}; DID: {1}) with status '{2}'.", session.Id, session.DistinctId, status);
			SessionUpdate result = session.CreateUpdate(isInitial: false, timestamp, status);
			DeletePersistedSession();
			return result;
		}

		public SessionUpdate? EndSession(DateTimeOffset timestamp, SessionEndStatus status)
		{
			SentrySession sentrySession = Interlocked.Exchange(ref _currentSession, null);
			if (sentrySession == null)
			{
				_options.LogWarning("Failed to end session because there is none active.");
				return null;
			}
			return EndSession(sentrySession, timestamp, status);
		}

		public SessionUpdate? EndSession(SessionEndStatus status)
		{
			return EndSession(_clock.GetUtcNow(), status);
		}

		public void PauseSession()
		{
			SentrySession currentSession = _currentSession;
			if (currentSession == null)
			{
				_options.LogWarning("Attempted to pause a session, but a session has not been started.");
				return;
			}
			_options.LogInfo("Pausing session (SID: {0}; DID: {1}).", currentSession.Id, currentSession.DistinctId);
			DateTimeOffset utcNow = _clock.GetUtcNow();
			_lastPauseTimestamp = utcNow;
			PersistSession(currentSession.CreateUpdate(isInitial: false, utcNow), utcNow);
		}

		public IReadOnlyList<SessionUpdate> ResumeSession()
		{
			SentrySession currentSession = _currentSession;
			if (currentSession == null)
			{
				_options.LogWarning("Attempted to resume a session, but a session has not been started.");
				return Array.Empty<SessionUpdate>();
			}
			DateTimeOffset? lastPauseTimestamp = _lastPauseTimestamp;
			if (lastPauseTimestamp.HasValue)
			{
				DateTimeOffset valueOrDefault = lastPauseTimestamp.GetValueOrDefault();
				_options.LogInfo("Resuming session (SID: {0}; DID: {1}).", currentSession.Id, currentSession.DistinctId);
				_lastPauseTimestamp = null;
				TimeSpan timeSpan = (_clock.GetUtcNow() - valueOrDefault).Duration();
				if (timeSpan >= _options.AutoSessionTrackingInterval)
				{
					_options.LogDebug("Paused session has been paused for {0}, which is longer than the configured timeout. Starting a new session instead of resuming this one.", timeSpan);
					List<SessionUpdate> list = new List<SessionUpdate>(2);
					SessionUpdate sessionUpdate = EndSession(valueOrDefault, SessionEndStatus.Exited);
					if (sessionUpdate != null)
					{
						list.Add(sessionUpdate);
					}
					SessionUpdate sessionUpdate2 = StartSession();
					if (sessionUpdate2 != null)
					{
						list.Add(sessionUpdate2);
					}
					return list;
				}
				_options.LogInfo("Resumed session (SID: {0}; DID: {1}) after being paused for {2}.", currentSession.Id, currentSession.DistinctId, timeSpan);
				return Array.Empty<SessionUpdate>();
			}
			_options.LogWarning("Attempted to resume a session, but the current session hasn't been paused.");
			return Array.Empty<SessionUpdate>();
		}

		public SessionUpdate? ReportError()
		{
			SentrySession currentSession = _currentSession;
			if (currentSession == null)
			{
				_options.LogDebug("There is no session active. Skipping updating the session as errored. Consider setting 'AutoSessionTracking = true' to enable Release Health and crash free rate.");
				return null;
			}
			currentSession.ReportError();
			if (currentSession.ErrorCount > 1)
			{
				_options.LogDebug("Reported an error on a session that already contains errors. Not creating an update.");
				return null;
			}
			return currentSession.CreateUpdate(isInitial: false, _clock.GetUtcNow());
		}
	}
}
