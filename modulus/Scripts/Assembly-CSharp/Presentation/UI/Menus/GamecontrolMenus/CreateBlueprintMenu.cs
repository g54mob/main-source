using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Data.Blueprints;
using Presentation.FactoryFloor.Toolbar;
using Presentation.UI.LayoutElements.ColorPicker;
using Presentation.UI.Menus.MenuEvents.MenuData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Menus.GamecontrolMenus
{
	public class CreateBlueprintMenu : GamecontrolMenu
	{
		[Space]
		[SerializeField]
		private TextMeshProUGUI _titleText;

		[SerializeField]
		private Button _createButton;

		[SerializeField]
		private TextMeshProUGUI _createButtonText;

		[SerializeField]
		private Button _backButton;

		[SerializeField]
		private TextMeshProUGUI _errorText;

		[SerializeField]
		[LocaKey]
		private string _buttonTextCreate;

		[SerializeField]
		[LocaKey]
		private string _buttonTextEdit;

		[SerializeField]
		[LocaKey]
		private string _invalidInput;

		[Header("Colorpicker")]
		[SerializeField]
		private BlueprintsColorLibrary _colorLibrary;

		[SerializeField]
		private ColorpickerButton _colorpickerButtonPrefab;

		[SerializeField]
		private Transform _colorpickerParent;

		[Header("Input field")]
		[SerializeField]
		private TMP_InputField _inputField;

		private bool _colorpickerInitialized;

		private ColorpickerButton _currentColorButton;

		private Color _currentColor;

		private Dictionary<Color, ColorpickerButton> _colorpickerButtons;

		private EditNameAndColorUIMenuData _nameAndColorMenuData;

		public event Action<bool, string, Color> OnChangedValues = delegate
		{
		};

		public override void ShowMenu(AbstractUIMenuData menuData)
		{
			base.ShowMenu(menuData);
			_errorText.text = "";
			_nameAndColorMenuData = (EditNameAndColorUIMenuData)menuData;
			_titleText.SetText(LocalizationUtility.GetLocalizedText(_nameAndColorMenuData.EditNameAndColorUIData.TitleCreate));
			_createButtonText.SetText(LocalizationUtility.GetLocalizedText(_buttonTextCreate));
			_createButton.onClick.AddListener(OnCreateBlueprintButtonClicked);
			_backButton.onClick.AddListener(OnBackButtonClicked);
			SetupColorPicker();
			SetupInputField();
		}

		public void UseEditMode(string currentName, Color currentColor)
		{
			UseEditMode(currentName);
			SetColorpicker(currentColor);
		}

		public void UseEditMode(string currentName)
		{
			_colorpickerParent.gameObject.SetActive(value: false);
			_titleText.SetText(LocalizationUtility.GetLocalizedText(_nameAndColorMenuData.EditNameAndColorUIData.TitleEdit));
			_createButtonText.SetText(LocalizationUtility.GetLocalizedText(_buttonTextEdit));
			_inputField.text = currentName;
		}

		public void UseEditMode(BlueprintUIData blueprintUIData)
		{
			UseEditMode(blueprintUIData.BlueprintName, blueprintUIData.Color);
		}

		private void SetColorpicker(Color color)
		{
			_colorpickerParent.gameObject.SetActive(value: true);
			if (_currentColorButton != null)
			{
				_currentColorButton.IsSelected = false;
			}
			if (!_colorpickerButtons.ContainsKey(color))
			{
				color = _colorLibrary.Colors[0];
			}
			_currentColorButton = _colorpickerButtons[color];
			_currentColorButton.IsSelected = true;
			_currentColor = color;
		}

		public override void HideMenu()
		{
			base.HideMenu();
			_createButton.onClick.RemoveListener(OnCreateBlueprintButtonClicked);
			_backButton.onClick.RemoveListener(OnBackButtonClicked);
		}

		private void SetupColorPicker()
		{
			if (_colorpickerInitialized)
			{
				SetColorpicker(_colorLibrary.Colors[0]);
				return;
			}
			_colorpickerInitialized = true;
			_colorpickerButtons = new Dictionary<Color, ColorpickerButton>();
			for (int i = 0; i < _colorLibrary.Colors.Length; i++)
			{
				ColorpickerButton colorpickerButton = UnityEngine.Object.Instantiate(_colorpickerButtonPrefab, _colorpickerParent);
				if (i == 0)
				{
					_currentColorButton = colorpickerButton;
					_currentColor = _colorLibrary.Colors[i];
				}
				colorpickerButton.IsSelected = i == 0;
				colorpickerButton.SetColor(_colorLibrary.Colors[i]);
				colorpickerButton.OnColorChanged = (Action<ColorpickerButton, Color>)Delegate.Combine(colorpickerButton.OnColorChanged, new Action<ColorpickerButton, Color>(OnSelectedColor));
				_colorpickerButtons.Add(_colorLibrary.Colors[i], colorpickerButton);
			}
		}

		private void OnSelectedColor(ColorpickerButton newButton, Color color)
		{
			_currentColorButton.IsSelected = false;
			_currentColorButton = newButton;
			_currentColor = color;
		}

		private void SetupInputField()
		{
			_inputField.text = string.Empty;
			_inputField.Select();
		}

		private void OnCreateBlueprintButtonClicked()
		{
			string text = _inputField.text.Trim();
			if (Validate(text))
			{
				_errorText.text = "";
				this.OnChangedValues(arg1: true, text, _currentColor);
				GoBack();
			}
			else
			{
				_errorText.text = LocalizationUtility.GetLocalizedText(_invalidInput);
			}
		}

		private bool Validate(string inputText)
		{
			if (string.IsNullOrEmpty(inputText))
			{
				return false;
			}
			string pattern = "[<>;{}[\\]\\\"'\\\\]";
			if (Regex.IsMatch(inputText, pattern))
			{
				return false;
			}
			return true;
		}

		private void OnBackButtonClicked()
		{
			this.OnChangedValues(arg1: false, string.Empty, _currentColor);
			GoBack();
		}
	}
}
