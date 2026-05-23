using System.Collections.Generic;
using DG.Tweening;
using UI.Breadcrumbs;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.Toolbar
{
	public class BuildBarButton : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup _frameCanvasGroup;

		[SerializeField]
		private CanvasGroup _activeGOCanvasGroup;

		[SerializeField]
		private Button _button;

		[SerializeField]
		private RectTransform _background;

		[SerializeField]
		private BreadcrumbUI _breadcrumbUI;

		private bool _hasBreadcrumbUI;

		public Button Button => _button;

		private void Awake()
		{
			_frameCanvasGroup.alpha = 1f;
			_activeGOCanvasGroup.alpha = 0f;
		}

		public void Init(BuildMode buildMode, int familyId)
		{
			_hasBreadcrumbUI = _breadcrumbUI != null;
			if (_hasBreadcrumbUI)
			{
				string item = BreadcrumbUtilities.BuildBarTabToTag(buildMode, familyId);
				_breadcrumbUI.SetBreadcrumbTags(new List<string> { item });
			}
		}

		private void Hovering(bool value)
		{
			_background.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, value ? 66f : 62f);
		}

		public void Select()
		{
			_frameCanvasGroup.DOKill();
			_activeGOCanvasGroup.DOKill();
			_frameCanvasGroup.DOFade(0f, 0.3f);
			_activeGOCanvasGroup.DOFade(1f, 0.3f);
			if (_hasBreadcrumbUI)
			{
				_breadcrumbUI.enabled = false;
			}
			Hovering(value: true);
		}

		public void Deselect()
		{
			_frameCanvasGroup.DOKill();
			_activeGOCanvasGroup.DOKill();
			_frameCanvasGroup.DOFade(1f, 0.3f);
			_activeGOCanvasGroup.DOFade(0f, 0.3f);
			if (_hasBreadcrumbUI)
			{
				_breadcrumbUI.enabled = true;
			}
			Hovering(value: false);
		}
	}
}
