using System;

public class AkSpatialAudioInitSettings : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public uint uMaxSoundPropagationDepth
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public float fMovementThreshold
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public uint uNumberOfPrimaryRays
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uMaxReflectionOrder
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uMaxDiffractionOrder
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uMaxDiffractionPaths
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uMaxGlobalReflectionPaths
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uMaxEmitterRoomAuxSends
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uDiffractionOnReflectionsOrder
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public float fMaxDiffractionAngleDegrees
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float fMaxPathLength
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float fCPULimitPercentage
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float fSmoothingConstantMs
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public uint uLoadBalancingSpread
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public bool bEnableGeometricDiffractionAndTransmission
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool bCalcEmitterVirtualPosition
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public AkTransmissionOperation eTransmissionOperation
	{
		get
		{
			return default(AkTransmissionOperation);
		}
		set
		{
		}
	}

	internal AkSpatialAudioInitSettings(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkSpatialAudioInitSettings obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkSpatialAudioInitSettings()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkSpatialAudioInitSettings()
	{
	}
}
