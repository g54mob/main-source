public class QuestStoneWeapon : Weapon
{
	public override void UpdateTic()
	{
		base.UpdateTic();
		AchievementController.singleton.ReportQuestStoneUsed();
	}
}
