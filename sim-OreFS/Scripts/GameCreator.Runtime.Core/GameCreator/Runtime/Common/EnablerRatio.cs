using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class EnablerRatio : TEnablerValueCommon
	{
		[SerializeField]
		[Range(0f, 1f)]
		private float m_Value;

		public float Value
		{
			get
			{
				return m_Value;
			}
			set
			{
				m_Value = Mathf.Clamp01(value);
			}
		}

		public EnablerRatio()
			: this(isEnabled: false, 1f)
		{
		}

		public EnablerRatio(float value)
			: this(isEnabled: false, value)
		{
		}

		public EnablerRatio(bool isEnabled, float value)
			: base(isEnabled)
		{
			Value = value;
		}
	}
}
