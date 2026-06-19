using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalBuyPlots : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionBuyPlots _definition;

		private int _numOwned;

		public SubGoalBuyPlots(Objective owner, SubGoalDefinitionBuyPlots definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionBuyPlots;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionBuyPlots)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				BuildEvents buildEvents = Level.BuildEvents;
				buildEvents.OnHospitalPlotBought = (Action<HospitalPlot>)Delegate.Combine(buildEvents.OnHospitalPlotBought, new Action<HospitalPlot>(OnHospitalPlotOwned));
			}
		}

		protected override void OnStart()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnHospitalPlotBought = (Action<HospitalPlot>)Delegate.Combine(buildEvents.OnHospitalPlotBought, new Action<HospitalPlot>(OnHospitalPlotOwned));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnHospitalPlotBought = (Action<HospitalPlot>)Delegate.Remove(buildEvents.OnHospitalPlotBought, new Action<HospitalPlot>(OnHospitalPlotOwned));
			base.OnEnd();
		}

		private void OnHospitalPlotOwned(HospitalPlot hospitalPlot)
		{
			if (!_definition.EnergyPlotsOnly || hospitalPlot.Definition.EnergyUnitsGenerated > 0)
			{
				_numOwned = Level.WorldState.HospitalMaps.Count;
			}
			UpdateProgress();
		}

		protected override bool HasCompleted()
		{
			return _numOwned >= _definition.PlotCount;
		}

		public override float PercentComplete()
		{
			return (float)_numOwned / (float)_definition.PlotCount;
		}

		public override int Score()
		{
			return _numOwned;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_numOwned} / {_definition.PlotCount}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
