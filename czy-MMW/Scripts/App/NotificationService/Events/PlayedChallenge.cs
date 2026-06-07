using System;
using System.Collections.Generic;
using Factory;

namespace NotificationService.Events
{
	[Factory.Serializable(1)]
	public class PlayedChallenge : INotificationEventTypeWithData, INotificationEventType
	{
		public ChallengeType Type;

		public int TimeStart;

		public bool InitFromJson(JSON.Dictionary json)
		{
			if (!json.ContainsKey("Type") || !json.ContainsKey("TimeStart"))
			{
				return false;
			}
			TimeStart = json.GetInt("TimeStart");
			return Enum.TryParse<ChallengeType>(json.GetString("Type"), ignoreCase: true, out Type);
		}

		public void ToJson(ref Dictionary<string, object> json)
		{
			json["Type"] = Type.ToString();
			json["TimeStart"] = TimeStart;
		}

		public bool DataMatches(INotificationEventTypeWithData eventTypeWithData)
		{
			if (!(eventTypeWithData is PlayedChallenge playedChallenge))
			{
				return false;
			}
			if (Type != playedChallenge.Type)
			{
				return false;
			}
			return TimeStart == playedChallenge.TimeStart;
		}

		public override string ToString()
		{
			return $"PlayedChallenge-{Type.ToString()}";
		}
	}
}
