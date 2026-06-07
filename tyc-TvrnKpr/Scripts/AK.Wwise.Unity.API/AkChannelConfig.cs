using System;

public class AkChannelConfig : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public uint uNumChannels
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint eConfigType
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uChannelMask
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	internal AkChannelConfig(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkChannelConfig obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkChannelConfig()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public static AkChannelConfig Standard(uint in_uChannelMask)
	{
		return null;
	}

	public static AkChannelConfig Anonymous(uint in_uNumChannels)
	{
		return null;
	}

	public static AkChannelConfig Ambisonic(uint in_uNumChannels)
	{
		return null;
	}

	public static AkChannelConfig Object()
	{
		return null;
	}

	public AkChannelConfig()
	{
	}

	public AkChannelConfig(uint in_uNumChannels, uint in_uChannelMask)
	{
	}

	public void Clear()
	{
	}

	public void SetStandard(uint in_uChannelMask)
	{
	}

	public void SetStandardOrAnonymous(uint in_uNumChannels, uint in_uChannelMask)
	{
	}

	public void SetAnonymous(uint in_uNumChannels)
	{
	}

	public void SetAmbisonic(uint in_uNumChannels)
	{
	}

	public void SetObject()
	{
	}

	public void SetSameAsMainMix()
	{
	}

	public void SetSameAsPassthrough()
	{
	}

	public bool IsValid()
	{
		return false;
	}

	public uint Serialize()
	{
		return 0u;
	}

	public void Deserialize(uint in_uChannelConfig)
	{
	}

	public AkChannelConfig RemoveLFE()
	{
		return null;
	}

	public AkChannelConfig RemoveCenter()
	{
		return null;
	}
}
