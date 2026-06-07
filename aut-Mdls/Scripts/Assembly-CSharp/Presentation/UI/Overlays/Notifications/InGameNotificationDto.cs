using System;
using UnityEngine;

namespace Presentation.UI.Overlays.Notifications
{
	public struct InGameNotificationDto
	{
		public InGameNotificationType Type;

		public string LabelText;

		public Sprite Sprite;

		public Action ButtonCallback;

		public string ButtonTextLocaKey;

		public object Identifier;

		public float Duration;

		public InGameObjectivesNotificationDto DeliveriesDto;

		public InGameNotificationDto(InGameNotificationType type = InGameNotificationType.Basic, float duration = 10f, object identifier = null)
		{
			Type = type;
			LabelText = string.Empty;
			Sprite = null;
			ButtonCallback = null;
			ButtonTextLocaKey = string.Empty;
			Duration = duration;
			Identifier = identifier;
			DeliveriesDto = InGameObjectivesNotificationDto.Empty;
		}

		public InGameNotificationDto(string labelText, Sprite sprite = null, Action buttonCallback = null, InGameNotificationType type = InGameNotificationType.Basic, string buttonTextLocaKey = "", object identifier = null)
		{
			Type = type;
			LabelText = labelText;
			Sprite = sprite;
			ButtonCallback = buttonCallback;
			ButtonTextLocaKey = buttonTextLocaKey;
			Duration = 10f;
			Identifier = identifier;
			DeliveriesDto = InGameObjectivesNotificationDto.Empty;
		}

		public InGameNotificationDto(string labelText, Sprite sprite = null, InGameNotificationType type = InGameNotificationType.Basic, float duration = 10f, object identifier = null)
		{
			Type = type;
			LabelText = labelText;
			Sprite = sprite;
			ButtonCallback = null;
			ButtonTextLocaKey = string.Empty;
			Duration = duration;
			Identifier = identifier;
			DeliveriesDto = InGameObjectivesNotificationDto.Empty;
		}

		public InGameNotificationDto(string labelText, Sprite sprite, InGameObjectivesNotificationDto deliveriesNotificationDto, InGameNotificationType type, float duration = 10f, object identifier = null)
		{
			Type = type;
			LabelText = labelText;
			Sprite = sprite;
			ButtonCallback = null;
			ButtonTextLocaKey = string.Empty;
			Duration = duration;
			Identifier = identifier;
			DeliveriesDto = deliveriesNotificationDto;
		}
	}
}
