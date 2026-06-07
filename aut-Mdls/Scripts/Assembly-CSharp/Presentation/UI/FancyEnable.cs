using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI
{
	public class FancyEnable : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _rectTransform;

		[SerializeField]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private GameObject borderHighlight;

		[SerializeField]
		private GameObject borderHighlightInner;

		[SerializeField]
		private bool _doFadeIn = true;

		[SerializeField]
		private bool _doMove = true;

		[SerializeField]
		private bool _doRotate;

		[SerializeField]
		private bool _doPopup;

		[SerializeField]
		private Vector3 _direction = new Vector3(0f, 30f, 0f);

		[SerializeField]
		private float _animDuration = 0.15f;

		[SerializeField]
		private float _rotationDuration = 1f;

		[SerializeField]
		private float _popupScale = 1.2f;

		[SerializeField]
		private float _popupDuration = 0.5f;

		[SerializeField]
		private Image _borderHighlightImage;

		[SerializeField]
		private Image _borderHighlightInnerImage;

		[SerializeField]
		private float _alphaFadeDuration = 0.5f;

		[SerializeField]
		private float _borderHighlightScale = 1.5f;

		[SerializeField]
		private float _borderHighlightDuration = 0.5f;

		private Vector3 _originalPos = Vector3.zero;

		private Vector3 _originalScale = Vector3.one;

		private TweenerCore<Vector2, Vector2, VectorOptions> _positionTween;

		private TweenerCore<float, float, FloatOptions> _canvasTween;

		private Tweener _rotationTween;

		private Tweener _popupTween;

		private Sequence _animationSequence;

		private void Awake()
		{
			if (_rectTransform == null)
			{
				_rectTransform = GetComponent<RectTransform>();
			}
		}

		private void OnEnable()
		{
			if (_borderHighlightImage != null)
			{
				_borderHighlightImage.color = new Color(_borderHighlightImage.color.r, _borderHighlightImage.color.g, _borderHighlightImage.color.b, 1f);
			}
			if (_borderHighlightInnerImage != null)
			{
				_borderHighlightInnerImage.color = new Color(_borderHighlightInnerImage.color.r, _borderHighlightInnerImage.color.g, _borderHighlightInnerImage.color.b, 1f);
			}
			if (_doMove)
			{
				_originalPos = _rectTransform.anchoredPosition;
				_rectTransform.anchoredPosition = _originalPos - _direction;
			}
			if (_doFadeIn)
			{
				_canvasGroup.alpha = 0f;
			}
			if (_doRotate)
			{
				_rectTransform.localRotation = Quaternion.Euler(180f, 0f, 0f);
			}
			_animationSequence = DOTween.Sequence();
			if (_doMove)
			{
				_positionTween = _rectTransform.DOAnchorPos(_originalPos, _animDuration);
				_animationSequence.Append(_positionTween);
			}
			if (_doFadeIn && !_doRotate)
			{
				_canvasTween = DOTween.To(() => _canvasGroup.alpha, delegate(float x)
				{
					_canvasGroup.alpha = x;
				}, 1f, _animDuration * 2f);
				_animationSequence.Append(_canvasTween);
			}
			if (!_doRotate && !_doPopup)
			{
				return;
			}
			_originalScale = _rectTransform.localScale;
			_animationSequence.AppendCallback(delegate
			{
				Sequence sequence = DOTween.Sequence();
				if (_doRotate)
				{
					_rotationTween = _rectTransform.DORotate(new Vector3(0f, 0f, 0f), _rotationDuration).OnUpdate(delegate
					{
						float x = _rectTransform.localRotation.eulerAngles.x;
						if (x > 90f && x < 270f)
						{
							_canvasGroup.alpha = 0f;
						}
						else
						{
							float endValue = 1f;
							_canvasGroup.DOFade(endValue, _animDuration);
						}
					}).OnComplete(delegate
					{
						if (_doRotate && borderHighlight != null)
						{
							borderHighlight.SetActive(value: true);
							borderHighlightInner.SetActive(value: true);
							borderHighlight.transform.localScale = _originalScale;
							borderHighlight.transform.DOScale(Vector3.one * _borderHighlightScale, _borderHighlightDuration);
							if (_borderHighlightImage != null)
							{
								_borderHighlightImage.DOFade(0f, _alphaFadeDuration);
							}
							if (_borderHighlightInnerImage != null)
							{
								_borderHighlightInnerImage.DOFade(0f, _alphaFadeDuration);
							}
						}
					});
					sequence.Join(_rotationTween);
				}
				if (_doPopup)
				{
					_popupTween = _rectTransform.DOScale(Vector3.one * _popupScale, _popupDuration / 2f).SetEase(Ease.OutQuad).OnComplete(delegate
					{
						_rectTransform.DOScale(_originalScale, _popupDuration / 2f).SetEase(Ease.InQuad).OnComplete(delegate
						{
							_rectTransform.DOScale(_originalScale * 1.05f, _popupDuration / 4f).SetEase(Ease.OutQuad).OnComplete(delegate
							{
								_rectTransform.DOScale(_originalScale, _popupDuration / 4f).SetEase(Ease.InQuad).OnComplete(FadeInImages);
							});
						});
					});
					sequence.Join(_popupTween);
				}
				sequence.Play();
			});
		}

		private void FadeInImages()
		{
		}

		private void OnDisable()
		{
			_rectTransform.anchoredPosition = _originalPos;
			if (_doFadeIn)
			{
				_canvasGroup.alpha = 0f;
				KillCanvasTween();
			}
			if (_doMove)
			{
				KillPositionTween();
			}
			if (_doRotate)
			{
				KillRotationTween();
			}
			if (_doPopup)
			{
				_rectTransform.localScale = _originalScale;
				KillPopupTween();
			}
			if (_animationSequence != null)
			{
				_animationSequence.Kill();
				_animationSequence = null;
			}
			if (borderHighlight != null)
			{
				borderHighlight.SetActive(value: false);
			}
			if (borderHighlightInner != null)
			{
				borderHighlightInner.SetActive(value: false);
			}
		}

		private void KillPositionTween()
		{
			if (_positionTween != null)
			{
				_positionTween.Kill();
				_positionTween = null;
			}
		}

		private void KillCanvasTween()
		{
			if (_canvasTween != null)
			{
				DOTween.Kill(_canvasTween);
				_canvasTween = null;
			}
		}

		private void KillRotationTween()
		{
			if (_rotationTween != null)
			{
				_rotationTween.Kill();
				_rotationTween = null;
			}
		}

		private void KillPopupTween()
		{
			if (_popupTween != null)
			{
				_popupTween.Kill();
				_popupTween = null;
			}
		}
	}
}
