using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	public class CaptureAudioFromAudioClip : MonoBehaviour
	{
		[SerializeField]
		private CaptureBase _capture;

		[SerializeField]
		private AudioClip _audioClip;

		private int _videoOffsetInSamples;

		private int _committedFrames;

		private int _committedSamples;

		private int _lastCommittedSample;

		private float[] _frameBuffer;

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		private float[] GetAudioSamplesForFrame()
		{
			return null;
		}
	}
}
