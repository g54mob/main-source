using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalThermalComfort : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionThermalComfort _definition;

		private int _current;

		public SubGoalThermalComfort(Objective owner, SubGoalDefinitionThermalComfort definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionThermalComfort;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionThermalComfort)base.Definition;
		}

		protected override void OnStart()
		{
			_current = _definition.CurrentThermalComfort(Level);
			base.OnStart();
		}

		public override void OnUpdate(float timeDelta, float unscaledTimeDelta)
		{
			base.OnUpdate(timeDelta, unscaledTimeDelta);
			int num = _definition.CurrentThermalComfort(Level);
			if (num != _current)
			{
				_current = num;
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _current >= _definition.Target;
		}

		public override float PercentComplete()
		{
			return (float)_current / (float)_definition.Target;
		}

		public override int Score()
		{
			return _current;
		}

		public override string ProgressText()
		{
			return ScriptLocalization.Challenges_SubGoals.ThermalComfort_Progress_CS.Replace("{[SCORE]}", StringUtils.FormatPercentageValue((float)_current / 100f));
		}
	}
}
