using Restory.UserInterface.CommonElements;
using Restory.UserInterface.ElementPresets;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UserInterface
{
	public class GUI_DropdownPresetSwitcher : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, ISelectHandler, IDeselectHandler
	{
		[SerializeField]
		private GUI_Dropdown dropdown;

		[SerializeField]
		private PresetSwitcherBlock shownSwitcherBlock = PresetSwitcherBlock.DefaultBlock;

		[SerializeField]
		private PresetSwitcherBlock hiddenSwitcherBlock = PresetSwitcherBlock.DefaultBlock;

		[SerializeField]
		private bool trackSelectableInteractable;

		private bool isInteractable = true;

		protected bool isPointerInside;

		protected bool isPointerDown;

		protected bool hasSelection;

		private void Reset()
		{
			dropdown = GetComponentInChildren<GUI_Dropdown>();
			ref PresetSwitcherBlock reference = ref shownSwitcherBlock;
			GUI_PresetSwitcher presetSwitcher = (hiddenSwitcherBlock.PresetSwitcher = GetComponentInChildren<GUI_PresetSwitcher>());
			reference.PresetSwitcher = presetSwitcher;
		}

		private void Start()
		{
			UpdateVisuals();
		}

		private void OnEnable()
		{
			dropdown.IsShownChanged += Dropdown_IsShownChanged;
			UpdateVisuals();
		}

		private void OnDisable()
		{
			dropdown.IsShownChanged -= Dropdown_IsShownChanged;
		}

		private void Update()
		{
			if (trackSelectableInteractable)
			{
				SetInteractableState(dropdown.interactable);
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			isPointerDown = true;
			UpdateVisuals();
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			isPointerDown = false;
			UpdateVisuals();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			isPointerInside = true;
			UpdateVisuals();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			isPointerInside = false;
			UpdateVisuals();
		}

		public virtual void OnSelect(BaseEventData eventData)
		{
			hasSelection = true;
			UpdateVisuals();
		}

		public virtual void OnDeselect(BaseEventData eventData)
		{
			hasSelection = false;
			UpdateVisuals();
		}

		private void SetInteractableState(bool value)
		{
			if (value != isInteractable)
			{
				isInteractable = value;
				UpdateVisuals();
			}
		}

		private void Dropdown_IsShownChanged(Dropdown dropdown, bool isShown)
		{
			UpdateVisuals();
		}

		private void UpdateVisuals(bool instantly = false)
		{
			PresetSwitcherBlock presetSwitcherBlock = (dropdown.IsShown ? shownSwitcherBlock : hiddenSwitcherBlock);
			if (!isInteractable)
			{
				presetSwitcherBlock.ActivatePreset(presetSwitcherBlock.DisabledPresetName, instantly);
			}
			else if (isPointerDown)
			{
				presetSwitcherBlock.ActivatePreset(presetSwitcherBlock.PressedPresetName, instantly);
			}
			else if (hasSelection)
			{
				presetSwitcherBlock.ActivatePreset(presetSwitcherBlock.SelectedPresetName, instantly);
			}
			else if (isPointerInside)
			{
				presetSwitcherBlock.ActivatePreset(presetSwitcherBlock.HighlightedPresetName, instantly);
			}
			else
			{
				presetSwitcherBlock.ActivatePreset(presetSwitcherBlock.NormalPresetName, instantly);
			}
		}
	}
}
