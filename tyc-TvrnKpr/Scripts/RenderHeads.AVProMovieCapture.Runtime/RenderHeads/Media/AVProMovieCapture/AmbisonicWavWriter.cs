using System.Collections.Generic;
using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	[AddComponentMenu("AVPro Movie Capture/Audio/Ambisonic WAV Writer", 601)]
	public class AmbisonicWavWriter : MonoBehaviour
	{
		[SerializeField]
		private CaptureBase _capture;

		[SerializeField]
		private AmbisonicOrder _order;

		[SerializeField]
		private AmbisonicFormat _format;

		[SerializeField]
		private string _filename;

		[SerializeField]
		[Range(4f, 32f)]
		private int _bufferCount;

		private float[] _outSamples;

		private WavWriter _wavWriter;

		private List<AmbisonicSource> _sources;

		private int _pendingSampleCount;

		public AmbisonicOrder Order => default(AmbisonicOrder);

		public AmbisonicFormat Format => default(AmbisonicFormat);

		internal void AddSource(AmbisonicSource source)
		{
		}

		internal void RemoveSource(AmbisonicSource source)
		{
		}

		private void OnDisable()
		{
		}

		private void SetupSource(AmbisonicSource source)
		{
		}

		private void ToggleCapturing(bool isCapturing)
		{
		}

		private void StartCapture()
		{
		}

		private void StopCapture()
		{
		}

		private bool IsCapturing()
		{
			return false;
		}

		private void LateUpdate()
		{
		}

		private void ProcessSources(bool isDraining)
		{
		}

		internal void MixSamples(float[] samples, int sampleCount, bool addSamples)
		{
		}

		private void FlushWavWriter()
		{
		}
	}
}
