using System;
using System.Collections.Generic;
using MoonSharp.Interpreter;
using UnityEngine;

[MoonSharpUserData]
public class ModStorage
{
	public Table GetAllStorageUIDsOfStorageType(string NewTypeString)
	{
		Table table = new Table(ModManager.Instance.GetLastCalledScript());
		TileCoord topLeftTile = new TileCoord(0, 0);
		TileCoord bottomRightTile = new TileCoord(TileManager.Instance.m_TilesWide - 1, TileManager.Instance.m_TilesHigh - 1);
		ObjectType result = ObjectType.Nothing;
		if (!Enum.TryParse<ObjectType>(NewTypeString, out result))
		{
			result = ModManager.Instance.GetModObjectTypeFromName(NewTypeString);
		}
		if (!Storage.GetIsTypeStorage(result))
		{
			string descriptionOverride = "Error: ModStorage.GetAllStorageUIDsOfStorageType - '" + NewTypeString + "' either isn't storage type or not found";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
			return new Table(ModManager.Instance.GetLastCalledScript(), DynValue.NewNumber(-1.0));
		}
		List<TileCoordObject> objectsInArea = PlotManager.Instance.GetObjectsInArea(result, topLeftTile, bottomRightTile);
		foreach (TileCoordObject item in objectsInArea)
		{
			table.Append(DynValue.NewNumber(item.m_UniqueID));
		}
		if (objectsInArea.Count > 0)
		{
			return table;
		}
		return new Table(ModManager.Instance.GetLastCalledScript(), DynValue.NewNumber(-1.0));
	}

	public Table GetAllStorageUIDsHoldingObject(string NewTypeString)
	{
		Table table = new Table(ModManager.Instance.GetLastCalledScript());
		TileCoord topLeftTile = new TileCoord(0, 0);
		TileCoord bottomRightTile = new TileCoord(TileManager.Instance.m_TilesWide - 1, TileManager.Instance.m_TilesHigh - 1);
		ObjectType result = ObjectType.Nothing;
		if (!Enum.TryParse<ObjectType>(NewTypeString, out result))
		{
			result = ModManager.Instance.GetModObjectTypeFromName(NewTypeString);
		}
		ObjectType storageType = ObjectTypeList.Instance.GetStorageType(result);
		List<TileCoordObject> objectsInArea = PlotManager.Instance.GetObjectsInArea(storageType, topLeftTile, bottomRightTile);
		foreach (TileCoordObject item in objectsInArea)
		{
			if ((bool)item.GetComponent<Storage>() && item.GetComponent<Storage>().m_ObjectType == result)
			{
				table.Append(DynValue.NewNumber(item.m_UniqueID));
			}
		}
		if (objectsInArea.Count > 0)
		{
			return table;
		}
		return new Table(ModManager.Instance.GetLastCalledScript(), DynValue.NewNumber(-1.0));
	}

	public Table GetStorageProperties(int UID)
	{
		Table table = new Table(ModManager.Instance.GetLastCalledScript());
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID);
		Storage component = objectFromUniqueID.GetComponent<Storage>();
		if (component != null)
		{
			if (component.m_ObjectType >= ObjectType.Total)
			{
				table.Append(DynValue.NewString(ModManager.Instance.m_ModStrings[component.m_ObjectType]));
			}
			else
			{
				table.Append(DynValue.NewString(component.m_ObjectType.ToString()));
			}
			table.Append(DynValue.NewNumber(component.GetStored()));
			table.Append(DynValue.NewNumber(component.GetCapacity()));
			if (objectFromUniqueID.m_TypeIdentifier >= ObjectType.Total)
			{
				table.Append(DynValue.NewString(ModManager.Instance.m_ModStrings[objectFromUniqueID.m_TypeIdentifier]));
			}
			else
			{
				table.Append(DynValue.NewString(objectFromUniqueID.m_TypeIdentifier.ToString()));
			}
		}
		return table;
	}

	public bool SetStorageMaxCapacity(int UID, int MaxCapacity)
	{
		Storage component = ObjectTypeList.Instance.GetObjectFromUniqueID(UID).GetComponent<Storage>();
		if (component != null)
		{
			component.m_Capacity = MaxCapacity;
			component.UpdateStored();
			return true;
		}
		return false;
	}

	public bool SetStorageQuantityStored(int UID, int CurrentStorage)
	{
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID);
		Storage component = objectFromUniqueID.GetComponent<Storage>();
		if (component != null)
		{
			if (component.m_Stored != CurrentStorage)
			{
				while (component.m_Stored < CurrentStorage)
				{
					component.AddToStored(objectFromUniqueID, null);
				}
				if (component.m_Stored > CurrentStorage)
				{
					component.ReleaseStored(objectFromUniqueID.m_TypeIdentifier, null, component.m_Stored - CurrentStorage);
				}
			}
			component.UpdateStored();
			return true;
		}
		return false;
	}

	public bool SetStorageType(string NewTypeString, int MaxCapacity, string NewStorageType)
	{
		ObjectType result = ObjectType.Nothing;
		if (!Enum.TryParse<ObjectType>(NewTypeString, out result))
		{
			result = ModManager.Instance.GetModObjectTypeFromName(NewTypeString);
		}
		if (result == ObjectType.Nothing)
		{
			string descriptionOverride = "Error: ModStorage.SetStorageType '" + NewTypeString + "' - Object Type Not Recognised";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
			return false;
		}
		ObjectType result2 = ObjectType.Nothing;
		if (!Enum.TryParse<ObjectType>(NewStorageType, out result2))
		{
			result2 = ModManager.Instance.GetModObjectTypeFromName(NewStorageType);
		}
		if (result2 == ObjectType.Nothing)
		{
			string descriptionOverride2 = "Error: ModStorage.SetStorageType '" + NewStorageType + "' - Storage Type Not Recognised";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride2);
			return false;
		}
		if (StorageTypeManager.m_StoragePaletteInformation.ContainsKey(result))
		{
			StorageTypeManager.m_StoragePaletteInformation.Remove(result);
		}
		else if (StorageTypeManager.m_StorageGenericInformation.ContainsKey(result))
		{
			StorageTypeManager.m_StorageGenericInformation.Remove(result);
		}
		ObjectTypeList.Instance.SetStorageType(result, result2);
		switch (result2)
		{
		case ObjectType.StorageGeneric:
		case ObjectType.StorageGenericMedium:
			StorageTypeManager.m_StorageGenericInformation.Add(result, new StorageTypeManager.StorageGenericInfo(MaxCapacity));
			return true;
		case ObjectType.StoragePalette:
		case ObjectType.StoragePaletteMedium:
			StorageTypeManager.m_StoragePaletteInformation.Add(result, new StorageTypeManager.StorageGenericInfo(MaxCapacity));
			return true;
		default:
			return true;
		}
	}

	public Table TakeFromStorage(int StorageUID, int Amount, int xPos, int yPos)
	{
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(StorageUID);
		Storage component = objectFromUniqueID.GetComponent<Storage>();
		if (component != null)
		{
			if (Amount > component.m_Stored)
			{
				Amount = component.m_Stored;
			}
			int usageCount = component.ReleaseStored(objectFromUniqueID.m_TypeIdentifier, null, Amount);
			Holdable component2 = objectFromUniqueID.GetComponent<Holdable>();
			if ((bool)component2)
			{
				component2.m_UsageCount = usageCount;
			}
			if (xPos < 0 || yPos < 0 || xPos >= TileManager.Instance.m_TilesWide || yPos >= TileManager.Instance.m_TilesHigh)
			{
				string descriptionOverride = "Error: ModStorage.TakeFromStorage '" + StorageUID + "' - Tile coordinates outside of map (" + xPos + "," + yPos + ")";
				ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
				return null;
			}
			TileCoord tilePosition = new TileCoord(xPos, yPos);
			Vector3 position = tilePosition.ToWorldPositionTileCentered();
			Table table = new Table(ModManager.Instance.GetLastCalledScript());
			for (int i = 0; i < Amount; i++)
			{
				if (ObjectTypeList.Instance.GetIsBuilding(component.m_ObjectType))
				{
					Building building = BuildingManager.Instance.AddBuilding(tilePosition, component.m_ObjectType, 0, null, true);
					table.Append(DynValue.NewNumber(building.m_UniqueID));
					continue;
				}
				BaseClass baseClass = ObjectTypeList.Instance.CreateObjectFromIdentifier(component.m_ObjectType, position, Quaternion.identity);
				if (component.m_ObjectType == ObjectType.CropWheat)
				{
					baseClass.GetComponent<CropWheat>().SetState(Crop.State.Wild);
				}
				table.Append(DynValue.NewNumber(baseClass.m_UniqueID));
			}
			component.UpdateStored();
			return table;
		}
		return null;
	}

	public bool AddToStorage(int StorageUID, int ObjectUID)
	{
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(StorageUID);
		BaseClass objectFromUniqueID2 = ObjectTypeList.Instance.GetObjectFromUniqueID(ObjectUID);
		Storage component = objectFromUniqueID.GetComponent<Storage>();
		if (component != null)
		{
			component.AddToStored(objectFromUniqueID2, null);
			component.UpdateStored();
			return true;
		}
		return false;
	}
}
