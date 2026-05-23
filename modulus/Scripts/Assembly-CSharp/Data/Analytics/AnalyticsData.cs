using System.Collections.Generic;
using Events;
using UnityEngine;

namespace Data.Analytics
{
	[CreateAssetMenu(menuName = "General/Analytics/Data", fileName = "AnalyticsData", order = 1)]
	public class AnalyticsData : ScriptableObject
	{
		private int _buildingsStarted;

		private int _buildingsCompleted;

		private int _buildingsUpgraded;

		private List<string> _buildingTypesStarted = new List<string>();

		private List<string> _buildingTypesAssembled = new List<string>();

		private List<string> _buildingTypesNotAssembled;

		[SerializeField]
		private BaseEvent _startLoadingSaveEvent;

		[SerializeField]
		private BaseEvent _finishedLoadingSaveEvent;

		private bool _IsCurrentlyLoading;

		public int BuildingsCompleted
		{
			get
			{
				return _buildingsCompleted;
			}
			set
			{
				if (!_IsCurrentlyLoading)
				{
					_buildingsCompleted = value;
				}
			}
		}

		public int BuildingsUpgraded => _buildingsUpgraded;

		public int BuildingsStarted => _buildingsStarted;

		private void OnEnable()
		{
			_startLoadingSaveEvent.Register(DeactivateAnalyticsDuringLoading);
			_finishedLoadingSaveEvent.Register(ActivateAnalyticsDuringLoading);
		}

		private void OnDisable()
		{
			_startLoadingSaveEvent.UnRegister(DeactivateAnalyticsDuringLoading);
			_finishedLoadingSaveEvent.UnRegister(ActivateAnalyticsDuringLoading);
			ResetValues();
		}

		private void DeactivateAnalyticsDuringLoading()
		{
			_IsCurrentlyLoading = true;
		}

		private void ActivateAnalyticsDuringLoading()
		{
			_IsCurrentlyLoading = false;
		}

		private void ResetValues()
		{
			_buildingsStarted = 0;
			_buildingsCompleted = 0;
			_buildingsUpgraded = 0;
			_buildingTypesStarted = new List<string>();
			_buildingTypesAssembled = new List<string>();
			_buildingTypesNotAssembled = new List<string>();
		}

		public void OnStartedBuilding(string buildingName, int currentCitizens)
		{
			if (!_IsCurrentlyLoading)
			{
				AddBuildingTypesStarted(buildingName);
			}
		}

		public void OnStartedUpgrade(string buildingName, string buildingStage, int currentCitizens)
		{
			_ = _IsCurrentlyLoading;
		}

		public void OnFailedUpgrade(string buildingName, string buildingStage, int currentCitizens)
		{
			_ = _IsCurrentlyLoading;
		}

		public void OnUpgradeCompleted(string buildingName, string buildingStage, int currentCitizens)
		{
			_ = _IsCurrentlyLoading;
		}

		public void AddBuildingTypesAssembled(string buildingName)
		{
			if (!_IsCurrentlyLoading)
			{
				_buildingsUpgraded++;
				if (!_buildingTypesAssembled.Contains(buildingName))
				{
					_buildingTypesAssembled.Add(buildingName);
				}
			}
		}

		public List<string> GetBuildingStartedNotAssembled()
		{
			_buildingTypesNotAssembled = new List<string>();
			for (int i = 0; i < _buildingTypesStarted.Count; i++)
			{
				if (!_buildingTypesAssembled.Contains(_buildingTypesStarted[i]))
				{
					_buildingTypesNotAssembled.Add(_buildingTypesStarted[i]);
				}
			}
			return _buildingTypesNotAssembled;
		}

		private void AddBuildingTypesStarted(string buildingName)
		{
			_buildingsStarted++;
			if (!_buildingTypesStarted.Contains(buildingName))
			{
				_buildingTypesStarted.Add(buildingName);
			}
		}
	}
}
