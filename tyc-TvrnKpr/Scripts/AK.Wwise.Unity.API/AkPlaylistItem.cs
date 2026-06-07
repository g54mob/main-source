using System;

public class AkPlaylistItem : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public uint audioNodeID
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public int msDelay
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public IntPtr pCustomInfo
	{
		get
		{
			return (IntPtr)0;
		}
		set
		{
		}
	}

	internal AkPlaylistItem(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkPlaylistItem obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkPlaylistItem()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkPlaylistItem()
	{
	}

	public AkPlaylistItem(AkPlaylistItem in_rCopy)
	{
	}

	public AkPlaylistItem Assign(AkPlaylistItem in_rCopy)
	{
		return null;
	}

	public bool IsEqualTo(AkPlaylistItem in_rCopy)
	{
		return false;
	}

	public AKRESULT SetExternalSources(uint in_nExternalSrc, AkExternalSourceInfoArray in_pExternalSrc)
	{
		return default(AKRESULT);
	}
}
