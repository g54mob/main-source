using Data.Buildings;
using Data.FactoryFloor;
using Data.FactoryFloor.Resources;
using Events.FactoryFloor.Buildings;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Await Building Received Resource", fileName = "AwaitBuildingReceivedResource", order = 8)]
	public class AwaitBuildingReceivedResourceQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private BuildingReceivedResourceEvent _buildingReceivedResourceEvent;

		[SerializeField]
		private BuildingObjectData _buildingObjectData;

		[SerializeField]
		private ResourceDataSO _resourceToCheckFor;

		[SerializeField]
		private FactoryLayer _factoryLayer;

		private bool _isSetup;

		private bool _eventWasCalled;

		public override bool IsValid()
		{
			if (!_isSetup)
			{
				if (CheckIfAlreadyDelivered())
				{
					return true;
				}
				_buildingReceivedResourceEvent.Register(HandleBuildingReceivedResourceEvent);
				_isSetup = true;
			}
			return _eventWasCalled;
		}

		private void HandleBuildingReceivedResourceEvent(BuildingReceivedResourceData buildingReceivedResourceData)
		{
			if (buildingReceivedResourceData.Resource.Data == _resourceToCheckFor && _buildingObjectData == buildingReceivedResourceData.BuildingBehaviour.BuildingObjectData)
			{
				_eventWasCalled = true;
			}
		}

		public override void Reset()
		{
			_isSetup = false;
			_eventWasCalled = false;
			_buildingReceivedResourceEvent?.UnRegister(HandleBuildingReceivedResourceEvent);
		}

		private bool CheckIfAlreadyDelivered()
		{
			foreach (FactoryObject allDistinctObjectList in _factoryLayer.GetAllDistinctObjectLists())
			{
				if (!allDistinctObjectList.HasFactoryObjectBehaviour(out BuildingBehaviour behaviour) || behaviour.BuildingObjectData != _buildingObjectData)
				{
					continue;
				}
				foreach (BuildingConstructionResource buildRequirement in behaviour.BuildRequirements)
				{
					if (!(buildRequirement.ResourceData != _resourceToCheckFor) && buildRequirement.Count > 0)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
