using System;

public class AkMonitoringCallbackInfo : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public AkMonitorErrorCode errorCode => default(AkMonitorErrorCode);

	public AkMonitorErrorLevel errorLevel => default(AkMonitorErrorLevel);

	public uint playingID => 0u;

	public ulong gameObjID => 0uL;

	public string message => null;

	internal AkMonitoringCallbackInfo(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkMonitoringCallbackInfo obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkMonitoringCallbackInfo()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public AkMonitoringCallbackInfo()
	{
	}
}
