using System.Collections.Generic;
using UI.Elements;
using UnityEngine.Localization;

namespace UI.Modal
{
	public class SecurityScrollModal : UIModal<UISecurityModalInitParameters>
	{
		private LocalizedString localizedStringTitle;

		private LocalizedString localizedStringMessage;

		public UIText message;

		public UIButton confirmButton;

		public override void Init(UIModalManager modalManager, UISecurityModalInitParameters initParameters, List<UIButton> modalOpenButton)
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
