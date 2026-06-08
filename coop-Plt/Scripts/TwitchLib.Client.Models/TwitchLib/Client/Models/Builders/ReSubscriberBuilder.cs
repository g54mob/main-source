namespace TwitchLib.Client.Models.Builders
{
	public sealed class ReSubscriberBuilder : SubscriberBaseBuilder, IBuilder<ReSubscriber>, IFromIrcMessageBuilder<ReSubscriber>
	{
		private ReSubscriberBuilder()
		{
		}

		public new static ReSubscriberBuilder Create()
		{
			return new ReSubscriberBuilder();
		}

		public ReSubscriber BuildFromIrcMessage(FromIrcMessageBuilderDataObject fromIrcMessageBuilderDataObject)
		{
			return new ReSubscriber(fromIrcMessageBuilderDataObject.Message);
		}

		ReSubscriber IBuilder<ReSubscriber>.Build()
		{
			return (ReSubscriber)Build();
		}

		public override SubscriberBase Build()
		{
			return new ReSubscriber(base.Badges, base.BadgeInfo, base.ColorHex, base.Color, base.DisplayName, base.EmoteSet, base.Id, base.Login, base.SystemMessage, base.MessageId, base.MsgParamCumulativeMonths, base.MsgParamStreakMonths, base.MsgParamShouldShareStreak, base.ParsedSystemMessage, base.ResubMessage, base.SubscriptionPlan, base.SubscriptionPlanName, base.RoomId, base.UserId, base.IsModerator, base.IsTurbo, base.IsSubscriber, base.IsPartner, base.TmiSentTs, base.UserType, base.RawIrc, base.Channel, base.Months);
		}
	}
}
