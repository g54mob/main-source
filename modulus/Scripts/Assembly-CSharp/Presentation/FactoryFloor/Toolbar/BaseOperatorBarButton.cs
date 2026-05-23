using DG.Tweening;
using Events;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.Toolbar
{
	public class BaseOperatorBarButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		protected Button _button;

		[SerializeField]
		protected Image _coloredPanel;

		[SerializeField]
		private Image _glow;

		[SerializeField]
		private Vector2 _panelSizeNormal;

		[SerializeField]
		private Vector2 _panelSizeHover;

		[SerializeField]
		private BaseEvent _stopPreviewEvent;

		private float _panelAlphaNormal = 0.75f;

		private float _panelAlphaHover = 1f;

		protected bool _isSelected;

		private bool _isHovering;

		private void Awake()
		{
			_stopPreviewEvent.Register(OnStopPreview);
			Initialized();
		}

		protected virtual void Initialized()
		{
		}

		protected virtual void OnDestroy()
		{
			_stopPreviewEvent.UnRegister(OnStopPreview);
		}

		public void SetSelected(bool value)
		{
			_isSelected = value;
			if (value)
			{
				Show();
			}
			else
			{
				Hide();
			}
		}

		private void OnStopPreview()
		{
			SetSelected(value: false);
		}

		public void SetColor(Color color)
		{
			_coloredPanel.color = color;
			_panelAlphaNormal = color.a;
		}

		private void OnDisable()
		{
			AnimateHover(isHovering: false);
		}

		protected void AnimateHover(bool isHovering)
		{
			_coloredPanel.rectTransform.DOKill();
			_glow.DOKill();
			_coloredPanel.DOKill();
			_coloredPanel.rectTransform.DOSizeDelta(isHovering ? _panelSizeHover : _panelSizeNormal, 0.2f).SetEase(Ease.OutCirc);
			_glow.DOFade(isHovering ? 0.2f : 0f, 0.2f);
			_coloredPanel.DOFade(isHovering ? _panelAlphaHover : _panelAlphaNormal, 0.2f);
		}

		protected virtual void Show()
		{
			AnimateHover(isHovering: true);
		}

		private void Hide()
		{
			if (!_isHovering && !_isSelected)
			{
				AnimateHover(isHovering: false);
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			_isHovering = true;
			if (!_button || _button.interactable)
			{
				Show();
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			_isHovering = false;
			Hide();
		}
	}
}
