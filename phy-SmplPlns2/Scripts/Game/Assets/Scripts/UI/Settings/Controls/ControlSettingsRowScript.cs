using System;
using Jundroo.Juicy.Widgets;
using Rewired;
using UnityEngine;

namespace Assets.Scripts.UI.Settings.Controls
{
	public class ControlSettingsRowScript : MonoBehaviour
	{
		private Widget _invertAxisIcon;

		private Widget _keyboardButtons;

		private bool _supportsAxisInvert;

		public InputAction Action { get; set; }

		public TextWidget ActionNameText { get; set; }

		public AxisRange AxisDirection { get; set; }

		public Widget ControllerButton { get; private set; }

		public TextWidget ControllerText { get; set; }

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
					_invertAxisIcon.Visible = _supportsAxisInvert;
					_keyboardButtons.Visible = !_supportsAxisInvert;
				}
			}
		}

		public Widget KeyboardAlternateButton { get; private set; }

		public TextWidget KeyboardAlternateText { get; set; }

		public Widget KeyboardButton { get; private set; }

		public TextWidget KeyboardText { get; set; }

		public string MapCategory { get; set; }

		public ControlSettingsDialogScript.RowButtonType MappingType { get; set; } = ControlSettingsDialogScript.RowButtonType.None;

		public Widget Widget { get; private set; }

		public void Initialize(Widget widget)
		{
			Widget = widget;
			ActionNameText = widget.FindWidget<TextWidget>("action-name");
			KeyboardButton = widget.FindWidget("keyboard-binding");
			KeyboardText = KeyboardButton.FindWidget<TextWidget>("keyboard-binding-text");
			KeyboardAlternateButton = widget.FindWidget("keyboard-binding-alternate");
			KeyboardAlternateText = KeyboardAlternateButton.FindWidget<TextWidget>("keyboard-binding-alternate-text");
			ControllerButton = widget.FindWidget("controller-binding");
			ControllerText = ControllerButton.FindWidget<TextWidget>("controller-binding-text");
			_invertAxisIcon = widget.FindWidget("invert-axis");
			_keyboardButtons = widget.FindWidget("keyboard-buttons");
			_invertAxisIcon.Clicked += delegate
			{
				OnAxisInvertClicked();
			};
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
