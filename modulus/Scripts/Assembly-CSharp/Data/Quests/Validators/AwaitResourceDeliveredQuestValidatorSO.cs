using Data.FactoryFloor.Resources;
using Data.Statistics;
using Events.FactoryFloor;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Await Resource Delivered", fileName = "AwaitResourceDelivered", order = 11)]
	public class AwaitResourceDeliveredQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private StatisticsSO _statisticsSO;

		[SerializeField]
		private ResourceDataSO _resourceData;

		[SerializeField]
		private int _targetResourcesDelivered = 1;

		[SerializeField]
		private ResourceDeliveredEventSO _resourceDelivered;

		private bool _isSetup;

		private bool _hasDeliveredEnough;

		public override bool IsValid()
		{
			if (!_isSetup)
			{
				_isSetup = true;
				_hasDeliveredEnough = HasDeliveredEnoughResources(_resourceData, _targetResourcesDelivered);
				if (!_hasDeliveredEnough)
				{
					_resourceDelivered.RegisterInline(OnResourceDelivered);
				}
			}
			return _hasDeliveredEnough;
		}

		private void OnResourceDelivered(Resource _)
		{
			_hasDeliveredEnough = HasDeliveredEnoughResources(_resourceData, _targetResourcesDelivered);
		}

		private bool HasDeliveredEnoughResources(ResourceDataSO resourceData, int targetResourcesDelivered)
		{
			return _statisticsSO.GetDeliveredStatistic(resourceData.ID) >= targetResourcesDelivered;
		}

		public override void Reset()
		{
			_hasDeliveredEnough = false;
			_isSetup = false;
			_resourceDelivered.UnRegisterInline(OnResourceDelivered);
		}
	}
}
