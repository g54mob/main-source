using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.Furnitures
{
	public class FurnitureBounds : MonoBehaviour
	{
		private Bounds _rendererBounds;

		private Bounds _mainBounds;

		private Bounds _gridBounds;

		private const float _sizeMargin = 0.98f;

		[SerializeField]
		private BoxCollider _wallPlacementCollider;

		[SerializeField]
		private LayerMask _layersToCheckOnGrid;

		[SerializeField]
		[Layer]
		private int _placementColliderLayer;

		private bool _checkingIntersections;

		private WallFurnitureDetection _wallFurnitureDetection;

		private bool _lastCanPlaceOnWall;

		private LayerMask _wallOnlyLayerMask;

		private LayerMask _wallWithoutLayerMask;

		[SerializeField]
		[ReadOnly]
		private List<BuildingWall> _wallsHangedOn = new List<BuildingWall>();

		[field: SerializeField]
		public Furniture Furniture { get; private set; }

		public Bounds GridBounds => _gridBounds;

		public bool IsIntersecting { get; private set; }

		[field: SerializeField]
		public BoxCollider SelectionCollider { get; private set; }

		[field: SerializeField]
		public BoxCollider PlacementCollider { get; private set; }

		[field: SerializeField]
		public SpriteRenderer FeedbackSpriteRenderer { get; private set; }

		public List<BuildingWall> WallsHangedOn => _wallsHangedOn;

		public PlacementFeedback PlacementFeedback { get; private set; }

		public event Action<bool> FurnitureIntersectionChanged;

		private void Awake()
		{
			_wallOnlyLayerMask = 1 << LayerMask.NameToLayer("Wall");
			_wallWithoutLayerMask = (int)_layersToCheckOnGrid & ~(int)_wallOnlyLayerMask;
			if (!Furniture)
			{
				Furniture = GetComponent<Furniture>();
			}
			_wallFurnitureDetection = GetComponentInChildren<WallFurnitureDetection>();
			if ((bool)_wallPlacementCollider)
			{
				_wallPlacementCollider.gameObject.SetActive(value: false);
			}
		}

		public bool IncorectPlacement(int? maskToNotTest = null)
		{
			if (!CheckIntersections(maskToNotTest))
			{
				return !CanPlaceOnWall();
			}
			return true;
		}

		private Bounds CalculateBounds(List<Renderer> p_renderers)
		{
			if (p_renderers.Count == 0)
			{
				return default(Bounds);
			}
			Bounds bounds = p_renderers[0].bounds;
			for (int i = 1; i < p_renderers.Count; i++)
			{
				bounds.Encapsulate(p_renderers[i].bounds);
			}
			return bounds;
		}

		public void SetupBounds(Renderer[] p_visuals, Renderer[] p_interactionZones)
		{
			List<Renderer> list = new List<Renderer>();
			list.AddRange(p_visuals);
			_rendererBounds = CalculateBounds(list);
			list.AddRange(p_interactionZones);
			if ((bool)PlacementCollider)
			{
				_mainBounds.center = PlacementCollider.center + base.transform.position;
				_mainBounds.size = PlacementCollider.size;
			}
			else
			{
				_mainBounds = CalculateBounds(list);
				_mainBounds.size *= 0.98f;
			}
			_gridBounds = _mainBounds;
			_gridBounds.center = _gridBounds.center.FlattenY() + (_mainBounds.extents - _gridBounds.extents).FlattenY();
			float x = ((_gridBounds.extents.x <= 0.25f) ? ((float)Mathf.CeilToInt(_gridBounds.max.x * 4f) * 0.25f) : ((float)Mathf.CeilToInt(_gridBounds.max.x * 2f) * 0.5f));
			float z = ((_gridBounds.extents.z <= 0.25f) ? ((float)Mathf.CeilToInt(_gridBounds.max.z * 4f) * 0.25f) : ((float)Mathf.CeilToInt(_gridBounds.max.z * 2f) * 0.5f));
			_gridBounds.max = new Vector3(x, 0f, z);
			float x2 = ((_gridBounds.extents.x <= 0.25f) ? ((float)Mathf.FloorToInt(_gridBounds.min.x * 4f) * 0.25f) : ((float)Mathf.FloorToInt(_gridBounds.min.x * 2f) * 0.5f));
			float z2 = ((_gridBounds.extents.z <= 0.25f) ? ((float)Mathf.FloorToInt(_gridBounds.min.z * 4f) * 0.25f) : ((float)Mathf.FloorToInt(_gridBounds.min.z * 2f) * 0.5f));
			_gridBounds.min = new Vector3(x2, 0f, z2);
			SetupColliders();
		}

		public void SetupColliders()
		{
			if (!SelectionCollider)
			{
				if (base.gameObject.TryGetComponent<BoxCollider>(out var component))
				{
					SelectionCollider = component;
				}
				else
				{
					SelectionCollider = base.gameObject.AddComponent<BoxCollider>();
					SelectionCollider.isTrigger = true;
					SelectionCollider.AutoSet(_rendererBounds);
				}
			}
			if (!PlacementCollider)
			{
				GameObject gameObject = new GameObject("PlacementCollider");
				gameObject.transform.parent = base.transform;
				PlacementCollider = gameObject.AddComponent<BoxCollider>();
				PlacementCollider.AutoSet(_mainBounds);
			}
			PlacementFeedback = PlacementCollider.gameObject.AddComponent<PlacementFeedback>();
			PlacementFeedback.Setup(FeedbackSpriteRenderer, PlacementCollider);
			PlacementFeedback.SetRenderers(GetComponentsInChildren<Renderer>());
			if ((bool)_wallPlacementCollider)
			{
				_wallPlacementCollider.gameObject.layer = _placementColliderLayer;
			}
			PlacementCollider.gameObject.layer = _placementColliderLayer;
			PlacementCollider.isTrigger = true;
		}

		public void EnablePlacementCheck()
		{
			_checkingIntersections = true;
			IsIntersecting = true;
			CheckIntersections();
		}

		public void DisablePlacementCheck()
		{
			_checkingIntersections = false;
			IsIntersecting = false;
			this.FurnitureIntersectionChanged?.Invoke(IsIntersecting);
		}

		private void Update()
		{
			if (_checkingIntersections)
			{
				CheckWall();
				CheckIntersections();
			}
		}

		public bool CouldBePlaced(Vector3 positionToCheck)
		{
			Collider[] results = PhysicsAllocation.Get(10);
			return Physics.OverlapBoxNonAlloc(positionToCheck + PlacementCollider.center, PlacementCollider.size * 0.5f, results, base.transform.rotation, _layersToCheckOnGrid, QueryTriggerInteraction.Collide) == 0;
		}

		public bool CouldBePlaced(FurnitureSlot furnitureSlotToCheck)
		{
			if (!furnitureSlotToCheck.isActiveAndEnabled)
			{
				return false;
			}
			if (furnitureSlotToCheck == Furniture.Controller.CurrentSlot)
			{
				return true;
			}
			using (new TemporaryMove(base.transform, furnitureSlotToCheck.transform))
			{
				using (new TemporaryColliderEnable(furnitureSlotToCheck.FurnitureController.Furniture.Bounds.PlacementCollider, isEnabled: false))
				{
					return !PlacementCollider.CheckPhysics(_layersToCheckOnGrid, QueryTriggerInteraction.Collide);
				}
			}
		}

		public bool CheckIntersections(int? maskToNotTest = null)
		{
			bool flag = false;
			PlacementCollider.enabled = false;
			FurnitureSlot[] slots = Furniture.Slots;
			foreach (FurnitureSlot furnitureSlot in slots)
			{
				if (furnitureSlot.isActiveAndEnabled && (bool)furnitureSlot.SlotedFurniture)
				{
					furnitureSlot.SlotedFurniture.Furniture.Bounds.PlacementCollider.enabled = false;
				}
			}
			int num = _wallWithoutLayerMask;
			int num2 = _wallOnlyLayerMask;
			int num3 = _layersToCheckOnGrid;
			if (maskToNotTest.HasValue)
			{
				num &= ~maskToNotTest.Value;
				num2 &= ~maskToNotTest.Value;
				num3 &= ~maskToNotTest.Value;
			}
			if ((bool)_wallPlacementCollider)
			{
				flag |= PlacementCollider.CheckPhysics(num, QueryTriggerInteraction.Collide);
				flag |= _wallPlacementCollider.CheckPhysics(num2, QueryTriggerInteraction.Collide);
			}
			else
			{
				flag = PlacementCollider.CheckPhysics(num3, QueryTriggerInteraction.Collide);
			}
			if (!flag)
			{
				slots = Furniture.Slots;
				foreach (FurnitureSlot furnitureSlot2 in slots)
				{
					if (furnitureSlot2.isActiveAndEnabled && (bool)furnitureSlot2.SlotedFurniture)
					{
						flag = furnitureSlot2.SlotedFurniture.Furniture.Bounds.PlacementCollider.CheckPhysics(num3, QueryTriggerInteraction.Collide);
						if (flag)
						{
							break;
						}
					}
				}
			}
			else
			{
				Collider[] array = PhysicsAllocation.Get(10);
				int num4 = PlacementCollider.OverlapNonAlloc(array, num3);
				for (int j = 0; j < num4; j++)
				{
					if (array[j].TryGetComponent<PlacementFeedback>(out var component))
					{
						MonoSingleton<PlacementFeedbackManager>.Instance.AddToList(component);
					}
				}
			}
			PlacementCollider.enabled = true;
			slots = Furniture.Slots;
			foreach (FurnitureSlot furnitureSlot3 in slots)
			{
				if (furnitureSlot3.isActiveAndEnabled && (bool)furnitureSlot3.SlotedFurniture)
				{
					furnitureSlot3.SlotedFurniture.Furniture.Bounds.PlacementCollider.enabled = true;
				}
			}
			if (flag != IsIntersecting)
			{
				IsIntersecting = flag;
				this.FurnitureIntersectionChanged?.Invoke(IsIntersecting);
			}
			return IsIntersecting;
		}

		public void CheckWall()
		{
			bool flag = CanPlaceOnWall();
			if (flag != _lastCanPlaceOnWall)
			{
				_lastCanPlaceOnWall = flag;
				this.FurnitureIntersectionChanged?.Invoke(IsIntersecting);
			}
		}

		public bool CanPlaceOnWall()
		{
			if (_wallFurnitureDetection == null)
			{
				return true;
			}
			if (!_wallFurnitureDetection.TryGetWalls(out _wallsHangedOn))
			{
				return false;
			}
			return true;
		}
	}
}
