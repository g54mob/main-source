using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class HospitalReputationMenu : MenuBase
	{
		[SerializeField]
		private ProgressBar _overallReputationProgressBar;

		[SerializeField]
		private ProgressBar _medicalProgressBar;

		[SerializeField]
		private ProgressBar _patientsProgressBar;

		[SerializeField]
		private ProgressBar _pricesProgressBar;

		[SerializeField]
		private ProgressBar _staffProgressBar;

		[SerializeField]
		private ProgressBar _publicityProgressBar;

		[SerializeField]
		private Transform _medicalRowTransform;

		[SerializeField]
		private GameObject _illnessReputationListItemPrefab;

		private ReputationTracker _reputationTracker;

		private Dictionary<IllnessDefinition, IllnessReputationListItem> _illnessListItems = new Dictionary<IllnessDefinition, IllnessReputationListItem>();

		public void Setup(ReputationTracker reputationTracker)
		{
			_reputationTracker = reputationTracker;
			Refresh();
		}

		protected override void Update()
		{
			base.Update();
			Refresh();
		}

		public void Refresh()
		{
			_overallReputationProgressBar.Progress = _reputationTracker.OverallReputation;
			_overallReputationProgressBar.SetColorFromGradient(Color.red, Color.yellow, Color.green);
			_medicalProgressBar.Progress = _reputationTracker.MedicalReputation;
			_medicalProgressBar.SetColorFromGradient(Color.red, Color.yellow, Color.green);
			_patientsProgressBar.Progress = _reputationTracker.PatientReputation;
			_patientsProgressBar.SetColorFromGradient(Color.red, Color.yellow, Color.green);
			_pricesProgressBar.Progress = _reputationTracker.PriceReputation;
			_pricesProgressBar.SetColorFromGradient(Color.red, Color.yellow, Color.green);
			_staffProgressBar.Progress = _reputationTracker.StaffReputation;
			_staffProgressBar.SetColorFromGradient(Color.red, Color.yellow, Color.green);
			_publicityProgressBar.Progress = _reputationTracker.SpecialReputation;
			_publicityProgressBar.SetColorFromGradient(Color.red, Color.yellow, Color.green);
			foreach (KeyValuePair<IllnessDefinition, ReputationTracker.IllnessRecord> illnessReputation in _reputationTracker.IllnessReputations)
			{
				IllnessDefinition key = illnessReputation.Key;
				ReputationTracker.IllnessRecord value = illnessReputation.Value;
				if (!_illnessListItems.TryGetValue(key, out var value2))
				{
					GameObject obj = Object.Instantiate(_illnessReputationListItemPrefab, base.transform, worldPositionStays: false);
					obj.transform.SetSiblingIndex(_medicalRowTransform.GetSiblingIndex() + 1);
					value2 = obj.GetComponent<IllnessReputationListItem>();
					value2.Label.text = key.Name.Translation;
					_illnessListItems[key] = value2;
				}
				value2.ProgressBar.Progress = value.Normalised;
				value2.ProgressBar.SetColorFromGradient(Color.red, Color.yellow, Color.green);
			}
		}
	}
}
