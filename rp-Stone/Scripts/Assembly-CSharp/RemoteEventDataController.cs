using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RemoteEventDataController : MonoBehaviour
{
	public class RemoteEventData
	{
		public Version version;

		public string checksum;

		public EventController.EventData[] events;

		public EventSchedules.ScheduleGenerator[] scheduleGenerators;

		public EventSchedules.Schedule[] baseSchedules;

		public static RemoteEventData FromString(string sjson)
		{
			return new RemoteEventData
			{
				version = Version.FromString(SlimJson.Parse(sjson, "version")),
				checksum = SlimJson.Parse(sjson, "checksum"),
				events = SlimJson.ParseArray(sjson, "data", EventController.EventData.FromString),
				scheduleGenerators = SlimJson.ParseArray(sjson, "scheduleGenerators", EventSchedules.ScheduleGenerator.FromString),
				baseSchedules = SlimJson.ParseArray(sjson, "baseSchedules", EventSchedules.Schedule.FromString)
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("version", version.ToString());
			SlimJson.AddProperty("checksum", checksum);
			SlimJson.AddProperty("data", events);
			SlimJson.AddProperty("scheduleGenerators", scheduleGenerators);
			SlimJson.AddProperty("baseSchedules", baseSchedules);
			return SlimJson.EndSerialization();
		}
	}

	private const string BASE_URL = "https://stonestoryrpg.com/cs/";

	private const string PLAYER_PREFS_KEY = "remote_event_data";

	public string outputSalt;

	public bool forceLocalData;

	public static RemoteEventDataController singleton { get; private set; }

	public bool isLoading { get; private set; }

	public RemoteEventData remoteData { get; private set; }

	public event Action<RemoteEventData> OnLoadingComplete;

	private void Awake()
	{
		singleton = this;
		isLoading = true;
		GetEventData(delegate(bool isRemoteDataNewer, RemoteEventData eventData)
		{
			isLoading = false;
			if (isRemoteDataNewer)
			{
				remoteData = eventData;
				if (this.OnLoadingComplete != null)
				{
					this.OnLoadingComplete(eventData);
				}
			}
			else if (this.OnLoadingComplete != null)
			{
				this.OnLoadingComplete(null);
			}
		});
	}

	public string ComputeChecksum(RemoteEventData data)
	{
		string checksum = data.checksum;
		data.checksum = null;
		string text = data.ToString();
		data.checksum = checksum;
		return Utils.MD5(text + outputSalt);
	}

	public void GetEventData(Action<bool, RemoteEventData> callback)
	{
		StartCoroutine(_GetEventData(callback));
	}

	private IEnumerator _GetEventData(Action<bool, RemoteEventData> callback)
	{
		if (false)
		{
			callback(arg1: false, null);
			yield break;
		}
		string url = "https://stonestoryrpg.com/cs/events.php";
		Utils.LogIfEditor("Calling remote: " + url);
		WWWForm formData = new WWWForm();
		using UnityWebRequest webRequest = UnityWebRequest.Post(url, formData);
		webRequest.timeout = 6;
		yield return webRequest.SendWebRequest();
		if (webRequest.result != UnityWebRequest.Result.Success)
		{
			Utils.LogWarningIfEditor("Failed to reach " + url);
			if (PlayerPrefs.HasKey("remote_event_data"))
			{
				string sjson = PlayerPrefs.GetString("remote_event_data");
				if (Version.FromString(SlimJson.Parse(sjson, "version")) > Features.VERSION)
				{
					RemoteEventData arg = RemoteEventData.FromString(sjson);
					callback(arg1: true, arg);
				}
				else
				{
					callback(arg1: false, null);
				}
			}
			else
			{
				callback(arg1: false, null);
			}
			yield break;
		}
		string text = webRequest.downloadHandler.text;
		try
		{
			Utils.LogIfEditor("Remote event data:\n" + text);
			RemoteEventData remoteEventData = RemoteEventData.FromString(text);
			if (remoteEventData.version > Features.VERSION)
			{
				if (remoteEventData.checksum == ComputeChecksum(remoteEventData))
				{
					Utils.LogIfEditor("Using remote events data, as remote version is greater than local.");
					PlayerPrefs.SetString("remote_event_data", text);
					callback(arg1: true, remoteEventData);
				}
				else
				{
					Utils.LogErrorIfEditor("Mismatching checksum when loading remote events data.");
					callback(arg1: false, null);
				}
			}
			else
			{
				Utils.LogIfEditor("Using local events data, as local version is equal or greater than remote.");
				callback(arg1: false, null);
			}
		}
		catch
		{
			callback(arg1: false, null);
		}
	}

	public void Test()
	{
		RemoteEventData remoteEventData = new RemoteEventData();
		remoteEventData.version = Features.VERSION;
		remoteEventData.events = EventController.singleton.events;
		remoteEventData.scheduleGenerators = EventSchedules.singleton.scheduleGenerators;
		remoteEventData.baseSchedules = EventSchedules.singleton.baseSchedules;
		remoteEventData.checksum = ComputeChecksum(remoteEventData);
		RemoteEventData remoteEventData2 = RemoteEventData.FromString(remoteEventData.ToString());
		if (remoteEventData == remoteEventData2)
		{
			Debug.LogWarning("RemoteEventDataController: Test passed.");
		}
		else
		{
			Debug.LogError("RemoteEventDataController: Test FAILED!");
		}
	}
}
