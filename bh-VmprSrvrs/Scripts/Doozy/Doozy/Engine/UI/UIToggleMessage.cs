using System;

namespace Doozy.Engine.UI
{
	[Serializable]
	public class UIToggleMessage : Message
	{
		public UIToggle Toggle;

		public UIToggleState ToggleState;

		public UIToggleBehaviorType Type;

		public UIToggleMessage(UIToggleState toggleState, UIToggleBehaviorType type)
		{
		}

		public UIToggleMessage(UIToggle toggle, UIToggleState toggleState, UIToggleBehaviorType type)
		{
		}
	}
}
