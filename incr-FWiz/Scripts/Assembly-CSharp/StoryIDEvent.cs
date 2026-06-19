using System.Collections.Generic;
using UnityEngine;

public abstract class StoryIDEvent : MonoBehaviour
{
	private static Dictionary<string, StoryIDEvent> _events;

	public string ID;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public static void Trigger(string id)
	{
	}

	public abstract void Trigger();
}
