using Easing;
using TMPro;
using UnityEngine;

namespace Motorways.UI
{
	public class NumberBubble : MonoBehaviour
	{
		public const float BounceScaleAmount = 1.3f;

		public const float BounceTweenDuration = 0.5f;

		public const float ShrinkTweenDuration = 0.1f;

		public bool hideWhenZero;

		[SerializeField]
		private RectTransform _optionNumberTransform;

		[SerializeField]
		private TMP_Text _optionNumberText;

		private TweenFloat _scaleTween = new TweenFloat();

		private bool _isHidden;

		private float? _defaultScale;

		private const string InfiniteSymbol = "<sprite index=1 tint=1>";

		private void Awake()
		{
			if (!_defaultScale.HasValue)
			{
				_defaultScale = base.transform.localScale.x;
			}
		}

		public void Bounce()
		{
			_scaleTween.Start(_isHidden ? 0f : 1.3f, 1f, 0.5f, Easings.Functions.BounceEaseOut);
			_isHidden = false;
		}

		public void SetValue(int value, bool doBounce = true)
		{
			if (hideWhenZero && value <= 0)
			{
				if (!_isHidden)
				{
					Hide();
				}
				return;
			}
			_optionNumberText.text = value.ToString();
			if (doBounce)
			{
				Bounce();
			}
			else if (_isHidden)
			{
				_optionNumberTransform.localScale = Vector3.one;
			}
		}

		public void SetValueUnlimited()
		{
			Bounce();
			_optionNumberText.text = "<sprite index=1 tint=1>";
		}

		public void Hide(bool instantly = false)
		{
			if (!_defaultScale.HasValue)
			{
				_defaultScale = base.transform.localScale.x;
			}
			_isHidden = true;
			if (instantly)
			{
				_scaleTween.Stop();
				_optionNumberTransform.localScale = Vector3.zero;
			}
			else
			{
				_scaleTween.Start(1f, 0f, 0.1f, Easings.Functions.Linear);
			}
		}

		private void Update()
		{
			if (_scaleTween.IsActive)
			{
				_scaleTween.Tick(Time.deltaTime);
				_optionNumberTransform.localScale = Vector3.one * _scaleTween.Value * _defaultScale.Value;
			}
		}
	}
}
