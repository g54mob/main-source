using System;
using System.Collections.Generic;
using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	public class AmbisonicSource : MonoBehaviour
	{
		[SerializeField]
		private AmbisonicWavWriter _sink;

		[SerializeField]
		private Transform _listener;

		private Vector3 _position;

		private AmbisonicOrder _order;

		private AmbisonicChannelOrder _channelOrder;

		private AmbisonicNormalisation _normalisation;

		private IntPtr _sourceInstance;

		private int _activeSampleIndex;

		private float[] _activeSamples;

		private Queue<float[]> _fullBuffers;

		private Queue<float[]> _emptyBuffers;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		internal void Setup(AmbisonicOrder order, AmbisonicChannelOrder channelOrder, AmbisonicNormalisation normalisation, int bufferCount)
		{
		}

		private void OnDrawGizmos()
		{
		}

		private void LateUpdate()
		{
		}

		private void SetListenerRelativePosition(Vector3 position)
		{
		}

		private void UpdateCoefficients()
		{
		}

		private void OnAudioFilterRead(float[] samples, int channelCount)
		{
		}

		internal void FlushBuffers()
		{
		}

		internal int GetFullBufferCount()
		{
			return 0;
		}

		internal void SendSamplesToSink(bool isAdditive, bool isDraining)
		{
		}
	}
}
