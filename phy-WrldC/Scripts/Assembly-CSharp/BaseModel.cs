using System;
using UnityEngine;

public abstract class BaseModel
{
	public event Action<string, object[]> NotifyChangeEvent;

	protected void NotifyChange(string eventName, params object[] data)
	{
		if (this.NotifyChangeEvent != null)
		{
			Debug.Log("<color=darkblue><b>MODEL EVENT:</b> " + eventName + "</color>");
			this.NotifyChangeEvent(eventName, data);
		}
	}
}
