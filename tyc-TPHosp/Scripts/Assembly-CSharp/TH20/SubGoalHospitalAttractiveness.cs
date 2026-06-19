using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalHospitalAttractiveness : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionHospitalAttractiveness _definition;

		private int _currentHospitalAttractiveness;

		public SubGoalHospitalAttractiveness(Objective owner, SubGoalDefinitionHospitalAttractiveness definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionHospitalAttractiveness;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionHospitalAttractiveness)base.Definition;
		}

		protected override void OnStart()
		{
			_currentHospitalAttractiveness = Level.WorldState.GetEnvironmentRating(HospitalAttributeMap.Attribute.Attractiveness);
			base.OnStart();
		}

		public override void OnUpdate(float timeDelta, float unscaledTimeDelta)
		{
			base.OnUpdate(timeDelta, unscaledTimeDelta);
			if (ShouldUpdate())
			{
				int environmentRating = Level.WorldState.GetEnvironmentRating(HospitalAttributeMap.Attribute.Attractiveness);
				if (environmentRating != _currentHospitalAttractiveness)
				{
					_currentHospitalAttractiveness = environmentRating;
					UpdateProgress();
				}
			}
		}

		protected override bool HasCompleted()
		{
			return _currentHospitalAttractiveness >= _definition.TargetAttractiveness;
		}

		public override float PercentComplete()
		{
			return (float)_currentHospitalAttractiveness / (float)_definition.TargetAttractiveness;
		}

		public override int Score()
		{
			return _currentHospitalAttractiveness;
		}

		public override string ProgressText()
		{
			return ScriptLocalization.Challenges_SubGoals.HospitalAttractiveness_Progress_CS.Replace("{[SCORE]}", StringUtils.FormatPercentageValue((float)Score() / 100f));
		}
	}
}
