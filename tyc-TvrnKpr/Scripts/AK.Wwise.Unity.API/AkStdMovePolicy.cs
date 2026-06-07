using System;

public class AkStdMovePolicy : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	internal AkStdMovePolicy(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkStdMovePolicy obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkStdMovePolicy()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public static bool IsTrivial()
	{
		return false;
	}

	public AkStdMovePolicy()
	{
	}
}
