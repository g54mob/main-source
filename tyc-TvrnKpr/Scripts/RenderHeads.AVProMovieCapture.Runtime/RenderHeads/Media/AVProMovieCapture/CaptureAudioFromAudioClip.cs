using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	[AddComponentMenu("AVPro Movie Capture/Audio/Capture Audio (From AudioClip)", 500)]
	public class CaptureAudioFromAudioClip : MonoBehaviour
	{
		[SerializeField]
		private CaptureBase _capture;

		[SerializeField]
		private AudioClip _audioClip;

		[SerializeField]
		private bool _restartAudioClipOnCaptureStart;

		private int _videoOffsetInSamples;

		private int _committedFrames;

		private int _committedSamples;

		private int _lastCommittedSample;

		private float[] _frameBuffer;

		private void Reset()
		{
		}

		private void OnCaptureStart()
		{
		}

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
