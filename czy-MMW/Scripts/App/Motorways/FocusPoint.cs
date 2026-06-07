using Easing;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways
{
	[RequireComponent(typeof(RectTransform))]
	public class FocusPoint : MonoBehaviour
	{
		private enum AnimationState
		{
			Hidden = 0,
			TransitionIn = 1,
			Visible = 2,
			TransitionOut = 3
		}

		private enum FadeState
		{
			Visible = 0,
			FadeDelay = 1,
			Fading = 2,
			Hidden = 3
		}

		public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("FocusPoint");

		private RectTransform _rectTransform;

		private Image _image;

		[SerializeField]
		private Image _additionalImage;

		[SerializeField]
		private AnimationState _animationState;

		private float _transitionProgress;

		[SerializeField]
		private float _transitionDuration = 0.2f;

		[SerializeField]
		private float _sensitivity = 5f;

		private FadeState _fadeState;

		[SerializeField]
		private float _fadeDelayDuration = 2.5f;

		private float _fadeDelayProgress;

		[SerializeField]
		private float _fadeDuration = 0.2f;

		private float _fadeProgress;

		private Vector2 _targetPosition;

		private const float AnchorPositionOffsetFactor = 0.8f;

		public Vector2 Position => _rectTransform.anchoredPosition;

		public bool IsVisible
		{
			get
			{
				if (_animationState != AnimationState.TransitionIn)
				{
					return _animationState == AnimationState.Visible;
				}
				return true;
			}
		}

		private void Awake()
		{
			_image = GetComponent<Image>();
			_rectTransform = GetComponent<RectTransform>();
			SetFocusPointActive(active: false, instant: true);
			_targetPosition = _rectTransform.anchoredPosition;
		}

		public void Update()
		{
			ProcessTransitions();
			ProcessFade();
			_rectTransform.anchoredPosition = Vector2.Lerp(_rectTransform.anchoredPosition, _targetPosition, 0.8f);
		}

		private void ProcessTransitions()
		{
			switch (_animationState)
			{
			case AnimationState.TransitionIn:
			{
				_transitionProgress += Time.deltaTime;
				if (_transitionProgress >= _transitionDuration)
				{
					_transitionProgress = _transitionDuration;
					_animationState = AnimationState.Visible;
				}
				float t2 = Easings.BackEaseOut(1f / _transitionDuration * _transitionProgress);
				base.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t2);
				break;
			}
			case AnimationState.TransitionOut:
			{
				_transitionProgress += Time.deltaTime;
				if (_transitionProgress >= _transitionDuration)
				{
					_transitionProgress = _transitionDuration;
					_animationState = AnimationState.Hidden;
				}
				float t = Easings.BackEaseIn(1f / _transitionDuration * _transitionProgress);
				base.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, t);
				break;
			}
			}
		}

		private void ProcessFade()
		{
			if (FeatureToggle.IsFeatureDisabled(Feature.CursorFade))
			{
				return;
			}
			switch (_fadeState)
			{
			case FadeState.FadeDelay:
				_fadeDelayProgress += Time.deltaTime;
				if (_fadeDelayProgress >= _fadeDelayDuration)
				{
					_fadeState = FadeState.Fading;
					_fadeDelayProgress = 0f;
				}
				break;
			case FadeState.Fading:
			{
				_fadeProgress += Time.deltaTime;
				float alpha = 1f - 1f / _fadeDuration * _fadeProgress;
				SetAlpha(alpha);
				if (_fadeProgress >= _fadeDuration)
				{
					_fadeState = FadeState.Hidden;
					_fadeProgress = 0f;
				}
				break;
			}
			}
		}

		private void RemoveFade()
		{
			if (!FeatureToggle.IsFeatureDisabled(Feature.CursorFade))
			{
				_fadeState = FadeState.Visible;
				SetAlpha(1f);
			}
		}

		private void SetAlpha(float alpha)
		{
			Color color = _image.color;
			color.a = alpha;
			_image.color = color;
			Color color2 = _additionalImage.color;
			color2.a = alpha;
			_additionalImage.color = color2;
		}

		public void SetCursorPosition(Vector2 position)
		{
			_targetPosition = position;
			if (FeatureToggle.IsFeatureEnabled(Feature.CursorFade) && IsVisible)
			{
				_fadeState = FadeState.FadeDelay;
				_fadeDelayProgress = 0f;
				_fadeProgress = 0f;
			}
		}

		public void OffsetCursorPosition(Vector2 offset)
		{
			_targetPosition += offset * _sensitivity;
		}

		public void SetFocusPointActive(bool active, bool instant = false)
		{
			RemoveFade();
			if (active)
			{
				if (instant)
				{
					base.transform.localScale = Vector3.one;
					_animationState = AnimationState.Visible;
				}
				else
				{
					BeginShowCursor();
				}
			}
			else if (instant)
			{
				base.transform.localScale = Vector3.zero;
				_animationState = AnimationState.Hidden;
			}
			else
			{
				BeginHideCursor();
			}
		}

		private void BeginShowCursor()
		{
			_animationState = AnimationState.TransitionIn;
			_transitionProgress = _transitionDuration - _transitionProgress;
		}

		private void BeginHideCursor()
		{
			_animationState = AnimationState.TransitionOut;
			_transitionProgress = _transitionDuration - _transitionProgress;
		}
	}
}
