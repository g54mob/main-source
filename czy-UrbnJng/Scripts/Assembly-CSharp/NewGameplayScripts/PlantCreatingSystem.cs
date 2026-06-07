using System;
using System.Collections.Generic;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NewGameplayScripts
{
	public class PlantCreatingSystem : MonoBehaviour, ISavedProgress, ISavedProgressReader
	{
		public class OnPlantCreatedEventArgs : EventArgs
		{
			public int ID;

			public string GUID;
		}

		[SerializeField]
		private Transform plantsParent;

		[SerializeField]
		private PotsSO potsSO;

		private int listSize = 3;

		private List<int> pots2x2UsedList = new List<int>();

		private List<int> pots3x3UsedList = new List<int>();

		private List<int> pots4x4UsedList = new List<int>();

		private List<int> potsOnwall2x2UsedList = new List<int>();

		private int previousVariantIndex;

		public Action OnPlantsLoaded;

		private bool IsFirstObjectSelected = true;

		public static PlantCreatingSystem Instance { get; private set; }

		public event EventHandler<OnPlantCreatedEventArgs> OnPlantCreated;

		public event EventHandler OnFirstObjectCreated;

		private void Awake()
		{
			Instance = this;
		}

		public void CreatePlant(int ID, string GUID)
		{
			if (MovementSystem.Instance.IsMoving())
			{
				return;
			}
			ObjectSO objectSO = ProgressManager.Instance.GetObjectSO(ID);
			int num = 0;
			bool flag = objectSO.variantsList.Count > 0;
			Transform plantVisual = GetPlantVisual(objectSO, GUID);
			Vector2Int size;
			if (flag)
			{
				for (int i = 0; i < objectSO.variantsList.Count; i++)
				{
					if (objectSO.variantsList[i].GUID == GUID)
					{
						num = i;
					}
				}
				size = objectSO.variantsList[num].size;
			}
			else
			{
				size = objectSO.size;
			}
			(Transform, int) randomPot = GetRandomPot(size);
			(Transform, int) randomPot2 = GetRandomPot(size);
			Plant plant = Plant.Create(objectSO, plantVisual, flag, num, randomPot, randomPot2, ID, plantsParent);
			this.OnPlantCreated?.Invoke(this, new OnPlantCreatedEventArgs
			{
				ID = ID,
				GUID = GUID
			});
			if (IsFirstObjectSelected)
			{
				this.OnFirstObjectCreated?.Invoke(this, EventArgs.Empty);
				IsFirstObjectSelected = false;
			}
			MovementSystem.Instance.StartMovingTransform(plant.GetPlantTransform(), isCreated: true, plant);
			plant.ToggleOutline(value: true);
		}

		public void CreatePlant(ObjectSO objectSO, string GUID)
		{
			if (MovementSystem.Instance.IsMoving())
			{
				return;
			}
			int num = 0;
			bool flag = objectSO.variantsList.Count > 0;
			Transform plantVisual = GetPlantVisual(objectSO, GUID);
			Vector2Int size;
			if (flag)
			{
				for (int i = 0; i < objectSO.variantsList.Count; i++)
				{
					if (objectSO.variantsList[i].GUID == GUID)
					{
						num = i;
					}
				}
				size = objectSO.variantsList[num].size;
			}
			else
			{
				size = objectSO.size;
			}
			(Transform, int) randomPot = GetRandomPot(size);
			(Transform, int) wallPot = ((size == new Vector2Int(4, 4)) ? GetRandomPot(size) : GetRandomWallPot(size));
			Plant plant = Plant.Create(objectSO, plantVisual, flag, num, randomPot, wallPot, -1, plantsParent);
			this.OnPlantCreated?.Invoke(this, new OnPlantCreatedEventArgs
			{
				GUID = GUID
			});
			if (IsFirstObjectSelected)
			{
				this.OnFirstObjectCreated?.Invoke(this, EventArgs.Empty);
				IsFirstObjectSelected = false;
			}
			MovementSystem.Instance.StartMovingTransform(plant.GetPlantTransform(), isCreated: true, plant);
			plant.ToggleOutline(value: true);
		}

		private (Transform, int) GetRandomPot(Vector2Int size)
		{
			Transform item = null;
			int num = 0;
			if (size == new Vector2Int(2, 2) && potsSO.pots2x2.Count != 0)
			{
				num = GetUniquePotIndex(potsSO.pots2x2, pots2x2UsedList);
				item = potsSO.pots2x2[num].transform;
			}
			if (size == new Vector2Int(3, 3) && potsSO.pots3x3.Count != 0)
			{
				num = GetUniquePotIndex(potsSO.pots3x3, pots3x3UsedList);
				item = potsSO.pots3x3[num].transform;
			}
			if (size == new Vector2Int(4, 4) && potsSO.pots4x4.Count != 0)
			{
				num = GetUniquePotIndex(potsSO.pots4x4, pots4x4UsedList);
				item = potsSO.pots4x4[num].transform;
			}
			return (item, num);
		}

		private (Transform, int) GetRandomWallPot(Vector2Int size)
		{
			Transform item = null;
			int num = 0;
			if (potsSO.potsOnwall2x2.Count != 0)
			{
				num = GetUniquePotIndex(potsSO.potsOnwall2x2, potsOnwall2x2UsedList);
				item = potsSO.potsOnwall2x2[num].transform;
			}
			return (item, num);
		}

		private Transform GetFloorPotByIndex(Vector2Int size, int index)
		{
			switch (size.x)
			{
			case 2:
				if (size.y != 2)
				{
					break;
				}
				return potsSO.pots2x2[index].transform;
			case 3:
				if (size.y != 3)
				{
					break;
				}
				return potsSO.pots3x3[index].transform;
			case 4:
				if (size.y != 4)
				{
					break;
				}
				return potsSO.pots4x4[index].transform;
			}
			return null;
		}

		private Transform GetWallPotByIndex(Vector2Int size, int index)
		{
			switch (size.x)
			{
			case 2:
				if (size.y != 2)
				{
					break;
				}
				return potsSO.potsOnwall2x2[index].transform;
			case 3:
				if (size.y != 3)
				{
					break;
				}
				return potsSO.pots3x3[index].transform;
			case 4:
				if (size.y != 4)
				{
					break;
				}
				return potsSO.pots4x4[index].transform;
			}
			return null;
		}

		private int GetUniquePotIndex(List<Transform> potsList, List<int> potsUsedList)
		{
			int num = UnityEngine.Random.Range(0, potsList.Count);
			if (potsUsedList.Count != 0)
			{
				do
				{
					num = UnityEngine.Random.Range(0, potsList.Count);
				}
				while (potsUsedList.Contains(num));
			}
			if (potsUsedList.Count < listSize)
			{
				potsUsedList.Add(num);
			}
			else
			{
				for (int i = 0; i < potsUsedList.Count - 1; i++)
				{
					potsUsedList[i] = potsUsedList[i + 1];
				}
				potsUsedList[listSize - 1] = num;
			}
			return num;
		}

		private Transform GetPlantVisual(ObjectSO objectSO, string GUID)
		{
			Transform result = null;
			if (objectSO.variantsList.Count > 0)
			{
				foreach (Variant variants in objectSO.variantsList)
				{
					if (GUID == variants.GUID)
					{
						result = variants.prefab;
						break;
					}
				}
			}
			else
			{
				result = objectSO.prefab;
			}
			return result;
		}

		public void LoadProgress(PlayerProgress progress)
		{
			if (!progress.CreativeMode)
			{
				foreach (InfoForPlantConstructor infoForPlant in progress.infoForPlants)
				{
					ObjectSO plantSOByGUID = CollectionManager.Instance.GetPlantSOByGUID(infoForPlant.itemGUID);
					Transform plantVisual = (infoForPlant.hasVariant ? plantSOByGUID.variantsList[infoForPlant.variantIndex].prefab : plantSOByGUID.prefab);
					Transform floorPotByIndex = GetFloorPotByIndex(infoForPlant.size, infoForPlant.floorPotIndex);
					Transform wallPotByIndex = GetWallPotByIndex(infoForPlant.size, infoForPlant.wallPotIndex);
					Plant obj = Plant.Create(floorPot: (floorPotByIndex, infoForPlant.floorPotIndex), wallPot: (wallPotByIndex, infoForPlant.wallPotIndex), objectSO: plantSOByGUID, plantVisual: plantVisual, hasVariant: infoForPlant.hasVariant, variantIndex: infoForPlant.variantIndex, ID: infoForPlant.objectSOID, plantParent: plantsParent);
					obj.transform.position = new Vector3(infoForPlant.worldPositionX, infoForPlant.worldPositionY, infoForPlant.worldPositionZ);
					obj.transform.rotation = Quaternion.Euler(new Vector3(0f, infoForPlant.rotation, 0f));
					obj.MoveId = infoForPlant.worldPositionX.ToString() + infoForPlant.worldPositionY + infoForPlant.worldPositionZ;
					obj.SetIsMoving(value: false);
				}
				OnPlantsLoaded?.Invoke();
				return;
			}
			foreach (InfoForPlantConstructor infoForPlant2 in progress.CreativeModeProgresses[SceneManager.GetActiveScene().name].infoForPlants)
			{
				ObjectSO plantSOByGUID2 = CollectionManager.Instance.GetPlantSOByGUID(infoForPlant2.itemGUID);
				Transform plantVisual2 = (infoForPlant2.hasVariant ? plantSOByGUID2.variantsList[infoForPlant2.variantIndex].prefab : plantSOByGUID2.prefab);
				Transform floorPotByIndex2 = GetFloorPotByIndex(infoForPlant2.size, infoForPlant2.floorPotIndex);
				Transform wallPotByIndex2 = GetWallPotByIndex(infoForPlant2.size, infoForPlant2.wallPotIndex);
				Plant obj2 = Plant.Create(floorPot: (floorPotByIndex2, infoForPlant2.floorPotIndex), wallPot: (wallPotByIndex2, infoForPlant2.wallPotIndex), objectSO: plantSOByGUID2, plantVisual: plantVisual2, hasVariant: infoForPlant2.hasVariant, variantIndex: infoForPlant2.variantIndex, ID: infoForPlant2.objectSOID, plantParent: plantsParent);
				obj2.transform.position = new Vector3(infoForPlant2.worldPositionX, infoForPlant2.worldPositionY, infoForPlant2.worldPositionZ);
				obj2.transform.rotation = Quaternion.Euler(new Vector3(0f, infoForPlant2.rotation, 0f));
				obj2.MoveId = infoForPlant2.worldPositionX.ToString() + infoForPlant2.worldPositionY + infoForPlant2.worldPositionZ;
				obj2.itemGUID = infoForPlant2.itemGUID;
				obj2.SetIsMoving(value: false);
			}
			OnPlantsLoaded?.Invoke();
		}

		public void UpdateProgress(PlayerProgress progress)
		{
			if (!progress.CreativeMode)
			{
				progress.infoForPlants.Clear();
				{
					foreach (Plant item3 in PlantsOnSceneCollection.Instance.collection)
					{
						Vector2Int size = (item3.GetHasVariant() ? item3.GetObjectSO().variantsList[item3.GetVariantIndex()].size : item3.GetObjectSO().size);
						InfoForPlantConstructor item = new InfoForPlantConstructor
						{
							worldPositionX = item3.transform.position.x,
							worldPositionY = item3.transform.position.y,
							worldPositionZ = item3.transform.position.z,
							rotation = item3.transform.eulerAngles.y,
							objectSOID = item3.GetID(),
							size = size,
							hasVariant = item3.GetHasVariant(),
							variantIndex = item3.GetVariantIndex(),
							score = item3.GetScore(),
							floorPotIndex = item3.GetFloorPotIndex(),
							wallPotIndex = item3.GetWallPotIndex(),
							itemGUID = item3.itemGUID
						};
						progress.infoForPlants.Add(item);
					}
					return;
				}
			}
			progress.CreativeModeProgresses[SceneManager.GetActiveScene().name].infoForPlants.Clear();
			foreach (Plant item4 in PlantsOnSceneCollection.Instance.collection)
			{
				Vector2Int size2 = (item4.GetHasVariant() ? item4.GetObjectSO().variantsList[item4.GetVariantIndex()].size : item4.GetObjectSO().size);
				InfoForPlantConstructor item2 = new InfoForPlantConstructor
				{
					worldPositionX = item4.transform.position.x,
					worldPositionY = item4.transform.position.y,
					worldPositionZ = item4.transform.position.z,
					rotation = item4.transform.eulerAngles.y,
					objectSOID = item4.GetID(),
					size = size2,
					hasVariant = item4.GetHasVariant(),
					variantIndex = item4.GetVariantIndex(),
					score = item4.GetScore(),
					floorPotIndex = item4.GetFloorPotIndex(),
					wallPotIndex = item4.GetWallPotIndex(),
					levelNumber = item4.itemLevelNumber,
					itemGUID = item4.itemGUID
				};
				progress.CreativeModeProgresses[SceneManager.GetActiveScene().name].infoForPlants.Add(item2);
			}
		}
	}
}
