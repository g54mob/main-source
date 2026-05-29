using System;
using System.Collections.Generic;
using MoonSharp.Interpreter;

[MoonSharpUserData]
public class ModTiles
{
	public int GetTilesWide()
	{
		if (ModManager.Instance.m_GameOptionsRef != null)
		{
			return ModManager.Instance.m_GameOptionsRef.m_MapWidth;
		}
		return TileManager.Instance.m_TilesWide;
	}

	public int GetTilesHigh()
	{
		if (ModManager.Instance.m_GameOptionsRef != null)
		{
			return ModManager.Instance.m_GameOptionsRef.m_MapHeight;
		}
		return TileManager.Instance.m_TilesHigh;
	}

	public Table GetMapLimits()
	{
		if (ModManager.Instance.m_GameOptionsRef != null)
		{
			return new Table(ModManager.Instance.GetLastCalledScript(), DynValue.NewNumber(ModManager.Instance.m_GameOptionsRef.m_MapWidth), DynValue.NewNumber(ModManager.Instance.m_GameOptionsRef.m_MapHeight));
		}
		return new Table(ModManager.Instance.GetLastCalledScript(), DynValue.NewNumber(TileManager.Instance.m_TilesWide), DynValue.NewNumber(TileManager.Instance.m_TilesHigh));
	}

	public void SetTile(int x, int y, string TileTypeString)
	{
		Tile.TileType newTileType = (Tile.TileType)Enum.Parse(typeof(Tile.TileType), TileTypeString);
		if (ModManager.Instance.m_GameOptionsRef != null)
		{
			ModManager.Instance.m_GameOptionsRef.SetTile(new TileCoord(x, y), newTileType);
		}
		else
		{
			TileManager.Instance.SetTileType(new TileCoord(x, y), newTileType);
		}
	}

	public string GetTileType(int x, int y)
	{
		return TileManager.Instance.GetTileType(new TileCoord(x, y)).ToString();
	}

	public void ClearEverythingInArea(int StartX, int StartY, int EndX, int EndY)
	{
		if (StartX >= 0 && StartY >= 0 && StartX < TileManager.Instance.m_TilesWide && StartY < TileManager.Instance.m_TilesHigh && EndX >= 0 && EndY >= 0 && EndX < TileManager.Instance.m_TilesWide && EndY < TileManager.Instance.m_TilesHigh)
		{
			TileCoord topLeft = new TileCoord(StartX, StartY);
			TileCoord bottomRight = new TileCoord(EndX, EndY);
			MapManager.Instance.ClearArea(topLeft, bottomRight);
		}
	}

	public void ClearEverythingOnSingleTile(int StartX, int StartY)
	{
		if (StartX >= 0 && StartY >= 0 && StartX < TileManager.Instance.m_TilesWide && StartY < TileManager.Instance.m_TilesHigh)
		{
			TileCoord tileCoord = new TileCoord(StartX, StartY);
			MapManager.Instance.ClearArea(tileCoord, tileCoord);
		}
	}

	public void ClearSpecificsInArea(int StartX, int StartY, int EndX, int EndY, bool Buildings, bool StaticObjects, bool HoldableObjects, bool Tiles)
	{
		if (StartX >= 0 && StartY >= 0 && StartX < TileManager.Instance.m_TilesWide && StartY < TileManager.Instance.m_TilesHigh && EndX >= 0 && EndY >= 0 && EndX < TileManager.Instance.m_TilesWide && EndY < TileManager.Instance.m_TilesHigh)
		{
			TileCoord topLeft = new TileCoord(StartX, StartY);
			TileCoord bottomRight = new TileCoord(EndX, EndY);
			MapManager.Instance.ClearArea(topLeft, bottomRight, Buildings, StaticObjects, HoldableObjects, Tiles);
		}
	}

	public string[] GetObjectTypeOnTile(int xPos, int yPos)
	{
		if (xPos < 0 || yPos < 0 || xPos >= TileManager.Instance.m_TilesWide || yPos >= TileManager.Instance.m_TilesHigh)
		{
			return null;
		}
		TileCoord newPosition = new TileCoord(xPos, yPos);
		List<TileCoordObject> objectsAtTile = PlotManager.Instance.GetObjectsAtTile(newPosition);
		string[] array = new string[objectsAtTile.Count];
		int num = 0;
		foreach (TileCoordObject item in objectsAtTile)
		{
			if (item.m_TypeIdentifier >= ObjectType.Total)
			{
				array[num++] = ModManager.Instance.m_ModStrings[item.m_TypeIdentifier];
			}
			else
			{
				array[num++] = item.m_TypeIdentifier.ToString();
			}
		}
		return array;
	}

	public int[] GetObjectUIDsOnTile(int xPos, int yPos)
	{
		if (xPos < 0 || yPos < 0 || xPos >= TileManager.Instance.m_TilesWide || yPos >= TileManager.Instance.m_TilesHigh)
		{
			return null;
		}
		TileCoord newPosition = new TileCoord(xPos, yPos);
		List<TileCoordObject> objectsAtTile = PlotManager.Instance.GetObjectsAtTile(newPosition);
		int[] array = new int[objectsAtTile.Count];
		int num = 0;
		foreach (TileCoordObject item in objectsAtTile)
		{
			array[num++] = item.m_UniqueID;
		}
		return array;
	}

	public int GetAmountObjectsOfTypeInArea(string NewTypeString, int StartX, int StartY, int EndX, int EndY)
	{
		if (StartX < 0 || StartY < 0 || StartX >= TileManager.Instance.m_TilesWide || StartY >= TileManager.Instance.m_TilesHigh)
		{
			return 0;
		}
		if (EndX < 0 || EndY < 0 || EndX >= TileManager.Instance.m_TilesWide || EndY >= TileManager.Instance.m_TilesHigh)
		{
			return 0;
		}
		TileCoord topLeftTile = new TileCoord(StartX, StartY);
		TileCoord bottomRightTile = new TileCoord(EndX, EndY);
		ObjectType result = ObjectType.Nothing;
		if (!Enum.TryParse<ObjectType>(NewTypeString, out result))
		{
			result = ModManager.Instance.GetModObjectTypeFromName(NewTypeString);
		}
		if (result == ObjectType.Nothing)
		{
			string descriptionOverride = "Error: ModTiles.GetAmountObjectsOfTypeInArea '" + NewTypeString + "' - Object Type Not Recognised";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
			return 0;
		}
		return PlotManager.Instance.GetObjectsInArea(result, topLeftTile, bottomRightTile).Count;
	}

	public int[] GetObjectsOfTypeInAreaUIDs(string NewTypeString, int StartX, int StartY, int EndX, int EndY)
	{
		if (StartX < 0 || StartY < 0 || StartX >= TileManager.Instance.m_TilesWide || StartY >= TileManager.Instance.m_TilesHigh)
		{
			return null;
		}
		if (EndX < 0 || EndY < 0 || EndX >= TileManager.Instance.m_TilesWide || EndY >= TileManager.Instance.m_TilesHigh)
		{
			return null;
		}
		TileCoord topLeftTile = new TileCoord(StartX, StartY);
		TileCoord bottomRightTile = new TileCoord(EndX, EndY);
		ObjectType result = ObjectType.Nothing;
		if (!Enum.TryParse<ObjectType>(NewTypeString, out result))
		{
			result = ModManager.Instance.GetModObjectTypeFromName(NewTypeString);
		}
		if (result == ObjectType.FarmerPlayer)
		{
			FarmerPlayer component = CollectionManager.Instance.GetPlayers()[0].GetComponent<FarmerPlayer>();
			return new int[1] { component.m_UniqueID };
		}
		if (ObjectTypeList.Instance.GetIsBuilding(result))
		{
			List<TileCoordObject> buildingsInArea = PlotManager.Instance.GetBuildingsInArea(result, topLeftTile, bottomRightTile);
			int[] array = new int[buildingsInArea.Count];
			int num = 0;
			{
				foreach (TileCoordObject item in buildingsInArea)
				{
					array[num++] = item.m_UniqueID;
				}
				return array;
			}
		}
		List<TileCoordObject> objectsInArea = PlotManager.Instance.GetObjectsInArea(result, topLeftTile, bottomRightTile);
		int[] array2 = new int[objectsInArea.Count];
		int num2 = 0;
		foreach (TileCoordObject item2 in objectsInArea)
		{
			array2[num2++] = item2.m_UniqueID;
		}
		return array2;
	}

	public int[] GetObjectsOfTypeInAreaIDs(string NewTypeString, int StartX, int StartY, int EndX, int EndY)
	{
		return GetObjectsOfTypeInAreaUIDs(NewTypeString, StartX, StartY, EndX, EndY);
	}

	public bool IsBuildingOnTile(int xPos, int yPos)
	{
		if (xPos < 0 || yPos < 0 || xPos >= TileManager.Instance.m_TilesWide || yPos >= TileManager.Instance.m_TilesHigh)
		{
			return false;
		}
		TileCoord newPosition = new TileCoord(xPos, yPos);
		foreach (TileCoordObject item in PlotManager.Instance.GetObjectsAtTile(newPosition))
		{
			if (ObjectTypeList.Instance.GetIsBuilding(item.m_TypeIdentifier))
			{
				return true;
			}
		}
		return false;
	}

	public string GetFirstSelectableObjectTypeOnTile(int xPos, int yPos)
	{
		if (xPos < 0 || yPos < 0 || xPos >= TileManager.Instance.m_TilesWide || yPos >= TileManager.Instance.m_TilesHigh)
		{
			return null;
		}
		TileCoord newPosition = new TileCoord(xPos, yPos);
		TileCoordObject selectableObjectAtTile = PlotManager.Instance.GetSelectableObjectAtTile(newPosition);
		if ((bool)selectableObjectAtTile)
		{
			if (selectableObjectAtTile.m_TypeIdentifier >= ObjectType.Total)
			{
				return ModManager.Instance.m_ModStrings[selectableObjectAtTile.m_TypeIdentifier];
			}
			return selectableObjectAtTile.m_TypeIdentifier.ToString();
		}
		return null;
	}

	public string GetSelectableObjectOnTile(int xPos, int yPos)
	{
		return GetFirstSelectableObjectTypeOnTile(xPos, yPos);
	}

	public int GetFirstSelectableObjectUIDOnTile(int xPos, int yPos, bool AllowBuildings = false)
	{
		if (xPos < 0 || yPos < 0 || xPos >= TileManager.Instance.m_TilesWide || yPos >= TileManager.Instance.m_TilesHigh)
		{
			return -1;
		}
		TileCoord newPosition = new TileCoord(xPos, yPos);
		TileCoordObject selectableObjectAtTile = PlotManager.Instance.GetSelectableObjectAtTile(newPosition, null, AllowBuildings);
		if ((bool)selectableObjectAtTile)
		{
			return selectableObjectAtTile.m_UniqueID;
		}
		return -1;
	}

	public int GetSelectableObjectOnTileID(int xPos, int yPos)
	{
		return GetFirstSelectableObjectUIDOnTile(xPos, yPos);
	}

	public Table GetSelectableObjectUIDsOnTile(int xPos, int yPos)
	{
		if (xPos < 0 || yPos < 0 || xPos >= TileManager.Instance.m_TilesWide || yPos >= TileManager.Instance.m_TilesHigh)
		{
			return new Table(ModManager.Instance.GetLastCalledScript(), DynValue.NewNumber(-1.0));
		}
		TileCoord newPosition = new TileCoord(xPos, yPos);
		List<TileCoordObject> objectsAtTile = PlotManager.Instance.GetObjectsAtTile(newPosition);
		if (objectsAtTile.Count > 0)
		{
			Table table = new Table(ModManager.Instance.GetLastCalledScript());
			{
				foreach (TileCoordObject item in objectsAtTile)
				{
					if ((bool)item && item.GetComponent<Selectable>() != null)
					{
						table.Append(DynValue.NewNumber(item.m_UniqueID));
					}
				}
				return table;
			}
		}
		return new Table(ModManager.Instance.GetLastCalledScript(), DynValue.NewNumber(-1.0));
	}

	public Table GetSelectableObjectTypesInArea(int StartX, int StartY, int EndX, int EndY, bool AllowBuildings = false)
	{
		if (StartX < 0 || StartY < 0 || StartX >= TileManager.Instance.m_TilesWide || StartY >= TileManager.Instance.m_TilesHigh)
		{
			return null;
		}
		if (EndX < 0 || EndY < 0 || EndX >= TileManager.Instance.m_TilesWide || EndY >= TileManager.Instance.m_TilesHigh)
		{
			return null;
		}
		List<Selectable> list = new List<Selectable>();
		for (int i = StartX; i < EndX; i++)
		{
			for (int j = StartY; j < EndY; j++)
			{
				TileCoord newPosition = new TileCoord(i, j);
				Selectable selectableObjectAtTile = PlotManager.Instance.GetSelectableObjectAtTile(newPosition, null, !AllowBuildings);
				if (selectableObjectAtTile != null)
				{
					list.Add(selectableObjectAtTile);
				}
			}
		}
		if (list.Count > 0)
		{
			Table table = new Table(ModManager.Instance.GetLastCalledScript());
			{
				foreach (Selectable item in list)
				{
					if ((bool)item && item.GetComponent<Selectable>() != null)
					{
						table.Append(DynValue.NewString(item.m_TypeIdentifier.ToString()));
					}
				}
				return table;
			}
		}
		return new Table(ModManager.Instance.GetLastCalledScript(), DynValue.NewNumber(-1.0));
	}

	public bool IsSubcategoryOnTile(int xPos, int yPos, string Subcategory)
	{
		if (xPos < 0 || yPos < 0 || xPos >= TileManager.Instance.m_TilesWide || yPos >= TileManager.Instance.m_TilesHigh)
		{
			return false;
		}
		ObjectSubCategory result = ObjectSubCategory.Any;
		if (!Enum.TryParse<ObjectSubCategory>(Subcategory, out result))
		{
			string descriptionOverride = "Error: ModTiles.IsSubcategoryOnTile - '" + Subcategory + "' cannot be found";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
			return false;
		}
		TileCoord newPosition = new TileCoord(xPos, yPos);
		foreach (TileCoordObject item in PlotManager.Instance.GetObjectsAtTile(newPosition))
		{
			if (ObjectTypeList.Instance.GetSubCategoryFromType(item.m_TypeIdentifier) == result)
			{
				return true;
			}
		}
		return false;
	}
}
