using System;
using Factory;
using Motorways;

namespace NotificationService.Events
{
	[Factory.Serializable(1)]
	public class PlayedChallengeQuery : INotificationEventTypeQuery
	{
		public ChallengeType Type;

		public ChallengeTime Time;

		public string QueryName => "PlayedChallenge";

		public bool Matches(INotificationEventType eventType, DateTime onDate)
		{
			if (!(eventType is PlayedChallenge playedChallenge))
			{
				return false;
			}
			if (Type != playedChallenge.Type)
			{
				return false;
			}
			if (Time == ChallengeTime.LastPlayed)
			{
				return true;
			}
			switch (playedChallenge.Type)
			{
			case ChallengeType.Weekly:
			{
				DateTime dateTime2 = ChallengeSystem.StartOfWeek(onDate);
				DateTime dateTime3 = dateTime2;
				if (Time == ChallengeTime.Previous)
				{
					dateTime3 = dateTime2 - TimeSpan.FromDays(7.0);
				}
				return playedChallenge.TimeStart == ChallengeSystem.ToTimestamp(dateTime3.Date);
			}
			case ChallengeType.Daily:
			{
				DateTime date = onDate.Date;
				DateTime dateTime = date;
				if (Time == ChallengeTime.Previous)
				{
					dateTime = date - TimeSpan.FromDays(1.0);
				}
				return playedChallenge.TimeStart == ChallengeSystem.ToTimestamp(dateTime.Date);
			}
			default:
				return false;
			}
		}
	}
}
