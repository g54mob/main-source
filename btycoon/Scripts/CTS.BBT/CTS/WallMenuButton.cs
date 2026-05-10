using System;

namespace CTS
{
	public class WallMenuButton : InterfaceButton
	{
		public static WallMenuButton Instance { get; private set; }

		public static event Action OnWallMenuButtonClicked;

		protected override void Awake()
		{
			base.Awake();
			Instance = this;
		}

		protected override void OnButtonClick()
		{
			base.OnButtonClick();
			WallMenuButton.OnWallMenuButtonClicked?.Invoke();
		}

		private void OnDestroy()
		{
			Instance = null;
		}
	}
}
