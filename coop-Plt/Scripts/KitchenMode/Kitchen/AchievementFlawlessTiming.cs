namespace Kitchen
{
	public class AchievementFlawlessTiming : WatchTriggerAchievement<CFlawlessTimingEvent>
	{
		public const float RequiredTime = 1f;

		protected override string Identifier => "FLAWLESS_TIMING";

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
