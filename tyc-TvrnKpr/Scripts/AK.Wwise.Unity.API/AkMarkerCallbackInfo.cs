using System;

public class AkMarkerCallbackInfo : AkEventCallbackInfo
{
	private IntPtr swigCPtr;

	public uint uIdentifier => 0u;

	public uint uPosition => 0u;

	public string strLabel => null;

	internal AkMarkerCallbackInfo(IntPtr cPtr, bool cMemoryOwn)
		: base((IntPtr)0, cMemoryOwn: false)
	{
	}

	internal static IntPtr getCPtr(AkMarkerCallbackInfo obj)
	{
		return (IntPtr)0;
	}

	internal override void setCPtr(IntPtr cPtr)
	{
	}

	protected override void Dispose(bool disposing)
	{
	}

	public AkMarkerCallbackInfo()
		: base((IntPtr)0, cMemoryOwn: false)
	{
	}
}
