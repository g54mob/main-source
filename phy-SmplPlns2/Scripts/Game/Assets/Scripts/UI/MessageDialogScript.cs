using System;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.UI
{
	public class MessageDialogScript : PanelDialogScript
	{
		public delegate void MessageDialogDelegate(MessageDialogScript messageDialog);

		private ButtonWidget _cancelButton;

		private TextWidget _cancelLabel;

		private bool _extraWide;

		private TextWidget _label;

		private int _maxLines;

		private MessageDialogType _messageDialogType;

		private ButtonWidget _middleButton;

		private TextWidget _middleLabel;

		private ButtonWidget _okayButton;

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

		public bool ExtraWide
		{
			get
			{
				return _extraWide;
			}
			set
			{
				_extraWide = value;
				Widget widget = base.Panel.FindWidget("panel");
				if (_extraWide)
				{
					widget.AddClass("dialog-wide");
				}
				else
				{
					widget.RemoveClass("dialog-wide");
				}
			}
		}

		public bool IsTextDirty { get; set; }

		public int MaxLines
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

		public MessageDialogType MessageDialogType
		{
			get
			{
				return _messageDialogType;
			}
			set
			{
				_messageDialogType = value;
				if (_messageDialogType == MessageDialogType.Okay)
				{
					_okayButton.Visible = true;
					_middleButton.Visible = false;
					_cancelButton.Visible = false;
				}
				else if (_messageDialogType == MessageDialogType.OkayCancel)
				{
					_okayButton.Visible = true;
					_middleButton.Visible = false;
					_cancelButton.Visible = true;
				}
				else if (_messageDialogType == MessageDialogType.ThreeButtons)
				{
					_okayButton.Visible = true;
					_middleButton.Visible = true;
					_cancelButton.Visible = true;
				}
				else if (_messageDialogType == MessageDialogType.NoButtons)
				{
					_okayButton.Visible = false;
					_middleButton.Visible = false;
					_cancelButton.Visible = false;
				}
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
				IsTextDirty = true;
				_label.Text = value;
				_label.Visible = !string.IsNullOrEmpty(value);
			}
		}

		public string MiddleButtonText
		{
			get
			{
				return _middleLabel.Text;
			}
			set
			{
				_middleLabel.Text = value;
			}
		}

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

		public MessageDialogResult? Result { get; protected set; }

		public string TruncationMessage { get; set; }

		public bool UseDangerButtonStyle
		{
			get
			{
				return _okayButton.HasClass("btn-danger");
			}
			set
			{
				if (value)
				{
					_okayButton.AddClass("btn-danger");
				}
				else
				{
					_okayButton.RemoveClass("btn-danger");
				}
			}
		}

		public event MessageDialogDelegate CancelClicked;

		public event MessageDialogDelegate MiddleClicked;

		public event MessageDialogDelegate OkayClicked;

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_label = widget.FindWidget<TextWidget>("label-text");
			_cancelButton = widget.FindWidget<ButtonWidget>("cancel-button");
			_middleButton = widget.FindWidget<ButtonWidget>("middle-button");
			_okayButton = widget.FindWidget<ButtonWidget>("okay-button");
			_cancelLabel = widget.FindWidget<TextWidget>("cancel-button-text");
			_okayLabel = widget.FindWidget<TextWidget>("okay-button-text");
			_middleLabel = widget.FindWidget<TextWidget>("middle-button-text");
			OkayButtonText = "Okay";
			CancelButtonText = "Cancel";
		}

		public WaitUntil WaitForResult()
		{
			return new WaitUntil(() => Result.HasValue);
		}

		protected bool RaiseCancelClickedEvent()
		{
			Result = MessageDialogResult.Cancel;
			if (this.CancelClicked != null)
			{
				this.CancelClicked(this);
				return true;
			}
			return false;
		}

		protected bool RaiseMiddleClickedEvent()
		{
			Result = MessageDialogResult.Middle;
			if (this.MiddleClicked != null)
			{
				this.MiddleClicked(this);
				return true;
			}
			return false;
		}

		protected bool RaiseOkayClickedEvent()
		{
			Result = MessageDialogResult.Okay;
			if (this.OkayClicked != null)
			{
				this.OkayClicked(this);
				return true;
			}
			return false;
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
				_label.TextMeshPro.ForceMeshUpdate();
				if (_maxLines != 0 && _label.TextMeshPro.textInfo.lineCount > _maxLines)
				{
					int firstCharacterIndex = _label.TextMeshPro.textInfo.lineInfo[_maxLines].firstCharacterIndex;
					string text = MessageText.Remove(firstCharacterIndex);
					text = text + System.Environment.NewLine + (TruncationMessage ?? "<<Truncated>>");
					_label.Text = text;
				}
			}
			if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) && MessageDialogType != MessageDialogType.Okay)
			{
				OnCancelClicked(null);
			}
			else if (UnityEngine.Input.GetKeyDown(KeyCode.Return) || UnityEngine.Input.GetKeyDown(KeyCode.KeypadEnter))
			{
				OnOkayClicked(null);
			}
		}

		private void OnCancelClicked(Widget widget)
		{
			if (!RaiseCancelClickedEvent())
			{
				Close();
			}
		}

		private void OnMiddleClicked(Widget widget)
		{
			if (!RaiseMiddleClickedEvent())
			{
				Close();
			}
		}

		private void OnOkayClicked(Widget widget)
		{
			if (!RaiseOkayClickedEvent())
			{
				Close();
			}
		}
	}
}
