using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	public class AudioSourceToWav : MonoBehaviour
	{
		[SerializeField]
		private string _filename;

		private WavWriter _wavWriter;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnAudioFilterRead(float[] data, int channels)
		{
		}
	}
}
