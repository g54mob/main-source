using System;

public class AkPositioningData : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public Ak3dData threeD
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public AkBehavioralPositioningData behavioral
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	internal AkPositioningData(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkPositioningData obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkPositioningData()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkPositioningData()
	{
	}
}
