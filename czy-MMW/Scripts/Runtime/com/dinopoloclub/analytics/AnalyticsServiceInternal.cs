using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DinoPoloClub;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace com.dinopoloclub.analytics
{
	internal class AnalyticsServiceInternal : MonoBehaviour
	{
		private class Session : AnalyticsService.ISession
		{
			[Serializable]
			private class Event
			{
				public string event_id;

				public string event_type;

				public string event_name;

				public long event_timestamp;

				public long event_timestamp_ms;

				public string event_version;

				public string app_version;

				public Dictionary<string, object> event_data;
			}

			[Serializable]
			private class EventsBatch
			{
				public List<Event> events;
			}

			private AnalyticsServiceInternal _owner;

			private string _sessionId;

			private readonly string _applicationId;

			private readonly string _applicationVersion;

			private long _sessionUTCStartTimeSeconds;

			private List<Event> _queuedEvents = new List<Event>();

			private float _lastBatchTime;

			private bool _hasSessionEnded;

			private int _uploadsPending;

			private const int SessionSerialisationVersion = 2;

			private const int SessionSerialisationVersion_StoreSaveTime = 2;

			private const float BatchDuration = 5f;

			private static readonly int BatchSize = 100;

			private bool CanSendData => _owner.CanSendData;

			public bool HasSessionEnded => _hasSessionEnded;

			public string SessionId => _sessionId;

			public string Id => _sessionId;

			public Session(AnalyticsServiceInternal owner, string applicationId, string applicationVersion, string sessionId = null, bool hasSessionEnded = false)
			{
				_owner = owner;
				if (sessionId == null)
				{
					_sessionId = GenerateSessionId();
					Debug.Log("New Session " + _sessionId);
				}
				else
				{
					_sessionId = sessionId;
					Debug.Log("Loaded Session from storage " + _sessionId);
				}
				_sessionId = sessionId ?? GenerateSessionId();
				_applicationId = applicationId;
				_applicationVersion = applicationVersion;
				_sessionUTCStartTimeSeconds = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
				_hasSessionEnded = hasSessionEnded;
			}

			private static string GenerateSessionId()
			{
				return Guid.NewGuid().ToString();
			}

			public long CalculateSessionDurationSeconds(long endTimeUTCSeconds = -1L)
			{
				return ((endTimeUTCSeconds != -1) ? endTimeUTCSeconds : new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()) - _sessionUTCStartTimeSeconds;
			}

			internal void RestartSession(long endTimeSeconds = -1L)
			{
				string text = GenerateSessionId();
				EndSession(endTimeSeconds);
				Debug.Log("Reset Session " + _sessionId + " -> " + text);
				_sessionId = text;
				_sessionUTCStartTimeSeconds = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
				_hasSessionEnded = false;
				SendEvent("session_start", "0.1");
			}

			public void SendEvent(string eventName, string eventVersion, Dictionary<string, object> data = null)
			{
				if (!string.IsNullOrEmpty(_sessionId))
				{
					if (data == null)
					{
						data = new Dictionary<string, object>();
					}
					data["session_id"] = _sessionId;
					EnqueueEvent(eventName, eventVersion, data);
				}
			}

			public void EndSession(long endSessionTimeSeconds = -1L)
			{
				if (!string.IsNullOrEmpty(_sessionId))
				{
					_hasSessionEnded = true;
					Dictionary<string, object> data = new Dictionary<string, object> { 
					{
						"session_duration",
						CalculateSessionDurationSeconds(endSessionTimeSeconds)
					} };
					SendEvent("session_end", "0.1", data);
					SendBatchedEvents();
				}
			}

			private static string GetUuid()
			{
				return Guid.NewGuid().ToString();
			}

			private void EnqueueEvent(string eventName, string eventVersion, Dictionary<string, object> data)
			{
				string uuid = GetUuid();
				long uniqueTimestampSeconds = _owner.GetUniqueTimestampSeconds();
				long uniqueTimestampMilliseconds = _owner.GetUniqueTimestampMilliseconds();
				Event item = new Event
				{
					event_id = uuid,
					event_type = eventName,
					event_name = eventName,
					event_timestamp = uniqueTimestampSeconds,
					event_timestamp_ms = uniqueTimestampMilliseconds,
					event_version = eventVersion,
					app_version = _applicationVersion,
					event_data = data
				};
				_queuedEvents.Add(item);
				if (CanSendData && _queuedEvents.Count >= BatchSize)
				{
					SendBatchedEvents();
				}
				else
				{
					_owner.SaveState();
				}
			}

			private void SendBatchedEvents()
			{
				_lastBatchTime = Time.time;
				if (_queuedEvents.Count <= 0 || !CanSendData)
				{
					return;
				}
				foreach (Event queuedEvent in _queuedEvents)
				{
					_ = queuedEvent;
				}
				EventsBatch batch = new EventsBatch
				{
					events = _queuedEvents
				};
				_queuedEvents = new List<Event>();
				_owner.StartCoroutine(SendEventsViaGateway(batch, delegate(bool wasSuccess)
				{
					if (!wasSuccess)
					{
						_queuedEvents.AddRange(batch.events);
						if (_hasSessionEnded)
						{
							_owner.SaveState();
						}
					}
					else if (_hasSessionEnded && _queuedEvents.Count == 0 && _uploadsPending == 0)
					{
						if (_owner == null)
						{
							Debug.LogError("Trying to clean up session but owner == null!");
						}
						else
						{
							_owner.RemoveSession(_sessionId);
							_sessionId = null;
							_owner = null;
						}
					}
				}));
			}

			private IEnumerator SendEventsViaGateway(EventsBatch batch, Action<bool> OnComplete)
			{
				if (!CanSendData)
				{
					Debug.LogError("SendEventsViaGateway called but CanSendData is false!");
					OnComplete?.Invoke(obj: false);
					yield break;
				}
				string s = JsonConvert.SerializeObject(batch);
				UnityWebRequest request = new UnityWebRequest(_owner._analyticsUrl, "POST");
				byte[] bytes = Encoding.UTF8.GetBytes(s);
				request.uploadHandler = new UploadHandlerRaw(bytes);
				request.downloadHandler = new DownloadHandlerBuffer();
				request.SetRequestHeader("Content-Type", "application/json");
				request.SetRequestHeader("Authorization", _owner._apiKey);
				_uploadsPending++;
				yield return request.SendWebRequest();
				_uploadsPending--;
				OnComplete?.Invoke(request.result == UnityWebRequest.Result.Success);
			}

			public void Update()
			{
				if (Time.time - _lastBatchTime > 5f)
				{
					SendBatchedEvents();
				}
			}

			public void Serialize(StreamWriter streamWriter)
			{
				if (_queuedEvents.Count == 0)
				{
					return;
				}
				streamWriter.WriteLine(2);
				streamWriter.WriteLine(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
				streamWriter.WriteLine(_sessionId);
				streamWriter.WriteLine(_applicationId);
				streamWriter.WriteLine(_applicationVersion);
				streamWriter.WriteLine(_queuedEvents.Count.ToString());
				foreach (Event queuedEvent in _queuedEvents)
				{
					string s = JsonConvert.SerializeObject(queuedEvent);
					string value = Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
					streamWriter.WriteLine(value);
				}
			}

			[CanBeNull]
			public static Session Deserialize(StreamReader reader, AnalyticsServiceInternal owner, string apiKey)
			{
				try
				{
					string text = reader.ReadLine();
					if (!int.TryParse(text, out var result))
					{
						result = 0;
					}
					long result2;
					switch (result)
					{
					default:
						Debug.LogError($"Ignoring unhandled session serialisation version {result}!");
						return null;
					case 2:
						if (!long.TryParse(reader.ReadLine(), out result2))
						{
							Debug.LogError($"Failed to parse save timestamp in serialised data with version {result}!");
							result2 = -1L;
						}
						break;
					case 0:
					case 1:
						result2 = -1L;
						break;
					}
					string text2 = ((result == 0) ? text : reader.ReadLine());
					string applicationId = reader.ReadLine();
					string applicationVersion = reader.ReadLine();
					if (!int.TryParse(reader.ReadLine(), out var result3))
					{
						Debug.LogError("Failed to parse event count for session " + text2);
						return null;
					}
					Session session = new Session(owner, applicationId, applicationVersion, text2, hasSessionEnded: true);
					List<Event> list = new List<Event>();
					bool flag = false;
					for (int i = 0; i < result3; i++)
					{
						try
						{
							byte[] array = Convert.FromBase64String(reader.ReadLine() ?? string.Empty);
							Event obj = JsonConvert.DeserializeObject<Event>(Encoding.UTF8.GetString(array, 0, array.Length));
							if (IsValidEvent(obj))
							{
								list.Add(obj);
								if (obj.event_type.Equals("session_end"))
								{
									flag = true;
								}
							}
						}
						catch (Exception arg)
						{
							Debug.LogError($"Failed to parse event {i} of {result3}: {arg}");
						}
					}
					if (!flag)
					{
						Debug.Log("Session " + text2 + " has no end event. Estimating end time based on last event or save timestamp.");
						long endSessionTimeSeconds = ((result2 == -1) ? list.Last().event_timestamp : result2);
						session.EndSession(endSessionTimeSeconds);
					}
					session._queuedEvents = list;
					return session;
				}
				catch (Exception ex)
				{
					Debug.LogError("Failed to parse analytics session!\n" + ex.StackTrace);
					return null;
				}
			}

			private static bool IsValidEvent(Event e)
			{
				if (e.event_timestamp == 0L && e.event_timestamp_ms == 0L)
				{
					Debug.LogWarning("Analytics invalid event: Invalid event Timestamps");
					return false;
				}
				if (e.event_data == null)
				{
					Debug.LogWarning("Analytics invalid event: event_data");
					return false;
				}
				if (!e.event_data.ContainsKey("session_id"))
				{
					Debug.LogWarning("Analytics invalid event: missing SessionId");
					return false;
				}
				return true;
			}
		}

		private Dictionary<string, Session> _sessions = new Dictionary<string, Session>();

		private const string Event_SessionStart = "session_start";

		private const string Version_SessionStart = "0.1";

		private const string Event_SessionEnd = "session_end";

		private const string Version_SessionEnd = "0.1";

		private const string Field_SessionId = "session_id";

		private const string Field_SessionDuration = "session_duration";

		private AnalyticsService.ConsentState _userConsentState;

		private string _analyticsUrl;

		private long _lastTimestampSeconds;

		private long _lastTimestampMilliSeconds;

		private const float SessionPauseTimeout = 300f;

		private DateTime _lastAppPauseTime;

		private Session _currentSession;

		private long _maximumSessionDurationSeconds = 86400L;

		private IAnalyticsStorageProvider _storageProvider;

		private string _applicationId;

		private string _applicationVersion;

		private string _apiKey;

		private bool CanSendData => _userConsentState == AnalyticsService.ConsentState.Accepted;

		public void Initialize(IAnalyticsStorageProvider storageProvider, string apiKey, string applicationId, string applicationVersion, string analyticsUrl, AnalyticsService.ConsentState consentState)
		{
			_storageProvider = storageProvider;
			_apiKey = apiKey;
			_applicationId = applicationId;
			_applicationVersion = applicationVersion;
			_userConsentState = consentState;
			_analyticsUrl = analyticsUrl;
			StreamReader streamReader = new StreamReader(new MemoryStream(storageProvider.RetrieveData()));
			while (streamReader.Peek() >= 0)
			{
				Session session = Session.Deserialize(streamReader, this, apiKey);
				if (session != null)
				{
					_sessions.Add(session.Id, session);
				}
			}
		}

		private void OnApplicationPause(bool pauseStatus)
		{
			if (_storageProvider == null)
			{
				if (!Application.isEditor)
				{
					Debug.LogError("OnApplicationPause called without a storage provider present in non-Editor environment!");
				}
			}
			else if (pauseStatus && !Mathf.Approximately(DateTime.UtcNow.Ticks, _lastAppPauseTime.Ticks))
			{
				_lastAppPauseTime = DateTime.UtcNow;
			}
			else if (!pauseStatus && _lastAppPauseTime != default(DateTime))
			{
				TimeSpan timeSpan = new TimeSpan(DateTime.UtcNow.Ticks - _lastAppPauseTime.Ticks);
				_lastAppPauseTime = default(DateTime);
				if (timeSpan.TotalSeconds > 300.0)
				{
					_currentSession.RestartSession(GetUniqueTimestampSeconds() - (long)timeSpan.TotalSeconds);
				}
			}
		}

		private void OnApplicationQuit()
		{
			Session currentSession = _currentSession;
			if (currentSession != null && !currentSession.HasSessionEnded)
			{
				_currentSession.EndSession(-1L);
			}
		}

		private void SaveState()
		{
			if (_userConsentState == AnalyticsService.ConsentState.Declined)
			{
				return;
			}
			if (_storageProvider == null)
			{
				Debug.LogError("Can't save analytics state as no storage provider present!");
				return;
			}
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter streamWriter = new StreamWriter(memoryStream);
			foreach (KeyValuePair<string, Session> session in _sessions)
			{
				session.Value.Serialize(streamWriter);
			}
			streamWriter.Flush();
			_storageProvider.StoreData(memoryStream.ToArray());
		}

		protected void Update()
		{
			if (CanSendData)
			{
				foreach (KeyValuePair<string, Session> session in _sessions)
				{
					session.Value.Update();
				}
			}
			if (_currentSession != null && _currentSession.CalculateSessionDurationSeconds(-1L) >= _maximumSessionDurationSeconds)
			{
				_currentSession.RestartSession(-1L);
			}
		}

		public long GetUniqueTimestampSeconds()
		{
			long num = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
			if (num <= _lastTimestampSeconds)
			{
				num = _lastTimestampSeconds + 1;
			}
			_lastTimestampSeconds = num;
			return num;
		}

		private long GetUniqueTimestampMilliseconds()
		{
			long num = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
			if (num <= _lastTimestampMilliSeconds)
			{
				num = _lastTimestampMilliSeconds + 1;
			}
			_lastTimestampMilliSeconds = num;
			return num;
		}

		public AnalyticsService.ISession CreateSession()
		{
			if (_userConsentState == AnalyticsService.ConsentState.Declined)
			{
				Debug.Log("User has declined to share analytics, so don't start a new session");
				return null;
			}
			_currentSession = new Session(this, _applicationId, _applicationVersion);
			_sessions[_currentSession.SessionId] = _currentSession;
			_currentSession.SendEvent("session_start", "0.1");
			return _currentSession;
		}

		private void RemoveSession(string sessionId)
		{
			if (!_sessions.Remove(sessionId))
			{
				Debug.LogError("Failed to Remove Analytics Session " + sessionId);
			}
		}

		internal void SetUserAnalyticsConsent(AnalyticsService.ConsentState newUserAnalyticsConsent)
		{
			if (newUserAnalyticsConsent != _userConsentState)
			{
				_userConsentState = newUserAnalyticsConsent;
				if (_userConsentState == AnalyticsService.ConsentState.Declined)
				{
					_sessions.Clear();
					_storageProvider.DeleteStoredData();
				}
			}
		}
	}
}
