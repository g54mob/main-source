using System;
using System.Collections.Generic;

public class EventBase : IEventBase
{
	public readonly List<Action> handlers;

	public int Count => 0;

	public bool IsEmpty => false;

	public uint SendEventCount { get; protected set; }

	public void Clear()
	{
	}

	public void Register(Action h)
	{
	}

	public bool Remove(Action h)
	{
		return false;
	}

	public int SendEvent()
	{
		return 0;
	}
}
public class EventBase<T0> : IEventBase
{
	public readonly List<Action<T0>> handlers;

	public int Count => 0;

	public bool IsEmpty => false;

	public uint SendEventCount { get; protected set; }

	public void Clear()
	{
	}

	public void Register(Action<T0> h)
	{
	}

	public bool Remove(Action<T0> h)
	{
		return false;
	}

	public int SendEvent(T0 p0)
	{
		return 0;
	}
}
public class EventBase<T0, T1> : IEventBase
{
	public readonly List<Action<T0, T1>> handlers;

	public int Count => 0;

	public bool IsEmpty => false;

	public uint SendEventCount { get; protected set; }

	public void Clear()
	{
	}

	public void Register(Action<T0, T1> h)
	{
	}

	public bool Remove(Action<T0, T1> h)
	{
		return false;
	}

	public int SendEvent(T0 p0, T1 p1)
	{
		return 0;
	}
}
public class EventBase<T0, T1, T2> : IEventBase
{
	public readonly List<Action<T0, T1, T2>> handlers;

	public int Count => 0;

	public bool IsEmpty => false;

	public uint SendEventCount { get; protected set; }

	public void Clear()
	{
	}

	public void Register(Action<T0, T1, T2> h)
	{
	}

	public bool Remove(Action<T0, T1, T2> h)
	{
		return false;
	}

	public int SendEvent(T0 p0, T1 p1, T2 p2)
	{
		return 0;
	}
}
public class EventBase<T0, T1, T2, T3> : IEventBase
{
	public readonly List<Action<T0, T1, T2, T3>> handlers;

	public int Count => 0;

	public bool IsEmpty => false;

	public uint SendEventCount { get; protected set; }

	public void Clear()
	{
	}

	public void Register(Action<T0, T1, T2, T3> h)
	{
	}

	public bool Remove(Action<T0, T1, T2, T3> h)
	{
		return false;
	}

	public int SendEvent(T0 p0, T1 p1, T2 p2, T3 p3)
	{
		return 0;
	}
}
public class EventBase<T0, T1, T2, T3, T4> : IEventBase
{
	public readonly List<Action<T0, T1, T2, T3, T4>> handlers;

	public int Count => 0;

	public bool IsEmpty => false;

	public uint SendEventCount { get; protected set; }

	public void Clear()
	{
	}

	public void Register(Action<T0, T1, T2, T3, T4> h)
	{
	}

	public bool Remove(Action<T0, T1, T2, T3, T4> h)
	{
		return false;
	}

	public int SendEvent(T0 p0, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		return 0;
	}
}
