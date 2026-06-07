using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Events.AutoSave;
using UnityEngine;

namespace Presentation.UI.Menus.ScreenElements
{
	public class AutoSaveIndicator : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _rectTransform;

		[SerializeField]
		private AutoSaveEvent _autoSaveEvent;

		private Sequence _sequence;

		private void Awake()
		{
			base.gameObject.SetActive(value: false);
			_rectTransform.anchoredPosition = new Vector2(_rectTransform.sizeDelta.x, _rectTransform.anchoredPosition.y);
			_autoSaveEvent.Register(HandleAutoSave);
		}

		private void OnDestroy()
		{
			_autoSaveEvent.UnRegister(HandleAutoSave);
			if (_sequence != null)
			{
				_sequence.Kill();
			}
		}

		private void HandleAutoSave(int autoSaveCount)
		{
			_sequence = DOTween.Sequence();
			_sequence.Append(GetInTween(0.75f));
			_sequence.Append(GetOutTween(0.75f).SetDelay(1.5f));
		}

		private TweenerCore<Vector2, Vector2, VectorOptions> GetOutTween(float duration)
		{
			return _rectTransform.DOAnchorPos(new Vector2(_rectTransform.sizeDelta.x, _rectTransform.anchoredPosition.y), duration).SetEase(Ease.InCubic).OnComplete(delegate
			{
				base.gameObject.SetActive(value: false);
			});
		}

		private TweenerCore<Vector2, Vector2, VectorOptions> GetInTween(float duration)
		{
			base.gameObject.SetActive(value: true);
			return _rectTransform.DOAnchorPos(new Vector2(-50f, _rectTransform.anchoredPosition.y), duration).SetEase(Ease.OutCubic);
		}
	}
}
