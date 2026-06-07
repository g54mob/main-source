using System;

public class EventEmitter
{
	private Delegate[] callbacks;

	public DelegateType getDelegate<DelegateType>(WorldEvents evt) where DelegateType : Delegate
	{
		return null;
	}

	public void on<DelegateType>(DelegateType a, WorldEvents evt) where DelegateType : Delegate
	{
	}

	public void emit(WorldEvents evt)
	{
	}

	public void emit<T1>(WorldEvents evt, T1 arg1)
	{
	}

	public void emit<T1, T2>(WorldEvents evt, T1 arg1, T2 arg2)
	{
	}

	public void emit<T1, T2, T3>(WorldEvents evt, T1 arg1, T2 arg2, T3 arg3)
	{
	}

	public void emit<T1, T2, T3, T4>(WorldEvents evt, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
	{
	}

	public void emit<T1, T2, T3, T4, T5>(WorldEvents evt, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
	{
	}

	public void emit<T1, T2, T3, T4, T5, T6>(WorldEvents evt, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
	{
	}

	public void removeAllListeners()
	{
	}
}
