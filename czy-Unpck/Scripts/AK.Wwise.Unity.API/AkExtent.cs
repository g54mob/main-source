using System;

public class AkExtent : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public float halfWidth
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkExtent_halfWidth_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkExtent_halfWidth_set(swigCPtr, value);
		}
	}

	public float halfHeight
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkExtent_halfHeight_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkExtent_halfHeight_set(swigCPtr, value);
		}
	}

	public float halfDepth
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_AkExtent_halfDepth_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_AkExtent_halfDepth_set(swigCPtr, value);
		}
	}

	internal AkExtent(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = cPtr;
	}

	internal static IntPtr getCPtr(AkExtent obj)
	{
		return obj?.swigCPtr ?? IntPtr.Zero;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
		Dispose();
		swigCPtr = cPtr;
	}

	~AkExtent()
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
					AkSoundEnginePINVOKE.CSharp_delete_AkExtent(swigCPtr);
				}
				swigCPtr = IntPtr.Zero;
			}
			GC.SuppressFinalize(this);
		}
	}

	public AkExtent()
		: this(AkSoundEnginePINVOKE.CSharp_new_AkExtent__SWIG_0(), cMemoryOwn: true)
	{
	}

	public AkExtent(float in_halfWidth, float in_halfHeight, float in_halfDepth)
		: this(AkSoundEnginePINVOKE.CSharp_new_AkExtent__SWIG_1(in_halfWidth, in_halfHeight, in_halfDepth), cMemoryOwn: true)
	{
	}
}
