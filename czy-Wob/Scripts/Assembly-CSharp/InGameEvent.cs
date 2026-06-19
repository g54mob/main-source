using UnityEngine;

public class InGameEvent
{
	protected float internalEventTimer;

	public virtual void Update()
	{
		internalEventTimer += Time.deltaTime;
	}

	public virtual void RunEvent(EventController controllerRef)
	{
		Debug.LogError("Custom implementation for RunEvent() expected.");
	}

	public virtual void StopEvent()
	{
		Debug.LogError("Custom implementation for StopEvent() expected.");
	}
}
