using System;
using UnityEngine;

public class SaveableInstance : MonoBehaviour, IDataPersistence
{
	public enum ObjectType
	{
		Item = 0,
		Dirt = 1,
		Other = 2
	}

	[SerializeField]
	private Transform saveTransformValues;

	[SerializeField]
	private SaveableObjectData saveData;

	public ObjectType type;

	private void Start()
	{
		while (saveData.id == 0)
		{
			saveData.id = Guid.NewGuid().GetHashCode();
		}
		if (saveTransformValues == null)
		{
			saveTransformValues = base.transform;
		}
	}

	public void Save()
	{
		if (base.transform.parent != null)
		{
			SaveableInstance componentInParent = base.transform.parent.GetComponentInParent<SaveableInstance>();
			if (componentInParent != null)
			{
				saveData.parentId = componentInParent.saveData.id;
				if (GetComponent<ItemComponent>() != null)
				{
					saveData.isChildOfNotSavableItemSocket = base.transform.parent.GetComponent<ItemSocket>() != null && base.transform.parent != componentInParent.transform;
					if (componentInParent.GetComponent<StorageComponent>() != null)
					{
						saveData.isChildOfStorageComponent = componentInParent.GetComponent<StorageComponent>().HasItem(GetComponent<ItemComponent>());
					}
					else
					{
						saveData.isChildOfStorageComponent = false;
					}
					saveData.isChildOfSocketPackageComponent = componentInParent.GetComponent<SocketPackage>() != null;
					if (saveData.isChildOfNotSavableItemSocket)
					{
						saveData.socketName = base.transform.parent.name;
					}
					if (saveData.isChildOfStorageComponent)
					{
						saveData.socketIndex = componentInParent.GetComponent<StorageComponent>().GetIndexOfChild(this);
					}
					if (saveData.isChildOfSocketPackageComponent)
					{
						saveData.socketIndex = componentInParent.GetComponent<SocketPackage>().GetIndexOfChild(this);
					}
				}
			}
			else
			{
				saveData.parentId = 0;
			}
		}
		else
		{
			saveData.parentId = 0;
		}
		saveData.position = saveTransformValues.position;
		saveData.rotation = saveTransformValues.rotation;
		saveData.scale = saveTransformValues.localScale;
		if (type == ObjectType.Item)
		{
			if (GetComponent<ItemComponent>() == null)
			{
				Debug.LogError("Save Data >Item< Has no Valid ItemComponent!");
			}
			saveData.item = GetComponent<ItemComponent>().item;
			saveData.objName = GetComponent<ItemComponent>().GetInfo().name;
			if (GetComponent<ProductComponent>() != null)
			{
				if (GetComponent<CupComponent>() != null)
				{
					saveData.dirty = GetComponent<CupComponent>().IsDirty();
				}
				Product product = GetComponent<ProductComponent>().GetProduct();
				if (product != null && product.IsValid())
				{
					saveData.product = GetComponent<ProductComponent>().GetProduct();
				}
			}
		}
		if (type == ObjectType.Dirt)
		{
			if (GetComponent<DirtComponent>() == null)
			{
				Debug.LogError("Save Data >Dirt< Has no Valid DirtComponent!");
			}
			saveData.item = GetComponent<DirtComponent>().GetDirt().dirtReferenceItem;
			saveData.objName = base.name;
		}
		if (type == ObjectType.Other)
		{
			if (GetComponent<ServiceCounterComponent>() != null)
			{
				saveData.item = GetComponent<ServiceCounterComponent>().itemReference;
				saveData.objName = base.name;
			}
			if (GetComponent<LampComponent>() != null)
			{
				saveData.item = GetComponent<ItemComponent>().item;
				saveData.objName = base.name;
				saveData.color = GetComponent<LampComponent>().currentColor;
			}
			if (GetComponent<DeliveryPackage>() != null)
			{
				saveData.item = GetComponent<ItemComponent>().item;
				saveData.objName = base.name;
			}
		}
		if (GetComponent<StorageComponent>() != null)
		{
			saveData.isSelfStorageComponent = true;
			Debug.Log("Storage Component Saved!");
		}
		else
		{
			saveData.isSelfStorageComponent = false;
		}
		if (GetComponent<SocketPackage>() != null)
		{
			saveData.isSelfSocketPackageComponent = true;
			Debug.Log("Socket Package Component Saved!");
		}
		else
		{
			saveData.isSelfSocketPackageComponent = false;
		}
	}

	public SaveableObjectData GetSaveData()
	{
		return saveData;
	}

	public void LoadData(GameData data, bool isNewGameData)
	{
	}

	public void LoadData(SaveableObjectData data)
	{
		saveData.objName = data.objName;
		saveData.id = data.id;
		saveData.parentId = data.parentId;
		saveData.position = data.position;
		saveData.rotation = data.rotation;
		saveData.scale = data.scale;
		saveData.item = data.item;
		saveData.isSelfStorageComponent = data.isSelfStorageComponent;
		saveData.isSelfSocketPackageComponent = data.isSelfSocketPackageComponent;
		saveData.isChildOfStorageComponent = data.isChildOfStorageComponent;
		saveData.isChildOfSocketPackageComponent = data.isChildOfSocketPackageComponent;
		saveData.socketIndex = data.socketIndex;
		saveData.product = data.product;
		saveData.dirty = data.dirty;
		saveData.color = data.color;
		base.transform.position = saveData.position;
		base.transform.rotation = saveData.rotation;
		base.transform.localScale = saveData.scale;
		if (type == ObjectType.Item)
		{
			ItemComponent component = GetComponent<ItemComponent>();
			component.item.amount = data.item.amount;
			component.item.tag = data.item.tag;
			if (GetComponent<IngredientColorPicker>() != null)
			{
				GetComponent<IngredientColorPicker>().PickColorByMask(component.item.tag.anomalyFlags);
			}
			if (GetComponent<ProductComponent>() != null)
			{
				if (GetComponent<CupComponent>() != null)
				{
					GetComponent<CupComponent>().Init();
					if (saveData.dirty)
					{
						GetComponent<CupComponent>().MarkDirty();
					}
					else
					{
						GetComponent<CupComponent>().UnmarkDirty();
					}
				}
				Product product = saveData.product;
				if (product != null && product.IsValid())
				{
					GetComponent<ProductComponent>().SetProduct(product);
				}
				else
				{
					GetComponent<ProductComponent>().ClearProduct();
				}
			}
		}
		if (type == ObjectType.Dirt)
		{
			GetComponent<DirtComponent>().GetDirt().dirtReferenceItem = data.item;
			return;
		}
		if (type == ObjectType.Other)
		{
			if (GetComponent<ServiceCounterComponent>() != null)
			{
				CafeShopManager.RegisterServiceCounter(GetComponent<ServiceCounterComponent>());
			}
			if (GetComponent<LampComponent>() != null)
			{
				GetComponent<LampComponent>().LoadColor(saveData.color);
			}
		}
		if (saveData.isSelfStorageComponent)
		{
			GetComponent<StorageComponent>().LoadClear();
		}
		else if (saveData.isSelfSocketPackageComponent)
		{
			GetComponent<SocketPackage>().LoadClear();
		}
	}

	public void SaveData(ref GameData gameData)
	{
		Save();
		SaveableObjectData saveableObjectData = gameData.registeredDynamicObjects.Find((SaveableObjectData x) => x.id == saveData.id);
		if (saveableObjectData == null)
		{
			gameData.registeredDynamicObjects.Add(saveData);
			return;
		}
		gameData.registeredDynamicObjects.Remove(saveableObjectData);
		gameData.registeredDynamicObjects.Add(saveData);
	}

	public void Reparent(Transform parent)
	{
		base.transform.parent = parent;
		if (saveData.isChildOfStorageComponent)
		{
			parent.GetComponent<StorageComponent>().LoadPushItem(base.gameObject.GetComponent<ItemComponent>(), saveData.socketIndex);
		}
		else if (saveData.isChildOfSocketPackageComponent)
		{
			parent.GetComponent<SocketPackage>().LoadPushItem(base.gameObject.GetComponent<ItemComponent>(), saveData.socketIndex);
		}
		else if (saveData.isChildOfNotSavableItemSocket)
		{
			parent.Find(saveData.socketName).GetComponent<ItemSocket>().SetItemToSocket(base.gameObject.GetComponent<ItemComponent>());
		}
		else if (parent.GetComponent<DishwasherComponent>() != null && base.gameObject.GetComponent<DishwasherComponent>() == null)
		{
			parent.GetComponent<DishwasherComponent>().LoadIntoDishwasher(base.gameObject.GetComponent<ItemComponent>());
		}
		else if (parent.GetComponent<DeliveryPackage>() != null && base.gameObject.GetComponent<DeliveryPackage>() == null)
		{
			parent.GetComponent<DeliveryPackage>().LoadItemsIntoSockets();
		}
		else if (parent.GetComponent<DeliveryDepotComponent>() != null && base.gameObject.GetComponent<DeliveryDepotComponent>() == null)
		{
			if ((bool)base.gameObject.GetComponent<DeliveryPackage>())
			{
				parent.GetComponent<DeliveryDepotComponent>().LoadDeliverPackage(base.gameObject.GetComponent<DeliveryPackage>());
			}
		}
		else if ((bool)parent.GetComponentInParent<WaterHeaterComponent>() && (bool)base.gameObject.GetComponent<KettleComponent>())
		{
			parent.GetComponentInParent<WaterHeaterComponent>().HeatUp(base.gameObject.GetComponent<ItemComponent>(), clear: true);
		}
	}
}
