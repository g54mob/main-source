using I2.Loc;
using TH20.EventAwardStar;
using UnityEngine;

namespace TH20
{
	public class MetagameSubGoalTotalStars : MetagameObjectiveSubGoal, Interface, IGameEventCallback
	{
		[SerializeField]
		private readonly MetagameSubGoalDefinitionTotalStars _definition;

		[SerializeField]
		private int _earnedAmount;

		public MetagameSubGoalTotalStars(Objective owner, MetagameSubGoalDefinitionTotalStars definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		protected override void OnStart()
		{
			if (Metagame != null)
			{
				Metagame.OnStarAwarded.AddAndDontSave(this);
				_earnedAmount = Metagame.TotalStars();
			}
			base.OnStart();
		}

		protected override void OnMetagameChanged(Metagame oldMetagame, Metagame newMetagame)
		{
			oldMetagame?.OnStarAwarded.Remove(this);
			newMetagame?.OnStarAwarded.AddAndDontSave(this);
		}

		public override void Destroy()
		{
			if (Metagame != null)
			{
				Metagame.OnStarAwarded.Remove(this);
			}
			base.Destroy();
		}

		public void OnStarAwardedEvent(MetagameHospitalRecord.StarIndex starIndex, LevelConfig levelConfig, bool debug)
		{
			_earnedAmount = Metagame.TotalStars();
			UpdateProgress();
			PlatformStatsAndAchievements.SetStatValue(Stat.StarsEarned, _earnedAmount);
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
			string text = ScriptLocalization.Challenges_SubGoals.TotalStars_Progress_CS;
			LocalisationParams.Set("COUNT", _definition.TargetAmount - _earnedAmount);
			LocalisationParams.Localise(ref text);
			return text;
		}
	}
}
