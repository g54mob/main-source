using System;

public class AkEventCallbackInfo : AkCallbackInfo
{
	private IntPtr swigCPtr;

	public uint playingID => 0u;

	public uint eventID => 0u;

	internal AkEventCallbackInfo(IntPtr cPtr, bool cMemoryOwn)
		: base((IntPtr)0, cMemoryOwn: false)
	{
	}

	internal static IntPtr getCPtr(AkEventCallbackInfo obj)
	{
		return (IntPtr)0;
	}

	internal override void setCPtr(IntPtr cPtr)
	{
	}

	protected override void Dispose(bool disposing)
	{
	}

	public AkEventCallbackInfo()
		: base((IntPtr)0, cMemoryOwn: false)
	{
	}
}
