using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class CursorRoomItem : CursorMode
	{
		private enum EditMode
		{
			New = 0,
			Existing = 1
		}

		private readonly IRoomItemDefinition _definition;

		private readonly Level _level;

		private readonly FinanceManager _financeManager;

		private readonly WorldState _worldState;

		private readonly BuildEvents _buildEvents;

		private RoomItem _roomItem;

		private FloorPlan _floorPlan;

		private RoomFloorPlanVisual _roomFloorPlanVisual;

		private readonly bool _canPlaceInOtherRooms;

		private EditMode _editMode;

		private bool _endOnPlace;

		private List<RoomItem> _invalidItems;

		private Vector3 _cursorWorldPosition;

		private readonly CursorControlRotatePlace _rotateControl;

		private FloorPlan _cachedFloorPlan;

		private List<ConvexPolygon> _wallColliders;

		[DontSave]
		private readonly RoomBuildingNavMesh _navMesh;

		[DontSave]
		private RoomItemPlaceInfoMenu _roomItemInfoMenu;

		private ParticleEffectControlComponent _particleEffectControl;

		private static float MaxMovementDelta = 5f;

		private static float MaxCollisionDistance = 30f;

		public RoomItem RoomItem => _roomItem;

		public CursorRoomItem(CursorManager cursorManager, Level level, RoomItemVisualEdit.Config roomItemEditConfig, IRoomItemDefinition definition, float itemRotation, FloorPlan floorPlan, RoomFloorPlanVisual roomFloorPlanVisual, RoomItem existingItem, bool endOnPlace)
			: base(cursorManager)
		{
			_level = level;
			_buildEvents = level.BuildEvents;
			_worldState = level.WorldState;
			_financeManager = level.FinanceManager;
			_floorPlan = floorPlan;
			_roomFloorPlanVisual = roomFloorPlanVisual;
			_definition = definition;
			_rotateControl = new CursorControlRotatePlace(itemRotation, cursorManager);
			BlueprintFloorPlan blueprintFloorPlan = _floorPlan as BlueprintFloorPlan;
			bool flag = definition.ItemType == RoomItemDefinition.Type.Door;
			bool flag2 = definition.ItemType == RoomItemDefinition.Type.Window;
			bool flag3 = definition.ItemType == RoomItemDefinition.Type.Landscape;
			_canPlaceInOtherRooms = !flag && !flag2 && !flag3;
			_level.DataViewManager.DisableOverlay(setByPlayer: false);
			SetupRoomItem(_level.VisualManager, _level.DataViewManager.ValueMaterial, roomItemEditConfig, existingItem);
			UpdateWallObjectRotation(_definition.ItemType == RoomItemDefinition.Type.Door || _definition.ItemType == RoomItemDefinition.Type.Window);
			_endOnPlace |= endOnPlace;
			if (blueprintFloorPlan != null)
			{
				_buildEvents.OnFloorPlanUpdated.InvokeSafe(blueprintFloorPlan);
			}
			_cursorManager.SetPlaneOffset(definition.OccupyWallOnly ? 1 : 0);
			_roomItemInfoMenu = _level.HUD.CreateMenu<RoomItemPlaceInfoMenu>();
			_roomItemInfoMenu.Setup(_roomItem, _level);
			if (_floorPlan.HospitalMap != null)
			{
				_navMesh = _level.BuildingLogic.GetRoomBuildingNavMesh(_floorPlan.HospitalMap);
				_navMesh.Reset();
				_navMesh.UpdateFrom(_floorPlan, _level.BuildingLogic.CurrentBlueprintFloorPlan, _worldState.Anchor);
			}
			CenterCursorOnRoomItem();
			_cursorWorldPosition = _cursorManager.WorldPosition;
			_level.CameraLogic.TrackObject(null);
		}

		private void SetupRoomItem(VisualManager visualManager, Material valueMaterial, RoomItemVisualEdit.Config roomItemEditConfig, RoomItem existingItem)
		{
			if (existingItem != null)
			{
				_editMode = EditMode.Existing;
				_endOnPlace = true;
				_roomItem = existingItem;
			}
			else
			{
				_editMode = EditMode.New;
				_roomItem = new RoomItem(_definition, _floorPlan, _level);
				_roomItem.Rotation = _rotateControl.Rotation;
				_roomItem.LocalPosition = _cursorManager.WorldPosition.SnapTo(_definition.GridSnap) - _floorPlan.GetAnchorWorldPos();
				RoomItemVisual roomItemVisual = new RoomItemVisual(visualManager, _roomItem.BlueprintPrefab, _roomItem.UpgradeAddOnBlueprintPrefab, null, valueMaterial, roomItemEditConfig, _buildEvents);
				roomItemVisual.UpdateFrom(_roomItem, snap: true, itemOnCursor: true, newItemOnCursor: true);
				_roomItem.Visual = roomItemVisual;
			}
			_roomItem.RemoveComponents<RoomItemSellInvalidComponent>();
			_roomItem.EnableAttributes(enabled: false);
			if (_roomItem.Visual != null)
			{
				_roomItem.Visual.SetupEditingVisuals(_roomItem);
				if (_roomItem.Visual.GameObject != null)
				{
					_particleEffectControl = _roomItem.Visual.GameObject.GetComponent<ParticleEffectControlComponent>();
				}
			}
			_level.BuildingLogic.StartEditingRoomObject(_roomItem);
		}

		public override void OnBecomeActive()
		{
			base.OnBecomeActive();
			_cursorManager.SetCursorIcon(CursorIcon.Default);
			_rotateControl.Initialise();
			HideInvalidItemBounds();
		}

		public override void Destroy()
		{
			if (_definition.DataViewMode != DataViewManager.Mode.None && !EditingBlueprintRoom())
			{
				_level.DataViewManager.DisableOverlay(setByPlayer: false);
			}
			HideInvalidItemBounds();
			DestroyRoomItem();
			_rotateControl.Destroy();
			if (_navMesh != null)
			{
				_level.BuildingLogic.ReleaseRoomBuildingNavMesh();
			}
			_level.HUD.DestroyMenu<RoomItemPlaceInfoMenu>();
			base.Destroy();
		}

		public override void CursorUpdate(InputManager inputManager)
		{
			UpdateCursorPosition();
			RoomItemVisual visual = _roomItem.Visual;
			if (visual == null)
			{
				return;
			}
			bool flag = !inputManager.IsMouseOverGuiOrDraggingScrollbar();
			visual.SetActive(flag);
			if (_roomItemInfoMenu != null)
			{
				GameObjectUtils.SetActive(_roomItemInfoMenu.gameObject, flag);
			}
			if (_particleEffectControl != null)
			{
				if (_roomItem.Definition.DisableParticlesOnEdit)
				{
					_particleEffectControl.StopAllParticles();
				}
				_particleEffectControl.EnableSpawnedEffects(enable: false);
			}
			if (_definition.DataViewMode != DataViewManager.Mode.None && !EditingBlueprintRoom())
			{
				_level.DataViewManager.EnableMode(_definition.DataViewMode, setByPlayer: false);
			}
			int num;
			float num2;
			if (_definition.AllowFreePlacement())
			{
				num = (inputManager.GetButton(31) ? 1 : 0);
				if (num != 0)
				{
					num2 = 0.1f;
					goto IL_00db;
				}
			}
			else
			{
				num = 0;
			}
			num2 = _definition.GridSnap;
			goto IL_00db;
			IL_00db:
			float cellSize = num2;
			float rotationSnap = ((num != 0) ? 1f : _definition.RotationSnap);
			_rotateControl.Update(inputManager, _level, rotationSnap, _definition.ItemSize, _roomItem);
			bool place = _rotateControl.Place;
			bool cancel = _rotateControl.Cancel;
			Vector3 worldPosition = _roomItem.WorldPosition;
			bool flag2 = false;
			if (!_rotateControl.Rotating)
			{
				Vector3 itemCursorPosition = GetItemCursorPosition();
				Vector3 vector = (_level.UserPreferences.Control.UseRoomItemSnap ? itemCursorPosition : itemCursorPosition.SnapTo(cellSize));
				_roomItem.LocalPosition = vector - _floorPlan.GetAnchorWorldPos();
			}
			_roomItem.Rotation = _rotateControl.SnapRotation;
			_level.HighlightManager.HighlightObject(_roomItem);
			UpdateRoomPlacingItemIn();
			if (_level.UserPreferences.Control.UseRoomItemSnap)
			{
				_roomItem.WorldPosition = _roomItem.WorldPosition.SnapTo(cellSize);
				if (ResolveItemCollision(worldPosition, _roomItem.WorldPosition))
				{
					flag2 = true;
				}
			}
			if (!flag2)
			{
				_roomItem.WorldPosition = _roomItem.WorldPosition.SnapTo(cellSize);
			}
			UpdateWallObjectRotation();
			if (!flag2)
			{
				_roomItem.WorldPosition = _roomItem.WorldPosition.SnapTo(cellSize);
			}
			Vector3 vector2 = visual.WorldPosition - _roomItem.WorldPosition;
			vector2.y = 0f;
			bool flag3 = Mathf.Abs(vector2.magnitude) > 0.1f || _rotateControl.Rotating;
			bool flag4 = ValidatePlacement(flag3, flag);
			bool isValid = _roomItem.IsValid;
			string invalidReasonDebug = _roomItem.InvalidReasonDebug;
			string invalidReasonDisplay = _roomItem.InvalidReasonDisplay;
			if (flag3)
			{
				_roomItem.SetValidDebug(valid: true, "Moving");
			}
			visual.CursorUpdate();
			visual.UpdateFrom(_roomItem, snap: false, itemOnCursor: true, newItemOnCursor: false, _definition.GetEditLiftOffset(_roomItem));
			visual.ShowBoundsVisual(_roomItem, flag3);
			if (flag3)
			{
				_roomItem.SetValid(isValid, invalidReasonDebug, invalidReasonDisplay);
			}
			if (cancel)
			{
				_buildEvents.OnStopRoomAutoFlow.InvokeSafe();
				if (_definition.DataViewMode != DataViewManager.Mode.None && !EditingBlueprintRoom())
				{
					_level.DataViewManager.DisableOverlay(setByPlayer: false);
				}
			}
			bool flag5 = false;
			if (place)
			{
				if (flag4)
				{
					flag5 = PlaceItem();
				}
				else
				{
					if (_invalidItems != null && _invalidItems.Count != 0)
					{
						foreach (RoomItem invalidItem in _invalidItems)
						{
							_buildEvents.OnRoomItemInvalid.InvokeSafe(invalidItem);
						}
					}
					_ = _roomItem.IsValid;
					_buildEvents.OnRoomItemPlacementDenied.InvokeSafe(_roomItem, _floorPlan);
				}
			}
			if (cancel)
			{
				CancelItem(cancel);
			}
			else if (flag5 && (!(_level.HUD.FindMenu<EditHospitalMenu>() != null) || _editMode == EditMode.Existing))
			{
				CancelItem(cancel);
			}
		}

		private void UpdateCursorPosition()
		{
			_cursorWorldPosition += _cursorManager.WorldPositionDelta;
		}

		private void UpdateRoomPlacingItemIn()
		{
			if (!_canPlaceInOtherRooms)
			{
				return;
			}
			FloorPlan floorPlan = null;
			RoomFloorPlanVisual newFloorPlanVisual = null;
			Vector3 cursorRoomTestPosition = GetCursorRoomTestPosition();
			Room roomAtWorldCoord = _worldState.GetRoomAtWorldCoord(cursorRoomTestPosition, includeHospital: true, includeClosedPlots: false);
			DebugDrawUtils.Marker(cursorRoomTestPosition, Color.magenta);
			if (roomAtWorldCoord != null)
			{
				floorPlan = roomAtWorldCoord.FloorPlan;
				newFloorPlanVisual = roomAtWorldCoord.FloorPlanVisual;
			}
			BlueprintFloorPlan currentBlueprintFloorPlan = _level.BuildingLogic.CurrentBlueprintFloorPlan;
			if (currentBlueprintFloorPlan != null && RoomAlgorithms.RoomContainsWorldCoord(currentBlueprintFloorPlan, cursorRoomTestPosition.ToGridCoord()))
			{
				floorPlan = currentBlueprintFloorPlan;
				newFloorPlanVisual = _level.BuildingLogic.CurrentBlueprintFloorPlanVisual;
			}
			if (floorPlan == null || floorPlan == _floorPlan)
			{
				return;
			}
			if (!_level.UserPreferences.Control.UseRoomItemSnap || floorPlan is BlueprintFloorPlan)
			{
				SetFloorPlanEditing(floorPlan, newFloorPlanVisual);
				return;
			}
			float radius = (_roomItem.Definition.CanBePlacedIn(floorPlan.Definition._type) ? GameAlgorithms.Config.CursorInNextRoomDistance : GameAlgorithms.Config.CursorInNextRoomDistanceItemInvalid);
			bool flag = RoomItemAlgorithms.GetClosestWallToLocation(floorPlan, cursorRoomTestPosition, radius) != null;
			if (!flag && currentBlueprintFloorPlan != null && floorPlan != currentBlueprintFloorPlan && RoomItemAlgorithms.GetClosestWallToLocation(currentBlueprintFloorPlan, cursorRoomTestPosition, radius) != null)
			{
				flag = true;
			}
			if (!flag)
			{
				SetFloorPlanEditing(floorPlan, newFloorPlanVisual);
			}
		}

		private void SetFloorPlanEditing(FloorPlan newFloorPlan, RoomFloorPlanVisual newFloorPlanVisual)
		{
			HideInvalidItemBounds();
			if (_floorPlan is BlueprintFloorPlan blueprintFloorPlan)
			{
				blueprintFloorPlan.ValidateTiles();
			}
			RoomAlgorithms.ValidateRoomItems(ItemValidateMode.Test, null, _floorPlan, _worldState, null, _navMesh);
			_floorPlan = newFloorPlan;
			_roomFloorPlanVisual = newFloorPlanVisual;
			_roomItem.FloorPlan = _floorPlan;
			RoomItemAlgorithms.RefreshInvalidItemBounds(_floorPlan);
		}

		private Vector3 GetCursorRoomTestPosition()
		{
			if (_level.UserPreferences.Control.UseRoomItemSnap)
			{
				return _cursorWorldPosition;
			}
			return _roomItem.WorldPosition;
		}

		private bool ResolveItemCollision(Vector3 origPos, Vector3 desiredPos)
		{
			if (origPos.SquareDistance2D(desiredPos) > MaxMovementDelta * MaxMovementDelta)
			{
				return false;
			}
			bool flag = false;
			if (_definition.HasCollision && !_definition.PlaceOnWall)
			{
				_roomItem.WorldPosition = origPos;
				ConvexPolygon combinedCollisionShape = _roomItem.GetCombinedCollisionShape(worldSpace: true, includeSolid: true, includeNonSolid: true);
				if (combinedCollisionShape != null)
				{
					Vector3 vector = desiredPos - origPos;
					float num = Mathf.Min(vector.magnitude / GameAlgorithms.Config.CursorItemMaxStepSize, 10f);
					Vector3 vector2 = vector / num;
					Vector3 resolvedPos = origPos;
					CacheCollisionShapes(force: false);
					for (int i = 0; (float)i < num; i++)
					{
						combinedCollisionShape.Move(vector2);
						resolvedPos += vector2;
						if (ResolveCollision(_wallColliders, combinedCollisionShape, ref resolvedPos))
						{
							flag = true;
						}
					}
					if (!flag || Vector3.Distance(resolvedPos, desiredPos) >= GameAlgorithms.Config.CursorRoomItemSnapDistance)
					{
						_roomItem.WorldPosition = desiredPos;
					}
					else
					{
						_roomItem.WorldPosition = resolvedPos;
					}
				}
			}
			return flag;
		}

		private static bool ResolveCollision(List<ConvexPolygon> shapes, ConvexPolygon itemShape, ref Vector3 resolvedPos)
		{
			bool result = false;
			if (shapes != null)
			{
				float num = MaxCollisionDistance * MaxCollisionDistance;
				foreach (ConvexPolygon shape in shapes)
				{
					if (shape.Center.SquareDistance2D(itemShape.Center) < num && ConvexPolygon.Intersect(itemShape, shape, out var resolveVector))
					{
						itemShape.Move(resolveVector);
						resolvedPos += resolveVector.as_xz_v3();
						result = true;
					}
				}
			}
			return result;
		}

		private void CacheCollisionShapes(bool force)
		{
			if (force || _floorPlan != _cachedFloorPlan)
			{
				_wallColliders = new List<ConvexPolygon>();
				AddFloorPlanCollision(_floorPlan);
				_cachedFloorPlan = _floorPlan;
				AddBlueprintFloorPlanCollision();
			}
		}

		private void AddFloorPlanCollision(FloorPlan floorPlan)
		{
			float num = floorPlan.Definition.WallThickness + 0.125f;
			float outsideWallThickness = GameAlgorithms.Config.OutsideWallThickness;
			Vector3[] array = new Vector3[4]
			{
				new Vector3(-1f, 0f, 1f + outsideWallThickness),
				new Vector3(1f, 0f, 1f + outsideWallThickness),
				new Vector3(1f, 0f, 1f - num),
				new Vector3(-1f, 0f, 1f - num)
			};
			foreach (WallCoord wall in floorPlan.Walls)
			{
				if (!wall.IsCorner())
				{
					ConvexPolygon convexPolygon = new ConvexPolygon();
					Vector3 vector = (wall._position + floorPlan.Anchor).ToWorldPosition();
					Quaternion quaternion = Quaternion.Euler(0f, wall._rotation.YawRotation(), 0f);
					Vector3[] array2 = array;
					foreach (Vector3 vector2 in array2)
					{
						convexPolygon.Points.Add((vector + quaternion * vector2).Xz());
					}
					convexPolygon.Calculate();
					_wallColliders.Add(convexPolygon);
				}
			}
		}

		private void AddBlueprintFloorPlanCollision()
		{
			BlueprintFloorPlan currentBlueprintFloorPlan = _level.BuildingLogic.CurrentBlueprintFloorPlan;
			if (currentBlueprintFloorPlan == null || currentBlueprintFloorPlan == _cachedFloorPlan)
			{
				return;
			}
			float num = currentBlueprintFloorPlan.Definition.WallThickness + 0.125f;
			float outsideWallThickness = GameAlgorithms.Config.OutsideWallThickness;
			Vector3[] array = new Vector3[4]
			{
				new Vector3(-1f, 0f, 1f + outsideWallThickness),
				new Vector3(1f, 0f, 1f + outsideWallThickness),
				new Vector3(1f, 0f, 1f - num),
				new Vector3(-1f, 0f, 1f - num)
			};
			foreach (WallCoord wall in currentBlueprintFloorPlan.Walls)
			{
				if (!wall.IsCorner())
				{
					ConvexPolygon convexPolygon = new ConvexPolygon();
					GridDirection direction = wall._rotation.Rotate180();
					Vector3 vector = (wall._position + currentBlueprintFloorPlan.Anchor + wall._rotation.DirectionCoord()).ToWorldPosition();
					Quaternion quaternion = Quaternion.Euler(0f, direction.YawRotation(), 0f);
					Vector3[] array2 = array;
					foreach (Vector3 vector2 in array2)
					{
						convexPolygon.Points.Add((vector + quaternion * vector2).Xz());
					}
					convexPolygon.Calculate();
					_wallColliders.Add(convexPolygon);
				}
			}
		}

		private bool ValidatePlacement(bool moving, bool isVisible)
		{
			HideInvalidItemBounds();
			if (!isVisible || (_floorPlan != null && _floorPlan.HospitalMap != null && _floorPlan.HospitalMap.Plot.Definition.UseEnergyUI))
			{
				return false;
			}
			_floorPlan.AddItemNoValidation(_roomItem);
			if (_navMesh != null)
			{
				_navMesh.UpdateFrom(_floorPlan, _level.BuildingLogic.CurrentBlueprintFloorPlan, _worldState.Anchor);
			}
			BlueprintFloorPlan blueprintFloorPlan = _floorPlan as BlueprintFloorPlan;
			blueprintFloorPlan?.ValidateTiles();
			_invalidItems = RoomAlgorithms.ValidateRoomItems(ItemValidateMode.Test, _roomItem.MapTileBound, _floorPlan, _worldState, null, _navMesh);
			blueprintFloorPlan?.RemoveItemToSell(_roomItem);
			if (_navMesh != null)
			{
				_invalidItems.Remove(_roomItem);
			}
			RoomItemAlgorithms.Validate(ItemValidateMode.Set, fullTest: true, _roomItem, _worldState, (_editMode == EditMode.New) ? _financeManager : null, _navMesh, _invalidItems);
			if (!moving && _navMesh != null && _navMesh.InvalidItems.Contains(_roomItem))
			{
				_roomItem.SetValid(valid: false, "Invalid nav points", ScriptLocalization.Menu.ItemInvalid_InvalidNavigation_CS);
				_level.WorldState.ShowUnreachableNavIsland(_navMesh, _roomItem);
			}
			_invalidItems.Remove(_roomItem);
			if (_navMesh != null)
			{
				_invalidItems.AddRange(_navMesh.InvalidItems);
			}
			bool flag = AllowPlacementWithInvalidItems();
			RoomItemAlgorithms.ShowItemBounds(_invalidItems);
			if (_roomItem.IsValid && !flag)
			{
				_roomItem.SetValidDebug(valid: false, "Invalidating other object(s)");
			}
			_floorPlan.RemoveItemNoValidation(_roomItem);
			if (flag)
			{
				return _roomItem.IsValid;
			}
			return false;
		}

		private bool AllowPlacementWithInvalidItems()
		{
			if (!EditingBlueprintRoom())
			{
				return _invalidItems.Count == 0;
			}
			return true;
		}

		private void HideInvalidItemBounds()
		{
			if (_invalidItems != null)
			{
				RoomItemAlgorithms.HideItemBounds(_invalidItems);
				_invalidItems.Clear();
			}
			RoomItemAlgorithms.RefreshInvalidItemBounds(_floorPlan);
		}

		private bool PlaceItem()
		{
			RoomItemVisual visual = _roomItem.Visual;
			RoomItem roomItem;
			if (_editMode == EditMode.New)
			{
				roomItem = ((_definition.ItemType == RoomItemDefinition.Type.Landscape) ? new LandscapeRoomItem(_roomItem, _floorPlan, CursorEditHospital.HospitalPlotLayer) : new RoomItem(_roomItem, _floorPlan));
			}
			else
			{
				_level.BuildingLogic.StopEditingRoomObject(_roomItem);
				roomItem = _roomItem;
				_roomItem = null;
			}
			roomItem.EnableAttributes(enabled: true);
			RoomPrestige param = GameAlgorithms.CalculateRoomPrestige(_floorPlan);
			_floorPlan.AddItem(roomItem);
			if (!_floorPlan.Definition.IsHospitalOrBay)
			{
				RoomPrestige param2 = GameAlgorithms.CalculateRoomPrestige(_floorPlan);
				_level.BuildEvents.OnFloorPlanPrestigeUpdated.InvokeSafe(_floorPlan, param, param2);
			}
			if (roomItem.Visual != null)
			{
				roomItem.Visual.DisableAndDestroyEditingVisuals();
			}
			BlueprintFloorPlan blueprintFloorPlan = _floorPlan as BlueprintFloorPlan;
			if (blueprintFloorPlan != null)
			{
				_roomFloorPlanVisual.UpdateFromRoom(_floorPlan);
				_buildEvents.OnFloorPlanUpdated.InvokeSafe(blueprintFloorPlan);
				RoomItemVisual roomItemVisual = _roomFloorPlanVisual.RoomItems[_roomFloorPlanVisual.RoomItems.Count - 1];
				if (visual != null && roomItemVisual.Animator != null)
				{
					roomItemVisual.CopyAnimatorStateFrom(visual);
					roomItemVisual.Animator.Pause();
				}
			}
			else
			{
				_roomFloorPlanVisual.CreateRoomItems();
				roomItem.AddToWorld(updateNavigation: true);
				if (_floorPlan.OwningRoom == null || _floorPlan.OwningRoom.IsOpen)
				{
					_worldState.AddNeedSatisfyingRoomItem(roomItem);
				}
				RoomAlgorithms.ValidateRoomItems(ItemValidateMode.Set, roomItem.MapTileBound, _floorPlan, _worldState, null, null);
				roomItem.SetValid(valid: true, roomItem.InvalidReasonDebug, roomItem.InvalidReasonDisplay);
			}
			bool flag = blueprintFloorPlan != null;
			bool num = _editMode == EditMode.New && flag;
			bool flag2 = _editMode == EditMode.Existing && !roomItem.HasBeenPurchased && flag;
			if (!num && !flag2 && !roomItem.HasBeenPurchased)
			{
				roomItem.HasBeenPurchased = true;
				_buildEvents.OnRoomItemPurchased.InvokeSafe(roomItem);
			}
			_buildEvents.OnRoomItemPlaced.InvokeSafe(roomItem, _floorPlan);
			if (roomItem.Visual != null)
			{
				ParticleEffectControlComponent component = roomItem.Visual.GameObject.GetComponent<ParticleEffectControlComponent>();
				if (component != null)
				{
					if (roomItem.Definition.DisableParticlesOnEdit)
					{
						component.EnableAllEffects(enable: true);
					}
					component.EnableSpawnedEffects(enable: true);
				}
			}
			if (_definition.PlacementEffect != null)
			{
				Object.Instantiate(_definition.PlacementEffect, roomItem.WorldPosition, Quaternion.Euler(0f, roomItem.Rotation, 0f));
			}
			RoomItemAlgorithms.RefreshInvalidItemBounds(_floorPlan);
			if (_endOnPlace || _definition.SinglePlace)
			{
				return true;
			}
			if (_roomItem != null && _roomItem.Visual != null)
			{
				_roomItem.Visual.UpdateFrom(_roomItem, snap: true, itemOnCursor: true, newItemOnCursor: true);
			}
			CacheCollisionShapes(force: true);
			return false;
		}

		private void CancelItem(bool userRequestCancelPlacement)
		{
			_buildEvents.OnRoomItemCancel.InvokeSafe(_roomItem, userRequestCancelPlacement);
			if (_editMode == EditMode.New || userRequestCancelPlacement)
			{
				DestroyRoomItem();
			}
		}

		private void DestroyRoomItem()
		{
			if (_roomItem != null)
			{
				if (_roomItem.HasBeenPurchased)
				{
					_buildEvents.OnRoomItemSold.InvokeSafe(_roomItem);
				}
				_level.BuildingLogic.StopEditingRoomObject(_roomItem);
				if (_roomItem.Visual != null)
				{
					_roomItem.Visual.Destroy();
				}
				_roomItem.Destroy();
				_roomItem = null;
			}
		}

		private Vector3 GetItemCursorPosition()
		{
			if (_definition.ItemType == RoomItemDefinition.Type.Door || _definition.ItemType == RoomItemDefinition.Type.Window)
			{
				return _cursorManager.WorldPosition - _rotateControl.Rotation.ToGridDirection().DirectionVector();
			}
			return _cursorWorldPosition;
		}

		private void UpdateWallObjectRotation(bool adjustPosition = true)
		{
			WallCoord closestWallToLocation = RoomItemAlgorithms.GetClosestWallToLocation(_floorPlan, _cursorManager.WorldPosition, _definition.WallMagnetismDistance + 1f, onlyOnSameAxis: false, _roomItem);
			if (closestWallToLocation == null)
			{
				return;
			}
			if (_definition.WallMagnetism && _level.UserPreferences.Control.UseWallMagnetism)
			{
				_rotateControl.Rotation = closestWallToLocation._rotation.YawRotation() + _definition.WallMagnetismRotation;
			}
			if (!_definition.PlaceOnWall)
			{
				return;
			}
			RoomItem roomItem = _roomItem;
			float rotation = (_rotateControl.Rotation = closestWallToLocation._rotation.YawRotation());
			roomItem.Rotation = rotation;
			if (adjustPosition)
			{
				if (_definition.ItemType == RoomItemDefinition.Type.Window)
				{
					_roomItem.LocalPosition = closestWallToLocation._position.ToWorldPosition();
				}
				else
				{
					_roomItem.LocalPosition = closestWallToLocation.ClampPositionToWall(_roomItem.LocalPosition);
				}
			}
		}

		private bool EditingBlueprintRoom()
		{
			return _level.BuildingLogic.CurrentBlueprintFloorPlan != null;
		}

		public override void DebugDraw()
		{
			Vector2 screenPosition = _cursorManager.ScreenPosition;
			GUI.Label(new Rect(screenPosition.x, (float)Screen.height - screenPosition.y - 64f, 300f, 100f), _roomItem.InvalidReasonDebug);
		}

		public void SetRoomItemTransform(Vector3 position, float rotation)
		{
			_roomItem.Rotation = rotation;
			_roomItem.WorldPosition = position;
			_rotateControl.Rotation = rotation;
			_roomItem.Visual.UpdateFrom(_roomItem, snap: true, itemOnCursor: true, newItemOnCursor: false, _definition.GetEditLiftOffset(_roomItem));
			CenterCursorOnRoomItem();
		}

		private void CenterCursorOnRoomItem()
		{
			Vector2 cursorPos = _level.InputManager.GetCursorPos();
			Vector3 vector = Camera.main.WorldToScreenPoint(_roomItem.WorldPosition);
			Vector3 vector2 = Camera.main.WorldToScreenPoint(_cursorManager.WorldPosition);
			cursorPos.x += vector.x - vector2.x;
			cursorPos.y -= vector.y - vector2.y;
			_level.InputManager.SetCursorPos(cursorPos);
		}
	}
}
