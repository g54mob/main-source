using UnityEngine.UI;

public class UINotificationDropdownSimple : UINotificationDropdown
{
	public Text Message;

	public override void SetContent(NotificationMessage msg)
	{
		Message.text = msg.Details;
	}

	public override float GetHeight()
	{
		return Message.preferredHeight + 8f;
	}
}
