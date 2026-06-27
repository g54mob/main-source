using System;
using System.Collections;
using Restory.UserInterface.ElementPresets;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_Button : GUI_Selectable, IPointerClickHandler, IEventSystemHandler, ISubmitHandler
	{
		[Serializable]
		public class ButtonClickedEvent : UnityEvent
		{
		}

		[SerializeField]
		private PresetSwitcherBlock switcherBlock = PresetSwitcherBlock.DefaultBlock;

		[SerializeField]
		private GraphicAndColorBlock button;

		[SerializeField]
		private GraphicAndColorBlock text;

		[SerializeField]
		private ButtonClickedEvent onClick = new ButtonClickedEvent();

		public override bool Interactable
		{
			get
			{
				return interactable;
			}
			set
			{
				interactable = value;
				interactableChanged.Invoke(this, interactable);
				UpdateVisuals(instantly: false);
			}
		}

		public event UnityAction OnClick
		{
			add
			{
				onClick.AddListener(value);
			}
			remove
			{
				onClick.RemoveListener(value);
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			UpdateVisuals(instantly: true);
		}

		protected override void Awake()
		{
			base.Awake();
			UpdateVisuals(instantly: true);
		}

		private void Press()
		{
			if (IsActive() && IsInteractable())
			{
				UISystemProfilerApi.AddMarker("Button.onClick", this);
				onClick.Invoke();
			}
		}

		private IEnumerator OnFinishSubmit()
		{
			float fadeTime = button.Colors.fadeDuration;
			float elapsedTime = 0f;
			while (elapsedTime < fadeTime)
			{
				elapsedTime += Time.unscaledDeltaTime;
				yield return null;
			}
			UpdateVisuals(instantly: false);
		}

		protected override void OnCanvasGroupChanged()
		{
			base.OnCanvasGroupChanged();
			UpdateVisuals(instantly: false);
		}

		private void UpdateVisuals(bool instantly)
		{
			PresetName presetName;
			Color color;
			Color color2;
			if (!IsInteractable())
			{
				presetName = PresetName.Disabled;
				color = button.Colors.disabledColor;
				color2 = text.Colors.disabledColor;
			}
			else if (isPointerDown)
			{
				presetName = PresetName.Pressed;
				color = button.Colors.pressedColor;
				color2 = text.Colors.pressedColor;
			}
			else if (hasSelection)
			{
				presetName = PresetName.Selected;
				color = button.Colors.selectedColor;
				color2 = text.Colors.selectedColor;
			}
			else if (isPointerInside)
			{
				presetName = PresetName.Highlighted;
				color = button.Colors.highlightedColor;
				color2 = text.Colors.highlightedColor;
			}
			else
			{
				presetName = PresetName.Normal;
				color = button.Colors.normalColor;
				color2 = text.Colors.normalColor;
			}
			if (switcherBlock.PresetSwitcher != null)
			{
				switcherBlock.PresetSwitcher.ActivatePreset(presetName, instantly);
			}
			if (button.Graphic != null)
			{
				button.CrossFadeColor(color, instantly);
			}
			if (text.Graphic != null)
			{
				text.CrossFadeColor(color2, instantly);
			}
		}

		public override void OnSelect(BaseEventData eventData)
		{
			base.OnSelect(eventData);
			UpdateVisuals(instantly: false);
		}

		public override void OnDeselect(BaseEventData eventData)
		{
			base.OnDeselect(eventData);
			UpdateVisuals(instantly: false);
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			UpdateVisuals(instantly: false);
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerExit(eventData);
			UpdateVisuals(instantly: false);
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			UpdateVisuals(instantly: false);
		}

		public virtual void OnPointerClick(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				Press();
			}
		}

		public virtual void OnSubmit(BaseEventData eventData)
		{
			if (IsActive() && IsInteractable())
			{
				Press();
				UpdateVisuals(instantly: false);
				StartCoroutine(OnFinishSubmit());
			}
		}
	}
}
