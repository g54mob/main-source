using I2.Loc;
using UnityEngine;

namespace TH20.UI
{
	public class PatientTabReputationPanel : OverviewMenuTabPanel
	{
		[SerializeField]
		private PanelItemProgressBar _overallReputation;

		[SerializeField]
		private PanelItemProgressBar _medical;

		[SerializeField]
		private PanelItemProgressBar _patients;

		[SerializeField]
		private PanelItemProgressBar _prices;

		[SerializeField]
		private PanelItemProgressBar _staff;

		[SerializeField]
		private PanelItemProgressBar _publicity;

		[SerializeField]
		private TooltipSpawner _overallReputationTooltip;

		[SerializeField]
		private TooltipSpawner _medicalReputationTooltip;

		[SerializeField]
		private TooltipSpawner _patientsReputationTooltip;

		[SerializeField]
		private TooltipSpawner _pricesReputationTooltip;

		[SerializeField]
		private TooltipSpawner _staffReputationTooltip;

		[SerializeField]
		private TooltipSpawner _publicityReputationTooltip;

		private ReputationTracker _reputationTracker;

		public void SetupReputationTracker(ReputationTracker reputationTracker)
		{
			_reputationTracker = reputationTracker;
			Refresh();
		}

		public override void Setup(OverviewMenuTab theTabRoot)
		{
			base.Setup(theTabRoot);
			if (_overallReputationTooltip != null)
			{
				_overallReputationTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = GetTooltipText(ScriptLocalization.Menu_Overview_Menu_Patients_Tooltips.ReputationOverall_CS, _overallReputation.Progress);
				});
			}
			if (_medicalReputationTooltip != null)
			{
				_medicalReputationTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = GetTooltipText(ScriptLocalization.Menu_Overview_Menu_Patients_Tooltips.ReputationMedical_CS, _medical.Progress);
				});
			}
			if (_patientsReputationTooltip != null)
			{
				_patientsReputationTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = GetTooltipText(ScriptLocalization.Menu_Overview_Menu_Patients_Tooltips.ReputationPatients_CS, _patients.Progress);
				});
			}
			if (_pricesReputationTooltip != null)
			{
				_pricesReputationTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = GetTooltipText(ScriptLocalization.Menu_Overview_Menu_Patients_Tooltips.ReputationPrices_CS, _prices.Progress);
				});
			}
			if (_staffReputationTooltip != null)
			{
				_staffReputationTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = GetTooltipText(ScriptLocalization.Menu_Overview_Menu_Patients_Tooltips.ReputationStaff_CS, _staff.Progress);
				});
			}
			if (_publicityReputationTooltip != null)
			{
				_publicityReputationTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = GetTooltipText(ScriptLocalization.Menu_Overview_Menu_Patients_Tooltips.ReputationPublicity_CS, _publicity.Progress);
				});
			}
		}

		protected override void Refresh()
		{
			if (_reputationTracker != null)
			{
				if ((bool)_overallReputation)
				{
					_overallReputation.Progress = _reputationTracker.OverallReputation;
				}
				if ((bool)_medical)
				{
					_medical.Progress = _reputationTracker.MedicalReputation;
				}
				if ((bool)_patients)
				{
					_patients.Progress = _reputationTracker.PatientReputation;
				}
				if ((bool)_prices)
				{
					_prices.Progress = _reputationTracker.PriceReputation;
				}
				if ((bool)_staff)
				{
					_staff.Progress = _reputationTracker.StaffReputation;
				}
				if ((bool)_publicity)
				{
					_publicity.Progress = _reputationTracker.SpecialReputation;
				}
			}
		}

		public override void UpdateProgressBars()
		{
			base.UpdateProgressBars();
			if ((bool)_overallReputation)
			{
				_overallReputation.CheckUpdateProgressBarWidth();
			}
			if ((bool)_medical)
			{
				_medical.CheckUpdateProgressBarWidth();
			}
			if ((bool)_patients)
			{
				_patients.CheckUpdateProgressBarWidth();
			}
			if ((bool)_prices)
			{
				_prices.CheckUpdateProgressBarWidth();
			}
			if ((bool)_staff)
			{
				_staff.CheckUpdateProgressBarWidth();
			}
			if ((bool)_publicity)
			{
				_publicity.CheckUpdateProgressBarWidth();
			}
		}

		private string GetTooltipText(string inLocText, float inValue)
		{
			return inLocText.Replace("{[REPUTATION]}", GetLocRepStatusString(inValue)).Replace("{[VALUE]}", StringUtils.FormatPercentageValue(inValue));
		}

		private string GetLocRepStatusString(float inValue)
		{
			string text = "";
			if (inValue < 0.2f)
			{
				return ScriptLocalization.Tooltip.Reputation_ProgressBar_VeryPoor_CS;
			}
			if (inValue < 0.4f)
			{
				return ScriptLocalization.Tooltip.Reputation_ProgressBar_Poor_CS;
			}
			if (inValue < 0.6f)
			{
				return ScriptLocalization.Tooltip.Reputation_ProgressBar_Fine_CS;
			}
			if (inValue < 0.8f)
			{
				return ScriptLocalization.Tooltip.Reputation_ProgressBar_Good_CS;
			}
			return ScriptLocalization.Tooltip.Reputation_ProgressBar_Great_CS;
		}
	}
}
