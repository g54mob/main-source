using UnityEngine;

namespace TH20
{
	public class AnimationLecternEventListener : MonoBehaviour
	{
		[SerializeField]
		private ClippableLight _projectorLight;

		[SerializeField]
		private Texture2D[] _projectorSlideCookies;

		[SerializeField]
		private float _projectorSlideDuration = 10f;

		private Texture2D[] _shuffledProjectorSlideCookies;

		private int _currentSlideIndex;

		private float _currentSlideTime;

		private void TurnProjectorOn(AnimationEvent animationEvent)
		{
			if (!_projectorLight.gameObject.activeSelf)
			{
				_projectorLight.gameObject.SetActive(value: true);
			}
		}

		private void TurnProjectorOff(AnimationEvent animationEvent)
		{
			if (_projectorLight.gameObject.activeSelf)
			{
				_projectorLight.gameObject.SetActive(value: false);
			}
		}

		private void OnEnable()
		{
			_shuffledProjectorSlideCookies = new Texture2D[_projectorSlideCookies.Length];
			for (int i = 0; i < _projectorSlideCookies.Length; i++)
			{
				_shuffledProjectorSlideCookies[i] = _projectorSlideCookies[i];
			}
			for (int j = 0; j < _projectorSlideCookies.Length - 1; j++)
			{
				int num = Random.Range(j, _projectorSlideCookies.Length);
				Texture2D texture2D = _shuffledProjectorSlideCookies[j];
				_shuffledProjectorSlideCookies[j] = _shuffledProjectorSlideCookies[num];
				_shuffledProjectorSlideCookies[num] = texture2D;
			}
			_projectorLight.Cookie = _shuffledProjectorSlideCookies[_currentSlideIndex];
		}

		private void Update()
		{
			_currentSlideTime += Time.deltaTime;
			if (_currentSlideTime >= _projectorSlideDuration)
			{
				_currentSlideTime = 0f;
				_currentSlideIndex = (_currentSlideIndex + 1) % _shuffledProjectorSlideCookies.Length;
				_projectorLight.Cookie = _shuffledProjectorSlideCookies[_currentSlideIndex];
			}
		}
	}
}
