using I2.Loc;
using TH20.EventAwardStar;
using UnityEngine;

namespace TH20
{
	public class MetagameSubGoalHospitalStarRating : MetagameObjectiveSubGoal, Interface, IGameEventCallback
	{
		[SerializeField]
		private readonly MetagameSubGoalDefinitionHospitalStarRating _definition;

		[SerializeField]
		private int _currentStarRating;

		public MetagameSubGoalHospitalStarRating(Objective owner, MetagameSubGoalDefinitionHospitalStarRating definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		protected override void OnStart()
		{
			if (Metagame != null)
			{
				Metagame.OnStarAwarded.Add(this);
			}
			base.OnStart();
		}

		protected override void OnMetagameChanged(Metagame oldMetagame, Metagame newMetagame)
		{
			oldMetagame?.OnStarAwarded.Remove(this);
			newMetagame?.OnStarAwarded.Add(this);
		}

		protected override void OnEnd()
		{
			if (Metagame != null)
			{
				Metagame.OnStarAwarded.Remove(this);
			}
			base.OnEnd();
		}

		public void OnStarAwardedEvent(MetagameHospitalRecord.StarIndex starIndex, LevelConfig levelConfig, bool debug)
		{
			if (levelConfig == _definition.LevelConfig.Instance)
			{
				_currentStarRating = (int)(starIndex + 1);
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _currentStarRating >= (int)(_definition.Target + 1);
		}

		public override float PercentComplete()
		{
			return (float)_currentStarRating / ((float)_definition.Target + 1f);
		}

		public override int Score()
		{
			return _currentStarRating;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_currentStarRating} / {(int)(_definition.Target + 1)}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
