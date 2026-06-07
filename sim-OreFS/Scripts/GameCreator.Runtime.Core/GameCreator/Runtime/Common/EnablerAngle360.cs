using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class EnablerAngle360 : TEnablerValueCommon
	{
		[SerializeField]
		[Range(0f, 359f)]
		private float m_Value;

		public float Value
		{
			get
			{
				return m_Value;
			}
			set
			{
				m_Value = Mathf.Clamp(value, 0f, 359f);
			}
		}

		public EnablerAngle360()
			: this(isEnabled: false, 120f)
		{
		}

		public EnablerAngle360(float value)
			: this(isEnabled: false, value)
		{
		}

		public EnablerAngle360(bool isEnabled, float value)
			: base(isEnabled)
		{
			Value = value;
		}
	}
}
