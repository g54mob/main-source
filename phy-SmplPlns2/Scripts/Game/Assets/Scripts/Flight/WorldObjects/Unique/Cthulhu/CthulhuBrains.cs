using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Unique.Cthulhu
{
	public class CthulhuBrains : MonoBehaviour
	{
		private AudioSource _audioSource;

		private float _fadeSpeed = 0.4f;

		private bool _fadingIn;

		private bool _fadingOut;

		public void FadeInBrainLoop()
		{
			ResetFades();
			_audioSource.volume = 0f;
			_fadingIn = true;
			_audioSource.Play();
		}

		public void FadeOutBrainLoop()
		{
			ResetFades();
			_audioSource.volume = 1f;
			_fadingOut = true;
			_audioSource.Play();
		}

		protected virtual void Start()
		{
			_audioSource = GetComponent<AudioSource>();
			ResetFades();
		}

		protected virtual void Update()
		{
			if (_fadingIn || _fadingOut)
			{
				Fade();
			}
		}

		private void Fade()
		{
			if (_fadingIn)
			{
				_audioSource.volume += _fadeSpeed * Time.deltaTime;
			}
			else
			{
				_audioSource.volume -= _fadeSpeed * Time.deltaTime;
			}
			if (_audioSource.volume <= 0f)
			{
				ResetBrainLoop();
			}
			else if (_audioSource.volume >= 1f)
			{
				ResetFades();
			}
		}

		private void ResetBrainLoop()
		{
			ResetFades();
			_audioSource.Stop();
			_audioSource.loop = true;
		}

		private void ResetFades()
		{
			_fadingIn = false;
			_fadingOut = false;
		}
	}
}
