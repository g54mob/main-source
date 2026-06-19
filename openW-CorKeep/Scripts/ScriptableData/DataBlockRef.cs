using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UnityEngine;

[Serializable]
public struct DataBlockRef<T> : IComparable, IComparable<DataBlockRef<T>>, IEquatable<DataBlockRef<T>> where T : ScriptableDataBlock
{
	[SerializeField]
	private DataBlockAddress m_address;

	private T m_cachedDataBlock;

	private DataBlockAddress m_cachedDataBlockAddress;

	[NonSerialized]
	private int m_cachedLoadID;

	public DataBlockAddress address => m_address;

	public bool hasAddress
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return m_address.guid != Guid.Empty;
		}
	}

	private bool m_cacheIsUpToDate
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (m_cachedLoadID == ScriptableData.globalLoadID)
			{
				return m_cachedDataBlockAddress == m_address;
			}
			return false;
		}
	}

	[JsonConstructor]
	public DataBlockRef(DataBlockAddress address)
	{
		m_address = address;
		m_cachedDataBlock = null;
		m_cachedDataBlockAddress = DataBlockAddress.Empty;
		m_cachedLoadID = 0;
	}

	public DataBlockRef(string addressGuid)
	{
		m_address = new DataBlockAddress(addressGuid);
		m_cachedDataBlock = null;
		m_cachedDataBlockAddress = DataBlockAddress.Empty;
		m_cachedLoadID = 0;
	}

	public static implicit operator DataBlockRef<T>(DataBlockAddress address)
	{
		return new DataBlockRef<T>(address);
	}

	public static implicit operator DataBlockRef<T>(T dataBlock)
	{
		return new DataBlockRef<T>(dataBlock ? dataBlock.address : DataBlockAddress.Empty);
	}

	public static implicit operator DataBlockAddress(DataBlockRef<T> dataBlockRef)
	{
		return dataBlockRef.address;
	}

	public static bool operator ==(DataBlockRef<T> a, DataBlockRef<T> b)
	{
		return a.m_address == b.m_address;
	}

	public static bool operator !=(DataBlockRef<T> a, DataBlockRef<T> b)
	{
		return a.m_address != b.m_address;
	}

	public int CompareTo(DataBlockRef<T> other)
	{
		return m_address.CompareTo(other.m_address);
	}

	public int CompareTo(object obj)
	{
		return m_address.CompareTo(obj);
	}

	public bool Equals(DataBlockRef<T> other)
	{
		return other.address == m_address;
	}

	public override bool Equals(object obj)
	{
		if (obj is DataBlockRef<T> dataBlockRef)
		{
			return EqualityComparer<DataBlockAddress>.Default.Equals(m_address, dataBlockRef.m_address);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(m_address);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryGet(out T dataBlock)
	{
		if ((m_cachedLoadID <= 0 || !m_cacheIsUpToDate) && ScriptableData.TryGetDataBlock<T>(m_address, out m_cachedDataBlock))
		{
			m_cachedLoadID = ScriptableData.globalLoadID;
			m_cachedDataBlockAddress = m_address;
		}
		dataBlock = m_cachedDataBlock;
		return dataBlock != null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public T Get()
	{
		TryGet(out var dataBlock);
		return dataBlock;
	}
}
