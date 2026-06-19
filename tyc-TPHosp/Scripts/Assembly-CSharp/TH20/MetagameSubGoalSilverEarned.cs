using I2.Loc;
using TH20.EventAwardSilver;
using UnityEngine;

namespace TH20
{
	public class MetagameSubGoalSilverEarned : MetagameObjectiveSubGoal, Interface, IGameEventCallback
	{
		[SerializeField]
		private readonly MetagameSubGoalDefinitionSilverEarned _definition;

		[SerializeField]
		private int _earnedAmount;

		public MetagameSubGoalSilverEarned(Objective owner, MetagameSubGoalDefinitionSilverEarned definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		protected override void OnStart()
		{
			if (Metagame != null)
			{
				Metagame.OnSilverAwarded.AddAndDontSave(this);
			}
			base.OnStart();
		}

		protected override void OnMetagameChanged(Metagame oldMetagame, Metagame newMetagame)
		{
			oldMetagame?.OnSilverAwarded.Remove(this);
			newMetagame?.OnSilverAwarded.AddAndDontSave(this);
		}

		public override void Destroy()
		{
			if (Metagame != null)
			{
				Metagame.OnSilverAwarded.Remove(this);
			}
			base.Destroy();
		}

		public void OnSilverAwardedEvent(int silver)
		{
			_earnedAmount += silver;
			UpdateProgress();
			PlatformStatsAndAchievements.SetStatValue(Stat.SilverEarned, _earnedAmount);
		}

		protected override bool HasCompleted()
		{
			return _earnedAmount >= _definition.TargetAmount;
		}

		public override float PercentComplete()
		{
			return (float)_earnedAmount / (float)_definition.TargetAmount;
		}

		public override int Score()
		{
			return _earnedAmount;
		}

		public override string ProgressText()
		{
			if (Completed())
			{
				return ScriptLocalization.Challenges_SubGoals.Done_CS;
			}
			return ScriptLocalization.Challenges_SubGoals.EarnSilver_Progress_CS.Replace("{[SILVER]}", StringUtils.FormatSilverCurrency(_definition.TargetAmount - _earnedAmount));
		}
	}
}
