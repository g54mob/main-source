using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class EnablerAngle180 : TEnablerValueCommon
	{
		[SerializeField]
		[Range(0f, 179f)]
		private float m_Value;

		public float Value
		{
			get
			{
				return m_Value;
			}
			set
			{
				m_Value = Mathf.Clamp(value, 0f, 179f);
			}
		}

		public EnablerAngle180()
			: this(isEnabled: false, 60f)
		{
		}

		public EnablerAngle180(float value)
			: this(isEnabled: false, value)
		{
		}

		public EnablerAngle180(bool isEnabled, float value)
			: base(isEnabled)
		{
			Value = value;
		}
	}
}
