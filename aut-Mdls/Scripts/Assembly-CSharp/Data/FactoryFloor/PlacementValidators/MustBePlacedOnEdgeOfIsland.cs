using Data.FactoryFloor.Maps;
using Data.Operator;
using Data.SaveData.PersistentSOs;
using Logic.Factory.Blueprint;
using UnityEngine;

namespace Data.FactoryFloor.PlacementValidators
{
	[CreateAssetMenu(menuName = "Factory/Validators/MustBePlacedOnEdgeOfIsland", fileName = "MustBePlacedOnEdgeOfIsland", order = 0)]
	public class MustBePlacedOnEdgeOfIsland : FactoryObjectPlacementValidator
	{
		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistentSO;

		[SerializeField]
		private bool _invertRotation;

		[SerializeField]
		private bool _checkRotation;

		public override bool IsValidPosition(FactoryObjectData factoryObjectData, Vector3Int blueprintPosition, Vector3Int position, int rotation, FactoryLayer placementLayer, FactoryLayer terrainLayer, int createdId, Blueprint blueprint, bool isBeingMoved = false, BlueprintElement element = null)
		{
			if (_islandLayer.IsEmpty)
			{
				return true;
			}
			if (!_islandLayer.TryGetIslandAtWorldPosition(position, out var islandObject))
			{
				return false;
			}
			if (!_unlockedIslandsPersistentSO.IsIslandUnlocked(islandObject))
			{
				return false;
			}
			GetPositionOnEdges(position, islandObject, out var isOnXMinEdge, out var isOnXMaxEdge, out var isOnZMinEdge, out var isOnZMaxEdge);
			bool num = isOnXMinEdge || isOnXMaxEdge || isOnZMinEdge || isOnZMaxEdge;
			bool flag = !_checkRotation || IsPositionFacingTowardsEdge(rotation, isOnXMinEdge, isOnXMaxEdge, isOnZMinEdge, isOnZMaxEdge);
			return num && flag;
		}

		private bool IsPositionFacingTowardsEdge(int rotation, bool isOnXMinEdge, bool isOnXMaxEdge, bool isOnZMinEdge, bool isOnZMaxEdge)
		{
			rotation = (_invertRotation ? ((rotation + 180) % 360) : (rotation % 360));
			if ((!isOnXMinEdge || rotation != 270) && (!isOnXMaxEdge || rotation != 90) && (!isOnZMinEdge || rotation != 180))
			{
				if (isOnZMaxEdge)
				{
					return rotation == 0;
				}
				return false;
			}
			return true;
		}

		private void GetPositionOnEdges(Vector3Int position, IslandObject islandObject, out bool isOnXMinEdge, out bool isOnXMaxEdge, out bool isOnZMinEdge, out bool isOnZMaxEdge)
		{
			Vector3Int position2 = islandObject.Position;
			Vector2Int size = islandObject.Size;
			int num = size.x / 2;
			int num2 = ((size.x % 2 == 0) ? (-1) : 0);
			int num3 = ((size.y % 2 == 0) ? (-1) : 0);
			int num4 = position2.x - num;
			int num5 = position2.x + num;
			isOnXMinEdge = position.x == num4;
			isOnXMaxEdge = position.x == num5 + num2;
			num = size.y / 2;
			num4 = position2.z - num;
			num5 = position2.z + num;
			isOnZMinEdge = position.z == num4;
			isOnZMaxEdge = position.z == num5 + num3;
		}
	}
}
