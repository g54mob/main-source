using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Networking;

public static class Diagnostics
{
	public class AuditTrail
	{
		public delegate void PopulateMetadata(Dictionary<string, string> metadata);

		public class EventBlock : IDisposable
		{
			private readonly AuditTrail _auditTrail;

			private readonly AuditTrailEvent _openEvent;

			private bool _hasClosed;

			public EventBlock(AuditTrail auditTrail, AuditTrailEvent openEvent)
			{
				_auditTrail = auditTrail;
				_openEvent = openEvent;
			}

			public EventBlock()
			{
				_auditTrail = null;
				_openEvent = null;
				_hasClosed = true;
			}

			public void Close()
			{
				if (!_hasClosed)
				{
					_hasClosed = true;
					if (Verify(_auditTrail._openEvents.Count > 0 && _auditTrail._openEvents.Peek() == _openEvent))
					{
						_auditTrail._openEvents.Pop();
					}
				}
			}

			public void Dispose()
			{
				Close();
			}
		}

		private Stack<AuditTrailEvent> _openEvents = new Stack<AuditTrailEvent>();

		private List<AuditTrailEvent> _rootEvents = new List<AuditTrailEvent>();

		private List<AuditTrailEvent> _allEvents = new List<AuditTrailEvent>();

		private EventBlock _emptyEventBlock = new EventBlock();

		public bool IsRecordingEvents { get; set; }

		public void RecordEvent(string name, PopulateMetadata populateMetadata = null)
		{
			if (IsRecordingEvents)
			{
				CreateEvent(name, populateMetadata);
			}
		}

		public EventBlock OpenEvent(string name, PopulateMetadata populateMetadata = null)
		{
			if (!IsRecordingEvents)
			{
				return _emptyEventBlock;
			}
			AuditTrailEvent auditTrailEvent = CreateEvent(name, populateMetadata);
			_openEvents.Push(auditTrailEvent);
			return new EventBlock(this, auditTrailEvent);
		}

		public string ToJson()
		{
			List<object> list = new List<object>();
			foreach (AuditTrailEvent rootEvent in _rootEvents)
			{
				list.Add(rootEvent.ToJson());
			}
			return Json.Serialize(list);
		}

		private AuditTrailEvent CreateEvent(string name, PopulateMetadata populateMetadata)
		{
			AuditTrailEvent auditTrailEvent = new AuditTrailEvent(name, populateMetadata);
			if (_openEvents.Count > 0)
			{
				_openEvents.Peek().AddChild(auditTrailEvent);
			}
			else
			{
				_rootEvents.Add(auditTrailEvent);
			}
			_allEvents.Add(auditTrailEvent);
			return auditTrailEvent;
		}
	}

	public class AuditTrailEvent
	{
		private readonly Dictionary<string, string> _metadata = new Dictionary<string, string>();

		private readonly List<AuditTrailEvent> _children = new List<AuditTrailEvent>();

		private static int NextId = 1;

		public int Id { get; }

		public DateTime Timestamp { get; }

		public string Name { get; }

		public IReadOnlyDictionary<string, string> Metadata => _metadata;

		public AuditTrailEvent Parent { get; private set; }

		public IReadOnlyList<AuditTrailEvent> Children => _children;

		public AuditTrailEvent(string name, AuditTrail.PopulateMetadata populateMetadata)
		{
			Id = NextId;
			NextId++;
			Timestamp = DateTime.Now;
			Name = name;
			populateMetadata?.Invoke(_metadata);
		}

		public void AddChild(AuditTrailEvent childEvent)
		{
			childEvent.Parent = this;
			_children.Add(childEvent);
		}

		public object ToJson()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["name"] = Name;
			dictionary["timestamp"] = Timestamp.ToString(DateTimeFormatInfo.InvariantInfo);
			if (_metadata.Count > 0)
			{
				Dictionary<string, object> dictionary2 = (Dictionary<string, object>)(dictionary["metadata"] = new Dictionary<string, object>());
				foreach (KeyValuePair<string, string> item in _metadata)
				{
					dictionary2[item.Key] = item.Value;
				}
			}
			if (_children.Count > 0)
			{
				List<object> list = (List<object>)(dictionary["children"] = new List<object>());
				foreach (AuditTrailEvent child in _children)
				{
					list.Add(child.ToJson());
				}
			}
			return dictionary;
		}
	}

	public class StorageAuditTrail : AuditTrail
	{
	}

	public static class Exception
	{
		public static string LastException;

		public static string LastExceptionStackTrace;

		public static void OnLogMessageReceived(string condition, string stackTrace, LogType type)
		{
			if (type == LogType.Exception)
			{
				LastException = condition;
				LastExceptionStackTrace = stackTrace;
			}
		}
	}

	public static class File
	{
		private static readonly string DiagnosticsDirectory = System.IO.Path.Combine(Application.persistentDataPath, "diagnostics");

		private static bool hasCheckedDirectory;

		private static bool doesDirectoryExist;

		public static bool CanWrite
		{
			get
			{
				if (!hasCheckedDirectory)
				{
					hasCheckedDirectory = true;
					doesDirectoryExist = Directory.Exists(DiagnosticsDirectory);
				}
				return doesDirectoryExist;
			}
		}

		public static string Path => DiagnosticsDirectory;

		public static string GetFullPath(string filename)
		{
			if (CanWrite)
			{
				return System.IO.Path.Combine(DiagnosticsDirectory, filename);
			}
			return null;
		}
	}

	public static class Hierarchy
	{
		private static HierarchyNode root;

		public static HierarchyNode Root => root;

		public static void Clear()
		{
			if (root != null)
			{
				UnityEngine.Object.DestroyImmediate(root.GameObject);
				root = null;
			}
		}
	}

	public class HierarchyNode
	{
		private GameObject _gameObject;

		public GameObject GameObject => _gameObject;

		public static HierarchyNode CreateNode(string name, HierarchyNode parent = null)
		{
			return new HierarchyNode(name, parent);
		}

		private HierarchyNode(string name, HierarchyNode parent = null)
		{
			if (parent == null)
			{
				_gameObject = GameObject.Find("/" + name);
			}
			else
			{
				Transform transform = parent.GameObject.transform.Find(name);
				if (transform != null)
				{
					_gameObject = transform.gameObject;
				}
			}
			if (!(_gameObject == null))
			{
				return;
			}
			_gameObject = new GameObject(name);
			if (parent != null)
			{
				Transform transform2 = parent.GameObject.transform;
				int i;
				for (i = 0; i < transform2.childCount && name.CompareTo(transform2.GetChild(i).name) >= 0; i++)
				{
				}
				_gameObject.transform.SetParent(transform2);
				_gameObject.transform.SetSiblingIndex(i);
			}
		}

		public HierarchyNode GetChild(string name)
		{
			return CreateNode(name, this);
		}
	}

	public static class Log
	{
		public enum Level
		{
			Info = 0,
			Warn = 1,
			Error = 2,
			Critical = 3
		}

		public class Channel
		{
			private readonly string _name;

			private bool _isMuted;

			public bool IsMuted
			{
				get
				{
					return _isMuted;
				}
				set
				{
					if (value != _isMuted)
					{
						_isMuted = value;
						if (_isMuted)
						{
							MuteChannel(_name);
						}
						else
						{
							UnmuteChannel(_name);
						}
					}
				}
			}

			public Channel(string name)
			{
				_name = name;
			}

			[DebuggerHidden]
			public void Info(string message, params object[] args)
			{
				Message(Level.Info, message, args);
			}

			[DebuggerHidden]
			public void Warn(string message, params object[] args)
			{
				Message(Level.Warn, message, args);
			}

			[DebuggerHidden]
			public void Error(string message, params object[] args)
			{
				Message(Level.Error, message, args);
			}

			[DebuggerHidden]
			public void Critical(string message, params object[] args)
			{
				Message(Level.Critical, message, args);
			}

			[DebuggerHidden]
			public void Message(Level level, string message, params object[] args)
			{
				Log.Message(level, _name, message, args);
			}

			[DebuggerHidden]
			public void Info(UnityEngine.Object contextObject, string message, params object[] args)
			{
				Message(contextObject, Level.Info, message, args);
			}

			[DebuggerHidden]
			public void Warn(UnityEngine.Object contextObject, string message, params object[] args)
			{
				Message(contextObject, Level.Warn, message, args);
			}

			[DebuggerHidden]
			public void Error(UnityEngine.Object contextObject, string message, params object[] args)
			{
				Message(contextObject, Level.Error, message, args);
			}

			[DebuggerHidden]
			public void Critical(UnityEngine.Object contextObject, string message, params object[] args)
			{
				Message(contextObject, Level.Critical, message, args);
			}

			[DebuggerHidden]
			public void Message(UnityEngine.Object contextObject, Level level, string message, params object[] args)
			{
				Log.Message(contextObject, level, _name, message, args);
			}
		}

		private static readonly List<string> mutedChannels = new List<string>();

		private const int MaxRecordedLogLines = 131072;

		private static List<string> _recordedLogLines;

		public static bool IsRecordingLog
		{
			get
			{
				return _recordedLogLines != null;
			}
			set
			{
				if (value)
				{
					if (_recordedLogLines == null)
					{
						_recordedLogLines = new List<string>();
						Application.logMessageReceived += OnLogMessageReceived;
					}
				}
				else if (_recordedLogLines != null)
				{
					_recordedLogLines = null;
					Application.logMessageReceived -= OnLogMessageReceived;
				}
			}
		}

		[CanBeNull]
		public static byte[] RecordedLog
		{
			get
			{
				if (_recordedLogLines != null)
				{
					return Encoding.UTF8.GetBytes(string.Join("\n", _recordedLogLines));
				}
				return null;
			}
		}

		[DebuggerHidden]
		public static void Info(string channel, string message, params object[] args)
		{
			Message(Level.Info, channel, message, args);
		}

		[DebuggerHidden]
		public static void Warn(string channel, string message, params object[] args)
		{
			Message(Level.Warn, channel, message, args);
		}

		[DebuggerHidden]
		public static void Error(string channel, string message, params object[] args)
		{
			Message(Level.Error, channel, message, args);
		}

		[DebuggerHidden]
		public static void Critical(string channel, string message, params object[] args)
		{
			Message(Level.Critical, channel, message, args);
		}

		[DebuggerHidden]
		public static void Message(Level level, string channel, string message, params object[] args)
		{
		}

		[DebuggerHidden]
		public static void Info(UnityEngine.Object contextObject, string channel, string message, params object[] args)
		{
			Message(contextObject, Level.Info, channel, message, args);
		}

		[DebuggerHidden]
		public static void Warn(UnityEngine.Object contextObject, string channel, string message, params object[] args)
		{
			Message(contextObject, Level.Warn, channel, message, args);
		}

		[DebuggerHidden]
		public static void Error(UnityEngine.Object contextObject, string channel, string message, params object[] args)
		{
			Message(contextObject, Level.Error, channel, message, args);
		}

		[DebuggerHidden]
		public static void Critical(UnityEngine.Object contextObject, string channel, string message, params object[] args)
		{
			Message(contextObject, Level.Critical, channel, message, args);
		}

		public static void MuteChannel(string channel)
		{
			if (!mutedChannels.Contains(channel))
			{
				mutedChannels.Add(channel);
			}
		}

		public static void UnmuteChannel(string channel)
		{
			if (mutedChannels.Contains(channel))
			{
				mutedChannels.Remove(channel);
			}
		}

		[DebuggerHidden]
		public static void Message(UnityEngine.Object contextObject, Level level, string channel, string message, params object[] args)
		{
		}

		public static Channel OpenChannel(string name)
		{
			return new Channel(name);
		}

		private static void OnLogMessageReceived(string condition, string trace, LogType type)
		{
			_recordedLogLines.Add(condition);
			bool flag = false;
			string[] array = trace.Split(Environment.NewLine.ToCharArray());
			foreach (string text in array)
			{
				if (!flag)
				{
					if (text.StartsWith("Diagnostics/Log") || text.StartsWith("UnityEngine.Debug:"))
					{
						continue;
					}
					flag = true;
				}
				_recordedLogLines.Add(text);
			}
			while (_recordedLogLines.Count > 131072)
			{
				_recordedLogLines.RemoveAt(0);
			}
		}
	}

	public enum ReportOrigin
	{
		Local = 0,
		Remote = 1
	}

	public enum ReportState
	{
		Searching = 0,
		Downloading = 1,
		Error = 2,
		Ready = 3
	}

	public class ReportAttachment
	{
		public string Filename { get; private set; }

		public string LocalFilepath { get; private set; }

		public byte[] Data { get; private set; }

		public int Size
		{
			get
			{
				if (Data != null)
				{
					return Data.Length;
				}
				if (!string.IsNullOrEmpty(LocalFilepath) && System.IO.File.Exists(LocalFilepath))
				{
					return (int)new FileInfo(LocalFilepath).Length;
				}
				return 0;
			}
		}

		public ReportAttachment(string filename, byte[] data)
		{
			Filename = filename;
			LocalFilepath = null;
			Data = data;
		}

		public ReportAttachment(string filename, string localFilepath)
		{
			Filename = filename;
			LocalFilepath = localFilepath;
			Data = null;
		}
	}

	public class ReportUpload
	{
		public int Id { get; set; }

		public bool IsComplete { get; set; }

		public int BytesUploaded { get; set; }

		public int BytesToUpload { get; private set; }

		public ReportUpload(Report report)
		{
			Id = 0;
			IsComplete = false;
			BytesUploaded = 0;
			BytesToUpload = report.TotalAttachmentSize;
		}
	}

	public class Report
	{
		private class CoroutineHost : MonoBehaviour
		{
		}

		private readonly Dictionary<string, string> _metadata = new Dictionary<string, string>();

		private readonly HashSet<string> _metadataIndices = new HashSet<string>();

		private readonly List<ReportAttachment> _attachments = new List<ReportAttachment>();

		private static Log.Channel Log = Diagnostics.Log.OpenChannel("Report");

		private const string ApiUrl = "https://api.dinopoloclub.com/1/";

		private const int MaxUploadSize = 524288;

		private static MonoBehaviour _coroutineHost;

		public int Id { get; private set; }

		public string Motive { get; set; }

		public ReportOrigin Origin { get; private set; }

		public ReportState State { get; private set; }

		public int TotalAttachmentSize
		{
			get
			{
				int num = 0;
				foreach (ReportAttachment attachment in _attachments)
				{
					num += attachment.Size;
				}
				return num;
			}
		}

		public IEnumerable<ReportAttachment> Attachments => _attachments;

		public Report()
		{
			Id = -1;
			Origin = ReportOrigin.Local;
			State = ReportState.Ready;
			SetMetadata("deviceModel", SystemInfo.deviceModel, index: true);
			SetMetadata("deviceType", SystemInfo.deviceType.ToString());
			if (Application.isEditor)
			{
				SetMetadata("deviceName", SystemInfo.deviceName, index: true);
			}
		}

		public void SetMetadata(string key, string value, bool index = false)
		{
			_metadata[key] = value;
			if (index)
			{
				_metadataIndices.Add(key);
			}
		}

		public void AttachFile(string filename, string localFilepath)
		{
			_attachments.Add(new ReportAttachment(filename, localFilepath));
		}

		public void AttachFile(string filename, byte[] data)
		{
			_attachments.Add(new ReportAttachment(filename, data));
		}

		public ReportAttachment GetAttachment(int attachmentIndex)
		{
			return _attachments[attachmentIndex];
		}

		public ReportUpload Upload()
		{
			if (!Verify(Origin == ReportOrigin.Local))
			{
				return null;
			}
			ReportUpload reportUpload = new ReportUpload(this);
			GetCoroutineHost().StartCoroutine(DoUpload(reportUpload));
			return reportUpload;
		}

		public static Report Download(int id)
		{
			Report report = new Report(id);
			GetCoroutineHost().StartCoroutine(report.DoDownload());
			return report;
		}

		public static Report SearchAndDownload(string metadataSearchKey, string metadataSearchValue)
		{
			Report report = new Report(metadataSearchKey, metadataSearchValue);
			GetCoroutineHost().StartCoroutine(report.DoSearch());
			return report;
		}

		private Report(int id)
		{
			Id = id;
			Origin = ReportOrigin.Remote;
		}

		private Report(string metadataSearchKey, string metadataSearchValue)
		{
			Id = -1;
			Origin = ReportOrigin.Remote;
			SetMetadata(metadataSearchKey, metadataSearchValue);
		}

		private static MonoBehaviour GetCoroutineHost()
		{
			if (_coroutineHost == null)
			{
				_coroutineHost = new GameObject().AddComponent<CoroutineHost>();
			}
			return _coroutineHost;
		}

		private IEnumerator DoUpload(ReportUpload upload)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (string key in _metadata.Keys)
			{
				string value = _metadata[key];
				if (_metadataIndices.Contains(key))
				{
					dictionary[key + "*"] = value;
				}
				else
				{
					dictionary[key] = value;
				}
			}
			dictionary["motive*"] = Motive;
			Log.Info("Uploading new report with metadata:");
			foreach (string key2 in dictionary.Keys)
			{
				Log.Info("\t{0}: {1}", key2, dictionary[key2]);
			}
			List<IMultipartFormSection> formSections = new List<IMultipartFormSection>();
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				formSections.Add(new MultipartFormDataSection(item.Key, item.Value));
			}
			UnityWebRequest www = UnityWebRequest.Post("https://api.dinopoloclub.com/1/diagnostics/report/new/", formSections);
			yield return www.SendWebRequest();
			if (www.result != UnityWebRequest.Result.Success)
			{
				Log.Error("Failed to upload report.");
				Log.Error("{0}", www.error);
			}
			else
			{
				JSON.Dictionary dictionary2 = JSON.ToDictionary(JSON.LoadFromString(www.downloadHandler.text));
				if (dictionary2 == null || dictionary2.GetString("result") != "ok")
				{
					Log.Error("Failed to upload report, result '{0}'.", dictionary2.GetString("result"));
				}
				else
				{
					int num = dictionary2.GetInt("reportId");
					if (num <= 0)
					{
						Log.Error("Failed to upload report, invalid id {0}.", num);
					}
					else
					{
						upload.Id = num;
						Id = num;
						Log.Info("Filed report with id {0}, uploading attachments.", Id);
						foreach (ReportAttachment attachment in _attachments)
						{
							string filename = attachment.Filename;
							byte[] filedata = attachment.Data;
							Log.Info("Uploading {0} ({1} bytes).", filename, filedata.Length);
							int attachmentBytesUploaded = 0;
							while (attachmentBytesUploaded < filedata.Length)
							{
								int num2 = Mathf.Min(filedata.Length - attachmentBytesUploaded, 524288);
								byte[] array = new byte[num2];
								Array.Copy(filedata, attachmentBytesUploaded, array, 0, num2);
								attachmentBytesUploaded += num2;
								upload.BytesUploaded += num2;
								formSections.Clear();
								formSections.Add(new MultipartFormFileSection(filename, array));
								Log.Info("Uploading chunk of {0} bytes.", num2);
								UnityWebRequest attachmentRequest = UnityWebRequest.Post(string.Format("{0}diagnostics/report/{1}/attachment/", "https://api.dinopoloclub.com/1/", Id), formSections);
								yield return attachmentRequest.SendWebRequest();
								if (attachmentRequest.result != UnityWebRequest.Result.Success)
								{
									Log.Error("Failed to upload attachment.");
									Log.Error("{0}", attachmentRequest.error);
									break;
								}
								Log.Info("{0}", attachmentRequest.downloadHandler.text);
								JSON.Dictionary dictionary3 = JSON.ToDictionary(JSON.LoadFromString(attachmentRequest.downloadHandler.text));
								string text = null;
								if (dictionary3 != null)
								{
									text = dictionary3.GetString("result");
								}
								if (string.IsNullOrEmpty(text) || text != "ok")
								{
									Log.Info("Failed to upload attachment, result '{0}'.", text);
									break;
								}
								Log.Info("Uploaded {0} / {1} bytes.", attachmentBytesUploaded, filedata.Length);
							}
						}
					}
				}
			}
			upload.IsComplete = true;
		}

		private IEnumerator DoSearch()
		{
			State = ReportState.Searching;
			string searchKey = null;
			string searchValue = null;
			foreach (string key in _metadata.Keys)
			{
				searchKey = key;
				searchValue = _metadata[searchKey];
			}
			if (searchKey == null || searchValue == null)
			{
				State = ReportState.Error;
				yield break;
			}
			UnityWebRequest www = UnityWebRequest.Get(string.Format("{0}diagnostics/report/search/?{1}={2}", "https://api.dinopoloclub.com/1/", searchKey, searchValue));
			yield return www.SendWebRequest();
			if (www.result != UnityWebRequest.Result.Success)
			{
				Log.Error("Failed to search for report matching metadata {0} = {1}.", searchKey, searchValue);
				Log.Error("{0}", www.error);
				State = ReportState.Error;
				yield break;
			}
			JSON.Dictionary dictionary = JSON.ToDictionary(JSON.LoadFromString(www.downloadHandler.text));
			if (dictionary == null || dictionary.GetString("result") != "ok")
			{
				Log.Error("Failed to search for report, result '{0}'.", dictionary.GetString("result"));
				State = ReportState.Error;
			}
			else
			{
				JSON.Array array = dictionary.GetArray("reportIds");
				if (array == null || array.Count == 0)
				{
					Log.Error("Failed to find a report matching metadata {0} = {1}.", searchKey, searchValue);
					State = ReportState.Error;
					yield break;
				}
				Id = Convert.ToInt32(array[0]);
				yield return GetCoroutineHost().StartCoroutine(DoDownload());
			}
			State = ReportState.Ready;
		}

		private IEnumerator DoDownload()
		{
			State = ReportState.Downloading;
			UnityWebRequest www = UnityWebRequest.Get(string.Format("{0}diagnostics/report/{1}/", "https://api.dinopoloclub.com/1/", Id));
			yield return www.SendWebRequest();
			if (www.result != UnityWebRequest.Result.Success)
			{
				Log.Error("Failed to download report {0}.", Id);
				Log.Error("{0}", www.error);
				State = ReportState.Error;
				yield break;
			}
			JSON.Dictionary dictionary = JSON.ToDictionary(JSON.LoadFromString(www.downloadHandler.text));
			if (dictionary == null || dictionary.GetString("result") != "ok")
			{
				Log.Error("Failed to download report, result '{0}'.", dictionary.GetString("result"));
				State = ReportState.Error;
			}
			else
			{
				Motive = dictionary.GetString("name");
				dictionary.GetDictionary("metadata");
				JSON.Array attachments = dictionary.GetArray("attachments");
				if (attachments != null)
				{
					int attachmentIndex = 0;
					while (attachmentIndex < attachments.Count)
					{
						string filename = attachments.GetString(attachmentIndex);
						if (!string.IsNullOrEmpty(filename))
						{
							www = new UnityWebRequest(string.Format("{0}diagnostics/report/{1}/attachment/?filename={2}", "https://api.dinopoloclub.com/1/", Id, filename))
							{
								method = "GET"
							};
							string localFilepath = Path.Combine(Application.temporaryCachePath, filename);
							if (System.IO.File.Exists(localFilepath))
							{
								System.IO.File.Delete(localFilepath);
							}
							DownloadHandlerFile downloadHandlerFile = new DownloadHandlerFile(localFilepath);
							downloadHandlerFile.removeFileOnAbort = true;
							www.downloadHandler = downloadHandlerFile;
							yield return www.SendWebRequest();
							if (www.result != UnityWebRequest.Result.Success)
							{
								Log.Error("Failed to download attachment '{0}'.", filename);
								Debug.Log(www.error);
							}
							else
							{
								Log.Info("Downloaded attachment '{0}' to {1}", filename, localFilepath);
								AttachFile(filename, localFilepath);
							}
						}
						int num = attachmentIndex + 1;
						attachmentIndex = num;
					}
				}
			}
			State = ReportState.Ready;
		}
	}

	private static int _breakCount = 0;

	private static readonly object _breakMutex = new object();

	private static bool _isTrackingExceptions;

	public static bool IsTrackingExceptions
	{
		get
		{
			return _isTrackingExceptions;
		}
		set
		{
			if (_isTrackingExceptions != value)
			{
				_isTrackingExceptions = value;
				if (_isTrackingExceptions)
				{
					Application.logMessageReceived += Exception.OnLogMessageReceived;
				}
				else if (_isTrackingExceptions)
				{
					Application.logMessageReceived -= Exception.OnLogMessageReceived;
				}
			}
		}
	}

	[DebuggerHidden]
	[Conditional("UNITY_EDITOR")]
	public static void Assert(bool condition)
	{
		if (!condition)
		{
			FailAssert("Assertion failed!");
		}
	}

	[StringFormatMethod("message")]
	[Conditional("UNITY_EDITOR")]
	[DebuggerHidden]
	public static void Assert(bool condition, string message, params object[] args)
	{
		if (!condition)
		{
			FailAssert(message, args);
		}
	}

	[DebuggerHidden]
	[StringFormatMethod("message")]
	public static void FailAssert(string message, params object[] args)
	{
		Log.Critical("Assert", message, args);
	}

	[DebuggerHidden]
	[StringFormatMethod("message")]
	public static void FailAssert(UnityEngine.Object contextObject, string message, params object[] args)
	{
		Log.Critical("Assert", message, args);
	}

	[Conditional("UNITY_EDITOR")]
	[DebuggerHidden]
	private static void Break()
	{
		if (_breakCount != 0)
		{
			return;
		}
		bool flag = false;
		lock (_breakMutex)
		{
			_breakCount++;
			if (_breakCount == 1)
			{
				flag = true;
			}
		}
		if (flag && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		lock (_breakMutex)
		{
			_breakCount--;
		}
	}

	[ContractAnnotation("false => false")]
	[ContractAnnotation("true => true")]
	[DebuggerHidden]
	public static bool Verify(bool condition)
	{
		return condition;
	}

	[ContractAnnotation("condition:true => true")]
	[ContractAnnotation("condition:false => false")]
	[DebuggerHidden]
	public static bool Verify(bool condition, string message)
	{
		return condition;
	}

	[ContractAnnotation("condition:false => false")]
	[ContractAnnotation("condition:true => true")]
	[DebuggerHidden]
	public static bool Verify(bool condition, string message, object param0)
	{
		return condition;
	}

	[ContractAnnotation("condition:false => false")]
	[DebuggerHidden]
	[ContractAnnotation("condition:true => true")]
	public static bool Verify(bool condition, string message, object param0, object param1)
	{
		return condition;
	}

	[ContractAnnotation("condition:true => true")]
	[ContractAnnotation("condition:false => false")]
	[DebuggerHidden]
	public static bool Verify(bool condition, string message, object param0, object param1, object param2)
	{
		return condition;
	}

	[DebuggerHidden]
	[ContractAnnotation("condition:true => true")]
	[ContractAnnotation("condition:false => false")]
	public static bool Verify(bool condition, string message, object param0, object param1, object param2, object param3)
	{
		return condition;
	}

	[DebuggerHidden]
	[ContractAnnotation("condition:false => false")]
	[ContractAnnotation("condition:true => true")]
	public static bool Verify(bool condition, string message, object param0, object param1, object param2, object param3, object param4)
	{
		return condition;
	}

	[ContractAnnotation("condition:false => false")]
	[ContractAnnotation("condition:true => true")]
	[DebuggerHidden]
	public static bool Verify(bool condition, string message, object param0, object param1, object param2, object param3, object param4, object param5)
	{
		return condition;
	}

	[ContractAnnotation("condition:true => true")]
	[ContractAnnotation("condition:false => false")]
	[DebuggerHidden]
	public static bool Verify(bool condition, UnityEngine.Object contextObject, string message)
	{
		return condition;
	}

	[ContractAnnotation("condition:true => true")]
	[DebuggerHidden]
	[ContractAnnotation("condition:false => false")]
	public static bool Verify(bool condition, UnityEngine.Object contextObject, string message, object param0)
	{
		return condition;
	}

	[DebuggerHidden]
	[ContractAnnotation("condition:true => true")]
	[ContractAnnotation("condition:false => false")]
	public static bool Verify(bool condition, UnityEngine.Object contextObject, string message, object param0, object param1)
	{
		return condition;
	}

	[ContractAnnotation("condition:false => false")]
	[DebuggerHidden]
	[ContractAnnotation("condition:true => true")]
	public static bool Verify(bool condition, UnityEngine.Object contextObject, string message, object param0, object param1, object param2)
	{
		return condition;
	}

	[DebuggerHidden]
	[ContractAnnotation("condition:false => false")]
	[ContractAnnotation("condition:true => true")]
	public static bool Verify(bool condition, UnityEngine.Object contextObject, string message, object param0, object param1, object param2, object param3)
	{
		return condition;
	}

	[DebuggerHidden]
	[ContractAnnotation("condition:false => false")]
	[ContractAnnotation("condition:true => true")]
	public static bool Verify(bool condition, UnityEngine.Object contextObject, string message, object param0, object param1, object param2, object param3, object param4)
	{
		return condition;
	}

	[DebuggerHidden]
	[ContractAnnotation("condition:false => false")]
	[ContractAnnotation("condition:true => true")]
	public static bool Verify(bool condition, UnityEngine.Object contextObject, string message, object param0, object param1, object param2, object param3, object param4, object param5)
	{
		return condition;
	}
}
