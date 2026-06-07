using System;

public class AkExternalSourceInfo : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public uint iExternalSrcCookie
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint idCodec
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public string szFile
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public IntPtr pInMemory
	{
		get
		{
			return (IntPtr)0;
		}
		set
		{
		}
	}

	public uint uiMemorySize
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint idFile
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	internal AkExternalSourceInfo(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkExternalSourceInfo obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkExternalSourceInfo()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkExternalSourceInfo()
	{
	}

	public AkExternalSourceInfo(IntPtr in_pInMemory, uint in_uiMemorySize, uint in_iExternalSrcCookie, uint in_idCodec)
	{
	}

	public AkExternalSourceInfo(string in_pszFileName, uint in_iExternalSrcCookie, uint in_idCodec)
	{
	}

	public AkExternalSourceInfo(uint in_idFile, uint in_iExternalSrcCookie, uint in_idCodec)
	{
	}

	public void Clear()
	{
	}

	public void Clone(AkExternalSourceInfo other)
	{
	}

	public static int GetSizeOf()
	{
		return 0;
	}
}
