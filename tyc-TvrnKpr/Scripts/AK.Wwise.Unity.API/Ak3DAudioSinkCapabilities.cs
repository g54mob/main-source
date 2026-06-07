using System;

public class Ak3DAudioSinkCapabilities : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public AkChannelConfig channelConfig
	{
		get
		{
			return null;
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

	public uint uAvailableSystemAudioObjects
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public bool bPassthrough
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool bMultiChannelObjects
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	internal Ak3DAudioSinkCapabilities(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(Ak3DAudioSinkCapabilities obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~Ak3DAudioSinkCapabilities()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public Ak3DAudioSinkCapabilities()
	{
	}
}
