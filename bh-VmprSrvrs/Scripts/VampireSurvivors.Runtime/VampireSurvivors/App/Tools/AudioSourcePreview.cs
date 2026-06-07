using UnityEngine;

namespace VampireSurvivors.App.Tools
{
	public class AudioSourcePreview : MonoBehaviour
	{
		private AudioSource _audioSource;

		public bool IsPlaying => false;

		public float CurrentTime => 0f;

		private void Awake()
		{
		}
	}
}
