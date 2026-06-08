using System;
using Newtonsoft.Json;
using TwitchLib.Api.V5.Models.Users;

namespace TwitchLib.Api.V5.Models.Subscriptions
{
	public class Subscription
	{
		[JsonProperty(PropertyName = "_id")]
		public string Id { get; protected set; }

		[JsonProperty(PropertyName = "created_at")]
		public DateTime CreatedAt { get; protected set; }

		[JsonProperty(PropertyName = "sub_plan")]
		public string SubPlan { get; protected set; }

		[JsonProperty(PropertyName = "sub_plan_name")]
		public string SubPlanName { get; protected set; }

		[JsonProperty(PropertyName = "user")]
		public User User { get; protected set; }
	}
}
