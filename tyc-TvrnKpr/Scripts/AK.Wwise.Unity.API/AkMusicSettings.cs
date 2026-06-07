using System;

public class AkMusicSettings : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public float fStreamingLookAheadRatio
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	internal AkMusicSettings(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkMusicSettings obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkMusicSettings()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}
}
