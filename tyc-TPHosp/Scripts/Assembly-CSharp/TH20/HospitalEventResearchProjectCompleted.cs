using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventResearchProjectCompleted : HospitalEvent, IHospitalEventFinance
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				ResearchManager researchManager = _level.ResearchManager;
				researchManager.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Combine(researchManager.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
			}

			public override void UnregisterEvents()
			{
				ResearchManager researchManager = _level.ResearchManager;
				researchManager.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Remove(researchManager.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
			}

			private void OnResearchProjectComplete(ResearchProject researchProject)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventResearchProjectCompleted
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					_money = RewardUtils.GetMoneyValue(researchProject.Definition.Rewards),
					_projectName = researchProject.Definition.NameLocalised
				});
			}
		}

		private int _money;

		private LocalisedString _projectName;

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.ResearchProjectCompleted_CS.Replace("{[PROJECT]}", _projectName.Translation);
		}

		public int GetFinanceValue()
		{
			return _money;
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
