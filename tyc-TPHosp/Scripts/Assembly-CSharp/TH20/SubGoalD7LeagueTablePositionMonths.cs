using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SubGoalD7LeagueTablePositionMonths : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionD7LeagueTablePositionMonths _definition;

		private int _currentPosition;

		private int _consecutiveMonths;

		private int _currentMonth = -1;

		private AmbulanceDepartmentStats _ambulanceDepartmentStats;

		private bool _wasCompletedInPast;

		public SubGoalD7LeagueTablePositionMonths(Objective owner, SubGoalDefinitionD7LeagueTablePositionMonths definition)
			: base(owner, definition)
		{
			_definition = definition;
			_ambulanceDepartmentStats = Level.ChallengeManager.PlayerAmbulanceDepartment.Stats;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionD7LeagueTablePositionMonths;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionD7LeagueTablePositionMonths)base.Definition;
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
			if (_definition != null && _currentMonth != month)
			{
				_currentMonth = month;
				_currentPosition = _ambulanceDepartmentStats.GetMonthlyLeaguePosition(_definition.StatType);
				if (_currentPosition < _definition.TargetPosition)
				{
					_consecutiveMonths++;
				}
				else
				{
					_consecutiveMonths = 0;
				}
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			if (!_definition.OnceCompleteStayComplete || !_wasCompletedInPast)
			{
				return CheckAndSetComplete();
			}
			return true;
		}

		private bool CheckAndSetComplete()
		{
			if (_consecutiveMonths < _definition.TargetConsecutiveMonths)
			{
				return false;
			}
			_wasCompletedInPast = true;
			return true;
		}

		public override float PercentComplete()
		{
			return (float)_consecutiveMonths / (float)_definition.TargetConsecutiveMonths;
		}

		public override int Score()
		{
			return _consecutiveMonths;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_consecutiveMonths} / {_definition.TargetConsecutiveMonths}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
