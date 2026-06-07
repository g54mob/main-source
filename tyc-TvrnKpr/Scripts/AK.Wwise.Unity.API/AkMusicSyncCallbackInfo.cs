using System;

public class AkMusicSyncCallbackInfo : AkCallbackInfo
{
	private IntPtr swigCPtr;

	public uint playingID => 0u;

	public int segmentInfo_iCurrentPosition => 0;

	public int segmentInfo_iPreEntryDuration => 0;

	public int segmentInfo_iActiveDuration => 0;

	public int segmentInfo_iPostExitDuration => 0;

	public int segmentInfo_iRemainingLookAheadTime => 0;

	public float segmentInfo_fBeatDuration => 0f;

	public float segmentInfo_fBarDuration => 0f;

	public float segmentInfo_fGridDuration => 0f;

	public float segmentInfo_fGridOffset => 0f;

	public AkCallbackType musicSyncType => default(AkCallbackType);

	public string userCueName => null;

	internal AkMusicSyncCallbackInfo(IntPtr cPtr, bool cMemoryOwn)
		: base((IntPtr)0, cMemoryOwn: false)
	{
	}

	internal static IntPtr getCPtr(AkMusicSyncCallbackInfo obj)
	{
		return (IntPtr)0;
	}

	internal override void setCPtr(IntPtr cPtr)
	{
	}

	protected override void Dispose(bool disposing)
	{
	}

	public AkMusicSyncCallbackInfo()
		: base((IntPtr)0, cMemoryOwn: false)
	{
	}
}
