using System;
using System.Collections.Generic;
using UI.Elements;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;

namespace UI.Modal
{
	public class UIRenameModal : UIModal<UIRenameModalInitParameters>
	{
		public UIInputField nameBar;

		private TableReference tableRef;

		private TableEntryReference placeholder;

		public UIButton confirmButton;

		public UIButton closeButton;

		private LocalizedString localizedString;

		public UIText message;

		private List<string> existingNames;

		private Action<string> OnClickAction;

		private Action OnCloseModal;

		private bool sameNameAllowed;

		public bool replaceName;

		public override void Init(UIModalManager modalManager, UIRenameModalInitParameters initParameters, List<UIButton> modalOpenButton)
		{
		}

		private void MyOnClick(string name)
		{
		}

		private void CheckSameNameDesired(bool confirm, string name)
		{
		}

		private void ValueChangeCheck()
		{
		}

		public override void OnClose()
		{
		}

		public override void Set()
		{
		}

		public void OpenDialog()
		{
		}

		public string GetName()
		{
			return null;
		}

		public override void DisablePanel()
		{
		}

		public override void EnablePanel()
		{
		}
	}
}
