using System;

public class AkMIDIEventCallbackInfo : AkEventCallbackInfo
{
	private IntPtr swigCPtr;

	public byte byChan => 0;

	public byte byParam1 => 0;

	public byte byParam2 => 0;

	public AkMIDIEventTypes byType => default(AkMIDIEventTypes);

	public byte byOnOffNote => 0;

	public byte byVelocity => 0;

	public AkMIDICcTypes byCc => default(AkMIDICcTypes);

	public byte byCcValue => 0;

	public byte byValueLsb => 0;

	public byte byValueMsb => 0;

	public byte byAftertouchNote => 0;

	public byte byNoteAftertouchValue => 0;

	public byte byChanAftertouchValue => 0;

	public byte byProgramNum => 0;

	internal AkMIDIEventCallbackInfo(IntPtr cPtr, bool cMemoryOwn)
		: base((IntPtr)0, cMemoryOwn: false)
	{
	}

	internal static IntPtr getCPtr(AkMIDIEventCallbackInfo obj)
	{
		return (IntPtr)0;
	}

	internal override void setCPtr(IntPtr cPtr)
	{
	}

	protected override void Dispose(bool disposing)
	{
	}

	public AkMIDIEventCallbackInfo()
		: base((IntPtr)0, cMemoryOwn: false)
	{
	}
}
