using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalHospitalValue : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionHospitalValue _definition;

		private int _currentHospitalValue;

		public SubGoalHospitalValue(Objective owner, SubGoalDefinitionHospitalValue definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionHospitalValue;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionHospitalValue)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				LevelStatsDatabase levelStatsDatabase = Level.LevelStatsDatabase;
				levelStatsDatabase.OnMonthCompleted = (Action<LevelStatsDatabase.MonthStats>)Delegate.Combine(levelStatsDatabase.OnMonthCompleted, new Action<LevelStatsDatabase.MonthStats>(OnMonthCompleted));
			}
		}

		protected override void OnStart()
		{
			_currentHospitalValue = Level.LevelStatsDatabase.HospitalValue;
			LevelStatsDatabase levelStatsDatabase = Level.LevelStatsDatabase;
			levelStatsDatabase.OnMonthCompleted = (Action<LevelStatsDatabase.MonthStats>)Delegate.Combine(levelStatsDatabase.OnMonthCompleted, new Action<LevelStatsDatabase.MonthStats>(OnMonthCompleted));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			LevelStatsDatabase levelStatsDatabase = Level.LevelStatsDatabase;
			levelStatsDatabase.OnMonthCompleted = (Action<LevelStatsDatabase.MonthStats>)Delegate.Remove(levelStatsDatabase.OnMonthCompleted, new Action<LevelStatsDatabase.MonthStats>(OnMonthCompleted));
			base.OnEnd();
		}

		private void OnMonthCompleted(LevelStatsDatabase.MonthStats monthStats)
		{
			if (ShouldUpdate())
			{
				_currentHospitalValue = monthStats.HospitalValue;
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _currentHospitalValue >= _definition.TargetValue;
		}

		public override float PercentComplete()
		{
			return (float)_currentHospitalValue / (float)_definition.TargetValue;
		}

		public override int Score()
		{
			return _currentHospitalValue;
		}

		public override string ProgressText()
		{
			return ScriptLocalization.Challenges_SubGoals.HospitalValue_Progress_CS.Replace("{[SCORE]}", StringUtils.FormatCurrency(Score()));
		}
	}
}
