using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class CursorRoomMove : CursorMode
	{
		private readonly Level _level;

		private readonly BlueprintFloorPlan _blueprintFloorPlan;

		private readonly RoomFloorPlanVisual _floorPlanVisual;

		private GridCoord _originalAnchor;

		private GridCoord _cursorStart;

		private readonly BuildEvents _buildEvents;

		private GridCoord _deltaLastUpdate;

		private readonly WorldState _worldState;

		private readonly List<RoomItem> _sellItems = new List<RoomItem>();

		private readonly List<RoomItem> _invalidItems = new List<RoomItem>();

		private float _rotationOffset;

		private float _rotationDampVelocity;

		private float _positionOffset;

		private int _numberOfRotations;

		private bool _landscapeEdit;

		private bool _roomCopyMode;

		private float _lastRotation;

		private CursorControlRotatePlace _rotateControl;

		private const string BlueprintMovingEvent = "BlueprintMoving";

		public CursorRoomMove(CursorManager cursorManager, Level level, WorldState worldState, BuildEvents buildEvents, BlueprintFloorPlan blueprintFloorPlan, RoomFloorPlanVisual floorPlanVisual, bool landscapeEdit)
			: base(cursorManager)
		{
			_level = level;
			_worldState = worldState;
			_buildEvents = buildEvents;
			_blueprintFloorPlan = blueprintFloorPlan;
			_floorPlanVisual = floorPlanVisual;
			_originalAnchor = _blueprintFloorPlan.Anchor;
			_cursorStart = cursorManager.WorldPositionSmoothed.ToGridCoord();
			_deltaLastUpdate = default(GridCoord);
			_rotateControl = new CursorControlRotatePlace(0f, cursorManager);
			_landscapeEdit = landscapeEdit;
		}

		public override void OnBecomeActive()
		{
			HideInvalidItemBounds();
			_cursorManager.SetCursorIcon(CursorIcon.MovingRoom);
			_buildEvents.OnMoveRoomStart.InvokeSafe();
		}

		public override void Destroy()
		{
			HideInvalidItemBounds();
			_rotateControl.Destroy();
			base.Destroy();
		}

		public override void CursorUpdate(InputManager inputManager)
		{
			Vector3 vector = Vector3.zero;
			GridCoord anchor = _blueprintFloorPlan.Anchor;
			GridCoord center = _blueprintFloorPlan.WorldBounds.Center;
			bool flag = false;
			_positionOffset = MathUtils.InterpolateTo(_positionOffset, 0.25f, 8f, Time.unscaledDeltaTime);
			for (_rotationOffset = Mathf.SmoothDampAngle(_rotationOffset, 0f, ref _rotationDampVelocity, GameAlgorithms.Config.CursorRoomRotationDampTime, float.PositiveInfinity, Time.unscaledDeltaTime); _rotationOffset <= -360f; _rotationOffset += 360f)
			{
			}
			while (_rotationOffset >= 360f)
			{
				_rotationOffset -= 360f;
			}
			_rotateControl.Update(inputManager, _level, 90f, RoomItemDefinition.Size.Large);
			List<RoomItem> previousSellItems = new List<RoomItem>(_sellItems);
			List<RoomItem> previousItems = new List<RoomItem>(_invalidItems);
			_sellItems.Clear();
			_invalidItems.Clear();
			if (_rotateControl.Rotating)
			{
				int num = (int)(_rotateControl.Rotation / 90f);
				int num2 = (int)(_lastRotation / 90f);
				int num3 = num - num2;
				if (num3 > 0)
				{
					for (int i = 0; i < num3; i++)
					{
						flag = true;
						RoomAlgorithms.RotateFloorPlan(_blueprintFloorPlan, clockwise: true);
						AudioManager.Instance.Play("RotateObject:Large");
						_numberOfRotations--;
						_rotationOffset -= 90f;
					}
				}
				else if (num3 < 0)
				{
					for (int j = 0; j < -num3; j++)
					{
						flag = true;
						RoomAlgorithms.RotateFloorPlan(_blueprintFloorPlan, clockwise: false);
						AudioManager.Instance.Play("RotateObject:Large");
						_numberOfRotations++;
						_rotationOffset += 90f;
					}
				}
				if (_landscapeEdit)
				{
					vector = _cursorManager.WorldPosition.SnapTo(1f).CellFraction(2f) - new Vector3(1f, 0f, 1f);
				}
				_lastRotation = _rotateControl.Rotation;
			}
			else
			{
				Vector3 vector2 = (_landscapeEdit ? _cursorManager.WorldPosition.SnapTo(1f) : _cursorManager.WorldPositionSmoothed);
				GridCoord gridCoord = vector2.ToGridCoord() - _cursorStart;
				vector = vector2.CellFraction(2f) - new Vector3(1f, 0f, 1f);
				HospitalMap hospitalMapAtWorldPosition = _worldState.GetHospitalMapAtWorldPosition(vector2);
				if (hospitalMapAtWorldPosition != null)
				{
					_blueprintFloorPlan.SetHospitalMap(hospitalMapAtWorldPosition);
				}
				_blueprintFloorPlan.Anchor = _originalAnchor + gridCoord;
				if (_deltaLastUpdate != gridCoord)
				{
					AudioManager.Instance.Play("BlueprintMoving");
				}
				_deltaLastUpdate = gridCoord;
			}
			GridCoord gridCoord2 = _blueprintFloorPlan.Anchor - anchor;
			bool num4 = gridCoord2.X != 0 || gridCoord2.Y != 0;
			bool validateItems = Mathf.Abs(_rotationOffset) < 0.1f && Mathf.Abs(vector.magnitude) < 0.1f;
			bool validateWindows = num4 || flag;
			if (_rotateControl.Rotating)
			{
				GridCoord center2 = _blueprintFloorPlan.WorldBounds.Center;
				if (center != center2)
				{
					GridCoord gridCoord3 = center - center2;
					_cursorStart -= gridCoord3;
					_blueprintFloorPlan.Anchor += gridCoord3;
				}
			}
			if (!_landscapeEdit)
			{
				_blueprintFloorPlan.Validate(validateItems, validateWindows);
			}
			if (num4)
			{
				_buildEvents.OnFloorPlanUpdated.InvokeSafe(_blueprintFloorPlan);
			}
			vector.y = _positionOffset;
			_floorPlanVisual.UpdateFromRoom(_blueprintFloorPlan, vector, _rotationOffset);
			_sellItems.AddRange(_blueprintFloorPlan.ItemsToSell);
			_invalidItems.AddRange(_blueprintFloorPlan.InvalidItems);
			RoomItemAlgorithms.RefreshSellVisualsOnItems(previousSellItems, _sellItems);
			RoomItemAlgorithms.RefreshBoundVisualsOnItems(previousItems, _invalidItems);
			if (!_rotateControl.Rotating)
			{
				bool flag2 = _landscapeEdit || _blueprintFloorPlan.ValidFloorTiles;
				if (_rotateControl.Place && flag2)
				{
					if (!_landscapeEdit)
					{
						_floorPlanVisual.UpdateFromRoom(_blueprintFloorPlan);
					}
					_buildEvents.OnMoveRoomEnd.InvokeSafe(param1: false, vector);
					_cursorManager.PopMode<CursorRoomMove>();
				}
				else if (_rotateControl.Cancel)
				{
					int num5 = _numberOfRotations & 3;
					for (int k = 0; k < num5; k++)
					{
						RoomAlgorithms.RotateFloorPlan(_blueprintFloorPlan, clockwise: true);
					}
					_blueprintFloorPlan.Anchor = _originalAnchor;
					HideInvalidItemBounds();
					if (!_landscapeEdit)
					{
						HideInvalidItemBounds();
						_blueprintFloorPlan.Validate();
						ShowInvalidItemBounds();
					}
					_floorPlanVisual.UpdateFromRoom(_blueprintFloorPlan);
					_buildEvents.OnMoveRoomEnd.InvokeSafe(param1: false, vector);
					_cursorManager.PopMode<CursorRoomMove>();
				}
			}
			if (_landscapeEdit && inputManager.GetButtonDown(52))
			{
				_buildEvents.OnMoveRoomEnd.InvokeSafe(param1: true, vector);
				_cursorManager.PopMode<CursorRoomMove>();
			}
			if (_roomCopyMode && inputManager.GetMouseQuick(MouseButton.Right) && _level != null && _level.BuildingLogic != null)
			{
				_level.BuildingLogic.TransitionToNullState(applyChanges: false);
				_level.HospitalHUDManager.HideRibbonMenuBuildBar();
				_level.HospitalHUDManager.ToggleRoomsList();
			}
			_cursorManager.SetCursorVisible(visible: false);
		}

		private void ShowInvalidItemBounds()
		{
			_sellItems.AddRange(_blueprintFloorPlan.ItemsToSell);
			_invalidItems.AddRange(_blueprintFloorPlan.InvalidItems);
			RoomItemAlgorithms.ShowSellItems(_sellItems);
			RoomItemAlgorithms.ShowItemBounds(_invalidItems);
		}

		private void HideInvalidItemBounds()
		{
			RoomItemAlgorithms.HideSellItems(_sellItems);
			RoomItemAlgorithms.HideItemBounds(_invalidItems);
			_sellItems.Clear();
			_invalidItems.Clear();
		}

		public void InitializeForCopy()
		{
			_originalAnchor = _cursorManager.GridPosition;
			_roomCopyMode = true;
			_rotateControl.RoomCopyMode = true;
		}
	}
}
