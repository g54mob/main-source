using System;
using System.Collections.Generic;
using Data.FactoryFloor.Islands;
using Data.FactoryFloor.Maps;
using Data.Variables;
using Events;
using Events.FactoryFloor.Islands;
using Events.Generic;
using Logic.Factory;
using Presentation.FactoryFloor.Islands;
using Presentation.Locators;
using UnityEngine;
using Utils;

namespace Commands.ToolsCommands
{
	public class CreateIslandCommand : ICommand
	{
		private readonly GridLocator _gridLocator;

		private readonly GridLocator _gridMapLocator;

		private readonly IslandLayer _islandLayer;

		private readonly FactoryClearer _factoryClearer;

		private readonly BaseEvent _finishedLoadingSaveEvent;

		private readonly CurrentEditingIsland _currentEditingIsland;

		private readonly IslandObjectEvent _createIslandObjectEvent;

		private readonly IntEvent _deleteIslandEvent;

		private readonly BrushPositions _brushPositions;

		private readonly string _name;

		private readonly MaxZoomLevelModifierSO _maxZoomLevelModifier;

		private Vector2Int _size;

		private Guid _guid;

		public CreateIslandCommand(string name, GridLocator gridLocator, GridLocator gridMapLocator, IslandLayer islandLayer, FactoryClearer factoryClearer, BaseEvent finishedLoadingSaveEvent, CurrentEditingIsland currentEditingIsland, IslandObjectEvent createIslandObjectEvent, IntEvent deleteIslandEvent, BrushPositions brushPositions, Vector2Int size, Guid guid, MaxZoomLevelModifierSO maxZoomLevelModifier)
		{
			_name = name;
			_gridLocator = gridLocator;
			_gridMapLocator = gridMapLocator;
			_islandLayer = islandLayer;
			_factoryClearer = factoryClearer;
			_finishedLoadingSaveEvent = finishedLoadingSaveEvent;
			_currentEditingIsland = currentEditingIsland;
			_createIslandObjectEvent = createIslandObjectEvent;
			_deleteIslandEvent = deleteIslandEvent;
			_brushPositions = brushPositions;
			_maxZoomLevelModifier = maxZoomLevelModifier;
			_size = size;
			_guid = guid;
		}

		public bool TryDo()
		{
			_factoryClearer.ClearLevel();
			_brushPositions.Clear();
			if (!_currentEditingIsland.Empty)
			{
				_deleteIslandEvent.Fire(_currentEditingIsland.CreatedId);
			}
			Vector2 size = new Vector2((float)_size.x * _gridLocator.GetCellSize().x, (float)_size.y * _gridLocator.GetCellSize().z);
			int getNewId = IntIdGenerator.GetNewId;
			Vector2Int vector2Int = _size + new Vector2Int(16, 16);
			Vector2Int vector2Int2 = new Vector2Int((int)_gridMapLocator.GetCellSize().x, (int)_gridMapLocator.GetCellSize().z);
			Vector2Int size2 = new Vector2Int(vector2Int.x / vector2Int2.x, vector2Int.y / vector2Int2.y);
			Vector3Int zero = Vector3Int.zero;
			if (size2.x % 2 == 1)
			{
				zero.x += vector2Int2.x / 2;
			}
			if (size2.y % 2 == 1)
			{
				zero.z += vector2Int2.y / 2;
			}
			List<Vector3Int> occupiedGridPositions = GridUtils.GetOccupiedGridPositions(_gridMapLocator.GetCellPosition(zero), size2);
			Vector3 worldPosition = _gridLocator.GetWorldPosition(zero);
			worldPosition.y = 0f;
			IslandData islandData = new IslandData(_name, _guid, _size);
			_currentEditingIsland.SetCurrentIsland(getNewId, islandData);
			IslandObject islandObject = new IslandObject(new IslandConfig(islandData, getNewId, worldPosition, size, islandData.Size, 0, default(IslandConfig.IslandBottomPrefabConfig), isGnnGateIsland: false), occupiedGridPositions, _maxZoomLevelModifier);
			_islandLayer.AddIsland(islandObject);
			_createIslandObjectEvent.Fire(islandObject);
			_finishedLoadingSaveEvent.Fire();
			return true;
		}
	}
}
