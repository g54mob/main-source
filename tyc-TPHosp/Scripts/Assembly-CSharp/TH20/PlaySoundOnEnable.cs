using UnityEngine;

namespace TH20
{
	public class PlaySoundOnEnable : MonoBehaviour
	{
		[SerializeField]
		private string _audioName;

		[SerializeField]
		private float _delay;

		private float _remainingTime;

		private bool _played;

		private void OnEnable()
		{
			_remainingTime = _delay;
			if (_remainingTime == 0f)
			{
				AudioManager.Instance.Play(_audioName, base.gameObject);
				_played = true;
			}
		}

		private void Update()
		{
			if (!_played)
			{
				_remainingTime -= Time.deltaTime;
				if (_remainingTime < 0f)
				{
					AudioManager.Instance.Play(_audioName, base.gameObject);
					_played = true;
				}
			}
		}
	}
}
