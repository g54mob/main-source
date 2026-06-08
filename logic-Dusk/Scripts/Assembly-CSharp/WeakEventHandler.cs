using System;
using UnityEngine;

public class WeakEventHandler<T, E> : IWeakEventHandler<E> where T : class where E : EventArgs
{
	private delegate void OpenEventHandler(T @this, object sender, E e);

	private WeakReference m_TargetRef;

	private OpenEventHandler m_OpenHandler;

	private EventHandler<E> m_Handler;

	private UnregisterCallback<E> m_Unregister;

	public EventHandler<E> Handler
	{
		get
		{
			return m_Handler;
		}
	}

	public WeakEventHandler(EventHandler<E> eventHandler, UnregisterCallback<E> unregister)
	{
		m_TargetRef = new WeakReference(eventHandler.Target);
		m_OpenHandler = (OpenEventHandler)Delegate.CreateDelegate(typeof(OpenEventHandler), null, eventHandler.Method);
		m_Handler = Invoke;
		m_Unregister = unregister;
	}

	public void Invoke(object sender, E e)
	{
		T val = (T)m_TargetRef.Target;
		if (val != null)
		{
			m_OpenHandler(val, sender, e);
		}
		else if (m_Unregister != null)
		{
			Debug.LogWarning("WeakEventHandler.Invoke() could not work because target was null.  Unregistering...");
			m_Unregister(m_Handler);
			m_Unregister = null;
		}
	}

	public static implicit operator EventHandler<E>(WeakEventHandler<T, E> weh)
	{
		return weh.m_Handler;
	}
}
