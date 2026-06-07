using System;
using UnityEngine;

public abstract class BaseView : IBaseView
{
	private object controller;

	public object Controller
	{
		get
		{
			return controller;
		}
		set
		{
			controller = value;
		}
	}

	public event Action<string, object[]> NotifyChangeEvent;

	public void NotifyChange(string eventName, params object[] data)
	{
		if (this.NotifyChangeEvent != null)
		{
			Debug.Log("<color=purple><b>VIEW EVENT:</b> " + eventName + "</color>");
			this.NotifyChangeEvent(eventName, data);
		}
	}
}
