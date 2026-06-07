#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Buildings;
using UnityEngine;
using Utils;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Set Custom Crane Positions", fileName = "SetCustomCranePositions", order = 22)]
	public class SetCustomCranePositionsSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private Vector3Int _buildingPosition;

		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private List<PositionAndDirection> _customCranePositions;

		[SerializeField]
		private List<Vector3Int> _customCranePickupPositions;

		public override void Execute()
		{
			if (_factoryLayer.TryGetObjectAt(_buildingPosition, out var factoryObject))
			{
				Dictionary<Vector3Int, Vector3Int> dictionary = new Dictionary<Vector3Int, Vector3Int>();
				foreach (PositionAndDirection customCranePosition in _customCranePositions)
				{
					dictionary.Add(customCranePosition.Position, customCranePosition.Direction);
				}
				factoryObject.GetFactoryObjectBehaviour<BuildingCranesBehaviour>().ForcePossibleCranePositions(dictionary);
				factoryObject.GetFactoryObjectBehaviour<BuildingCranesBehaviour>().ForcePossibleCranePickupPositions(_customCranePickupPositions);
			}
			else
			{
				this.LogError($"Could not find a building at {_buildingPosition}", "Execute", 33);
			}
		}
	}
}
