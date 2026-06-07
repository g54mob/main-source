using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnumFlagValues<TE, TF, U> : IEnumerable<KeyValuePair<TE, U>>, IEnumerable where TE : Enum where TF : Enum
{
	[SerializeField]
	private TF m_flag;

	[SerializeField]
	private U[] m_enumValues;

	public TF Flag
	{
		get
		{
			return m_flag;
		}
		set
		{
			m_flag = value;
		}
	}

	public U this[TE enumValue]
	{
		get
		{
			return Get(enumValue);
		}
		set
		{
			Set(enumValue, value);
		}
	}

	public bool TryGet(TE enumValue, out U value)
	{
		value = default(U);
		if (!m_enumValues.IsValid())
		{
			return false;
		}
		int num = Convert.ToInt32(enumValue);
		if (num < m_enumValues.Length)
		{
			value = m_enumValues[num];
			return IsIndexValid(num);
		}
		Debug.LogError("Enum Values for type " + typeof(U)?.ToString() + " not complete, might need to serialize it in the inspector");
		return false;
	}

	private U Get(TE enumValue)
	{
		if (!m_enumValues.IsValid())
		{
			return default(U);
		}
		int num = Convert.ToInt32(enumValue);
		if (num < m_enumValues.Length)
		{
			return m_enumValues[num];
		}
		Debug.LogError("Enum Values for type " + typeof(U)?.ToString() + " not complete, might need to serialize it in the inspector");
		return default(U);
	}

	private void Set(TE enumValue, U value)
	{
		if (!m_enumValues.IsValid())
		{
			return;
		}
		int num = Convert.ToInt32(enumValue);
		if (num >= m_enumValues.Length)
		{
			U[] array = new U[num + 1];
			for (int i = 0; i < m_enumValues.Length; i++)
			{
				array[i] = m_enumValues[i];
			}
			m_enumValues = array;
		}
		m_enumValues[num] = value;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public IEnumerator<KeyValuePair<TE, U>> GetEnumerator()
	{
		for (int i = 0; i < m_enumValues.Length; i++)
		{
			if (Enum.IsDefined(typeof(TE), i) && IsIndexValid(i))
			{
				yield return new KeyValuePair<TE, U>((TE)Enum.ToObject(typeof(TE), i), m_enumValues[i]);
			}
		}
	}

	public IEnumerable<U> GetSimpleEnumerator()
	{
		using IEnumerator<KeyValuePair<TE, U>> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			yield return enumerator.Current.Value;
		}
	}

	private bool IsIndexValid(int index)
	{
		return (Convert.ToInt32(m_flag) & (1 << index)) != 0;
	}
}
