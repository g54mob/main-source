using System;

namespace Doozy.Engine.UI
{
	[Serializable]
	public class UIDrawerMessage : Message
	{
		public UIDrawer Drawer;

		public UIDrawerBehaviorType Type;

		public UIDrawerMessage(UIDrawer drawer, UIDrawerBehaviorType type)
		{
		}
	}
}
