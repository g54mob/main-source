using System;
using UnityEngine;

public class AkMIDIPost : AkMIDIEvent
{
	private IntPtr swigCPtr;

	public ulong uOffset
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkMIDIPost_uOffset_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkMIDIPost_uOffset_set(swigCPtr, value);
		}
	}

	internal AkMIDIPost(IntPtr cPtr, bool cMemoryOwn)
		: base(AkSoundEnginePINVOKE.CSharp_AkMIDIPost_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = cPtr;
	}

	internal static IntPtr getCPtr(AkMIDIPost obj)
	{
		return obj?.swigCPtr ?? IntPtr.Zero;
	}

	internal override void setCPtr(IntPtr cPtr)
	{
		base.setCPtr(AkSoundEnginePINVOKE.CSharp_AkMIDIPost_SWIGUpcast(cPtr));
		swigCPtr = cPtr;
	}

	protected override void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					AkSoundEnginePINVOKE.CSharp_delete_AkMIDIPost(swigCPtr);
				}
				swigCPtr = IntPtr.Zero;
			}
			GC.SuppressFinalize(this);
			base.Dispose(disposing);
		}
	}

	public uint PostOnEvent(uint in_eventID, ulong in_gameObjectID, uint in_uNumPosts)
	{
		uint num = AkSoundEnginePINVOKE.CSharp_AkMIDIPost_PostOnEvent__SWIG_0(swigCPtr, in_eventID, in_gameObjectID, in_uNumPosts);
		AkCallbackManager.SetLastAddedPlayingID(num);
		return num;
	}

	public uint PostOnEvent(uint in_eventID, ulong in_gameObjectID, uint in_uNumPosts, bool in_bAbsoluteOffsets)
	{
		uint num = AkSoundEnginePINVOKE.CSharp_AkMIDIPost_PostOnEvent__SWIG_1(swigCPtr, in_eventID, in_gameObjectID, in_uNumPosts, in_bAbsoluteOffsets);
		AkCallbackManager.SetLastAddedPlayingID(num);
		return num;
	}

	public uint PostOnEvent(uint in_eventID, ulong in_gameObjectID, uint in_uNumPosts, bool in_bAbsoluteOffsets, uint in_uFlags, AkCallbackManager.EventCallback in_pfnCallback, object in_pCookie)
	{
		in_pCookie = AkCallbackManager.EventCallbackPackage.Create(in_pfnCallback, in_pCookie, ref in_uFlags);
		uint num = AkSoundEnginePINVOKE.CSharp_AkMIDIPost_PostOnEvent__SWIG_2(swigCPtr, in_eventID, in_gameObjectID, in_uNumPosts, in_bAbsoluteOffsets, in_uFlags, (in_uFlags != 0) ? ((IntPtr)1) : IntPtr.Zero, (in_pCookie != null) ? ((IntPtr)in_pCookie.GetHashCode()) : IntPtr.Zero);
		AkCallbackManager.SetLastAddedPlayingID(num);
		return num;
	}

	public uint PostOnEvent(uint in_eventID, ulong in_gameObjectID, uint in_uNumPosts, bool in_bAbsoluteOffsets, uint in_uFlags, AkCallbackManager.EventCallback in_pfnCallback, object in_pCookie, uint in_playingID)
	{
		in_pCookie = AkCallbackManager.EventCallbackPackage.Create(in_pfnCallback, in_pCookie, ref in_uFlags);
		uint num = AkSoundEnginePINVOKE.CSharp_AkMIDIPost_PostOnEvent__SWIG_3(swigCPtr, in_eventID, in_gameObjectID, in_uNumPosts, in_bAbsoluteOffsets, in_uFlags, (in_uFlags != 0) ? ((IntPtr)1) : IntPtr.Zero, (in_pCookie != null) ? ((IntPtr)in_pCookie.GetHashCode()) : IntPtr.Zero, in_playingID);
		AkCallbackManager.SetLastAddedPlayingID(num);
		return num;
	}

	public uint PostOnEvent(uint in_eventID, GameObject in_gameObjectID, uint in_uNumPosts)
	{
		ulong akGameObjectID = AkSoundEngine.GetAkGameObjectID(in_gameObjectID);
		AkSoundEngine.PreGameObjectAPICall(in_gameObjectID, akGameObjectID);
		uint num = PostOnEvent(in_eventID, akGameObjectID, in_uNumPosts);
		AkCallbackManager.SetLastAddedPlayingID(num);
		return num;
	}

	public uint PostOnEvent(uint in_eventID, GameObject in_gameObjectID, uint in_uNumPosts, bool in_bAbsoluteOffsets)
	{
		ulong akGameObjectID = AkSoundEngine.GetAkGameObjectID(in_gameObjectID);
		AkSoundEngine.PreGameObjectAPICall(in_gameObjectID, akGameObjectID);
		uint num = PostOnEvent(in_eventID, akGameObjectID, in_uNumPosts, in_bAbsoluteOffsets);
		AkCallbackManager.SetLastAddedPlayingID(num);
		return num;
	}

	public uint PostOnEvent(uint in_eventID, GameObject in_gameObjectID, uint in_uNumPosts, bool in_bAbsoluteOffsets, uint in_uFlags, AkCallbackManager.EventCallback in_pfnCallback, object in_pCookie)
	{
		ulong akGameObjectID = AkSoundEngine.GetAkGameObjectID(in_gameObjectID);
		AkSoundEngine.PreGameObjectAPICall(in_gameObjectID, akGameObjectID);
		uint num = PostOnEvent(in_eventID, akGameObjectID, in_uNumPosts, in_bAbsoluteOffsets, in_uFlags, in_pfnCallback, in_pCookie);
		AkCallbackManager.SetLastAddedPlayingID(num);
		return num;
	}

	public uint PostOnEvent(uint in_eventID, GameObject in_gameObjectID, uint in_uNumPosts, bool in_bAbsoluteOffsets, uint in_uFlags, AkCallbackManager.EventCallback in_pfnCallback, object in_pCookie, uint in_playingID)
	{
		ulong akGameObjectID = AkSoundEngine.GetAkGameObjectID(in_gameObjectID);
		AkSoundEngine.PreGameObjectAPICall(in_gameObjectID, akGameObjectID);
		in_pCookie = AkCallbackManager.EventCallbackPackage.Create(in_pfnCallback, in_pCookie, ref in_uFlags);
		uint num = PostOnEvent(in_eventID, akGameObjectID, in_uNumPosts, in_bAbsoluteOffsets, in_uFlags, in_pfnCallback, in_pCookie, in_playingID);
		AkCallbackManager.SetLastAddedPlayingID(num);
		return num;
	}

	public void Clone(AkMIDIPost other)
	{
		AkSoundEnginePINVOKE.CSharp_AkMIDIPost_Clone(swigCPtr, getCPtr(other));
	}

	public static int GetSizeOf()
	{
		return AkSoundEnginePINVOKE.CSharp_AkMIDIPost_GetSizeOf();
	}

	public AkMIDIPost()
		: this(AkSoundEnginePINVOKE.CSharp_new_AkMIDIPost(), cMemoryOwn: true)
	{
	}
}
