using System;

public class Ak3dData : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public AkTransform xform
	{
		get
		{
			IntPtr intPtr = AkSoundEnginePINVOKE.CSharp_Ak3dData_xform_get(swigCPtr);
			if (!(intPtr == IntPtr.Zero))
			{
				return new AkTransform(intPtr, cMemoryOwn: false);
			}
			return null;
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_Ak3dData_xform_set(swigCPtr, AkTransform.getCPtr(value));
		}
	}

	public float spread
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_Ak3dData_spread_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_Ak3dData_spread_set(swigCPtr, value);
		}
	}

	public float focus
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_Ak3dData_focus_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_Ak3dData_focus_set(swigCPtr, value);
		}
	}

	public uint uEmitterChannelMask
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_Ak3dData_uEmitterChannelMask_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_Ak3dData_uEmitterChannelMask_set(swigCPtr, value);
		}
	}

	internal Ak3dData(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = cPtr;
	}

	internal static IntPtr getCPtr(Ak3dData obj)
	{
		return obj?.swigCPtr ?? IntPtr.Zero;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
		Dispose();
		swigCPtr = cPtr;
	}

	~Ak3dData()
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
					AkSoundEnginePINVOKE.CSharp_delete_Ak3dData(swigCPtr);
				}
				swigCPtr = IntPtr.Zero;
			}
			GC.SuppressFinalize(this);
		}
	}

	public Ak3dData()
		: this(AkSoundEnginePINVOKE.CSharp_new_Ak3dData(), cMemoryOwn: true)
	{
	}
}
