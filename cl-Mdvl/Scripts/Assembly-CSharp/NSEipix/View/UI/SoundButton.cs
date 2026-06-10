using System;
using NSEipix.Base;
using NSMedieval.Sound;
using NSMedieval.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace NSEipix.View.UI
{
	public class SoundButton : Button
	{
		public class ButtonNonInteractableClickedEvent : UnityEvent
		{
		}

		public class ButtonRightClickedEvent : UnityEvent
		{
		}

		public class PointerDownEvent : UnityEvent
		{
		}

		public class PointerDragEvent : UnityEvent
		{
		}

		[SerializeField]
		private string buttonClickSound;

		[SerializeField]
		private string buttonHoverSound;

		private ButtonNonInteractableClickedEvent nonInteractableClickEvent = new ButtonNonInteractableClickedEvent();

		private ButtonRightClickedEvent rightClickedEvent = new ButtonRightClickedEvent();

		private PointerDownEvent onPointerDownEvent = new PointerDownEvent();

		private PointerDragEvent onPointerDragEvent = new PointerDragEvent();

		public string ButtonClickSound
		{
			get
			{
				return buttonClickSound;
			}
			set
			{
				buttonClickSound = value;
			}
		}

		public string ButtonHoverSound
		{
			get
			{
				return buttonHoverSound;
			}
			set
			{
				buttonHoverSound = value;
			}
		}

		public ButtonRightClickedEvent onRightClick
		{
			get
			{
				return rightClickedEvent;
			}
			set
			{
				rightClickedEvent = value;
			}
		}

		public PointerDownEvent onPointerDown
		{
			get
			{
				return onPointerDownEvent;
			}
			set
			{
				onPointerDownEvent = value;
			}
		}

		public PointerDragEvent onPointerDrag
		{
			get
			{
				return onPointerDragEvent;
			}
			set
			{
				onPointerDragEvent = value;
			}
		}

		public ButtonNonInteractableClickedEvent onNonInteractableClick
		{
			get
			{
				return nonInteractableClickEvent;
			}
			set
			{
				nonInteractableClickEvent = value;
			}
		}

		public event Action PointerClickEvent;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			ClearAllListeners();
		}

		public void ClearAllListeners()
		{
			this.PointerClickEvent = null;
			onNonInteractableClick?.RemoveAllListeners();
			onRightClick?.RemoveAllListeners();
			onPointerDown?.RemoveAllListeners();
			onPointerDrag?.RemoveAllListeners();
			base.onClick?.RemoveAllListeners();
		}

		public void AddCleanListener(UnityAction call)
		{
			base.onClick.RemoveAllListeners();
			base.onClick.AddListener(call);
		}

		public void RemoveAllListeners()
		{
			onRightClick.RemoveAllListeners();
		}

		public void AddCleanNonInteractableListener(UnityAction call)
		{
			onNonInteractableClick.RemoveAllListeners();
			onNonInteractableClick.AddListener(call);
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			if (eventData == null)
			{
				return;
			}
			if (!IsInteractable())
			{
				nonInteractableClickEvent?.Invoke();
			}
			if (eventData.button == PointerEventData.InputButton.Right)
			{
				if (IsActive() && IsInteractable())
				{
					rightClickedEvent?.Invoke();
				}
				return;
			}
			if (MonoSingleton<AudioManager>.IsInstantiated() && !string.IsNullOrEmpty(buttonClickSound))
			{
				MonoSingleton<AudioManager>.Instance.PlaySound(ButtonClickSound);
			}
			base.OnPointerClick(eventData);
			this.PointerClickEvent?.Invoke();
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			if (IsInteractable() && !string.IsNullOrEmpty(buttonHoverSound))
			{
				MonoSingleton<AudioManager>.Instance.PlaySound(ButtonHoverSound);
			}
			if (Input.GetMouseButton(0))
			{
				onPointerDragEvent?.Invoke();
			}
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			onPointerDownEvent?.Invoke();
		}

		public void DeactivateClearListeners()
		{
			base.onClick.RemoveAllListeners();
			base.gameObject.SetActive(value: false);
		}

		public void Activate(UnityAction onClick, string tooltipKey = null, bool interactable = true)
		{
			base.gameObject.SetActive(value: true);
			base.interactable = interactable;
			base.onClick.RemoveAllListeners();
			if (interactable)
			{
				base.onClick.AddListener(onClick);
			}
			if (tooltipKey != null)
			{
				LocalizedTextTooltipView component = GetComponent<LocalizedTextTooltipView>();
				if (component != null)
				{
					component.SetTooltipKey(tooltipKey);
				}
			}
		}
	}
}
