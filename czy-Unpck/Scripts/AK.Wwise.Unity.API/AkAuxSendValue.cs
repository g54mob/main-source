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
			return AkSoundEnginePINVOKE.CSharp_AkAuxSendValue_listenerID_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkAuxSendValue_listenerID_set(swigCPtr, value);
		}
	}

	public uint auxBusID
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkAuxSendValue_auxBusID_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkAuxSendValue_auxBusID_set(swigCPtr, value);
		}
	}

	public float fControlValue
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkAuxSendValue_fControlValue_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkAuxSendValue_fControlValue_set(swigCPtr, value);
		}
	}

	internal AkAuxSendValue(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = cPtr;
	}

	internal static IntPtr getCPtr(AkAuxSendValue obj)
	{
		return obj?.swigCPtr ?? IntPtr.Zero;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
		Dispose();
		swigCPtr = cPtr;
	}

	~AkAuxSendValue()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					AkSoundEnginePINVOKE.CSharp_delete_AkAuxSendValue(swigCPtr);
				}
				swigCPtr = IntPtr.Zero;
			}
			GC.SuppressFinalize(this);
		}
	}

	public void Set(ulong listener, uint id, float value)
	{
		AkSoundEnginePINVOKE.CSharp_AkAuxSendValue_Set(swigCPtr, listener, id, value);
	}

	public bool IsSame(ulong listener, uint id)
	{
		return AkSoundEnginePINVOKE.CSharp_AkAuxSendValue_IsSame(swigCPtr, listener, id);
	}

	public void Set(GameObject listener, uint id, float value)
	{
		ulong akGameObjectID = AkSoundEngine.GetAkGameObjectID(listener);
		AkSoundEngine.PreGameObjectAPICall(listener, akGameObjectID);
		Set(akGameObjectID, id, value);
	}

	public bool IsSame(GameObject listener, uint id)
	{
		ulong akGameObjectID = AkSoundEngine.GetAkGameObjectID(listener);
		AkSoundEngine.PreGameObjectAPICall(listener, akGameObjectID);
		return IsSame(akGameObjectID, id);
	}

	public static int GetSizeOf()
	{
		return AkSoundEnginePINVOKE.CSharp_AkAuxSendValue_GetSizeOf();
	}
}
