using System;
using System.Collections.Generic;
using UI.Elements;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace UI.Modal
{
	public class TicksSelectionModal : UIModal<UITicksModalInitParameters>
	{
		private LocalizedString localizedStringTitle;

		private LocalizedString localizedStringMessage;

		private List<LocalizedString> localizedTicksMessage;

		public UIText message;

		public UIButton confirmButton;

		public UIButton closeButton;

		private List<UIToggle> ticksToggles;

		private Action<List<UIToggle>> OnConfirm;

		private Action OnCancel;

		[SerializeField]
		private Transform toggleContent;

		[SerializeField]
		private GameObject toggle;

		[SerializeField]
		private ToggleGroup toggleGroup;

		public override void Init(UIModalManager modalManager, UITicksModalInitParameters initParameters, List<UIButton> modalOpenButton)
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
