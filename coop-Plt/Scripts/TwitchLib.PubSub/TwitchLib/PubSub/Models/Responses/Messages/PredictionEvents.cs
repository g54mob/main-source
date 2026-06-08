using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using TwitchLib.PubSub.Enums;
using TwitchLib.PubSub.Extensions;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
	public class PredictionEvents : MessageData
	{
		public PredictionType Type { get; protected set; }

		public Guid Id { get; protected set; }

		public string ChannelId { get; protected set; }

		public DateTime? CreatedAt { get; protected set; }

		public DateTime? LockedAt { get; protected set; }

		public DateTime? EndedAt { get; protected set; }

		public ICollection<Outcome> Outcomes { get; protected set; } = new List<Outcome>();

		public PredictionStatus Status { get; protected set; }

		public string Title { get; protected set; }

		public Guid? WinningOutcomeId { get; protected set; }

		public int PredictionTime { get; protected set; }

		public PredictionEvents(string jsonStr)
		{
			JObject jObject = JObject.Parse(jsonStr);
			Type = (PredictionType)Enum.Parse(typeof(PredictionType), jObject.SelectToken("type").ToString().Replace("-", ""), ignoreCase: true);
			JToken jToken = jObject.SelectToken("data.event");
			Id = Guid.Parse(jToken.SelectToken("id").ToString());
			ChannelId = jToken.SelectToken("channel_id").ToString();
			CreatedAt = (jToken.SelectToken("created_at").IsEmpty() ? ((DateTime?)null) : new DateTime?(DateTime.Parse(jToken.SelectToken("created_at").ToString())));
			EndedAt = (jToken.SelectToken("ended_at").IsEmpty() ? ((DateTime?)null) : new DateTime?(DateTime.Parse(jToken.SelectToken("ended_at").ToString())));
			LockedAt = (jToken.SelectToken("locked_at").IsEmpty() ? ((DateTime?)null) : new DateTime?(DateTime.Parse(jToken.SelectToken("locked_at").ToString())));
			Status = (PredictionStatus)Enum.Parse(typeof(PredictionStatus), jToken.SelectToken("status").ToString().Replace("_", ""), ignoreCase: true);
			Title = jToken.SelectToken("title").ToString();
			WinningOutcomeId = (jToken.SelectToken("winning_outcome_id").IsEmpty() ? ((Guid?)null) : new Guid?(Guid.Parse(jToken.SelectToken("winning_outcome_id").ToString())));
			PredictionTime = int.Parse(jToken.SelectToken("prediction_window_seconds").ToString());
			foreach (JToken item in jToken.SelectToken("outcomes").Children())
			{
				Outcome outcome = new Outcome
				{
					Id = Guid.Parse(item.SelectToken("id").ToString()),
					Color = item.SelectToken("color").ToString(),
					Title = item.SelectToken("title").ToString(),
					TotalPoints = long.Parse(item.SelectToken("total_points").ToString()),
					TotalUsers = long.Parse(item.SelectToken("total_users").ToString())
				};
				foreach (JToken item2 in item.SelectToken("top_predictors").Children())
				{
					outcome.TopPredictors.Add(new Outcome.Predictor
					{
						DisplayName = item2.SelectToken("user_display_name").ToString(),
						Points = int.Parse(item2.SelectToken("points").ToString()),
						UserId = item2.SelectToken("user_id").ToString()
					});
				}
				Outcomes.Add(outcome);
			}
		}
	}
}
