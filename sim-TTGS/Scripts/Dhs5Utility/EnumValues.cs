using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnumValues<T, U> : IEnumerable<KeyValuePair<T, U>>, IEnumerable where T : Enum
{
	[SerializeField]
	private U[] m_enumValues;

	public U this[T enumValue]
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

	private U Get(T enumValue)
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

	private void Set(T enumValue, U value)
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

	public IEnumerator<KeyValuePair<T, U>> GetEnumerator()
	{
		for (int i = 0; i < m_enumValues.Length; i++)
		{
			if (Enum.IsDefined(typeof(T), i))
			{
				yield return new KeyValuePair<T, U>((T)Enum.ToObject(typeof(T), i), m_enumValues[i]);
			}
		}
	}

	public IEnumerator<U> GetSimpleEnumerator()
	{
		U[] enumValues = m_enumValues;
		for (int i = 0; i < enumValues.Length; i++)
		{
			yield return enumValues[i];
		}
	}
}
