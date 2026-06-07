using System;
using System.Collections.Generic;
using MoonSharp.Interpreter;
using UnityEngine;

[MoonSharpUserData]
public class ModBuilding : ModCustom
{
	public Dictionary<ObjectType, Vector2Int> ModCoordsTL;

	public Dictionary<ObjectType, Vector2Int> ModCoordsBR;

	public Dictionary<ObjectType, Vector2Int> ModCoordsAccess;

	protected Dictionary<ObjectType, bool> IsWalkable;

	public override void Init()
	{
		base.Init();
		ModCoordsTL = new Dictionary<ObjectType, Vector2Int>();
		ModCoordsBR = new Dictionary<ObjectType, Vector2Int>();
		ModCoordsAccess = new Dictionary<ObjectType, Vector2Int>();
		IsWalkable = new Dictionary<ObjectType, bool>();
	}

	public override string GetPrefabLocation()
	{
		return "WorldObjects/Buildings/ModBuilding";
	}

	public override ObjectSubCategory GetSubcategory()
	{
		return ObjectSubCategory.BuildingsMisc;
	}

	public bool IsItWalkable(ObjectType TypeToCheck)
	{
		return IsWalkable.ContainsKey(TypeToCheck);
	}

	public void CreateBuilding(string UniqueName, string[] NewIngredientsStringArr, int[] NewIngredientsAmountArr, string ModelName = "", int[] TL = null, int[] BR = null, int[] Access = null, bool UsingCustomModel = true)
	{
		if (UniqueName.Length == 0)
		{
			string descriptionOverride = "Error: ModBuilding.CreateBuilding '" + UniqueName + "' - Unique Name is null length";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
			return;
		}
		if (NewIngredientsStringArr != null && NewIngredientsStringArr.Length != NewIngredientsAmountArr.Length)
		{
			string descriptionOverride2 = "Error: ModBuilding.CreateBuilding '" + UniqueName + "' - Ingredients and Ingredient amounts not equal";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride2);
			return;
		}
		if (ModelName.Length == 0)
		{
			UsingCustomModel = false;
		}
		if (UsingCustomModel)
		{
			ModelName = ModelName.Replace("\\", "\\").Replace("/", "\\").ToLower();
		}
		if (!GeneralUtils.m_InGame)
		{
			if (ModManager.Instance.GetModObjectTypeFromName(UniqueName) != ObjectType.Nothing)
			{
				string descriptionOverride3 = "Error: ModBuilding.CreateBuilding '" + UniqueName + "' - already used this name!";
				ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride3);
				return;
			}
			ObjectType objectType = ObjectTypeList.m_Total + ModManager.Instance.CustomCreations;
			ModIDOriginals.Add(objectType, UniqueName);
			IsEnabled.Add(objectType, true);
			HasSetIngredients.Add(objectType, false);
			HasSetRecipe.Add(objectType, false);
			if (ModelName.Length == 0)
			{
				ModelName = "Models/Buildings/BlockWall";
			}
			ModModels.Add(objectType, ModelName);
			ModModelsCustom.Add(objectType, UsingCustomModel);
			ModManager.Instance.AddModString(objectType, UniqueName);
			ModCoordsTL.Add(objectType, (TL != null && TL.Length > 1) ? new Vector2Int(TL[0], TL[1]) : new Vector2Int(0, -1));
			ModCoordsBR.Add(objectType, (BR != null && BR.Length > 1) ? new Vector2Int(BR[0], BR[1]) : new Vector2Int(1, 0));
			ModCoordsAccess.Add(objectType, (Access != null && Access.Length > 1) ? new Vector2Int(Access[0], Access[1]) : new Vector2Int(-1, 0));
			if (DebugInfo)
			{
				Debug.Log("ADDED NEW BUILDING CALLED " + UniqueName + " (" + UniqueName + ")  ObjID " + objectType);
			}
			ModManager.Instance.CustomCreations++;
			Mod lastCalledMod = ModManager.Instance.GetLastCalledMod();
			if (lastCalledMod != null)
			{
				lastCalledMod.CustomIDs.Add(objectType);
				return;
			}
			string descriptionOverride4 = "Error: ModBuilding.CreateBuilding - Cannot find Lua Script";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride4);
			return;
		}
		ObjectType modObjectTypeFromName = ModManager.Instance.GetModObjectTypeFromName(UniqueName);
		ObjectTypeList.Instance.EnableCustomItem(modObjectTypeFromName, GetSubcategory());
		if (!HasSetIngredients[modObjectTypeFromName] && NewIngredientsStringArr != null)
		{
			IngredientRequirement[] array = new IngredientRequirement[NewIngredientsStringArr.Length];
			for (int i = 0; i < NewIngredientsStringArr.Length; i++)
			{
				ObjectType result = ObjectType.Nothing;
				if (!Enum.TryParse<ObjectType>(NewIngredientsStringArr[i], out result))
				{
					result = ModManager.Instance.GetModObjectTypeFromName(NewIngredientsStringArr[i]);
					if (result == ObjectType.Nothing)
					{
						string descriptionOverride5 = "Error: ModBuilding.CreateBuilding - Object Ingredient '" + NewIngredientsStringArr[i] + "' - cannot be found";
						ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride5);
						return;
					}
				}
				int count = NewIngredientsAmountArr[i];
				array[i] = new IngredientRequirement(result, count);
			}
			ObjectTypeList.Instance.SetIngredients(modObjectTypeFromName, array);
			HasSetIngredients[modObjectTypeFromName] = true;
		}
		VariableManager.Instance.SetVariable(modObjectTypeFromName, "Unlocked", 1);
		VariableManager.Instance.SetVariable(modObjectTypeFromName, "ConversionDelay", 2f);
		VariableManager.Instance.SetVariable(modObjectTypeFromName, "BuildDelay", 1f);
	}

	public bool IsBuildingActuallyFlooring(int UID)
	{
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID);
		if (objectFromUniqueID != null)
		{
			return Floor.GetIsTypeFloor(objectFromUniqueID.m_TypeIdentifier);
		}
		return false;
	}

	public int[] GetAllBuildingsUIDsOfType(string NewTypeString, int StartX, int StartY, int EndX, int EndY)
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
		return new int[1] { -1 };
	}

	public int[] GetBuildingsUIDsRequiringIngredientInArea(string IngredientString, int StartX, int StartY, int EndX, int EndY)
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
		if (!Enum.TryParse<ObjectType>(IngredientString, out result))
		{
			result = ModManager.Instance.GetModObjectTypeFromName(IngredientString);
		}
		if (result == ObjectType.Nothing)
		{
			string descriptionOverride = "Error: ModBuilding.GetBuildingsUIDsRequiringIngredientInArea - Ingredient '" + IngredientString + "' - cannot be found";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
			return null;
		}
		List<int> list = new List<int>();
		for (int i = 0; i < (int)ObjectTypeList.m_Total; i++)
		{
			ObjectType objectType = (ObjectType)i;
			if (!Converter.GetIsTypeConverter(objectType) || !ObjectTypeList.Instance.GetIsBuilding(objectType))
			{
				continue;
			}
			foreach (TileCoordObject item in PlotManager.Instance.GetBuildingsInArea(objectType, topLeftTile, bottomRightTile))
			{
				Converter component = item.GetComponent<Converter>();
				if (!(component != null) || component.m_ResultsToCreate == 0)
				{
					continue;
				}
				foreach (IngredientRequirement item2 in component.m_Requirements[component.m_ResultsToCreate])
				{
					if (item2.m_Type == result)
					{
						list.Add(item.m_UniqueID);
					}
				}
			}
		}
		int[] array = new int[list.Count];
		int num = 0;
		foreach (int item3 in list)
		{
			array[num++] = item3;
		}
		return array;
	}

	public void SetBuildingWalkable(string NewTypeString, bool CanBeWalkedThrough)
	{
		ObjectType result = ObjectType.Nothing;
		if (!Enum.TryParse<ObjectType>(NewTypeString, out result))
		{
			result = ModManager.Instance.GetModObjectTypeFromName(NewTypeString);
		}
		if (result == ObjectType.Nothing)
		{
			string descriptionOverride = "Error: ModBuilding.SetCustomBuildingWalkable '" + NewTypeString + "' - Not Found";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
			return;
		}
		if (IsWalkable.ContainsKey(result))
		{
			IsWalkable.Remove(result);
		}
		if (CanBeWalkedThrough)
		{
			IsWalkable.Add(result, true);
		}
	}

	public int GetBuildingCoveringTile(int PosX, int PosY, bool AllowFlooring = false, bool AllowWalls = false, bool AllowFootprintTiles = false)
	{
		TileCoord position = new TileCoord(PosX, PosY);
		if (!position.GetIsValid())
		{
			return -1;
		}
		Tile tile = TileManager.Instance.GetTile(position);
		if (tile.m_Building != null)
		{
			if (!AllowFlooring && tile.m_Building.GetComponent<Floor>() != null)
			{
				return -1;
			}
			if (!AllowWalls && tile.m_Building.GetComponent<Wall>() != null)
			{
				return -1;
			}
			return tile.m_Building.m_UniqueID;
		}
		if (AllowFootprintTiles && tile.m_BuildingFootprint != null)
		{
			if (!AllowFlooring && tile.m_BuildingFootprint.GetComponent<Floor>() != null)
			{
				return -1;
			}
			if (!AllowWalls && tile.m_BuildingFootprint.GetComponent<Wall>() != null)
			{
				return -1;
			}
			return tile.m_BuildingFootprint.m_UniqueID;
		}
		return -1;
	}

	public Table GetAllBuildingsUIDsFromName(string DesiredName)
	{
		Table table = new Table(ModManager.Instance.GetLastCalledScript());
		foreach (KeyValuePair<BaseClass, int> item in CollectionManager.Instance.GetCollection("Building"))
		{
			Building component = item.Key.GetComponent<Building>();
			if (component.GetHumanReadableName().Equals(DesiredName))
			{
				table.Append(DynValue.NewNumber(component.m_UniqueID));
			}
		}
		if (table.Length == 0)
		{
			table.Append(DynValue.NewNumber(-1.0));
		}
		return table;
	}
}
