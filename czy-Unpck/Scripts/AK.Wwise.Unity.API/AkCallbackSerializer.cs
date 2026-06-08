using System;

public class AkCallbackSerializer : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	internal AkCallbackSerializer(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = cPtr;
	}

	internal static IntPtr getCPtr(AkCallbackSerializer obj)
	{
		return obj?.swigCPtr ?? IntPtr.Zero;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
		Dispose();
		swigCPtr = cPtr;
	}

	~AkCallbackSerializer()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					AkSoundEnginePINVOKE.CSharp_delete_AkCallbackSerializer(swigCPtr);
				}
				swigCPtr = IntPtr.Zero;
			}
			GC.SuppressFinalize(this);
		}
	}

	public static AKRESULT Init()
	{
		return (AKRESULT)AkSoundEnginePINVOKE.CSharp_AkCallbackSerializer_Init();
	}

	public static void Term()
	{
		AkSoundEnginePINVOKE.CSharp_AkCallbackSerializer_Term();
	}

	public static IntPtr Lock()
	{
		return AkSoundEnginePINVOKE.CSharp_AkCallbackSerializer_Lock();
	}

	public static void Unlock()
	{
		AkSoundEnginePINVOKE.CSharp_AkCallbackSerializer_Unlock();
	}

	public static void SetLocalOutput(uint in_uErrorLevel)
	{
		AkSoundEnginePINVOKE.CSharp_AkCallbackSerializer_SetLocalOutput(in_uErrorLevel);
	}

	public static AKRESULT AudioSourceChangeCallbackFunc(bool in_bOtherAudioPlaying, object in_pCookie)
	{
		return (AKRESULT)AkSoundEnginePINVOKE.CSharp_AkCallbackSerializer_AudioSourceChangeCallbackFunc(in_bOtherAudioPlaying, (in_pCookie != null) ? ((IntPtr)in_pCookie.GetHashCode()) : IntPtr.Zero);
	}

	public AkCallbackSerializer()
		: this(AkSoundEnginePINVOKE.CSharp_new_AkCallbackSerializer(), cMemoryOwn: true)
	{
	}
}
