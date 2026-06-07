using System;

public class AkPlatformInitSettings : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public AkThreadProperties threadLEngine
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public AkThreadProperties threadOutputMgr
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public AkThreadProperties threadBankManager
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public AkThreadProperties threadMonitor
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public ushort uNumRefillsInVoice
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public uint uSampleRate
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public bool bEnableAvxSupport
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public uint uMaxSystemAudioObjects
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	internal AkPlatformInitSettings(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkPlatformInitSettings obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkPlatformInitSettings()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}
}
