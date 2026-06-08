namespace TwitchLib.Client.Models.Builders
{
	public sealed class SubscriberBuilder : SubscriberBaseBuilder, IBuilder<Subscriber>, IFromIrcMessageBuilder<Subscriber>
	{
		private SubscriberBuilder()
		{
		}

		public new static SubscriberBuilder Create()
		{
			return new SubscriberBuilder();
		}

		public Subscriber BuildFromIrcMessage(FromIrcMessageBuilderDataObject fromIrcMessageBuilderDataObject)
		{
			return new Subscriber(fromIrcMessageBuilderDataObject.Message);
		}

		Subscriber IBuilder<Subscriber>.Build()
		{
			return (Subscriber)Build();
		}

		public override SubscriberBase Build()
		{
			return new Subscriber(base.Badges, base.BadgeInfo, base.ColorHex, base.Color, base.DisplayName, base.EmoteSet, base.Id, base.Login, base.SystemMessage, base.MessageId, base.MsgParamCumulativeMonths, base.MsgParamStreakMonths, base.MsgParamShouldShareStreak, base.ParsedSystemMessage, base.ResubMessage, base.SubscriptionPlan, base.SubscriptionPlanName, base.RoomId, base.UserId, base.IsModerator, base.IsTurbo, base.IsSubscriber, base.IsPartner, base.TmiSentTs, base.UserType, base.RawIrc, base.Channel);
		}
	}
}
