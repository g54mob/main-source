using System;

namespace Doozy.Engine.UI;

[Serializable]
public class UIViewMessage : Message
{
	public UIView View;

	public UIViewBehaviorType Type;

	public UIViewMessage(UIView view)
	{
		View = view;
		Type = UIViewBehaviorType.Unknown;
	}

	public UIViewMessage(UIView view, UIViewBehaviorType type)
	{
		View = view;
		Type = type;
	}
}
