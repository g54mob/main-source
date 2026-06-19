using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalOwnPlots : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionOwnPlots _definition;

		private int _numOwned;

		public SubGoalOwnPlots(Objective owner, SubGoalDefinitionOwnPlots definition)
			: base(owner, definition)
		{
			_definition = definition;
			if (_definition.IncludeExisting)
			{
				CalculateNumOwned();
			}
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionOwnPlots;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionOwnPlots)base.Definition;
			if (_definition.IncludeExisting)
			{
				CalculateNumOwned();
			}
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				BuildEvents buildEvents = Level.BuildEvents;
				buildEvents.OnHospitalPlotBuilt = (Action<HospitalPlot>)Delegate.Combine(buildEvents.OnHospitalPlotBuilt, new Action<HospitalPlot>(OnHospitalPlotOwned));
				BuildEvents buildEvents2 = Level.BuildEvents;
				buildEvents2.OnHospitalPlotBought = (Action<HospitalPlot>)Delegate.Combine(buildEvents2.OnHospitalPlotBought, new Action<HospitalPlot>(OnHospitalPlotOwned));
			}
		}

		protected override void OnStart()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnHospitalPlotBuilt = (Action<HospitalPlot>)Delegate.Combine(buildEvents.OnHospitalPlotBuilt, new Action<HospitalPlot>(OnHospitalPlotOwned));
			BuildEvents buildEvents2 = Level.BuildEvents;
			buildEvents2.OnHospitalPlotBought = (Action<HospitalPlot>)Delegate.Combine(buildEvents2.OnHospitalPlotBought, new Action<HospitalPlot>(OnHospitalPlotOwned));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnHospitalPlotBuilt = (Action<HospitalPlot>)Delegate.Remove(buildEvents.OnHospitalPlotBuilt, new Action<HospitalPlot>(OnHospitalPlotOwned));
			BuildEvents buildEvents2 = Level.BuildEvents;
			buildEvents2.OnHospitalPlotBought = (Action<HospitalPlot>)Delegate.Remove(buildEvents2.OnHospitalPlotBought, new Action<HospitalPlot>(OnHospitalPlotOwned));
			base.OnEnd();
		}

		private void OnHospitalPlotOwned(HospitalPlot hospitalPlot)
		{
			if (_definition.IncludeExisting)
			{
				CalculateNumOwned();
			}
			else if (hospitalPlot.Bought && hospitalPlot.Built && (!_definition.EnergyPlotsOnly || hospitalPlot.Definition.EnergyUnitsGenerated > 0))
			{
				_numOwned++;
			}
			UpdateProgress();
		}

		private void CalculateNumOwned()
		{
			_numOwned = 0;
			foreach (HospitalPlot hospitalPlot in Level.WorldState.HospitalPlots)
			{
				if (hospitalPlot.Bought && hospitalPlot.Built && (!_definition.EnergyPlotsOnly || hospitalPlot.Definition.EnergyUnitsGenerated > 0))
				{
					_numOwned++;
				}
			}
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
