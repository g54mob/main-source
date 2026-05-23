using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.Toolbar
{
	public class FancyToolBarButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private Image _hoverImage;

		[SerializeField]
		private Image _glowImage;

		[SerializeField]
		private CanvasGroup _hoverGroup;

		[SerializeField]
		private Image _selectedOutline;

		[SerializeField]
		protected FactoryLockedView _lockedView;

		[SerializeField]
		private Color _disabledOutlineColor;

		private Color _accentColor = Color.white;

		private float _hoverAlpha = 0.4f;

		protected bool _deactivated;

		protected bool _deactivatedHover;

		public int ID { get; set; }

		public virtual Color AccentColor
		{
			set
			{
				_accentColor = new Color(value.r, value.g, value.b, 1f);
				_hoverImage.color = _accentColor;
				_glowImage.color = _accentColor;
				_hoverGroup.alpha = 0f;
				_selectedOutline.color = _accentColor;
			}
		}

		public event Action<FancyToolBarButton> Hovered;

		public event Action<FancyToolBarButton> Selected;

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
			if (!_deactivatedHover)
			{
				_hoverGroup.DOKill();
				_hoverGroup.DOFade(_hoverAlpha, 0.4f);
				this.Hovered?.Invoke(this);
			}
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
			if (!_deactivatedHover)
			{
				_hoverGroup.DOKill();
				_hoverGroup.DOFade(0f, 0.4f);
			}
		}

		private void OnDisable()
		{
			_hoverGroup.DOKill();
			_hoverGroup.DOFade(0f, 0.4f);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			ButtonPressed();
		}

		protected virtual void ButtonPressed()
		{
			if (!_deactivated)
			{
				this.Selected?.Invoke(this);
			}
		}

		public void Disable(bool forceLock = false, bool allowHover = false)
		{
			_deactivated = true;
			_deactivatedHover = !allowHover;
			_button.interactable = allowHover;
			if ((bool)_lockedView)
			{
				if (forceLock)
				{
					_lockedView.IsForcedLock = true;
				}
				else
				{
					_lockedView.IsLocked = true;
				}
			}
			_hoverGroup.DOKill();
			_hoverGroup.alpha = 0f;
			_selectedOutline.DOKill();
		}

		public void Enable()
		{
			_deactivated = false;
			_deactivatedHover = false;
			_button.interactable = true;
			if ((bool)_lockedView)
			{
				_lockedView.IsLocked = false;
			}
		}
	}
}
