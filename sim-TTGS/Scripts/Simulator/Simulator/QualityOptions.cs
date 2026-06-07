using System;
using Dhs5.Utility.Settings;
using UnityEngine;
using UnityEngine.Rendering;

namespace Simulator
{
	[Serializable]
	public class QualityOptions
	{
		[SerializeField]
		private PlayerPrefBool m_vsync;

		[SerializeField]
		private PlayerPrefEnum<MSAASamples> m_antialiasing;

		public PlayerPrefBool VSync => m_vsync;

		public PlayerPrefEnum<MSAASamples> Antialiasing => m_antialiasing;

		public void Update()
		{
			QualitySettings.vSyncCount = (m_vsync.Value ? 1 : 0);
			QualitySettings.antiAliasing = (int)m_antialiasing.Value;
		}

		public void Load()
		{
			m_vsync.Load();
			m_antialiasing.Load();
			Update();
		}

		public void Reset()
		{
			m_vsync.Reset();
			m_antialiasing.Reset();
			Update();
		}
	}
}
