using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class AmplitudeAnalytics : MonoBehaviour
{
	internal class EventData
	{
		public string device_id = SystemInfo.deviceUniqueIdentifier;

		public string device_type = "PC";

		public string os_name = SystemInfo.operatingSystem.ToString();

		public string platform = Application.platform.ToString();

		public string language = Application.systemLanguage.ToString();

		public string session_id;

		public string app_version;

		public string user_id;

		public string time;

		public string event_type;

		public Dictionary<string, object> user_properties = new Dictionary<string, object>();

		public Dictionary<string, object> event_properties = new Dictionary<string, object>();

		public bool ShouldSerializeuser_properties()
		{
			if (user_properties != null)
			{
				return user_properties.Count > 0;
			}
			return false;
		}

		public bool ShouldSerializeevent_properties()
		{
			if (event_properties != null)
			{
				return event_properties.Count > 0;
			}
			return false;
		}
	}

	private const string API_KEY = "6d8813123f16370a1e1b9d2d2ac0567e";

	private EventData _event;

	private EventData[] _events = new EventData[1];

	public void Init(string version, string userId)
	{
		_event = new EventData();
		_event.session_id = GetTimeStamp().ToString();
		_event.app_version = version;
		_event.user_id = userId;
		_events[0] = _event;
	}

	public void Event(string eventName)
	{
		Event(eventName, null, null);
	}

	private string GetTimeStamp()
	{
		return ((long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds).ToString();
	}

	public void Event(string eventName, Dictionary<string, object> eventParams, Dictionary<string, object> userParams)
	{
		_event.time = GetTimeStamp();
		_event.event_type = eventName;
		_event.event_properties = eventParams;
		_event.user_properties = userParams;
		string text = JsonConvert.SerializeObject(_events);
		string json = "{api_key:'6d8813123f16370a1e1b9d2d2ac0567e', events:" + text + "}";
		Debug.Log("amplitude analytics event: " + eventName);
		if (!Debug.isDebugBuild)
		{
			StartCoroutine(Send("https://api.amplitude.com/2/httpapi", json));
		}
		else
		{
			Debug.Log("amplitude analytics event: " + eventName + " - sending skipped beacause of Debug mode");
		}
	}

	private IEnumerator Send(string url, string json)
	{
		UnityWebRequest request = new UnityWebRequest(url, "POST");
		byte[] bytes = Encoding.UTF8.GetBytes(json);
		request.uploadHandler = new UploadHandlerRaw(bytes);
		request.downloadHandler = new DownloadHandlerBuffer();
		request.SetRequestHeader("Content-Type", "application/json");
		yield return request.SendWebRequest();
		if (request.isNetworkError || request.isHttpError)
		{
			Debug.Log("amplitude analytics request error:  " + request.error + " " + request.downloadHandler.text);
		}
	}
}
