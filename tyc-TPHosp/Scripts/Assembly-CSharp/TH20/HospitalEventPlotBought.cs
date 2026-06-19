using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventPlotBought : HospitalEvent, IHospitalEventFinance
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				BuildEvents buildEvents = _level.BuildEvents;
				buildEvents.OnHospitalPlotBought = (Action<HospitalPlot>)Delegate.Combine(buildEvents.OnHospitalPlotBought, new Action<HospitalPlot>(OnHospitalPlotBought));
			}

			public override void UnregisterEvents()
			{
				BuildEvents buildEvents = _level.BuildEvents;
				buildEvents.OnHospitalPlotBought = (Action<HospitalPlot>)Delegate.Remove(buildEvents.OnHospitalPlotBought, new Action<HospitalPlot>(OnHospitalPlotBought));
			}

			private void OnHospitalPlotBought(HospitalPlot hospitalPlot)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventPlotBought
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					_plotDefinition = hospitalPlot.Definition
				});
			}
		}

		private HospitalPlotDefinition _plotDefinition;

		public override bool HasExpired(GameDate currentDate)
		{
			return false;
		}

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.PlotBought_CS.Replace("{[NAME]}", _plotDefinition.NameLocalised.Translation);
		}

		public int GetFinanceValue()
		{
			return -_plotDefinition.Cost;
		}

		public bool IsFinanceValueValid()
		{
			return GetFinanceValue() != 0;
		}

		public bool ShowOnStatement()
		{
			return true;
		}
	}
}
