using System;
using System.Runtime.Serialization;

[Serializable]
public class UIPersistentData
{
	public UINotificationPersistentData[] Notifications;

	[OptionalField(VersionAdded = 2)]
	public UIFlags Flags;

	public UIPersistentData(UIManager uiManager)
	{
		Notifications = ReturnNotificationData(uiManager);
		Flags = uiManager.Flags;
	}

	public void Restore(UIManager uIManager)
	{
		RestoreNotifications(uIManager, Notifications);
		uIManager.Flags = Flags;
	}

	private UINotificationPersistentData[] ReturnNotificationData(UIManager uiManager)
	{
		NotificationData[] array = NotificationData.Notifications.ToArray();
		int num;
		if (array == null || (num = array.Length) == 0)
		{
			return null;
		}
		UINotificationPersistentData[] array2 = new UINotificationPersistentData[num];
		for (int i = 0; i < num; i++)
		{
			array2[i] = new UINotificationPersistentData(array[i]);
		}
		return array2;
	}

	private void RestoreNotifications(UIManager uiManager, UINotificationPersistentData[] data)
	{
		if (data != null)
		{
			int num = data.Length;
			for (int i = 0; i < num; i++)
			{
				data[i].Restore(uiManager);
			}
		}
	}
}
