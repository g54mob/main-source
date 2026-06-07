using System;
using System.Collections.Generic;
using Factory;
using Motorways;

namespace NotificationService.Events
{
	[Factory.Serializable(1)]
	public class PlayedMap : INotificationEventTypeWithData, INotificationEventType, INotificationEventTypeQuery
	{
		public MapDefinition.CityNames Map;

		public string QueryName => "PlayedMap";

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

		public bool Matches(INotificationEventType eventType, DateTime onDate)
		{
			if (eventType is INotificationEventTypeWithData eventTypeWithData)
			{
				return DataMatches(eventTypeWithData);
			}
			return false;
		}

		public override string ToString()
		{
			return $"PlayedMap-{Map.ToString()}";
		}

		public bool DataMatches(INotificationEventTypeWithData eventTypeWithData)
		{
			if (eventTypeWithData is PlayedMap playedMap)
			{
				return Map == playedMap.Map;
			}
			return false;
		}
	}
}
