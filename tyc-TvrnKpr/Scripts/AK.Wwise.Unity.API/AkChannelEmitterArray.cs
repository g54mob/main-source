using System;
using UnityEngine;

public class AkChannelEmitterArray : IDisposable
{
	public IntPtr m_Buffer;

	private IntPtr m_Current;

	private uint m_MaxCount;

	public uint Count { get; private set; }

	public AkChannelEmitterArray(uint in_Count)
	{
	}

	public void Dispose()
	{
	}

	~AkChannelEmitterArray()
	{
	}

	public void Reset()
	{
	}

	public void Add(AkVector64 in_Pos, Vector3 in_Forward, Vector3 in_Top, uint in_ChannelMask)
	{
	}
}
