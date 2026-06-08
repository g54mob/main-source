namespace Kitchen
{
	public class AchievementNewChefPlus : WatchTriggerAchievement<CAchievementNewChefPlusEvent>
	{
		protected override string Identifier => "NEW_CHEF_PLUS";

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
