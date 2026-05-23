using System.Collections.Generic;
using Data.FactoryFloor.Resources;
using Data.Operator;
using UnityEngine;

namespace Utils.Analytics.IntervalHandlers
{
	[CreateAssetMenu(menuName = "General/Analytics/Statistics", fileName = "StatisticsAnalyticsSO", order = 0)]
	public class StatisticsAnalyticsSO : ScriptableObject
	{
		[SerializeField]
		private List<ResourceDataSO> _ignoreResourcesProduced = new List<ResourceDataSO>();

		[SerializeField]
		private List<ResourceDataSO> _ignoreResourcesDelivered = new List<ResourceDataSO>();

		[SerializeField]
		private List<FactoryObjectData> _ignoreFactoryObjectPlaced = new List<FactoryObjectData>();

		public IEnumerable<ResourceDataSO> IgnoreResourcesProduced => _ignoreResourcesProduced;

		public IEnumerable<ResourceDataSO> IgnoreResourcesDelivered => _ignoreResourcesDelivered;

		public IEnumerable<FactoryObjectData> IgnoreFactoryObjectPlaced => _ignoreFactoryObjectPlaced;

		public bool ShouldTrackResourceProduced(ResourceDataSO resourceData)
		{
			return !_ignoreResourcesProduced.Contains(resourceData);
		}

		public bool ShouldTrackResourcesDelivered(ResourceDataSO resourceData)
		{
			return !_ignoreResourcesDelivered.Contains(resourceData);
		}

		public bool ShouldTrackFactoryObjectPlaced(FactoryObjectData resourceData)
		{
			return !_ignoreFactoryObjectPlaced.Contains(resourceData);
		}
	}
}
