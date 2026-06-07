using System;

public class AkAudioFormat : IDisposable
{
	private IntPtr swigCPtr;

	protected bool swigCMemOwn;

	public uint uSampleRate
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public AkChannelConfig channelConfig
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public uint uBitsPerSample
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uBlockAlign
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uTypeID
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	public uint uInterleaveID
	{
		get
		{
			return 0u;
		}
		set
		{
		}
	}

	internal AkAudioFormat(IntPtr cPtr, bool cMemoryOwn)
	{
	}

	internal static IntPtr getCPtr(AkAudioFormat obj)
	{
		return (IntPtr)0;
	}

	internal virtual void setCPtr(IntPtr cPtr)
	{
	}

	~AkAudioFormat()
	{
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public uint GetNumChannels()
	{
		return 0u;
	}

	public uint GetBitsPerSample()
	{
		return 0u;
	}

	public uint GetBlockAlign()
	{
		return 0u;
	}

	public uint GetTypeID()
	{
		return 0u;
	}

	public uint GetInterleaveID()
	{
		return 0u;
	}

	public void SetAll(uint in_uSampleRate, AkChannelConfig in_channelConfig, uint in_uBitsPerSample, uint in_uBlockAlign, uint in_uTypeID, uint in_uInterleaveID)
	{
	}

	public AkAudioFormat()
	{
	}
}
