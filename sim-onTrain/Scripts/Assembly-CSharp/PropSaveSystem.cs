using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public static class PropSaveSystem
{
	[Serializable]
	public class PropSaveData
	{
		public string itemName;

		public Vector3 localPosition;

		public Vector3 localEulerAngles;

		public int wagonIndex;

		public bool isNetworkObject;

		public string uniqueID;

		public string stateData;

		public float health;

		public string parentObjectID;

		public int parentLeafIndex;

		public PropSaveData()
		{
		}

		public PropSaveData(string name, Vector3 localPos, Vector3 localEuler, int wagon, bool isNetwork = false, string objectID = "", string state = "", float hp = 100f, string parentObjectID = "", int parentLeafIndex = -1)
		{
			itemName = name;
			localPosition = localPos;
			localEulerAngles = localEuler;
			wagonIndex = wagon;
			isNetworkObject = isNetwork;
			uniqueID = objectID;
			stateData = state;
			health = hp;
			this.parentObjectID = parentObjectID;
			this.parentLeafIndex = parentLeafIndex;
		}
	}

	private const string PROP_COUNT_KEY = "PropCount";

	private const string PROP_DATA_PREFIX = "PropData_";

	public static void SaveAllPropsWithWagons(List<WagonController> wagons)
	{
		Debug.LogWarning("PropSaveSystem.SaveAllPropsWithWagons kullanılıyor - TrainBuildManager kullanılması öneriliyor.");
		PropBase[] array = UnityEngine.Object.FindObjectsOfType<PropBase>();
		if (array.Length == 0)
		{
			Debug.Log("Kaydedilecek PropBase objesi bulunamadı.");
			Singleton<ES3SaveManager>.Instance.SaveData("PropCount", 0);
			return;
		}
		List<PropSaveData> list = new List<PropSaveData>();
		PropBase[] array2 = array;
		foreach (PropBase propBase in array2)
		{
			if (propBase.data != null && !string.IsNullOrEmpty(propBase.data.itemName))
			{
				GrabbableObject component = propBase.GetComponent<GrabbableObject>();
				if (component != null)
				{
					component.FindWagonByRaycast();
				}
				propBase.SetID();
				int assignedWagonID = propBase.assignedWagonID;
				bool isNetworkObject = propBase.data.isNetworkObject;
				string state = "";
				GameObject gameObject = propBase.gameObject;
				FurnaceController component2 = gameObject.GetComponent<FurnaceController>();
				if (component2 != null)
				{
					state = component2.SaveState();
				}
				else
				{
					GrillController component3 = gameObject.GetComponent<GrillController>();
					if (component3 != null)
					{
						state = component3.SaveState();
					}
					else
					{
						BasicWaterPurifierController component4 = gameObject.GetComponent<BasicWaterPurifierController>();
						if (component4 != null)
						{
							state = component4.SaveState();
						}
						else
						{
							PlantPotController component5 = gameObject.GetComponent<PlantPotController>();
							if (component5 != null)
							{
								state = component5.SaveState();
							}
						}
					}
				}
				PropSaveData item = new PropSaveData(propBase.data.itemName, propBase.transform.localPosition, propBase.transform.localEulerAngles, assignedWagonID, isNetworkObject, propBase.uniqueID, state, propBase.health);
				list.Add(item);
				Debug.Log($"Prop kaydediliyor: {propBase.data.itemName} - Network: {isNetworkObject}");
			}
			else
			{
				Debug.LogWarning("PropBase objesi " + propBase.name + " üzerinde geçerli CollectableItemData bulunamadı!");
			}
		}
		Singleton<ES3SaveManager>.Instance.SaveData("PropCount", list.Count);
		for (int j = 0; j < list.Count; j++)
		{
			string key = "PropData_" + j;
			Singleton<ES3SaveManager>.Instance.SaveData(key, list[j]);
		}
		Debug.Log($"Toplam {list.Count} PropBase objesi kaydedildi!");
	}

	public static void LoadAllPropsWithWagons(TrainController trainController)
	{
		Debug.LogWarning("PropSaveSystem.LoadAllPropsWithWagons kullanılıyor - TrainBuildManager kullanılması öneriliyor.");
		if (!Singleton<ES3SaveManager>.Instance.KeyExists("PropCount"))
		{
			Debug.Log("Kaydedilmiş prop verisi bulunamadı.");
			return;
		}
		int num = Singleton<ES3SaveManager>.Instance.LoadData("PropCount", 0);
		if (num == 0)
		{
			Debug.Log("Yüklenecek prop bulunamadı.");
			return;
		}
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			string text = "PropData_" + i;
			if (Singleton<ES3SaveManager>.Instance.KeyExists(text))
			{
				if (InstantiatePropWithCorrectParent(Singleton<ES3SaveManager>.Instance.LoadData<PropSaveData>(text), trainController))
				{
					num2++;
				}
			}
			else
			{
				Debug.LogWarning("Prop verisi bulunamadı: " + text);
			}
		}
		Debug.Log($"{num2} prop yüklendi.");
	}

	private static bool InstantiatePropWithCorrectParent(PropSaveData saveData, TrainController trainController)
	{
		if (string.IsNullOrEmpty(saveData.itemName))
		{
			Debug.LogWarning("Prop item name boş!");
			return false;
		}
		CollectableItemData collectableItemData = FindItemDataByName(saveData.itemName);
		if (collectableItemData == null)
		{
			Debug.LogWarning("ItemData bulunamadı: " + saveData.itemName);
			return false;
		}
		WagonController wagonController = null;
		if (trainController != null && saveData.wagonIndex >= 0)
		{
			wagonController = trainController.GetWagonByID(saveData.wagonIndex);
			if (wagonController == null)
			{
				Debug.LogWarning($"Wagon ID {saveData.wagonIndex} bulunamadı! Ana trene parent edilecek.");
			}
		}
		GameObject gameObject = null;
		if (!string.IsNullOrEmpty(collectableItemData.itemName) && Singleton<PoolingSystem>.Instance != null)
		{
			gameObject = Singleton<PoolingSystem>.Instance.InstantiateAPS(collectableItemData.itemName);
		}
		else if (collectableItemData.itemPrefab != null)
		{
			gameObject = UnityEngine.Object.Instantiate(collectableItemData.itemPrefab);
		}
		if (gameObject == null)
		{
			Debug.LogWarning("Prop instantiate edilemedi: " + saveData.itemName);
			return false;
		}
		if (gameObject.GetComponent<NetworkIdentity>() != null && saveData.isNetworkObject)
		{
			if (!NetworkServer.active)
			{
				Debug.LogWarning("NetworkServer aktif değil, network objesi spawn edilemiyor!");
				UnityEngine.Object.Destroy(gameObject);
				return false;
			}
			NetworkServer.Spawn(gameObject);
			Debug.Log("Network objesi spawn edildi: " + saveData.itemName);
		}
		PropBase propBase = gameObject.GetComponent<PropBase>();
		if (propBase == null)
		{
			propBase = gameObject.AddComponent<PropBase>();
		}
		propBase.data = collectableItemData;
		propBase.assignedWagonID = saveData.wagonIndex;
		Debug.Log(saveData.uniqueID);
		propBase.uniqueID = saveData.uniqueID;
		propBase.health = ((saveData.health > 0f) ? saveData.health : propBase.maxHealth);
		if (wagonController != null)
		{
			SetCorrectParentByItemType(gameObject.transform, wagonController, collectableItemData.itemType);
		}
		else
		{
			gameObject.transform.SetParent(trainController.transform, worldPositionStays: false);
		}
		gameObject.transform.localPosition = saveData.localPosition;
		gameObject.transform.localEulerAngles = saveData.localEulerAngles;
		if (!string.IsNullOrEmpty(saveData.stateData))
		{
			FurnaceController component = gameObject.GetComponent<FurnaceController>();
			if (component != null)
			{
				component.LoadState(saveData.stateData);
			}
			else
			{
				GrillController component2 = gameObject.GetComponent<GrillController>();
				if (component2 != null)
				{
					component2.LoadState(saveData.stateData);
				}
				else
				{
					BasicWaterPurifierController component3 = gameObject.GetComponent<BasicWaterPurifierController>();
					if (component3 != null)
					{
						component3.LoadState(saveData.stateData);
					}
					else
					{
						PlantPotController component4 = gameObject.GetComponent<PlantPotController>();
						if (component4 != null)
						{
							component4.LoadState(saveData.stateData);
						}
					}
				}
			}
		}
		Debug.Log($"Prop yüklendi: {saveData.itemName} - Network: {saveData.isNetworkObject}");
		return true;
	}

	private static void SetCorrectParentByItemType(Transform propTransform, WagonController wagon, ItemType itemType)
	{
		switch (itemType)
		{
		case ItemType.Placeable:
			if (wagon.propParent != null)
			{
				propTransform.SetParent(wagon.propParent, worldPositionStays: false);
			}
			else
			{
				wagon.AddPropItems(propTransform);
			}
			break;
		case ItemType.BuildItem:
			if (wagon.buildParent != null)
			{
				propTransform.SetParent(wagon.buildParent, worldPositionStays: false);
			}
			else
			{
				wagon.AddBuildItems(propTransform);
			}
			break;
		default:
			propTransform.SetParent(wagon.transform, worldPositionStays: false);
			break;
		}
	}

	private static CollectableItemData FindItemDataByName(string itemName)
	{
		CollectableItemData[] array = Resources.LoadAll<CollectableItemData>("");
		foreach (CollectableItemData collectableItemData in array)
		{
			if (collectableItemData.itemName == itemName)
			{
				return collectableItemData;
			}
		}
		_ = TrainGameManager.Instance?.itemChooser != null;
		return null;
	}

	public static void ClearAllSavedData()
	{
		Singleton<ES3SaveManager>.Instance.SaveData("PropCount", 0);
		Debug.Log("Tüm kaydedilmiş prop data'sı temizlendi.");
	}
}
