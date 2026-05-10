using System;
using System.Collections;
using System.Collections.Generic;
using CTS;
using CTS.Core;
using UnityEngine;

public class MapEditor
{
	public delegate FurnitureSaveStruct[] LoadFurnituresToSaveDelegate(Transform container);

	public static LoadFurnituresToSaveDelegate GetFurnituresToSaveFromMapEditor;

	public static event Action<FurnitureSaveStruct> PlaceFurnitureFromSave;

	public static event Action<bool> OnBeginFurnituresLoading;

	public static event Action OnRefreshFurnitures;

	public static event Action LevelLoaded;

	public static Coroutine Load(GridEditionDataSO data)
	{
		MonoSingleton<UI_ConstructionSystem>.Instance.CloseBuildMode();
		Clear();
		return StaticCoroutines.StartStaticCoroutine(GenerateEnumerator(data));
	}

	public static GridSaveData[] GetAllGridData()
	{
		GridSaveData[] array = new GridSaveData[MonoSingleton<ConstructionSystem>.Instance.Grids.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = GetFloorGridData(i);
		}
		return array;
	}

	public static GridSaveData GetFloorGridData(int floor)
	{
		BuildingRoomContainer roomContainerAt = MonoSingleton<BuildingRoomsContainerManager>.Instance.GetRoomContainerAt(floor);
		Vector2Int getGridSize = roomContainerAt.Grid.GetGridSize;
		List<CellSaveData> list = new List<CellSaveData>();
		GridSaveData result = new GridSaveData
		{
			gridSize = getGridSize
		};
		for (int i = 0; i < getGridSize.x; i++)
		{
			for (int j = 0; j < getGridSize.y; j++)
			{
				list.Add(roomContainerAt.Grid.GetCell(new Vector2Int(i, j)).SaveCellFromEditor());
			}
		}
		result.assignationData = roomContainerAt.GetAssignationArray();
		result.cells = list.ToArray();
		return result;
	}

	public static void Clear()
	{
		MapEditor.OnRefreshFurnitures?.Invoke();
		MonoSingleton<ConstructionSystem>.Instance.ClearAllGrids();
	}

	public static void LoadAllGridData(GridSaveData[] data)
	{
		for (int i = 0; i < data.Length; i++)
		{
			LoadFloorGridData(i, data[i]);
		}
	}

	public static void LoadFloorGridData(int floor, GridSaveData data)
	{
		MonoSingleton<BuildingRoomsContainerManager>.Instance.CurrentStage = floor;
		MonoSingleton<ConstructionSystem>.Instance.CreateGridFromEditor(floor, data.cells);
		MonoSingleton<BuildingRoomsContainerManager>.Instance.GetRoomContainerAt(floor).SetAssignationArray(data.assignationData);
		MonoSingleton<BuildingRoomsContainerManager>.Instance.CurrentStage = 0;
		MonoSingleton<BuildingRoomsContainerManager>.Instance.ForceNavmeshRebake();
	}

	private static IEnumerator GenerateEnumerator(GridEditionDataSO data)
	{
		yield return Coroutines.WaitForSecondsUnscaled(0.2f);
		Clear();
		LoadAllGridData(data.grid);
		yield return Coroutines.WaitForSecondsUnscaled(0.2f);
		MonoSingleton<ConstructionSystem>.Instance.OnCloseBuildModeFromEditor();
		yield return Coroutines.WaitForSecondsUnscaled(0.2f);
		MapEditor.OnBeginFurnituresLoading?.Invoke(obj: true);
		for (int i = 0; i < data.furnitures.Length; i++)
		{
			MapEditor.PlaceFurnitureFromSave(data.furnitures[i]);
		}
		MapEditor.OnBeginFurnituresLoading?.Invoke(obj: false);
		MapEditor.LevelLoaded?.Invoke();
	}
}
