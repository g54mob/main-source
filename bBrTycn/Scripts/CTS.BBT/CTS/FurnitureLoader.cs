using System.Collections.Generic;
using System.Linq;
using CTS.BBT;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CTS
{
	public static class FurnitureLoader
	{
		private static Dictionary<string, FurnitureSO> _furnitureList = new Dictionary<string, FurnitureSO>();

		public static ReadOnlyValueCollection<string, FurnitureSO> LoadedFurnitures => _furnitureList;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void Initialize()
		{
			FurnitureSO[] array = Addressables.LoadAssetsAsync<FurnitureSO>("Furnitures").WaitForCompletion().ToArray();
			foreach (FurnitureSO furnitureSO in array)
			{
				_furnitureList.TryAdd(furnitureSO.name, furnitureSO);
			}
			MapEditor.GetFurnituresToSaveFromMapEditor = GetFurnituresToSaveFromMapEditor;
		}

		public static void AddFurniture(FurnitureSO furniture)
		{
			_furnitureList.Add(furniture.name, furniture);
		}

		public static bool TryGetFurniture(string id, out FurnitureSO furnitureData)
		{
			return _furnitureList.TryGetValue(id, out furnitureData);
		}

		private static FurnitureSaveStruct[] GetFurnituresToSaveFromMapEditor(Transform container)
		{
			List<FurnitureSaveStruct> list = new List<FurnitureSaveStruct>();
			foreach (Transform child in container.GetChildren())
			{
				if (!child.TryGetComponent<Furniture>(out var component))
				{
					continue;
				}
				List<SlottedFurnitureSaveStruct> list2 = new List<SlottedFurnitureSaveStruct>();
				FurnitureSlot[] slots = component.Slots;
				foreach (FurnitureSlot furnitureSlot in slots)
				{
					if (furnitureSlot.SlotedFurniture != null)
					{
						SlottedFurnitureSaveStruct item = new SlottedFurnitureSaveStruct
						{
							furnitureName = furnitureSlot.SlotedFurniture.Furniture.Parameters.name,
							positionFurnitures = furnitureSlot.SlotedFurniture.Furniture.transform.position,
							rotationFurnitures = furnitureSlot.SlotedFurniture.Furniture.transform.rotation
						};
						list2.Add(item);
					}
				}
				FurnitureSaveStruct item2 = new FurnitureSaveStruct
				{
					furnitureName = component.Parameters.name,
					positionFurnitures = child.position,
					rotationFurnitures = child.rotation,
					slotedFurniture = list2.ToArray()
				};
				list.Add(item2);
			}
			return list.ToArray();
		}
	}
}
