using System;
using System.Collections.Generic;
using Jundroo.Juicy.Widgets;
using Jundroo.Juicy.Widgets.Extra;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
	public class InputDialogScript : PanelDialogScript
	{
		public delegate void InputDialogDelegate(InputDialogScript inputDialog);

		private TextWidget _cancelLabel;

		private TextWidget _errorText;

		private InputDialogStyle _inputDialogStyle;

		private InputWidget _inputField;

		private TextWidget _label;

		private TextWidget _okayLabel;

		public string CancelButtonText
		{
			get
			{
				return _cancelLabel.Text;
			}
			set
			{
				_cancelLabel.Text = value;
			}
		}

		public InputDialogStyle InputDialogStyle
		{
			get
			{
				return _inputDialogStyle;
			}
			set
			{
				_inputDialogStyle = value;
				if (_inputDialogStyle == InputDialogStyle.Large)
				{
					base.Panel.AddClass("input-dialog-wide");
				}
				else
				{
					base.Panel.RemoveClass("input-dialog-wide");
				}
			}
		}

		public InputWidget InputField => _inputField;

		public string InputPlaceholderText
		{
			get
			{
				return _inputField.Placeholder.text;
			}
			set
			{
				_inputField.Placeholder.text = value;
			}
		}

		public string InputText
		{
			get
			{
				return _inputField.Text;
			}
			set
			{
				_inputField.Text = value;
			}
		}

		public List<char> InvalidCharacters { get; protected set; }

		public int MaxLength
		{
			get
			{
				return _inputField.Input.characterLimit;
			}
			set
			{
				_inputField.Input.characterLimit = value;
			}
		}

		public string MessageText
		{
			get
			{
				return _label.Text;
			}
			set
			{
				_label.Text = value;
				_label.Visible = !string.IsNullOrEmpty(value);
			}
		}

		public bool Modal { get; set; } = true;

		public string OkayButtonText
		{
			get
			{
				return _okayLabel.Text;
			}
			set
			{
				_okayLabel.Text = value;
			}
		}

		public InputDialogResult? Result { get; protected set; }

		public bool SelectTextOnStart { get; set; } = true;

		public string ValidationErrorMessage { get; set; }

		public InputWidget.ValidationFunctionDelegate ValidationFunction
		{
			get
			{
				return _inputField.ValidationFunction;
			}
			set
			{
				_inputField.ValidationFunction = value;
			}
		}

		public string ValidationRegex
		{
			get
			{
				return _inputField.ValidationRegex;
			}
			set
			{
				_inputField.ValidationRegex = value;
			}
		}

		public event InputDialogDelegate CancelClicked;

		public event InputDialogDelegate OkayClicked;

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_inputField = widget.FindWidget<InputWidget>("input");
			_label = widget.FindWidget<TextWidget>("label-text");
			_cancelLabel = widget.FindWidget<TextWidget>("cancel-button-text");
			_okayLabel = widget.FindWidget<TextWidget>("okay-button-text");
			DraggableInputField input = _inputField.Input;
			input.onValidateInput = (TMP_InputField.OnValidateInput)Delegate.Combine(input.onValidateInput, new TMP_InputField.OnValidateInput(OnValidateInput));
			_inputField.Validated += OnValidated;
			_errorText = base.Widget.FindWidget<TextWidget>("validation-error");
			CancelButtonText = "Cancel";
			OkayButtonText = "Okay";
			base.Panel.Animation.ShowComplete += delegate
			{
				if (SelectTextOnStart)
				{
					_inputField.Input.ActivateInputField();
				}
			};
		}

		public WaitUntil WaitForResult()
		{
			return new WaitUntil(() => Result.HasValue);
		}

		protected virtual void Awake()
		{
			InvalidCharacters = new List<char>();
		}

		protected virtual void OnCancelClicked(Widget widget)
		{
			_errorText.Visible = false;
			if (!RaiseCancelClickedEvent())
			{
				Close();
			}
		}

		protected virtual void OnOkayClicked(Widget widget)
		{
			_inputField.Validate();
			if (!_inputField.HasError && !RaiseOkayClickedEvent())
			{
				Close();
			}
		}

		protected bool RaiseCancelClickedEvent()
		{
			Result = InputDialogResult.Cancel;
			if (this.CancelClicked != null)
			{
				this.CancelClicked(this);
				return true;
			}
			return false;
		}

		protected bool RaiseOkayClickedEvent()
		{
			Result = InputDialogResult.Okay;
			if (this.OkayClicked != null)
			{
				this.OkayClicked(this);
				return true;
			}
			return false;
		}

		protected virtual void Update()
		{
			if (Game.Instance.UserInterface.ActiveDialog == this)
			{
				if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
				{
					OnCancelClicked(null);
				}
				else if ((UnityEngine.Input.GetKeyDown(KeyCode.Return) || UnityEngine.Input.GetKeyDown(KeyCode.KeypadEnter)) && InputDialogStyle == InputDialogStyle.Normal)
				{
					OnOkayClicked(null);
				}
			}
		}

		private void OnValidated(InputWidget widget)
		{
			if (!_inputField.HasError)
			{
				_errorText.Visible = false;
			}
			else if (!string.IsNullOrEmpty(ValidationErrorMessage))
			{
				_errorText.Text = ValidationErrorMessage;
				_errorText.Visible = true;
			}
			else if (!string.IsNullOrEmpty(_inputField.ValidationErrorMessage))
			{
				_errorText.Text = _inputField.ValidationErrorMessage;
				_errorText.Visible = true;
			}
		}

		private char OnValidateInput(string text, int charIndex, char addedChar)
		{
			if (InvalidCharacters.Contains(addedChar))
			{
				return '\0';
			}
			return addedChar;
		}
	}
}
