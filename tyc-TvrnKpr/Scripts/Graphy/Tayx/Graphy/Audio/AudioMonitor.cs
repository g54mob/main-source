using UnityEngine;

namespace Tayx.Graphy.Audio
{
	public class AudioMonitor : MonoBehaviour
	{
		private const float m_refValue = 1f;

		private GraphyManager m_graphyManager;

		private AudioListener m_audioListener;

		private GraphyManager.LookForAudioListener m_findAudioListenerInCameraIfNull;

		private FFTWindow m_FFTWindow;

		private int m_spectrumSize;

		private float[] m_spectrum;

		private float[] m_spectrumHighestValues;

		private float m_maxDB;

		public float[] Spectrum => null;

		public float[] SpectrumHighestValues => null;

		public float MaxDB => 0f;

		public bool SpectrumDataAvailable => false;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void UpdateParameters()
		{
		}

		public float lin2dB(float linear)
		{
			return 0f;
		}

		public float dBNormalized(float db)
		{
			return 0f;
		}

		private void FindAudioListener()
		{
		}

		private void Init()
		{
		}
	}
}
