using System;
using Rewired;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Ui.Settings
{
	public class ControlSettingsRowScript : MonoBehaviour
	{
		private XmlElement _invertAxisIcon;

		private XmlElement _keyboardButtons;

		private bool _supportsAxisInvert;

		public InputAction Action { get; set; }

		public string MapCategory { get; private set; }

		public XmlElement ActionNameText { get; set; }

		public AxisRange AxisDirection { get; set; }

		public XmlElement ControllerButton { get; private set; }

		public XmlElement ControllerText { get; set; }

		public Action<InputMapper.InputMappedEventData, ControlSettingsRowScript, ControlSettingsDialogScript.RowButtonType> InputMappedEvent { get; set; }

		public Action<ControlSettingsRowScript, bool> InvertChangedEvent { get; set; }

		public bool Inverted
		{
			get
			{
				return _invertAxisIcon.HasClass("inverted");
			}
			set
			{
				if (value && !_invertAxisIcon.HasClass("inverted"))
				{
					_invertAxisIcon.AddClass("inverted");
				}
				else if (!value && _invertAxisIcon.HasClass("inverted"))
				{
					_invertAxisIcon.RemoveClass("inverted");
				}
			}
		}

		public bool IsAxis
		{
			get
			{
				return _invertAxisIcon.Visible;
			}
			set
			{
				if (_supportsAxisInvert != value)
				{
					_supportsAxisInvert = value;
					if (_supportsAxisInvert)
					{
						_invertAxisIcon.Show();
						_keyboardButtons.Hide();
					}
					else
					{
						_invertAxisIcon.Hide();
						_keyboardButtons.Show();
					}
				}
			}
		}

		public XmlElement KeyboardAlternateButton { get; private set; }

		public XmlElement KeyboardAlternateText { get; set; }

		public XmlElement KeyboardButton { get; private set; }

		public XmlElement KeyboardText { get; set; }

		public ControlSettingsDialogScript.RowButtonType MappingType { get; set; } = ControlSettingsDialogScript.RowButtonType.None;

		public XmlElement XmlElement { get; private set; }

		public ControlSettingsRowScript(XmlElement element)
		{
			XmlElement = element;
		}

		public void Initialize(XmlElement element, string mapCategory)
		{
			XmlElement = element;
			MapCategory = mapCategory;
			ActionNameText = element.GetElementByInternalId("action-name");
			KeyboardButton = element.GetElementByInternalId("keyboard-binding");
			KeyboardText = KeyboardButton.GetElementByInternalId("keyboard-binding-text");
			KeyboardAlternateButton = element.GetElementByInternalId("keyboard-binding-alternate");
			KeyboardAlternateText = KeyboardAlternateButton.GetElementByInternalId("keyboard-binding-alternate-text");
			ControllerButton = element.GetElementByInternalId("controller-binding");
			ControllerText = ControllerButton.GetElementByInternalId("controller-binding-text");
			_invertAxisIcon = element.GetElementByInternalId("invert-axis");
			_keyboardButtons = element.GetElementByInternalId("keyboard-buttons");
			_invertAxisIcon.AddOnClickEvent(delegate
			{
				OnAxisInvertClicked();
			});
		}

		public void OnInputMapped(InputMapper.InputMappedEventData obj)
		{
			InputMappedEvent?.Invoke(obj, this, MappingType);
			MappingType = ControlSettingsDialogScript.RowButtonType.None;
		}

		public void OnMappingStopped(InputMapper.StoppedEventData obj)
		{
			obj.inputMapper.InputMappedEvent -= OnInputMapped;
			obj.inputMapper.StoppedEvent -= OnMappingStopped;
			MappingType = ControlSettingsDialogScript.RowButtonType.None;
		}

		private void OnAxisInvertClicked()
		{
			_invertAxisIcon.ToggleClass("inverted");
			InvertChangedEvent?.Invoke(this, _invertAxisIcon.HasClass("inverted"));
		}
	}
}
