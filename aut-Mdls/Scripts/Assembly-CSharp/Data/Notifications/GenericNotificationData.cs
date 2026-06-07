using UnityEngine;

namespace Data.Notifications
{
	public class GenericNotificationData : AbstractNotificationData
	{
		public Sprite Sprite;

		public string LocaKey;

		public GenericNotificationData(Sprite sprite, string locaKey)
		{
			Sprite = sprite;
			LocaKey = locaKey;
		}
	}
}
