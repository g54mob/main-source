using System;
using DG.Tweening;
using Data.Variables;
using Events.UI.Overlays;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor
{
	public class FadeToBlackUI : MonoBehaviour
	{
		[SerializeField]
		private Image _image;

		[SerializeField]
		private FadeToBlackEvent _fadeToBlackEvent;

		[SerializeField]
		private FadeFromBlackEvent _fadeFromBlackEvent;

		[SerializeField]
		private FadeLetterBoxFromBlackEvent _fadeLetterboxFromBlackEvent;

		[SerializeField]
		private BoolVariableSO _uiVisibilitySO;

		[SerializeField]
		private Image _topLetterbox;

		[SerializeField]
		private Image _bottomLetterbox;

		private Color _transparentColor = new Color(0f, 0f, 0f, 0f);

		private void Awake()
		{
			_image.color = _transparentColor;
			_topLetterbox.gameObject.SetActive(value: false);
			_bottomLetterbox.gameObject.SetActive(value: false);
			_fadeToBlackEvent.Register(HandleFadeToBlackEvent);
			_fadeFromBlackEvent.Register(HandleFadFromBlackEvent);
			_fadeLetterboxFromBlackEvent.Register(FadeLetterBoxFromBlack);
		}

		private void OnDestroy()
		{
			_fadeToBlackEvent.UnRegister(HandleFadeToBlackEvent);
			_fadeFromBlackEvent.UnRegister(HandleFadFromBlackEvent);
			_fadeLetterboxFromBlackEvent.UnRegister(FadeLetterBoxFromBlack);
		}

		private void HandleFadeToBlackEvent(Action onComplete)
		{
			FadeToBlack(onComplete);
		}

		private void HandleFadFromBlackEvent((Action onComplete, bool showUI) data)
		{
			FadeFromBlack(data.onComplete, data.showUI);
		}

		public void FadeToBlack(Action onComplete = null)
		{
			_image.DOColor(Color.black, 1f).OnComplete(delegate
			{
				_topLetterbox.gameObject.SetActive(value: false);
				_bottomLetterbox.gameObject.SetActive(value: false);
				_uiVisibilitySO.SetValue(value: false);
				onComplete?.Invoke();
			}).SetEase(Ease.InOutCirc);
		}

		public void FadeFromBlack(Action onComplete = null, bool showUI = true)
		{
			_uiVisibilitySO.SetValue(showUI);
			_topLetterbox.gameObject.SetActive(!showUI);
			_bottomLetterbox.gameObject.SetActive(!showUI);
			_topLetterbox.color = Color.black;
			_bottomLetterbox.color = Color.black;
			_image.DOColor(_transparentColor, 1f).OnComplete(delegate
			{
				onComplete?.Invoke();
			}).SetEase(Ease.InOutCirc);
		}

		public void FadeLetterBoxFromBlack(Action onComplete = null)
		{
			_topLetterbox.DOColor(_transparentColor, 1f).SetEase(Ease.InOutCirc);
			_bottomLetterbox.DOColor(_transparentColor, 1f).OnComplete(delegate
			{
				onComplete?.Invoke();
			}).SetEase(Ease.InOutCirc);
		}
	}
}
