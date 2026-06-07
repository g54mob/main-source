using System;
using System.Collections.Generic;
using System.Reflection;
using Client;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways;
using Motorways.Models;
using Motorways.Processes;
using Motorways.Themes;
using Motorways.Views;
using Server;
using UnityEngine;

public class InGameDevToolsRegistry : IInGameDevToolsRegistry, IReusable, IReleasedFromScopeHandler
{
	public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("InGameDevTools");

	private const int MaxGroupIndex = 5;

	private const KeyCode ClearToolsToNoneKeyCode = KeyCode.Z;

	[Dependency]
	private IScope _scope;

	[Dependency]
	private HotkeyDebugView _hotkeyDebugView;

	private List<IInGameDevTool> _allTools = new List<IInGameDevTool>();

	private HashSet<KeyCode> _modifierKeys = new HashSet<KeyCode>();

	private Dictionary<ToolModelType, MotorwaysModelContainerTool> _modelContainerTools = new Dictionary<ToolModelType, MotorwaysModelContainerTool>();

	private List<Action<string>> _onToolsChanged = new List<Action<string>>();

	private static bool VideoCaptureModeOn = false;

	public static bool SandboxModeOn = false;

	public List<IInGameDevTool> GetAllGenericDevTools()
	{
		if (_allTools.Count == 0)
		{
			RegisterTools();
		}
		return _allTools;
	}

	public List<ToolModelType> GetModelDevToolTypes()
	{
		if (_allTools.Count == 0)
		{
			RegisterTools();
		}
		return new List<ToolModelType>(_modelContainerTools.Keys);
	}

	public List<IInGameModelDevTool> GetAllModelToolsForModelType(ToolModelType toolModelType)
	{
		if (_allTools.Count == 0)
		{
			RegisterTools();
		}
		return _modelContainerTools[toolModelType].GetToolsForModel();
	}

	public void OnToolsChanged(Action<string> newOnToolsChangedCallback)
	{
		_onToolsChanged.Add(newOnToolsChangedCallback);
	}

	public void UpdateEditorIfPresent()
	{
		UpdateObservers();
	}

	protected void UpdateObservers()
	{
		string obj = "";
		foreach (Action<string> item in _onToolsChanged)
		{
			item(obj);
		}
	}

	public IInGameDevTool GetDevToolByCommandSerializationName(string commandSerializationName)
	{
		foreach (IInGameDevTool allTool in _allTools)
		{
			if (allTool.GetCommandSerializationName() == commandSerializationName)
			{
				return allTool;
			}
		}
		return null;
	}

	public IInGameModelDevTool GetModelDevToolByCommandSerializationName(string commandSerializationName)
	{
		foreach (KeyValuePair<ToolModelType, MotorwaysModelContainerTool> modelContainerTool in _modelContainerTools)
		{
			foreach (IInGameModelDevTool item in modelContainerTool.Value.GetToolsForModel())
			{
				if (item.GetCommandSerializationName() == commandSerializationName)
				{
					return item;
				}
			}
		}
		return null;
	}

	private DevToolType CreateDevToolWithName<DevToolType>(string commandSerializationName) where DevToolType : class, IInGameDevTool
	{
		IInGameDevTool devToolByCommandSerializationName = GetDevToolByCommandSerializationName(commandSerializationName);
		if (devToolByCommandSerializationName != null)
		{
			_allTools.Remove(devToolByCommandSerializationName);
		}
		DevToolType val = _scope.Get<DevToolType>();
		val.SetCommandSerializationName(commandSerializationName);
		val.PrepareTool();
		_allTools.Add(val);
		UpdateObservers();
		return val;
	}

	private DevToolType CreateModelDevToolWithName<DevToolType>(string commandSerializationName) where DevToolType : IInGameModelDevTool, new()
	{
		IInGameModelDevTool modelDevToolByCommandSerializationName = GetModelDevToolByCommandSerializationName(commandSerializationName);
		if (modelDevToolByCommandSerializationName != null)
		{
			_modelContainerTools[modelDevToolByCommandSerializationName.GetToolModelType()].RemoveTool(modelDevToolByCommandSerializationName);
		}
		DevToolType val = (DevToolType)_scope.Get(typeof(DevToolType));
		val.SetCommandSerializationName(commandSerializationName);
		val.PrepareTool();
		ToolModelType toolModelType = val.GetToolModelType();
		if (!_modelContainerTools.ContainsKey(toolModelType))
		{
			MotorwaysModelContainerTool value = CreateDevToolWithName<MotorwaysModelContainerTool>("GroupInspect" + toolModelType).SetModelType(toolModelType);
			_modelContainerTools.Add(toolModelType, value);
		}
		_modelContainerTools[toolModelType].RegisterNewTool(val);
		UpdateObservers();
		return val;
	}

	public void RespondToInGameToolUse()
	{
		bool flag = false;
		foreach (KeyCode modifierKey in _modifierKeys)
		{
			flag |= Input.GetKey(modifierKey);
		}
		foreach (IInGameDevTool allTool in _allTools)
		{
			bool flag2 = allTool.InGameHotkeyActivated();
			bool flag3 = allTool.GetModifierHotKey() != KeyCode.None;
			bool flag4 = allTool.InGameParameterHotKeyActivated();
			if ((flag2 && (flag3 || !flag)) || flag4)
			{
				allTool.OnHotkeyActivated(flag2);
			}
		}
	}

	public void OnReleasedFromScope(IScope scope)
	{
		foreach (IInGameDevTool allTool in _allTools)
		{
			scope.Release(allTool);
		}
		_allTools.Clear();
		_modifierKeys.Clear();
		foreach (MotorwaysModelContainerTool value in _modelContainerTools.Values)
		{
			scope.Release(value);
		}
		_modelContainerTools.Clear();
	}

	public void Reset()
	{
		_allTools.Clear();
		_modifierKeys.Clear();
		_modelContainerTools.Clear();
		_onToolsChanged.Clear();
	}

	public void RegisterTools()
	{
		if (!FeatureToggle.IsFeatureEnabled(Feature.InGameDevTools))
		{
			return;
		}
		CreateDevToolWithName<MotorwaysDevTool>("NoneTool").SetEditorDisplayName("None").SetEditorIconPath("Assets/Art/UI/Menus/Options/SPR_UI_MenuX.png");
		CreateDevToolWithName<MotorwaysDevTool>("AddDestination").SetEditorDisplayName("Add Destination").SetEditorIconPath("Assets/Art/UI/InGameBuilding/SPR_UI_Temp_InGameBuilding_00.png").ActivateOnDefaultActionInput()
			.DefaultToResettingToNoneAfterUse()
			.ShowGridWhenActive()
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				if (command.TryGetIntParameter("groupIndex", out var result) && command.TryGetBoolParameter("isDouble", out var result2) && command.TryGetEnumParameter<BuildingLayout>("buildingLayout", out var result3) && command.TryGetBoolParameter("upgrade", out var result4) && command.TryGetBoolParameter("isStation", out var result5))
				{
					bool flag = true;
					TileDirection result6 = TileDirection.None;
					DrivewayDirection result7;
					if (!result2)
					{
						flag = ((result3 != BuildingLayout.BuildingAbove) ? (flag & command.TryGetEnumParameter<DrivewayDirection>("singleDestinationToSideDrivewayDirections", out result7)) : (flag & command.TryGetEnumParameter<DrivewayDirection>("singleDestinationAboveDrivewayDirections", out result7)));
					}
					else
					{
						if (result5)
						{
							flag = ((result3 != BuildingLayout.BuildingAbove) ? (flag & command.TryGetEnumParameter<TileDirection>("stationDestinationVerticalCarparkSide", out result6)) : (flag & command.TryGetEnumParameter<TileDirection>("stationDestinationHorizontalCarparkSide", out result6)));
						}
						result7 = DrivewayDirection.Both;
					}
					if (flag)
					{
						CarparkEntrance carparkEntrance = CarparkEntrance.TopLeft;
						TileDirection drivewayDirection = ((result3 == BuildingLayout.BuildingAbove) ? TileDirection.East : TileDirection.South);
						switch (result7)
						{
						case DrivewayDirection.North:
							carparkEntrance = CarparkEntrance.TopLeft;
							break;
						case DrivewayDirection.South:
							carparkEntrance = CarparkEntrance.BottomRight;
							break;
						case DrivewayDirection.East:
							carparkEntrance = CarparkEntrance.BottomRight;
							break;
						case DrivewayDirection.West:
							carparkEntrance = CarparkEntrance.TopLeft;
							break;
						case DrivewayDirection.Both:
							carparkEntrance = CarparkEntrance.TopLeftAndBottomRight;
							break;
						}
						CarparkPreference carparkPreference = ((!(result5 && result2)) ? ((!result2) ? CarparkPreference.Solo : CarparkPreference.ForceDouble) : CarparkPreference.Station);
						if (!command.TryGetIntParameter("secondGroupIndex", out var result8))
						{
							result8 = -1;
						}
						if (!command.TryGetBoolParameter("secondUpgrade", out var result9))
						{
							result9 = false;
						}
						command.SpawnDestinationAtCursorPosition(carparkEntrance, carparkPreference, drivewayDirection, result6, result, result4, result8, result9);
					}
				}
			})
			.WithBoolParam(IngameDevToolBoolParameter.DefineBoolParameter("isDouble").SetEditorDisplayName("Is a double destination?").SetEditorTooltip("If true, the destination will have two buildings.")
				.SetValue(newValue: false)
				.SetDefaultValueForHotkey(newValue: false))
			.WithBoolParam(IngameDevToolBoolParameter.DefineBoolParameter("isStation").SetEditorDisplayName("Is a station?").SetEditorTooltip("If true, the destination will be a train station.")
				.ShowConditionallyOnBool("isDouble", valueToCheck: true)
				.SetValue(newValue: false)
				.SetDefaultValueForHotkey(newValue: false))
			.WithEnumParam(IngameDevToolEnumParameter<BuildingLayout>.DefineEnumParameter("buildingLayout").SetEditorDisplayName("Building Layout").SetEditorTooltip("Where should the building be relative to the carpark?")
				.SetValue(BuildingLayout.BuildingAbove)
				.SetDefaultValueForHotkey(BuildingLayout.BuildingAbove))
			.WithEnumParam(IngameDevToolEnumParameter<DrivewayDirection>.DefineEnumParameter("singleDestinationAboveDrivewayDirections").SetEditorDisplayName("Carpark Entrance").SetEditorTooltip("Which side of the carpark is the entrance on?")
				.ShowConditionallyOnBool("isDouble", valueToCheck: false)
				.ShowConditionallyOnBool("isStation", valueToCheck: false)
				.ShowConditionallyOnEnum("buildingLayout", BuildingLayout.BuildingAbove)
				.SetAllowedValues(new List<DrivewayDirection>
				{
					DrivewayDirection.West,
					DrivewayDirection.East
				})
				.SetValue(DrivewayDirection.West)
				.SetDefaultValueForHotkey(DrivewayDirection.West))
			.WithEnumParam(IngameDevToolEnumParameter<TileDirection>.DefineEnumParameter("stationDestinationVerticalCarparkSide").SetEditorDisplayName("Carpark Side").SetEditorTooltip("Which side of the entire destination are the carpark tiles on?")
				.ShowConditionallyOnBool("isDouble", valueToCheck: true)
				.ShowConditionallyOnBool("isStation", valueToCheck: true)
				.ShowConditionallyOnEnum("buildingLayout", BuildingLayout.BuildingToSide)
				.SetAllowedValues(new List<TileDirection>
				{
					TileDirection.West,
					TileDirection.East
				})
				.SetValue(TileDirection.West)
				.SetDefaultValueForHotkey(TileDirection.West))
			.WithEnumParam(IngameDevToolEnumParameter<TileDirection>.DefineEnumParameter("stationDestinationHorizontalCarparkSide").SetEditorDisplayName("Carpark Side").SetEditorTooltip("Which side of the entire destination are the carpark tiles on?")
				.ShowConditionallyOnBool("isDouble", valueToCheck: true)
				.ShowConditionallyOnBool("isStation", valueToCheck: true)
				.ShowConditionallyOnEnum("buildingLayout", BuildingLayout.BuildingAbove)
				.SetAllowedValues(new List<TileDirection>
				{
					TileDirection.South,
					TileDirection.North
				})
				.SetValue(TileDirection.South)
				.SetDefaultValueForHotkey(TileDirection.South))
			.WithEnumParam(IngameDevToolEnumParameter<DrivewayDirection>.DefineEnumParameter("singleDestinationToSideDrivewayDirections").SetEditorDisplayName("Carpark Entrance").SetEditorTooltip("Which side of the carpark is the entrance on?")
				.ShowConditionallyOnBool("isDouble", valueToCheck: false)
				.ShowConditionallyOnEnum("buildingLayout", BuildingLayout.BuildingToSide)
				.SetAllowedValues(new List<DrivewayDirection>
				{
					DrivewayDirection.North,
					DrivewayDirection.South
				})
				.SetValue(DrivewayDirection.North)
				.SetDefaultValueForHotkey(DrivewayDirection.North))
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("groupIndex").SetEditorDisplayName("Group Index").SetEditorTooltip("Which group should the destination belong to?")
				.SetMinimumValue(0)
				.SetMaximumValue(5))
			.WithBoolParam(IngameDevToolBoolParameter.DefineBoolParameter("upgrade").SetEditorDisplayName("Upgrade First Destination").SetEditorTooltip("The first (or only) destination will start as a circle")
				.SetValue(newValue: false)
				.SetDefaultValueForHotkey(newValue: false))
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("secondGroupIndex").SetEditorDisplayName("Second Destination Group Index").SetEditorTooltip("Which group should the destination belong to? (-1 indicates that it should be empty)")
				.SetMinimumValue(-1)
				.SetMaximumValue(5)
				.SetValue(-1)
				.SetDefaultValueForHotkey(-1)
				.ShowConditionallyOnBool("isDouble", valueToCheck: true))
			.WithBoolParam(IngameDevToolBoolParameter.DefineBoolParameter("secondUpgrade").SetEditorDisplayName("Upgrade Second Destination").SetEditorTooltip("The second destination will start as a circle")
				.SetValue(newValue: false)
				.SetDefaultValueForHotkey(newValue: false)
				.ShowConditionallyOnBool("isDouble", valueToCheck: true))
			.DrawOnTilesUnderCursor(delegate(MotorwaysDevTool devTool, Vector2Int newHoveredTile, DebugTileDataViewer tileDataView)
			{
				int parameterValue = devTool.GetIntParameter("groupIndex").ParameterValue;
				MotorwaysThemeDatabase motorwaysThemeDatabase = devTool.gameScope.Get<IThemeDatabase>() as MotorwaysThemeDatabase;
				Color buildingColor = (motorwaysThemeDatabase.GetTheme() as Theme).GetBuildingColor(parameterValue, ThemeComponentGroupTarget.BuildingBase);
				bool parameterValue2 = devTool.GetBoolParameter("isDouble").ParameterValue;
				BuildingLayout parameterValue3 = devTool.GetEnumParameter<BuildingLayout>("buildingLayout").ParameterValue;
				Color color = Color.black;
				if (parameterValue2)
				{
					int parameterValue4 = devTool.GetIntParameter("secondGroupIndex").ParameterValue;
					if (parameterValue4 != -1)
					{
						color = (motorwaysThemeDatabase.GetTheme() as Theme).GetBuildingColor(parameterValue4, ThemeComponentGroupTarget.BuildingBase);
					}
				}
				BuildingPlacer.Layout layout = null;
				int num = 0;
				DrivewayDirection drivewayDirection;
				if (parameterValue2)
				{
					drivewayDirection = DrivewayDirection.Both;
					layout = ((parameterValue3 != BuildingLayout.BuildingAbove) ? BuildingSpawningProcess.DoubleCarparkLayouts[0] : BuildingSpawningProcess.DoubleCarparkLayouts[1]);
				}
				else if (parameterValue3 == BuildingLayout.BuildingAbove)
				{
					drivewayDirection = devTool.GetEnumParameter<DrivewayDirection>("singleDestinationAboveDrivewayDirections").ParameterValue;
					layout = ((drivewayDirection == DrivewayDirection.West) ? BuildingSpawningProcess.SingleCarparkLayouts[0] : BuildingSpawningProcess.SingleCarparkLayouts[1]);
				}
				else
				{
					drivewayDirection = devTool.GetEnumParameter<DrivewayDirection>("singleDestinationToSideDrivewayDirections").ParameterValue;
					layout = ((drivewayDirection == DrivewayDirection.North) ? BuildingSpawningProcess.SingleCarparkLayouts[2] : BuildingSpawningProcess.SingleCarparkLayouts[3]);
				}
				tileDataView.squareTileData.Clear();
				tileDataView.checkerSquareTileData.Clear();
				Vector2Int coordinatesOffset = layout.driveways[num].coordinatesOffset;
				for (int i = 0; i < layout.footprint.x; i++)
				{
					for (int j = 0; j < layout.footprint.y; j++)
					{
						Vector2Int vector2Int = new Vector2Int(i, j);
						Vector2Int key = vector2Int + newHoveredTile;
						bool flag = false;
						if ((parameterValue3 != BuildingLayout.BuildingAbove) ? (vector2Int.x == coordinatesOffset.x) : (vector2Int.y == coordinatesOffset.y))
						{
							tileDataView.squareTileData.Add(key, Color.grey);
						}
						else
						{
							Color value = buildingColor;
							if (parameterValue2)
							{
								if (parameterValue3 == BuildingLayout.BuildingAbove && i > 1)
								{
									value = color;
								}
								else if (parameterValue3 == BuildingLayout.BuildingToSide && j < 2)
								{
									value = color;
								}
							}
							tileDataView.squareTileData.Add(key, value);
						}
					}
				}
				Vector2Int key2 = newHoveredTile + coordinatesOffset + TileUtilities.GetAdjacentCoordinates(Vector2Int.zero, layout.driveways[num].direction);
				tileDataView.squareTileData.Add(key2, Color.grey);
				if (parameterValue2 && drivewayDirection == DrivewayDirection.Both)
				{
					Vector2Int key3 = newHoveredTile + layout.driveways[num + 1].coordinatesOffset + TileUtilities.GetAdjacentCoordinates(Vector2Int.zero, layout.driveways[num + 1].direction);
					tileDataView.squareTileData.Add(key3, Color.grey);
				}
			})
			.ActivateOnInGameHotkey(KeyCode.T);
		CreateDevToolWithName<MotorwaysDevTool>("AddDoubleDestination").SetEditorDisplayName("Add Double Destination").SetEditorIconPath("Assets/Art/UI/InGameBuilding/SPR_UI_Temp_InGameBuilding_00.png").ActivateOnDefaultActionInput()
			.DefaultToResettingToNoneAfterUse()
			.ShowGridWhenActive()
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				if (command.TryGetIntParameter("groupIndex", out var result) && command.TryGetBoolParameter("isDouble", out var result2) && command.TryGetEnumParameter<BuildingLayout>("buildingLayout", out var result3) && command.TryGetBoolParameter("upgrade", out var result4) && command.TryGetBoolParameter("isStation", out var result5))
				{
					bool flag = true;
					TileDirection result6 = TileDirection.None;
					DrivewayDirection result7;
					if (!result2)
					{
						flag = ((result3 != BuildingLayout.BuildingAbove) ? (flag & command.TryGetEnumParameter<DrivewayDirection>("singleDestinationToSideDrivewayDirections", out result7)) : (flag & command.TryGetEnumParameter<DrivewayDirection>("singleDestinationAboveDrivewayDirections", out result7)));
					}
					else
					{
						if (result5)
						{
							flag = ((result3 != BuildingLayout.BuildingAbove) ? (flag & command.TryGetEnumParameter<TileDirection>("stationDestinationVerticalCarparkSide", out result6)) : (flag & command.TryGetEnumParameter<TileDirection>("stationDestinationHorizontalCarparkSide", out result6)));
						}
						result7 = DrivewayDirection.Both;
					}
					if (flag)
					{
						CarparkEntrance carparkEntrance = CarparkEntrance.TopLeft;
						TileDirection drivewayDirection = ((result3 == BuildingLayout.BuildingAbove) ? TileDirection.East : TileDirection.South);
						switch (result7)
						{
						case DrivewayDirection.North:
							carparkEntrance = CarparkEntrance.TopLeft;
							break;
						case DrivewayDirection.South:
							carparkEntrance = CarparkEntrance.BottomRight;
							break;
						case DrivewayDirection.East:
							carparkEntrance = CarparkEntrance.BottomRight;
							break;
						case DrivewayDirection.West:
							carparkEntrance = CarparkEntrance.TopLeft;
							break;
						case DrivewayDirection.Both:
							carparkEntrance = CarparkEntrance.TopLeftAndBottomRight;
							break;
						}
						CarparkPreference carparkPreference = ((!(result5 && result2)) ? ((!result2) ? CarparkPreference.Solo : CarparkPreference.ForceDouble) : CarparkPreference.Station);
						if (!command.TryGetIntParameter("secondGroupIndex", out var result8))
						{
							result8 = -1;
						}
						if (!command.TryGetBoolParameter("secondUpgrade", out var result9))
						{
							result9 = false;
						}
						command.SpawnDestinationAtCursorPosition(carparkEntrance, carparkPreference, drivewayDirection, result6, result, result4, result8, result9);
					}
				}
			})
			.WithBoolParam(IngameDevToolBoolParameter.DefineBoolParameter("isDouble").SetEditorDisplayName("Is a double destination?").SetEditorTooltip("If true, the destination will have two buildings.")
				.SetValue(newValue: true)
				.SetDefaultValueForHotkey(newValue: true))
			.WithBoolParam(IngameDevToolBoolParameter.DefineBoolParameter("isStation").SetEditorDisplayName("Is a station?").SetEditorTooltip("If true, the destination will be a train station.")
				.ShowConditionallyOnBool("isDouble", valueToCheck: true)
				.SetValue(newValue: false)
				.SetDefaultValueForHotkey(newValue: false))
			.WithEnumParam(IngameDevToolEnumParameter<BuildingLayout>.DefineEnumParameter("buildingLayout").SetEditorDisplayName("Building Layout").SetEditorTooltip("Where should the building be relative to the carpark?")
				.SetValue(BuildingLayout.BuildingAbove)
				.SetDefaultValueForHotkey(BuildingLayout.BuildingAbove))
			.WithEnumParam(IngameDevToolEnumParameter<DrivewayDirection>.DefineEnumParameter("singleDestinationAboveDrivewayDirections").SetEditorDisplayName("Carpark Entrance").SetEditorTooltip("Which side of the carpark is the entrance on?")
				.ShowConditionallyOnBool("isDouble", valueToCheck: true)
				.ShowConditionallyOnBool("isStation", valueToCheck: false)
				.ShowConditionallyOnEnum("buildingLayout", BuildingLayout.BuildingAbove)
				.SetAllowedValues(new List<DrivewayDirection>
				{
					DrivewayDirection.West,
					DrivewayDirection.East
				})
				.SetValue(DrivewayDirection.West)
				.SetDefaultValueForHotkey(DrivewayDirection.West))
			.WithEnumParam(IngameDevToolEnumParameter<TileDirection>.DefineEnumParameter("stationDestinationVerticalCarparkSide").SetEditorDisplayName("Carpark Side").SetEditorTooltip("Which side of the entire destination are the carpark tiles on?")
				.ShowConditionallyOnBool("isDouble", valueToCheck: true)
				.ShowConditionallyOnBool("isStation", valueToCheck: true)
				.ShowConditionallyOnEnum("buildingLayout", BuildingLayout.BuildingToSide)
				.SetAllowedValues(new List<TileDirection>
				{
					TileDirection.West,
					TileDirection.East
				})
				.SetValue(TileDirection.West)
				.SetDefaultValueForHotkey(TileDirection.West))
			.WithEnumParam(IngameDevToolEnumParameter<TileDirection>.DefineEnumParameter("stationDestinationHorizontalCarparkSide").SetEditorDisplayName("Carpark Side").SetEditorTooltip("Which side of the entire destination are the carpark tiles on?")
				.ShowConditionallyOnBool("isDouble", valueToCheck: true)
				.ShowConditionallyOnBool("isStation", valueToCheck: true)
				.ShowConditionallyOnEnum("buildingLayout", BuildingLayout.BuildingAbove)
				.SetAllowedValues(new List<TileDirection>
				{
					TileDirection.South,
					TileDirection.North
				})
				.SetValue(TileDirection.South)
				.SetDefaultValueForHotkey(TileDirection.South))
			.WithEnumParam(IngameDevToolEnumParameter<DrivewayDirection>.DefineEnumParameter("singleDestinationToSideDrivewayDirections").SetEditorDisplayName("Carpark Entrance").SetEditorTooltip("Which side of the carpark is the entrance on?")
				.ShowConditionallyOnBool("isDouble", valueToCheck: false)
				.ShowConditionallyOnEnum("buildingLayout", BuildingLayout.BuildingToSide)
				.SetAllowedValues(new List<DrivewayDirection>
				{
					DrivewayDirection.North,
					DrivewayDirection.South
				})
				.SetValue(DrivewayDirection.North)
				.SetDefaultValueForHotkey(DrivewayDirection.North))
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("groupIndex").SetEditorDisplayName("Group Index").SetEditorTooltip("Which group should the destination belong to?")
				.SetMinimumValue(0)
				.SetMaximumValue(5))
			.WithBoolParam(IngameDevToolBoolParameter.DefineBoolParameter("upgrade").SetEditorDisplayName("Upgrade First Destination").SetEditorTooltip("The first (or only) destination will start as a circle")
				.SetValue(newValue: false)
				.SetDefaultValueForHotkey(newValue: false))
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("secondGroupIndex").SetEditorDisplayName("Second Destination Group Index").SetEditorTooltip("Which group should the destination belong to? (-1 indicates that it should be empty)")
				.SetMinimumValue(-1)
				.SetMaximumValue(5)
				.SetValue(-1)
				.SetDefaultValueForHotkey(-1)
				.ShowConditionallyOnBool("isDouble", valueToCheck: true))
			.WithBoolParam(IngameDevToolBoolParameter.DefineBoolParameter("secondUpgrade").SetEditorDisplayName("Upgrade Second Destination").SetEditorTooltip("The second destination will start as a circle")
				.SetValue(newValue: false)
				.SetDefaultValueForHotkey(newValue: false)
				.ShowConditionallyOnBool("isDouble", valueToCheck: true))
			.DrawOnTilesUnderCursor(delegate(MotorwaysDevTool devTool, Vector2Int newHoveredTile, DebugTileDataViewer tileDataView)
			{
				int parameterValue = devTool.GetIntParameter("groupIndex").ParameterValue;
				MotorwaysThemeDatabase motorwaysThemeDatabase = devTool.gameScope.Get<IThemeDatabase>() as MotorwaysThemeDatabase;
				Color buildingColor = (motorwaysThemeDatabase.GetTheme() as Theme).GetBuildingColor(parameterValue, ThemeComponentGroupTarget.BuildingBase);
				bool parameterValue2 = devTool.GetBoolParameter("isDouble").ParameterValue;
				BuildingLayout parameterValue3 = devTool.GetEnumParameter<BuildingLayout>("buildingLayout").ParameterValue;
				Color color = Color.black;
				if (parameterValue2)
				{
					int parameterValue4 = devTool.GetIntParameter("secondGroupIndex").ParameterValue;
					if (parameterValue4 != -1)
					{
						color = (motorwaysThemeDatabase.GetTheme() as Theme).GetBuildingColor(parameterValue4, ThemeComponentGroupTarget.BuildingBase);
					}
				}
				BuildingPlacer.Layout layout = null;
				int num = 0;
				DrivewayDirection drivewayDirection;
				if (parameterValue2)
				{
					drivewayDirection = DrivewayDirection.Both;
					layout = ((parameterValue3 != BuildingLayout.BuildingAbove) ? BuildingSpawningProcess.DoubleCarparkLayouts[0] : BuildingSpawningProcess.DoubleCarparkLayouts[1]);
				}
				else if (parameterValue3 == BuildingLayout.BuildingAbove)
				{
					drivewayDirection = devTool.GetEnumParameter<DrivewayDirection>("singleDestinationAboveDrivewayDirections").ParameterValue;
					layout = ((drivewayDirection == DrivewayDirection.West) ? BuildingSpawningProcess.SingleCarparkLayouts[0] : BuildingSpawningProcess.SingleCarparkLayouts[1]);
				}
				else
				{
					drivewayDirection = devTool.GetEnumParameter<DrivewayDirection>("singleDestinationToSideDrivewayDirections").ParameterValue;
					layout = ((drivewayDirection == DrivewayDirection.North) ? BuildingSpawningProcess.SingleCarparkLayouts[2] : BuildingSpawningProcess.SingleCarparkLayouts[3]);
				}
				tileDataView.squareTileData.Clear();
				tileDataView.checkerSquareTileData.Clear();
				Vector2Int coordinatesOffset = layout.driveways[num].coordinatesOffset;
				for (int i = 0; i < layout.footprint.x; i++)
				{
					for (int j = 0; j < layout.footprint.y; j++)
					{
						Vector2Int vector2Int = new Vector2Int(i, j);
						Vector2Int key = vector2Int + newHoveredTile;
						bool flag = false;
						if ((parameterValue3 != BuildingLayout.BuildingAbove) ? (vector2Int.x == coordinatesOffset.x) : (vector2Int.y == coordinatesOffset.y))
						{
							tileDataView.squareTileData.Add(key, Color.grey);
						}
						else
						{
							Color value = buildingColor;
							if (parameterValue2)
							{
								if (parameterValue3 == BuildingLayout.BuildingAbove && i > 1)
								{
									value = color;
								}
								else if (parameterValue3 == BuildingLayout.BuildingToSide && j < 2)
								{
									value = color;
								}
							}
							tileDataView.squareTileData.Add(key, value);
						}
					}
				}
				Vector2Int key2 = newHoveredTile + coordinatesOffset + TileUtilities.GetAdjacentCoordinates(Vector2Int.zero, layout.driveways[num].direction);
				tileDataView.squareTileData.Add(key2, Color.grey);
				if (parameterValue2 && drivewayDirection == DrivewayDirection.Both)
				{
					Vector2Int key3 = newHoveredTile + layout.driveways[num + 1].coordinatesOffset + TileUtilities.GetAdjacentCoordinates(Vector2Int.zero, layout.driveways[num + 1].direction);
					tileDataView.squareTileData.Add(key3, Color.grey);
				}
			})
			.ActivateOnInGameHotkey(KeyCode.Y);
		CreateDevToolWithName<MotorwaysDevTool>("AddHouse").SetEditorDisplayName("Add House").SetEditorIconPath("Assets/Art/UI/SPR_UI_Button_home.png").ActivateOnDefaultActionInput()
			.DefaultToResettingToNoneAfterUse()
			.ShowGridWhenActive()
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				command.TryGetEnumParameter<TileDirection>("drivewayDirection", out var result);
				command.TryGetIntParameter("groupIndex", out var result2);
				command.SpawnHouse(result, result2);
			})
			.WithEnumParam(IngameDevToolEnumParameter<TileDirection>.DefineEnumParameter("drivewayDirection").SetEditorDisplayName("Driveway Direction").SetEditorTooltip("Which direction should the driveway face? Set to `None` for a random direction.")
				.SetValue(TileDirection.East)
				.SetDefaultValueForHotkey(TileDirection.East))
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("groupIndex").SetEditorDisplayName("Group Index").SetEditorTooltip("Which group should we the house belong to? Set to `-1` for random colour.")
				.SetMinimumValue(-1)
				.SetMaximumValue(5)
				.SetValue(0))
			.ActivateOnInGameHotkey(KeyCode.H)
			.DrawOnTilesUnderCursor(delegate(MotorwaysDevTool devTool, Vector2Int newHoveredTile, DebugTileDataViewer tileDataView)
			{
				tileDataView.Clear();
				BuildingPlacer buildingPlacer = _scope.Get<BuildingPlacer>();
				buildingPlacer.StartPlacing(TileContentType.House, 0, GroupingStyle.Normal, BuildingPlacer.WeightEvaluationLevel.IgnoreWeights);
				BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
				RectInt rectInt = (typeof(BuildingPlacer).GetField("_placeableArea", bindingAttr).GetValue(buildingPlacer) as RectInt?) ?? new RectInt(0, 0, 0, 0);
				List<Fix64> list = typeof(BuildingPlacer).GetField("_placeableTileWeights", bindingAttr).GetValue(buildingPlacer) as List<Fix64>;
				foreach (Vector2Int item in rectInt.allPositionsWithin)
				{
					Vector2Int vector2Int = item - rectInt.min;
					int index = vector2Int.x + rectInt.width * vector2Int.y;
					if (list[index] <= Fix64.Zero)
					{
						tileDataView.checkerSquareTileData.Add(item, Color.red);
					}
				}
				Color value = Color.Lerp(Color.grey, Color.clear, 0.8f);
				for (int i = rectInt.xMin - 1; i <= rectInt.xMax; i++)
				{
					tileDataView.squareTileData.Add(new Vector2Int(i, rectInt.yMin - 1), value);
					tileDataView.squareTileData.Add(new Vector2Int(i, rectInt.yMax), value);
				}
				for (int j = rectInt.yMin - 1; j <= rectInt.yMax; j++)
				{
					tileDataView.squareTileData[new Vector2Int(rectInt.xMin - 1, j)] = value;
					tileDataView.squareTileData[new Vector2Int(rectInt.xMax, j)] = value;
				}
				int parameterValue = devTool.GetIntParameter("groupIndex").ParameterValue;
				MotorwaysThemeDatabase motorwaysThemeDatabase = devTool.gameScope.Get<IThemeDatabase>() as MotorwaysThemeDatabase;
				Color value2 = ((parameterValue < 0) ? Color.white : (motorwaysThemeDatabase.GetTheme() as Theme).GetBuildingColor(parameterValue, ThemeComponentGroupTarget.BuildingBase));
				tileDataView.squareTileData[newHoveredTile] = value2;
				TileDirection parameterValue2 = devTool.GetEnumParameter<TileDirection>("drivewayDirection").ParameterValue;
				Vector2Int key = newHoveredTile + TileUtilities.GetAdjacencyOffsetForDirection(parameterValue2);
				tileDataView.squareTileData[key] = Color.grey;
				tileDataView.checkerTilesOn = true;
				tileDataView.squareTilesOn = true;
			});
		CreateDevToolWithName<MotorwaysDevTool>("RemoveDestination").SetEditorDisplayName("Remove Destination Or House").SetEditorIconPath("Assets/Art/UI/InGameBuilding/SPR_UI_Temp_InGameBuilding_00.png").ActivateOnDefaultActionInput()
			.DefaultToResettingToNoneAfterUse()
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				command.RemoveAnyBuilding();
			})
			.ActivateOnInGameHotkey(KeyCode.X);
		CreateDevToolWithName<MotorwaysDevTool>("ChangeGroupIndex").SetEditorDisplayName("Change Group Index").SetEditorIconPath("Assets/Art/UI/SPR_UI_Button_home.png").ActivateOnDefaultActionInput()
			.DefaultToResettingToNoneAfterUse()
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				if (command.TryGetIntParameter("groupIndex", out var result))
				{
					command.ChangeGroupIndex(result);
				}
			})
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("groupIndex").SetEditorDisplayName("Group Index").SetEditorTooltip("Which group should we change to?")
				.SetMinimumValue(0)
				.SetMaximumValue(5));
		CreateDevToolWithName<MotorwaysDevTool>("RotateDestination").SetEditorDisplayName("Rotate Destination").SetEditorIconPath("Assets/Art/UI/Icons/SPR_UI_Roundabout.png").ActivateOnDefaultActionInput()
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				command.RotateBuilding();
			});
		CreateDevToolWithName<MotorwaysDevTool>("FlipDestination").SetEditorDisplayName("Flip Destination").SetEditorIconPath("Assets/Art/UI/InGameBuilding/SPR_UI_Temp_InGameBuilding_00.png").ActivateOnDefaultActionInput()
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				command.FlipDestination();
			});
		CreateDevToolWithName<MotorwaysDevTool>("UpgradeDestination").SetEditorDisplayName("Upgrade Destination").SetEditorIconPath("Assets/Art/UI/InGameBuilding/SPR_UI_Temp_InGameBuilding_00.png").ActivateOnDefaultActionInput()
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				command.UpgradeDestination();
			})
			.ActivateOnInGameHotkey(KeyCode.Period);
		CreateDevToolWithName<MotorwaysDevTool>("DowngradeDestination").SetEditorDisplayName("Downgrade Destination").SetEditorIconPath("Assets/Art/UI/InGameBuilding/SPR_UI_Temp_InGameBuilding_00.png").ActivateOnDefaultActionInput()
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				command.DowngradeDestinations();
			})
			.ActivateOnInGameHotkey(KeyCode.Comma);
		CreateDevToolWithName<MotorwaysDevTool>("GrantUpgrade").SetEditorDisplayName("Grant Upgrade").SetEditorIconPath("Assets/Art/UI/Icons/SPR_UI_RoadStack.png").ActivateOnEditorButton("Grant Upgrades")
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				UpgradeDatabaseModel model = simulation.GetModel<UpgradeDatabaseModel>();
				command.TryGetIntParameter("concreteCount", out var result);
				if (result > 0)
				{
					model.ApplyUpgradePackage(new UpgradePackageDefinition
					{
						type = UpgradeType.Concrete,
						amount = result
					}, freeUpgrade: true);
				}
				command.TryGetIntParameter("bridgeCount", out var result2);
				if (result2 > 0)
				{
					model.ApplyUpgradePackage(new UpgradePackageDefinition
					{
						type = UpgradeType.Bridge,
						amount = result2
					}, freeUpgrade: true);
				}
				command.TryGetIntParameter("tunnelCount", out var result3);
				if (result3 > 0)
				{
					model.ApplyUpgradePackage(new UpgradePackageDefinition
					{
						type = UpgradeType.Tunnel,
						amount = result3
					}, freeUpgrade: true);
				}
				command.TryGetIntParameter("motorwayCount", out var result4);
				if (result4 > 0)
				{
					model.ApplyUpgradePackage(new UpgradePackageDefinition
					{
						type = UpgradeType.Motorway,
						amount = result4
					}, freeUpgrade: true);
				}
				command.TryGetIntParameter("trafficLightCount", out var result5);
				if (result5 > 0)
				{
					model.ApplyUpgradePackage(new UpgradePackageDefinition
					{
						type = UpgradeType.TrafficLight,
						amount = result5
					}, freeUpgrade: true);
				}
				command.TryGetIntParameter("roundaboutCount", out var result6);
				if (result6 > 0)
				{
					model.ApplyUpgradePackage(new UpgradePackageDefinition
					{
						type = UpgradeType.Roundabout,
						amount = result6
					}, freeUpgrade: true);
				}
			})
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("concreteCount").SetEditorDisplayName("Concrete Count").SetEditorTooltip("How much concrete to grant.")
				.SetDefaultValueForHotkey(20))
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("bridgeCount").SetEditorDisplayName("Bridge Count").SetEditorTooltip("How many bridges to grant.")
				.SetDefaultValueForHotkey(1))
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("tunnelCount").SetEditorDisplayName("Tunnel Count").SetEditorTooltip("How many tunnels to grant.")
				.SetDefaultValueForHotkey(1))
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("motorwayCount").SetEditorDisplayName("Motorway Count").SetEditorTooltip("How many motorways to grant.")
				.SetDefaultValueForHotkey(1))
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("trafficLightCount").SetEditorDisplayName("Traffic Light Count").SetEditorTooltip("How many traffic lights to grant.")
				.SetDefaultValueForHotkey(1))
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("roundaboutCount").SetEditorDisplayName("Roundabout Count").SetEditorTooltip("How many roundabouts to grant.")
				.SetDefaultValueForHotkey(1))
			.ActivateOnInGameHotkey(KeyCode.S);
		CreateDevToolWithName<MotorwaysDevTool>("RemoveUpgrade").SetEditorDisplayName("Remove Upgrade").SetEditorIconPath("Assets/Art/UI/Icons/SPR_UI_RoadStack.png").ActivateOnEditorButton("Remove Upgrades")
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				UpgradeDatabaseModel model = simulation.GetModel<UpgradeDatabaseModel>();
				command.TryGetIntParameter("concreteCount", out var result);
				if (result > 0)
				{
					result = Math.Min(result, model.GetAvailableUpgradeCount(UpgradeType.Concrete));
					Diagnostics.Verify(model.ConsumeUpgrade(UpgradeType.Concrete, result), "We tried to remove more {0} ({1}) than we had ({2}).", "Concrete", result, model.GetAvailableUpgradeCount(UpgradeType.Concrete));
				}
				command.TryGetIntParameter("bridgeCount", out var result2);
				if (result2 > 0)
				{
					result2 = Math.Min(result2, model.GetAvailableUpgradeCount(UpgradeType.Bridge));
					Diagnostics.Verify(model.ConsumeUpgrade(UpgradeType.Bridge, result2), "We tried to remove more {0} ({1}) than we had ({2}).", "Bridge", result2, model.GetAvailableUpgradeCount(UpgradeType.Bridge));
				}
				command.TryGetIntParameter("tunnelCount", out var result3);
				if (result3 > 0)
				{
					result3 = Math.Min(result3, model.GetAvailableUpgradeCount(UpgradeType.Tunnel));
					Diagnostics.Verify(model.ConsumeUpgrade(UpgradeType.Tunnel, result3), "We tried to remove more {0} ({1}) than we had ({2}).", "Tunnel", result3, model.GetAvailableUpgradeCount(UpgradeType.Tunnel));
				}
				command.TryGetIntParameter("motorwayCount", out var result4);
				if (result4 > 0)
				{
					result4 = Math.Min(result4, model.GetAvailableUpgradeCount(UpgradeType.Motorway));
					Diagnostics.Verify(model.ConsumeUpgrade(UpgradeType.Motorway, result4), "We tried to remove more {0} ({1}) than we had ({2}).", "Motorway", result4, model.GetAvailableUpgradeCount(UpgradeType.Motorway));
				}
				command.TryGetIntParameter("trafficLightCount", out var result5);
				if (result5 > 0)
				{
					result5 = Math.Min(result5, model.GetAvailableUpgradeCount(UpgradeType.TrafficLight));
					Diagnostics.Verify(model.ConsumeUpgrade(UpgradeType.TrafficLight, result5), "We tried to remove more {0} ({1}) than we had ({2}).", "TrafficLight", result5, model.GetAvailableUpgradeCount(UpgradeType.TrafficLight));
				}
				command.TryGetIntParameter("roundaboutCount", out var result6);
				if (result6 > 0)
				{
					result6 = Math.Min(result6, model.GetAvailableUpgradeCount(UpgradeType.Roundabout));
					Diagnostics.Verify(model.ConsumeUpgrade(UpgradeType.Roundabout, result6), "We tried to remove more {0} ({1}) than we had ({2}).", "Roundabout", result6, model.GetAvailableUpgradeCount(UpgradeType.Roundabout));
				}
			})
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("concreteCount").SetEditorDisplayName("Concrete Count").SetEditorTooltip("How much concrete to remove."))
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("bridgeCount").SetEditorDisplayName("Bridge Count").SetEditorTooltip("How many bridges to remove."))
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("tunnelCount").SetEditorDisplayName("Tunnel Count").SetEditorTooltip("How many tunnels to remove."))
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("motorwayCount").SetEditorDisplayName("Motorway Count").SetEditorTooltip("How many motorways to remove."))
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("trafficLightCount").SetEditorDisplayName("Traffic Light Count").SetEditorTooltip("How many traffic lights to remove."))
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("roundaboutCount").SetEditorDisplayName("Roundabout Count").SetEditorTooltip("How many roundabouts to remove."));
		CreateDevToolWithName<MotorwaysDevTool>("SetCitySpawnMode").SetEditorDisplayName("Set City SpawnMode").SetEditorIconPath("Assets/Art/UI/InGameBuilding/SPR_UI_Temp_InGameBuilding_00.png").ActivateOnEditorButton("Next Mode")
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				CityPlanModel.BuildingSpawningMode buildingSpawningMode = command.GetSpawningMode();
				switch (buildingSpawningMode)
				{
				case CityPlanModel.BuildingSpawningMode.None:
					buildingSpawningMode = CityPlanModel.BuildingSpawningMode.Houses;
					break;
				case CityPlanModel.BuildingSpawningMode.Houses:
					buildingSpawningMode = CityPlanModel.BuildingSpawningMode.Destinations;
					break;
				case CityPlanModel.BuildingSpawningMode.Destinations:
					buildingSpawningMode = CityPlanModel.BuildingSpawningMode.All;
					break;
				case CityPlanModel.BuildingSpawningMode.All:
					buildingSpawningMode = CityPlanModel.BuildingSpawningMode.None;
					break;
				}
				command.SetSpawningMode(buildingSpawningMode);
				_hotkeyDebugView.ShowMessage($"Spawning Mode is: {buildingSpawningMode}");
			})
			.ActivateOnInGameHotkey(KeyCode.L);
		CreateDevToolWithName<MotorwaysDevTool>("ToggleClockPaused").SetEditorDisplayName("Toggle Clock Paused").ActivateOnEditorButton("Toggle").SetEditorIconPath("Assets/Art/UI/Clock/SPR_UI_Clock_Face.png")
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				bool isPaused = simulation.GetModel<ClockModel>().isPaused;
				command.SetClockPaused(!isPaused);
				string text = ((!isPaused) ? "paused" : "unpaused");
				_hotkeyDebugView.ShowMessage("Clock " + text);
			})
			.ActivateOnInGameHotkey(KeyCode.K);
		CreateDevToolWithName<MotorwaysDevTool>("ClearAll").SetEditorDisplayName("Clear All").SetEditorIconPath("Assets/Art/UI/Icons/SPR_UI_Trashcan.png").ActivateOnEditorButton("Clear Selected On All Tiles")
			.SetClientCodeToExecute(delegate(MotorwaysDevTool tool, ISimulation simulation)
			{
				IngameDevToolBoolParameter boolParameter = tool.GetBoolParameter("roads");
				IngameDevToolBoolParameter boolParameter2 = tool.GetBoolParameter("destinations");
				IngameDevToolBoolParameter boolParameter3 = tool.GetBoolParameter("houses");
				bool parameterValue = boolParameter.ParameterValue;
				_ = boolParameter2.ParameterValue;
				_ = boolParameter3.ParameterValue;
				TilemapModel tilemapModel = _scope.Get<TilemapModel>();
				List<Vector2Int> list = new List<Vector2Int>();
				List<Vector2Int> list2 = new List<Vector2Int>();
				List<Vector2Int> list3 = new List<Vector2Int>();
				ModelListEnumerator<DestinationModel> enumerator2 = simulation.GetModels<DestinationModel>().GetEnumerator();
				while (enumerator2.MoveNext())
				{
					foreach (TileModel tileModel in enumerator2.Current.TileModels)
					{
						list2.Add(tileModel.Coordinates);
					}
				}
				ModelListEnumerator<HouseModel> enumerator4 = simulation.GetModels<HouseModel>().GetEnumerator();
				while (enumerator4.MoveNext())
				{
					HouseModel current4 = enumerator4.Current;
					list3.Add(current4.tileModel.Coordinates);
				}
				foreach (Vector2Int allTileCoordinate in tilemapModel.GetAllTileCoordinates())
				{
					if (!list2.Contains(allTileCoordinate) && !list3.Contains(allTileCoordinate))
					{
						Tile tile = tilemapModel.GetTile(allTileCoordinate);
						if (!tile.IsEmpty() && parameterValue && tile.GetTwoLaneRoadCount(RoadState.VisiblyActive | RoadState.Mothballed, Tile.MotorwayInclusion.Include) > 0)
						{
							list.Add(allTileCoordinate);
						}
					}
				}
				foreach (Vector2Int item2 in list)
				{
					if (parameterValue)
					{
						tool.RemoveRoadsAndUpgradesAtTileCoordinate(item2);
					}
				}
			})
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				command.TryGetBoolParameter("roads", out var _);
				command.TryGetBoolParameter("destinations", out var result2);
				command.TryGetBoolParameter("houses", out var result3);
				_scope.Get<TilemapModel>();
				List<Vector2Int> list = new List<Vector2Int>();
				List<Vector2Int> list2 = new List<Vector2Int>();
				ModelListEnumerator<DestinationModel> enumerator2 = simulation.GetModels<DestinationModel>().GetEnumerator();
				while (enumerator2.MoveNext())
				{
					foreach (TileModel tileModel2 in enumerator2.Current.TileModels)
					{
						list.Add(tileModel2.Coordinates);
					}
				}
				ModelListEnumerator<HouseModel> enumerator4 = simulation.GetModels<HouseModel>().GetEnumerator();
				while (enumerator4.MoveNext())
				{
					HouseModel current4 = enumerator4.Current;
					list2.Add(current4.tileModel.Coordinates);
				}
				foreach (Vector2Int item3 in list)
				{
					if (result2)
					{
						command.RemoveSpecificBuildingAtTileCoordinate(item3, TileContentType.Destination);
						command.RemoveSpecificBuildingAtTileCoordinate(item3, TileContentType.Carpark);
					}
				}
				foreach (Vector2Int item4 in list2)
				{
					if (result3)
					{
						command.RemoveSpecificBuildingAtTileCoordinate(item4, TileContentType.House);
					}
				}
			})
			.WithBoolParam(IngameDevToolBoolParameter.DefineBoolParameter("roads").SetEditorDisplayName("Clear Roads").SetEditorTooltip("This clears all road types that aren't driveways (includes bridges, tunnels, roundabouts, motorways, etc).")
				.SetValue(newValue: true)
				.SetDefaultValueForHotkey(newValue: true))
			.WithBoolParam(IngameDevToolBoolParameter.DefineBoolParameter("destinations").SetEditorDisplayName("Clear Destinations").SetEditorTooltip("This clears destinations and their entry roads.")
				.SetValue(newValue: true)
				.SetDefaultValueForHotkey(newValue: true))
			.WithBoolParam(IngameDevToolBoolParameter.DefineBoolParameter("houses").SetEditorDisplayName("Clear Houses").SetEditorTooltip("This clears houses and their driveways.")
				.SetValue(newValue: true)
				.SetDefaultValueForHotkey(newValue: true));
		CreateDevToolWithName<MotorwaysDevTool>("ChangePeepCountByColorGroup").SetEditorDisplayName("Change Peep Count By Color Group").SetEditorIconPath("Assets/Art/UI/InGameBuilding/SPR_UI_Temp_InGameBuilding_00.png").ActivateOnEditorButton("Apply")
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				if (command.TryGetIntParameter("groupIndex", out var result) && command.TryGetIntParameter("deltaPeepCount", out var result2))
				{
					command.ChangePeepCount(result2, result);
				}
			})
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("deltaPeepCount").SetEditorDisplayName("Change In Peep Count").SetEditorTooltip("This increase or decreases the unassigned peeps on all destinations of a given color.  It does not allow removing ones that are already assigned to cars!")
				.DontSetValueOnApply())
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("groupIndex").SetEditorDisplayName("Group Index").SetEditorTooltip("Which group should we change to?")
				.SetMinimumValue(0)
				.SetMaximumValue(5));
		CreateDevToolWithName<MotorwaysDevTool>("SetPinCountOnDestination").SetEditorDisplayName("Set Pin Count on Destination").SetEditorIconPath("Assets/Art/UI/InGameBuilding/SPR_UI_Temp_InGameBuilding_00.png").ActivateOnDefaultActionInput()
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				if (command.TryGetIntParameter("pinCount", out var result))
				{
					command.SetPinCountOnDestination(result);
				}
			})
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("pinCount").SetEditorDisplayName("Pin Count").SetEditorTooltip("The number of pins to set on a destination. If it removes pins, it does not allow removing ones that are already assigned to cars!")
				.DontSetValueOnApply()
				.SetMinimumValue(0)
				.SetMaximumValue(15));
		CreateDevToolWithName<MotorwaysDevTool>("IncreaseGlobalPeepCount").SetEditorDisplayName("Increase Global Peep Count").SetEditorIconPath("Assets/Art/UI/InGameBuilding/SPR_UI_Temp_InGameBuilding_00.png").ActivateOnEditorButton("Apply")
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				int targetGroupIndex = -1;
				if (command.TryGetIntParameter("deltaPeepCount", out var result))
				{
					command.ChangePeepCount(result, targetGroupIndex);
				}
			})
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("deltaPeepCount").SetEditorDisplayName("Number Of Peeps To Add").SetEditorTooltip("This increases the unassigned peeps on all destinations of all colors.")
				.SetDefaultValueForHotkey(1))
			.ActivateOnInGameHotkey(KeyCode.D);
		CreateDevToolWithName<MotorwaysDevTool>("DecreaseGlobalPeepCount").SetEditorDisplayName("Decrease Global Peep Count").SetEditorIconPath("Assets/Art/UI/InGameBuilding/SPR_UI_Temp_InGameBuilding_00.png").ActivateOnEditorButton("Apply")
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				int targetGroupIndex = -1;
				if (command.TryGetIntParameter("deltaPeepCount", out var result))
				{
					command.ChangePeepCount(-Mathf.Abs(result), targetGroupIndex);
				}
			})
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("deltaPeepCount").SetEditorDisplayName("Number Of Peeps To Remove").SetEditorTooltip("This decreases the unassigned peeps on all destinations of all colors.  It does not allow removing ones that are already assigned to cars!")
				.SetDefaultValueForHotkey(-1))
			.ActivateOnInGameHotkey(KeyCode.C);
		CreateDevToolWithName<MotorwaysDevTool>("AddScore").SetEditorDisplayName("Add Score").SetEditorIconPath("Assets/Art/Pin/Small/SPR_Pin_Small_BakedCol.png").ActivateOnEditorButton("Add")
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				if (command.TryGetIntParameter("scoreDelta", out var result))
				{
					ScoreModel model = simulation.GetModel<ScoreModel>();
					for (int i = 0; i < result; i++)
					{
						model.AddScore();
					}
					_hotkeyDebugView.ShowMessage($"Added {result} points ");
				}
			})
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("scoreDelta").SetEditorDisplayName("Score to add").SetDefaultValueForHotkey(100))
			.ActivateOnInGameHotkey(KeyCode.Equals);
		CreateDevToolWithName<MotorwaysDevTool>("ShowUpgradeScreen").SetEditorDisplayName("Show Upgrade Screen").SetEditorIconPath("Assets/Art/Pin/Small/SPR_Pin_Small_BakedCol.png").ActivateOnEditorButton("Show")
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				simulation.Scope.Get<UpgradeAwardingProcess>().GrantUpgradeChoice(1);
			})
			.ActivateOnInGameHotkey(KeyCode.Backslash);
		CreateDevToolWithName<MotorwaysDevTool>("EndGame").SetEditorDisplayName("Force Game Over").SetEditorIconPath("Assets/Art/Pin/Small/SPR_Pin_Small_BakedCol.png").ActivateOnEditorButton("Game Over")
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				simulation.GetModel<DestinationModel>().OnOvercrowded();
			})
			.ActivateOnInGameHotkey(KeyCode.R);
		CreateModelDevToolWithName<DestinationDevTool>("DestinationPeepCountChange").SetEditorDisplayName("Destination Change Peep Count").SetEditorIconPath("Assets/Art/UI/InGameBuilding/SPR_UI_Temp_InGameBuilding_00.png").SetModelCommandToExecute(delegate(MotorwaysModelDevToolCommand command, DestinationModel destinationModel, ISimulation simulation)
		{
			if (destinationModel.isActive && command.TryGetIntParameter("totalPeepCount", out var result))
			{
				if (result > destinationModel.TotalDemand)
				{
					int num = Mathf.Min(result, command.Scope.Get<City>().Rules.GetMaximumDemandForDestination(destinationModel));
					while (num > destinationModel.TotalDemand)
					{
						destinationModel.unassignedDemand.Add(destinationModel.GroupIndex);
					}
				}
				else
				{
					int num2 = Mathf.Max(result, 0);
					while (num2 < destinationModel.unassignedDemand.Count)
					{
						destinationModel.unassignedDemand.RemoveAt(destinationModel.unassignedDemand.Count - 1);
					}
				}
			}
		})
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("totalPeepCount", "TotalDemand").SetEditorDisplayName("Peep Count").SetEditorTooltip("This increase or decreases the unassigned peeps on a destination.  It does not allow removing ones that are already assigned to cars!")
				.DontSetValueOnApply());
		CreateModelDevToolWithName<DestinationDevTool>("DestinationAddSecondDestination").SetEditorDisplayName("Add Second Destination (Only Works On Double Destinations)").SetEditorIconPath("Assets/Art/UI/InGameBuilding/SPR_UI_Temp_InGameBuilding_00.png").SetModelCommandToExecute(delegate(MotorwaysModelDevToolCommand command, DestinationModel destinationModel, ISimulation simulation)
		{
			if (Diagnostics.Verify(destinationModel.isActive) && Diagnostics.Verify(destinationModel.Carpark.SupportsTwoDestinations, "The selected destination is a single destination!  Pick a double destination.") && Diagnostics.Verify(destinationModel.Carpark.ActiveDestinationCount < 2, "This double destination already has two destinations on it!"))
			{
				BuildingSpawningProcess buildingSpawningProcess = command.Scope.Get<BuildingSpawningProcess>();
				CityPlanModel.ScheduledBuilding scheduledBuilding = command.Scope.Get<CityPlanModel.ScheduledBuilding>();
				if (command.TryGetIntParameter("groupIndex", out scheduledBuilding.groupIndex))
				{
					scheduledBuilding.time = command.Scope.Get<ClockModel>().ExpansionTime;
					scheduledBuilding.type = CityTileType.Demand;
					scheduledBuilding.grouping = GroupingStyle.Normal;
					scheduledBuilding.demandMultiplier = Fix64.One;
					buildingSpawningProcess.AddBuildingToDoubleCarpark(simulation, scheduledBuilding, destinationModel.Carpark, DestinationModel.DestinationType.Destination);
				}
			}
		})
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("groupIndex").SetEditorDisplayName("Group Index").SetEditorTooltip("The group index you want the new building to be set to!")
				.SetMinimumValue(0)
				.SetMaximumValue(5));
		CreateModelDevToolWithName<DestinationDevTool>("DestinationInspectData").SetEditorDisplayName("Destination Data Inspector").SetEditorIconPath("Assets/Art/UI/InGameBuilding/SPR_UI_Temp_InGameBuilding_00.png").OverrideDrawEditorToolFunction(delegate(DestinationDevTool tool)
		{
			tool.DrawBaseEditorTool(tool);
		})
			.DrawOnTilesUnderCursor(delegate(DestinationDevTool tool, Vector2Int position, DebugTileDataViewer debugTileDataViewer)
			{
				if (tool.SelectedModel != null)
				{
					debugTileDataViewer.onlyDrawWhenSelected = false;
					debugTileDataViewer.textSize = 20;
					debugTileDataViewer.stringData.Clear();
					float num = (float)tool.SelectedModel.RequiredSupply;
					string value = $"{num:F2}";
					if (debugTileDataViewer.stringData.ContainsKey(tool.SelectedModel.Carpark.TopLeftWorldCoordinate))
					{
						debugTileDataViewer.stringData[tool.SelectedModel.Carpark.TopLeftWorldCoordinate] = value;
					}
					else
					{
						debugTileDataViewer.stringData.Add(tool.SelectedModel.Carpark.TopLeftWorldCoordinate, value);
					}
					int num2 = 0;
					ModelListEnumerator<DestinationModel> enumerator2 = tool.gameScope.Get<Simulation>().GetModels<DestinationModel>().GetEnumerator();
					while (enumerator2.MoveNext())
					{
						if (enumerator2.Current.GroupIndex == tool.SelectedModel.GroupIndex)
						{
							num2++;
						}
					}
					DemandModel demandModel = tool.gameScope.Get<DemandModel>();
					ModelListEnumerator<HouseModel> enumerator3 = tool.gameScope.Get<Simulation>().GetModels<HouseModel>().GetEnumerator();
					while (enumerator3.MoveNext())
					{
						HouseModel current3 = enumerator3.Current;
						if (current3.GroupIndex == tool.SelectedModel.GroupIndex)
						{
							float num3 = (float)demandModel.CalculateSupplyContributionFromHouseToDestination(current3, tool.SelectedModel) / (float)num2;
							value = $"{num3:F2}";
							if (!debugTileDataViewer.stringData.ContainsKey(current3.tileModel.Coordinates))
							{
								debugTileDataViewer.stringData.Add(current3.tileModel.Coordinates, value);
							}
							else
							{
								debugTileDataViewer.stringData[current3.tileModel.Coordinates] = value;
							}
						}
					}
				}
			})
			.SetOnModelSelectedCommandToExecute(delegate(MotorwaysModelDevTool<DestinationModel, DestinationDevTool> tool, DestinationModel model)
			{
				tool.OnToolDeselected();
			});
		CreateModelDevToolWithName<HouseDevTool>("HouseInspectData").SetEditorDisplayName("House Data Inspector").SetEditorIconPath("Assets/Art/UI/InGameBuilding/SPR_UI_Temp_InGameBuilding_00.png").OverrideDrawEditorToolFunction(delegate(HouseDevTool tool)
		{
			tool.DrawBaseEditorTool(tool);
		})
			.DrawOnTilesUnderCursor(delegate(HouseDevTool tool, Vector2Int position, DebugTileDataViewer debugTileDataViewer)
			{
				if (tool.SelectedModel != null)
				{
					debugTileDataViewer.onlyDrawWhenSelected = false;
					debugTileDataViewer.textSize = 20;
					debugTileDataViewer.stringData.Clear();
					int num = 0;
					float num2 = 0f;
					ModelListEnumerator<DestinationModel> enumerator2 = tool.gameScope.Get<Simulation>().GetModels<DestinationModel>().GetEnumerator();
					while (enumerator2.MoveNext())
					{
						if (enumerator2.Current.GroupIndex == tool.SelectedModel.GroupIndex)
						{
							num++;
						}
					}
					enumerator2 = tool.gameScope.Get<Simulation>().GetModels<DestinationModel>().GetEnumerator();
					string value;
					while (enumerator2.MoveNext())
					{
						DestinationModel current3 = enumerator2.Current;
						if (current3.GroupIndex == tool.SelectedModel.GroupIndex)
						{
							DemandModel demandModel = tool.gameScope.Get<DemandModel>();
							float num3 = (float)(demandModel.CalculateSupplyContributionFromHouseToDestination(tool.SelectedModel, current3) * demandModel.GetSupplyScale(current3.GroupIndex));
							float num4 = (float)current3.RequiredSupply;
							num2 += num3;
							value = $"Add\n{num3:F2} of\n{num4:F2}";
							if (debugTileDataViewer.stringData.ContainsKey(current3.Carpark.TopLeftWorldCoordinate))
							{
								debugTileDataViewer.stringData[current3.Carpark.TopLeftWorldCoordinate] = value;
							}
							else
							{
								debugTileDataViewer.stringData.Add(current3.Carpark.TopLeftWorldCoordinate, value);
							}
						}
					}
					value = $"Total\n{num2:F2}";
					if (debugTileDataViewer.stringData.ContainsKey(tool.SelectedModel.tileModel.Coordinates))
					{
						debugTileDataViewer.stringData[tool.SelectedModel.tileModel.Coordinates] = value;
					}
					else
					{
						debugTileDataViewer.stringData.Add(tool.SelectedModel.tileModel.Coordinates, value);
					}
				}
			})
			.SetOnModelSelectedCommandToExecute(delegate(MotorwaysModelDevTool<HouseModel, HouseDevTool> tool, HouseModel model)
			{
				tool.OnToolDeselected();
			});
		CreateDevToolWithName<MotorwaysDevTool>("SkipAheadTime").SetEditorDisplayName("Skip Ahead Time").SetEditorIconPath("Assets/Art/UI/Icons/SPR_UI_FastForward.png").ActivateOnEditorButton("Skip!")
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				bool flag = command.TryGetFloatParameter("skipAheadDurationHours", out var result);
				flag = command.TryGetFloatParameter("skipAheadDurationDays", out var result2) || flag;
				if (command.TryGetFloatParameter("skipAheadDurationWeeks", out var result3) || flag)
				{
					Fix64 fix = (Fix64)(5.0 / 6.0);
					Fix64 fix2 = result * fix;
					fix *= (Fix64)24f;
					fix2 += result2 * fix;
					fix *= (Fix64)7f;
					fix2 += result3 * fix;
					if (Diagnostics.Verify(fix2 >= Fix64.Zero))
					{
						Game game = command.Scope.Get<Game>();
						if (game != null && command.TryGetBoolParameter("unpauseGame", out var result4))
						{
							if (simulation.IsPaused && result4)
							{
								simulation.IsPaused = false;
							}
							game.AddArbitraryAccumulatedTime(fix2);
						}
					}
				}
			})
			.WithFloatParam(IngameDevToolFloatParameter.DefineFloatParameter("skipAheadDurationHours").SetEditorDisplayName("Hours To Skip Ahead").SetEditorTooltip("This is in hours.")
				.SetDefaultValueForHotkey(Fix64Consts.Zero))
			.WithFloatParam(IngameDevToolFloatParameter.DefineFloatParameter("skipAheadDurationDays").SetEditorDisplayName("Days To Skip Ahead").SetEditorTooltip("This is in days.")
				.SetDefaultValueForHotkey(Fix64Consts.One))
			.WithFloatParam(IngameDevToolFloatParameter.DefineFloatParameter("skipAheadDurationWeeks").SetEditorDisplayName("Weeks To Skip Ahead").SetEditorTooltip("This is in weeks.")
				.SetDefaultValueForHotkey(Fix64Consts.Zero))
			.WithBoolParam(IngameDevToolBoolParameter.DefineBoolParameter("unpauseGame").SetEditorDisplayName("Unpause Game If Needed").SetEditorTooltip("This tool only works if the game is unpaused.  When this is checked the game will automatically be unpaused immediately before skipping ahead.")
				.SetValue(newValue: true)
				.SetDefaultValueForHotkey(newValue: true))
			.ActivateOnInGameHotkey(KeyCode.F);
		CreateDevToolWithName<MotorwaysDevTool>("SkipAheadExpansionTime").SetEditorDisplayName("Skip Ahead Expansion Time").SetEditorIconPath("Assets/Art/UI/Icons/SPR_UI_FastForward.png").ActivateOnEditorButton("Skip!")
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				bool flag = command.TryGetFloatParameter("skipAheadDurationHours", out var result);
				flag = command.TryGetFloatParameter("skipAheadDurationDays", out var result2) || flag;
				if (command.TryGetFloatParameter("skipAheadDurationWeeks", out var result3) || flag)
				{
					Fix64 fix = (Fix64)(5.0 / 6.0);
					Fix64 fix2 = result * fix;
					fix *= (Fix64)24f;
					fix2 += result2 * fix;
					fix *= (Fix64)7f;
					fix2 += result3 * fix;
					if (Diagnostics.Verify(fix2 >= Fix64.Zero))
					{
						simulation.GetModel<ClockModel>().CurrentFrame.expansionTime += fix2;
						simulation.GetModel<ClockModel>().NextFrame.expansionTime += fix2;
						UpgradeDatabaseModel upgradeDatabaseModel = command.Scope.Get<UpgradeDatabaseModel>();
						if (upgradeDatabaseModel.upgradeSchedulePaused)
						{
							upgradeDatabaseModel.accumulatedUpgradeScheduleDelayTime += fix2;
						}
						CityPlanModel cityPlanModel = command.Scope.Get<CityPlanModel>();
						if (cityPlanModel != null && cityPlanModel.scheduledBuildings.Count > 0)
						{
							cityPlanModel.scheduledBuildings[0].time += fix2;
						}
					}
				}
			})
			.WithFloatParam(IngameDevToolFloatParameter.DefineFloatParameter("skipAheadDurationHours").SetEditorDisplayName("Hours To Skip Ahead").SetEditorTooltip("This is in hours.")
				.SetDefaultValueForHotkey(Fix64Consts.Zero))
			.WithFloatParam(IngameDevToolFloatParameter.DefineFloatParameter("skipAheadDurationDays").SetEditorDisplayName("Days To Skip Ahead").SetEditorTooltip("This is in days.")
				.SetDefaultValueForHotkey(Fix64Consts.Zero))
			.WithFloatParam(IngameDevToolFloatParameter.DefineFloatParameter("skipAheadDurationWeeks").SetEditorDisplayName("Weeks To Skip Ahead").SetEditorTooltip("This is in weeks.")
				.SetDefaultValueForHotkey((Fix64)3L))
			.ActivateOnInGameHotkey(KeyCode.E);
		CreateDevToolWithName<MotorwaysDevTool>("ToggleUpgrades").SetEditorDisplayName("Toggle Recurring Upgrades").SetEditorIconPath("Assets/Art/UI/Icons/SPR_UI_Pause.png").ActivateOnEditorButton("Toggle Recurring Upgrades (e.g. Weekly/Milestones)")
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				UpgradeDatabaseModel upgradeDatabaseModel = command.Scope.Get<UpgradeDatabaseModel>();
				upgradeDatabaseModel.upgradeSchedulePaused = !upgradeDatabaseModel.upgradeSchedulePaused;
				_hotkeyDebugView.ShowMessage("Recurring Upgrades: " + (upgradeDatabaseModel.upgradeSchedulePaused ? "OFF" : "ON"));
			})
			.ActivateOnInGameHotkey(KeyCode.U);
		CreateDevToolWithName<MotorwaysDevTool>("ResetAllCars").SetEditorDisplayName("Reset All Cars To Houses").SetEditorIconPath("Assets/Art/UI/Icons/SPR_UI_Car.png").ActivateOnEditorButton("Reset")
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				ModelListEnumerator<VehicleModel> enumerator2 = simulation.GetModels<VehicleModel>().GetEnumerator();
				while (enumerator2.MoveNext())
				{
					enumerator2.Current.ResetToHouse();
				}
			});
		CreateDevToolWithName<MotorwaysDevTool>("TogglePinVisibility").SetEditorDisplayName("Toggle pin visibility").SetEditorIconPath("Assets/Art/Pin/Small/SPR_Pin_Small_BakedCol.png").ActivateOnEditorButton("Toggle")
			.SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
			{
				bool flag = false;
				bool flag2 = false;
				foreach (DestinationView view in simulation.Scope.Get<ViewClient>().GetViews<DestinationView>())
				{
					if (!flag2 && !view.IsShowingPins)
					{
						flag = true;
						flag2 = true;
					}
					view.SetPinViewVisible(flag);
				}
				_hotkeyDebugView.ShowMessage("Pin Visibility: " + (flag ? "ON" : "OFF"));
			})
			.ActivateOnInGameHotkey(KeyCode.Semicolon);
		CreateDevToolWithName<MotorwaysDevTool>("SetDrawToggleVisiblity").SetEditorDisplayName("Set Draw Toggle Visibility").SetEditorIconPath("Assets/Art/PlatformResources/AppleMFIController/SPR_ControllerDraw.png").SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
		{
			if (command.TryGetBoolParameter("drawButtonsHidden", out var result))
			{
				GameUIScreen gameUIScreen = UnityEngine.Object.FindObjectOfType<GameUIScreen>();
				gameUIScreen.SetDrawButtonsHiddenByTutorial(result);
				gameUIScreen.SetDrawButtonsVisible(!result);
			}
		})
			.WithBoolParam(IngameDevToolBoolParameter.DefineBoolParameter("drawButtonsHidden").SetEditorTooltip("Hide the draw toggle buttons.").SetEditorDisplayName("Hidden")
				.SetValue(newValue: false))
			.ActivateOnEditorButton("Apply");
		CreateDevToolWithName<MotorwaysDevTool>("ToggleHUDVisibility").SetEditorDisplayName("Toggle HUD Visibility").SetEditorIconPath("Assets/Art/PlatformResources/AppleMFIController/SPR_ControllerDraw.png").SetCommandToExecute(delegate
		{
			GameUIScreen gameUIScreen = UnityEngine.Object.FindObjectOfType<GameUIScreen>();
			_hotkeyDebugView.ShowMessage("HUD: " + ((!gameUIScreen.DebugToolsHideUI) ? "OFF" : "ON"));
			gameUIScreen.DebugToolsHideUI = !gameUIScreen.DebugToolsHideUI;
		})
			.ActivateOnEditorButton("Toggle HUD Visibility")
			.ActivateOnInGameHotkey(KeyCode.I);
		CreateDevToolWithName<MotorwaysDevTool>("ToggleWorldGridVisibility").SetEditorDisplayName("Toggle WorldGrid Visibility").SetEditorIconPath("Assets/Art/PlatformResources/AppleMFIController/SPR_ControllerDraw.png").SetCommandToExecute(delegate
		{
			GameUIScreen gameUIScreen = UnityEngine.Object.FindObjectOfType<GameUIScreen>();
			_hotkeyDebugView.ShowMessage("World Grid: " + ((!gameUIScreen.DebugToolsHideWorldGrid) ? "OFF" : "ON"));
			gameUIScreen.DebugToolsHideWorldGrid = !gameUIScreen.DebugToolsHideWorldGrid;
		})
			.ActivateOnEditorButton("Toggle WorldGrid Visibility")
			.ActivateOnInGameHotkey(KeyCode.O);
		CreateDevToolWithName<MotorwaysDevTool>("SetHudAndWorldGridVisibility").SetEditorDisplayName("Set HUD & World Grid Visibility").SetEditorIconPath("Assets/Art/PlatformResources/AppleMFIController/SPR_ControllerDraw.png").SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
		{
			if (command.TryGetBoolParameter("hudHidden", out var result) && command.TryGetBoolParameter("worldGridHidden", out var result2))
			{
				GameUIScreen gameUIScreen = UnityEngine.Object.FindObjectOfType<GameUIScreen>();
				gameUIScreen.DebugToolsHideWorldGrid = result2;
				gameUIScreen.DebugToolsHideUI = result;
			}
		})
			.WithBoolParam(IngameDevToolBoolParameter.DefineBoolParameter("hudHidden").SetEditorTooltip("Set the HUD hidden.").SetEditorDisplayName("HUD Hidden")
				.SetDefaultValueForHotkey(newValue: true)
				.SetValue(newValue: true))
			.WithBoolParam(IngameDevToolBoolParameter.DefineBoolParameter("worldGridHidden").SetEditorTooltip("Set the world grid hidden.").SetEditorDisplayName("World Grid Hidden")
				.SetDefaultValueForHotkey(newValue: true)
				.SetValue(newValue: true))
			.ActivateOnEditorButton("Apply");
		CreateDevToolWithName<MotorwaysDevTool>("ForceUpdateTheme").SetEditorDisplayName("Force Update Theme").SetEditorIconPath("Assets/Art/UI/Menus/Pause/SPR_PauseUI_NightOff.png").SetCommandToExecute(delegate
		{
			_hotkeyDebugView.ShowMessage("Force Update Theme");
		})
			.ActivateOnEditorButton("Update")
			.ActivateOnInGameHotkey(KeyCode.Slash);
		CreateDevToolWithName<MotorwaysDevTool>("ChangeLocaleForward").SetEditorDisplayName("Change Locale Forward").SetEditorIconPath("Assets/Art/UI/Menus/Pause/SPR_PauseUI_NightOff.png").SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
		{
			LocaleDatabase localeDatabase = simulation.Scope.Get<LocaleDatabase>();
			int index = (localeDatabase.GetIndex(localeDatabase.CurrentLocale) + 1) % localeDatabase.LocaleCount;
			LocaleDatabase.LocaleId id = localeDatabase.GetLocale(index).Id;
			_hotkeyDebugView.ShowMessage($"Setting Locale: {id}");
			simulation.Scope.Get<IActivePlayer>().LocaleId = id;
		})
			.ActivateOnEditorButton("Previous Locale")
			.ActivateOnInGameHotkey(KeyCode.Period, KeyCode.LeftShift);
		CreateDevToolWithName<MotorwaysDevTool>("ChangeLocaleBackward").SetEditorDisplayName("Change Locale Backward").SetEditorIconPath("Assets/Art/UI/Menus/Pause/SPR_PauseUI_NightOff.png").SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
		{
			LocaleDatabase localeDatabase = simulation.Scope.Get<LocaleDatabase>();
			int num = localeDatabase.GetIndex(localeDatabase.CurrentLocale) - 1;
			if (num == -1)
			{
				num = localeDatabase.LocaleCount - 1;
			}
			LocaleDatabase.LocaleId id = localeDatabase.GetLocale(num).Id;
			_hotkeyDebugView.ShowMessage($"Setting Locale: {id}");
			simulation.Scope.Get<IActivePlayer>().LocaleId = id;
		})
			.ActivateOnEditorButton("Previous Locale")
			.ActivateOnInGameHotkey(KeyCode.Comma, KeyCode.LeftShift);
		CreateDevToolWithName<MotorwaysDevTool>("PauseSimulation").SetEditorDisplayName("Toggle Pause Simulation").SetEditorIconPath("Assets/Art/UI/Icons/SPR_UI_Pause.png").SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
		{
			simulation.Scope.Get<Game>().SetPaused(!simulation.IsPaused);
			string text = (simulation.IsPaused ? "paused" : "unpaused");
			_hotkeyDebugView.ShowMessage("Simulation " + text);
		})
			.ActivateOnEditorButton("Toggle Paused")
			.ActivateOnInGameHotkey(KeyCode.P);
		CreateDevToolWithName<MotorwaysDevTool>("ToggleGodMode").SetEditorDisplayName("Toggle God Mode").SetEditorIconPath("Assets/Art/UI/ChallengeMode/ChallengeIcons/MO_Challenge_Sub_Double_In.png").SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
		{
			GameBehaviourModel model = simulation.GetModel<GameBehaviourModel>();
			model.CanGameOver = !model.CanGameOver;
			_hotkeyDebugView.ShowMessage("God mode: " + (model.CanGameOver ? "OFF" : "ON"));
			BuildingsIndicatorView buildingsIndicatorView = simulation.Scope.Get<BuildingsIndicatorView>();
			bool flag = !model.CanGameOver;
			if (flag)
			{
				buildingsIndicatorView.StopPulsing();
			}
			else
			{
				buildingsIndicatorView.StartPulsing();
			}
			buildingsIndicatorView.AlertsEnabled = !flag;
		})
			.ActivateOnEditorButton("Toggle God Mode")
			.ActivateOnInGameHotkey(KeyCode.G);
		CreateDevToolWithName<MotorwaysDevTool>("ToggleDisconnectedBuildingPulsing").SetEditorDisplayName("Toggle Disconnected Building Pulse").SetEditorIconPath("Assets/Art/UI/SPR_UI_Button_home.png").SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
		{
			BuildingsIndicatorView buildingsIndicatorView = simulation.Scope.Get<BuildingsIndicatorView>();
			if (!buildingsIndicatorView.PulsingEnabled)
			{
				buildingsIndicatorView.StartPulsing();
				_hotkeyDebugView.ShowMessage("Building Pulsing: ON");
			}
			else
			{
				buildingsIndicatorView.StopPulsing();
				_hotkeyDebugView.ShowMessage("Building Pulsing: OFF");
			}
		})
			.ActivateOnEditorButton("Apply")
			.ActivateOnInGameHotkey(KeyCode.Quote);
		CreateDevToolWithName<MotorwaysDevTool>("ToggleVideoCaptureMode").SetEditorDisplayName("Toggle Video Capture Mode").SetEditorIconPath("Assets/Art/UI/Icons/SPR_UI_Camera.png").SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
		{
			bool flag = !VideoCaptureModeOn;
			BuildingsIndicatorView buildingsIndicatorView = simulation.Scope.Get<BuildingsIndicatorView>();
			if (flag)
			{
				buildingsIndicatorView.StopPulsing();
			}
			else
			{
				buildingsIndicatorView.StartPulsing();
			}
			buildingsIndicatorView.AlertsEnabled = !flag;
			command.Scope.Get<UpgradeDatabaseModel>().upgradeSchedulePaused = flag;
			command.SetSpawningMode((!flag) ? CityPlanModel.BuildingSpawningMode.All : CityPlanModel.BuildingSpawningMode.None);
			UnityEngine.Object.FindObjectOfType<GameUIScreen>().DebugToolsHideUI = flag;
			simulation.Scope.Get<NotificationView>().NotificationsEnabled = !flag;
			VideoCaptureModeOn = flag;
		})
			.ActivateOnEditorButton("Toggle Video Capture Mode")
			.ActivateOnInGameHotkey(KeyCode.M);
		CreateDevToolWithName<MotorwaysDevTool>("SpeedUp").SetEditorDisplayName("Debug Increase Speed").SetEditorIconPath("Assets/Art/UI/ChallengeMode/ChallengeIcons/MO_Challenge_Sub_Double_In.png").SetClientCodeToExecute(delegate(MotorwaysDevTool command, ISimulation simulation)
		{
			MotorwaysGame motorwaysGame = simulation.Scope.Get<Game>() as MotorwaysGame;
			if (motorwaysGame.DebugTimescale < 1f)
			{
				motorwaysGame.DebugTimescale = 1f;
			}
			else
			{
				motorwaysGame.DebugTimescale += 1f;
			}
			_hotkeyDebugView.ShowMessage("Increase Timescale: " + motorwaysGame.DebugTimescale);
		})
			.ActivateOnEditorButton("Speed Up")
			.ActivateOnInGameHotkey(KeyCode.Q);
		CreateDevToolWithName<MotorwaysDevTool>("SlowDown").SetEditorDisplayName("Debug Decrease Speed").SetEditorIconPath("Assets/Art/UI/ChallengeMode/ChallengeIcons/MO_Challenge_Sub_Half_In.png").SetClientCodeToExecute(delegate(MotorwaysDevTool command, ISimulation simulation)
		{
			MotorwaysGame motorwaysGame = simulation.Scope.Get<Game>() as MotorwaysGame;
			float num = motorwaysGame.DebugTimescale + -1f;
			if (num < 1f)
			{
				num = motorwaysGame.DebugTimescale * 0.75f;
			}
			motorwaysGame.DebugTimescale = num;
			_hotkeyDebugView.ShowMessage("Decrease Timescale: " + motorwaysGame.DebugTimescale);
		})
			.ActivateOnEditorButton("Slow Down")
			.ActivateOnInGameHotkey(KeyCode.A);
		CreateDevToolWithName<MotorwaysDevTool>("SetBuildingGroupIndex").SetEditorDisplayName("Set Building Group Index").SetEditorIconPath("Assets/Art/UI/ChallengeMode/ChallengeIcons/MO_Challenge_Main_DestinationCircle.png").SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
		{
			if (command.TryGetIntParameter("groupIndex", out var result))
			{
				command.SetGroupIndex(result);
			}
		})
			.ActivateOnDefaultActionInput()
			.WithIntParam(IngameDevToolIntParameter.DefineIntParameter("groupIndex").SetEditorDisplayName("Group Index").SetEditorTooltip("Which group should the destination belong to?")
				.SetMinimumValue(0)
				.SetMaximumValue(5))
			.ActivateOnInGameHotkeyWithIntParameter(KeyCode.Alpha4, "groupIndex", 0)
			.ActivateOnInGameHotkeyWithIntParameter(KeyCode.Alpha5, "groupIndex", 1)
			.ActivateOnInGameHotkeyWithIntParameter(KeyCode.Alpha6, "groupIndex", 2)
			.ActivateOnInGameHotkeyWithIntParameter(KeyCode.Alpha7, "groupIndex", 3)
			.ActivateOnInGameHotkeyWithIntParameter(KeyCode.Alpha8, "groupIndex", 4)
			.ActivateOnInGameHotkeyWithIntParameter(KeyCode.Alpha9, "groupIndex", 5);
		CreateDevToolWithName<MotorwaysDevTool>("ToggleSandboxMode").SetEditorDisplayName("Toggle Sandbox Mode").SetEditorIconPath("Assets/Art/UI/ChallengeMode/ChallengeIcons/MO_Challenge_Sub_Star_In.png").SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
		{
			bool flag = !SandboxModeOn;
			command.Scope.Get<UpgradeDatabaseModel>().upgradeSchedulePaused = flag;
			command.SetSpawningMode((!flag) ? CityPlanModel.BuildingSpawningMode.All : CityPlanModel.BuildingSpawningMode.None);
			simulation.GetModel<GameBehaviourModel>().CanGameOver = !flag;
			SandboxModeOn = flag;
			_hotkeyDebugView.ShowMessage("Sandbox mode: " + (SandboxModeOn ? "ON" : "OFF"));
		})
			.ActivateOnEditorButton("Toggle Sandbox Mode")
			.ActivateOnInGameHotkey(KeyCode.N);
		CreateDevToolWithName<MotorwaysDevTool>("ToggleDebugCameraControls").SetEditorDisplayName("Toggle Debug Camera Controls").SetEditorIconPath("Assets/Art/UI/ChallengeMode/ChallengeIcons/MO_Challenge_Sub_Star_In.png").SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
		{
			CameraView cameraView = command.Scope.Get<CameraView>();
			cameraView.HasControlOverriden = !cameraView.HasControlOverriden;
			_hotkeyDebugView.ShowMessage("Debug Camera: " + (cameraView.HasControlOverriden ? "ON" : "OFF"));
		})
			.ActivateOnEditorButton("Toggle Debug Camera Controls")
			.ActivateOnInGameHotkey(KeyCode.B);
		CreateDevToolWithName<MotorwaysDevTool>("CinematicMode").SetEditorDisplayName("Toggle Cinematic Mode").SetEditorIconPath("Assets/Art/UI/GifMode/SPR_GifUI_Gif.png").SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
		{
			CameraView cameraView = command.Scope.Get<CameraView>();
			if (cameraView.IsInCinematicMode)
			{
				cameraView.ExitCinematicMode();
			}
			else
			{
				cameraView.EnterCinematicMode();
				cameraView.GoToNextAgentInCinematicMode();
			}
		})
			.ActivateOnEditorButton("Toggle Cinematic Mode")
			.ActivateOnInGameHotkey(KeyCode.J);
		CreateDevToolWithName<MotorwaysDevTool>("CinematicModeNextAgent").SetEditorDisplayName("Cinematic Mode Next Agent").SetEditorIconPath("Assets/Art/UI/ChallengeMode/ChallengeIcons/MO_Challenge_Main_FFWD.png").SetCommandToExecute(delegate(MotorwaysDevToolCommand command, ISimulation simulation)
		{
			command.Scope.Get<CameraView>().GoToNextAgentInCinematicMode();
			_hotkeyDebugView.ShowMessage("Cinematic Mode - Next Agent");
		})
			.ActivateOnEditorButton("Next Agent")
			.ActivateOnInGameHotkey(KeyCode.J, KeyCode.LeftShift);
		List<HotkeyDescription> hotkeyDescriptions = new List<HotkeyDescription>();
		foreach (IInGameDevTool allTool in _allTools)
		{
			KeyCode hotKey = allTool.GetHotKey();
			string editorToolDisplayNameWithoutHotkeyCode = allTool.GetEditorToolDisplayNameWithoutHotkeyCode();
			if (hotKey != KeyCode.None && !editorToolDisplayNameWithoutHotkeyCode.Contains("Toggle Sandbox Mode"))
			{
				hotkeyDescriptions.Add(new HotkeyDescription(hotKey, allTool.GetModifierHotKey(), editorToolDisplayNameWithoutHotkeyCode));
			}
		}
		hotkeyDescriptions.Add(new HotkeyDescription(KeyCode.V, "Toggle Hotkey Help"));
		hotkeyDescriptions.Sort((HotkeyDescription descriptionA, HotkeyDescription descriptionB) => string.Compare(descriptionA.description, descriptionB.description, StringComparison.Ordinal));
		CreateDevToolWithName<MotorwaysDevTool>("ToggleHotkeyHelp").SetEditorDisplayName("Toggle Hotkey Help").SetEditorIconPath("Assets/Art/UI/ChallengeMode/ChallengeIcons/MO_Challenge_Sub_Star_In.png").SetCommandToExecute(delegate
		{
			if (_hotkeyDebugView.IsShowingHotkeyDescriptions)
			{
				_hotkeyDebugView.HideHotkeyDescriptions();
			}
			else
			{
				_hotkeyDebugView.ShowHotkeyDescriptions(hotkeyDescriptions);
			}
		})
			.ActivateOnEditorButton("Toggle Hotkey Help")
			.ActivateOnInGameHotkey(KeyCode.V);
		foreach (IInGameDevTool allTool2 in _allTools)
		{
			if (allTool2.GetModifierHotKey() != KeyCode.None)
			{
				_modifierKeys.Add(allTool2.GetModifierHotKey());
			}
		}
	}
}
