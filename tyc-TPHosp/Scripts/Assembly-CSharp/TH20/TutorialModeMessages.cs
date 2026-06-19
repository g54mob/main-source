namespace TH20
{
	public class TutorialModeMessages : TutorialMode
	{
		private MessagesMenu _messagesMenu;

		public override void Enter()
		{
			_messagesMenu = Level.HUD.FindMenu<MessagesMenu>();
		}

		public override void Destroy()
		{
			if (_messagesMenu != null)
			{
				_messagesMenu.ShowTutorialHighlight(show: false);
			}
			base.Destroy();
		}

		public override void Update()
		{
			if (!(_messagesMenu == null))
			{
				int notificationCount = _messagesMenu.GetNotificationCount();
				_messagesMenu.ShowTutorialHighlight(notificationCount > 0);
			}
		}
	}
}
