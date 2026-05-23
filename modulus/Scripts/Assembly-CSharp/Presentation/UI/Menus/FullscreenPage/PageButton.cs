using DG.Tweening;
using Presentation.UI.ButtonHelpers;
using UnityEngine;

namespace Presentation.UI.Menus.FullscreenPage
{
	public class PageButton : ActivationButton
	{
		[SerializeField]
		private RectTransform _line;

		[SerializeField]
		private CanvasGroup _activeObject;

		[SerializeField]
		private float _lineScale = 1f;

		[SerializeField]
		private float _lineScaleActive = 3f;

		protected override void SetActive(bool active)
		{
			_line.DOKill();
			_line.DOScaleY(active ? _lineScaleActive : _lineScale, 0.3f);
			_activeObject.DOKill();
			_activeObject.DOFade(active ? 1f : 0f, 0.3f);
		}

		protected override void SetHover(bool hover)
		{
			if (!base.ActiveState)
			{
				_line.DOKill();
				_line.DOScaleY(hover ? _lineScaleActive : _lineScale, 0.3f);
			}
		}

		public void HideButton()
		{
			base.gameObject.SetActive(value: false);
		}

		public void ShowButton()
		{
			base.gameObject.SetActive(value: true);
		}
	}
}
