using DG.Tweening;
using Presentation.FactoryFloor.Toolbar;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.ModuleViewer
{
	public class ModuleButtonInViewer : ModuleButton
	{
		[SerializeField]
		private CanvasGroup _activeState;

		[SerializeField]
		private Image _backgroundImage;

		[SerializeField]
		private Color _bgNormalColor;

		[SerializeField]
		private Color _bgPinnedColor;

		[SerializeField]
		private ModuleViewerMaxLocator _maxLocator;

		private bool _isActive;

		private bool _isPinned;

		public bool IsInMaxViewer { private get; set; }

		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActive = value;
				if (_isActive)
				{
					_activeState.DOFade(1f, 0.3f);
				}
				else
				{
					_activeState.DOFade(0f, 0.2f);
				}
			}
		}

		public bool IsPinned
		{
			get
			{
				return _isPinned;
			}
			set
			{
				_isPinned = value;
				_backgroundImage.color = (_isPinned ? _bgPinnedColor : _bgNormalColor);
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			_activeState.alpha = 0f;
			_activeState.gameObject.SetActive(value: true);
		}

		protected override void HandleClick()
		{
			if (IsInMaxViewer)
			{
				_hoverGO.SetActive(value: false);
				_maxLocator.Value.UpdateModule((_moduleViewerData, _index));
			}
			else
			{
				base.HandleClick();
			}
		}
	}
}
