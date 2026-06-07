using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tayx.Graphy.Audio
{
	public class G_AudioMonitor : MonoBehaviour
	{
		private const float m_refValue = 1f;

		private GraphyManager m_graphyManager;

		private AudioListener m_audioListener;

		private GraphyManager.LookForAudioListener m_findAudioListenerInCameraIfNull;

		private FFTWindow m_FFTWindow;

		private int m_spectrumSize;

		public float[] Spectrum { get; private set; }

		public float[] SpectrumHighestValues { get; private set; }

		public float MaxDB { get; private set; }

		public bool SpectrumDataAvailable => false;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
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

		private AudioListener FindAudioListener()
		{
			return null;
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
		{
		}

		private void Init()
		{
		}
	}
}
