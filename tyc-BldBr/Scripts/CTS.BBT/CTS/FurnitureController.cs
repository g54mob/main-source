using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using CTS.Furnitures;
using CTS.GridSystem;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	[DefaultExecutionOrder(-1)]
	public class FurnitureController : CTSBehaviour
	{
		[SerializeField]
		private bool _autoGetRenderersForOutline = true;

		[SerializeField]
		[Layer]
		private int _ghostLayer;

		[SerializeField]
		[Layer]
		private int _furnitureLayer;

		[SerializeField]
		private GridRenderer _gridRenderer;

		[SerializeField]
		private SelectionModes _pickUpSelectionModes;

		[SerializeField]
		public bool NeedSlot;

		private readonly Dictionary<Renderer, Color> _originalColors = new Dictionary<Renderer, Color>();

		private Quaternion _previousPlacedRotation;

		private Quaternion _previousManualRotation;

		private FurnitureSlot _previousFurnitureSlot;

		private RoomBuilding _previousRoom;

		[Inject(false)]
		private BarVisualObject _barVisualObject;

		private WallFurnitureDetection _wallFurnitureDetection;

		private static readonly int _shaderBaseColor = Shader.PropertyToID("_BaseColor");

		[field: SerializeField]
		public Furniture Furniture { get; private set; }

		[field: SerializeField]
		[field: Required(null)]
		public Transform VisualContainer { get; private set; }

		[field: SerializeField]
		[field: Required(null)]
		public Transform InteractionZoneContainer { get; private set; }

		public GridLayer CurrentGridLayer { get; private set; }

		public Renderer[] Renderers { get; private set; } = Array.Empty<Renderer>();

		public Renderer[] InteractionZoneRenderers { get; private set; } = Array.Empty<Renderer>();

		public bool IsPlaced { get; private set; } = true;

		public bool IsPlacable
		{
			get
			{
				if (!IsPlaced && !Furniture.Bounds.IsIntersecting)
				{
					return Furniture.Bounds.CanPlaceOnWall();
				}
				return false;
			}
		}

		public FurnitureSlot CurrentSlot { get; private set; }

		public Vector3 PreviousPlacedPosition { get; private set; }

		[field: InjectScope(EGetScope.Children)]
		[field: Inject(false)]
		public NavMeshObstacle[] NavMeshObstacle { get; }

		public PlacementFeedback PlacementFeedback => Furniture.Bounds.PlacementFeedback;

		public static event Action<FurnitureController> FurniturePickedUp;

		public static event Action<FurnitureController> PlacingFurniture;

		public static event Action<FurnitureController> StaticFurniturePlaced;

		public static event Action<FurnitureController> FurniturePlacedInSlot;

		public static event Action<bool> Rotating;

		public event Action<bool> FurniturePlaced;

		public event Action<bool> PlacementChanged;

		public event Action<FurnitureSlot> OnSlot;

		protected override void OnAwake()
		{
			base.OnAwake();
			if (Furniture == null)
			{
				Furniture = GetComponent<Furniture>();
			}
			FurnitureSetup();
			_wallFurnitureDetection = GetComponentInChildren<WallFurnitureDetection>();
			Renderer[] renderers = Renderers;
			foreach (Renderer renderer in renderers)
			{
				if (renderer.sharedMaterial.HasProperty(_shaderBaseColor))
				{
					_originalColors[renderer] = renderer.sharedMaterial.GetColor(_shaderBaseColor);
				}
			}
		}

		protected override void OnEnabled()
		{
			if (_wallFurnitureDetection != null)
			{
				_wallFurnitureDetection.OnWallChanged += OnWallChanged;
			}
			Furniture.RoomObject.CurrentRoomChanged += OnRoomChanged;
			Furniture.Bounds.CheckIntersections();
			Furniture.Bounds.FurnitureIntersectionChanged += OnFurnitureIntersectionChanged;
		}

		protected override void OnDisabled()
		{
			Furniture.RoomObject.CurrentRoomChanged -= OnRoomChanged;
			if ((bool)Furniture.SelectableObject)
			{
				Furniture.SelectableObject.Selected -= OnFurnitureSelected;
			}
			if (_wallFurnitureDetection != null)
			{
				_wallFurnitureDetection.OnWallChanged -= OnWallChanged;
			}
			Furniture.Bounds.FurnitureIntersectionChanged -= OnFurnitureIntersectionChanged;
			if (base.gameObject.scene.isLoaded)
			{
				LeaveSlot();
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void FurnitureSetup()
		{
			if ((bool)VisualContainer)
			{
				Renderers = VisualContainer.GetComponentsInChildren<Renderer>();
			}
			if ((bool)InteractionZoneContainer)
			{
				InteractionZoneRenderers = InteractionZoneContainer.GetComponentsInChildren<Renderer>();
			}
			Renderer[] interactionZoneRenderers = InteractionZoneRenderers;
			for (int i = 0; i < interactionZoneRenderers.Length; i++)
			{
				interactionZoneRenderers[i].gameObject.SetActive(value: false);
			}
			using (new TemporaryMove(base.transform, Vector3.zero, Quaternion.identity))
			{
				Furniture.Bounds.SetupBounds(Renderers, InteractionZoneRenderers);
			}
			NavMeshObstacle[] navMeshObstacle = NavMeshObstacle;
			for (int i = 0; i < navMeshObstacle.Length; i++)
			{
				navMeshObstacle[i].carvingTimeToStationary = 0f;
			}
		}

		private void OnWallChanged(bool _)
		{
			RefreshColors();
		}

		public void SetupFromShop()
		{
			IsPlaced = false;
			Furniture.Bounds.CheckIntersections();
			OnFurnitureIntersectionChanged(Furniture.Bounds.IsIntersecting);
		}

		public void SetupSelectableObject()
		{
			if (!Furniture.OutlineRenderers)
			{
				Furniture.OutlineRenderers = GetComponent<OutlineRendererCollection>();
			}
			if (!Furniture.SelectableObject)
			{
				Furniture.SelectableObject = GetComponent<SelectableObject>();
			}
			if ((bool)Furniture.SelectableObject)
			{
				Furniture.SelectableObject.Selected -= OnFurnitureSelected;
				Furniture.SelectableObject.Selected += OnFurnitureSelected;
			}
			if (Furniture.Parameters.CanBeUseByPlayer && (bool)Furniture.OutlineRenderers && _autoGetRenderersForOutline)
			{
				Furniture.OutlineRenderers.SetRenderers(Renderers);
			}
		}

		private void OnFurnitureSelected(SelectionMode selectionMode)
		{
			if (_pickUpSelectionModes.CanBeSelectedBy(selectionMode) && Furniture.Parameters.CanBeUseByPlayer)
			{
				PickUpFurniture();
			}
		}

		private void OnFurnitureIntersectionChanged(bool p_isIntersecting)
		{
			RefreshColors();
		}

		public void RefreshColors()
		{
			bool flag = true;
			if (MonoSingleton<MoneyHandler>.InstanceExists() && (object)Furniture.Parameters != null)
			{
				flag = Furniture.Purchased || Furniture.Parameters.PurchasePrice <= 0 || MonoSingleton<MoneyHandler>.Instance.CurrentMoney >= Furniture.Parameters.PurchasePrice;
			}
			bool flag2 = Furniture.Bounds.IsIntersecting || (MonoSingleton<FurniturePlacer>.InstanceExists() && !MonoSingleton<FurniturePlacer>.Instance.HasValidPosition) || (_wallFurnitureDetection != null && !_wallFurnitureDetection.OnWall) || !flag;
			if (FurnitureShop.IsClosed)
			{
				return;
			}
			if (IsPlaced)
			{
				ChangeVisualsParameters(flag2 ? new Color?(FurniturePlacer.InvalidPlacementColor) : ((Color?)null));
			}
			else if (!CurrentSlot)
			{
				if (flag2 || (object)Furniture.RoomObject.CurrentRoom == null || Furniture.RoomObject.CurrentRoom.RoomIndex == 0 || !Furniture.Bounds.CanPlaceOnWall())
				{
					ChangeVisualsParameters(FurniturePlacer.InvalidPlacementColor, flag2 ? new Color?(Color.red) : ((Color?)null));
				}
				else
				{
					ChangeVisualsParameters(FurniturePlacer.ValidPlacementColor);
				}
			}
		}

		private void OnRoomChanged()
		{
			OnFurnitureIntersectionChanged(Furniture.Bounds.IsIntersecting);
		}

		public void ChangeVisualsParameters(Color? p_gridColor = null, Color? p_materialsColor = null)
		{
			if (!p_materialsColor.HasValue)
			{
				Renderer[] renderers = Renderers;
				foreach (Renderer renderer in renderers)
				{
					if (_originalColors.TryGetValue(renderer, out var value))
					{
						renderer.material.SetColor(_shaderBaseColor, value);
					}
				}
			}
			else
			{
				Renderer[] renderers = Renderers;
				for (int i = 0; i < renderers.Length; i++)
				{
					renderers[i].material.SetColor(_shaderBaseColor, p_materialsColor.Value);
				}
			}
			PlacementFeedback.Show(p_gridColor.HasValue);
			if (p_gridColor.HasValue)
			{
				PlacementFeedback.SetColor(p_gridColor.Value);
			}
			FurnitureSlot[] slots = Furniture.Slots;
			foreach (FurnitureSlot furnitureSlot in slots)
			{
				if ((bool)furnitureSlot.SlotedFurniture)
				{
					furnitureSlot.SlotedFurniture.ChangeVisualsParameters(p_gridColor, p_materialsColor);
				}
			}
		}

		private void PickUpFurniture()
		{
			IsPlaced = false;
			base.gameObject.layer = _ghostLayer;
			NavMeshObstacle[] navMeshObstacle = NavMeshObstacle;
			for (int i = 0; i < navMeshObstacle.Length; i++)
			{
				navMeshObstacle[i].enabled = false;
			}
			Furniture.Bounds.EnablePlacementCheck();
			PlacementFeedback.Show(show: true);
			ShowSlottedFurnitureGrid(show: true);
			MonoSingleton<FurniturePlacer>.Instance.OnFurniturePickedUp(this);
			if (!(MonoSingleton<FurniturePlacer>.Instance.CurrentPickedUpFurniture != Furniture))
			{
				this.PlacementChanged?.Invoke(obj: false);
				FurnitureController.FurniturePickedUp?.Invoke(this);
			}
		}

		private void ShowSlottedFurnitureGrid(bool show)
		{
			FurnitureSlot[] slots = Furniture.Slots;
			foreach (FurnitureSlot furnitureSlot in slots)
			{
				if ((bool)furnitureSlot.SlotedFurniture)
				{
					furnitureSlot.SlotedFurniture._gridRenderer?.ShowGrid(show);
				}
			}
		}

		public void PlaceFurniture(bool buyIt)
		{
			FurnitureController.PlacingFurniture?.Invoke(this);
			if ((bool)CurrentSlot)
			{
				CurrentSlot.FurnitureController.ChangeVisualsParameters();
				CurrentSlot.SetSlotedFurniture(this);
				_previousFurnitureSlot = CurrentSlot;
			}
			ShowSlottedFurnitureGrid(show: false);
			SetupFurnitureInPlace();
			NavMeshObstacle[] navMeshObstacle = NavMeshObstacle;
			for (int i = 0; i < navMeshObstacle.Length; i++)
			{
				navMeshObstacle[i].enabled = true;
			}
			base.transform.GetChild(0).DOShakeScale(0.1f, 0.3f).SetUpdate(isIndependentUpdate: true);
			this.PlacementChanged?.Invoke(obj: true);
			this.FurniturePlaced?.Invoke(buyIt);
			FurnitureController.StaticFurniturePlaced?.Invoke(this);
		}

		public void SetupFurnitureInPlace()
		{
			base.gameObject.layer = _furnitureLayer;
			IsPlaced = true;
			Furniture.Bounds.DisablePlacementCheck();
			Physics.SyncTransforms();
			PlacementFeedback.Show(show: false);
			SetPreviousData();
		}

		public void SetPreviousData()
		{
			if ((bool)Furniture && (bool)Furniture.RoomObject)
			{
				_previousRoom = Furniture.RoomObject.CurrentRoom;
			}
			PreviousPlacedPosition = base.transform.position;
			_previousPlacedRotation = base.transform.rotation;
			_previousManualRotation = _previousPlacedRotation;
		}

		public void CancelPickUp()
		{
			base.transform.position = PreviousPlacedPosition;
			base.transform.rotation = _previousPlacedRotation;
			_previousManualRotation = _previousPlacedRotation;
			ChangeVisualsParameters();
			if (_previousRoom != Furniture.RoomObject.CurrentRoom)
			{
				Furniture.RoomObject.CurrentRoom = _previousRoom;
			}
			if ((bool)_previousFurnitureSlot)
			{
				MoveToSlot(_previousFurnitureSlot);
			}
			PlaceFurniture(buyIt: true);
		}

		public void RotateFurniture(float p_angle, bool playSound)
		{
			if (!CurrentSlot)
			{
				FurnitureController.Rotating?.Invoke(playSound);
				base.transform.RotateAround(base.transform.position, Vector3.up, p_angle);
				_previousManualRotation = base.transform.rotation;
			}
		}

		public void CopyPositionValues(Furniture furnitureToCopy)
		{
			if (!furnitureToCopy.Controller.CurrentSlot)
			{
				base.transform.SetPositionAndRotation(furnitureToCopy.transform.position, furnitureToCopy.transform.rotation);
				PreviousPlacedPosition = furnitureToCopy.transform.position;
				_previousPlacedRotation = furnitureToCopy.transform.rotation;
				_previousManualRotation = furnitureToCopy.transform.rotation;
			}
			Furniture.RoomObject.CurrentRoom = furnitureToCopy.RoomObject.CurrentRoom;
			_previousRoom = furnitureToCopy.RoomObject.CurrentRoom;
		}

		public void SetInSlot(FurnitureSlot newSlot, bool skipVerification)
		{
			if (CurrentSlot != null)
			{
				CurrentSlot.SetSlotedFurniture(null);
			}
			if (skipVerification)
			{
				if ((bool)CurrentSlot)
				{
					CurrentSlot.FurnitureController.PlacementFeedback.RemoveChild(PlacementFeedback);
				}
				CurrentSlot = newSlot;
				_previousFurnitureSlot = CurrentSlot;
				CurrentSlot?.SetSlotedFurniture(this);
				CurrentSlot?.FurnitureController.PlacementFeedback.AddChild(PlacementFeedback);
				Furniture.Bounds.DisablePlacementCheck();
				Furniture.MarkAsBought();
				MoveToSlot(CurrentSlot);
				_previousRoom = Furniture.RoomObject.CurrentRoom;
			}
			else if (!(CurrentSlot == newSlot) && newSlot.IsActiveAndFree)
			{
				ChangeVisualsParameters(FurniturePlacer.SlotPlacementColor);
				if ((bool)CurrentSlot)
				{
					CurrentSlot.FurnitureController.ChangeVisualsParameters();
					CurrentSlot.FurnitureController.PlacementFeedback.RemoveChild(PlacementFeedback);
				}
				CurrentSlot = newSlot;
				if ((bool)CurrentSlot)
				{
					CurrentSlot.SetSlotedFurniture(null);
					CurrentSlot.FurnitureController.ChangeVisualsParameters(FurniturePlacer.SlotPlacementColor);
					CurrentSlot.FurnitureController.PlacementFeedback.AddChild(PlacementFeedback);
					Furniture.Bounds.DisablePlacementCheck();
					MoveToSlot(CurrentSlot);
					FurnitureController.FurniturePlacedInSlot?.Invoke(this);
				}
			}
		}

		private void MoveToSlot(FurnitureSlot slot)
		{
			if ((bool)slot)
			{
				base.transform.SetPositionAndRotation(slot.transform.position, slot.transform.rotation);
				Furniture.RoomObject.CurrentRoom = slot.CurrentRoom;
				base.transform.parent = slot.transform;
				this.OnSlot?.Invoke(slot);
			}
		}

		public void LeaveSlot()
		{
			base.transform.rotation = _previousManualRotation;
			Furniture.Bounds.EnablePlacementCheck();
			RefreshColors();
			if ((bool)CurrentSlot)
			{
				CurrentSlot.SetSlotedFurniture(null);
				CurrentSlot.FurnitureController.ChangeVisualsParameters();
				CurrentSlot.FurnitureController.PlacementFeedback.RemoveChild(PlacementFeedback);
				CurrentSlot = null;
				if (base.enabled)
				{
					base.transform.parent = null;
				}
				this.OnSlot?.Invoke(null);
			}
		}
	}
}
