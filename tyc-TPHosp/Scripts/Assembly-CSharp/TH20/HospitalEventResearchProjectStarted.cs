using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventResearchProjectStarted : HospitalEvent, IHospitalEventFinance
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				ResearchManager researchManager = _level.ResearchManager;
				researchManager.OnResearchProjectAssigned = (Action<ResearchProject, RoomItem>)Delegate.Combine(researchManager.OnResearchProjectAssigned, new Action<ResearchProject, RoomItem>(OnResearchProjectAssigned));
			}

			public override void UnregisterEvents()
			{
				ResearchManager researchManager = _level.ResearchManager;
				researchManager.OnResearchProjectAssigned = (Action<ResearchProject, RoomItem>)Delegate.Remove(researchManager.OnResearchProjectAssigned, new Action<ResearchProject, RoomItem>(OnResearchProjectAssigned));
			}

			private void OnResearchProjectAssigned(ResearchProject researchProject, RoomItem roomItem)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventResearchProjectStarted
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					_value = -researchProject.Definition.GreenlightCost,
					_projectName = researchProject.Definition.NameLocalised
				});
			}
		}

		private int _value;

		private LocalisedString _projectName;

		public int GetFinanceValue()
		{
			return _value;
		}

		public bool IsFinanceValueValid()
		{
			return GetFinanceValue() != 0;
		}

		public bool ShowOnStatement()
		{
			return true;
		}

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.ResearchProjectStarted_CS.Replace("{[PROJECT]}", _projectName.Translation);
		}
	}
}
