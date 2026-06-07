using System;

public class AkDurationCallbackInfo : AkEventCallbackInfo
{
	private IntPtr swigCPtr;

	public float fDuration => 0f;

	public float fEstimatedDuration => 0f;

	public uint audioNodeID => 0u;

	public uint mediaID => 0u;

	public bool bStreaming => false;

	internal AkDurationCallbackInfo(IntPtr cPtr, bool cMemoryOwn)
		: base((IntPtr)0, cMemoryOwn: false)
	{
	}

	internal static IntPtr getCPtr(AkDurationCallbackInfo obj)
	{
		return (IntPtr)0;
	}

	internal override void setCPtr(IntPtr cPtr)
	{
	}

	protected override void Dispose(bool disposing)
	{
	}

	public AkDurationCallbackInfo()
		: base((IntPtr)0, cMemoryOwn: false)
	{
	}
}
