using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[Since("v3.8.0")]
	public class MLValue : ChildComponent
	{
		public enum Type
		{
			Percent = 0,
			Absolute = 1,
			Extra = 2
		}

		[SerializeField]
		private Type m_Type;

		[SerializeField]
		private float m_Value;

		public Type type
		{
			get
			{
				return m_Type;
			}
			set
			{
				m_Type = value;
			}
		}

		public float value
		{
			get
			{
				return m_Value;
			}
			set
			{
				m_Value = value;
			}
		}

		public MLValue(float value)
		{
			m_Type = Type.Percent;
			m_Value = value;
		}

		public MLValue(Type type, float value)
		{
			m_Type = type;
			m_Value = value;
		}

		public float GetValue(float total)
		{
			return m_Type switch
			{
				Type.Percent => m_Value * total, 
				Type.Absolute => m_Value, 
				Type.Extra => total + m_Value, 
				_ => 0f, 
			};
		}
	}
}
