using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture.Demos
{
	public class AmbisonicAudioDemo : MonoBehaviour
	{
		private struct Instance
		{
			private float x;

			private float y;

			private float z;

			private float radius;
		}

		[SerializeField]
		private Transform[] _audioObjects;

		[SerializeField]
		private AudioSource[] _audioSources;

		private int index;

		private void Update()
		{
		}
	}
}
