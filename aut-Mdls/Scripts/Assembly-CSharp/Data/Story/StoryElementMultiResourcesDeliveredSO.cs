using System;
using System.Collections.Generic;
using Data.FactoryFloor.Resources;
using Data.Statistics;
using Events.FactoryFloor;
using UnityEngine;

namespace Data.Story
{
	[CreateAssetMenu(fileName = "StoryElementMultiResourcesDeliveredSO", menuName = "Story/StoryElementMultiResourcesDeliveredSO")]
	public class StoryElementMultiResourcesDeliveredSO : StoryElementSO
	{
		[Serializable]
		private struct ResourceAndAmount
		{
			public ResourceDataSO Resource;

			public int Amount;
		}

		[SerializeField]
		private StatisticsSO _statisticsSO;

		[SerializeField]
		private List<ResourceAndAmount> _resourceData;

		[SerializeField]
		private ResourceDeliveredEventSO _resourceDelivered;

		public override void Initialize()
		{
			if (HasDeliveredEnoughResources())
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
			if (HasDeliveredEnoughResources())
			{
				TryExecute();
				_resourceDelivered.UnRegisterMainThread(OnResourceDelivered);
			}
		}

		private bool HasDeliveredEnoughResources()
		{
			foreach (ResourceAndAmount resourceDatum in _resourceData)
			{
				if (_statisticsSO.GetDeliveredStatistic(resourceDatum.Resource.ID) < resourceDatum.Amount)
				{
					return false;
				}
			}
			return true;
		}

		public override void Destroy()
		{
			_resourceDelivered.UnRegisterMainThread(OnResourceDelivered);
		}
	}
}
