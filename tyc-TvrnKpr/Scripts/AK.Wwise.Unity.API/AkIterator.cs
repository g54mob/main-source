using System;

public class AkIterator : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public AkPlaylistItem pItem
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	internal AkIterator(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkIterator obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkIterator()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkIterator NextIter()
	{
		return null;
	}

	public AkIterator PrevIter()
	{
		return null;
	}

	public AkPlaylistItem GetItem()
	{
		return null;
	}

	public bool IsEqualTo(AkIterator in_rOp)
	{
		return false;
	}

	public bool IsDifferentFrom(AkIterator in_rOp)
	{
		return false;
	}

	public AkIterator()
	{
	}
}
