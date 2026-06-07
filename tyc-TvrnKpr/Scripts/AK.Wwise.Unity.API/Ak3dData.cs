using System;

public class Ak3dData : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public AkTransform xform
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public float spread
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float focus
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public uint uEmitterChannelMask
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	internal Ak3dData(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(Ak3dData obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~Ak3dData()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public Ak3dData()
	{
	}
}
