using Data.FactoryFloor.Resources;
using Data.Statistics;
using Events.FactoryFloor;
using UnityEngine;

namespace Data.Story
{
	[CreateAssetMenu(fileName = "StoryElementResourceDeliveredSO", menuName = "Story/StoryElementResourceDeliveredSO")]
	public class StoryElementResourceDeliveredSO : StoryElementSO
	{
		[SerializeField]
		private StatisticsSO _statisticsSO;

		[SerializeField]
		private ResourceDataSO _resourceData;

		[SerializeField]
		private int _targetResourcesDelivered = 1;

		[SerializeField]
		private ResourceDeliveredEventSO _resourceDelivered;

		public override void Initialize()
		{
			if (HasDeliveredEnoughResources(_resourceData, _targetResourcesDelivered))
			{
				TryExecute();
			}
			else
			{
				_resourceDelivered.RegisterMainThread(OnResourceDelivered);
			}
		}

		private void OnResourceDelivered(Resource resource)
		{
			if (HasDeliveredEnoughResources(_resourceData, _targetResourcesDelivered))
			{
				TryExecute();
				_resourceDelivered.UnRegisterMainThread(OnResourceDelivered);
			}
		}

		private bool HasDeliveredEnoughResources(ResourceDataSO resourceData, int targetResourcesDelivered)
		{
			return _statisticsSO.GetDeliveredStatistic(resourceData.ID) >= targetResourcesDelivered;
		}

		public override void Destroy()
		{
			_resourceDelivered.UnRegisterMainThread(OnResourceDelivered);
		}
	}
}
