using System;

namespace Doozy.Engine.UI;

[Serializable]
public class UIDrawerMessage(UIDrawer drawer, UIDrawerBehaviorType type) : Message
{
	public UIDrawer Drawer = drawer;

	public UIDrawerBehaviorType Type = type;
}
