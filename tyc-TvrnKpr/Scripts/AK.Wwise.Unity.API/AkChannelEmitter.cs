using System;

public class AkChannelEmitter : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public AkWorldTransform position
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public uint uInputChannels
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public string padding
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	internal AkChannelEmitter(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkChannelEmitter obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkChannelEmitter()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}
}
