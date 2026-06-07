using System;
using System.Collections.Generic;

public static class EventMgr
{
	private static Dictionary<Enum, IEventBase> s_events;

	public static void Register(Enum key, Action act)
	{
	}

	public static void Register<T0>(Enum key, Action<T0> act)
	{
	}

	public static void Register<T0, T1>(Enum key, Action<T0, T1> act)
	{
	}

	public static void Register<T0, T1, T2>(Enum key, Action<T0, T1, T2> act)
	{
	}

	public static void Register<T0, T1, T2, T3>(Enum key, Action<T0, T1, T2, T3> act)
	{
	}

	public static void Register<T0, T1, T2, T3, T4>(Enum key, Action<T0, T1, T2, T3, T4> act)
	{
	}

	public static void Remove(Enum key, Action act)
	{
	}

	public static void Remove<T0>(Enum key, Action<T0> act)
	{
	}

	public static void Remove<T0, T1>(Enum key, Action<T0, T1> act)
	{
	}

	public static void Remove<T0, T1, T2>(Enum key, Action<T0, T1, T2> act)
	{
	}

	public static void Remove<T0, T1, T2, T3>(Enum key, Action<T0, T1, T2, T3> act)
	{
	}

	public static void Remove<T0, T1, T2, T3, T4>(Enum key, Action<T0, T1, T2, T3, T4> act)
	{
	}

	public static void Clear(Enum key)
	{
	}

	public static void PrintEvents()
	{
	}

	public static int SendEvent(Enum key)
	{
		return 0;
	}

	public static int SendEvent<T0>(Enum key, T0 arg0)
	{
		return 0;
	}

	public static int SendEvent<T0, T1>(Enum key, T0 arg0, T1 arg1)
	{
		return 0;
	}

	public static int SendEvent<T0, T1, T2>(Enum key, T0 arg0, T1 arg1, T2 arg2)
	{
		return 0;
	}

	public static int SendEvent<T0, T1, T2, T3>(Enum key, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
	{
		return 0;
	}

	public static int SendEvent<T0, T1, T2, T3, T4>(Enum key, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
	{
		return 0;
	}

	private static T TryGet<T>(Enum key) where T : IEventBase
	{
		return default(T);
	}

	private static EventBase Ensure(Enum key)
	{
		return null;
	}

	private static EventBase<T0> Ensure<T0>(Enum key)
	{
		return null;
	}

	private static EventBase<T0, T1> Ensure<T0, T1>(Enum key)
	{
		return null;
	}

	private static EventBase<T0, T1, T2> Ensure<T0, T1, T2>(Enum key)
	{
		return null;
	}

	private static EventBase<T0, T1, T2, T3> Ensure<T0, T1, T2, T3>(Enum key)
	{
		return null;
	}

	private static EventBase<T0, T1, T2, T3, T4> Ensure<T0, T1, T2, T3, T4>(Enum key)
	{
		return null;
	}
}
