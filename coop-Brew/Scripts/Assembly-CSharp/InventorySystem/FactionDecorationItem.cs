using Brewery.Data;
using UnityEngine;

namespace InventorySystem
{
	[CreateAssetMenu(fileName = "New Faction Decoration", menuName = "Inventory/Faction Decoration")]
	public class FactionDecorationItem : Item
	{
		[Header("Faction Properties")]
		[Tooltip("Which faction this decoration attracts (e.g., Priests, Bikers, etc.)")]
		[SerializeField]
		private FactionData factionData;

		[Tooltip("Percentage boost to faction attraction (e.g., 10 = 10%). Multiple decorations stack up to 100%.")]
		[SerializeField]
		[Range(1f, 100f)]
		private float factionAttractionBonus;

		[Header("Placement Type")]
		[Tooltip("True if this decoration is placed on walls (vertical grids), false for floor placement (horizontal grids)")]
		[SerializeField]
		private bool isWallDecoration;

		[Tooltip("Additional rotation offset applied when placing (Euler angles). Use this to adjust how the decoration faces. Example for walls: (0, 0, 90) or (-90, 0, 0). Test in Unity to find the right values for your prefab.")]
		[SerializeField]
		private Vector3 placementRotationOffset;

		[Header("Visual Info (Optional)")]
		[Tooltip("Decorative description shown in UI (e.g., 'A golden cross that attracts priests')")]
		[TextArea(2, 3)]
		[SerializeField]
		private string decorationDescription;

		[Header("Placement Prefabs")]
		[Tooltip("Material shown when placement preview is valid (green)")]
		[SerializeField]
		private Material validPlacementMaterial;

		[Tooltip("Material shown when placement preview is invalid (red)")]
		[SerializeField]
		private Material invalidPlacementMaterial;

		[Tooltip("Actual prefab spawned when placed (has NetworkObject, PlacedObject, Collider, etc.)")]
		[SerializeField]
		private GameObject placedObjectPrefab;

		[Header("Debug")]
		[Tooltip("Log warnings for missing references during OnValidate.")]
		[SerializeField]
		private bool warnOnMissingReferences;

		public FactionData FactionData => null;

		public float FactionAttractionBonus => 0f;

		public bool IsWallDecoration => false;

		public Vector3 PlacementRotationOffset => default(Vector3);

		public string DecorationDescription => null;

		public Material ValidPlacementMaterial => null;

		public Material InvalidPlacementMaterial => null;

		public GameObject PlacedObjectPrefab => null;

		public override ItemCarryType GetCarryType()
		{
			return default(ItemCarryType);
		}

		public new string GetTooltip()
		{
			return null;
		}
	}
}
