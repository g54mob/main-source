using System;
using UnityEngine;

public class AkAuxSendValue : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public ulong listenerID
	{
		get
		{
			return 0uL;
		}
		set
		{
		}
	}

	public uint auxBusID
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public float fControlValue
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	internal AkAuxSendValue(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkAuxSendValue obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkAuxSendValue()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public void Set(ulong listener, uint id, float value)
	{
	}

	public bool IsSame(ulong listener, uint id)
	{
		return false;
	}

	public void Set(GameObject listener, uint id, float value)
	{
	}

	public bool IsSame(GameObject listener, uint id)
	{
		return false;
	}

	public static int GetSizeOf()
	{
		return 0;
	}
}
