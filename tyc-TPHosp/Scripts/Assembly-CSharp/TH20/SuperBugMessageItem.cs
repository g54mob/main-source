using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class SuperBugMessageItem : MonoBehaviour
	{
		[SerializeField]
		private Button _closeButton;

		[SerializeField]
		private TMP_Text _text;

		[SerializeField]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private float _fadeInSpeed = 2.7f;

		[SerializeField]
		private float _fadeOutSpeed = 4.5f;

		private Coroutine _fadeCoroutine;

		private bool _fadeIn;

		private float _t;

		public bool IsHidden => _t <= 0f;

		private void Start()
		{
			_closeButton.onClick.AddListener(OnClosePressed);
		}

		public void Show(string text)
		{
			if (!text.IsNullOrEmpty())
			{
				_fadeIn = true;
				_text.text = text;
			}
		}

		public void Hide()
		{
			_fadeIn = false;
		}

		private void OnEnable()
		{
			_fadeCoroutine = StartCoroutine(FadeCoroutine());
		}

		private void OnDisable()
		{
			if (_fadeCoroutine != null)
			{
				StopCoroutine(_fadeCoroutine);
			}
		}

		private void OnDestroy()
		{
			_closeButton.onClick.RemoveListener(OnClosePressed);
		}

		private void OnClosePressed()
		{
			Hide();
		}

		private IEnumerator FadeCoroutine()
		{
			_t = 0f;
			while (true)
			{
				_t += (_fadeIn ? (Time.unscaledDeltaTime * _fadeInSpeed) : ((0f - Time.unscaledDeltaTime) * _fadeOutSpeed));
				_t = Mathf.Clamp01(_t);
				_canvasGroup.alpha = EasingsUtils.CubicEaseOut(_t);
				yield return null;
			}
		}
	}
}
