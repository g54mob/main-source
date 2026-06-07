using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public abstract class TEnablerValueCommon
	{
		[SerializeField]
		private bool m_IsEnabled;

		public bool IsEnabled
		{
			get
			{
				return m_IsEnabled;
			}
			set
			{
				m_IsEnabled = value;
			}
		}

		protected TEnablerValueCommon()
		{
			m_IsEnabled = false;
		}

		protected TEnablerValueCommon(bool isEnabled)
		{
			m_IsEnabled = isEnabled;
		}
	}
}
