using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.Achievements;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class UnlockHitAndRunAchievement : NimbatusAction
	{
		public static float KilledBees;

		private static float StartTime;

		public override void Execute()
		{
			if (Time.time - StartTime > 120f)
			{
				KilledBees = 0f;
				StartTime = Time.time;
				return;
			}
			KilledBees += 1f;
			if (KilledBees >= 10f)
			{
				BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.HitAndRun);
			}
		}
	}
}
