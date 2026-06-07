using System;

public class AkSourceSettings : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public uint sourceID
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public IntPtr pMediaMemory
	{
		get
		{
			return (IntPtr)0;
		}
		set
		{
		}
	}

	public uint uMediaSize
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	internal AkSourceSettings(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkSourceSettings obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkSourceSettings()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public void Clear()
	{
	}

	public static int GetSizeOf()
	{
		return 0;
	}

	public void Clone(AkSourceSettings other)
	{
	}

	public AkSourceSettings()
	{
	}
}
