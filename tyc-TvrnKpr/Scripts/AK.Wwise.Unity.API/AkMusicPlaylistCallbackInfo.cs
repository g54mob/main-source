using System;

public class AkMusicPlaylistCallbackInfo : AkEventCallbackInfo
{
	private IntPtr swigCPtr;

	public uint playlistID => 0u;

	public uint uNumPlaylistItems => 0u;

	public uint uPlaylistSelection => 0u;

	public uint uPlaylistItemDone => 0u;

	internal AkMusicPlaylistCallbackInfo(IntPtr cPtr, bool cMemoryOwn)
		: base((IntPtr)0, cMemoryOwn: false)
	{
	}

	internal static IntPtr getCPtr(AkMusicPlaylistCallbackInfo obj)
	{
		return (IntPtr)0;
	}

	internal override void setCPtr(IntPtr cPtr)
	{
	}

	protected override void Dispose(bool disposing)
	{
	}

	public AkMusicPlaylistCallbackInfo()
		: base((IntPtr)0, cMemoryOwn: false)
	{
	}
}
