using System;
using System.Collections.Generic;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui
{
	public class InputDialogScript : ModApi.Ui.InputDialogScript
	{
		private Button _cancelButton;

		private XmlElement _cancelLabel;

		private TMP_InputField _inputField;

		private XmlElement _label;

		private Button _okayButton;

		private XmlElement _okayLabel;

		private XmlElement _panel;

		private XmlElement _placeholderText;

		public override string CancelButtonText
		{
			get
			{
				return _cancelLabel.GetAttribute("text");
			}
			set
			{
				_cancelLabel.SetAttribute("text", value);
			}
		}

		public override string InputPlaceholderText
		{
			get
			{
				return _placeholderText.GetAttribute("text");
			}
			set
			{
				_placeholderText.SetAttribute("text", value);
			}
		}

		public override string InputText
		{
			get
			{
				return _inputField.text;
			}
			set
			{
				_inputField.text = value;
			}
		}

		public override int MaxLength
		{
			get
			{
				return _inputField.characterLimit;
			}
			set
			{
				_inputField.characterLimit = value;
			}
		}

		public override string MessageText
		{
			get
			{
				return _label.GetAttribute("text");
			}
			set
			{
				_label.SetAttribute("text", value);
			}
		}

		public override string OkayButtonText
		{
			get
			{
				return _okayLabel.GetAttribute("text");
			}
			set
			{
				_okayLabel.SetAttribute("text", value);
			}
		}

		public static InputDialogScript Create(Transform parent)
		{
			return Game.Instance.UserInterface.CreateDialog("Ui/Xml/InputDialog", parent, delegate(InputDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			});
		}

		public override void Close()
		{
			base.Close();
			_panel.Hide(recursiveCall: false, delegate
			{
				base.gameObject.SetActive(value: false);
				UnityEngine.Object.Destroy(base.gameObject);
			});
		}

		protected virtual void Awake()
		{
			base.InvalidCharacters = new List<char>();
		}

		protected override void Start()
		{
			base.Start();
			if (!base.Modal)
			{
				_panel.AddClass("non-modal-dialog");
			}
			_inputField.ActivateInputField();
			_panel.Show();
		}

		protected virtual void Update()
		{
			if (Game.Instance.UserInterface.ActiveDialog == this)
			{
				if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
				{
					OnCancelClicked();
				}
				else if (UnityEngine.Input.GetKeyDown(KeyCode.Return) || UnityEngine.Input.GetKeyDown(KeyCode.KeypadEnter))
				{
					OnOkayClicked();
				}
			}
		}

		private void OnCancelClicked()
		{
			if (!RaiseCancelClickedEvent())
			{
				Close();
			}
		}

		private void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_panel = xmlLayout.GetElementById("panel");
			_cancelButton = xmlLayout.GetElementById<Button>("cancel-button");
			_okayButton = xmlLayout.GetElementById<Button>("okay-button");
			_inputField = xmlLayout.GetElementById<TMP_InputField>("input");
			_label = xmlLayout.GetElementById("label-text");
			_placeholderText = xmlLayout.GetElementById("placeholder-text");
			_cancelLabel = xmlLayout.GetElementById("cancel-button-text");
			_okayLabel = xmlLayout.GetElementById("okay-button-text");
			_cancelButton.onClick.AddListener(delegate
			{
				OnCancelClicked();
			});
			_okayButton.onClick.AddListener(delegate
			{
				OnOkayClicked();
			});
			TMP_InputField inputField = _inputField;
			inputField.onValidateInput = (TMP_InputField.OnValidateInput)Delegate.Combine(inputField.onValidateInput, new TMP_InputField.OnValidateInput(OnValidateInput));
			_panel.SetAttribute("active", "false");
		}

		private void OnOkayClicked()
		{
			if (!RaiseOkayClickedEvent())
			{
				Close();
			}
		}

		private char OnValidateInput(string text, int charIndex, char addedChar)
		{
			if (base.InvalidCharacters.Contains(addedChar))
			{
				return '\0';
			}
			return addedChar;
		}
	}
}
