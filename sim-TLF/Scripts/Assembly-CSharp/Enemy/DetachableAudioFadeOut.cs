using System.Collections;
using UnityEngine;

namespace Enemy
{
	[RequireComponent(typeof(AudioSource))]
	public class DetachableAudioFadeOut : MonoBehaviour
	{
		[SerializeField]
		private AudioSource _source;

		[Tooltip("Seconds the volume takes to reach zero.")]
		[SerializeField]
		private float _fadeDuration = 4f;

		private void Reset()
		{
			_source = GetComponent<AudioSource>();
		}

		private void Awake()
		{
			if (_source == null)
			{
				_source = GetComponent<AudioSource>();
			}
		}

		public void Begin(float fadeDuration = -1f)
		{
			if (fadeDuration > 0f)
			{
				_fadeDuration = fadeDuration;
			}
			StartCoroutine(FadeRoutine());
		}

		private IEnumerator FadeRoutine()
		{
			if (_source == null)
			{
				Object.Destroy(base.gameObject);
				yield break;
			}
			if (!_source.isPlaying)
			{
				_source.Play();
			}
			float startVolume = _source.volume;
			float elapsed = 0f;
			while (elapsed < _fadeDuration && _source != null)
			{
				elapsed += Time.deltaTime;
				_source.volume = Mathf.Lerp(startVolume, 0f, elapsed / _fadeDuration);
				yield return null;
			}
			if (_source != null)
			{
				_source.volume = 0f;
				_source.Stop();
			}
			Object.Destroy(base.gameObject);
		}
	}
}
