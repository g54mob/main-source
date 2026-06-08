using System;

public class AkSpatialAudioInitSettings : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public uint uMaxSoundPropagationDepth
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_uMaxSoundPropagationDepth_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_uMaxSoundPropagationDepth_set(swigCPtr, value);
		}
	}

	public float fMovementThreshold
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_fMovementThreshold_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_fMovementThreshold_set(swigCPtr, value);
		}
	}

	public uint uNumberOfPrimaryRays
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_uNumberOfPrimaryRays_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_uNumberOfPrimaryRays_set(swigCPtr, value);
		}
	}

	public uint uMaxReflectionOrder
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_uMaxReflectionOrder_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_uMaxReflectionOrder_set(swigCPtr, value);
		}
	}

	public float fMaxPathLength
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_fMaxPathLength_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_fMaxPathLength_set(swigCPtr, value);
		}
	}

	public float fCPULimitPercentage
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_fCPULimitPercentage_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_fCPULimitPercentage_set(swigCPtr, value);
		}
	}

	public bool bEnableDiffractionOnReflection
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_bEnableDiffractionOnReflection_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_bEnableDiffractionOnReflection_set(swigCPtr, value);
		}
	}

	public bool bEnableGeometricDiffractionAndTransmission
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_bEnableGeometricDiffractionAndTransmission_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_bEnableGeometricDiffractionAndTransmission_set(swigCPtr, value);
		}
	}

	public bool bCalcEmitterVirtualPosition
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_bCalcEmitterVirtualPosition_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_bCalcEmitterVirtualPosition_set(swigCPtr, value);
		}
	}

	public bool bUseObstruction
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_bUseObstruction_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_bUseObstruction_set(swigCPtr, value);
		}
	}

	public bool bUseOcclusion
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_bUseOcclusion_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkSpatialAudioInitSettings_bUseOcclusion_set(swigCPtr, value);
		}
	}

	internal AkSpatialAudioInitSettings(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = cPtr;
	}

	internal static IntPtr getCPtr(AkSpatialAudioInitSettings obj)
	{
		return obj?.swigCPtr ?? IntPtr.Zero;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
		Dispose();
		swigCPtr = cPtr;
	}

	~AkSpatialAudioInitSettings()
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
					AkSoundEnginePINVOKE.CSharp_delete_AkSpatialAudioInitSettings(swigCPtr);
				}
				swigCPtr = IntPtr.Zero;
			}
			GC.SuppressFinalize(this);
		}
	}

	public AkSpatialAudioInitSettings()
		: this(AkSoundEnginePINVOKE.CSharp_new_AkSpatialAudioInitSettings(), cMemoryOwn: true)
	{
	}
}
