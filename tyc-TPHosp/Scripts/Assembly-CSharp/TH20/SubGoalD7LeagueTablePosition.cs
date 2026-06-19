using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SubGoalD7LeagueTablePosition : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionD7LeagueTablePosition _definition;

		private int _currentPosition;

		private AmbulanceDepartmentStats _ambulanceDepartmentStats;

		public SubGoalD7LeagueTablePosition(Objective owner, SubGoalDefinitionD7LeagueTablePosition definition)
			: base(owner, definition)
		{
			_definition = definition;
			_ambulanceDepartmentStats = Level.ChallengeManager.PlayerAmbulanceDepartment.Stats;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionD7LeagueTablePosition;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionD7LeagueTablePosition)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				ChallengeManager challengeManager = Level.ChallengeManager;
				challengeManager.OnAmbulanceLeagueUpdated = (Action<int>)Delegate.Combine(challengeManager.OnAmbulanceLeagueUpdated, new Action<int>(OnAmbulanceLeagueUpdated));
			}
		}

		protected override void OnStart()
		{
			ChallengeManager challengeManager = Level.ChallengeManager;
			challengeManager.OnAmbulanceLeagueUpdated = (Action<int>)Delegate.Combine(challengeManager.OnAmbulanceLeagueUpdated, new Action<int>(OnAmbulanceLeagueUpdated));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			ChallengeManager challengeManager = Level.ChallengeManager;
			challengeManager.OnAmbulanceLeagueUpdated = (Action<int>)Delegate.Remove(challengeManager.OnAmbulanceLeagueUpdated, new Action<int>(OnAmbulanceLeagueUpdated));
			base.OnEnd();
		}

		private void OnAmbulanceLeagueUpdated(int month)
		{
			if (_definition != null)
			{
				_currentPosition = _ambulanceDepartmentStats.GetMonthlyLeaguePosition(_definition.StatType);
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _currentPosition < _definition.TargetPosition;
		}

		public override float PercentComplete()
		{
			return 0f;
		}

		public override int Score()
		{
			return _currentPosition;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_currentPosition} / {_definition.TargetPosition}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
