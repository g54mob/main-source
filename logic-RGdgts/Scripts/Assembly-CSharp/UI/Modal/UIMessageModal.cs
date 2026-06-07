using System;
using System.Collections.Generic;
using UI.Elements;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;

namespace UI.Modal
{
	public class UIMessageModal : UIModal<UIMessageModalInitParameters>
	{
		private LocalizedString localizedStringTitle;

		private LocalizedString localizedStringMessage;

		[SerializeField]
		private UIText message;

		[SerializeField]
		private UIButton confirmButton;

		private Action OnErrorClose;

		private List<Action> OnTicksSelected;

		[SerializeField]
		private List<UIToggle> ticksList;

		private List<TableEntryReference> tickMessages;

		public override void Init(UIModalManager modalManager, UIMessageModalInitParameters initParameters, List<UIButton> modalOpenButton)
		{
		}

		private void InvokeTicksMethods()
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

		public override void DisablePanel()
		{
		}

		public override void EnablePanel()
		{
		}
	}
}
