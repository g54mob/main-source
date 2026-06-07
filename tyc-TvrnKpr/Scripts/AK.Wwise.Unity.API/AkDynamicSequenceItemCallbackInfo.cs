using System;

public class AkDynamicSequenceItemCallbackInfo : AkCallbackInfo
{
	private IntPtr swigCPtr;

	public uint playingID => 0u;

	public uint audioNodeID => 0u;

	public IntPtr pCustomInfo => (IntPtr)0;

	internal AkDynamicSequenceItemCallbackInfo(IntPtr cPtr, bool cMemoryOwn)
		: base((IntPtr)0, cMemoryOwn: false)
	{
	}

	internal static IntPtr getCPtr(AkDynamicSequenceItemCallbackInfo obj)
	{
		return (IntPtr)0;
	}

	internal override void setCPtr(IntPtr cPtr)
	{
	}

	protected override void Dispose(bool disposing)
	{
	}

	public AkDynamicSequenceItemCallbackInfo()
		: base((IntPtr)0, cMemoryOwn: false)
	{
	}
}
