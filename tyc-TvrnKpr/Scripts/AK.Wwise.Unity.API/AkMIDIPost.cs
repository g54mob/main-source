using System;
using UnityEngine;

public class AkMIDIPost : AkMIDIEvent
{
	private IntPtr swigCPtr;

	public ulong uOffset
	{
		get
		{
			return 0uL;
		}
		set
		{
		}
	}

	internal AkMIDIPost(IntPtr cPtr, bool cMemoryOwn)
		: base((IntPtr)0, cMemoryOwn: false)
	{
	}

	internal static IntPtr getCPtr(AkMIDIPost obj)
	{
		return (IntPtr)0;
	}

	internal override void setCPtr(IntPtr cPtr)
	{
	}

	protected override void Dispose(bool disposing)
	{
	}

	public uint PostOnEvent(uint in_eventID, ulong in_gameObjectID, uint in_uNumPosts)
	{
		return 0u;
	}

	public uint PostOnEvent(uint in_eventID, ulong in_gameObjectID, uint in_uNumPosts, bool in_bAbsoluteOffsets)
	{
		return 0u;
	}

	public uint PostOnEvent(uint in_eventID, ulong in_gameObjectID, uint in_uNumPosts, bool in_bAbsoluteOffsets, uint in_uFlags, AkCallbackManager.EventCallback in_pfnCallback, object in_pCookie)
	{
		return 0u;
	}

	public uint PostOnEvent(uint in_eventID, ulong in_gameObjectID, uint in_uNumPosts, bool in_bAbsoluteOffsets, uint in_uFlags, AkCallbackManager.EventCallback in_pfnCallback, object in_pCookie, uint in_playingID)
	{
		return 0u;
	}

	public uint PostOnEvent(uint in_eventID, GameObject in_gameObjectID, uint in_uNumPosts)
	{
		return 0u;
	}

	public uint PostOnEvent(uint in_eventID, GameObject in_gameObjectID, uint in_uNumPosts, bool in_bAbsoluteOffsets)
	{
		return 0u;
	}

	public uint PostOnEvent(uint in_eventID, GameObject in_gameObjectID, uint in_uNumPosts, bool in_bAbsoluteOffsets, uint in_uFlags, AkCallbackManager.EventCallback in_pfnCallback, object in_pCookie)
	{
		return 0u;
	}

	public uint PostOnEvent(uint in_eventID, GameObject in_gameObjectID, uint in_uNumPosts, bool in_bAbsoluteOffsets, uint in_uFlags, AkCallbackManager.EventCallback in_pfnCallback, object in_pCookie, uint in_playingID)
	{
		return 0u;
	}

	public void Clone(AkMIDIPost other)
	{
	}

	public static int GetSizeOf()
	{
		return 0;
	}

	public AkMIDIPost()
		: base((IntPtr)0, cMemoryOwn: false)
	{
	}
}
