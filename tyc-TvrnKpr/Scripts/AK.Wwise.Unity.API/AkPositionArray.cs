using System;
using UnityEngine;

public class AkPositionArray : IDisposable
{
	public IntPtr m_Buffer;

	private IntPtr m_Current;

	private uint m_MaxCount;

	public uint Count { get; private set; }

	public AkPositionArray(uint in_Count)
	{
	}

	public void Dispose()
	{
	}

	~AkPositionArray()
	{
	}

	public void Reset()
	{
	}

	public void Add(AkVector64 in_Pos, Vector3 in_Forward, Vector3 in_Top)
	{
	}
}
