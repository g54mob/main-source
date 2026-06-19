using System;

[Serializable]
public struct GuidAsULongs : IEquatable<GuidAsULongs>
{
	public ulong m_low;

	public ulong m_high;

	public static GuidAsULongs FromAddress(DataBlockAddress address)
	{
		return new GuidAsULongs
		{
			m_low = (ulong)address.lowBits,
			m_high = (ulong)address.highBits
		};
	}

	public DataBlockAddress ToAddress()
	{
		return new DataBlockAddress((long)m_low, (long)m_high);
	}

	public bool Equals(GuidAsULongs other)
	{
		if (m_low == other.m_low)
		{
			return m_high == other.m_high;
		}
		return false;
	}
}
