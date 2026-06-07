using Data.FactoryFloor.Resources;
using Data.Objectives.Validators;
using Data.Statistics;
using UnityEngine;

[CreateAssetMenu(menuName = "Objectives/Validators/ResourceDelivered", fileName = "ResourceDelivered")]
public class ResourceDeliveredObjectiveValidatorSO : AbstractObjectiveValidator
{
	[SerializeField]
	private StatisticsSO _statisticsSO;

	[SerializeField]
	private ResourceDataSO _resourceData;

	[SerializeField]
	private int _targetResourcesDelivered = 1;

	public override bool IsValid()
	{
		return HasDeliveredEnoughResources(_resourceData, _targetResourcesDelivered);
	}

	private bool HasDeliveredEnoughResources(ResourceDataSO resourceData, int targetResourcesDelivered)
	{
		return _statisticsSO.GetDeliveredStatistic(resourceData.ID) >= targetResourcesDelivered;
	}
}
