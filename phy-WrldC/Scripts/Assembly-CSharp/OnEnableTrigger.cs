using UnityEngine;
using UnityEngine.Events;

public class OnEnableTrigger : MonoBehaviour
{
	public enum EventTriggerPermission
	{
		NotReady = 0,
		AfterGameTime = 1,
		Ready = 2
	}

	public EventTriggerPermission m_EventTriggerPermission;

	public float m_TiggerNotEarlyThanGameTime = 1f;

	public UnityEvent m_OnEnableEvent;

	public UnityEvent m_OnDisableEvent;

	private void OnEnable()
	{
		if (m_EventTriggerPermission == EventTriggerPermission.Ready || (m_EventTriggerPermission == EventTriggerPermission.AfterGameTime && Time.time > m_TiggerNotEarlyThanGameTime))
		{
			m_OnEnableEvent.Invoke();
		}
	}

	private void OnDisable()
	{
		if (m_EventTriggerPermission == EventTriggerPermission.Ready || (m_EventTriggerPermission == EventTriggerPermission.AfterGameTime && Time.time > m_TiggerNotEarlyThanGameTime))
		{
			m_OnDisableEvent.Invoke();
		}
	}
}
