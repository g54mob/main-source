using System;

public class AkDeviceDescription : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public uint idDevice
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public string deviceName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public AkAudioDeviceState deviceStateMask
	{
		get
		{
			return default(AkAudioDeviceState);
		}
		set
		{
		}
	}

	public bool isDefaultDevice
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	internal AkDeviceDescription(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkDeviceDescription obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkDeviceDescription()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public void Clear()
	{
	}

	public static int GetSizeOf()
	{
		return 0;
	}

	public void Clone(AkDeviceDescription other)
	{
	}

	public AkDeviceDescription()
	{
	}
}
