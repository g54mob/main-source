using System;
using System.Reflection;

public static class EventHandlerUtils
{
	public static EventHandler<E> MakeWeak<E>(this EventHandler<E> eventHandler, UnregisterCallback<E> unregister) where E : EventArgs
	{
		if (eventHandler == null)
		{
			throw new ArgumentNullException("eventHandler");
		}
		if (eventHandler.Method.IsStatic || eventHandler.Target == null)
		{
			throw new ArgumentException("Only instance methods are supported.", "eventHandler");
		}
		Type type = typeof(WeakEventHandler<, >).MakeGenericType(eventHandler.Method.DeclaringType, typeof(E));
		ConstructorInfo constructor = type.GetConstructor(new Type[2]
		{
			typeof(EventHandler<E>),
			typeof(UnregisterCallback<E>)
		});
		IWeakEventHandler<E> weakEventHandler = (IWeakEventHandler<E>)constructor.Invoke(new object[2] { eventHandler, unregister });
		return weakEventHandler.Handler;
	}
}
