using System;
using System.Collections.Generic;
using Factory;
using Motorways;

namespace NotificationService.Events
{
	[Factory.Serializable(1)]
	public class GameOvered : INotificationEventTypeWithData, INotificationEventType, INotificationEventTypeQuery
	{
		public MapDefinition.CityNames Map;

		public string QueryName => "GameOvered";

		public bool InitFromJson(JSON.Dictionary json)
		{
			if (!json.ContainsKey("Map"))
			{
				return false;
			}
			return Enum.TryParse<MapDefinition.CityNames>(json.GetString("Map"), ignoreCase: true, out Map);
		}

		public void ToJson(ref Dictionary<string, object> json)
		{
			json["Map"] = Map.ToString();
		}

		public bool DataMatches(INotificationEventTypeWithData eventTypeWithData)
		{
			if (eventTypeWithData is GameOvered gameOvered)
			{
				return Map == gameOvered.Map;
			}
			return false;
		}

		public override string ToString()
		{
			return $"GameOvered-{Map.ToString()}";
		}

		public bool Matches(INotificationEventType eventType, DateTime onDate)
		{
			if (eventType is INotificationEventTypeWithData eventTypeWithData)
			{
				return DataMatches(eventTypeWithData);
			}
			return false;
		}
	}
}
