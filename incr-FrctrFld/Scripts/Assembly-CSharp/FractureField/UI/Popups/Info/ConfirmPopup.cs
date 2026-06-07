using System;
using FractureField.UI.Components.Buttons;
using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField.UI.Popups.Info
{
	public class ConfirmPopup : Popup
	{
		public class Options
		{
			public string Title;

			public string Description;

			public string ConfirmText;

			public string CancelText;

			public bool CloseOnConfirm;

			public Action OnConfirm;

			public Action OnCancel;

			public Action OnFinally;

			public bool HideButtons;

			public bool HideConfirmButton;

			public bool HideCancelButton;

			public bool CloseOnOverlayClick;
		}

		[Header("References")]
		[SerializeField]
		private RText _title;

		[SerializeField]
		private RText _description;

		[SerializeField]
		private RButtonComponent _confirmButton;

		[SerializeField]
		private RButtonComponent _cancelButton;

		private Options _options;

		public virtual void Open(Options options)
		{
		}

		public void ClickedConfirm()
		{
		}

		public void ClickedCancel()
		{
		}
	}
}
