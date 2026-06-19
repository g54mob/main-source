using System;
using System.Collections.Generic;
using System.Linq;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public class CursorSelect : CursorMode
	{
		private readonly Level _level;

		private readonly WorldState _worldState;

		private readonly BuildEvents _buildEvents;

		private readonly CharacterManager _characterManager;

		private readonly HighlightManager _highlightManager;

		private readonly MonoBeastManager _monoBeastManager;

		private readonly Dictionary<ICursorSelectable, float> _hoverTimes = new Dictionary<ICursorSelectable, float>();

		private float _mouseHeldStartTime;

		private Vector2 _mouseHeldStartPosition;

		private ICursorSelectable _mouseHeldObject;

		private ICursorSelectable _debugForceSelectedObject;

		public CursorSelect(CursorManager cursorManager, Level level, WorldState worldState, BuildEvents buildEvents, CharacterManager characterManager, HighlightManager highlightManager, MonoBeastManager monoBeastManager)
			: base(cursorManager)
		{
			_level = level;
			_worldState = worldState;
			_buildEvents = buildEvents;
			_characterManager = characterManager;
			_highlightManager = highlightManager;
			_monoBeastManager = monoBeastManager;
			BuildEvents buildEvents2 = _buildEvents;
			buildEvents2.OnCursorHoverStart = (Action<ICursorSelectable>)Delegate.Combine(buildEvents2.OnCursorHoverStart, new Action<ICursorSelectable>(OnCursorHoverStart));
			RegisterConsoleCommands();
		}

		public override void OnBecomeActive()
		{
			_cursorManager.SetCursorVisible(visible: true);
			_cursorManager.SetCursorIcon(CursorIcon.Default);
		}

		public override void OnBecomeInactive()
		{
			base.OnBecomeInactive();
			foreach (KeyValuePair<ICursorSelectable, float> hoverTime in _hoverTimes)
			{
				_buildEvents.OnCursorHoverStop.InvokeSafe(hoverTime.Key);
			}
			_hoverTimes.Clear();
			_mouseHeldObject = null;
		}

		public override void Destroy()
		{
			ClearDebugForceSelectedObject();
			UnRegisterConsoleCommands();
			BuildEvents buildEvents = _buildEvents;
			buildEvents.OnCursorHoverStart = (Action<ICursorSelectable>)Delegate.Remove(buildEvents.OnCursorHoverStart, new Action<ICursorSelectable>(OnCursorHoverStart));
			base.Destroy();
		}

		private void RegisterConsoleCommands()
		{
			ConsoleCommandsDatabase.RegisterCommand("SelectFirstRoomItemOfType", "Selects the first room item found with the given debug tag", "SelectFirstRoomItemOfType Drug dispenser", DebugSelectFirstRoomItemOfType);
			ConsoleCommandsDatabase.RegisterSimpleCommand("ClearDebugSelectedObject", "Clears any debug force-selected object", ClearDebugForceSelectedObject);
			ConsoleCommandsDatabase.RegisterCommand("SetSelectedObject", "Sets the cursors selected object using ID", "SetSelectedObject ObjectID", DebugSelectObject);
		}

		private void UnRegisterConsoleCommands()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("SelectFirstRoomItemOfType");
			ConsoleCommandsDatabase.UnRegisterCommand("SetSelectedObject");
		}

		public override void CursorUpdate(InputManager inputManager)
		{
			if (_level.HUD.IsFullscreenMenuOpen() || !_cursorManager.IsCursorIconVisible() || !inputManager.IsMouseInsideWindow())
			{
				return;
			}
			ICursorSelectable cursorSelectable = ((_debugForceSelectedObject != null) ? _debugForceSelectedObject : (inputManager.IsMouseOverGui ? null : GetSelection(_cursorManager.WorldPosition.ToGridCoord())));
			bool flag = inputManager.GetMouseQuickOnScene(MouseButton.Left) || inputManager.GetButtonDown(10);
			bool flag2 = !inputManager.IsMouseOverGui && inputManager.GetButtonDown(52);
			if (inputManager.GetMouseDownOnScene(MouseButton.Left) && cursorSelectable != null && cursorSelectable.CanDragHoldSelect())
			{
				_mouseHeldObject = cursorSelectable;
				_mouseHeldStartTime = Time.unscaledTime;
				_mouseHeldStartPosition = inputManager.GetMousePosNormalised();
			}
			if (inputManager.GetMouseUp(MouseButton.Left))
			{
				_buildEvents.OnCursorHoldCancel.InvokeSafe(_mouseHeldObject);
				_mouseHeldObject = null;
			}
			if (_mouseHeldObject != null)
			{
				cursorSelectable = _mouseHeldObject;
			}
			if (_mouseHeldObject != null && _mouseHeldObject.CanDragHoldSelect())
			{
				float minHoldSelectTime = GameAlgorithms.Config.MinHoldSelectTime;
				float maxHoldSelectTime = GameAlgorithms.Config.MaxHoldSelectTime;
				float dragSelectDistance = GameAlgorithms.Config.DragSelectDistance;
				float num = Time.unscaledTime - _mouseHeldStartTime - minHoldSelectTime;
				bool flag3 = num >= maxHoldSelectTime;
				bool num2 = Vector2.Distance(_mouseHeldStartPosition, inputManager.GetMousePosNormalised()) >= dragSelectDistance;
				if (num >= 0f)
				{
					_buildEvents.OnCursorHoldUpdated.InvokeSafe(cursorSelectable, num / maxHoldSelectTime);
				}
				if (num2 || flag3)
				{
					_buildEvents.OnCursorHoverStop.InvokeSafe(cursorSelectable);
					_buildEvents.OnCursorHoldCancel.InvokeSafe(cursorSelectable);
					_buildEvents.OnCursorDragSelect.InvokeSafe(cursorSelectable);
					return;
				}
			}
			if (cursorSelectable == null)
			{
				if (flag)
				{
					_buildEvents.OnCursorSelectObject.InvokeSafe(null);
				}
				if (!inputManager.IsMouseOverGui)
				{
					_buildEvents.OnCursorHighlight.InvokeSafe(null);
				}
			}
			else
			{
				if (cursorSelectable.CanHighlight())
				{
					_highlightManager.HighlightObject(cursorSelectable);
					_buildEvents.OnCursorHighlight.InvokeSafe(cursorSelectable);
				}
				if (flag)
				{
					_mouseHeldObject = null;
					_buildEvents.OnCursorSelectObject.InvokeSafe(cursorSelectable);
					inputManager.Flush();
				}
				if (flag2)
				{
					_mouseHeldObject = null;
					_buildEvents.OnCursorDeleteObject.InvokeSafe(cursorSelectable);
					cursorSelectable = null;
				}
			}
			if (cursorSelectable != null)
			{
				bool flag4 = cursorSelectable is RoomItem roomItem && !roomItem.Definition.ShowQueuePositions;
				if (cursorSelectable.HasTooltip() || flag4)
				{
					if (!_hoverTimes.ContainsKey(cursorSelectable))
					{
						_hoverTimes.Add(cursorSelectable, 0f);
					}
					float num3 = _hoverTimes[cursorSelectable];
					_hoverTimes[cursorSelectable] += Time.unscaledDeltaTime;
					if (_hoverTimes[cursorSelectable] >= GameAlgorithms.Config.CursorHoverStartTime)
					{
						_hoverTimes[cursorSelectable] = GameAlgorithms.Config.CursorHoverStartTime;
						if (num3 < GameAlgorithms.Config.CursorHoverStartTime)
						{
							_buildEvents.OnCursorHoverStart.InvokeSafe(cursorSelectable);
							foreach (ICursorSelectable item in _hoverTimes.Keys.ToList())
							{
								if (item != cursorSelectable)
								{
									_hoverTimes[item] = 0f;
								}
							}
						}
					}
				}
			}
			foreach (ICursorSelectable item2 in _hoverTimes.Keys.ToList())
			{
				if (item2 == cursorSelectable)
				{
					continue;
				}
				if (item2 is MustCallDestroy mustCallDestroy && mustCallDestroy.HasBeenDestroyed())
				{
					_hoverTimes.Remove(item2);
					continue;
				}
				_buildEvents.OnCursorHoverOut.InvokeSafe(item2);
				_hoverTimes[item2] -= Time.unscaledDeltaTime * (GameAlgorithms.Config.CursorHoverStartTime / GameAlgorithms.Config.CursorHoverStopTime);
				if (_hoverTimes[item2] <= 0f)
				{
					_hoverTimes.Remove(item2);
					_buildEvents.OnCursorHoverStop.InvokeSafe(item2);
				}
			}
		}

		private void OnCursorHoverStart(ICursorSelectable selected)
		{
			if (selected != null && !_hoverTimes.ContainsKey(selected))
			{
				_hoverTimes.Add(selected, GameAlgorithms.Config.CursorHoverStartTime);
			}
		}

		private ConsoleCommandResult DebugSelectFirstRoomItemOfType(params string[] args)
		{
			string type = string.Join(" ", args);
			if (DebugSelectFirstRoomItemOfType(type))
			{
				return ConsoleCommandResult.Succeeded();
			}
			return ConsoleCommandResult.Failed("Couldn't find item of that type");
		}

		private bool DebugSelectFirstRoomItemOfType(string type)
		{
			foreach (Room allRoom in _worldState.AllRooms)
			{
				foreach (RoomItem item in allRoom.FloorPlan.Items)
				{
					if (item.Definition.DebugTag == type)
					{
						_debugForceSelectedObject = item;
						BuildEvents buildEvents = _buildEvents;
						buildEvents.OnRoomItemDestroyed = (Action<RoomItem>)Delegate.Combine(buildEvents.OnRoomItemDestroyed, new Action<RoomItem>(ClearDebugForceSelectedRoomItem));
						_buildEvents.OnCursorSelectObject.InvokeSafe(item);
						return true;
					}
				}
			}
			return false;
		}

		private void ClearDebugForceSelectedRoomItem(RoomItem item)
		{
			if (item == _debugForceSelectedObject)
			{
				ClearDebugForceSelectedObject();
			}
		}

		private void ClearDebugForceSelectedObject()
		{
			BuildEvents buildEvents = _buildEvents;
			buildEvents.OnRoomItemDestroyed = (Action<RoomItem>)Delegate.Remove(buildEvents.OnRoomItemDestroyed, new Action<RoomItem>(ClearDebugForceSelectedRoomItem));
			_debugForceSelectedObject = null;
		}

		private ConsoleCommandResult DebugSelectObject(params string[] args)
		{
			ClearDebugForceSelectedObject();
			if (int.TryParse(args[0], out var result))
			{
				foreach (Character allCharacter in _characterManager.AllCharacters)
				{
					if (result == allCharacter.ID)
					{
						_buildEvents.OnCursorSelectObject.InvokeSafe(allCharacter);
						return ConsoleCommandResult.Succeeded();
					}
				}
				foreach (Room allRoom in _worldState.AllRooms)
				{
					if (result == allRoom.ID)
					{
						_buildEvents.OnCursorSelectObject.InvokeSafe(allRoom);
						return ConsoleCommandResult.Succeeded();
					}
					foreach (RoomItem item in allRoom.FloorPlan.Items)
					{
						if (result == item.ID && item.IsSelectable())
						{
							_buildEvents.OnCursorSelectObject.InvokeSafe(item);
							return ConsoleCommandResult.Succeeded();
						}
					}
				}
				return ConsoleCommandResult.Failed("Couldn't find item");
			}
			return ConsoleCommandResult.Failed("Invalid ID. Must be an integer");
		}

		private ICursorSelectable GetSelection(GridCoord worldPos)
		{
			Character characterAtCursor = CursorSelectionHelpers.GetCharacterAtCursor(_characterManager);
			if (characterAtCursor != null)
			{
				return characterAtCursor;
			}
			RoomItem item = CursorSelectionHelpers.GetItem(_worldState.AllRooms);
			if (item != null)
			{
				return item;
			}
			Room room = CursorSelectionHelpers.GetRoom(worldPos, _worldState);
			if (room != null)
			{
				return room;
			}
			Room plot = CursorSelectionHelpers.GetPlot(_worldState, _level.InputManager);
			if (plot != null)
			{
				return plot;
			}
			MonoBeast monoBeast = CursorSelectionHelpers.GetMonoBeast(_monoBeastManager);
			if (monoBeast != null)
			{
				return monoBeast;
			}
			return null;
		}
	}
}
