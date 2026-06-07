using System;

public class AkCommunicationSettings : IDisposable
{
	public enum AkCommSystem
	{
		AkCommSystem_Socket = 0,
		AkCommSystem_HTCS = 1
	}

	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public uint uPoolSize
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public ushort uDiscoveryBroadcastPort
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public ushort uCommandPort
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public AkCommSystem commSystem
	{
		get
		{
			return default(AkCommSystem);
		}
		set
		{
		}
	}

	public bool bInitSystemLib
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public string szAppNetworkName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	internal AkCommunicationSettings(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkCommunicationSettings obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkCommunicationSettings()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkCommunicationSettings()
	{
	}
}
