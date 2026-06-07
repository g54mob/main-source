using System;
using System.Collections.Generic;
using MoonSharp.Interpreter;
using UnityEngine;

[MoonSharpUserData]
public class ModObject
{
	public void StartMoveTo(int UID, int NewX, int NewY, float Speed = 10f, float Height = 0f)
	{
		TileCoord tileCoord = new TileCoord(NewX, NewY);
		TileCoordObject tileCoordObject = null;
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID);
		if (objectFromUniqueID != null)
		{
			tileCoordObject = objectFromUniqueID.GetComponent<TileCoordObject>();
		}
		if (tileCoordObject == null)
		{
			string descriptionOverride = "Error: ModObject.StartMoveTo - '" + UID + "' cannot be found";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
		}
		else if (!tileCoord.GetIsValid())
		{
			string text = objectFromUniqueID.m_TypeIdentifier.ToString();
			if (objectFromUniqueID.m_TypeIdentifier >= ObjectType.Total)
			{
				text = ModManager.Instance.m_ModStrings[objectFromUniqueID.m_TypeIdentifier];
			}
			string descriptionOverride2 = "Error: ModObject.StartMoveTo - '" + UID + "' is outside of the map limits! (" + text + ")";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride2);
		}
		else
		{
			tileCoordObject.m_ModSpeed = Speed;
			tileCoordObject.m_ModPosition = tileCoordObject.transform.position;
			tileCoordObject.m_ModMoveToPosition = tileCoord.ToWorldPositionTileCentered();
			tileCoordObject.m_ModMoveDistance = (tileCoordObject.m_ModMoveToPosition - tileCoordObject.m_ModPosition).magnitude;
			tileCoordObject.m_ModMoveTimer = 0f;
			tileCoordObject.m_ModHeight = Height;
			Vector3 modMoveDelta = tileCoordObject.m_ModMoveToPosition - tileCoordObject.m_ModPosition;
			modMoveDelta.Normalize();
			tileCoordObject.m_ModMoveDelta = modMoveDelta;
			float y = -90f - Mathf.Atan2(modMoveDelta.z, modMoveDelta.x) * 57.29578f;
			tileCoordObject.transform.rotation = Quaternion.Euler(0f, y, 0f);
			tileCoordObject.m_ModOldDiff = 100000000f;
		}
	}

	public bool UpdateMoveTo(int UID, bool Arc = false, bool Wobble = false)
	{
		TileCoordObject tileCoordObject = null;
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID);
		if (objectFromUniqueID != null)
		{
			tileCoordObject = objectFromUniqueID.GetComponent<TileCoordObject>();
		}
		if (tileCoordObject == null)
		{
			string descriptionOverride = "Error: ModObject.UpdateMoveTo - '" + UID + "' cannot be found";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
			return true;
		}
		float magnitude = (tileCoordObject.m_ModMoveToPosition - tileCoordObject.m_ModPosition).magnitude;
		if (magnitude < TileCoordObject.m_ModMoveToFinishDistance || magnitude > tileCoordObject.m_ModOldDiff)
		{
			tileCoordObject.SetPosition(tileCoordObject.m_ModMoveToPosition);
			return true;
		}
		tileCoordObject.m_ModOldDiff = magnitude;
		tileCoordObject.m_ModPosition += tileCoordObject.m_ModMoveDelta * tileCoordObject.m_ModSpeed * TimeManager.Instance.m_NormalDelta;
		Vector3 modPosition = tileCoordObject.m_ModPosition;
		float num = magnitude / tileCoordObject.m_ModMoveDistance;
		if (Arc)
		{
			float num2 = Mathf.Sin(num * (float)Math.PI);
			modPosition.y += num2 * 2.5f;
		}
		if (Wobble)
		{
			tileCoordObject.m_ModMoveTimer += TimeManager.Instance.m_NormalDelta;
			float num3 = Mathf.Cos(tileCoordObject.m_ModMoveTimer * (float)Math.PI * 2f) * tileCoordObject.m_ModMoveDelta.z * TileCoordObject.m_ModWobbleHeight * num;
			float num4 = Mathf.Sin(tileCoordObject.m_ModMoveTimer * (float)Math.PI * 3f) * TileCoordObject.m_ModWobbleHeight * num;
			float num5 = Mathf.Cos(tileCoordObject.m_ModMoveTimer * (float)Math.PI * 2f) * tileCoordObject.m_ModMoveDelta.x * TileCoordObject.m_ModWobbleHeight * num;
			modPosition.x += num3;
			modPosition.y = tileCoordObject.m_ModHeight + num4;
			modPosition.z += num5;
		}
		if (!new TileCoord(tileCoordObject.m_ModMoveToPosition).GetIsValid())
		{
			string text = objectFromUniqueID.m_TypeIdentifier.ToString();
			if (objectFromUniqueID.m_TypeIdentifier >= ObjectType.Total)
			{
				text = ModManager.Instance.m_ModStrings[objectFromUniqueID.m_TypeIdentifier];
			}
			string descriptionOverride2 = "Error: ModObject.UpdateMoveTo - '" + UID + "' is outside of the map limits! (" + text + ")";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride2);
			return true;
		}
		tileCoordObject.SetPosition(modPosition);
		return false;
	}

	private void MoveInDirection(int UID, int DirectionX, int DirectionY)
	{
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID);
		if (objectFromUniqueID == null)
		{
			string descriptionOverride = "Error: ModObject.MoveInDirection - '" + UID + "' cannot be found";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
			return;
		}
		ObjectType typeIdentifier = ObjectTypeList.Instance.GetObjectFromUniqueID(UID).m_TypeIdentifier;
		if (!objectFromUniqueID.GetComponent<TileMover>())
		{
			string descriptionOverride2 = string.Concat("Error: ModObject.MoveInDirection - '", typeIdentifier, "' is not of Type TileMover - cannot be used in this function");
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride2);
		}
		else
		{
			TileCoord direction = new TileCoord(DirectionX, DirectionY);
			objectFromUniqueID.GetComponent<TileMover>().MoveDirection(direction);
		}
	}

	public void MoveToInstantly(int UID, int NewX, int NewY)
	{
		TileCoordObject tileCoordObject = null;
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID);
		if (objectFromUniqueID != null)
		{
			tileCoordObject = objectFromUniqueID.GetComponent<TileCoordObject>();
		}
		if (tileCoordObject == null)
		{
			string descriptionOverride = "Error: ModObject.MoveToInstantly - '" + UID + "' cannot be found";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
			return;
		}
		TileCoord position = new TileCoord(NewX, NewY);
		if (!position.GetIsValid())
		{
			string text = objectFromUniqueID.m_TypeIdentifier.ToString();
			if (objectFromUniqueID.m_TypeIdentifier >= ObjectType.Total)
			{
				text = ModManager.Instance.m_ModStrings[objectFromUniqueID.m_TypeIdentifier];
			}
			string descriptionOverride2 = "Error: ModObject.MoveToInstantly - '" + UID + "' is outside of the map limits! (" + text + ")";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride2);
		}
		else
		{
			tileCoordObject.UpdatePositionToTilePosition(position);
		}
	}

	public Table GetObjectTileCoord(int UID)
	{
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID);
		if (objectFromUniqueID == null)
		{
			string descriptionOverride = "Error: ModObject.GetObjectTileCoord - '" + UID + "' cannot be found";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
			return null;
		}
		TileCoord tileCoord = new TileCoord(objectFromUniqueID.transform.localPosition);
		return new Table(ModManager.Instance.GetLastCalledScript(), DynValue.NewNumber(tileCoord.x), DynValue.NewNumber(tileCoord.y));
	}

	public bool IsValidObjectUID(int UID)
	{
		return ObjectTypeList.Instance.GetObjectFromUniqueID(UID, false) != null;
	}

	public bool DestroyObject(int UID)
	{
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID, false);
		if (objectFromUniqueID != null)
		{
			if (!objectFromUniqueID.GetComponent<Worker>() && !MapManager.Instance.IsObjectSafeToDelete(objectFromUniqueID))
			{
				return false;
			}
			if (!objectFromUniqueID.GetComponent<TileCoordObject>())
			{
				return false;
			}
			TileCoord tileCoord = objectFromUniqueID.GetComponent<TileCoordObject>().m_TileCoord;
			Tile tile = TileManager.Instance.GetTile(tileCoord);
			if ((bool)objectFromUniqueID.GetComponent<Building>() && (bool)tile.m_Building)
			{
				if (tile.m_Building.m_Levels != null)
				{
					for (int num = tile.m_Building.m_Levels.Count - 1; num >= 0; num--)
					{
						Building building = tile.m_Building.m_Levels[num];
						tile.m_Building.RemoveBuilding(building);
						BuildingManager.Instance.DestroyBuilding(building);
					}
				}
				BuildingManager.Instance.DestroyBuilding(tile.m_Building);
				return true;
			}
			if ((bool)objectFromUniqueID.GetComponent<Floor>() && (bool)tile.m_Floor)
			{
				BuildingManager.Instance.DestroyBuilding(tile.m_Floor);
				return true;
			}
			if ((bool)GameStateManager.Instance.GetCurrentState().GetComponent<GameStateNormal>() && (bool)objectFromUniqueID.GetComponent<Worker>())
			{
				GameStateManager.Instance.GetCurrentState().GetComponent<GameStateNormal>().RemoveSelectedWorker(objectFromUniqueID.GetComponent<Worker>());
			}
			objectFromUniqueID.StopUsing();
			return true;
		}
		return false;
	}

	public string GetObjectType(int UID)
	{
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID);
		if (objectFromUniqueID != null)
		{
			if (objectFromUniqueID.m_TypeIdentifier >= ObjectType.Total)
			{
				return ModManager.Instance.m_ModStrings[objectFromUniqueID.m_TypeIdentifier];
			}
			return objectFromUniqueID.m_TypeIdentifier.ToString();
		}
		return "";
	}

	public bool IsWearingClothing(int UID, string ClothingType)
	{
		FarmerClothes.Type result = FarmerClothes.Type.Total;
		if (!Enum.TryParse<FarmerClothes.Type>(ClothingType, out result))
		{
			string descriptionOverride = "Error: ModObject.IsWearingClothing - Cannot find Clothing Type: " + ClothingType;
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
			return false;
		}
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID);
		if (objectFromUniqueID != null && (bool)objectFromUniqueID.GetComponent<Farmer>() && objectFromUniqueID.GetComponent<Farmer>().m_FarmerClothes.Get(result) != null)
		{
			return true;
		}
		return false;
	}

	public Table GetClothingTypesWorn(int UID)
	{
		Table table = new Table(ModManager.Instance.GetLastCalledScript());
		List<string> list = new List<string>();
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID);
		if (objectFromUniqueID != null && (bool)objectFromUniqueID.GetComponent<Farmer>())
		{
			FarmerClothes farmerClothes = objectFromUniqueID.GetComponent<Farmer>().m_FarmerClothes;
			for (int i = 0; i < farmerClothes.m_Clothes.Count; i++)
			{
				if ((bool)farmerClothes.m_Clothes[i].GetComponent<Hat>() || (bool)farmerClothes.m_Clothes[i].GetComponent<Top>())
				{
					if (farmerClothes.m_Clothes[i].m_TypeIdentifier >= ObjectType.Total)
					{
						list.Add(ModManager.Instance.m_ModStrings[farmerClothes.m_Clothes[i].m_TypeIdentifier]);
					}
					else
					{
						list.Add(farmerClothes.m_Clothes[i].ToString());
					}
				}
			}
		}
		foreach (string item in list)
		{
			table.Append(DynValue.NewString(item));
		}
		return table;
	}

	public Table GetObjectProperties(int UID)
	{
		Table table = new Table(ModManager.Instance.GetLastCalledScript());
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID);
		if (objectFromUniqueID != null)
		{
			if (objectFromUniqueID.m_TypeIdentifier >= ObjectType.Total)
			{
				table.Append(DynValue.NewString(ModManager.Instance.m_ModStrings[objectFromUniqueID.m_TypeIdentifier]));
			}
			else
			{
				table.Append(DynValue.NewString(objectFromUniqueID.m_TypeIdentifier.ToString()));
			}
			TileCoordObject component = objectFromUniqueID.GetComponent<TileCoordObject>();
			if (component != null)
			{
				table.Append(DynValue.NewNumber(component.m_TileCoord.x));
				table.Append(DynValue.NewNumber(component.m_TileCoord.y));
			}
			else
			{
				table.Append(DynValue.NewNumber(-1.0));
				table.Append(DynValue.NewNumber(-1.0));
			}
			table.Append(DynValue.NewNumber(objectFromUniqueID.m_ModelRoot.gameObject.transform.rotation.eulerAngles.y));
			table.Append(DynValue.NewString(objectFromUniqueID.GetHumanReadableName()));
		}
		return table;
	}

	public void SetObjectRotation(int UID, float RotX = 0f, float RotY = 0f, float RotZ = 0f)
	{
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID, false);
		if (objectFromUniqueID != null)
		{
			objectFromUniqueID.gameObject.transform.localRotation = Quaternion.Euler(RotX, RotY, RotZ);
		}
		if (objectFromUniqueID == null)
		{
			string descriptionOverride = "Error: ModObject.SetObjectRotation - '" + UID + "' cannot be found";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
		}
	}

	public string GetObjectCategory(int UID)
	{
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID);
		if (objectFromUniqueID != null)
		{
			return ObjectTypeList.Instance.GetCategoryFromType(objectFromUniqueID.m_TypeIdentifier).ToString();
		}
		return "";
	}

	public string GetObjectSubcategory(int UID)
	{
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID);
		if (objectFromUniqueID != null)
		{
			return ObjectTypeList.Instance.GetSubCategoryFromType(objectFromUniqueID.m_TypeIdentifier).ToString();
		}
		return "";
	}

	public void SetObjectDurability(int UID, int Durability)
	{
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID, false);
		if (objectFromUniqueID != null)
		{
			Holdable component = objectFromUniqueID.GetComponent<Holdable>();
			if (component != null)
			{
				component.m_UsageCount = Durability;
			}
		}
		if (objectFromUniqueID == null)
		{
			string descriptionOverride = "Error: ModObject.SetObjectDurability - '" + UID + "' cannot be found";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
		}
	}
}
