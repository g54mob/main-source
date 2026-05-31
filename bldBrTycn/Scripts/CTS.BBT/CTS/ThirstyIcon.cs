using UnityEngine;

namespace CTS
{
	public class ThirstyIcon : MonoBehaviour
	{
		[SerializeField]
		private Animator[] _animation;

		[SerializeField]
		private float _speed = 1f;

		private float _thirstyValue;

		private int _currentPlayer;

		private void Update()
		{
			_thirstyValue += Time.unscaledDeltaTime * _speed;
			if (_thirstyValue >= 1f)
			{
				_thirstyValue -= 1f;
				PlayAnim();
			}
		}

		private void PlayAnim()
		{
			_animation[_currentPlayer].SetTrigger("play");
			_currentPlayer++;
			if (_currentPlayer >= _animation.Length)
			{
				_currentPlayer = 0;
			}
		}
	}
}
