using System;

public class AkAudioSettings : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

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

	public uint uNumSamplesPerSecond
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	internal AkAudioSettings(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkAudioSettings obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkAudioSettings()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkAudioSettings()
	{
	}
}
