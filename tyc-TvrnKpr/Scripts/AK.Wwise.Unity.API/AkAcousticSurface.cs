using System;

public class AkAcousticSurface : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public uint textureID
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public float transmissionLoss
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public string strName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	internal AkAcousticSurface(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkAcousticSurface obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkAcousticSurface()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkAcousticSurface()
	{
	}

	public void Clear()
	{
	}

	public void DeleteName()
	{
	}

	public static int GetSizeOf()
	{
		return 0;
	}

	public void Clone(AkAcousticSurface other)
	{
	}
}
