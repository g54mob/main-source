using DG.Tweening;
using TMPro;
using UI.Text;
using UnityEngine;
using UnityEngine.UI;
using Utilities.Text;

namespace UI.HUD
{
	[ExecuteAlways]
	public class StatSliderView : MonoBehaviour
	{
		[SerializeField]
		private Slider _slider;

		[SerializeField]
		private TextMeshProUGUI _statText;

		[SerializeField]
		private RectTransform _fillRect;

		[SerializeField]
		private RectTransform _fillBg;

		[SerializeField]
		private TextShake _shakeText;

		[SerializeField]
		private StretchText _stretchText;

		[SerializeField]
		private Image _warningImage;

		[SerializeField]
		private TextMeshProUGUI _hintText;

		[SerializeField]
		private string _textValue;

		[Header("Text Parameters Over Slider")]
		[SerializeField]
		private Gradient _textGradient;

		[SerializeField]
		private AnimationCurve _shakeValue;

		[SerializeField]
		private float _shakePower = 3f;

		[Header("Fade Parameters")]
		[SerializeField]
		private float _fadeDuration = 0.3f;

		[SerializeField]
		private float _blinkDuration = 0.5f;

		[Header("Denied Feedback")]
		[Tooltip("Корінь рядка, який трусимо при заблокованій дії. Якщо порожньо — власний RectTransform.")]
		[SerializeField]
		private RectTransform _deniedShakeRoot;

		[SerializeField]
		private float _deniedShakeDuration = 0.4f;

		[SerializeField]
		private float _deniedShakeAngle = 8f;

		[SerializeField]
		private int _deniedShakeVibrato = 10;

		private TMP_TextInfo _textInfo;

		private Tweener _hintFadeTweener;

		private Tweener _warningFadeTweener;

		private Sequence _warningBlinkSequence;

		private Tween _deniedTween;

		private Vector2 _lastSizeDelta;

		private Color _lastTextColor;

		private float _lastShakeMagnitude;

		private float _lastSliderValue = float.MinValue;

		private bool _hintVisible;

		private bool _warningVisible;

		private bool _warningBlinking;

		private void Start()
		{
			_hintText.text = _textValue;
			if (Application.isPlaying)
			{
				Color color = _hintText.color;
				color.a = 0f;
				_hintText.color = color;
				_hintVisible = false;
				Color color2 = _warningImage.color;
				color2.a = 0f;
				_warningImage.color = color2;
				_warningVisible = false;
				_warningBlinking = false;
				_lastSizeDelta = _statText.rectTransform.sizeDelta;
				_lastTextColor = _statText.color;
				_lastShakeMagnitude = _shakeText.shakeMagnitude;
			}
		}

		public void Update()
		{
			if (Application.isPlaying)
			{
				float value = _slider.value;
				AlightTextToFill();
				SetTextEffectOverSlider(value);
				if (!Mathf.Approximately(value, _lastSliderValue))
				{
					CheckForWarnings(value);
					_lastSliderValue = value;
				}
			}
		}

		private void CheckForWarnings(float value)
		{
			if (value < 25f)
			{
				if (!_hintVisible)
				{
					_hintVisible = true;
					FadeInHintText();
				}
			}
			else if (_hintVisible)
			{
				_hintVisible = false;
				FadeOutHintText();
			}
			if (value <= 0f)
			{
				if (!_warningVisible)
				{
					_warningVisible = true;
					FadeInWarningImage();
				}
				if (!_warningBlinking)
				{
					_warningBlinking = true;
					StartBlinkingWarning();
				}
			}
			else
			{
				if (_warningVisible)
				{
					_warningVisible = false;
					FadeOutWarningImage();
				}
				if (_warningBlinking)
				{
					_warningBlinking = false;
					StopBlinkingWarning();
				}
			}
		}

		private void FadeInHintText()
		{
			_hintFadeTweener?.Kill();
			_hintFadeTweener = _hintText.DOFade(1f, _fadeDuration);
		}

		private void FadeOutHintText()
		{
			_hintFadeTweener?.Kill();
			_hintFadeTweener = _hintText.DOFade(0f, _fadeDuration);
		}

		private void FadeInWarningImage()
		{
			_warningFadeTweener?.Kill();
			_warningFadeTweener = _warningImage.DOFade(1f, _fadeDuration);
		}

		private void FadeOutWarningImage()
		{
			_warningFadeTweener?.Kill();
			_warningFadeTweener = _warningImage.DOFade(0f, _fadeDuration);
		}

		private void StartBlinkingWarning()
		{
			_warningBlinkSequence?.Kill();
			_warningBlinkSequence = DOTween.Sequence();
			_warningBlinkSequence.Append(_warningImage.DOFade(0.3f, _blinkDuration / 2f));
			_warningBlinkSequence.Append(_warningImage.DOFade(1f, _blinkDuration / 2f));
			_warningBlinkSequence.SetLoops(-1, LoopType.Yoyo);
		}

		private void StopBlinkingWarning()
		{
			_warningBlinkSequence?.Kill();
			_warningBlinkSequence = null;
		}

		public void LateUpdate()
		{
			if (Application.isPlaying)
			{
				SetTextGeometry();
			}
		}

		private void AlightTextToFill()
		{
			float num = _fillBg.rect.x - _fillRect.rect.x;
			float num2 = -2f * num;
			if (!Mathf.Approximately(num2, _lastSizeDelta.x))
			{
				_lastSizeDelta = new Vector2(num2, _statText.rectTransform.sizeDelta.y);
				_statText.rectTransform.sizeDelta = _lastSizeDelta;
			}
		}

		private void SetTextEffectOverSlider(float sliderValue)
		{
			float time = sliderValue / _slider.maxValue;
			Color color = _textGradient.Evaluate(time);
			if (color != _lastTextColor)
			{
				_lastTextColor = color;
				_statText.color = color;
			}
			float num = _shakeValue.Evaluate(time) * _shakePower;
			if (!Mathf.Approximately(num, _lastShakeMagnitude))
			{
				_lastShakeMagnitude = num;
				_shakeText.shakeMagnitude = num;
			}
		}

		private void SetTextGeometry()
		{
			if (!(_statText == null) && !(_stretchText == null) && !(_shakeText == null))
			{
				_statText.ForceMeshUpdate();
				_textInfo = _statText.textInfo;
				_stretchText.ApplyStretch(_textInfo);
				_shakeText.ApplyShake(_textInfo);
				for (int i = 0; i < _textInfo.meshInfo.Length; i++)
				{
					TMP_MeshInfo tMP_MeshInfo = _textInfo.meshInfo[i];
					tMP_MeshInfo.mesh.SetVertices(tMP_MeshInfo.vertices, 0, tMP_MeshInfo.vertices.Length);
					_statText.UpdateGeometry(tMP_MeshInfo.mesh, i);
				}
			}
		}

		public bool PlayDeniedFeedback()
		{
			if (!Application.isPlaying)
			{
				return false;
			}
			if (_deniedShakeRoot == null)
			{
				_deniedShakeRoot = base.transform as RectTransform;
			}
			if (_deniedShakeRoot == null)
			{
				return false;
			}
			if (_deniedTween != null && _deniedTween.IsActive())
			{
				return false;
			}
			_deniedShakeRoot.localRotation = Quaternion.identity;
			_deniedTween = _deniedShakeRoot.DOShakeRotation(_deniedShakeDuration, new Vector3(0f, 0f, _deniedShakeAngle), _deniedShakeVibrato).OnComplete(delegate
			{
				_deniedShakeRoot.localRotation = Quaternion.identity;
			});
			return true;
		}

		private void OnDestroy()
		{
			_hintFadeTweener?.Kill();
			_warningFadeTweener?.Kill();
			_warningBlinkSequence?.Kill();
			_deniedTween?.Kill();
		}
	}
}
