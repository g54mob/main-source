using System;

public class AkExtent : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public float halfWidth
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float halfHeight
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float halfDepth
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	internal AkExtent(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkExtent obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkExtent()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkExtent()
	{
	}

	public AkExtent(float in_halfWidth, float in_halfHeight, float in_halfDepth)
	{
	}
}
