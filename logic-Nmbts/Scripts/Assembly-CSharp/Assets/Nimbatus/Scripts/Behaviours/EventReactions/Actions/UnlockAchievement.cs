using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.Achievements;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class UnlockAchievement : NimbatusAction
	{
		public EAchievement Achievement;

		public override void Execute()
		{
			BaseSingleton<AchievementManager>.Instance.UnlockAchievement(Achievement);
		}
	}
}
