using UnityEngine;

namespace Tayx.Graphy.Fps
{
	public class G_FpsMonitor : MonoBehaviour
	{
		private short[] m_fpsSamples;

		private short[] m_fpsSamplesSorted;

		private short m_fpsSamplesCapacity;

		private short m_onePercentSamples;

		private short m_zero1PercentSamples;

		private short m_fpsSamplesCount;

		private short m_indexSample;

		private float m_unscaledDeltaTime;

		public short CurrentFPS { get; private set; }

		public short AverageFPS { get; private set; }

		public short OnePercentFPS { get; private set; }

		public short Zero1PercentFps { get; private set; }

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
