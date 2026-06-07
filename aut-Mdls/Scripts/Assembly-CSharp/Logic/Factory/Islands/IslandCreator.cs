using System;
using Commands;
using Commands.ToolsCommands;
using Data.FactoryFloor.Islands;
using Data.FactoryFloor.Maps;
using Data.Variables;
using Events;
using Events.FactoryFloor.Islands;
using Events.Generic;
using Presentation.Locators;
using UnityEngine;

namespace Logic.Factory.Islands
{
	[CreateAssetMenu(menuName = "Factory/Tools/Islands/IslandCreator", fileName = "IslandCreator", order = 0)]
	public class IslandCreator : ScriptableObject
	{
		[SerializeField]
		private GridLocator _gridLocator;

		[SerializeField]
		private GridLocator _gridMapLocator;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private FactoryClearer _factoryClearer;

		[SerializeField]
		private BaseEvent _finishedLoadingSaveEvent;

		[SerializeField]
		private CurrentEditingIsland _currentEditingIsland;

		[SerializeField]
		private StreamingAssetsPathVariableSO _currentIslandWorkingPath;

		[SerializeField]
		private IslandObjectEvent _createIslandObjectEvent;

		[SerializeField]
		private IntEvent _deleteIslandEvent;

		[SerializeField]
		private CommandManager _commandManager;

		[SerializeField]
		private BrushPositions _brushPositions;

		[SerializeField]
		private MaxZoomLevelModifierSO _maxZoomLevelModifier;

		public void CreateNewIsland(Vector2Int size)
		{
			_commandManager.DoCommand(new CreateIslandCommand("Unnamed", _gridLocator, _gridMapLocator, _islandLayer, _factoryClearer, _finishedLoadingSaveEvent, _currentEditingIsland, _createIslandObjectEvent, _deleteIslandEvent, _brushPositions, size, Guid.NewGuid(), _maxZoomLevelModifier));
			_currentIslandWorkingPath.ResetToDefault();
		}

		public void CreateIslandWithId(string name, string guid, Vector2Int size)
		{
			if (Guid.TryParse(guid, out var result))
			{
				_commandManager.DoCommand(new CreateIslandCommand(name, _gridLocator, _gridMapLocator, _islandLayer, _factoryClearer, _finishedLoadingSaveEvent, _currentEditingIsland, _createIslandObjectEvent, _deleteIslandEvent, _brushPositions, size, result, _maxZoomLevelModifier));
			}
		}
	}
}
