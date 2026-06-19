using System;
using UnityEngine;

namespace TH20
{
	public class CursorEditHospitalBuild : CursorMode
	{
		private enum RoomAreaDragOperation
		{
			Add = 0,
			Subtract = 1
		}

		private readonly Level _level;

		private readonly WorldState _worldState;

		private readonly BlueprintFloorPlan _dragFloorPlan;

		private readonly BlueprintFloorPlanVisual _dragFloorPlanVisualisation;

		private bool _dragging;

		private RoomAreaDragOperation _dragOperation;

		private GridCoord _dragStartCoord;

		private GridCoord _currentDragEndPoint;

		private HospitalMapTile.Type _tileType;

		private HospitalPlot _hospitalPlot;

		public CursorEditHospitalBuild(CursorManager cursorManager, Level level, HospitalPlot hospitalPlot, CursorEditHospital.Config config)
			: base(cursorManager)
		{
			_level = level;
			_worldState = _level.WorldState;
			_hospitalPlot = hospitalPlot;
			HospitalEditEvents hospitalEditEvents = _level.HospitalEditEvents;
			hospitalEditEvents.OnTileTypeSelected = (Action<HospitalMapTile.Type>)Delegate.Combine(hospitalEditEvents.OnTileTypeSelected, new Action<HospitalMapTile.Type>(OnTileTypeSelected));
			HospitalEditEvents hospitalEditEvents2 = _level.HospitalEditEvents;
			hospitalEditEvents2.OnSelectHospitalPlot = (Action<HospitalPlot>)Delegate.Combine(hospitalEditEvents2.OnSelectHospitalPlot, new Action<HospitalPlot>(OnSelectHospitalPlot));
			_dragFloorPlan = new BlueprintFloorPlan(config.DragRoomDefinition.Instance, _level, null);
			_dragFloorPlanVisualisation = new BlueprintFloorPlanVisual(_level.WorldState, _level.VisualManager, _level.DataViewManager, _level.BuildingLogic.Configuration.RoomItemEditConfig, _level.BuildEvents, "Blueprint", config.DragFloorTilePrefab, config.DragAddWallDefinition.Instance, config.DragAddMaterialValid, config.DragAddMaterialInvalid, config.DragAddMaterialInvalid);
		}

		public override void Destroy()
		{
			_dragFloorPlan.Destroy();
			_dragFloorPlanVisualisation.Destroy();
			HospitalEditEvents hospitalEditEvents = _level.HospitalEditEvents;
			hospitalEditEvents.OnTileTypeSelected = (Action<HospitalMapTile.Type>)Delegate.Remove(hospitalEditEvents.OnTileTypeSelected, new Action<HospitalMapTile.Type>(OnTileTypeSelected));
			HospitalEditEvents hospitalEditEvents2 = _level.HospitalEditEvents;
			hospitalEditEvents2.OnSelectHospitalPlot = (Action<HospitalPlot>)Delegate.Remove(hospitalEditEvents2.OnSelectHospitalPlot, new Action<HospitalPlot>(OnSelectHospitalPlot));
			_level.HospitalEditEvents.OnEndBuilding.InvokeSafe();
			base.Destroy();
		}

		public override void OnBecomeActive()
		{
			_cursorManager.SetCursorVisible(visible: false);
			_cursorManager.SetCursorModel(CursorModel.RoomBuild);
		}

		private void OnTileTypeSelected(HospitalMapTile.Type type)
		{
			_tileType = type;
		}

		private void OnSelectHospitalPlot(HospitalPlot hospitalPlot)
		{
			_hospitalPlot = hospitalPlot;
		}

		public override void CursorUpdate(InputManager inputManager)
		{
			if (!_dragging && (inputManager.GetButtonDown(10) || inputManager.GetMouseDownOnScene(MouseButton.Left)))
			{
				GridCoord gridPosition = _cursorManager.GridPosition;
				if (GridBounds.IsInBounds(gridPosition, _worldState.Bounds))
				{
					_dragging = true;
					_dragStartCoord = gridPosition;
				}
			}
			bool subtracting = (_dragOperation == RoomAreaDragOperation.Subtract) ^ Input.GetKey(KeyCode.LeftControl);
			_cursorManager.SetCursorModel(CursorModel.RoomBuild);
			_cursorManager.SetCursorIcon((!subtracting) ? CursorIcon.AddRoom : CursorIcon.SubRoom);
			if (_dragging)
			{
				_currentDragEndPoint = GridBounds.ClampToBounds(_cursorManager.GridPosition, _worldState.Bounds);
				int x = Mathf.Min(_dragStartCoord.X, _currentDragEndPoint.X);
				int y = Mathf.Min(_dragStartCoord.Y, _currentDragEndPoint.Y);
				int num = Mathf.Abs(_currentDragEndPoint.X - _dragStartCoord.X) + 1;
				int num2 = Mathf.Abs(_currentDragEndPoint.Y - _dragStartCoord.Y) + 1;
				_dragFloorPlan.Anchor = new GridCoord(x, y);
				_dragFloorPlan.Tiles = new bool[num, num2];
				ArrayUtils.Populate(_dragFloorPlan.Tiles, value: true);
				_dragFloorPlan.RecalculateWalls();
				_dragFloorPlan.ValidateTiles();
				_dragFloorPlanVisualisation.SetVisible(visible: true);
				_dragFloorPlanVisualisation.UpdateFromRoom(_dragFloorPlan);
				_cursorManager.SetCursorVisible(visible: false);
			}
			else
			{
				_cursorManager.SetCursorVisible(visible: true);
			}
			bool floorImageDirty = false;
			Texture2D floorImage = _hospitalPlot.Definition.FloorImage;
			if (_dragging && (inputManager.GetButtonUp(10) || inputManager.GetMouseUp(MouseButton.Left)) && _hospitalPlot.HospitalMap != null)
			{
				FloorPlan floorPlan = _hospitalPlot.HospitalMap.FloorPlan;
				RoomAlgorithms.IterateFreeRoomTiles(_dragFloorPlan, delegate(int num4, int num6, bool free)
				{
					int num3 = num4 + _dragFloorPlan.Anchor.X - floorPlan.Anchor.X;
					int num5 = num6 + _dragFloorPlan.Anchor.Y - floorPlan.Anchor.Y;
					if (num5 > 0 && num5 < floorImage.height - 1 && num3 > 0 && num3 < floorImage.width - 1)
					{
						floorImageDirty = true;
						floorImage.SetPixel(num3, num5, subtracting ? Color.clear : HospitalMapTile.GetColor(_tileType));
					}
				});
			}
			if (floorImageDirty)
			{
				floorImage.Apply();
				if (_hospitalPlot.HospitalMap != null)
				{
					_hospitalPlot.HospitalMap.Build(animateWalls: false);
				}
				_level.WorldState.CalculateLighting();
				_dragging = false;
				_cursorManager.SetCursorVisible(visible: true);
				_dragFloorPlanVisualisation.SetVisible(visible: false);
				_level.HospitalEditEvents.OnHospitalPlotUpdated.InvokeSafe(_hospitalPlot);
			}
		}
	}
}
