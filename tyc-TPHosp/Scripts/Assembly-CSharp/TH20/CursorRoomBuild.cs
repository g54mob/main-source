using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	public class CursorRoomBuild : CursorMode
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public GameObject DragFloorTilePrefab;

			public Material DragAddMaterialValid;

			public Material DragAddMaterialInvalid;

			public SharedInstance<RoomWallDefinition> DragAddWallDefinition;

			public Material DragSubMaterialValid;

			public Material DragSubMaterialInvalid;

			public SharedInstance<RoomWallDefinition> DragSubWallDefinition;
		}

		public enum RoomAreaDragOperation
		{
			Add = 0,
			Subtract = 1
		}

		private readonly Config _config;

		private readonly Level _level;

		private readonly BuildEvents _buildEvents;

		private readonly BuildingLogic _buildingLogic;

		private readonly WorldState _worldState;

		private readonly HighlightManager _highlightManager;

		private readonly BlueprintFloorPlan _blueprintFloorPlan;

		private readonly BlueprintFloorPlanVisual _floorPlanVisual;

		private bool _dragging;

		private bool _dragIsValid;

		private RoomAreaDragOperation _dragOperation;

		private GridCoord _dragStartCoord;

		private GridCoord _currentDragEndPoint;

		private GridCoord _dragSizeLastUpdate;

		private readonly BlueprintFloorPlan _dragFloorPlan;

		private readonly BlueprintFloorPlanVisual _dragFloorPlanVisualisation;

		private const string BlueprintExpandingAudioEvent = "BlueprintExpanding";

		private const string BlueprintSubtractingAudioEvent = "BlueprintSubtracting";

		private readonly List<RoomItem> _sellItems = new List<RoomItem>();

		private readonly List<RoomItem> _invalidItems = new List<RoomItem>();

		public RoomAreaDragOperation DragOperation
		{
			get
			{
				return _dragOperation;
			}
			set
			{
				_dragOperation = value;
			}
		}

		public BlueprintFloorPlan BlueprintFloorPlan => _blueprintFloorPlan;

		public CursorRoomBuild(CursorManager cursorManager, Level level, Config config, BlueprintFloorPlan blueprintFloorPlan, BlueprintFloorPlanVisual floorPlanVisual)
			: base(cursorManager)
		{
			_config = config;
			_level = level;
			_buildEvents = level.BuildEvents;
			_buildingLogic = level.BuildingLogic;
			_blueprintFloorPlan = blueprintFloorPlan;
			_floorPlanVisual = floorPlanVisual;
			_worldState = level.WorldState;
			_highlightManager = level.HighlightManager;
			RoomDefinition definition = _blueprintFloorPlan.Definition;
			_dragFloorPlan = new BlueprintFloorPlan(definition, level, null);
			_dragFloorPlanVisualisation = new BlueprintFloorPlanVisual(level.WorldState, level.VisualManager, level.DataViewManager, level.BuildingLogic.Configuration.RoomItemEditConfig, level.BuildEvents, "Blueprint", config.DragFloorTilePrefab, GetAddWallDefinition(), config.DragAddMaterialValid, config.DragAddMaterialInvalid, config.DragAddMaterialInvalid);
			blueprintFloorPlan.Validate();
			floorPlanVisual.DisableParticleEffects();
			_buildEvents.OnRoomValidityChanged.InvokeSafe(_blueprintFloorPlan);
			_buildEvents.OnFloorPlanUpdated.InvokeSafe(_blueprintFloorPlan);
			BuildEvents buildEvents = _buildEvents;
			buildEvents.OnRoomItemPlaced = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents.OnRoomItemPlaced, new Action<RoomItem, FloorPlan>(OnRoomItemPlaced));
			BuildEvents buildEvents2 = _buildEvents;
			buildEvents2.OnCursorDeleteObject = (Action<ICursorSelectable>)Delegate.Combine(buildEvents2.OnCursorDeleteObject, new Action<ICursorSelectable>(OnCursorDeleteObject));
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Combine(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
			_level.CameraLogic.TrackObject(null);
			InspectorMenu inspectorMenu = _level.HUD.FindMenu<InspectorMenu>();
			if (inspectorMenu != null)
			{
				inspectorMenu.CloseAndRestoreGeneralNotifications();
			}
		}

		private RoomWallDefinition GetAddWallDefinition()
		{
			if (!(_blueprintFloorPlan.Definition._dragAddWallDefinition != null))
			{
				return _config.DragAddWallDefinition.Instance;
			}
			return _blueprintFloorPlan.Definition._dragAddWallDefinition.Instance;
		}

		private RoomWallDefinition GetSubWallDefinition()
		{
			if (!(_blueprintFloorPlan.Definition._dragSubWallDefinition != null))
			{
				return _config.DragSubWallDefinition.Instance;
			}
			return _blueprintFloorPlan.Definition._dragSubWallDefinition.Instance;
		}

		private CursorModel GetCursorModel(bool subtracting)
		{
			if (subtracting)
			{
				if (!_blueprintFloorPlan.Definition.IsLowWallRoom())
				{
					return CursorModel.RoomBuildSubtract;
				}
				return CursorModel.RoomLowBuildSubtract;
			}
			if (!_blueprintFloorPlan.Definition.IsLowWallRoom())
			{
				return CursorModel.RoomBuild;
			}
			return CursorModel.RoomLowBuild;
		}

		public override void OnBecomeActive()
		{
			_cursorManager.SetCursorVisible(visible: false);
			_cursorManager.SetCursorModel(GetCursorModel(_dragOperation == RoomAreaDragOperation.Subtract));
			_cursorManager.SetCursorIcon((_dragOperation == RoomAreaDragOperation.Add) ? CursorIcon.AddRoom : CursorIcon.SubRoom);
			HideInvalidItemBounds();
			_blueprintFloorPlan.RebuildNavMesh();
			_blueprintFloorPlan.Validate();
			ShowInvalidItemBounds();
		}

		public override void OnBecomeInactive()
		{
			base.OnBecomeInactive();
			_cursorManager.SetCursorIcon(CursorIcon.Default);
			_cursorManager.SetCursorModel(CursorModel.Default);
		}

		public override void CursorUpdate(InputManager inputManager)
		{
			bool subtracting = (_dragOperation == RoomAreaDragOperation.Subtract) ^ Input.GetKey(KeyCode.LeftControl);
			List<RoomItem> previousSellItems = new List<RoomItem>(_sellItems);
			List<RoomItem> previousItems = new List<RoomItem>(_invalidItems);
			_sellItems.Clear();
			_invalidItems.Clear();
			if (!_dragging)
			{
				UpdateSelect(inputManager, subtracting, _blueprintFloorPlan.Definition);
			}
			else
			{
				UpdateBuilding(inputManager, subtracting);
			}
			_floorPlanVisual.UpdateFromRoom(_blueprintFloorPlan);
			_sellItems.AddRange(_blueprintFloorPlan.ItemsToSell);
			_invalidItems.AddRange(_blueprintFloorPlan.InvalidItems);
			RoomItemAlgorithms.RefreshSellVisualsOnItems(previousSellItems, _sellItems);
			RoomItemAlgorithms.RefreshBoundVisualsOnItems(previousItems, _invalidItems);
		}

		private void UpdateBuilding(InputManager inputManager, bool subtracting)
		{
			_cursorManager.SetCursorModel(GetCursorModel(subtracting));
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
				_dragFloorPlan.ValidRoomSize = true;
				_dragIsValid = RoomAlgorithms.CanAddRectToRoomArea(_blueprintFloorPlan, _dragStartCoord, _currentDragEndPoint, subtracting);
				_blueprintFloorPlan.AddDragRect(_dragStartCoord, _currentDragEndPoint, subtracting);
				if (_blueprintFloorPlan.ValidFloorTiles && !_dragIsValid)
				{
					_blueprintFloorPlan.ValidFloorTiles = false;
					_buildEvents.OnRoomValidityChanged.InvokeSafe(_blueprintFloorPlan);
				}
				_dragFloorPlanVisualisation.SetVisible(subtracting || !_dragIsValid);
				_dragFloorPlanVisualisation.CompletelyInvalid = !_dragIsValid;
				if (!subtracting)
				{
					_dragFloorPlanVisualisation.SetAppearance(GetAddWallDefinition(), _config.DragAddMaterialValid, _config.DragAddMaterialInvalid);
				}
				else
				{
					_dragFloorPlanVisualisation.SetAppearance(GetSubWallDefinition(), _config.DragSubMaterialValid, _config.DragSubMaterialInvalid);
				}
				_dragFloorPlanVisualisation.UpdateFromRoom(_dragFloorPlan);
				_cursorManager.SetCursorVisible(visible: false);
				if (_dragSizeLastUpdate.X > num || _dragSizeLastUpdate.Y > num2)
				{
					AudioManager.Instance.Play("BlueprintExpanding");
				}
				else if (_dragSizeLastUpdate.X < num || _dragSizeLastUpdate.Y < num2)
				{
					AudioManager.Instance.Play("BlueprintSubtracting");
				}
				_dragSizeLastUpdate = new GridCoord(num, num2);
			}
			if (!_dragging || (!inputManager.GetButtonUp(10) && !inputManager.GetMouseUp(MouseButton.Left)))
			{
				return;
			}
			_blueprintFloorPlan.EndDrag();
			if (_dragIsValid && (subtracting || _dragFloorPlan.ValidFloorTiles))
			{
				bool canBeBuilt = _blueprintFloorPlan.CanBeBuilt;
				RoomPrestige param = GameAlgorithms.CalculateRoomPrestige(_blueprintFloorPlan);
				RoomAlgorithms.AddRectToRoomArea(_blueprintFloorPlan, _dragStartCoord, _currentDragEndPoint, subtracting);
				if (canBeBuilt != _blueprintFloorPlan.CanBeBuilt)
				{
					_buildEvents.OnRoomValidityChanged.InvokeSafe(_blueprintFloorPlan);
				}
				_buildEvents.OnFloorPlanUpdated.InvokeSafe(_blueprintFloorPlan);
				RoomPrestige param2 = GameAlgorithms.CalculateRoomPrestige(_blueprintFloorPlan);
				_buildEvents.OnFloorPlanPrestigeUpdated.InvokeSafe(_blueprintFloorPlan, param, param2);
				AudioManager.Instance.Play(subtracting ? "BlueprintSubtracting" : "BlueprintExpanding");
			}
			else
			{
				AudioManager.Instance.Play("PlaceObjectDenied");
			}
			_dragging = false;
			_cursorManager.SetCursorVisible(visible: true);
			_dragFloorPlanVisualisation.SetVisible(visible: false);
			_blueprintFloorPlan.Validate();
			_buildEvents.OnRoomDragEnd.InvokeSafe();
		}

		private void UpdateSelect(InputManager inputManager, bool subtracting, RoomDefinition roomDefinition)
		{
			if (!inputManager.IsMouseOverGui && inputManager.GetMouseQuickOnScene(MouseButton.Right))
			{
				if (_dragOperation == RoomAreaDragOperation.Add)
				{
					_buildingLogic.ChangeRoomBuildMode(RoomAreaDragOperation.Subtract);
				}
				else
				{
					_blueprintFloorPlan.AutoFlowActive = true;
					_buildingLogic.ChangeRoomBuildMode(RoomAreaDragOperation.Add);
				}
			}
			_cursorManager.SetCursorVisible(visible: true);
			_cursorManager.SetCursorIcon((!subtracting) ? CursorIcon.AddRoom : CursorIcon.SubRoom);
			_cursorManager.SetCursorModel(GetCursorModel(subtracting));
			if (!_blueprintFloorPlan.AutoFlowActive)
			{
				RoomItem selectedItem = GetSelectedItem();
				if (selectedItem != null)
				{
					_cursorManager.SetCursorVisible(visible: false);
					_cursorManager.SetCursorIcon(CursorIcon.Default);
					_cursorManager.SetCursorModel(CursorModel.Default);
					if (selectedItem.CanHighlight())
					{
						_highlightManager.HighlightObject(selectedItem);
					}
					bool flag = inputManager.GetKey(KeyCode.LeftControl) || inputManager.GetKey(KeyCode.RightControl);
					bool flag2 = !inputManager.IsMouseOverGui && inputManager.GetButtonDown(52);
					if (inputManager.GetMouseDownOnScene(MouseButton.Left) || (!inputManager.IsMouseOverGui && inputManager.GetButtonDown(10)))
					{
						_sellItems.Remove(selectedItem);
						_blueprintFloorPlan.ItemsToSell.Remove(selectedItem);
						if (flag)
						{
							if (selectedItem.Definition.ItemType != RoomItemDefinition.Type.PlotObject)
							{
								_buildEvents.OnBeginItemPlacement.InvokeSafe(selectedItem.Definition, selectedItem.FloorPlan, param3: false);
								if (_cursorManager.TryGetActiveMode<CursorRoomItem>(out var activeMode))
								{
									activeMode.SetRoomItemTransform(selectedItem.WorldPosition, selectedItem.Rotation);
								}
							}
						}
						else if (selectedItem.FloorPlan == _blueprintFloorPlan)
						{
							_buildEvents.OnBeginItemEditBuildMode.InvokeSafe(selectedItem);
						}
						else
						{
							_buildEvents.StartItemEdit(selectedItem, selectedItem.OwningRoom);
						}
					}
					else if (flag2)
					{
						_buildEvents.OnCursorDeleteObject.InvokeSafe(selectedItem);
					}
					return;
				}
			}
			if (!subtracting)
			{
				if (_blueprintFloorPlan.AutoFlowActive && _blueprintFloorPlan.ValidRoomSize)
				{
					RoomItemDefinition itemToLeaveOnCursor = roomDefinition.GetItemToLeaveOnCursor();
					if (_blueprintFloorPlan.RequiredItems.Count != 0)
					{
						List<RoomItemDefinition> validItems = _blueprintFloorPlan.RequiredItems[0].GetValidItems(_worldState);
						if (validItems.Count != 0)
						{
							RoomItemDefinition roomItemDefinition = validItems[0];
							bool flag3 = _blueprintFloorPlan.RequiredItems.Count == 1 && itemToLeaveOnCursor == roomItemDefinition;
							_buildEvents.OnBeginItemPlacement.InvokeSafe(roomItemDefinition, _blueprintFloorPlan, !flag3);
							return;
						}
					}
					if (itemToLeaveOnCursor != null)
					{
						_buildEvents.OnBeginItemPlacement.InvokeSafe(itemToLeaveOnCursor, _blueprintFloorPlan, param3: false);
						return;
					}
					_blueprintFloorPlan.AutoFlowActive = false;
				}
				GridCoord coord = _cursorManager.GridPosition - _blueprintFloorPlan.Anchor;
				if (_blueprintFloorPlan.ValidCoord(coord.X, coord.Y) && _blueprintFloorPlan[coord])
				{
					_cursorManager.SetCursorVisible(visible: false);
					_cursorManager.SetCursorIcon(CursorIcon.MoveRoom);
					_cursorManager.SetCursorModel(CursorModel.Default);
					if (inputManager.GetMouseDownOnScene(MouseButton.Left))
					{
						_buildEvents.OnMoveRoom.InvokeSafe();
						return;
					}
				}
			}
			if (inputManager.GetMouseQuick(MouseButton.Right) && _blueprintFloorPlan.Width() == 0 && _blueprintFloorPlan.Height() == 0 && _blueprintFloorPlan.Items.Count == 0)
			{
				if (_buildingLogic.CurrentState != BuildingLogic.State.Null)
				{
					_buildingLogic.TransitionToNullState(applyChanges: false);
					_level.HospitalHUDManager.HideRibbonMenuBuildBar();
					_level.HospitalHUDManager.ToggleRoomsList();
				}
			}
			else
			{
				if (!inputManager.GetButtonDown(10) && !inputManager.GetMouseDownOnScene(MouseButton.Left))
				{
					return;
				}
				GridCoord gridPosition = _cursorManager.GridPosition;
				if (GridBounds.IsInBounds(gridPosition, _worldState.Bounds))
				{
					if (_blueprintFloorPlan.TileCount == 0)
					{
						_blueprintFloorPlan.SetHospitalMap(_worldState.GetHospitalMapAtWorldPosition(gridPosition));
					}
					if (_blueprintFloorPlan.HospitalMap != null && _blueprintFloorPlan.HospitalMap.Room.Definition._type != RoomDefinition.Type.AmbulanceBay && !_blueprintFloorPlan.HospitalMap.Plot.Definition.UseEnergyUI)
					{
						_dragging = true;
						_dragStartCoord = gridPosition;
						_dragSizeLastUpdate = new GridCoord(1, 1);
						_dragFloorPlan.SetHospitalMap(_blueprintFloorPlan.HospitalMap);
						_blueprintFloorPlan.StartDrag();
						_buildEvents.OnRoomDragStart.InvokeSafe(_dragFloorPlan);
					}
				}
			}
		}

		public override void Destroy()
		{
			HideInvalidItemBounds();
			_cursorManager.SetCursorIcon(CursorIcon.Default);
			_cursorManager.SetCursorModel(CursorModel.Default);
			_dragFloorPlan.Destroy();
			_dragFloorPlanVisualisation.Destroy();
			BuildEvents buildEvents = _buildEvents;
			buildEvents.OnRoomItemPlaced = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents.OnRoomItemPlaced, new Action<RoomItem, FloorPlan>(OnRoomItemPlaced));
			BuildEvents buildEvents2 = _buildEvents;
			buildEvents2.OnCursorDeleteObject = (Action<ICursorSelectable>)Delegate.Remove(buildEvents2.OnCursorDeleteObject, new Action<ICursorSelectable>(OnCursorDeleteObject));
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Remove(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
			base.Destroy();
		}

		private RoomItem GetSelectedItem()
		{
			float num = float.MaxValue;
			RoomItem result = null;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			foreach (RoomItem item in _blueprintFloorPlan.Items)
			{
				if (item.IsSelectable() && item.Visual.RayCast(ray, out var distance) && distance < num)
				{
					num = distance;
					result = item;
				}
			}
			if (DebugVars.EnableCorridorItemSelection.Value)
			{
				foreach (Room allRoom in _worldState.AllRooms)
				{
					foreach (RoomItem item2 in allRoom.FloorPlan.Items)
					{
						if (item2.IsSelectable() && !allRoom.Definition.UseBlueprintEditMode(item2.Definition) && item2.Visual.RayCast(ray, out var distance2) && distance2 < num)
						{
							num = distance2;
							result = item2;
						}
					}
				}
			}
			return result;
		}

		public void ShowInvalidItemBounds()
		{
			_sellItems.AddRange(_blueprintFloorPlan.ItemsToSell);
			_invalidItems.AddRange(_blueprintFloorPlan.InvalidItems);
			RoomItemAlgorithms.ShowSellItems(_sellItems);
			RoomItemAlgorithms.ShowItemBounds(_invalidItems);
		}

		public void HideInvalidItemBounds()
		{
			RoomItemAlgorithms.HideSellItems(_sellItems);
			RoomItemAlgorithms.HideItemBounds(_invalidItems);
			_sellItems.Clear();
			_invalidItems.Clear();
		}

		private void OnRoomItemPlaced(RoomItem roomItem, FloorPlan floorPlan)
		{
			HideInvalidItemBounds();
			_blueprintFloorPlan.Validate();
			ShowInvalidItemBounds();
		}

		private void OnCursorDeleteObject(ICursorSelectable cursorSelectable)
		{
			if (cursorSelectable is RoomItem)
			{
				RoomBuildingNavMesh roomBuildingNavMesh = ((_blueprintFloorPlan.HospitalMap == null) ? null : _buildingLogic.GetRoomBuildingNavMesh(_blueprintFloorPlan.HospitalMap));
				roomBuildingNavMesh?.RebuildFrom(_blueprintFloorPlan, _buildingLogic.CurrentBlueprintFloorPlan, _worldState.Anchor);
				HideInvalidItemBounds();
				_blueprintFloorPlan.Validate();
				ShowInvalidItemBounds();
				if (roomBuildingNavMesh != null)
				{
					_level.BuildingLogic.ReleaseRoomBuildingNavMesh();
				}
			}
		}

		private void OnBalanceUpdated(int newBalance)
		{
			bool canBeBuilt = _blueprintFloorPlan.CanBeBuilt;
			_blueprintFloorPlan.ValidateCanAfford();
			if (canBeBuilt != _blueprintFloorPlan.CanBeBuilt)
			{
				_floorPlanVisual.UpdateFromRoom(_blueprintFloorPlan);
				_buildEvents.OnRoomValidityChanged.InvokeSafe(_blueprintFloorPlan);
			}
		}
	}
}
