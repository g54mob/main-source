using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Notification Descriptor", menuName = "Motorways/Notifications/Notification Descriptor", order = 1)]
public class NotificationDescriptor : ScriptableObject
{
	[Serializable]
	public enum MessageDeliveryMethod
	{
		Consecutive = 0,
		Random = 1
	}

	[Serializable]
	public enum MessageCategory
	{
		Content = 1,
		Challenge = 2
	}

	[Serializable]
	public struct GameNotificationMessage
	{
		[SerializeField]
		[StringEnumSearch(typeof(StringId))]
		private string _title;

		[StringEnumSearch(typeof(StringId))]
		[SerializeField]
		private string _body;

		public StringId Title
		{
			get
			{
				if (Enum.TryParse<StringId>(_title, out var result))
				{
					return result;
				}
				return StringId.None;
			}
			set
			{
				_title = value.ToString();
			}
		}

		public StringId Body
		{
			get
			{
				if (Enum.TryParse<StringId>(_body, out var result))
				{
					return result;
				}
				return StringId.None;
			}
			set
			{
				_body = value.ToString();
			}
		}
	}

	public MessageCategory category;

	public List<GameNotificationMessage> messages = new List<GameNotificationMessage>();

	public MessageDeliveryMethod messageDeliveryMethod;

	public List<NotificationBooleanExpression> conditions = new List<NotificationBooleanExpression>();

	public string Id => base.name;

	public override bool Equals(object other)
	{
		if (other is NotificationDescriptor notificationDescriptor)
		{
			return base.name == notificationDescriptor.name;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Id.GetHashCode();
	}
}
