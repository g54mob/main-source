using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public abstract class TEnablerValue<T> : TEnablerValueCommon
	{
		[SerializeField]
		private T m_Value;

		public T Value
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

		protected TEnablerValue()
		{
			m_Value = default(T);
		}

		protected TEnablerValue(bool isEnabled, T value)
			: base(isEnabled)
		{
			m_Value = value;
		}
	}
}
