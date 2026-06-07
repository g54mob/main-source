using Data.Buildings;
using Data.FactoryFloor;
using Data.Objectives.Validators;
using UnityEngine;

[CreateAssetMenu(menuName = "Objectives/Validators/BuildingExistsInFactoryLayer", fileName = "BuildingExistsInFactoryLayer")]
public class BuildingExistsInFactoryLayerObjectiveValidatorSO : AbstractObjectiveValidator
{
	[SerializeField]
	private FactoryLayer _factoryLayer;

	[SerializeField]
	private BuildingObjectData _targetBuildingData;

	[SerializeField]
	private int _targetBuildingStage = 1;

	public override bool IsValid()
	{
		return DoesBuildingExist(_targetBuildingData, _targetBuildingStage);
	}

	private bool DoesBuildingExist(BuildingObjectData targetBuildingData, int targetBuildingStage)
	{
		if (targetBuildingData == null)
		{
			return false;
		}
		if (!_factoryLayer.TryGetObjectsFromData(targetBuildingData, out var factoryObjects))
		{
			return false;
		}
		foreach (FactoryObject item in factoryObjects)
		{
			BuildingBehaviour factoryObjectBehaviour = item.GetFactoryObjectBehaviour<BuildingBehaviour>();
			if (factoryObjectBehaviour != null && factoryObjectBehaviour.CurrentBuildingStage >= targetBuildingStage)
			{
				return true;
			}
		}
		return false;
	}
}
