using System;

public class AkImageSourceParams : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public AkVector64 sourcePosition
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public float fDistanceScalingFactor
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float fLevel
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float fDiffraction
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float fOcclusion
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public byte uDiffractionEmitterSide
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public byte uDiffractionListenerSide
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	internal AkImageSourceParams(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkImageSourceParams obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkImageSourceParams()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkImageSourceParams()
	{
	}

	public AkImageSourceParams(AkVector64 in_sourcePosition, float in_fDistanceScalingFactor, float in_fLevel)
	{
	}
}
