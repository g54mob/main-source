using System;

public class AkTrivialStdMovePolicy : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	internal AkTrivialStdMovePolicy(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkTrivialStdMovePolicy obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkTrivialStdMovePolicy()
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

	public AkTrivialStdMovePolicy()
	{
	}
}
