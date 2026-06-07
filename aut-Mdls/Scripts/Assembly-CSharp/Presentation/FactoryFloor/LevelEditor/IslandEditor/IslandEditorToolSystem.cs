using Data.FactoryFloor.GameMode;
using Data.FactoryFloor.Islands;
using Data.FactoryFloor.Maps;
using Data.SaveData.PersistentSOs;
using Events.FactoryFloor.Islands;
using Events.Generic;
using Logic.Factory;
using Logic.FactoryTools.IslandEditor;
using Presentation.Locators;
using UnityEngine;

namespace Presentation.FactoryFloor.LevelEditor.IslandEditor
{
	public class IslandEditorToolSystem : MonoBehaviour
	{
		[SerializeField]
		private CurrentGameMode _currentGameMode;

		[SerializeField]
		private GameModeSO _levelEditorGameMode;

		[SerializeField]
		private LockedFactoryObjectsPersistentSO _lockedFactoryObjectsPersistentSO;

		[SerializeField]
		private IslandObjectEvent _createIslandObjectEvent;

		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistentSO;

		[Header("Tools")]
		[SerializeField]
		private ToolSystemLocator _toolSystemLocator;

		[Space]
		[SerializeField]
		private IntEvent _paintToolButtonPressed;

		[SerializeField]
		private IntEvent _paintBrushEnvironmentToolPressed;

		[SerializeField]
		private PaintBrushTool _paintBrushTool;

		[SerializeField]
		private PaintTextureTool _paintTextureTool;

		private void Start()
		{
			_lockedFactoryObjectsPersistentSO.UnlockAll();
			_currentGameMode.SwitchTo(_levelEditorGameMode);
		}

		private void OnEnable()
		{
			_paintToolButtonPressed.Register(SelectPaintTool);
			_paintBrushEnvironmentToolPressed.Register(SelectPaintBrushTool);
			_createIslandObjectEvent.Register(OnCreateIslandObject);
		}

		private void OnDisable()
		{
			_paintToolButtonPressed.UnRegister(SelectPaintTool);
			_paintBrushEnvironmentToolPressed.UnRegister(SelectPaintBrushTool);
			_createIslandObjectEvent.UnRegister(OnCreateIslandObject);
		}

		private void SelectPaintBrushTool(int obj)
		{
			_paintBrushTool.SetBrush(obj);
			_toolSystemLocator.ToolSystem.SelectTool(_paintBrushTool, null);
		}

		private void SelectPaintTool(int obj)
		{
			_paintTextureTool.SetColour(EnvironmentColorIDs.GetColor((EnvironmentColorIDs.FloorType)obj));
			_toolSystemLocator.ToolSystem.SelectTool(_paintTextureTool, null);
		}

		private void OnCreateIslandObject(IslandObject islandObject)
		{
			_unlockedIslandsPersistentSO.UnlockIsland(islandObject);
		}
	}
}
