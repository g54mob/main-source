#define ENABLE_DEBUG_LOGS
#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.Collections.Generic;
using System.IO;
using Data.FactoryFloor;
using Data.FactoryFloor.Islands;
using Data.Operator;
using Data.Variables;
using Events.FactoryFloor.Islands;
using SFB;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.Island;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Logic.Factory.Islands
{
	[CreateAssetMenu(menuName = "Factory/Tools/Islands/IslandSaver", fileName = "IslandSaver", order = 0)]
	public class IslandSaver : ScriptableObject
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private FactoryLayer _terrainLayer;

		[SerializeField]
		private InputActionAsset _input;

		[SerializeField]
		private BrushPositions _brushPositions;

		[SerializeField]
		private FactoryObjectData _blockedTileFactoryObjectData;

		[SerializeField]
		private CurrentEditingIsland _currentEditingIsland;

		[SerializeField]
		private StreamingAssetsPathVariableSO _currentIslandWorkingPath;

		[SerializeField]
		private UpdateIslandIdEvent _updateIslandIdEvent;

		[SerializeField]
		private EnvironmentObjectsDatabase _environmentObjectsDatabase;

		public void SaveCurrentIslandAsNew()
		{
			int createdId = _currentEditingIsland.CreatedId;
			_currentEditingIsland.NewId();
			_updateIslandIdEvent.Fire(new IdPair
			{
				OldId = createdId,
				NewId = _currentEditingIsland.CreatedId
			});
			Vector3Int position = _currentEditingIsland.IslandData.Position;
			IslandSaveData islandSaveData = new IslandSaveData(_currentEditingIsland.Id.ToString(), GetAllSavedObjectDtos(_factoryLayer, position), GetAllSavedObjectDtos(_terrainLayer, position), _currentEditingIsland.IslandData.Size, _currentEditingIsland.GetFloorTextureToArray(), _brushPositions.GetBrushPositions());
			_input.Disable();
			string text;
			try
			{
				string directoryName = Path.GetDirectoryName(_currentIslandWorkingPath.Value);
				text = StandaloneFileBrowser.SaveFilePanel("Save island", directoryName, "Island-" + islandSaveData.Guid, "json");
			}
			catch (Exception ex)
			{
				this.LogAssertion(ex.Message, "SaveCurrentIslandAsNew", 57);
				_input.Enable();
				return;
			}
			_input.Enable();
			if (!string.IsNullOrEmpty(text))
			{
				SaveSystem.TrySaveData(islandSaveData, text);
				_currentIslandWorkingPath.SetValue(text);
				this.Log("Saved Island \"" + text + "\" (" + islandSaveData.Guid + ")", "SaveCurrentIslandAsNew", 72);
			}
		}

		public void SaveCurrentIsland()
		{
			Vector3Int position = _currentEditingIsland.IslandData.Position;
			IslandSaveData islandSaveData = new IslandSaveData(_currentEditingIsland.Id.ToString(), GetAllSavedObjectDtos(_factoryLayer, position), GetAllSavedObjectDtos(_terrainLayer, position), _currentEditingIsland.IslandData.Size, _currentEditingIsland.GetFloorTextureToArray(), _brushPositions.GetBrushPositions());
			if (!string.IsNullOrEmpty(_currentIslandWorkingPath.Value))
			{
				SaveSystem.TrySaveData(islandSaveData, _currentIslandWorkingPath.Value);
				this.Log("Saved Island \"" + _currentIslandWorkingPath.Value + "\" (" + islandSaveData.Guid + ")", "SaveCurrentIsland", 88);
			}
		}

		private List<SavedObjectDto> GetAllSavedObjectDtos(FactoryLayer layer, Vector3Int islandPosition)
		{
			List<SavedObjectDto> list = new List<SavedObjectDto>();
			foreach (FactoryObject allDistinctObjectList in layer.GetAllDistinctObjectLists())
			{
				list.Add(new SavedObjectDto(allDistinctObjectList.Position - islandPosition, allDistinctObjectList.Rotation, allDistinctObjectList.Mirrored, allDistinctObjectList.NonChangable, allDistinctObjectList.ObjectId, allDistinctObjectList.GetSoftLinkedObjectsPos(), allDistinctObjectList.GetHardLinkedObjectsPos(), allDistinctObjectList.GetConfigurations(), allDistinctObjectList.GetSaveStates()));
			}
			return list;
		}
	}
}
