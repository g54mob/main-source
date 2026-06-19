using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalGenerateElectricity : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionGenerateElectricity _definition;

		private int _totalElectricity;

		private ChallengeElectricity _electricityChallenge;

		public SubGoalGenerateElectricity(Objective owner, SubGoalDefinitionGenerateElectricity definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionGenerateElectricity;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_ = _electricityChallenge;
			_definition = (SubGoalDefinitionGenerateElectricity)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				RegisterCallbacks();
			}
		}

		protected override void OnStart()
		{
			List<ChallengeElectricity> activeChallengesOfType = Level.ChallengeManager.GetActiveChallengesOfType<ChallengeElectricity>();
			if (activeChallengesOfType.Count > 0)
			{
				using List<ChallengeElectricity>.Enumerator enumerator = activeChallengesOfType.GetEnumerator();
				if (enumerator.MoveNext())
				{
					ChallengeElectricity current = enumerator.Current;
					_electricityChallenge = current;
				}
			}
			_ = _electricityChallenge;
			RegisterCallbacks();
			OnTotalElectricityChanged();
			base.OnStart();
		}

		protected override void OnEnd()
		{
			UnregisterCallbacks();
			base.OnEnd();
		}

		private void RegisterCallbacks()
		{
			if (_electricityChallenge != null)
			{
				_electricityChallenge.OnTotalElectricityChanged.AddListener(OnTotalElectricityChanged);
			}
		}

		private void UnregisterCallbacks()
		{
			if (_electricityChallenge != null)
			{
				_electricityChallenge.OnTotalElectricityChanged.RemoveListener(OnTotalElectricityChanged);
			}
		}

		private void OnTotalElectricityChanged()
		{
			if (_electricityChallenge != null)
			{
				_totalElectricity = _electricityChallenge.TotalElectricity;
				Level.ObjectiveEvents.OnSubGoalUpdated(this);
			}
		}

		protected override bool HasCompleted()
		{
			return _totalElectricity >= _definition.TargetAmount;
		}

		public override float PercentComplete()
		{
			return (float)_totalElectricity / (float)_definition.TargetAmount;
		}

		public override int Score()
		{
			return _totalElectricity;
		}

		public override string ProgressText()
		{
			if (Completed())
			{
				return ScriptLocalization.Challenges_SubGoals.Done_CS;
			}
			return ScriptLocalization.Challenges_SubGoals.ElectricGenerated_Progress_CS.Replace("{[COUNT]}", StringUtils.FormatNumber(_definition.TargetAmount - _totalElectricity));
		}
	}
}
