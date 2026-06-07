using System;

public class SingleEventCapturer
{
	private bool isEventReceived;

	private bool isEventRegistered;

	private Action callback;

	private Enum eventEnum;

	public bool IsEventReceived => false;

	public SingleEventCapturer(Enum e, Action callback = null)
	{
	}

	~SingleEventCapturer()
	{
	}

	private void RegisterEvent(Enum e)
	{
	}

	private void OnReceiveEvent()
	{
	}

	public void UnregisterEvent()
	{
	}
}
public class SingleEventCapturer<T0>
{
	private bool isEventReceived;

	private bool isEventRegistered;

	private Action callback;

	private T0 data;

	private Enum eventEnum;

	public bool IsEventReceived => false;

	public SingleEventCapturer(Enum e, Action callback = null)
	{
	}

	~SingleEventCapturer()
	{
	}

	private void RegisterEvent(Enum e)
	{
	}

	private void OnReceiveEvent(T0 obj)
	{
	}

	public void UnregisterEvent()
	{
	}

	public T0 GetData()
	{
		return default(T0);
	}
}
public class SingleEventCapturer<T0, T1>
{
	private bool isEventReceived;

	private bool isEventRegistered;

	private Action callback;

	private T0 data0;

	private T1 data1;

	private Enum eventEnum;

	public bool IsEventReceived => false;

	public SingleEventCapturer(Enum e, Action callback = null)
	{
	}

	~SingleEventCapturer()
	{
	}

	private void RegisterEvent(Enum e)
	{
	}

	private void OnReceiveEvent(T0 obj1, T1 obj2)
	{
	}

	public void UnregisterEvent()
	{
	}

	public void GetData(out T0 out0, out T1 out1)
	{
		out0 = default(T0);
		out1 = default(T1);
	}
}
public class SingleEventCapturer<T0, T1, T2>
{
	private bool isEventReceived;

	private bool isEventRegistered;

	private Action callback;

	private T0 data0;

	private T1 data1;

	private T2 data2;

	private Enum eventEnum;

	public bool IsEventReceived => false;

	public SingleEventCapturer(Enum e, Action callback = null)
	{
	}

	~SingleEventCapturer()
	{
	}

	private void RegisterEvent(Enum e)
	{
	}

	private void OnReceiveEvent(T0 obj0, T1 obj1, T2 obj2)
	{
	}

	public void UnregisterEvent()
	{
	}

	public void GetData(out T0 out0, out T1 out1, out T2 out2)
	{
		out0 = default(T0);
		out1 = default(T1);
		out2 = default(T2);
	}
}
