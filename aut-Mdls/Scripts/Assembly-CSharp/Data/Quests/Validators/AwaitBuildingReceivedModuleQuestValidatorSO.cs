using Data.FactoryFloor.Resources;
using Data.Shapes;
using Events.FactoryFloor.Buildings;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Await Building Received Module", fileName = "AwaitBuildingReceivedModule", order = 8)]
	public class AwaitBuildingReceivedModuleQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private BuildingReceivedResourceEvent _buildingReceivedResourceEvent;

		[SerializeField]
		private ShapeDataSO _moduleToCheckFor;

		private bool _isSetup;

		private bool _eventWasCalled;

		public override bool IsValid()
		{
			if (!_isSetup)
			{
				_buildingReceivedResourceEvent.Register(HandleBuildingReceivedModuleEvent);
				_isSetup = true;
			}
			return _eventWasCalled;
		}

		private void HandleBuildingReceivedModuleEvent(BuildingReceivedResourceData buildingReceivedResourceData)
		{
			if (buildingReceivedResourceData.Resource is ShapeResource shapeResource && _moduleToCheckFor.Data.RotationIndependantHash.Contains(shapeResource.ShapeData.GetShapeHash()))
			{
				_eventWasCalled = true;
			}
		}

		public override void Reset()
		{
			_isSetup = false;
			_eventWasCalled = false;
			_buildingReceivedResourceEvent?.UnRegister(HandleBuildingReceivedModuleEvent);
		}
	}
}
