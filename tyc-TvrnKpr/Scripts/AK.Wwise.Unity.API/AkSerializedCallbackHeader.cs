using System;

public class AkSerializedCallbackHeader : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public IntPtr pPackage => (IntPtr)0;

	public uint eType => 0u;

	public AkSerializedCallbackHeader pNext => null;

	internal AkSerializedCallbackHeader(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkSerializedCallbackHeader obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkSerializedCallbackHeader()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public IntPtr GetData()
	{
		return (IntPtr)0;
	}

	public AkSerializedCallbackHeader()
	{
	}
}
