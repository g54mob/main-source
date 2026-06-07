using Property;
using UnityEngine;

namespace Brewery.Items
{
	[CreateAssetMenu(fileName = "Furniture_New", menuName = "Brewery/Items/Furniture")]
	public class FurnitureData : PlaceableItemData
	{
		[Header("Furniture Properties")]
		[Tooltip("Type of furniture (Table, Couch, TV)")]
		[SerializeField]
		private FurnitureType furnitureType;

		[Tooltip("Value bonus added to house when this furniture is placed correctly")]
		[SerializeField]
		private int valueBonus;

		[Header("Placement Rules")]
		[Tooltip("If true, this furniture must be placed on a surface (e.g., TV on Table)")]
		[SerializeField]
		private bool requiresSurface;

		[Tooltip("The furniture type this must be placed on (if requiresSurface is true)")]
		[SerializeField]
		private FurnitureType requiredSurfaceType;

		[Tooltip("If true, this furniture must face another furniture (e.g., Couch faces TV)")]
		[SerializeField]
		private bool requiresFacing;

		[Tooltip("The furniture type this must face (if requiresFacing is true)")]
		[SerializeField]
		private FurnitureType requiredFacingTarget;

		[Tooltip("Maximum angle deviation from facing target (degrees)")]
		[SerializeField]
		[Range(5f, 90f)]
		private float facingAngleTolerance;

		[Header("UI Hints")]
		[Tooltip("Short description of placement rules for UI tooltips")]
		[SerializeField]
		private string placementHint;

		public FurnitureType FurnitureType => default(FurnitureType);

		public int ValueBonus => 0;

		public bool RequiresSurface => false;

		public FurnitureType RequiredSurfaceType => default(FurnitureType);

		public bool RequiresFacing => false;

		public FurnitureType RequiredFacingTarget => default(FurnitureType);

		public float FacingAngleTolerance => 0f;

		public string PlacementHint => null;

		public bool HasPlacementRules => false;

		public string GetPlacementRulesDescription()
		{
			return null;
		}
	}
}
