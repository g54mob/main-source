using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.PlacementValidators;
using Data.Operator;
using Logic.Factory.Blueprint;
using UnityEngine;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "Factory/Validators/CanOverrideLowObjects", fileName = "CanOverrideLowObjects", order = 0)]
	public class CanOverrideLowObjects : FactoryObjectPlacementValidator
	{
		[SerializeField]
		private List<FactoryObjectData> _lowObjects;

		public override bool IsValidPosition(FactoryObjectData factoryObjectData, Vector3Int blueprintPosition, Vector3Int position, int rotation, FactoryLayer placementLayer, FactoryLayer terrainLayer, int createdId, Blueprint blueprint = null, bool isBeingMoved = false, BlueprintElement element = null)
		{
			FactoryObject objectAt = placementLayer.GetObjectAt(position);
			if (objectAt != null && (!_lowObjects.Contains(objectAt.FactoryObjectData) || objectAt.NonChangable))
			{
				return false;
			}
			return true;
		}
	}
}
