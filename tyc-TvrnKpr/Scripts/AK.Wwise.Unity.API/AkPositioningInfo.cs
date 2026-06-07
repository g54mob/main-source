using System;

public class AkPositioningInfo : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public float fCenterPct
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public AkSpeakerPanningType pannerType
	{
		get
		{
			return default(AkSpeakerPanningType);
		}
		set
		{
		}
	}

	public Ak3DPositionType e3dPositioningType
	{
		get
		{
			return default(Ak3DPositionType);
		}
		set
		{
		}
	}

	public bool bHoldEmitterPosAndOrient
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public Ak3DSpatializationMode e3DSpatializationMode
	{
		get
		{
			return default(Ak3DSpatializationMode);
		}
		set
		{
		}
	}

	public bool bEnableAttenuation
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool bUseConeAttenuation
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float fInnerAngle
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float fOuterAngle
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float fConeMaxAttenuation
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float LPFCone
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float HPFCone
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float fMaxDistance
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float fVolDryAtMaxDist
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float fVolAuxGameDefAtMaxDist
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float fVolAuxUserDefAtMaxDist
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float LPFValueAtMaxDist
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float HPFValueAtMaxDist
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	internal AkPositioningInfo(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkPositioningInfo obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkPositioningInfo()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkPositioningInfo()
	{
	}
}
