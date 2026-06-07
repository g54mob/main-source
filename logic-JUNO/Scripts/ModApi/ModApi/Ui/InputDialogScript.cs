using System.Collections.Generic;
using UnityEngine;

namespace ModApi.Ui
{
	public abstract class InputDialogScript : DialogScript
	{
		public delegate void InputDialogDelegate(InputDialogScript inputDialog);

		public virtual string CancelButtonText { get; set; }

		public virtual string InputPlaceholderText { get; set; }

		public virtual string InputText { get; set; }

		public List<char> InvalidCharacters { get; protected set; }

		public virtual int MaxLength { get; set; }

		public virtual string MessageText { get; set; }

		public bool Modal { get; set; } = true;

		public virtual string OkayButtonText { get; set; }

		public InputDialogResult? Result { get; protected set; }

		public event InputDialogDelegate CancelClicked;

		public event InputDialogDelegate OkayClicked;

		public WaitUntil WaitForResult()
		{
			return new WaitUntil(() => Result.HasValue);
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
	}
}
