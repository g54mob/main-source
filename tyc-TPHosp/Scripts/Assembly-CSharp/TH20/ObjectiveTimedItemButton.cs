using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class ObjectiveTimedItemButton : MonoBehaviour
	{
		[SerializeField]
		private DynamicButton _button;

		[SerializeField]
		private Image _highlight;

		private float _elapsedTime;

		private float _triggerTime = 30f;

		private float _fillAmount;

		private float _fillAmountMax = 3f;

		private float _animSpeed = 1f;

		private bool _isAnimating;

		private void Update()
		{
			if (_isAnimating)
			{
				_fillAmount += Time.unscaledDeltaTime * _animSpeed;
				_highlight.fillAmount = Mathf.Clamp01(_fillAmount);
				if (_fillAmount >= _fillAmountMax)
				{
					GameObjectUtils.SetActive(_highlight.gameObject, isActive: false);
					_isAnimating = false;
				}
			}
			else
			{
				_elapsedTime += Time.unscaledDeltaTime;
				if (_elapsedTime > _triggerTime)
				{
					StartAnimation();
					_elapsedTime = 0f;
				}
			}
		}

		private void StartAnimation()
		{
			GameObjectUtils.SetActive(_highlight.gameObject, isActive: true);
			_isAnimating = true;
			_fillAmount = 0f;
			_highlight.fillAmount = _fillAmount;
		}
	}
}
