using System;

namespace Doozy.Engine.UI
{
	[Serializable]
	public class UIViewMessage : Message
	{
		public UIView View;

		public UIViewBehaviorType Type;

		public UIViewMessage(UIView view)
		{
		}

		public UIViewMessage(UIView view, UIViewBehaviorType type)
		{
		}
	}
}
