namespace Kitchen
{
	public struct MenuAction
	{
		public MainMenuAction Action;

		public PauseMenuAction PauseAction;

		public bool SkipAnimation;

		public INetworkTarget Target;

		public MenuAction(MainMenuAction action, bool skip_animation = false)
		{
			Action = action;
			PauseAction = PauseMenuAction.Null;
			SkipAnimation = skip_animation;
			Target = null;
		}

		public MenuAction(PauseMenuAction action)
		{
			Action = MainMenuAction.Null;
			PauseAction = action;
			SkipAnimation = false;
			Target = null;
		}

		public static implicit operator MenuAction(MainMenuAction action)
		{
			return new MenuAction(action);
		}

		public static implicit operator MenuAction(PauseMenuAction action)
		{
			return new MenuAction(action);
		}
	}
}
