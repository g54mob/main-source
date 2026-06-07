using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Unique.Cthulhu
{
	public class CthulhuWaves : MonoBehaviour
	{
		private AudioSource _audioSource;

		private float _fadeSpeed = 0.4f;

		private bool _fadingOut;

		public void FadeOutWaveLoop()
		{
			_fadingOut = true;
		}

		public void PlayWaveLoop()
		{
			ResetWaveLoop();
			_audioSource.Play();
		}

		protected virtual void Start()
		{
			_audioSource = GetComponent<AudioSource>();
		}

		protected virtual void Update()
		{
			if (_fadingOut)
			{
				FadeOut();
			}
		}

		private void FadeOut()
		{
			if (_audioSource.volume <= 0f)
			{
				ResetWaveLoop();
			}
			else
			{
				_audioSource.volume -= _fadeSpeed * Time.deltaTime;
			}
		}

		private void ResetWaveLoop()
		{
			_fadingOut = false;
			_audioSource.Stop();
			_audioSource.volume = 1f;
			_audioSource.loop = true;
		}
	}
}
