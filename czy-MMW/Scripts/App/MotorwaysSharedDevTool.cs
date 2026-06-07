using System.Collections.Generic;
using Factory;
using Motorways;
using Motorways.Commands;
using UnityEngine;

public abstract class MotorwaysSharedDevTool<DevToolType, CommandType> : BaseInGameDevTool<DevToolType, CommandType> where DevToolType : MotorwaysSharedDevTool<DevToolType, CommandType> where CommandType : BaseInGameDevToolCommand<CommandType>
{
	[Dependency]
	protected TileEditor _tileEditor;

	[Dependency]
	protected ClientUpgradeDatabase _clientUpgradeDatabase;

	public void RemoveRoadsAndUpgradesAtTileCoordinate(Vector2Int tileCoordinate)
	{
		List<TileEdit> list = new List<TileEdit>();
		TileEditResult tileEditResult = _tileEditor.ClearTileExplicit(_tilemapView, tileCoordinate, TileEditor.ClearTileOfType.TrafficLight);
		if (tileEditResult.IsSuccessful)
		{
			list.Add(tileEditResult.edit);
		}
		TileEditResult tileEditResult2 = _tileEditor.ClearTileExplicit(_tilemapView, tileCoordinate, TileEditor.ClearTileOfType.UnbuiltMotorway);
		if (tileEditResult2.IsSuccessful)
		{
			list.Add(tileEditResult2.edit);
		}
		TileEditResult tileEditResult3 = _tileEditor.ClearTileExplicit(_tilemapView, tileCoordinate, TileEditor.ClearTileOfType.BuiltMotorways);
		if (tileEditResult3.IsSuccessful)
		{
			list.Add(tileEditResult3.edit);
		}
		TileEditResult tileEditResult4 = _tileEditor.ClearTileExplicit(_tilemapView, tileCoordinate, TileEditor.ClearTileOfType.Roundabout);
		if (tileEditResult4.IsSuccessful)
		{
			list.Add(tileEditResult4.edit);
		}
		TileEditResult tileEditResult5 = _tileEditor.ClearTileExplicit(_tilemapView, tileCoordinate, TileEditor.ClearTileOfType.Passages);
		if (tileEditResult5.IsSuccessful)
		{
			list.Add(tileEditResult5.edit);
		}
		TileEditResult tileEditResult6 = _tileEditor.ClearTileExplicit(_tilemapView, tileCoordinate, TileEditor.ClearTileOfType.Roads);
		if (tileEditResult6.IsSuccessful)
		{
			list.Add(tileEditResult6.edit);
		}
		foreach (TileEdit item in list)
		{
			AddTileEdit(item);
		}
	}

	public void AddTileEdit(TileEdit edit)
	{
		if (edit != null)
		{
			ClientTileEdit clientTileEdit = _tilemapView.GenerateClientTileEditAndAddEditToViews(edit, isDraft: false);
			ScheduleClientTileEdit(clientTileEdit);
			_clientUpgradeDatabase.AddTileEdit(clientTileEdit);
		}
	}

	public void ScheduleClientTileEdit(ClientTileEdit clientTileEdit)
	{
		EditTileCommand command = EditTileCommand.Create(gameScope, clientTileEdit.edit);
		_simulation.ScheduleCommand(command);
		clientTileEdit.isScheduledOnSimulation = true;
	}
}
