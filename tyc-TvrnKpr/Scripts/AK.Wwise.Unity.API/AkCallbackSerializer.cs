using System;

public class AkCallbackSerializer : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	internal AkCallbackSerializer(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkCallbackSerializer obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkCallbackSerializer()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public static AKRESULT Init()
	{
		return default(AKRESULT);
	}

	public static void Term()
	{
	}

	public static IntPtr Lock()
	{
		return (IntPtr)0;
	}

	public static void Unlock()
	{
	}

	public static void SetLocalOutput(uint in_uErrorLevel, string in_ip, uint in_port, string in_xmlFilePath, uint in_msXmlTranslatorTimeout, uint in_msWaapiTranslatorTimeout)
	{
	}

	public static void FreeXmlTranslatorHandle(string in_xmlFilePath, uint in_msXmlTranslatorTimeout)
	{
	}

	public static AKRESULT AudioSourceChangeCallbackFunc(bool in_bOtherAudioPlaying, object in_pCookie)
	{
		return default(AKRESULT);
	}

	public AkCallbackSerializer()
	{
	}
}
