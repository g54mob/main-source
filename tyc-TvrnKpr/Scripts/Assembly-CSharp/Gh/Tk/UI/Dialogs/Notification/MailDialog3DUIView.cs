using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.Notification
{
	public class MailDialog3DUIView : BaseNotificationDialog3DUIView
	{
		[SerializeField]
		private TextMeshProI18n _greetings;

		[SerializeField]
		private TextBlock3DUIView _textBlock;

		[SerializeField]
		private TextMeshProI18n _overflowText;

		[SerializeField]
		private TextMeshProI18n _farewell;

		[SerializeField]
		private TextMeshProI18n _postScriptText;

		[SerializeField]
		private TextMeshProI18n _signature;

		[SerializeField]
		private Transform _sealSocket;

		[SerializeField]
		private SpriteRenderer _topImage;

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
