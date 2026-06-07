using System.Collections.Generic;
using ScheduleOne.EntityFramework;
using ScheduleOne.ItemFramework;
using ScheduleOne.Property;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Building
{
	public class BuildUpdate_Grid : BuildUpdate_Base
	{
		[Header("Settings")]
		public float detectionRange;

		public LayerMask detectionMask;

		public float rotation_Smoothing;

		public bool AllowRotation;

		[SerializeField]
		[Header("Temperature")]
		private bool showTemperaturesByDefault;

		[SerializeField]
		private bool allowToggleShowTemperatures;

		protected bool _validPosition;

		protected Material _currentGhostMaterial;

		protected float _rotation;

		private TileIntersection _closestIntersection;

		private float verticalOffset;

		protected bool _showTemperatures;

		public GameObject GhostModel { get; private set; }

		public GridItem BuildableItemClass { get; private set; }

		public ItemInstance ItemInstance { get; private set; }

		public bool AllowToggleShowTemperatures => false;

		protected TileIntersection closestIntersection
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual void Initialize(GridItem buildableItemClass, ItemInstance itemInstance, GameObject ghostModel)
		{
		}

		protected virtual void Start()
		{
		}

		protected virtual void Update()
		{
		}

		private void CheckToggleTemperatureDisplay()
		{
		}

		protected virtual void LateUpdate()
		{
		}

		protected void PositionObjectInFrontOfPlayer(float dist, bool sanitizeForward, bool buildPointAsOrigin)
		{
		}

		protected void CheckRotation()
		{
		}

		protected void ApplyRotation()
		{
		}

		private List<TileIntersection> GetRelevantIntersections(FootprintTile tile)
		{
			return null;
		}

		protected virtual void CheckIntersections()
		{
		}

		protected void UpdateMaterials()
		{
		}

		protected virtual GridItem Place()
		{
			return null;
		}

		protected virtual void OnPlacedObjectPreSpawn(GridItem item)
		{
		}

		protected virtual void OnClosestIntersectionChanged(TileIntersection previous, TileIntersection current)
		{
		}

		protected virtual void SetShowTemperatures(bool show, ScheduleOne.Property.Property property)
		{
		}

		private Vector2 GetOriginCoordinate()
		{
			return default(Vector2);
		}

		private Grid GetHoveredGrid()
		{
			return null;
		}
	}
}
