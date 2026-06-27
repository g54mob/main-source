using System;
using Restory.Data.Remapping;
using Restory.UserInterface.CommonElements;
using Restory.UserInterface.ElementPresets;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Restory.UserInterface.SettingsMenu
{
	public class GUI_RemapItem : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISubmitHandler, ISelectHandler, IDeselectHandler
	{
		[Serializable]
		public class GUI_RemapItemClick : UnityEvent<GUI_RemapItem>
		{
		}

		[SerializeField]
		private RemappingButton remappingButton;

		[SerializeField]
		private string key;

		[SerializeField]
		private bool isRemapped;

		[SerializeField]
		private bool conflict;

		[SerializeField]
		private Button button;

		[SerializeField]
		private GUI_LocalisedText text;

		[SerializeField]
		private TextMeshProUGUI keyText;

		[SerializeField]
		private GUI_ElementPresetSwitcher elementPresetSwitcher;

		[SerializeField]
		private Color errorColor;

		[SerializeField]
		private Color normalColor;

		[SerializeField]
		private GUI_ConcreteNavigation navigation;

		[Space]
		[SerializeField]
		private GUI_RemapItemClick onClick;

		protected bool isPointerInside;

		public RemappingButton RemappingButton
		{
			get
			{
				return remappingButton;
			}
			set
			{
				remappingButton = value;
				text.LocalizationID = remappingButton.NameKey;
			}
		}

		public string Key
		{
			get
			{
				return key;
			}
			set
			{
				key = value;
				UpdateView();
			}
		}

		public bool Conflict
		{
			get
			{
				return conflict;
			}
			set
			{
				conflict = value;
				UpdateView();
			}
		}

		public bool IsRemapped
		{
			get
			{
				return isRemapped;
			}
			set
			{
				isRemapped = value;
				navigation.enabled = !isRemapped;
				UpdateView();
			}
		}

		public GUI_ConcreteNavigation Navigation => navigation;

		public event UnityAction<GUI_RemapItem> OnClick
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

		private void OnEnable()
		{
			button.onClick.AddListener(button_onClick);
		}

		private void OnDisable()
		{
			button.onClick.RemoveListener(button_onClick);
		}

		public void UpdateView()
		{
			keyText.text = (isRemapped ? "?" : key);
			keyText.color = (conflict ? errorColor : normalColor);
			ActivatePreset();
		}

		private void button_onClick()
		{
			onClick.Invoke(this);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			isPointerInside = true;
			ActivatePreset();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			isPointerInside = false;
			ActivatePreset();
		}

		private void ActivatePreset(bool instantly = false)
		{
			if (isRemapped)
			{
				elementPresetSwitcher.ActivatePreset(PresetName.Input, instantly);
			}
			else if (isPointerInside)
			{
				elementPresetSwitcher.ActivatePreset(PresetName.Hovered, instantly);
			}
			else
			{
				elementPresetSwitcher.ActivatePreset(PresetName.Normal, instantly);
			}
		}

		public void OnSubmit(BaseEventData eventData)
		{
			onClick.Invoke(this);
		}

		public void OnSelect(BaseEventData eventData)
		{
			isPointerInside = true;
			ActivatePreset();
		}

		public void OnDeselect(BaseEventData eventData)
		{
			isPointerInside = false;
			ActivatePreset();
		}
	}
}
