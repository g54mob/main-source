using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

[Serializable]
[StructLayout(LayoutKind.Explicit)]
public struct DataBlockAddress : IComparable, IComparable<DataBlockAddress>, IEquatable<DataBlockAddress>
{
	[FieldOffset(0)]
	private Guid m_guid;

	[FieldOffset(0)]
	[SerializeField]
	[HideInInspector]
	private long m_low;

	[FieldOffset(8)]
	[SerializeField]
	[HideInInspector]
	private long m_high;

	public static DataBlockAddress Empty => new DataBlockAddress
	{
		m_guid = Guid.Empty
	};

	public Guid guid
	{
		get
		{
			return m_guid;
		}
		set
		{
			m_low = (m_high = 0L);
			m_guid = value;
		}
	}

	public long lowBits => m_low;

	public long highBits => m_high;

	public static DataBlockAddress NewAddress()
	{
		return Guid.NewGuid();
	}

	public static DataBlockAddress Parse(string input)
	{
		return Guid.Parse(input);
	}

	public static bool TryParse(string input, out DataBlockAddress result)
	{
		Guid result3;
		bool result2 = Guid.TryParse(input, out result3);
		result = result3;
		return result2;
	}

	public DataBlockAddress(long low, long high)
	{
		m_guid = Guid.Empty;
		m_low = low;
		m_high = high;
	}

	public DataBlockAddress(Guid guid)
	{
		m_low = (m_high = 0L);
		m_guid = guid;
	}

	public DataBlockAddress(string addressGuid)
	{
		m_low = (m_high = 0L);
		m_guid = Guid.Parse(addressGuid);
	}

	public static implicit operator Guid(DataBlockAddress sg)
	{
		return sg.m_guid;
	}

	public static implicit operator DataBlockAddress(Guid guid)
	{
		return new DataBlockAddress
		{
			m_guid = guid
		};
	}

	public static bool operator ==(DataBlockAddress a, DataBlockAddress b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(DataBlockAddress a, DataBlockAddress b)
	{
		return !a.Equals(b);
	}

	public static bool operator ==(DataBlockAddress a, Guid b)
	{
		return a.guid.Equals(b);
	}

	public static bool operator !=(DataBlockAddress a, Guid b)
	{
		return !a.guid.Equals(b);
	}

	public static bool operator ==(Guid a, DataBlockAddress b)
	{
		return b.guid.Equals(a);
	}

	public static bool operator !=(Guid a, DataBlockAddress b)
	{
		return !b.guid.Equals(a);
	}

	public int CompareTo(DataBlockAddress other)
	{
		return m_guid.CompareTo(other);
	}

	public int CompareTo(object obj)
	{
		return m_guid.CompareTo(obj);
	}

	public override bool Equals(object obj)
	{
		if (obj is DataBlockAddress dataBlockAddress)
		{
			return m_guid.Equals(dataBlockAddress.m_guid);
		}
		return false;
	}

	public bool Equals(DataBlockAddress other)
	{
		return m_guid.Equals(other);
	}

	public override int GetHashCode()
	{
		return m_guid.GetHashCode();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override string ToString()
	{
		return guid.ToString();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public string ToString(string format)
	{
		return guid.ToString(format);
	}
}
