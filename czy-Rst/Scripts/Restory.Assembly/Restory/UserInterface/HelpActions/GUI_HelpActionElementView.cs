using System;
using Restory.Data.GUIControllerElements;
using Restory.UserInterface.ElementPresets;
using Rewired;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UserInterface.HelpActions
{
	public class GUI_HelpActionElementView : MonoBehaviour
	{
		private static class Style
		{
			public const string Data = "Data";

			public const string Gui = "GUI";
		}

		[SerializeField]
		private HelpActionElement element;

		[SerializeField]
		private GuiControllerTemplateList controllerTemplateList;

		[SerializeField]
		private GUI_InputActionButtonImage actionImage;

		[SerializeField]
		private Image holdImage;

		[SerializeField]
		private GUI_ElementPresetSwitcher elementPresetSwitcher;

		private bool interactable = true;

		public HelpActionElement Element
		{
			get
			{
				return element;
			}
			set
			{
				SetHelpActionElement(value);
			}
		}

		public GuiControllerTemplateList СontrollerTemplateList
		{
			get
			{
				return controllerTemplateList;
			}
			set
			{
				SetСontrollerTemplateList(value);
			}
		}

		public event Action<HelpActionElement> ElementChanged;

		private void Editor_OnControllerTemplateListChanged()
		{
			SetСontrollerTemplateList(controllerTemplateList);
		}

		private void OnEnable()
		{
			if (element != null)
			{
				Subscribe();
				UpdateView();
			}
		}

		private void OnDisable()
		{
			if (element != null)
			{
				Unsubscribe();
			}
		}

		private void Subscribe()
		{
			element.InteractableChanged += SetInteractable;
			element.ProgressChanged += SetProgress;
		}

		private void Unsubscribe()
		{
			element.InteractableChanged -= SetInteractable;
			element.ProgressChanged -= SetProgress;
		}

		public void SetHelpActionElement(HelpActionElement element)
		{
			if (base.isActiveAndEnabled && this.element != null)
			{
				Unsubscribe();
			}
			this.element = element;
			if (base.isActiveAndEnabled)
			{
				Subscribe();
				UpdateView();
			}
			this.ElementChanged?.Invoke(this.element);
		}

		public void SetСontrollerTemplateList(GuiControllerTemplateList controllerTemplateList)
		{
			this.controllerTemplateList = controllerTemplateList;
			actionImage.SetСontrollerTemplateList(controllerTemplateList);
		}

		private void SetInteractable(bool interactable)
		{
			this.interactable = interactable;
			UpdateActivePreset();
		}

		private void SetProgress(float value)
		{
			holdImage.fillAmount = value;
		}

		private void UpdateView()
		{
			if (element != null)
			{
				actionImage.SetInputActionAndAxis(element.Button.InputAction, element.Button.AxisRange, element.Button.Hold);
				SetInteractable(element.Interactable);
				SetProgress(element.Progress);
			}
			else
			{
				actionImage.SetInputActionAndAxis(null, AxisRange.Full, hold: false);
				SetInteractable(interactable: false);
				SetProgress(0f);
			}
		}

		private void UpdateActivePreset()
		{
			elementPresetSwitcher.ActivatePreset(interactable ? PresetName.Normal : PresetName.Disabled);
		}
	}
}
