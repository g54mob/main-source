using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class FingerEventDetector<T> : FingerEventDetector where T : FingerEvent, new()
{
	public delegate void FingerEventHandler(T eventData);

	private List<T> fingerEventsList;

	protected virtual T CreateFingerEvent()
	{
		return new T();
	}

	public override Type GetEventType()
	{
		return typeof(T);
	}

	protected override void Start()
	{
		base.Start();
		FingerGestures.OnInputProviderChanged += FingerGestures_OnInputProviderChanged;
		Init();
	}

	protected virtual void OnDestroy()
	{
		FingerGestures.OnInputProviderChanged -= FingerGestures_OnInputProviderChanged;
	}

	private void FingerGestures_OnInputProviderChanged()
	{
		Init();
	}

	protected virtual void Init()
	{
		Init(FingerGestures.Instance.MaxFingers);
	}

	protected virtual void Init(int fingersCount)
	{
		fingerEventsList = new List<T>(fingersCount);
		for (int i = 0; i < fingersCount; i++)
		{
			T val = CreateFingerEvent();
			val.Detector = this;
			val.Finger = FingerGestures.GetFinger(i);
			fingerEventsList.Add(val);
		}
	}

	protected T GetEvent(FingerGestures.Finger finger)
	{
		return GetEvent(finger.Index);
	}

	protected virtual T GetEvent(int fingerIndex)
	{
		return fingerEventsList[fingerIndex];
	}
}
public abstract class FingerEventDetector : MonoBehaviour
{
	public int FingerIndexFilter = -1;

	public ScreenRaycaster Raycaster;

	public bool UseSendMessage = true;

	public bool SendMessageToSelection = true;

	public GameObject MessageTarget;

	private FingerGestures.Finger activeFinger;

	private ScreenRaycastData lastRaycast;

	internal ScreenRaycastData Raycast => lastRaycast;

	protected abstract void ProcessFinger(FingerGestures.Finger finger);

	public abstract Type GetEventType();

	protected virtual void Awake()
	{
		if (!Raycaster)
		{
			Raycaster = GetComponent<ScreenRaycaster>();
		}
		if (!MessageTarget)
		{
			MessageTarget = base.gameObject;
		}
	}

	protected virtual void Start()
	{
	}

	protected virtual void Update()
	{
		ProcessFingers();
	}

	protected virtual void ProcessFingers()
	{
		if (FingerIndexFilter >= 0 && FingerIndexFilter < FingerGestures.Instance.MaxFingers)
		{
			ProcessFinger(FingerGestures.GetFinger(FingerIndexFilter));
			return;
		}
		for (int i = 0; i < FingerGestures.Instance.MaxFingers; i++)
		{
			ProcessFinger(FingerGestures.GetFinger(i));
		}
	}

	protected void TrySendMessage(FingerEvent eventData)
	{
		FingerGestures.FireEvent(eventData);
		if (UseSendMessage)
		{
			MessageTarget.SendMessage(eventData.Name, eventData, SendMessageOptions.DontRequireReceiver);
			if (SendMessageToSelection && (bool)eventData.Selection && eventData.Selection != MessageTarget)
			{
				eventData.Selection.SendMessage(eventData.Name, eventData, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public GameObject PickObject(Vector2 screenPos)
	{
		if (!Raycaster || !Raycaster.enabled)
		{
			return null;
		}
		if (!Raycaster.Raycast(screenPos, out lastRaycast))
		{
			return null;
		}
		return lastRaycast.GameObject;
	}

	protected void UpdateSelection(FingerEvent e)
	{
		e.Selection = PickObject(e.Position);
		e.Raycast = Raycast;
	}
}
