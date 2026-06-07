using System.Collections.Generic;
using UnityEngine;

namespace Tayx.Graphy.Fps
{
	public class FpsMonitor : MonoBehaviour
	{
		private GraphyManager m_graphyManager;

		private float m_currentFps;

		private float m_avgFps;

		private float m_minFps;

		private float m_maxFps;

		[SerializeField]
		private int m_averageSamples;

		private List<float> m_averageFpsSamples;

		private int m_timeToResetMinMaxFps;

		private float m_timeToResetMinFpsPassed;

		private float m_timeToResetMaxFpsPassed;

		private float unscaledDeltaTime;

		public float CurrentFPS => 0f;

		public float AverageFPS => 0f;

		public float MinFPS => 0f;

		public float MaxFPS => 0f;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void UpdateParameters()
		{
		}

		private void Init()
		{
		}
	}
}
