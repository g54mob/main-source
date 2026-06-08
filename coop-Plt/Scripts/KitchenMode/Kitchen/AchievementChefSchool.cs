namespace Kitchen
{
	public class AchievementChefSchool : WatchTriggerAchievement<SPracticeMode>
	{
		public override bool ClearFlag => false;

		protected override string Identifier => "CHEF_SCHOOL";

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
