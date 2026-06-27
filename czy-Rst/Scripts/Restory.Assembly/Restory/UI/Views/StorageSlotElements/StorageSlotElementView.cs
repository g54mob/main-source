using System;
using Restory.Data.Elements.Condition;
using Restory.ObjectPools;
using Restory.UserInterface.CommonElements;
using Restory.UserInterface.ElementPresets;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UI.Views.StorageSlotElements
{
	public sealed class StorageSlotElementView : GUI_InteractibleView, IPointerClickHandler, IEventSystemHandler, IPointerMoveHandler, ICleanableComponent
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private Image elementImage;

		[SerializeField]
		private Image conditionImage;

		[SerializeField]
		private Toggle toggle;

		[SerializeField]
		private PresetName disabledPreset = PresetName.Disabled;

		public bool Selected
		{
			get
			{
				return toggle.isOn;
			}
			set
			{
				toggle.isOn = value;
			}
		}

		public event Action<StorageSlotElementView> PointerClick;

		public event Action<StorageSlotElementView> PointerUp;

		public event Action<StorageSlotElementView> PointerDown;

		public event Action<StorageSlotElementView> PointerEnter;

		public event Action<StorageSlotElementView> PointerExit;

		public event Action<StorageSlotElementView> PointerMove;

		public void Select()
		{
			Selected = true;
		}

		public void Deselect()
		{
			Selected = false;
		}

		public void Show()
		{
			canvasGroup.alpha = 1f;
			canvasGroup.interactable = true;
			base.enabled = true;
		}

		public void Hide()
		{
			canvasGroup.alpha = 0f;
			canvasGroup.interactable = false;
		}

		public void Enable()
		{
			ActivateDefaultPreset();
			base.enabled = true;
		}

		public void Disable()
		{
			ActivatePreset(disabledPreset);
			base.enabled = false;
		}

		public void UpdateElement(Sprite elementIcon, ElementConditionBase elementCondition)
		{
			elementImage.sprite = elementIcon;
			if ((bool)elementCondition)
			{
				conditionImage.sprite = elementCondition.Icon;
				conditionImage.enabled = !(elementCondition is PerfectElementCondition);
			}
		}

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
			this.PointerClick?.Invoke(this);
		}

		void IPointerMoveHandler.OnPointerMove(PointerEventData eventData)
		{
			this.PointerMove?.Invoke(this);
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			this.PointerEnter?.Invoke(this);
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerExit(eventData);
			this.PointerExit?.Invoke(this);
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			this.PointerDown?.Invoke(this);
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
			this.PointerUp?.Invoke(this);
		}

		void ICleanableComponent.Clean()
		{
			Enable();
			this.PointerClick = null;
			this.PointerUp = null;
			this.PointerDown = null;
			this.PointerEnter = null;
			this.PointerExit = null;
			this.PointerMove = null;
			elementImage.sprite = null;
			conditionImage.sprite = null;
			toggle.isOn = false;
			canvasGroup.alpha = 1f;
			canvasGroup.interactable = true;
		}
	}
}
