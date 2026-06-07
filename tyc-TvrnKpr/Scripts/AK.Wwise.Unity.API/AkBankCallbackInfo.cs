using System;

public class AkBankCallbackInfo : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public uint bankID => 0u;

	public IntPtr inMemoryBankPtr => (IntPtr)0;

	public AKRESULT loadResult => default(AKRESULT);

	internal AkBankCallbackInfo(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkBankCallbackInfo obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkBankCallbackInfo()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkBankCallbackInfo()
	{
	}
}
