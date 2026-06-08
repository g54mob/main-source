namespace Kitchen
{
	public class ReachDayAchievement : AchievementManager
	{
		protected string AchievementIdentifier = string.Empty;

		private int CheckedDay = -1;

		protected override string Identifier => AchievementIdentifier;

		protected override bool SkipRateLimit => true;

		protected override void OnUpdate()
		{
			if (Require<SDay>(out var comp) && comp.Day != CheckedDay)
			{
				if (comp.Day >= 20)
				{
					AchievementIdentifier = "DAY_20";
					Unlock();
				}
				if (comp.Day >= 25)
				{
					AchievementIdentifier = "DAY_25";
					Unlock();
				}
				if (comp.Day >= 30)
				{
					AchievementIdentifier = "DAY_30";
					Unlock();
				}
				CheckedDay = comp.Day;
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
