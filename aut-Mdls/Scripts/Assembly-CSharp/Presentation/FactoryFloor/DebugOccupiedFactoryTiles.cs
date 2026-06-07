using System.Collections.Generic;
using Data.FactoryFloor;
using NaughtyAttributes;
using Presentation.Locators;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class DebugOccupiedFactoryTiles : MonoBehaviour
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private GridLocator _gridLocator;

		[SerializeField]
		private GameObject _testGameObject;

		private readonly List<GameObject> _placed = new List<GameObject>();

		[Button("Show", EButtonEnableMode.Always)]
		public void DisplayOccupied()
		{
			RemoveOccupied();
			foreach (FactoryObject allDistinctObjectList in _factoryLayer.GetAllDistinctObjectLists())
			{
				foreach (Vector3Int occupiedPosition in allDistinctObjectList.OccupiedPositions)
				{
					Vector3 worldPosition = _gridLocator.GetWorldPosition(occupiedPosition);
					worldPosition.y = 0f;
					GameObject item = Object.Instantiate(_testGameObject, worldPosition, _testGameObject.transform.rotation, base.transform);
					_placed.Add(item);
				}
			}
		}

		[Button("Hide", EButtonEnableMode.Always)]
		public void RemoveOccupied()
		{
			foreach (GameObject item in _placed)
			{
				Object.Destroy(item);
			}
			_placed.Clear();
		}
	}
}
