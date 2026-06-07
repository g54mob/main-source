using Gh.Tk.UI.Dialogs.Notification;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class BankruptcyDialog3DUIView : BaseNotificationDialog3DUIView
	{
		[SerializeField]
		private TextBlock3DUIView _contentText;

		protected override void Awake()
		{
		}

		protected override void Closed()
		{
		}

		public override void SetUIData(UINotificationData data)
		{
		}
	}
}
