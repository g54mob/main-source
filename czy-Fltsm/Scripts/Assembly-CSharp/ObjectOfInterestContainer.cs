using System.Collections.Generic;
using PajamaLlama.Debugs;
using UnityEngine;

public class ObjectOfInterestContainer
{
	private int _lastSelectedObject;

	public List<INotificationObjectOfInterest> ObjectsOfInterest { get; private set; } = new List<INotificationObjectOfInterest>();

	public void SelectObjectOfInterest()
	{
		if (ObjectsOfInterest.Count == 0)
		{
			Debugger.Warning("Trying to divide by zero!");
			return;
		}
		_lastSelectedObject = Mathf.Clamp(_lastSelectedObject % ObjectsOfInterest.Count, 0, ObjectsOfInterest.Count - 1);
		ObjectsOfInterest[_lastSelectedObject].NotificationLeftClick();
		_lastSelectedObject++;
	}

	public bool AddObjectOfInterest(INotificationObjectOfInterest objectOfInterest)
	{
		if (objectOfInterest == null)
		{
			Debugger.Warning("Tried adding an object of interest that's null!");
			return false;
		}
		if (ReturnObjectOfInterest(objectOfInterest) == null)
		{
			ObjectsOfInterest.AddUnique(objectOfInterest);
			return true;
		}
		return false;
	}

	public bool RemoveObjectOfInterest(GameObject gameObject)
	{
		INotificationObjectOfInterest notificationObjectOfInterest = ReturnObjectOfInterest(gameObject);
		if (notificationObjectOfInterest == null)
		{
			return false;
		}
		if (ObjectsOfInterest.Remove(notificationObjectOfInterest))
		{
			if (ObjectsOfInterest.Count > 0)
			{
				_lastSelectedObject = Mathf.Clamp(_lastSelectedObject % ObjectsOfInterest.Count, 0, ObjectsOfInterest.Count - 1);
			}
			return true;
		}
		return false;
	}

	public bool RemoveObjectOfInterest(INotificationObjectOfInterest objectOfInterest)
	{
		if (objectOfInterest == null)
		{
			return false;
		}
		if (ObjectsOfInterest.Remove(objectOfInterest))
		{
			if (ObjectsOfInterest.Count > 0)
			{
				_lastSelectedObject = Mathf.Clamp(_lastSelectedObject % ObjectsOfInterest.Count, 0, ObjectsOfInterest.Count - 1);
			}
			return true;
		}
		return false;
	}

	private INotificationObjectOfInterest ReturnObjectOfInterest(GameObject gameObject)
	{
		return ObjectsOfInterest.Find((INotificationObjectOfInterest notificationObjectOfInterest) => notificationObjectOfInterest.GameObjectOfInterest == gameObject);
	}

	private INotificationObjectOfInterest ReturnObjectOfInterest(INotificationObjectOfInterest objectOfInterest)
	{
		return ObjectsOfInterest.Find((INotificationObjectOfInterest notificationObjectOfInterest) => notificationObjectOfInterest.IsMatch(objectOfInterest));
	}
}
