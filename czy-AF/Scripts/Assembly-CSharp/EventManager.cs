using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
	private Dictionary<string, UnityEvent> eventDictionary;

	private static EventManager eventManager;

	public static EventManager instance
	{
		get
		{
			if (!eventManager)
			{
				eventManager = Object.FindObjectOfType(typeof(EventManager)) as EventManager;
				if ((bool)eventManager)
				{
					eventManager.Init();
				}
			}
			return eventManager;
		}
	}

	private void Init()
	{
		if (eventDictionary == null)
		{
			eventDictionary = new Dictionary<string, UnityEvent>();
		}
	}

	public static void StartListening(string eventName, UnityAction listener)
	{
		UnityEvent value = null;
		if (instance.eventDictionary.TryGetValue(eventName, out value))
		{
			value.AddListener(listener);
			return;
		}
		value = new UnityEvent();
		value.AddListener(listener);
		instance.eventDictionary.Add(eventName, value);
	}

	public static void StopListening(string eventName, UnityAction listener)
	{
		if (!(eventManager == null))
		{
			UnityEvent value = null;
			if (instance.eventDictionary.TryGetValue(eventName, out value))
			{
				value.RemoveListener(listener);
			}
		}
	}

	public static void TriggerEvent(string eventName)
	{
		UnityEvent value = null;
		if (instance.eventDictionary.TryGetValue(eventName, out value))
		{
			value.Invoke();
		}
	}

	public static void ExportEvents()
	{
		List<string> list = new List<string>();
		foreach (string key in instance.eventDictionary.Keys)
		{
			list.Add(key);
		}
		list.Sort();
		string text = "";
		foreach (string item in list)
		{
			text = text + item + "\n";
		}
		Debug.Log("Events exported to file!");
		File.WriteAllText("events.txt", text);
	}
}
