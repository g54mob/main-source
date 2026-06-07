using System;
using UnityEngine;

public abstract class MonoBehaviourBaseView : MonoBehaviour, IBaseView
{
	public object Controller { get; set; }

	public event Action<string, object[]> NotifyChangeEvent;

	public void NotifyChange(string eventName, params object[] data)
	{
		if (this.NotifyChangeEvent != null)
		{
			Debug.Log("<color=purple><b>VIEW EVENT:</b> " + eventName + "</color>");
			this.NotifyChangeEvent(eventName, data);
		}
	}

	public bool DetachController()
	{
		if (Controller == null)
		{
			return false;
		}
		bool result = false;
		Type baseType = Controller.GetType().BaseType;
		if (baseType.IsGenericType)
		{
			if (baseType.GetGenericTypeDefinition() == typeof(BaseController<>))
			{
				Controller.GetType().GetMethod("SetView").Invoke(Controller, new object[1]);
			}
			if (baseType.GetGenericTypeDefinition() == typeof(BaseController<, >))
			{
				Controller.GetType().GetMethod("SetModel").Invoke(Controller, new object[1]);
				Controller.GetType().GetMethod("SetView").Invoke(Controller, new object[1]);
			}
			Debug.Log("<color=white><b>Controller Detached: View (<i>" + base.name + "</i>)</b></color>");
			result = true;
		}
		Controller = null;
		return result;
	}

	protected void OnDestroy()
	{
		if (DetachController())
		{
			Debug.Log("<color=black><b>Destroyed: View (<i>" + base.name + "</i>)</b></color>");
		}
	}
}
