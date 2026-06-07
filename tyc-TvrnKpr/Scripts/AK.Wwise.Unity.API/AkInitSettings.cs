using System;

public class AkInitSettings : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public uint uMaxNumPaths
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uCommandQueueSize
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public bool bEnableGameSyncPreparation
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public uint uContinuousPlaybackLookAhead
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uNumSamplesPerFrame
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uMonitorQueuePoolSize
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uCpuMonitorQueueMaxSize
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public AkOutputSettings settingsMainOutput
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public uint uMaxHardwareTimeoutMs
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public bool bUseSoundBankMgrThread
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool bUseLEngineThread
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public string szPluginDLLPath
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public AkFloorPlane eFloorPlane
	{
		get
		{
			return default(AkFloorPlane);
		}
		set
		{
		}
	}

	public float fGameUnitsToMeters
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public uint uBankReadBufferSize
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public float fDebugOutOfRangeLimit
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool bDebugOutOfRangeCheckEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool bOfflineRendering
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	internal AkInitSettings(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkInitSettings obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkInitSettings()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}
}
