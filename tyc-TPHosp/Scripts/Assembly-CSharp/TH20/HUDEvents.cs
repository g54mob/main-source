using System;

namespace TH20
{
	public class HUDEvents : MustCallDestroy, IGameEventsBase
	{
		public Action<InspectorMenu, Character> OnInspectorOpen;

		public Action<InspectorMenu, Room> OnInspectorOpenRoom;

		public Action OnInspectorClose;

		public Action<MenuBase> OnMenuOpen;

		public Action<MenuBase> OnMenuClose;

		public Action OnOptionsMenuOpen;

		public Action OnOptionsMenuClose;

		public void Initialise(bool isGlobalHUD)
		{
			if (isGlobalHUD)
			{
				GameEventsRegistry.RegisterGlobalEvent(this);
			}
			else
			{
				GameEventsRegistry.RegisterLevelEvent(this);
			}
		}

		public void VerifyEvents()
		{
			OnInspectorOpen.VerifyIsNull();
			OnInspectorOpenRoom.VerifyIsNull();
			OnInspectorClose.VerifyIsNull();
			OnMenuOpen.VerifyIsNull();
			OnMenuClose.VerifyIsNull();
			OnOptionsMenuOpen.VerifyIsNull();
			OnOptionsMenuClose.VerifyIsNull();
		}
	}
}
