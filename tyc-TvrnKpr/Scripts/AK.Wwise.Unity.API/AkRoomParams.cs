using System;
using UnityEngine;

public class AkRoomParams : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public Vector3 Front
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public Vector3 Up
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public uint ReverbAuxBus
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public float ReverbLevel
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float TransmissionLoss
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float RoomGameObj_AuxSendLevelToSelf
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool RoomGameObj_KeepRegistered
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float RoomPriority
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	internal AkRoomParams(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkRoomParams obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkRoomParams()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkRoomParams()
	{
	}
}
