using System;

namespace Doozy.Engine.UI
{
	[Serializable]
	public class UIButtonMessage : Message
	{
		public UIButton Button;

		public string ButtonName;

		public UIButtonBehaviorType Type;

		public UIButtonMessage(UIButton button)
		{
		}

		public UIButtonMessage(UIButton button, UIButtonBehaviorType type)
		{
		}

		public UIButtonMessage(string buttonName)
		{
		}

		public UIButtonMessage(string buttonName, UIButtonBehaviorType type)
		{
		}
	}
}
