using System;

public class AkDeviceSettings : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public IntPtr pIOMemory
	{
		get
		{
			return (IntPtr)0;
		}
		set
		{
		}
	}

	public uint uIOMemorySize
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uIOMemoryAlignment
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint ePoolAttributes
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uGranularity
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public AkThreadProperties threadProperties
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public float fTargetAutoStmBufferLength
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public uint uMaxConcurrentIO
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public bool bUseStreamCache
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public uint uMaxCachePinnedBytes
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	internal AkDeviceSettings(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkDeviceSettings obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkDeviceSettings()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}
}
