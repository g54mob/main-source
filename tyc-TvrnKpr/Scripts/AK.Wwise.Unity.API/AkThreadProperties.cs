using System;

public class AkThreadProperties : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public int nPriority
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public uint dwAffinityMask
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uStackSize
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	internal AkThreadProperties(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkThreadProperties obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkThreadProperties()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkThreadProperties()
	{
	}
}
