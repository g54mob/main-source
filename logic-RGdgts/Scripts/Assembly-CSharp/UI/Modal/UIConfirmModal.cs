using System;
using System.Collections.Generic;
using UI.Elements;
using UnityEngine.Localization;

namespace UI.Modal
{
	public class UIConfirmModal : UIModal<UIConfirmModalInitParameters>
	{
		private LocalizedString localizedStringTitle;

		private LocalizedString localizedStringMessage;

		public UIText message;

		public UIButton confirmButton;

		public UIButton closeButton;

		private Action<bool> OnConfirm;

		public override void Init(UIModalManager modalManager, UIConfirmModalInitParameters initParameters, List<UIButton> modalOpenButton)
		{
		}

		public override void Set()
		{
		}

		public override void OnOpen()
		{
		}

		public override void OnClose()
		{
		}

		public void Confirm(bool confirm)
		{
		}

		public override void DisablePanel()
		{
		}

		public override void EnablePanel()
		{
		}
	}
}
