using System;
using System.Collections.Generic;
using UI.Elements;
using UnityEngine.Localization;

namespace UI.Modal
{
	public class UIConfirmImportAssetModal : UIModal<UIConfirmImportAssetModalInitParameters>
	{
		private LocalizedString localizedStringTitle;

		private LocalizedString localizedStringMessage;

		public UIText message;

		public UIButton confirmButton;

		public UIButton closeButton;

		private Action<bool, Asset> OnConfirm;

		private Asset asset;

		public override void Init(UIModalManager modalManager, UIConfirmImportAssetModalInitParameters initParameters, List<UIButton> modalOpenButton)
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

		public void Confirm(bool confirm, Asset asset)
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
