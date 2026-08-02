using System;
using UnityEngine;

namespace HQFPSTemplate
{
	[Serializable]
	public class GenericStatData
	{
		[SerializeField]
		[Range(0.01f, 100f)]
		private float m_InitialValue = 100f;

		[SerializeField]
		private bool m_RegenEnabled = true;

		[SerializeField]
		[ShowIf("m_RegenEnabled", true, 10f)]
		private float m_RegenPause = 2f;

		[SerializeField]
		[ShowIf("m_RegenEnabled", true, 10f)]
		[Clamp(0f, 1000f)]
		private float m_RegenSpeed = 10f;

		private float m_NextRegenTime;

		public float InitialValue => m_InitialValue;

		public bool CanRegenerate
		{
			get
			{
				if (m_RegenEnabled)
				{
					return !IsPaused;
				}
				return false;
			}
		}

		public bool IsPaused => Time.time < m_NextRegenTime;

		public float RegenDelta => m_RegenSpeed * Time.deltaTime;

		public void Pause()
		{
			m_NextRegenTime = Time.time + m_RegenPause;
		}
	}
}
