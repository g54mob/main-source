using System;

namespace Doozy.Engine.UI;

[Serializable]
public class UIButtonMessage : Message
{
	public UIButton Button;

	public string ButtonName;

	public UIButtonBehaviorType Type;

	public UIButtonMessage(UIButton button)
	{
		ButtonName = button.ButtonName;
		Button = button;
	}

	public UIButtonMessage(UIButton button, UIButtonBehaviorType type)
	{
		ButtonName = button.ButtonName;
		Button = button;
		Type = type;
	}

	public UIButtonMessage(string buttonName)
	{
		ButtonName = buttonName;
		Button = null;
	}

	public UIButtonMessage(string buttonName, UIButtonBehaviorType type)
	{
		ButtonName = buttonName;
		Button = null;
		Type = type;
	}
}
