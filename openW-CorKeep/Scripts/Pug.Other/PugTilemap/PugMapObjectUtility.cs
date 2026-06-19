using System.Collections.Generic;
using PugTilemap.Workshop;
using UnityEngine;

namespace PugTilemap
{
	public static class PugMapObjectUtility
	{
		[ClearOnReload]
		private static WorkshopPrefabBank _prefabBank;

		private static WorkshopPrefabBank prefabBank
		{
			get
			{
				if (_prefabBank == null)
				{
					_prefabBank = Resources.Load<WorkshopPrefabBank>("MapWorkshop/MapWorkshopPrefabBank");
					if (_prefabBank == null)
					{
						_prefabBank = Resources.FindObjectsOfTypeAll<WorkshopPrefabBank>()[0];
					}
					_prefabBank.InitVolatile();
				}
				return _prefabBank;
			}
		}

		public static int GetObjectIndex(IEntityMonoBehaviourData component)
		{
			return prefabBank.prefabs.FindIndex((WorkshopPrefabBank.EdPrefab x) => x.mainObjectID == component.ObjectInfo.objectID);
		}

		public static bool CanPrefabBePlacedWithComponentsAtTile(int index, IEnumerable<MonoBehaviour> componentsAtPosition, TileType tileTypeAtPosition)
		{
			return CanPrefabBePlacedWithComponentsAtTile(prefabBank.prefabs[index].prefab.GetComponent<MonoBehaviour>(), componentsAtPosition, tileTypeAtPosition);
		}

		public static bool CanPrefabBePlacedWithComponentsAtTile(MonoBehaviour prefabComponent, IEnumerable<MonoBehaviour> componentsAtPosition, TileType tileTypeAtPosition)
		{
			if (prefabComponent is IPrefabEditorPlaceableCondition)
			{
				return (prefabComponent as IPrefabEditorPlaceableCondition).CanBePlaced(componentsAtPosition, tileTypeAtPosition);
			}
			return true;
		}

		public static ObjectID GetComponentObjectID(int index)
		{
			return prefabBank.prefabs[index].mainObjectID;
		}

		public static Sprite GetIcon(int index)
		{
			return prefabBank.prefabs[index].icon;
		}

		public static bool CanShareTileWithOtherPrefabs(int index)
		{
			return prefabBank.prefabs[index].canShareTileWithOtherPrefabs;
		}

		public static GameObject Instantiate(int index)
		{
			return prefabBank.prefabs[index].Instantiate();
		}

		public static GameObject Instantiate(int index, int tileset)
		{
			return prefabBank.prefabs[index].Instantiate();
		}
	}
}
