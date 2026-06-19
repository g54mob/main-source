using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalPromoteStaff : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionPromoteStaff _definition;

		private int _numPromoted;

		public SubGoalPromoteStaff(Objective owner, SubGoalDefinitionPromoteStaff definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionPromoteStaff;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionPromoteStaff)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				CharacterEvents characterEvents = Level.CharacterEvents;
				characterEvents.OnStaffPromoted = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
			}
		}

		protected override void OnStart()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnStaffPromoted = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnStaffPromoted = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
			base.OnEnd();
		}

		private void OnStaffPromoted(Staff staff)
		{
			if (_definition.StaffType == null || staff.Definition == _definition.StaffType.Instance)
			{
				_numPromoted++;
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _numPromoted >= _definition.TargetNumPromotions;
		}

		public override float PercentComplete()
		{
			return (float)_numPromoted / (float)_definition.TargetNumPromotions;
		}

		public override int Score()
		{
			return _numPromoted;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_numPromoted} / {_definition.TargetNumPromotions}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
