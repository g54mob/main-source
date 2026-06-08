using System;

public class AkBehavioralPositioningData : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public float center
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkBehavioralPositioningData_center_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkBehavioralPositioningData_center_set(swigCPtr, value);
		}
	}

	public float panLR
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkBehavioralPositioningData_panLR_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkBehavioralPositioningData_panLR_set(swigCPtr, value);
		}
	}

	public float panBF
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkBehavioralPositioningData_panBF_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkBehavioralPositioningData_panBF_set(swigCPtr, value);
		}
	}

	public float panDU
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkBehavioralPositioningData_panDU_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkBehavioralPositioningData_panDU_set(swigCPtr, value);
		}
	}

	public float panSpatMix
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkBehavioralPositioningData_panSpatMix_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkBehavioralPositioningData_panSpatMix_set(swigCPtr, value);
		}
	}

	public Ak3DSpatializationMode spatMode
	{
		get
		{
			return (Ak3DSpatializationMode)AkSoundEnginePINVOKE.CSharp_AkBehavioralPositioningData_spatMode_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkBehavioralPositioningData_spatMode_set(swigCPtr, (int)value);
		}
	}

	public AkSpeakerPanningType panType
	{
		get
		{
			return (AkSpeakerPanningType)AkSoundEnginePINVOKE.CSharp_AkBehavioralPositioningData_panType_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkBehavioralPositioningData_panType_set(swigCPtr, (int)value);
		}
	}

	public bool enableHeightSpread
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkBehavioralPositioningData_enableHeightSpread_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkBehavioralPositioningData_enableHeightSpread_set(swigCPtr, value);
		}
	}

	internal AkBehavioralPositioningData(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = cPtr;
	}

	internal static IntPtr getCPtr(AkBehavioralPositioningData obj)
	{
		return obj?.swigCPtr ?? IntPtr.Zero;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
		Dispose();
		swigCPtr = cPtr;
	}

	~AkBehavioralPositioningData()
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
					AkSoundEnginePINVOKE.CSharp_delete_AkBehavioralPositioningData(swigCPtr);
				}
				swigCPtr = IntPtr.Zero;
			}
			GC.SuppressFinalize(this);
		}
	}

	public AkBehavioralPositioningData()
		: this(AkSoundEnginePINVOKE.CSharp_new_AkBehavioralPositioningData(), cMemoryOwn: true)
	{
	}
}
