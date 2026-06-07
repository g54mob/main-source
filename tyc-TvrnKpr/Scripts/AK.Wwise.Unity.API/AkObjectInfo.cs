using System;

public class AkObjectInfo : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public uint objID
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint parentID
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public int iDepth
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	internal AkObjectInfo(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkObjectInfo obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkObjectInfo()
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

	public void Clone(AkObjectInfo other)
	{
	}

	public AkObjectInfo()
	{
	}
}
