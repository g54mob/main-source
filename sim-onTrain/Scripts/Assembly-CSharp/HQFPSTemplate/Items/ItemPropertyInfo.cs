using System;
using UnityEngine;

namespace HQFPSTemplate.Items
{
	[Serializable]
	public class ItemPropertyInfo
	{
		[SerializeField]
		private string m_Name;

		[SerializeField]
		private ItemPropertyType m_Type;

		[SerializeField]
		private float m_FixedValue;

		[SerializeField]
		private bool m_UseRandomValue;

		[SerializeField]
		private Vector2 m_RandomValueRange;

		public string Name => m_Name;

		public ItemPropertyType Type => m_Type;

		public bool GetAsBoolean()
		{
			return GetAsInteger() > 0;
		}

		public int GetAsInteger()
		{
			return (int)GetInternalValue();
		}

		public float GetAsFloat()
		{
			return GetInternalValue();
		}

		private float GetInternalValue()
		{
			if (m_Type == ItemPropertyType.Boolean || m_Type == ItemPropertyType.ItemId)
			{
				return m_FixedValue;
			}
			float result = 0f;
			if (m_Type == ItemPropertyType.Float)
			{
				result = (m_UseRandomValue ? UnityEngine.Random.Range(m_RandomValueRange.x, m_RandomValueRange.y) : m_FixedValue);
			}
			else if (m_Type == ItemPropertyType.Integer)
			{
				result = (m_UseRandomValue ? ((float)UnityEngine.Random.Range((int)m_RandomValueRange.x, (int)m_RandomValueRange.y)) : m_FixedValue);
			}
			return result;
		}
	}
}
