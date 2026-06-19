using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalStaffMorale : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionStaffMorale _definition;

		private float _currentAverage;

		public SubGoalStaffMorale(Objective owner, SubGoalDefinitionStaffMorale definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionStaffMorale;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionStaffMorale)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				Level.AddTimelineUpdateListener(OnTimelineUpdate);
			}
		}

		protected override void OnStart()
		{
			Level.AddTimelineUpdateListener(OnTimelineUpdate);
			base.OnStart();
			UpdateProgress();
		}

		protected override void OnEnd()
		{
			Level.RemoveTimelineUpdateListener(OnTimelineUpdate);
			base.OnEnd();
		}

		protected override bool HasCompleted()
		{
			return Score() >= _definition.TargetPercentage;
		}

		public override float PercentComplete()
		{
			return (float)Score() / (float)_definition.TargetPercentage;
		}

		public override int Score()
		{
			return Mathf.RoundToInt(_currentAverage * 100f);
		}

		public override string ProgressText()
		{
			return ScriptLocalization.Challenges_SubGoals.StaffMorale_Progress_CS.Replace("{[CURRENT]}", StringUtils.FormatPercentageValue(_currentAverage));
		}

		private void OnTimelineUpdate(int day, int month, int year)
		{
			if (ShouldUpdate())
			{
				_currentAverage = Level.CharacterManager.StaffMorale;
				UpdateProgress();
			}
		}
	}
}
