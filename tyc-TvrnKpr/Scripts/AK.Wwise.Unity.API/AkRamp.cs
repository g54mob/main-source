using System;

public class AkRamp : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public float fPrev
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float fNext
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	internal AkRamp(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkRamp obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkRamp()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkRamp()
	{
	}

	public AkRamp(float in_fPrev, float in_fNext)
	{
	}
}
