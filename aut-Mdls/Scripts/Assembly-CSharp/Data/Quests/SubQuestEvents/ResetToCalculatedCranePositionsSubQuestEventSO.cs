#define ENABLE_DEBUG_ERRORS
#define ENABLE_DEBUG_LOGS
using Data.FactoryFloor;
using Data.FactoryFloor.Buildings;
using UnityEngine;
using Utils;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Reset To Calculated Crane Positions", fileName = "ResetToCalculatedCranePositions", order = 23)]
	public class ResetToCalculatedCranePositionsSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private Vector3Int _buildingPosition;

		[SerializeField]
		private FactoryLayer _factoryLayer;

		public override void Execute()
		{
			if (_factoryLayer.TryGetObjectAt(_buildingPosition, out var factoryObject))
			{
				this.Log($"Reset crane positions of building at {_buildingPosition}", "Execute", 18);
				factoryObject.GetFactoryObjectBehaviour<BuildingCranesBehaviour>().CalculatePossibleCranePositions();
				factoryObject.GetFactoryObjectBehaviour<BuildingCranesBehaviour>().ResetForcedPickupPositions();
			}
			else
			{
				this.LogError($"Could not find a building at {_buildingPosition}", "Execute", 24);
			}
		}
	}
}
