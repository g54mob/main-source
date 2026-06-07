using System;

public class AkSegmentInfo : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public int iCurrentPosition
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int iPreEntryDuration
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int iActiveDuration
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int iPostExitDuration
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int iRemainingLookAheadTime
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public float fBeatDuration
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float fBarDuration
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float fGridDuration
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float fGridOffset
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	internal AkSegmentInfo(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkSegmentInfo obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkSegmentInfo()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkSegmentInfo()
	{
	}
}
