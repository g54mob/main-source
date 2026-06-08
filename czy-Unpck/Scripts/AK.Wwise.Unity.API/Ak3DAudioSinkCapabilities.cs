using System;

public class Ak3DAudioSinkCapabilities : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public AkChannelConfig channelConfig
	{
		get
		{
			IntPtr intPtr = AkSoundEnginePINVOKE.CSharp_Ak3DAudioSinkCapabilities_channelConfig_get(swigCPtr);
			if (!(intPtr == IntPtr.Zero))
			{
				return new AkChannelConfig(intPtr, cMemoryOwn: false);
			}
			return null;
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_Ak3DAudioSinkCapabilities_channelConfig_set(swigCPtr, AkChannelConfig.getCPtr(value));
		}
	}

	public uint uMaxSystemAudioObjects
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_Ak3DAudioSinkCapabilities_uMaxSystemAudioObjects_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_Ak3DAudioSinkCapabilities_uMaxSystemAudioObjects_set(swigCPtr, value);
		}
	}

	public uint uAvailableSystemAudioObjects
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_Ak3DAudioSinkCapabilities_uAvailableSystemAudioObjects_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_Ak3DAudioSinkCapabilities_uAvailableSystemAudioObjects_set(swigCPtr, value);
		}
	}

	public bool bPassthrough
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_Ak3DAudioSinkCapabilities_bPassthrough_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_Ak3DAudioSinkCapabilities_bPassthrough_set(swigCPtr, value);
		}
	}

	public bool bMultiChannelObjects
	{
		get
		{
			return AkSoundEnginePINVOKE.CSharp_Ak3DAudioSinkCapabilities_bMultiChannelObjects_get(swigCPtr);
		}
		set
		{
			AkSoundEnginePINVOKE.CSharp_Ak3DAudioSinkCapabilities_bMultiChannelObjects_set(swigCPtr, value);
		}
	}

	internal Ak3DAudioSinkCapabilities(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = cPtr;
	}

	internal static IntPtr getCPtr(Ak3DAudioSinkCapabilities obj)
	{
		return obj?.swigCPtr ?? IntPtr.Zero;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
		Dispose();
		swigCPtr = cPtr;
	}

	~Ak3DAudioSinkCapabilities()
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
					AkSoundEnginePINVOKE.CSharp_delete_Ak3DAudioSinkCapabilities(swigCPtr);
				}
				swigCPtr = IntPtr.Zero;
			}
			GC.SuppressFinalize(this);
		}
	}

	public Ak3DAudioSinkCapabilities()
		: this(AkSoundEnginePINVOKE.CSharp_new_Ak3DAudioSinkCapabilities(), cMemoryOwn: true)
	{
	}
}
