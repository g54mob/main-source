using System;

public class AkBehavioralPositioningData : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public float center
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float panLR
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float panBF
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float panDU
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float panSpatMix
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public Ak3DSpatializationMode spatMode
	{
		get
		{
			return default(Ak3DSpatializationMode);
		}
		set
		{
		}
	}

	public AkSpeakerPanningType panType
	{
		get
		{
			return default(AkSpeakerPanningType);
		}
		set
		{
		}
	}

	public bool enableHeightSpread
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	internal AkBehavioralPositioningData(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkBehavioralPositioningData obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkBehavioralPositioningData()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkBehavioralPositioningData()
	{
	}
}
