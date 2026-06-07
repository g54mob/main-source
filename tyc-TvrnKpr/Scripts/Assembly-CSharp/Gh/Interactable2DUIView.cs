using System;
using System.Runtime.CompilerServices;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Gh
{
	public class Interactable2DUIView : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, ISubmitHandler, IMoveHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerMoveHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
	{
		protected RectTransform _ourRect;

		[SerializeField]
		protected ImageColorVisualizer _imageColorVisualizer;

		private bool _isEnabled;

		private bool _isHovered;

		private bool _isPressed;

		private bool _isSelected;

		private bool _isFocused;

		private Tween _positionTween;

		private Tween _rotationTween;

		private Tween _scaleTween;

		public Vector2 Dimensions => default(Vector2);

		[field: SerializeField]
		public bool IsInteractionFrozen { get; set; }

		public bool IsEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsPressed
		{
			get
			{
				return false;
			}
			protected set
			{
			}
		}

		public bool IsSelected
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsFocused
		{
			get
			{
				return false;
			}
			protected set
			{
			}
		}

		public bool IsHovered
		{
			get
			{
				return false;
			}
			protected set
			{
			}
		}

		public UnityEvent Clicked { get; }

		public UnityEvent ClickedSecondary { get; }

		[field: SerializeField]
		public TMP_Text LabelText { get; private set; }

		public event EventHandler HoveredChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected virtual void Awake()
		{
		}

		private void UpdateVisualizers()
		{
		}

		public void SetIsSelectedWithoutNotify(bool value)
		{
		}

		public void OnPointerClick(PointerEventData eventData)
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerMove(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		protected virtual void OnHoveringInternal(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		public void OnSubmit(BaseEventData eventData)
		{
		}

		public void OnDeselect(BaseEventData eventData)
		{
		}

		private void OnEnabledChanged(bool oldValue, bool newValue)
		{
		}

		private void OnPressedChanged(bool oldValue, bool newValue)
		{
		}

		protected void OnIsSelectedChanged(bool oldValue, bool newValue)
		{
		}

		protected virtual void OnIsSelectedChangedInternal(bool oldValue, bool newValue)
		{
		}

		private void OnFocusedChanged(bool oldValue, bool newValue)
		{
		}

		private void OnIsHoveredChanged(bool oldValue, bool newValue)
		{
		}

		protected virtual void OnIsHoveredChangedInternal(bool oldValue, bool newValue)
		{
		}

		protected void OnClicked()
		{
		}

		protected virtual void OnClickedInternal()
		{
		}

		protected void OnClickedSecondary()
		{
		}

		protected virtual void OnClickedSecondaryInternal()
		{
		}

		public void SetPosition(Vector3 localPosition, bool animate)
		{
		}

		public void SetRotation(Vector3 localRotation, bool animate)
		{
		}

		public void SetScale(float scale, bool animate)
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		public void OnMove(AxisEventData eventData)
		{
		}
	}
}
