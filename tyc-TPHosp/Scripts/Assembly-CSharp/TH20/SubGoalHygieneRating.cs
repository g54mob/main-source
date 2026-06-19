using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalHygieneRating : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionHygieneRating _definition;

		private readonly HospitalAttributeMap _hygieneMap;

		private float _currentRating;

		public SubGoalHygieneRating(Objective owner, SubGoalDefinitionHygieneRating definition)
			: base(owner, definition)
		{
			_definition = definition;
			_hygieneMap = Level.WorldState.HospitalAttributeMaps[2];
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionHygieneRating;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionHygieneRating)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				HospitalAttributeMap hygieneMap = _hygieneMap;
				hygieneMap.OnMapUpdated = (Action)Delegate.Combine(hygieneMap.OnMapUpdated, new Action(OnHygieneUpdated));
				HospitalAttributeMap hygieneMap2 = _hygieneMap;
				hygieneMap2.OnCharacterUpdated = (Action)Delegate.Combine(hygieneMap2.OnCharacterUpdated, new Action(OnHygieneUpdated));
			}
		}

		protected override void OnStart()
		{
			HospitalAttributeMap hygieneMap = _hygieneMap;
			hygieneMap.OnMapUpdated = (Action)Delegate.Combine(hygieneMap.OnMapUpdated, new Action(OnHygieneUpdated));
			HospitalAttributeMap hygieneMap2 = _hygieneMap;
			hygieneMap2.OnCharacterUpdated = (Action)Delegate.Combine(hygieneMap2.OnCharacterUpdated, new Action(OnHygieneUpdated));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			HospitalAttributeMap hygieneMap = _hygieneMap;
			hygieneMap.OnMapUpdated = (Action)Delegate.Remove(hygieneMap.OnMapUpdated, new Action(OnHygieneUpdated));
			HospitalAttributeMap hygieneMap2 = _hygieneMap;
			hygieneMap2.OnCharacterUpdated = (Action)Delegate.Remove(hygieneMap2.OnCharacterUpdated, new Action(OnHygieneUpdated));
			base.OnEnd();
		}

		private void OnHygieneUpdated()
		{
			if (ShouldUpdate())
			{
				_currentRating = GameAlgorithms.CalculateHygieneEnvironmentRating(Level);
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _currentRating >= _definition.Rating;
		}

		public override float PercentComplete()
		{
			return _currentRating / _definition.Rating;
		}

		public override int Score()
		{
			return (int)_currentRating;
		}

		public override string ProgressText()
		{
			return ScriptLocalization.Challenges_SubGoals.Hygiene_Progress_CS.Replace("{[RATING]}", StringUtils.FormatPercentageValue(_currentRating / 100f));
		}
	}
}
