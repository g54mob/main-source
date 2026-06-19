using System;
using System.Collections.Generic;
using FullInspector;
using UnityEngine;

namespace TH20
{
	public class CursorEditHospitalItem : CursorMode
	{
		private readonly HUD _hud;

		private readonly Level _level;

		private readonly WorldState _worldState;

		private readonly HighlightManager _highlightManager;

		private bool _ignoreAddRemoveItem;

		private HospitalPlot _hospitalPlot;

		private HospitalPlotLayer _hospitalPlotLayer;

		private bool _dragging;

		private readonly BlueprintFloorPlan _dragFloorPlan;

		private readonly BlueprintFloorPlanVisual _dragFloorPlanVisualisation;

		private GridCoord _dragStartCoord;

		private List<LandscapeRoomItem> _multiSelectItems = new List<LandscapeRoomItem>();

		public CursorEditHospitalItem(CursorManager cursorManager, Level level, HospitalPlot hospitalPlot, HospitalPlotLayer hospitalPlotLayer)
			: base(cursorManager)
		{
			_hospitalPlot = hospitalPlot;
			_hospitalPlotLayer = hospitalPlotLayer;
			_hud = level.HUD;
			_level = level;
			_worldState = level.WorldState;
			_highlightManager = level.HighlightManager;
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnRoomItemPlaced = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents2.OnRoomItemPlaced, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents3 = _level.BuildEvents;
			buildEvents3.OnBeginItemEdit = (Action<RoomItem, Room>)Delegate.Combine(buildEvents3.OnBeginItemEdit, new Action<RoomItem, Room>(OnBeginItemEdit));
			BuildEvents buildEvents4 = _level.BuildEvents;
			buildEvents4.OnRoomItemDestroyed = (Action<RoomItem>)Delegate.Combine(buildEvents4.OnRoomItemDestroyed, new Action<RoomItem>(OnRoomItemDestroyed));
			BuildEvents buildEvents5 = _level.BuildEvents;
			buildEvents5.OnMoveRoomEnd = (Action<bool, Vector3>)Delegate.Combine(buildEvents5.OnMoveRoomEnd, new Action<bool, Vector3>(OnMoveRoomEnd));
			HospitalEditEvents hospitalEditEvents = _level.HospitalEditEvents;
			hospitalEditEvents.OnSelectHospitalPlot = (Action<HospitalPlot>)Delegate.Combine(hospitalEditEvents.OnSelectHospitalPlot, new Action<HospitalPlot>(OnSelectHospitalPlot));
			HospitalEditEvents hospitalEditEvents2 = _level.HospitalEditEvents;
			hospitalEditEvents2.OnSelectHospitalPlotLayer = (Action<HospitalPlotLayer>)Delegate.Combine(hospitalEditEvents2.OnSelectHospitalPlotLayer, new Action<HospitalPlotLayer>(OnSelectHospitalPlotLayer));
			HospitalEditEvents hospitalEditEvents3 = _level.HospitalEditEvents;
			hospitalEditEvents3.OnHospitalPlotStateChanging = (Action<HospitalPlot, bool>)Delegate.Combine(hospitalEditEvents3.OnHospitalPlotStateChanging, new Action<HospitalPlot, bool>(OnHospitalPlotStateChanging));
			if (_hospitalPlot.HospitalMap != null)
			{
				_hud.CreateMenu<LandscapeObjectsMenu>(recycle: true).Setup(_hospitalPlot.HospitalMap.FloorPlan, _worldState, level.BuildEvents);
			}
			BuildingLogic.Config configuration = _level.BuildingLogic.Configuration;
			_dragFloorPlan = new BlueprintFloorPlan(hospitalPlot.GetRoomDefinition(), level, null);
			_dragFloorPlanVisualisation = new BlueprintFloorPlanVisual(level.WorldState, level.VisualManager, level.DataViewManager, configuration.RoomItemEditConfig, level.BuildEvents, "Blueprint", configuration.BlueprintFloorTilePrefab, _level.Config.GetCursorRoomBuildConfig().DragAddWallDefinition.Instance, configuration.BlueprintFloorMaterialInvalidSize, configuration.BlueprintFloorMaterialInvalidSize, configuration.BlueprintFloorMaterialInvalidSize);
		}

		public override void Destroy()
		{
			_hud.DestroyMenu<LandscapeObjectsMenu>();
			_dragFloorPlan.Destroy();
			_dragFloorPlanVisualisation.Destroy();
			_cursorManager.PopMode<CursorRoomItem>();
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnRoomItemPlaced = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents2.OnRoomItemPlaced, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents3 = _level.BuildEvents;
			buildEvents3.OnBeginItemEdit = (Action<RoomItem, Room>)Delegate.Remove(buildEvents3.OnBeginItemEdit, new Action<RoomItem, Room>(OnBeginItemEdit));
			BuildEvents buildEvents4 = _level.BuildEvents;
			buildEvents4.OnRoomItemDestroyed = (Action<RoomItem>)Delegate.Remove(buildEvents4.OnRoomItemDestroyed, new Action<RoomItem>(OnRoomItemDestroyed));
			BuildEvents buildEvents5 = _level.BuildEvents;
			buildEvents5.OnMoveRoomEnd = (Action<bool, Vector3>)Delegate.Remove(buildEvents5.OnMoveRoomEnd, new Action<bool, Vector3>(OnMoveRoomEnd));
			HospitalEditEvents hospitalEditEvents = _level.HospitalEditEvents;
			hospitalEditEvents.OnSelectHospitalPlot = (Action<HospitalPlot>)Delegate.Remove(hospitalEditEvents.OnSelectHospitalPlot, new Action<HospitalPlot>(OnSelectHospitalPlot));
			HospitalEditEvents hospitalEditEvents2 = _level.HospitalEditEvents;
			hospitalEditEvents2.OnSelectHospitalPlotLayer = (Action<HospitalPlotLayer>)Delegate.Remove(hospitalEditEvents2.OnSelectHospitalPlotLayer, new Action<HospitalPlotLayer>(OnSelectHospitalPlotLayer));
			HospitalEditEvents hospitalEditEvents3 = _level.HospitalEditEvents;
			hospitalEditEvents3.OnHospitalPlotStateChanging = (Action<HospitalPlot, bool>)Delegate.Remove(hospitalEditEvents3.OnHospitalPlotStateChanging, new Action<HospitalPlot, bool>(OnHospitalPlotStateChanging));
			base.Destroy();
		}

		public override void CursorUpdate(InputManager inputManager)
		{
			if (_cursorManager.IsModeActive<CursorRoomItem>())
			{
				return;
			}
			bool key = inputManager.GetKey(KeyCode.LeftControl);
			if (key || _dragging)
			{
				UpdateMultiSelect(inputManager);
			}
			else
			{
				_dragging = false;
				_dragFloorPlanVisualisation.SetVisible(visible: false);
				RoomItem selectedItem = GetSelectedItem(inputManager);
				if (selectedItem != null)
				{
					_highlightManager.HighlightObject(selectedItem);
					if (inputManager.GetMouseDownOnScene(MouseButton.Left))
					{
						_level.BuildEvents.StartItemEdit(selectedItem, selectedItem.OwningRoom);
					}
					else if (inputManager.GetButtonDown(52))
					{
						_level.BuildEvents.OnRoomItemDestroy.InvokeSafe(selectedItem);
					}
				}
			}
			if (key && !_dragging)
			{
				_cursorManager.SetCursorVisible(visible: true);
				_cursorManager.SetCursorIconVisible(visible: false);
				_cursorManager.SetCursorIcon(CursorIcon.Default);
				_cursorManager.SetCursorModel(CursorModel.RoomBuild);
			}
			else
			{
				_cursorManager.SetCursorVisible(visible: false);
				_cursorManager.SetCursorIconVisible(visible: true);
				_cursorManager.SetCursorIcon(CursorIcon.Default);
				_cursorManager.SetCursorModel(CursorModel.Default);
			}
		}

		private void UpdateMultiSelect(InputManager inputManager)
		{
			if (!_dragging)
			{
				_dragFloorPlanVisualisation.SetVisible(visible: false);
				if (inputManager.GetMouseDownOnScene(MouseButton.Left))
				{
					_dragging = true;
					_dragStartCoord = _cursorManager.GridPosition;
				}
				return;
			}
			GridCoord gridPosition = _cursorManager.GridPosition;
			_dragFloorPlan.Anchor = new GridCoord(Mathf.Min(_dragStartCoord.X, gridPosition.X), Mathf.Min(_dragStartCoord.Y, gridPosition.Y));
			_dragFloorPlan.Tiles = new bool[Mathf.Abs(gridPosition.X - _dragStartCoord.X) + 1, Mathf.Abs(gridPosition.Y - _dragStartCoord.Y) + 1];
			ArrayUtils.Populate(_dragFloorPlan.Tiles, value: true);
			_dragFloorPlan.RecalculateWalls();
			_dragFloorPlan.ValidRoomSize = false;
			_dragFloorPlanVisualisation.CompletelyInvalid = true;
			_dragFloorPlanVisualisation.UpdateFromRoom(_dragFloorPlan);
			_dragFloorPlanVisualisation.SetVisible(visible: true);
			_dragFloorPlanVisualisation.SetWallsFloorVisible(visible: true);
			if (inputManager.GetMouseUpOnScene(MouseButton.Left))
			{
				_dragging = false;
				StartMultiSelectEdit();
			}
		}

		private void StartMultiSelectEdit()
		{
			if (_hospitalPlot.HospitalMap == null)
			{
				return;
			}
			FloorPlan floorPlan = _hospitalPlot.HospitalMap.FloorPlan;
			RoomFloorPlanVisual roomVisual = _hospitalPlot.HospitalMap.RoomVisual;
			_multiSelectItems.Clear();
			foreach (LandscapeRoomItem landscapeItem in floorPlan.LandscapeItems)
			{
				if (RoomAlgorithms.RoomContainsWorldCoord(_dragFloorPlan, landscapeItem.WorldPosition.ToGridCoord()))
				{
					_multiSelectItems.Add(landscapeItem);
				}
			}
			if (_multiSelectItems.Count == 0)
			{
				return;
			}
			foreach (LandscapeRoomItem multiSelectItem in _multiSelectItems)
			{
				OnRoomItemDestroyed(multiSelectItem);
				RoomAlgorithms.MoveItemToFloorPlan(multiSelectItem, _dragFloorPlan);
			}
			roomVisual.UpdateFromRoom(floorPlan);
			_dragFloorPlanVisualisation.UpdateFromRoom(_dragFloorPlan);
			_dragFloorPlanVisualisation.SetWallsFloorVisible(visible: false);
			_cursorManager.PushMode(new CursorRoomMove(_cursorManager, _level, _worldState, _level.BuildEvents, _dragFloorPlan, _dragFloorPlanVisualisation, landscapeEdit: true));
		}

		private void OnMoveRoomEnd(bool deleted, Vector3 cellOffset)
		{
			if (_multiSelectItems.Count == 0 || _hospitalPlot.HospitalMap == null)
			{
				return;
			}
			FloorPlan floorPlan = _hospitalPlot.HospitalMap.FloorPlan;
			RoomFloorPlanVisual roomVisual = _hospitalPlot.HospitalMap.RoomVisual;
			if (deleted)
			{
				foreach (LandscapeRoomItem multiSelectItem in _multiSelectItems)
				{
					_level.BuildEvents.OnRoomItemDestroy.InvokeSafe(multiSelectItem);
				}
				_multiSelectItems.Clear();
				return;
			}
			bool key = _level.InputManager.GetKey(KeyCode.LeftControl);
			cellOffset.y = 0f;
			if (key)
			{
				foreach (LandscapeRoomItem multiSelectItem2 in _multiSelectItems)
				{
					if (!_hospitalPlot.Definition.Contains(multiSelectItem2, floorPlan, _hospitalPlotLayer, cellOffset))
					{
						LandscapeRoomItem landscapeRoomItem = new LandscapeRoomItem(multiSelectItem2, _dragFloorPlan, _hospitalPlotLayer);
						landscapeRoomItem.WorldPosition += cellOffset;
						_dragFloorPlan.AddItem(landscapeRoomItem);
						RoomAlgorithms.MoveItemToFloorPlan(landscapeRoomItem, floorPlan);
						OnRoomItemAdded(landscapeRoomItem, floorPlan);
					}
				}
				roomVisual.UpdateFromRoom(floorPlan);
				_cursorManager.PushMode(new CursorRoomMove(_cursorManager, _level, _worldState, _level.BuildEvents, _dragFloorPlan, _dragFloorPlanVisualisation, landscapeEdit: true));
				return;
			}
			foreach (LandscapeRoomItem multiSelectItem3 in _multiSelectItems)
			{
				if (!_hospitalPlot.Definition.Contains(multiSelectItem3, floorPlan, _hospitalPlotLayer, cellOffset))
				{
					multiSelectItem3.WorldPosition += cellOffset;
					RoomAlgorithms.MoveItemToFloorPlan(multiSelectItem3, floorPlan);
					OnRoomItemAdded(multiSelectItem3, floorPlan);
				}
			}
			_multiSelectItems.Clear();
			roomVisual.UpdateFromRoom(floorPlan);
			_dragFloorPlanVisualisation.UpdateFromRoom(_dragFloorPlan);
		}

		private void OnSelectHospitalPlot(HospitalPlot hospitalPlot)
		{
			_hospitalPlot = hospitalPlot;
			if (_hospitalPlot.HospitalMap != null)
			{
				_hud.CreateMenu<LandscapeObjectsMenu>(recycle: true).Setup(_hospitalPlot.HospitalMap.FloorPlan, _worldState, _level.BuildEvents);
			}
		}

		private void OnSelectHospitalPlotLayer(HospitalPlotLayer layer)
		{
			_hospitalPlotLayer = layer;
		}

		private void OnHospitalPlotStateChanging(HospitalPlot hospitalPlot, bool changing)
		{
			_ignoreAddRemoveItem = changing;
			_cursorManager.PopMode<CursorRoomItem>();
		}

		private void OnRoomItemAdded(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (!_ignoreAddRemoveItem && _hospitalPlot.HospitalMap != null && !_hospitalPlot.Definition.Contains(roomItem, _hospitalPlot.HospitalMap.FloorPlan, _hospitalPlotLayer))
			{
				SharedInstance<RoomItemDefinition> sharedInstance = SharedInstanceUtils.GetSharedInstance(roomItem.Definition as RoomItemDefinition);
				HospitalPlotItem hospitalPlotItem = new HospitalPlotItem
				{
					Definition = sharedInstance,
					Position = roomItem.LocalPosition,
					Rotation = roomItem.Rotation
				};
				_hospitalPlot.Definition.AddItem(hospitalPlotItem, _hospitalPlotLayer);
				SharedInstanceUtils.MarkAsDirty(_hospitalPlot.Definition);
			}
		}

		private void OnBeginItemEdit(RoomItem roomItem, Room room)
		{
			OnRoomItemDestroyed(roomItem);
		}

		private void OnRoomItemDestroyed(RoomItem roomItem)
		{
			if (!_ignoreAddRemoveItem && _hospitalPlot.Definition.RemoveItem(roomItem))
			{
				SharedInstanceUtils.MarkAsDirty(_hospitalPlot.Definition);
			}
		}

		private RoomItem GetSelectedItem(InputManager inputManager)
		{
			float num = float.MaxValue;
			RoomItem result = null;
			Ray ray = Camera.main.ScreenPointToRay(inputManager.GetMousePos());
			if (_hospitalPlot.HospitalMap != null)
			{
				FloorPlan floorPlan = _hospitalPlot.HospitalMap.FloorPlan;
				float distance;
				foreach (LandscapeRoomItem landscapeItem in floorPlan.LandscapeItems)
				{
					if (landscapeItem.Visual != null && landscapeItem.Visual.RayCast(ray, out distance) && distance < num)
					{
						num = distance;
						result = landscapeItem;
					}
				}
				foreach (RoomItem item in floorPlan.Items)
				{
					if (item.Visual != null && item.Visual.RayCast(ray, out distance) && distance < num)
					{
						num = distance;
						result = item;
					}
				}
			}
			return result;
		}
	}
}
