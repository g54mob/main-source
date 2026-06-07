using System;
using Events;
using UnityEngine;

public class UIEventEnabler : MonoBehaviour
{
	[SerializeField]
	private BaseEvent[] _UIEnableEvents = Array.Empty<BaseEvent>();

	[SerializeField]
	private BaseEvent[] _UIDisableEvents = Array.Empty<BaseEvent>();

	private void Awake()
	{
		BaseEvent[] uIEnableEvents = _UIEnableEvents;
		for (int i = 0; i < uIEnableEvents.Length; i++)
		{
			uIEnableEvents[i].Register(EnableUI);
		}
		uIEnableEvents = _UIDisableEvents;
		for (int i = 0; i < uIEnableEvents.Length; i++)
		{
			uIEnableEvents[i].Register(DisableUI);
		}
	}

	private void OnDestroy()
	{
		BaseEvent[] uIEnableEvents = _UIEnableEvents;
		for (int i = 0; i < uIEnableEvents.Length; i++)
		{
			uIEnableEvents[i].UnRegister(EnableUI);
		}
		uIEnableEvents = _UIDisableEvents;
		for (int i = 0; i < uIEnableEvents.Length; i++)
		{
			uIEnableEvents[i].UnRegister(DisableUI);
		}
	}

	private void EnableUI()
	{
		base.gameObject.SetActive(value: true);
	}

	private void DisableUI()
	{
		base.gameObject.SetActive(value: false);
	}
}
