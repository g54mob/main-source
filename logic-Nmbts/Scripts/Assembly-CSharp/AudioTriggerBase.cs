using UnityEngine;

public abstract class AudioTriggerBase : MonoBehaviour
{
	public enum EventType
	{
		Start = 0,
		Awake = 1,
		OnDestroy = 2,
		OnCollisionEnter = 3,
		OnCollisionExit = 4,
		OnEnable = 5,
		OnDisable = 6
	}

	public EventType triggerEvent;

	protected virtual void Awake()
	{
		_CheckEvent(EventType.Awake);
	}

	protected virtual void Start()
	{
		_CheckEvent(EventType.Start);
	}

	protected virtual void OnDestroy()
	{
		if (triggerEvent == EventType.OnDestroy && (bool)SingletonMonoBehaviour<AudioController>.DoesInstanceExist())
		{
			_CheckEvent(EventType.OnDestroy);
		}
	}

	protected virtual void OnCollisionEnter()
	{
		_CheckEvent(EventType.OnCollisionEnter);
	}

	protected virtual void OnCollisionExit()
	{
		_CheckEvent(EventType.OnCollisionExit);
	}

	protected virtual void OnEnable()
	{
		_CheckEvent(EventType.OnEnable);
	}

	protected virtual void OnDisable()
	{
		_CheckEvent(EventType.OnDisable);
	}

	protected abstract void _OnEventTriggered();

	protected virtual void _CheckEvent(EventType eventType)
	{
		if (triggerEvent == eventType)
		{
			_OnEventTriggered();
		}
	}
}
