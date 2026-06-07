using System;

public class AkInitializationSettings : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public AkStreamMgrSettings streamMgrSettings
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public AkDeviceSettings deviceSettings
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public AkInitSettings initSettings
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public AkPlatformInitSettings platformSettings
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public AkMusicSettings musicSettings
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public uint uMemoryPrimarySbaInitSize
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uMemoryPrimaryTlsfInitSize
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uMemoryPrimaryTlsfSpanSize
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uMemoryPrimaryAllocSizeHuge
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uMemoryPrimaryReservedLimit
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uMemoryMediaTlsfInitSize
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uMemoryMediaTlsfSpanSize
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uMemoryMediaAllocSizeHuge
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uMemoryMediaReservedLimit
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uMemDebugLevel
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public bool bUseSubFoldersForGeneratedFiles
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	internal AkInitializationSettings(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkInitializationSettings obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkInitializationSettings()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkInitializationSettings()
	{
	}
}
