using System;
using System.Collections.Generic;
using UI.Elements;
using UnityEngine.Localization;

namespace UI.Modal
{
	public class UIPublishTicksModal : UIModal<UITicksModalInitParameters>
	{
		private LocalizedString localizedStringTitle;

		private LocalizedString localizedStringMessage;

		private List<LocalizedString> localizedTicksMessage;

		public UIText message;

		public UIButton confirmButton;

		public UIButton closeButton;

		public List<UIToggle> ticksToggles;

		private Action<List<UIToggle>> OnConfirm;

		private Action OnCancel;

		public override void Init(UIModalManager modalManager, UITicksModalInitParameters initParameters, List<UIButton> modalOpenButton)
		{
		}

		private void CheckToggles()
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
