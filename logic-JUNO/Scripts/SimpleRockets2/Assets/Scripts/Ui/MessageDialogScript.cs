using System;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui
{
	public class MessageDialogScript : ModApi.Ui.MessageDialogScript
	{
		private int _buttonTextMaxLines = 1;

		private Button _cancelButton;

		private XmlElement _cancelLabel;

		private bool _extraWide;

		private XmlElement _label;

		private TextMeshProUGUI _labelText;

		private int _maxLines;

		private Button _middleButton;

		private XmlElement _middleLabel;

		private Button _okayButton;

		private XmlElement _okayButtonElement;

		private XmlElement _okayLabel;

		private XmlElement _panel;

		public override int ButtonTextMaxLines
		{
			get
			{
				return _buttonTextMaxLines;
			}
			set
			{
				_buttonTextMaxLines = value;
				RectTransform component = _cancelButton.GetComponent<RectTransform>();
				RectTransform component2 = _middleButton.GetComponent<RectTransform>();
				RectTransform component3 = _okayButton.GetComponent<RectTransform>();
				int num = Mathf.Max(30, 24 * value);
				component.sizeDelta = new Vector2(component.sizeDelta.x, num);
				component2.sizeDelta = new Vector2(component2.sizeDelta.x, num);
				component3.sizeDelta = new Vector2(component3.sizeDelta.x, num);
			}
		}

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

		public override bool ExtraWide
		{
			get
			{
				return _extraWide;
			}
			set
			{
				_extraWide = value;
				XmlElement elementByInternalId = _panel.GetElementByInternalId("dialog-panel");
				if (_extraWide)
				{
					elementByInternalId.AddClass("extra-wide");
				}
				else
				{
					elementByInternalId.RemoveClass("extra-wide");
				}
			}
		}

		public bool IsTextDirty { get; set; }

		public override int MaxLines
		{
			get
			{
				return _maxLines;
			}
			set
			{
				_maxLines = value;
				IsTextDirty = true;
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
				IsTextDirty = true;
				_label.SetAndApplyAttribute("text", value);
			}
		}

		public override string MiddleButtonText
		{
			get
			{
				return _middleLabel.GetAttribute("text");
			}
			set
			{
				_middleLabel.SetAttribute("text", value);
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

		public override string TruncationMessage { get; set; }

		public override bool UseDangerButtonStyle
		{
			get
			{
				return _okayButtonElement.HasClass("btn-danger");
			}
			set
			{
				if (value)
				{
					_okayButtonElement.AddClass("btn-danger");
				}
				else
				{
					_okayButtonElement.RemoveClass("btn-danger");
				}
			}
		}

		public static MessageDialogScript Create(MessageDialogType type, Transform parent, bool fadeIn = true)
		{
			return Game.Instance.UserInterface.CreateDialog("Ui/Xml/MessageDialog", parent, delegate(MessageDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			}, delegate(MessageDialogScript d)
			{
				d.MessageDialogType = type;
			}, fadeIn);
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

		protected override void Start()
		{
			base.Start();
			_panel.Show();
		}

		protected virtual void Update()
		{
			if (Game.Instance.UserInterface.ActiveDialog != this)
			{
				return;
			}
			if (IsTextDirty)
			{
				IsTextDirty = false;
				_labelText.ForceMeshUpdate();
				if (_maxLines != 0 && _labelText.textInfo.lineCount > _maxLines)
				{
					int firstCharacterIndex = _labelText.textInfo.lineInfo[_maxLines].firstCharacterIndex;
					string text = MessageText.Remove(firstCharacterIndex);
					text = text + Environment.NewLine + (TruncationMessage ?? "<<Truncated>>");
					_label.SetAndApplyAttribute("text", text);
				}
			}
			if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) && base.MessageDialogType != MessageDialogType.Okay)
			{
				OnCancelClicked();
			}
			else if (UnityEngine.Input.GetKeyDown(KeyCode.Return) || UnityEngine.Input.GetKeyDown(KeyCode.KeypadEnter))
			{
				OnOkayClicked();
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
			_label = xmlLayout.GetElementById("label-text");
			_labelText = _label.GetComponent<TextMeshProUGUI>();
			_cancelButton = xmlLayout.GetElementById<Button>("cancel-button");
			_middleButton = xmlLayout.GetElementById<Button>("middle-button");
			_okayButtonElement = xmlLayout.GetElementById("okay-button");
			_okayButton = _okayButtonElement.GetComponent<Button>();
			_cancelLabel = xmlLayout.GetElementById("cancel-button-text");
			_okayLabel = xmlLayout.GetElementById("okay-button-text");
			_middleLabel = xmlLayout.GetElementById("middle-button-text");
			if (base.MessageDialogType == MessageDialogType.Okay)
			{
				_cancelButton.gameObject.SetActive(value: false);
				_okayButtonElement.AddClass("lower-center");
				_okayButtonElement.ApplyAttributesRecursive();
			}
			else if (base.MessageDialogType == MessageDialogType.ThreeButtons)
			{
				xmlLayout.GetElementById("middle-button").SetActive(active: true);
				_panel.AddClass("three-buttons");
			}
			else if (base.MessageDialogType == MessageDialogType.NoButtons)
			{
				_cancelButton.gameObject.SetActive(value: false);
				_okayButton.gameObject.SetActive(value: false);
				_middleButton.gameObject.SetActive(value: false);
			}
			_cancelButton.onClick.AddListener(delegate
			{
				OnCancelClicked();
			});
			_middleButton.onClick.AddListener(delegate
			{
				OnMiddleClicked();
			});
			_okayButton.onClick.AddListener(delegate
			{
				OnOkayClicked();
			});
			if (!base.FadeInUponStart)
			{
				_panel.SetAndApplyAttribute("showAnimation", "None");
			}
			_panel.SetAttribute("active", "false");
		}

		private void OnMiddleClicked()
		{
			if (!RaiseMiddleClickedEvent())
			{
				Close();
			}
		}

		private void OnOkayClicked()
		{
			if (!RaiseOkayClickedEvent())
			{
				Close();
			}
		}
	}
}
