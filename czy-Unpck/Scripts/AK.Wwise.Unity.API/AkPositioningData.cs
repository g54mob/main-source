using System;

public class AkPositioningData : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public Ak3dData threeD
	{
		get
		{
			IntPtr intPtr = AkSoundEnginePINVOKE.CSharp_AkPositioningData_threeD_get(swigCPtr);
			if (!(intPtr == IntPtr.Zero))
			{
				return new Ak3dData(intPtr, cMemoryOwn: false);
			}
			return null;
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkPositioningData_threeD_set(swigCPtr, Ak3dData.getCPtr(value));
		}
	}

	public AkBehavioralPositioningData behavioral
	{
		get
		{
			IntPtr intPtr = AkSoundEnginePINVOKE.CSharp_AkPositioningData_behavioral_get(swigCPtr);
			if (!(intPtr == IntPtr.Zero))
			{
				return new AkBehavioralPositioningData(intPtr, cMemoryOwn: false);
			}
			return null;
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkPositioningData_behavioral_set(swigCPtr, AkBehavioralPositioningData.getCPtr(value));
		}
	}

	internal AkPositioningData(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = cPtr;
	}

	internal static IntPtr getCPtr(AkPositioningData obj)
	{
		return obj?.swigCPtr ?? IntPtr.Zero;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
		Dispose();
		swigCPtr = cPtr;
	}

	~AkPositioningData()
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
					AkSoundEnginePINVOKE.CSharp_delete_AkPositioningData(swigCPtr);
				}
				swigCPtr = IntPtr.Zero;
			}
			GC.SuppressFinalize(this);
		}
	}

	public AkPositioningData()
		: this(AkSoundEnginePINVOKE.CSharp_new_AkPositioningData(), cMemoryOwn: true)
	{
	}
}
