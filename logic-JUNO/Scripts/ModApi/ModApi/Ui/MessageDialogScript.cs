using UnityEngine;

namespace ModApi.Ui
{
	public abstract class MessageDialogScript : DialogScript
	{
		public delegate void MessageDialogDelegate(MessageDialogScript messageDialog);

		public virtual int ButtonTextMaxLines { get; set; }

		public virtual string CancelButtonText { get; set; }

		public virtual bool ExtraWide { get; set; }

		public virtual int MaxLines { get; set; }

		public MessageDialogType MessageDialogType { get; protected set; }

		public virtual string MessageText { get; set; }

		public virtual string MiddleButtonText { get; set; }

		public virtual string OkayButtonText { get; set; }

		public MessageDialogResult? Result { get; protected set; }

		public virtual string TruncationMessage { get; set; }

		public virtual bool UseDangerButtonStyle { get; set; }

		public event MessageDialogDelegate CancelClicked;

		public event MessageDialogDelegate MiddleClicked;

		public event MessageDialogDelegate OkayClicked;

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
	}
}
