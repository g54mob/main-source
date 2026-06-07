using System;
using UnityEngine;

public abstract class EventBase<T> : IDisposable where T : Enum
{
	public T EventType { get; protected set; }

	public bool IsBeingDispatched { get; private set; }

	public EventBase(T type)
	{
		EventType = type;
	}

	public void Dispatch()
	{
		try
		{
			IsBeingDispatched = true;
			DispatchEvent();
		}
		catch (Exception innerException)
		{
			Debug.LogException(new Exception($"Exception caught while disptaching '{EventType}'", innerException));
		}
		finally
		{
			IsBeingDispatched = false;
		}
	}

	public virtual void Dispose()
	{
	}

	protected abstract void DispatchEvent();
}
