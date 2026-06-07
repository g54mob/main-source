using System;
using CTS.BBT;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.GridSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS.Furnitures
{
	[DefaultExecutionOrder(-2)]
	public class FurniturePlacer : MonoSingleton<FurniturePlacer>
	{
		[Tooltip("The number of degree an object rotate with each player input - Best to leave it to 90 multiples")]
		[SerializeField]
		private int _rotationAngle = 90;

		[SerializeField]
		private LayerMask _furnitureLayerMask;

		[SerializeField]
		private LayerMask _gridsLayerMask;

		[SerializeField]
		private Color _validPlacementColor = Color.green;

		[SerializeField]
		private Color _invalidPlacementColor = Color.red;

		[SerializeField]
		private Color _slotPlacementColor = Color.blue;

		[SerializeField]
		private InputActionReference _pickerInput;

		[SerializeField]
		private float _raycastMaxDistance = 30f;

		private bool _checkedThisFrame;

		public static Color ValidPlacementColor { get; private set; } = Color.green;

		public static Color InvalidPlacementColor { get; private set; } = Color.red;

		public static Color SlotPlacementColor { get; private set; } = Color.blue;

		public static bool PlaceAnywhere { get; set; } = false;

		public static bool PlacedSomethingThisFrame { get; private set; }

		public Furniture CurrentPickedUpFurniture { get; private set; }

		private bool _hasEnoughMoney
		{
			get
			{
				if ((bool)CurrentPickedUpFurniture)
				{
					return MonoSingleton<MoneyHandler>.Instance.CurrentMoney >= CurrentPickedUpFurniture.Parameters.PurchasePrice;
				}
				return true;
			}
		}

		public bool HasValidPosition { get; private set; }

		public event Action<bool> OnValidPositionChanged;

		public static event Action<Furniture> FurniturePickedUp;

		public static event Action SpawningFurniture;

		protected override void SingletonAwake()
		{
			UpdateColors();
			PlacedSomethingThisFrame = false;
			MapEditor.PlaceFurnitureFromSave += PlaceFurnitureFromMapEditorSaveFile;
		}

		protected override void OnSingletonDestroy()
		{
			MapEditor.PlaceFurnitureFromSave -= PlaceFurnitureFromMapEditorSaveFile;
		}

		private void UpdateColors()
		{
			ValidPlacementColor = _validPlacementColor;
			InvalidPlacementColor = _invalidPlacementColor;
			SlotPlacementColor = _slotPlacementColor;
		}

		private void OnEnable()
		{
			_pickerInput.action.performed += OnPickupAction;
			FloorsManager.ChangingFloor += OnLayerChanged;
			FurnitureShopInputsObserver.PlaceInputPressed += TryPlaceFurniture;
			FurnitureShopInputsObserver.RotateClockwiseInputPressed += RotateClockwise;
			FurnitureShopInputsObserver.RotateCounterClockwiseInputPressed += RotateCounterClockwise;
			UIFurnitureSellButton.FurnitureSellButtonClicked += SellPickedUpFurniture;
			FurnitureShop.FurnitureShopClosed += CancelPlacement;
		}

		private void OnDisable()
		{
			_pickerInput.action.performed -= OnPickupAction;
			FloorsManager.ChangingFloor -= OnLayerChanged;
			FurnitureShopInputsObserver.PlaceInputPressed -= TryPlaceFurniture;
			FurnitureShopInputsObserver.RotateClockwiseInputPressed -= RotateClockwise;
			FurnitureShopInputsObserver.RotateCounterClockwiseInputPressed -= RotateCounterClockwise;
			UIFurnitureSellButton.FurnitureSellButtonClicked -= SellPickedUpFurniture;
			FurnitureShop.FurnitureShopClosed -= CancelPlacement;
		}

		private void OnPickupAction(InputAction.CallbackContext obj)
		{
			if (!CurrentPickedUpFurniture && !FurnitureShop.IsClosed)
			{
				Furniture hovered = WorldSelector.GetHovered<Furniture>();
				if ((bool)hovered && hovered.Parameters.CanBeUseByPlayer)
				{
					TryDuplicate(hovered);
				}
			}
		}

		private Furniture SpawnFurniture(FurnitureSO furnitureToSpawn)
		{
			Vector3 position = ((FloorsManager.CurrentFloor != null) ? FloorsManager.CurrentFloor.GetClosestVerticeOnFloorGrid(CameraUtilities.GetMouseWorldPositionXZ(Camera.main, CameraUtilities.GetDistanceFromCam(Camera.main, Vector3.zero))) : Vector3.zero);
			return UnityEngine.Object.Instantiate(furnitureToSpawn.Prefab, position, Quaternion.identity, MonoSingleton<ParentFurnitures>.Instance.transform);
		}

		private void SpawnFurnitureAndPickUp(FurnitureSO furnitureToSpawn)
		{
			if (furnitureToSpawn.CanBeUseByPlayer)
			{
				FurniturePlacer.SpawningFurniture?.Invoke();
				Furniture furniture = SpawnFurniture(furnitureToSpawn);
				furniture.SetFurnitureSO(furnitureToSpawn);
				furniture.Controller.SetupFromShop();
				PlacedSomethingThisFrame = true;
				WorldSelector.SelectObject(furniture.SelectableObject, allowMultiple: false, bypassMode: true);
			}
		}

		public void StartPlacement(FurnitureSO furnitureSO)
		{
			if ((bool)CurrentPickedUpFurniture)
			{
				if (CurrentPickedUpFurniture.Parameters == furnitureSO)
				{
					return;
				}
				CancelPlacement();
			}
			SpawnFurnitureAndPickUp(furnitureSO);
		}

		public void OnFurniturePickedUp(FurnitureController p_pickedUpFurnitureController)
		{
			CurrentPickedUpFurniture = p_pickedUpFurnitureController.Furniture;
			FurniturePlacer.FurniturePickedUp?.Invoke(CurrentPickedUpFurniture);
		}

		private void TryPlaceFurniture()
		{
			if (!PlacedSomethingThisFrame && FurnitureShop.IsOpen && !WorldSelector.PointerIsOverUI && (bool)CurrentPickedUpFurniture && HasValidPosition && (CurrentPickedUpFurniture.Purchased || _hasEnoughMoney) && (PlaceAnywhere || CurrentPickedUpFurniture.Controller.IsPlacable))
			{
				PlacedSomethingThisFrame = true;
				PlaceFurniture();
			}
		}

		private void PlaceFurnitureFromMapEditorSaveFile(FurnitureSaveStruct furnitureSaveStruct)
		{
			if (!FurnitureLoader.TryGetFurniture(furnitureSaveStruct.furnitureName, out var furnitureData))
			{
				return;
			}
			Furniture furniture = CTSFactory.Instantiate(furnitureData.Prefab, furnitureSaveStruct.positionFurnitures, furnitureSaveStruct.rotationFurnitures, MonoSingleton<ParentFurnitures>.Instance.transform, false);
			furniture.SetFurnitureSO(furnitureData);
			furniture.gameObject.SetActive(value: true);
			furniture.Controller.SetupSelectableObject();
			furniture.Controller.PlaceFurniture(buyIt: false);
			if ((bool)furniture.Interactor)
			{
				furniture.Interactor.OnFurniturePlaced();
			}
			for (int i = 0; i < furnitureSaveStruct.slotedFurniture.Length; i++)
			{
				if (FurnitureLoader.TryGetFurniture(furnitureSaveStruct.slotedFurniture[i].furnitureName, out var furnitureData2))
				{
					Furniture furniture2 = UnityEngine.Object.Instantiate(furnitureData2.Prefab, furnitureSaveStruct.slotedFurniture[i].positionFurnitures, furnitureSaveStruct.slotedFurniture[i].rotationFurnitures, MonoSingleton<ParentFurnitures>.Instance.transform);
					furniture2.SetFurnitureSO(furnitureData2);
					FurnitureSlot closestFreeSlot = furniture.GetClosestFreeSlot(furnitureSaveStruct.slotedFurniture[i].positionFurnitures);
					furniture2.Controller.SetInSlot(closestFreeSlot, skipVerification: true);
					if ((bool)furniture2.Interactor)
					{
						furniture2.Interactor.OnFurniturePlaced();
					}
				}
			}
		}

		private void PlaceFurniture()
		{
			if ((bool)CurrentPickedUpFurniture)
			{
				Furniture currentPickedUpFurniture = CurrentPickedUpFurniture;
				CurrentPickedUpFurniture = null;
				bool purchased = currentPickedUpFurniture.Purchased;
				currentPickedUpFurniture.Controller.PlaceFurniture(buyIt: true);
				FurniturePlacer.FurniturePickedUp?.Invoke(null);
				WorldSelector.Deselect(currentPickedUpFurniture.SelectableObject);
				if (InputManager.game.build.duplicate.InProgress() && !purchased)
				{
					TryDuplicate(currentPickedUpFurniture);
				}
			}
		}

		private bool TryDuplicate(Furniture furnitureToDuplicate)
		{
			if (MonoSingleton<MoneyHandler>.Instance.CurrentMoney - furnitureToDuplicate.Parameters.PurchasePrice < 0)
			{
				return false;
			}
			SpawnFurnitureAndPickUp(furnitureToDuplicate.Parameters);
			CurrentPickedUpFurniture.Controller.CopyPositionValues(furnitureToDuplicate);
			PlacePickedUpFurnitureByMouse();
			return true;
		}

		private void SellPickedUpFurniture()
		{
			if ((bool)CurrentPickedUpFurniture && CurrentPickedUpFurniture.Purchased)
			{
				CurrentPickedUpFurniture.SellFurniture();
				CancelPlacement();
			}
		}

		private void CancelPlacement()
		{
			if ((bool)CurrentPickedUpFurniture)
			{
				CurrentPickedUpFurniture.Controller.LeaveSlot();
				WorldSelector.Deselect(CurrentPickedUpFurniture.SelectableObject);
				if (CurrentPickedUpFurniture.Purchased)
				{
					CurrentPickedUpFurniture.Controller.CancelPickUp();
				}
				else
				{
					CurrentPickedUpFurniture.Controller.ChangeVisualsParameters();
					UnityEngine.Object.Destroy(CurrentPickedUpFurniture.gameObject);
				}
				CurrentPickedUpFurniture = null;
				FurniturePlacer.FurniturePickedUp?.Invoke(null);
			}
		}

		public bool TryCancelPlacement()
		{
			if (!CurrentPickedUpFurniture)
			{
				return false;
			}
			CancelPlacement();
			return true;
		}

		private void RotateClockwise()
		{
			if ((bool)CurrentPickedUpFurniture)
			{
				CurrentPickedUpFurniture.Controller.RotateFurniture(_rotationAngle, playSound: true);
			}
		}

		private void RotateCounterClockwise()
		{
			if ((bool)CurrentPickedUpFurniture)
			{
				CurrentPickedUpFurniture.Controller.RotateFurniture(-_rotationAngle, playSound: true);
			}
		}

		public void RotateClockwiseNoSound()
		{
			if ((bool)CurrentPickedUpFurniture)
			{
				CurrentPickedUpFurniture.Controller.RotateFurniture(_rotationAngle, playSound: false);
			}
		}

		private void OnLayerChanged(Floor p_floor)
		{
			if ((bool)CurrentPickedUpFurniture)
			{
				CurrentPickedUpFurniture.transform.position = p_floor.GetClosestVerticeOnFloorGrid(CurrentPickedUpFurniture.transform.position);
			}
		}

		private bool TryGetFurnitureSlot(out FurnitureSlot furnitureSlot)
		{
			furnitureSlot = null;
			bool flag = false;
			RaycastHit hitInfo;
			using (new TemporaryColliderEnable(CurrentPickedUpFurniture.Bounds.PlacementCollider, isEnabled: false))
			{
				flag = Physics.Raycast(MainCamera.CameraReference.ScreenPointToRay(Input.mousePosition), out hitInfo, _raycastMaxDistance, (int)_furnitureLayerMask | (1 << LayerMask.NameToLayer("FurnitureSlot")));
			}
			if (!flag)
			{
				return false;
			}
			if (hitInfo.collider.TryGetComponent<FurnitureSlot>(out furnitureSlot))
			{
				if (CurrentPickedUpFurniture.Bounds.CouldBePlaced(furnitureSlot))
				{
					return true;
				}
				furnitureSlot = null;
			}
			if (hitInfo.collider.TryGetComponent<Furniture>(out var component))
			{
				furnitureSlot = component.GetClosestAvailableSlot(hitInfo.point, CurrentPickedUpFurniture);
			}
			return furnitureSlot;
		}

		private bool TryPlaceInFurnitureSlot(FurnitureSlot furnitureSlot)
		{
			if (!furnitureSlot)
			{
				return false;
			}
			if (!furnitureSlot.IsActiveAndFree || !CurrentPickedUpFurniture.Parameters.Tags.HasFlagNonAlloc(furnitureSlot.CompatibleTags))
			{
				return false;
			}
			CurrentPickedUpFurniture.Controller.SetInSlot(furnitureSlot, skipVerification: false);
			return true;
		}

		private bool PlaceOnGrid()
		{
			if (Physics.Raycast(MainCamera.CameraReference.ScreenPointToRay(Input.mousePosition), out var hitInfo, _raycastMaxDistance, _gridsLayerMask))
			{
				if (!hitInfo.transform.TryGetComponent<GridController>(out var component))
				{
					return false;
				}
				CurrentPickedUpFurniture.Move(InputManager.game.build.gridplacement.InProgress() ? hitInfo.point : component.GetClosestVerticeOnGrid(hitInfo.point));
				return true;
			}
			return false;
		}

		private void Update()
		{
			if ((bool)MainCamera.CameraReference && (bool)CurrentPickedUpFurniture && !WorldSelector.PointerIsOverUI)
			{
				PlacePickedUpFurnitureByMouse();
			}
		}

		private void LateUpdate()
		{
			_checkedThisFrame = false;
			PlacedSomethingThisFrame = false;
		}

		private void PlacePickedUpFurnitureByMouse()
		{
			if (_checkedThisFrame)
			{
				return;
			}
			_checkedThisFrame = true;
			bool newHasValidPosition = false;
			if (!TryPlaceInSlot())
			{
				if ((bool)CurrentPickedUpFurniture.Controller.CurrentSlot)
				{
					CurrentPickedUpFurniture.Controller.LeaveSlot();
				}
				newHasValidPosition = PlaceOnGrid() && CanBePlaceOnCurrentRoom();
				if (CurrentPickedUpFurniture.Controller.NeedSlot)
				{
					newHasValidPosition = false;
				}
				if (newHasValidPosition != HasValidPosition)
				{
					HasValidPosition = newHasValidPosition;
					CurrentPickedUpFurniture.Controller.RefreshColors();
					this.OnValidPositionChanged?.Invoke(HasValidPosition);
				}
			}
			bool TryPlaceInSlot()
			{
				if (TryGetFurnitureSlot(out var furnitureSlot))
				{
					if (furnitureSlot == CurrentPickedUpFurniture.Controller.CurrentSlot)
					{
						return true;
					}
					newHasValidPosition = TryPlaceInFurnitureSlot(furnitureSlot);
					if (newHasValidPosition)
					{
						HasValidPosition = true;
						CurrentPickedUpFurniture.Controller.RefreshColors();
						this.OnValidPositionChanged?.Invoke(HasValidPosition);
						return true;
					}
				}
				return false;
			}
		}

		public bool CanBePlaceOnCurrentRoom()
		{
			return CanBePlaceOnCurrentRoom(CurrentPickedUpFurniture);
		}

		public static bool CanBePlaceOnCurrentRoom(Furniture furniture)
		{
			if (!RoomBuilding.TryGetRoomAt(furniture.transform.position, out var room))
			{
				return false;
			}
			switch (furniture.Parameters.Posable)
			{
			case EPose.ExteriorOnly:
				if (room.RoomIndex != 0)
				{
					return false;
				}
				break;
			case EPose.InteriorOnly:
				if (room.RoomIndex == 0)
				{
					return false;
				}
				break;
			}
			return true;
		}
	}
}
