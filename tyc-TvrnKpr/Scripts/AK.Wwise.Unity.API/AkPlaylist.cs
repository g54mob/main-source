using System;

public class AkPlaylist : AkPlaylistArray
{
	private IntPtr swigCPtr;

	internal AkPlaylist(IntPtr cPtr, bool cMemoryOwn)
		: base((IntPtr)0, cMemoryOwn: false)
	{
	}

	internal static IntPtr getCPtr(AkPlaylist obj)
	{
		return (IntPtr)0;
	}

	internal override void setCPtr(IntPtr cPtr)
	{
	}

	protected override void Dispose(bool disposing)
	{
	}

	public AKRESULT Enqueue(uint in_audioNodeID, int in_msDelay, IntPtr in_pCustomInfo, uint in_cExternals, AkExternalSourceInfoArray in_pExternalSources)
	{
		return default(AKRESULT);
	}

	public AKRESULT Enqueue(uint in_audioNodeID, int in_msDelay, IntPtr in_pCustomInfo, uint in_cExternals)
	{
		return default(AKRESULT);
	}

	public AKRESULT Enqueue(uint in_audioNodeID, int in_msDelay, IntPtr in_pCustomInfo)
	{
		return default(AKRESULT);
	}

	public AKRESULT Enqueue(uint in_audioNodeID, int in_msDelay)
	{
		return default(AKRESULT);
	}

	public AKRESULT Enqueue(uint in_audioNodeID)
	{
		return default(AKRESULT);
	}

	public AkPlaylist()
		: base((IntPtr)0, cMemoryOwn: false)
	{
	}
}
