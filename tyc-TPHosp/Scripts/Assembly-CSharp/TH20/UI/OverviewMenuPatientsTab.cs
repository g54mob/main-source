using UnityEngine;

namespace TH20.UI
{
	public class OverviewMenuPatientsTab : OverviewMenuTab
	{
		[SerializeField]
		private PatientTabOverviewPanel _theOverviewPanel;

		[SerializeField]
		private PatientTabReputationPanel _theReputationPanel;

		[SerializeField]
		private PanelItemValueViewer _curesViewer;

		[SerializeField]
		private PanelItemValueViewer _deathsViewer;

		[SerializeField]
		private PanelItemValueViewer _fatalitiesViewer;

		[SerializeField]
		private PanelItemValueViewer _ineffectivesViewer;

		[SerializeField]
		private PanelItemValueViewer _rageQuitViewer;

		[SerializeField]
		private PanelItemValueViewer _sentHomeViewer;

		[SerializeField]
		private PanelItemValueViewer _totalTreatmentsViewer;

		[SerializeField]
		private PanelItemValueViewer _totalVisitorsViewer;

		private int _lastCures = -1;

		private int _lastDeaths = -1;

		private int _lastFatalities = -1;

		private int _lastIneffectives = -1;

		private int _lastRageQuits = -1;

		private int _lastSentHomes = -1;

		private int _lastTotalTreatments = -1;

		private int _lastTotalVisitors = -1;

		public override void Setup(OverviewMenu theOverviewRoot, OverviewMenu.Mode theMode)
		{
			base.Setup(theOverviewRoot, theMode);
			_theOverviewPanel.SetupAdvisor(theOverviewRoot.TheAdvisorScene);
			_theReputationPanel.SetupReputationTracker(theOverviewRoot.TheLevel.ReputationTracker);
			Refresh(force: true);
		}

		public override void Activate(bool state)
		{
			base.Activate(state);
			if (state)
			{
				base.TheOverviewMenu.SetStandardAdvisor();
				_theOverviewPanel.AdvisorVisible = true;
			}
			else
			{
				_theOverviewPanel.ResetAdvisor();
			}
		}

		public void Update()
		{
			Refresh(force: false);
			_theReputationPanel.UpdateProgressBars();
		}

		private void Refresh(bool force)
		{
			if (_levelStatsDatabase != null)
			{
				LevelStatsDatabase.CumulativeLevelStats cumulativeLevelStats = _levelStatsDatabase.GetCumulativeLevelStats();
				if ((bool)_totalVisitorsViewer && (_lastTotalVisitors != cumulativeLevelStats.NumberOfPatients || force))
				{
					_lastTotalVisitors = cumulativeLevelStats.NumberOfPatients;
					_totalVisitorsViewer.SetValueText(_lastTotalVisitors);
				}
				if ((bool)_curesViewer && (_lastCures != cumulativeLevelStats.NumberOfTreatmentCures || force))
				{
					_lastCures = cumulativeLevelStats.NumberOfTreatmentCures;
					_curesViewer.SetValueText(_lastCures);
				}
				if ((bool)_ineffectivesViewer && (_lastIneffectives != cumulativeLevelStats.NumberOfTreatmentIneffectives || force))
				{
					_lastIneffectives = cumulativeLevelStats.NumberOfTreatmentIneffectives;
					_ineffectivesViewer.SetValueText(_lastIneffectives);
				}
				if ((bool)_fatalitiesViewer && (_lastFatalities != cumulativeLevelStats.NumberOfTreatmentFatals || force))
				{
					_lastFatalities = cumulativeLevelStats.NumberOfTreatmentFatals;
					_fatalitiesViewer.SetValueText(_lastFatalities);
				}
				int num = _lastCures + _lastIneffectives + _lastFatalities;
				if ((bool)_totalTreatmentsViewer && (_lastTotalTreatments != num || force))
				{
					_lastTotalTreatments = num;
					_totalTreatmentsViewer.SetValueText(_lastTotalTreatments);
				}
				if ((bool)_deathsViewer && (_lastDeaths != cumulativeLevelStats.NumberOfPatientDeaths || force))
				{
					_lastDeaths = cumulativeLevelStats.NumberOfPatientDeaths;
					_deathsViewer.SetValueText(_lastDeaths);
				}
				if ((bool)_rageQuitViewer && (_lastRageQuits != cumulativeLevelStats.NumberOfPatientRageQuits || force))
				{
					_lastRageQuits = cumulativeLevelStats.NumberOfPatientRageQuits;
					_rageQuitViewer.SetValueText(_lastRageQuits);
				}
				if ((bool)_sentHomeViewer && (_lastSentHomes != cumulativeLevelStats.NumberOfPatientsSentHome || force))
				{
					_lastSentHomes = cumulativeLevelStats.NumberOfPatientsSentHome;
					_sentHomeViewer.SetValueText(_lastSentHomes);
				}
			}
		}
	}
}
