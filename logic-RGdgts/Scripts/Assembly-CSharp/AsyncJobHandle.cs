using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class AsyncJobHandle
{
	public delegate bool IsCompleteCallback(IntPtr handePtr);

	public delegate void DisposeCallback(IntPtr handePtr);

	public CPUModule cpu;

	public IGenericAsyncJob job;

	public GCHandle gcHandle;

	public static Dictionary<Type, IntPtr> jobValueGetters;

	public AsyncJobHandle(CPUModule cpu, IGenericAsyncJob job)
	{
	}

	public void Dispose()
	{
	}

	public IntPtr GetValueGetter()
	{
		return (IntPtr)0;
	}

	public static bool IsComplete(IntPtr handlePtr)
	{
		return false;
	}

	public static void DisposeJob(IntPtr handlePtr)
	{
	}
}
