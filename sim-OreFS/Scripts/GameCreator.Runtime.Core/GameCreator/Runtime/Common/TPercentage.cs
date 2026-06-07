using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public abstract class TPercentage : ISerializationCallbackReceiver
	{
		[SerializeField]
		private float m_Value = 1f;

		public float UnitRatio
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

		public float Percent
		{
			get
			{
				return m_Value * 100f;
			}
			set
			{
				m_Value = value / 100f;
			}
		}

		protected TPercentage()
		{
		}

		protected TPercentage(float unit)
		{
			m_Value = unit;
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			if (!AssemblyUtils.IsReloading)
			{
				m_Value = Mathf.Clamp01(m_Value);
			}
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		public override string ToString()
		{
			return m_Value.ToString("P");
		}
	}
}
