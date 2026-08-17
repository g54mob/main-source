using System;
using Doozy.Engine.UI.Animation;

namespace Doozy.Engine.UI;

[Serializable]
public class UIPopupMessage : Message
{
	public UIPopup Popup;

	public AnimationType AnimationType;

	public UIPopupMessage(UIPopup popup)
	{
		Popup = popup;
		AnimationType = AnimationType.Undefined;
	}

	public UIPopupMessage(UIPopup popup, AnimationType animationType)
	{
		Popup = popup;
		AnimationType = animationType;
	}
}
