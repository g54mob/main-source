using System;

public class MsgContext : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public uint in_playingID
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public ulong in_gameObjID
	{
		get
		{
			return 0uL;
		}
		set
		{
		}
	}

	public uint in_soundID
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public bool in_bIsBus
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	internal MsgContext(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(MsgContext obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~MsgContext()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public MsgContext(uint pId, ulong goId, uint nodeId, bool isBus)
	{
	}

	public MsgContext(uint pId, ulong goId, uint nodeId)
	{
	}

	public MsgContext(uint pId, ulong goId)
	{
	}

	public MsgContext(uint pId)
	{
	}

	public MsgContext()
	{
	}
}
